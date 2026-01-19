using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;

namespace Nexus_Retail_ERP.Data
{
    internal class POSHelper
    {
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["NexusDB"]?.ConnectionString;

        public static string GetBranchNameByID(int branchID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT BranchName FROM Branches WHERE BranchID = @BranchID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BranchID", branchID);
                        return cmd.ExecuteScalar().ToString();
                    }
                }
            }
            catch { return ""; }
        }

        public static bool AddCustomer(string name, string phone, string email, string address, DateTime? dob)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                INSERT INTO Customers (CustomerName, Phone, Email, Address, DOB, TotalSpent, LoyaltyPoints)
                VALUES (@Name, @Phone, @Email, @Address, @DOB, 0, 0)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Phone", phone);
                        cmd.Parameters.AddWithValue("@Email", (object)email ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Address", (object)address ?? DBNull.Value);

                        if (dob.HasValue)
                            cmd.Parameters.AddWithValue("@DOB", dob.Value);
                        else
                            cmd.Parameters.AddWithValue("@DOB", DBNull.Value);

                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Add Customer Error: " + ex.Message);
                return false;
            }
        }

        /* public static bool SendTransferRequest(int fromBranchID, int toBranchID, int variantID, int qty, int userID)
         {
             try
             {
                 using (SqlConnection conn = new SqlConnection(ConnectionString))
                 {
                     conn.Open();
                     string query = @"
                 INSERT INTO StockRequests 
                 (RequestType, Quantity, Status, RequestDate, FromBranchID, ToBranchID, VariantID, RequestedBy)
                 VALUES 
                 ('Transfer', @Qty, 'Pending', GETDATE(), @FromBranch, @ToBranch, @Var, @User)";

                     using (SqlCommand cmd = new SqlCommand(query, conn))
                     {
                         cmd.Parameters.AddWithValue("@Qty", qty);
                         cmd.Parameters.AddWithValue("@FromBranch", fromBranchID);
                         cmd.Parameters.AddWithValue("@ToBranch", toBranchID);
                         cmd.Parameters.AddWithValue("@Var", variantID);
                         cmd.Parameters.AddWithValue("@User", userID);
                         cmd.ExecuteNonQuery();
                     }
                     return true;
                 }
             }
             catch (Exception ex)
             {
                 System.Diagnostics.Debug.WriteLine(ex.Message);
                 return false;
             }
         }

        public static bool SendTransferRequest(int fromBranch, int? toBranch, int varID, int qty, int userID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string type = (toBranch == null || toBranch == 0) ? "Restock" : "Transfer";

                    string query = @"
                INSERT INTO StockRequests 
                (RequestType, Quantity, Status, RequestDate, FromBranchID, ToBranchID, VariantID, RequestedBy) 
                VALUES 
                (@Type, @Qty, 'Pending', GETDATE(), @From, @To, @Var, @User)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Type", type);
                        cmd.Parameters.AddWithValue("@Qty", qty);
                        cmd.Parameters.AddWithValue("@From", fromBranch);
                        if (toBranch == null || toBranch == 0)
                        {
                            cmd.Parameters.AddWithValue("@To", DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@To", toBranch);
                        }
                        cmd.Parameters.AddWithValue("@Var", varID);
                        cmd.Parameters.AddWithValue("@User", userID);

                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Request Error: " + ex.Message);
                return false;
            }
        }
        */

        public static bool SendTransferRequest(int? sourceBranchID, int destBranchID, int varID, int qty, int userID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    string type = (sourceBranchID == null || sourceBranchID == 0) ? "Restock" : "Transfer";

                    string query = @"
                INSERT INTO StockRequests 
                (RequestType, Quantity, Status, RequestDate, FromBranchID, ToBranchID, VariantID, RequestedBy) 
                VALUES 
                (@Type, @Qty, 'Pending', GETDATE(), @From, @To, @Var, @User)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Type", type);
                        cmd.Parameters.AddWithValue("@Qty", qty);

                        if (sourceBranchID == null || sourceBranchID == 0)
                        {
                            cmd.Parameters.AddWithValue("@From", DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@From", sourceBranchID);
                        }

                        cmd.Parameters.AddWithValue("@To", destBranchID);
                        cmd.Parameters.AddWithValue("@Var", varID);
                        cmd.Parameters.AddWithValue("@User", userID);

                        cmd.ExecuteNonQuery();
                    }
                    string fromBranch = (sourceBranchID == null || sourceBranchID == 0) ? "HEAD OFFICE" : $"Branch #{sourceBranchID}";
                    string toBranch = $"Branch #{destBranchID}";

                    string prodName = DatabaseHelper.GetProductNameByID(varID);
                    string userName = DatabaseHelper.GetUserNameByID(userID);

                    DatabaseHelper.NotifyOwner_StockRequest(type, fromBranch, toBranch, prodName, qty, userName);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("DB Error: " + ex.Message);
            }
        }


        public static DataTable GetStockAvailability(int variantID, int excludeBranchID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    b.BranchID,
                    b.BranchName,
                    i.CurrentStock
                FROM Inventory i
                INNER JOIN Branches b ON i.BranchID = b.BranchID
                WHERE i.VariantID = @Var 
                  AND i.BranchID != @Exclude 
                  AND i.CurrentStock > 0
                ORDER BY i.CurrentStock DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Var", variantID);
                        cmd.Parameters.AddWithValue("@Exclude", excludeBranchID);
                        DataTable dt = new DataTable();
                        new SqlDataAdapter(cmd).Fill(dt);
                        return dt;
                    }
                }
            }
            catch { return new DataTable(); }
        }


        public static bool RequestStockTransfer(int variantID, int branchID, int userID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                INSERT INTO StockRequests (RequestType, Quantity, Status, RequestDate, FromBranchID, VariantID, RequestedBy)
                VALUES ('Restock', 10, 'Pending', GETDATE(), @Branch, @Var, @User)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Branch", branchID);
                        cmd.Parameters.AddWithValue("@Var", variantID);
                        cmd.Parameters.AddWithValue("@User", userID);
                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Request Error: " + ex.Message);
                return false;
            }
        }


        public static bool SaveTransaction(int branchID, int userID, int? customerID, decimal totalAmount, decimal discountAmount, int pointsUsed, decimal finalPaid, decimal totalTax, DataTable cartItems, string payMethod, string refNo, out string invoiceNo)
        {
            invoiceNo = "INV-" + DateTime.Now.ToString("yyyyMMdd-HHmmss");

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    string masterSql = @"
                INSERT INTO Transactions 
                (InvoiceNo, TotalAmount, DiscountAmount, FinalAmount, PaymentMethod, BranchID, UserID, CustomerID, TransactionDate)
                VALUES 
                (@Inv, @Total, @Disc, @Final, @Method, @Branch, @User, @Cust, GETDATE());
                SELECT SCOPE_IDENTITY();";

                    int transID;
                    using (SqlCommand cmd = new SqlCommand(masterSql, conn, trans))
                    {
                        cmd.Parameters.AddWithValue("@Inv", invoiceNo);
                        cmd.Parameters.AddWithValue("@Total", totalAmount);
                        cmd.Parameters.AddWithValue("@Disc", discountAmount + pointsUsed);
                        cmd.Parameters.AddWithValue("@Final", finalPaid);
                        cmd.Parameters.AddWithValue("@Method", payMethod);
                        cmd.Parameters.AddWithValue("@Branch", branchID);
                        cmd.Parameters.AddWithValue("@User", userID);
                        cmd.Parameters.AddWithValue("@Cust", (object)customerID ?? DBNull.Value);

                        transID = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    if (finalPaid > 0)
                    {
                        string finSql = "INSERT INTO FinancialRecords (TransactionID, PaymentMethod, Amount, ReferenceNo, Description) VALUES (@TID, @Method, @Amt, @Ref, @Desc)";
                        using (SqlCommand cmd = new SqlCommand(finSql, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@TID", transID);
                            cmd.Parameters.AddWithValue("@Method", payMethod);
                            cmd.Parameters.AddWithValue("@Amt", finalPaid);
                            cmd.Parameters.AddWithValue("@Ref", (object)refNo ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@Desc", "POS Sale: " + invoiceNo);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    foreach (DataRow row in cartItems.Rows)
                    {
                        int variantID = Convert.ToInt32(row["VariantID"]);
                        int qty = Convert.ToInt32(row["Qty"]);
                        decimal price = Convert.ToDecimal(row["Price"]);
                        decimal taxRate = Convert.ToDecimal(row["TaxRate"]);
                        decimal lineTax = (price * qty) * (taxRate / 100);

                        string detailSql = "INSERT INTO TransactionDetails (TransactionID, VariantID, Quantity, UnitPrice, TaxAmount, Subtotal) VALUES (@TID, @Var, @Qty, @Price, @Tax, @Sub)";
                        using (SqlCommand cmd = new SqlCommand(detailSql, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@TID", transID);
                            cmd.Parameters.AddWithValue("@Var", variantID);
                            cmd.Parameters.AddWithValue("@Qty", qty);
                            cmd.Parameters.AddWithValue("@Price", price);
                            cmd.Parameters.AddWithValue("@Tax", lineTax);
                            cmd.Parameters.AddWithValue("@Sub", (price * qty) + lineTax);
                            cmd.ExecuteNonQuery();
                        }

                        string stockSql = "UPDATE Inventory SET CurrentStock = CurrentStock - @Qty WHERE VariantID = @Var AND BranchID = @Branch";
                        using (SqlCommand cmd = new SqlCommand(stockSql, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@Qty", qty);
                            cmd.Parameters.AddWithValue("@Var", variantID);
                            cmd.Parameters.AddWithValue("@Branch", branchID);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    if (customerID.HasValue)
                    {
                        if (pointsUsed > 0)
                        {
                            string burnSql = "UPDATE Customers SET LoyaltyPoints = LoyaltyPoints - @Used WHERE CustomerID = @Cust";
                            using (SqlCommand cmd = new SqlCommand(burnSql, conn, trans))
                            {
                                cmd.Parameters.AddWithValue("@Used", pointsUsed);
                                cmd.Parameters.AddWithValue("@Cust", customerID.Value);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        // 1 Point for every 500 Taka paid
                        int pointsEarned = (int)(finalPaid / 500);
                        if (pointsEarned > 0)
                        {
                            string earnSql = "UPDATE Customers SET TotalSpent = TotalSpent + @Paid, LoyaltyPoints = LoyaltyPoints + @Earned WHERE CustomerID = @Cust";
                            using (SqlCommand cmd = new SqlCommand(earnSql, conn, trans))
                            {
                                cmd.Parameters.AddWithValue("@Paid", finalPaid);
                                cmd.Parameters.AddWithValue("@Earned", pointsEarned);
                                cmd.Parameters.AddWithValue("@Cust", customerID.Value);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    trans.Commit();
                    return true;
                }
                catch (Exception ex) { trans.Rollback(); return false; }
            }
        }


        public static DataRow GetCustomerByPhone(string phone)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT CustomerID, CustomerName, Phone, LoyaltyPoints, DOB FROM Customers WHERE Phone = @Phone";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Phone", phone);
                        DataTable dt = new DataTable();
                        new SqlDataAdapter(cmd).Fill(dt);
                        if (dt.Rows.Count > 0) return dt.Rows[0];
                        return null;
                    }
                }
            }
            catch { return null; }
        }

        public static DataTable GetPOSProducts(int branchID, string search = "")
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    v.VariantID,
                    p.ProductName,
                    v.VariantName,
                    v.SalesPrice,
                    i.CurrentStock, 
                    p.TaxRate, 
                    p.ProductImagePath
                FROM Inventory i
                INNER JOIN Variants v ON i.VariantID = v.VariantID
                INNER JOIN Products p ON v.ProductID = p.ProductID
                WHERE 
                    i.BranchID = @BranchID 
                    AND p.IsActive = 1
                    AND (p.ProductName LIKE @Search OR v.SKU LIKE @Search)
                ORDER BY p.ProductName";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BranchID", branchID);
                        cmd.Parameters.AddWithValue("@Search", "%" + search + "%");

                        DataTable dt = new DataTable();
                        new SqlDataAdapter(cmd).Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Product Load Error: " + ex.Message);
                return new DataTable();
            }
        }

    }
}
