using Microsoft.Data.SqlClient;
using Nexus_Retail_ERP.Forms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using Nexus_Retail_ERP.Models;

namespace Nexus_Retail_ERP.Data
{
    public static class DatabaseHelper
    {
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["NexusDB"]?.ConnectionString;

        // =========================================================
        // Branches
        // =========================================================
        public static List<BranchInfo> GetAllBranches(bool includeInactive)
        {
            var branches = new List<BranchInfo>();
            string query;

            if (includeInactive)
            {
                query = @"
                        SELECT 
                            BranchID,
                            BranchName,
                            Location,
                            Phone,
                            IsActive
                        FROM Branches 
                        ORDER BY BranchName";
            }
            else
            {
                query = @"
                        SELECT 
                            BranchID,
                            BranchName,
                            Location,
                            Phone,
                            IsActive
                        FROM Branches 
                        WHERE IsActive = 1 
                        ORDER BY BranchName";
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                branches.Add(new BranchInfo
                                {
                                    BranchID = Convert.ToInt32(reader["BranchID"]),
                                    BranchName = reader["BranchName"].ToString(),
                                    Location = reader["Location"].ToString(),
                                    Phone = reader["Phone"].ToString(),
                                    IsActive = Convert.ToBoolean(reader["IsActive"])
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to load branches: {ex.Message}", ex);
            }

            return branches;
        }

        public static bool DeleteBranch(int branchID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "UPDATE Branches SET IsActive = 0 WHERE BranchID = @BranchID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BranchID", branchID);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete branch: {ex.Message}", ex);
            }
        }

