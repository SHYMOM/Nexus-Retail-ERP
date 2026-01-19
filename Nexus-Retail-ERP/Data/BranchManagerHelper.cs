using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;

namespace Nexus_Retail_ERP.Data
{
    internal class BranchManagerHelper
    {
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["NexusDB"]?.ConnectionString;

        public static DataTable GetBranchTransactions(int branchID, int limit = 30)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = $@"
            SELECT TOP {limit}
                Format(TransactionDate, 'hh:mm tt') as Time,
                InvoiceNo as Invoice,
                FinalAmount as Amount,
                PaymentMethod as Method
            FROM Transactions 
            WHERE BranchID = @B 
            ORDER BY TransactionDate DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@B", branchID);
                    DataTable dt = new DataTable();
                    new SqlDataAdapter(cmd).Fill(dt);
                    return dt;
                }
            }
        }

        public static DataTable GetBranchStaff(int branchID)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = @"
            SELECT UserID, FullName, Role, Phone, 
                   CASE WHEN IsActive = 1 THEN 'Active' ELSE 'Inactive' END as Status 
            FROM Users 
            WHERE BranchID = @B AND Role != 'Owner'"; // Exclude Owner

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@B", branchID);
                    DataTable dt = new DataTable();
                    new SqlDataAdapter(cmd).Fill(dt);
                    return dt;
                }
            }
        }


        public static DataTable GetAllTransferHistory(int myBranchID)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = @"
            SELECT * FROM (
                -- 1. MY REQUESTS
                SELECT 
                    sr.RequestDate,
                    'My Request (In)' AS 'Request Type',
                    p.ProductName + ' (' + v.VariantName + ')' AS Product,
                    sr.Quantity,
                    ISNULL(b.BranchName, 'Head Office') AS 'Partner Branch',
                    sr.Status
                FROM StockRequests sr
                LEFT JOIN Branches b ON sr.FromBranchID = b.BranchID
                JOIN Variants v ON sr.VariantID = v.VariantID
                JOIN Products p ON v.ProductID = p.ProductID
                WHERE sr.ToBranchID = @MyBranchID

                UNION ALL

                -- 2. BRANCH REQUESTS
                SELECT 
                    sr.RequestDate,
                    'Branch Request (Out)' AS 'Request Type',
                    p.ProductName + ' (' + v.VariantName + ')' AS Product,
                    sr.Quantity,
                    b.BranchName AS 'Partner Branch',
                    sr.Status
                FROM StockRequests sr
                JOIN Branches b ON sr.ToBranchID = b.BranchID
                JOIN Variants v ON sr.VariantID = v.VariantID
                JOIN Products p ON v.ProductID = p.ProductID
                WHERE sr.FromBranchID = @MyBranchID
            ) AS CombinedHistory
            ORDER BY RequestDate DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MyBranchID", myBranchID);
                    DataTable dt = new DataTable();
                    new SqlDataAdapter(cmd).Fill(dt);
                    return dt;
                }
            }
        }

        public static void GetBranchStats(int branchID, out decimal todaySales, out int lowStockCount, out int pendingRequests)
        {
            todaySales = 0; lowStockCount = 0; pendingRequests = 0;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT ISNULL(SUM(FinalAmount),0) FROM Transactions WHERE BranchID=@B AND CAST(TransactionDate AS DATE) = CAST(GETDATE() AS DATE)", conn))
                {
                    cmd.Parameters.AddWithValue("@B", branchID);
                    todaySales = Convert.ToDecimal(cmd.ExecuteScalar());
                }

                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Inventory WHERE BranchID=@B AND CurrentStock <= LowStockLimit", conn))
                {
                    cmd.Parameters.AddWithValue("@B", branchID);
                    lowStockCount = Convert.ToInt32(cmd.ExecuteScalar());
                }

                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM StockRequests WHERE ToBranchID=@B AND Status='Pending'", conn))
                {
                    cmd.Parameters.AddWithValue("@B", branchID);
                    pendingRequests = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public static DataTable GetIncomingTransferRequests(int myBranchID)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = @"
            SELECT 
                sr.RequestID,
                b.BranchName as 'Requesting Branch',
                p.ProductName + ' (' + v.VariantName + ')' as Product,
                sr.Quantity,
                sr.RequestDate,
                sr.Status
            FROM StockRequests sr
            JOIN Branches b ON sr.ToBranchID = b.BranchID 
            JOIN Variants v ON sr.VariantID = v.VariantID
            JOIN Products p ON v.ProductID = p.ProductID
            WHERE sr.FromBranchID = @MyBranchID AND sr.Status = 'Pending'
            ORDER BY sr.RequestDate DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MyBranchID", myBranchID);
                    DataTable dt = new DataTable();
                    new SqlDataAdapter(cmd).Fill(dt);
                    return dt;
                }
            }
        }

        public static bool ProcessTransferRequest(int requestID, bool isApproved, int approverID)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    int varID = 0, qty = 0, sourceBranch = 0, destBranch = 0;
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM StockRequests WHERE RequestID = @ID", conn, trans))
                    {
                        cmd.Parameters.AddWithValue("@ID", requestID);
                        using (SqlDataReader r = cmd.ExecuteReader())
                        {
                            if (r.Read())
                            {
                                varID = (int)r["VariantID"];
                                qty = (int)r["Quantity"];
                                sourceBranch = (int)r["FromBranchID"];
                                destBranch = (int)r["ToBranchID"];
                            }
                            else return false;
                        }
                    }

                    string status = isApproved ? "Approved" : "Rejected";

                    if (isApproved)
                    {
                        int myStock = 0;
                        string checkSql = "SELECT CurrentStock FROM Inventory WHERE BranchID=@B AND VariantID=@V";
                        using (SqlCommand cmd = new SqlCommand(checkSql, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@B", sourceBranch);
                            cmd.Parameters.AddWithValue("@V", varID);
                            object res = cmd.ExecuteScalar();
                            if (res != null) myStock = Convert.ToInt32(res);
                        }

                        if (myStock < qty)
                        {
                            throw new Exception($"Insufficient Stock. You have {myStock}, request is {qty}.");
                        }

                        string deductSql = "UPDATE Inventory SET CurrentStock = CurrentStock - @Q WHERE BranchID=@B AND VariantID=@V";
                        using (SqlCommand cmd = new SqlCommand(deductSql, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@Q", qty);
                            cmd.Parameters.AddWithValue("@B", sourceBranch);
                            cmd.Parameters.AddWithValue("@V", varID);
                            cmd.ExecuteNonQuery();
                        }


                        string addSql = @"
                    MERGE Inventory AS target
                    USING (SELECT @B AS BranchID, @V AS VariantID) AS source
                    ON (target.BranchID = source.BranchID AND target.VariantID = source.VariantID)
                    WHEN MATCHED THEN UPDATE SET CurrentStock = CurrentStock + @Q
                    WHEN NOT MATCHED THEN INSERT (BranchID, VariantID, CurrentStock, LowStockLimit) VALUES (@B, @V, @Q, 10);";

                        using (SqlCommand cmd = new SqlCommand(addSql, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@Q", qty);
                            cmd.Parameters.AddWithValue("@B", destBranch);
                            cmd.Parameters.AddWithValue("@V", varID);
                            cmd.ExecuteNonQuery();
                        }
                    }


                    string updateSql = "UPDATE StockRequests SET Status = @S WHERE RequestID = @ID";

                    using (SqlCommand cmd = new SqlCommand(updateSql, conn, trans))
                    {
                        cmd.Parameters.AddWithValue("@S", status);
                        cmd.Parameters.AddWithValue("@ID", requestID);
                        cmd.ExecuteNonQuery();
                    }

                    trans.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
