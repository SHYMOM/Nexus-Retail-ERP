using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using Timer = System.Timers.Timer;
using System.Configuration;

namespace Nexus_Retail_ERP.Data
{
    internal class OwnerDashboardHelper
    {
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["NexusDB"]?.ConnectionString;

        ////////////////////////////////////////////////////////////////////////////Ownwr Dashboard Needs//////////////////////////////////////////////////////////

        public static decimal GetTodayRevenue()
        {
            decimal todayRevenue = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT ISNULL(SUM(FinalAmount), 0) as TodayRevenue
                        FROM Transactions 
                        WHERE CONVERT(date, TransactionDate) = CONVERT(date, GETDATE())";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            todayRevenue = Convert.ToDecimal(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetTodayRevenue: {ex.Message}");
            }
            return todayRevenue;
        }

        public static string GetBestBranchToday()
        {
            string bestBranch = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT TOP 1 b.BranchName, SUM(t.FinalAmount) as TotalSales
                        FROM Transactions t
                        INNER JOIN Branches b ON t.BranchID = b.BranchID
                        WHERE CONVERT(date, t.TransactionDate) = CONVERT(date, GETDATE())
                        GROUP BY b.BranchName
                        ORDER BY TotalSales DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            bestBranch = reader["BranchName"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetBestBranchToday: {ex.Message}");
            }
            return bestBranch;
        }

        public static decimal GetTodayDamageLoss()
        {
            decimal todayLoss = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT ISNULL(SUM(d.Quantity * v.CostPrice), 0) as TodayLoss
                        FROM DamagedStock d
                        INNER JOIN Variants v ON d.VariantID = v.VariantID
                        WHERE CONVERT(date, d.ReportedDate) = CONVERT(date, GETDATE())";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            todayLoss = Convert.ToDecimal(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetTodayDamageLoss: {ex.Message}");
            }
            return todayLoss;
        }

        public static List<dynamic> GetGlobalTransactions(int limit)
        {
            var transactions = new List<dynamic>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT TOP (@limit) 
                            t.TransactionDate as Time,
                            b.BranchName as Branch,
                            u.FullName as Cashier,
                            t.FinalAmount as Amount,
                            'Completed' as Status
                        FROM Transactions t
                        INNER JOIN Branches b ON t.BranchID = b.BranchID
                        INNER JOIN Users u ON t.UserID = u.UserID
                        ORDER BY t.TransactionDate DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@limit", limit);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                transactions.Add(new
                                {
                                    Time = Convert.ToDateTime(reader["Time"]),
                                    Branch = reader["Branch"].ToString(),
                                    Cashier = reader["Cashier"].ToString(),
                                    Amount = Convert.ToDecimal(reader["Amount"]),
                                    Status = "Completed" //TODO : Currently Transactions table doesn't have Status column
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetGlobalTransactions: {ex.Message}");
            }
            return transactions;
        }
        public static int GetTotalTransactionsToday()
        {
            int count = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT COUNT(*) as TotalTransactions
                        FROM Transactions 
                        WHERE CONVERT(date, TransactionDate) = CONVERT(date, GETDATE())";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            count = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetTotalTransactionsToday: {ex.Message}");
            }
            return count;
        }

        public static int GetTotalBranches()
        {
            int count = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) as TotalBranches FROM Branches WHERE IsActive = 1";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            count = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetTotalBranches: {ex.Message}");
            }
            return count;
        }

        public static int GetActiveStaffCount()
        {
            int count = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT COUNT(*) as ActiveStaff 
                        FROM Users 
                        WHERE IsActive = 1 
                        AND Role IN ('Manager', 'Cashier')";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            count = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetActiveStaffCount: {ex.Message}");
            }
            return count;
        }

        public static int GetPendingApprovalsCount()
        {
            int count = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT COUNT(*) as PendingApprovals
                        FROM StockRequests 
                        WHERE Status = 'Pending'";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            count = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetPendingApprovalsCount: {ex.Message}");
            }
            return count;
        }

        public static List<string> GetSecurityAuditLogs(int limit)
        {
            var logs = new List<string>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT TOP (@limit) 
                            CONCAT(
                                u.Username, 
                                ' - ',
                                al.Action,
                                ' at ',
                                FORMAT(al.LogDate, 'hh:mm tt'),
                                ' (',
                                al.TableName,
                                ')'
                            ) as LogEntry
                        FROM AuditLogs al
                        INNER JOIN Users u ON al.UserID = u.UserID
                        ORDER BY al.LogDate DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@limit", limit);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                logs.Add(reader["LogEntry"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetSecurityAuditLogs: {ex.Message}");
            }

            if (logs.Count == 0)
            {
                logs.Add($"Owner logged in at {DateTime.Now:hh:mm tt}");
                logs.Add("System initialized. Ready for monitoring.");
                logs.Add("All systems operational");
            }

            return logs;
        }

        public static List<dynamic> GetPendingApprovals()
        {
            var approvals = new List<dynamic>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            sr.RequestID as ID,
                            bFrom.BranchName as Branch,
                            sr.Quantity as ItemCount,
                            sr.Status,
                            sr.RequestType as Type
                        FROM StockRequests sr
                        INNER JOIN Branches bFrom ON sr.FromBranchID = bFrom.BranchID
                        WHERE sr.Status = 'Pending'
                        ORDER BY sr.RequestDate ASC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            approvals.Add(new
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                Branch = reader["Branch"].ToString(),
                                ItemCount = Convert.ToInt32(reader["ItemCount"]),
                                Status = reader["Status"].ToString(),
                                Type = reader["Type"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetPendingApprovals: {ex.Message}");
            }
            return approvals;
        }

        public static bool ApproveRequest(int requestId, int approvedByUserId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    string getRequestQuery = @"
                        SELECT RequestType, Quantity, VariantID, ToBranchID, FromBranchID
                        FROM StockRequests 
                        WHERE RequestID = @RequestID";

                    using (SqlCommand getCmd = new SqlCommand(getRequestQuery, conn))
                    {
                        getCmd.Parameters.AddWithValue("@RequestID", requestId);

                        using (SqlDataReader reader = getCmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string requestType = reader["RequestType"].ToString();
                                int quantity = Convert.ToInt32(reader["Quantity"]);
                                int variantId = Convert.ToInt32(reader["VariantID"]);
                                int toBranchId = Convert.ToInt32(reader["ToBranchID"]);
                                int fromBranchId = Convert.ToInt32(reader["FromBranchID"]);

                                reader.Close();

                                if (requestType == "Restock")
                                {
                                    string updateInventoryQuery = @"
                                        UPDATE Inventory 
                                        SET Quantity = Quantity + @Quantity
                                        WHERE BranchID = @BranchID AND VariantID = @VariantID";

                                    using (SqlCommand updateCmd = new SqlCommand(updateInventoryQuery, conn))
                                    {
                                        updateCmd.Parameters.AddWithValue("@Quantity", quantity);
                                        updateCmd.Parameters.AddWithValue("@BranchID", toBranchId);
                                        updateCmd.Parameters.AddWithValue("@VariantID", variantId);
                                        updateCmd.ExecuteNonQuery();
                                    }
                                }

                                string updateRequestQuery = @"
                                    UPDATE StockRequests 
                                    SET Status = 'Approved' 
                                    WHERE RequestID = @RequestID";

                                using (SqlCommand updateCmd = new SqlCommand(updateRequestQuery, conn))
                                {
                                    updateCmd.Parameters.AddWithValue("@RequestID", requestId);
                                    updateCmd.ExecuteNonQuery();
                                }

                                return true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in ApproveRequest: {ex.Message}");
                return false;
            }
            return false;
        }

        public static bool RejectRequest(int requestId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                        UPDATE StockRequests 
                        SET Status = 'Rejected' 
                        WHERE RequestID = @RequestID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@RequestID", requestId);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in RejectRequest: {ex.Message}");
                return false;
            }
        }
    }
}