        public static bool AddBranch(string branchName, string location, string phone, bool IsActive)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Branches (BranchName, Location, Phone, IsActive) VALUES (@BranchName, @Location, @Phone, @IsActive)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BranchName", branchName);
                        cmd.Parameters.AddWithValue("@Location", location);
                        cmd.Parameters.AddWithValue("@Phone", phone);
                        cmd.Parameters.AddWithValue("@IsActive", IsActive);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to add branch: {ex.Message}", ex);
            }
        }

        public static bool UpdateBranch(int branchID, string branchName, string location, string phone, bool IsActive)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "UPDATE Branches SET BranchName = @BranchName, Location = @Location, Phone = @Phone, IsActive = @IsActive WHERE BranchID = @BranchID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BranchID", branchID);
                        cmd.Parameters.AddWithValue("@BranchName", branchName);
                        cmd.Parameters.AddWithValue("@Location", location);
                        cmd.Parameters.AddWithValue("@Phone", phone);
                        cmd.Parameters.AddWithValue("@IsActive", IsActive);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update branch: {ex.Message}", ex);
            }
        }


        // =========================================================
        // Categories
        // =========================================================

        public static List<Category> GetAllCategories()
        {
            return ProductMasterHelper.GetAllCategories();
        }

        public static bool AddCategory(string categoryName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Categories (CategoryName) VALUES (@CategoryName)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CategoryName", categoryName);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to add category: {ex.Message}", ex);
            }
        }

        public static bool UpdateCategory(int categoryID, string categoryName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "UPDATE Categories SET CategoryName = @CategoryName WHERE CategoryID = @CategoryID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CategoryID", categoryID);
                        cmd.Parameters.AddWithValue("@CategoryName", categoryName);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update category: {ex.Message}", ex);
            }
        }

        public static bool DeleteCategory(int categoryID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM Categories WHERE CategoryID = @CategoryID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CategoryID", categoryID);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete category: {ex.Message}", ex);
            }
        }


        // =============================================================
        //  INVENTORY HELPER METHODS
        // =============================================================

        // 1. Get Missing Products
        // Retrieves a list of Product Variants that exist in the system 
        // but are NOT yet tracked in the Inventory table for the selected Branch.
        public static DataTable GetMissingProducts(int branchID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    v.VariantID, 
                    v.ProductID,
                    (p.ProductName + ' [' + v.VariantName + ']') AS FullProductName
                FROM Variants v
                INNER JOIN Products p ON v.ProductID = p.ProductID
                WHERE v.VariantID NOT IN (
                    SELECT VariantID FROM Inventory WHERE BranchID = @BranchID
                )
                ORDER BY p.ProductName, v.VariantName";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BranchID", branchID);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log error (optional)
                System.Diagnostics.Debug.WriteLine("GetMissingProducts Error: " + ex.Message);
                return new DataTable(); // Return empty table to prevent crash
            }
        }

        // 2. Update Low Stock Limit
        // Updates the warning threshold for a specific inventory item.
        public static bool UpdateLowStockLimit(int inventoryID, int newLimit)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "UPDATE Inventory SET LowStockLimit = @Limit WHERE InventoryID = @ID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Limit", newLimit);
                        cmd.Parameters.AddWithValue("@ID", inventoryID);

                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("UpdateLowStockLimit Error: " + ex.Message);
                return false;
            }
        }

        // 3. Register Inventory Item
        // Adds a new row to the Inventory table to start tracking a specific variant at a specific branch.
        public static bool RegisterInventoryItem(int productID, int variantID, int branchID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                INSERT INTO Inventory (ProductID, VariantID, BranchID, CurrentStock, LowStockLimit)
                VALUES (@Prod, @Var, @Branch, 0, 10)"; // Defaults: 0 Stock, 10 Limit

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Prod", productID);
                        cmd.Parameters.AddWithValue("@Var", variantID);
                        cmd.Parameters.AddWithValue("@Branch", branchID);

                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("RegisterInventoryItem Error: " + ex.Message);
                return false;
            }
        }

        public static bool AdjustStock(int inventoryID, int adjustmentQty, string reason, int userID)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // 1. Get Current Stock (For Logging)
                    int currentStock = 0;
                    string getStockQuery = "SELECT CurrentStock FROM Inventory WHERE InventoryID = @ID";
                    using (SqlCommand cmd = new SqlCommand(getStockQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@ID", inventoryID);
                        object result = cmd.ExecuteScalar();
                        if (result != null) currentStock = Convert.ToInt32(result);
                    }

                    // 2. Update Inventory
                    string updateQuery = @"
                UPDATE Inventory 
                SET CurrentStock = CurrentStock + @Qty 
                WHERE InventoryID = @ID";

                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@Qty", adjustmentQty);
                        cmd.Parameters.AddWithValue("@ID", inventoryID);
                        cmd.ExecuteNonQuery();
                    }

                    // 3. Log Action in AuditLogs
                    // Note: We use the existing table structure we created earlier
                    string logQuery = @"
                INSERT INTO AuditLogs (UserID, Action, TableName, RecordID, OldValue, NewValue, LogDate)
                VALUES (@UserID, 'STOCK_ADJUST', 'Inventory', @RecordID, @OldVal, @NewVal, GETDATE())";

                    using (SqlCommand cmd = new SqlCommand(logQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        cmd.Parameters.AddWithValue("@RecordID", inventoryID);
                        cmd.Parameters.AddWithValue("@OldVal", currentStock.ToString());
                        cmd.Parameters.AddWithValue("@NewVal", (currentStock + adjustmentQty).ToString());
                        cmd.ExecuteNonQuery();
                    }

                    // 4. Commit Transaction
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    // If anything goes wrong, undo changes
                    transaction.Rollback();
                    System.Diagnostics.Debug.WriteLine("Stock Update Failed: " + ex.Message);
                    return false;
                }
            }
        }

        public static DataTable GetInventoryData(int branchID, string searchTerm)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    i.InventoryID,
                    i.ProductID,
                    i.VariantID,
                    i.BranchID,
                    p.ProductName,
                    v.VariantName,
                    b.BranchName,
                    i.CurrentStock,
                    i.LowStockLimit
                FROM Inventory i
                INNER JOIN Products p ON i.ProductID = p.ProductID
                INNER JOIN Variants v ON i.VariantID = v.VariantID
                INNER JOIN Branches b ON i.BranchID = b.BranchID
                WHERE 
                    (i.BranchID = @BranchID OR @BranchID = 0) -- 0 means 'All Branches'
                    AND 
                    (p.ProductName LIKE @Search OR v.VariantName LIKE @Search)
                ORDER BY p.ProductName, b.BranchName";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BranchID", branchID);
                        cmd.Parameters.AddWithValue("@Search", "%" + searchTerm + "%");

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Ideally, log this error to a file
                System.Diagnostics.Debug.WriteLine("Inventory Load Error: " + ex.Message);
                return new DataTable(); // Return empty table on error to prevent crash
            }
        }


        // =============================================================
        //  EMPLOYEE MANAGEMENT METHODS
        // =============================================================

        // 1. Get All Employees (Searchable)
        // Fetches list of users joined with their Branch Name
        public static DataTable GetAllEmployees(string searchTerm)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    u.UserID,
                    u.FullName,
                    u.Username,
                    u.Role,
                    u.Phone,
                    b.BranchName,
                    u.Salary,
                    u.IsActive,
                    u.BranchID,
                    u.ProfileImagePath
                FROM Users u
                LEFT JOIN Branches b ON u.BranchID = b.BranchID
                WHERE 
                    u.Role != 'Owner' -- Usually we hide the Main Owner from general lists
                    AND (
                        u.FullName LIKE @Search OR 
                        u.Username LIKE @Search OR 
                        u.Phone LIKE @Search OR
                        b.BranchName LIKE @Search
                    )
                ORDER BY u.IsActive DESC, u.FullName ASC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Search", "%" + searchTerm + "%");

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("GetAllEmployees Error: " + ex.Message);
                return new DataTable(); // Return empty table to prevent crash
            }
        }

        // 2. Update Employee Details
        // Updates role, salary, branch, and active status
        public static bool UpdateEmployee(int userID, string role, decimal salary, int branchID, bool isActive)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                UPDATE Users 
                SET 
                    Role = @Role, 
                    Salary = @Salary, 
                    BranchID = @BranchID, 
                    IsActive = @IsActive
                WHERE UserID = @UserID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Role", role);
                        cmd.Parameters.AddWithValue("@Salary", salary);
                        cmd.Parameters.AddWithValue("@BranchID", branchID);
                        cmd.Parameters.AddWithValue("@IsActive", isActive);
                        cmd.Parameters.AddWithValue("@UserID", userID);

                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("UpdateEmployee Error: " + ex.Message);
                return false;
            }
        }



        // =========================================================
        // Authentication
        // =========================================================

        public static AuthResult AuthenticateUser(string username, string passwordHash)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            u.UserID,
                            u.Role,
                            u.FullName,
                            u.BranchID,
                            b.BranchName
                        FROM Users u
                        LEFT JOIN Branches b ON u.BranchID = b.BranchID
                        WHERE u.Username = @Username 
                            AND u.PasswordHash = @PasswordHash
                            AND u.IsActive = 1";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new AuthResult
                                {
                                    IsAuthenticated = true,
                                    UserID = Convert.ToInt32(reader["UserID"]),
                                    Role = reader["Role"].ToString(),
                                    FullName = reader["FullName"].ToString(),
                                    BranchID = reader["BranchID"] != DBNull.Value ?
                                               Convert.ToInt32(reader["BranchID"]) : 0,
                                    BranchName = reader["BranchName"] != DBNull.Value ?
                                                reader["BranchName"].ToString() : "Head Office"
                                };
                            }
                        }
                    }
                }

                return new AuthResult { IsAuthenticated = false };
            }
            catch (Exception ex)
            {
                throw new Exception($"Authentication failed: {ex.Message}", ex);
            }
        }

        public static string ComputeSHA256Hash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString().ToUpper();
            }
        }

        public static List<string> GetAvailableRoles()
        {
            return new List<string> { "Owner", "Manager", "Cashier" };
        }


        public static bool IsUsernameAvailable(string username)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        int count = (int)cmd.ExecuteScalar();
                        return count == 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool IsPhoneAvailable(string phone)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Users WHERE Phone = @Phone";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Phone", phone);
                        int count = (int)cmd.ExecuteScalar();
                        return count == 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }


        private static int GetLastInsertedUserID(SqlConnection conn)
        {
            try
            {
                string query = "SELECT SCOPE_IDENTITY()";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    object result = cmd.ExecuteScalar();
                    return result != DBNull.Value ? Convert.ToInt32(result) : 0;
                }
            }
            catch
            {
                return 0;
            }
        }

        private static void LogUserAction(int userID, string action, string tableName, int? recordID, string oldValue, string newValue)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                        INSERT INTO AuditLogs (
                            UserID, 
                            Action, 
                            TableName, 
                            RecordID, 
                            OldValue, 
                            NewValue, 
                            LogDate
                        ) VALUES (
                            @UserID, 
                            @Action, 
                            @TableName, 
                            @RecordID, 
                            @OldValue, 
                            @NewValue, 
                            GETDATE()
                        )";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        cmd.Parameters.AddWithValue("@Action", action);
                        cmd.Parameters.AddWithValue("@TableName", tableName);

                        if (recordID.HasValue)
                            cmd.Parameters.AddWithValue("@RecordID", recordID.Value);
                        else
                            cmd.Parameters.AddWithValue("@RecordID", DBNull.Value);

                        cmd.Parameters.AddWithValue("@OldValue", oldValue ?? "");
                        cmd.Parameters.AddWithValue("@NewValue", newValue ?? "");

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Failed to log user action: {ex.Message}");
            }
        }

        public static bool TestConnection()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    return conn.State == ConnectionState.Open;
                }
            }
            catch
            {
                return false;
            }
        }


        public static bool RegisterEmployee(
            string username,
            string password,
            string role,
            string fullName,
            string phone,
            string address,
            DateTime? dob,
            decimal salary,
            string profileImagePath,
            int branchID,
            out string message)
        {
            message = "";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    string checkQuery = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Username", username);
                        int userCount = (int)checkCmd.ExecuteScalar();

                        if (userCount > 0)
                        {
                            message = "Username already exists. Please choose a different username.";
                            return false;
                        }
                    }

                    checkQuery = "SELECT COUNT(*) FROM Users WHERE Phone = @Phone";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Phone", phone);
                        int phoneCount = (int)checkCmd.ExecuteScalar();

                        if (phoneCount > 0)
                        {
                            message = "Phone number already registered. Please use a different phone number.";
                            return false;
                        }
                    }


                    string passwordHash = ComputeSHA256Hash(password);

                    string insertQuery = @"
                        INSERT INTO Users (
                            Username, 
                            PasswordHash,
                            Role, 
                            FullName, 
                            Phone, 
                            Address, 
                            DOB, 
                            Salary, 
                            ProfileImagePath, 
                            IsActive, 
                            BranchID,
                            LastLogin
                        ) VALUES (
                            @Username, 
                            @PasswordHash,
                            @Role, 
                            @FullName, 
                            @Phone, 
                            @Address, 
                            @DOB, 
                            @Salary, 
                            @ProfileImagePath, 
                            1, 
                            @BranchID,
                            GETDATE()
                        )";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);
                        cmd.Parameters.AddWithValue("@Role", role);
                        cmd.Parameters.AddWithValue("@FullName", fullName);
                        cmd.Parameters.AddWithValue("@Phone", phone);
                        cmd.Parameters.AddWithValue("@Address", address ?? "");

                        if (dob.HasValue)
                            cmd.Parameters.AddWithValue("@DOB", dob.Value);
                        else
                            cmd.Parameters.AddWithValue("@DOB", DBNull.Value);

                        cmd.Parameters.AddWithValue("@Salary", salary);

                        if (!string.IsNullOrEmpty(profileImagePath))
                            cmd.Parameters.AddWithValue("@ProfileImagePath", profileImagePath);
                        else
                            cmd.Parameters.AddWithValue("@ProfileImagePath", DBNull.Value);

                        cmd.Parameters.AddWithValue("@BranchID", branchID);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            int newUserID = GetLastInsertedUserID(conn);
                            if (newUserID > 0)
                            {
                                LogUserAction(
                                    SessionDetails.CurrentUserID,
                                    "CREATE",
                                    "Users",
                                    newUserID,
                                    null,
                                    $"Created new user: {username} ({role})"
                                );
                            }

                            message = "Employee registered successfully!";
                            return true;
                        }
                        else
                        {
                            message = "Failed to register employee.";
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                message = $"Registration error: {ex.Message}";
                return false;
            }
        }

        public static void UpdateLastLogin(int userID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "UPDATE Users SET LastLogin = GETDATE() WHERE UserID = @UserID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch
            {

            }
        }


    }


    /// //////////////////////////////////////TEmp Model Class//////////////////////

    public class BranchInfo
    {
        public int BranchID { get; set; }
        public string BranchName { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }

        public override string ToString()
        {
            return $"{BranchName} - {Location}";
        }
    }

    public class AuthResult
    {
        public bool IsAuthenticated { get; set; }
        public int UserID { get; set; }
        public string Role { get; set; }
        public string FullName { get; set; }
        public int BranchID { get; set; }
        public string BranchName { get; set; }
    }


    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string ProductImagePath { get; set; }
        public decimal TaxRate { get; set; }
        public bool IsActive { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int VariantCount { get; set; }
        public List<Variant> Variants { get; set; }
    }

    public class Variant
    {
        public int VariantID { get; set; }
        public string VariantName { get; set; }
        public string UOM { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SalesPrice { get; set; }
        public string SKU { get; set; }
        public string VariantImagePath { get; set; }
        public int ProductID { get; set; }
        public int TotalStock { get; set; }
    }

    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }

    public class AuditLog
    {
        public int LogID { get; set; }
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Action { get; set; }
        public string TableName { get; set; }
        public int? RecordID { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public DateTime LogDate { get; set; }
    }
}