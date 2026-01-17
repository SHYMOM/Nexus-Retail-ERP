using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Nexus_Retail_ERP.Data
{
    internal class ProductMasterHelper
    {
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["NexusDB"]?.ConnectionString;

        ///////////////////////////////////////////////////////////////////////ProductMaster////////////////////////////////////////////////////////
        // =============================================
        // PRODUCT MANAGEMENT FUNCTIONS
        // =============================================

        public static List<Category> GetAllCategories()
        {
            var categories = new List<Category>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    CategoryID,
                    CategoryName
                FROM Categories 
                ORDER BY CategoryName";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                categories.Add(new Category
                                {
                                    CategoryID = Convert.ToInt32(reader["CategoryID"]),
                                    CategoryName = reader["CategoryName"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to load categories: {ex.Message}", ex);
            }

            return categories;
        }

        public static List<Product> GetAllProducts()
        {
            var products = new List<Product>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    p.ProductID,
                    p.ProductName,
                    p.Description,
                    p.ProductImagePath,
                    p.TaxRate,
                    p.IsActive,
                    p.CategoryID,
                    c.CategoryName,
                    (SELECT COUNT(*) FROM Variants v WHERE v.ProductID = p.ProductID) as VariantCount
                FROM Products p
                LEFT JOIN Categories c ON p.CategoryID = c.CategoryID
                ORDER BY p.ProductName";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                products.Add(new Product
                                {
                                    ProductID = Convert.ToInt32(reader["ProductID"]),
                                    ProductName = reader["ProductName"].ToString(),
                                    Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : "",
                                    ProductImagePath = reader["ProductImagePath"] != DBNull.Value ? reader["ProductImagePath"].ToString() : "",
                                    TaxRate = Convert.ToDecimal(reader["TaxRate"]),
                                    IsActive = Convert.ToBoolean(reader["IsActive"]),
                                    CategoryID = Convert.ToInt32(reader["CategoryID"]),
                                    CategoryName = reader["CategoryName"].ToString(),
                                    VariantCount = Convert.ToInt32(reader["VariantCount"]),
                                    Variants = new List<Variant>()
                                });
                            }
                        }
                    }

                    foreach (var product in products)
                    {
                        product.Variants = GetVariantsByProductId(product.ProductID, conn);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to load products: {ex.Message}", ex);
            }

            return products;
        }

        public static Product GetProductById(int productId)
        {
            Product product = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    p.ProductID,
                    p.ProductName,
                    p.Description,
                    p.ProductImagePath,
                    p.TaxRate,
                    p.IsActive,
                    p.CategoryID,
                    c.CategoryName
                FROM Products p
                LEFT JOIN Categories c ON p.CategoryID = c.CategoryID
                WHERE p.ProductID = @ProductID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProductID", productId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                product = new Product
                                {
                                    ProductID = Convert.ToInt32(reader["ProductID"]),
                                    ProductName = reader["ProductName"].ToString(),
                                    Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : "",
                                    ProductImagePath = reader["ProductImagePath"] != DBNull.Value ? reader["ProductImagePath"].ToString() : "",
                                    TaxRate = Convert.ToDecimal(reader["TaxRate"]),
                                    IsActive = Convert.ToBoolean(reader["IsActive"]),
                                    CategoryID = Convert.ToInt32(reader["CategoryID"]),
                                    CategoryName = reader["CategoryName"].ToString(),
                                    Variants = GetVariantsByProductId(productId, conn)
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to load product: {ex.Message}", ex);
            }

            return product;
        }

        public static int AddProduct(Product product, int userId)
        {
            int newProductId = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                INSERT INTO Products (
                    ProductName,
                    Description,
                    ProductImagePath,
                    TaxRate,
                    IsActive,
                    CategoryID
                ) VALUES (
                    @ProductName,
                    @Description,
                    @ProductImagePath,
                    @TaxRate,
                    @IsActive,
                    @CategoryID
                );
                SELECT SCOPE_IDENTITY();";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                        cmd.Parameters.AddWithValue("@Description", product.Description ?? "");
                        cmd.Parameters.AddWithValue("@ProductImagePath", product.ProductImagePath ?? "");
                        cmd.Parameters.AddWithValue("@TaxRate", product.TaxRate);
                        cmd.Parameters.AddWithValue("@IsActive", product.IsActive);
                        cmd.Parameters.AddWithValue("@CategoryID", product.CategoryID);

                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            newProductId = Convert.ToInt32(result);

                            // Log action
                            LogAudit(userId, "CREATE", "Products", newProductId,
                                null, $"Created product: {product.ProductName}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to add product: {ex.Message}", ex);
            }

            return newProductId;
        }

        public static bool UpdateProduct(Product product, int userId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    string oldValues = GetProductOldValues(product.ProductID, conn);

                    string query = @"
                UPDATE Products 
                SET 
                    ProductName = @ProductName,
                    Description = @Description,
                    ProductImagePath = @ProductImagePath,
                    TaxRate = @TaxRate,
                    IsActive = @IsActive,
                    CategoryID = @CategoryID
                WHERE ProductID = @ProductID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProductID", product.ProductID);
                        cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                        cmd.Parameters.AddWithValue("@Description", product.Description ?? "");
                        cmd.Parameters.AddWithValue("@ProductImagePath", product.ProductImagePath ?? "");
                        cmd.Parameters.AddWithValue("@TaxRate", product.TaxRate);
                        cmd.Parameters.AddWithValue("@IsActive", product.IsActive);
                        cmd.Parameters.AddWithValue("@CategoryID", product.CategoryID);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Log the action
                            LogAudit(userId, "UPDATE", "Products", product.ProductID,
                                oldValues, $"Updated product: {product.ProductName}");
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update product: {ex.Message}", ex);
            }

            return false;
        }

        public static bool DeleteProduct(int productId, int userId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    string productName = GetProductName(productId, conn);

                    DeleteVariantsByProductId(productId, conn);

                    string query = "DELETE FROM Products WHERE ProductID = @ProductID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProductID", productId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Log the action
                            LogAudit(userId, "DELETE", "Products", productId,
                                productName, "Product deleted");
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete product: {ex.Message}", ex);
            }

            return false;
        }

        public static List<Product> SearchProducts(string searchText)
        {
            var products = new List<Product>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    p.ProductID,
                    p.ProductName,
                    p.Description,
                    p.ProductImagePath,
                    p.TaxRate,
                    p.IsActive,
                    p.CategoryID,
                    c.CategoryName
                FROM Products p
                LEFT JOIN Categories c ON p.CategoryID = c.CategoryID
                WHERE p.ProductName LIKE @SearchText 
                   OR p.Description LIKE @SearchText 
                   OR c.CategoryName LIKE @SearchText
                ORDER BY p.ProductName";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SearchText", $"%{searchText}%");

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                products.Add(new Product
                                {
                                    ProductID = Convert.ToInt32(reader["ProductID"]),
                                    ProductName = reader["ProductName"].ToString(),
                                    Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : "",
                                    ProductImagePath = reader["ProductImagePath"] != DBNull.Value ? reader["ProductImagePath"].ToString() : "",
                                    TaxRate = Convert.ToDecimal(reader["TaxRate"]),
                                    IsActive = Convert.ToBoolean(reader["IsActive"]),
                                    CategoryID = Convert.ToInt32(reader["CategoryID"]),
                                    CategoryName = reader["CategoryName"].ToString(),
                                    Variants = new List<Variant>()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to search products: {ex.Message}", ex);
            }

            return products;
        }

        // =============================================
        // VARIANT MANAGEMENT FUNCTIONS
        // =============================================

        public static List<Variant> GetVariantsByProductId(int productId, SqlConnection existingConn = null)
        {
            var variants = new List<Variant>();
            SqlConnection conn = existingConn;

            try
            {
                bool closeConn = false;
                if (conn == null)
                {
                    conn = new SqlConnection(ConnectionString);
                    conn.Open();
                    closeConn = true;
                }

                string query = @"
            SELECT 
                v.VariantID,
                v.VariantName,
                v.UOM,
                v.CostPrice,
                v.SalesPrice,
                v.SKU,
                v.VariantImagePath,
                v.ProductID
            FROM Variants v
            LEFT JOIN Inventory i ON v.VariantID = i.VariantID
            WHERE v.ProductID = @ProductID
            GROUP BY 
                v.VariantID,
                v.VariantName,
                v.UOM,
                v.CostPrice,
                v.SalesPrice,
                v.SKU,
                v.VariantImagePath,
                v.ProductID
            ORDER BY v.VariantName";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProductID", productId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            variants.Add(new Variant
                            {
                                VariantID = Convert.ToInt32(reader["VariantID"]),
                                VariantName = reader["VariantName"].ToString(),
                                UOM = reader["UOM"] != DBNull.Value ? reader["UOM"].ToString() : "",
                                CostPrice = Convert.ToDecimal(reader["CostPrice"]),
                                SalesPrice = Convert.ToDecimal(reader["SalesPrice"]),
                                SKU = reader["SKU"] != DBNull.Value ? reader["SKU"].ToString() : "",
                                VariantImagePath = reader["VariantImagePath"] != DBNull.Value ? reader["VariantImagePath"].ToString() : "",
                                ProductID = Convert.ToInt32(reader["ProductID"])
                            });
                        }
                    }
                }

                if (closeConn)
                {
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to load variants: {ex.Message}", ex);
            }

            return variants;
        }

        public static Variant GetVariantById(int variantId)
        {
            Variant variant = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    v.VariantID,
                    v.VariantName,
                    v.UOM,
                    v.CostPrice,
                    v.SalesPrice,
                    v.SKU,
                    v.VariantImagePath,
                    v.ProductID,
                    ISNULL(SUM(i.Quantity), 0) as TotalStock
                FROM Variants v
                LEFT JOIN Inventory i ON v.VariantID = i.VariantID
                WHERE v.VariantID = @VariantID
                GROUP BY 
                    v.VariantID,
                    v.VariantName,
                    v.UOM,
                    v.CostPrice,
                    v.SalesPrice,
                    v.SKU,
                    v.VariantImagePath,
                    v.ProductID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@VariantID", variantId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                variant = new Variant
                                {
                                    VariantID = Convert.ToInt32(reader["VariantID"]),
                                    VariantName = reader["VariantName"].ToString(),
                                    UOM = reader["UOM"] != DBNull.Value ? reader["UOM"].ToString() : "",
                                    CostPrice = Convert.ToDecimal(reader["CostPrice"]),
                                    SalesPrice = Convert.ToDecimal(reader["SalesPrice"]),
                                    SKU = reader["SKU"] != DBNull.Value ? reader["SKU"].ToString() : "",
                                    VariantImagePath = reader["VariantImagePath"] != DBNull.Value ? reader["VariantImagePath"].ToString() : "",
                                    ProductID = Convert.ToInt32(reader["ProductID"]),
                                    TotalStock = Convert.ToInt32(reader["TotalStock"])
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to load variant: {ex.Message}", ex);
            }

            return variant;
        }

        public static int AddVariant(Variant variant, int userId)
        {
            int newVariantId = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    if (!IsSkuAvailable(variant.SKU, conn))
                    {
                        throw new Exception($"SKU '{variant.SKU}' is already in use. Please use a unique SKU.");
                    }

                    string query = @"
                INSERT INTO Variants (
                    VariantName,
                    UOM,
                    CostPrice,
                    SalesPrice,
                    SKU,
                    VariantImagePath,
                    ProductID
                ) VALUES (
                    @VariantName,
                    @UOM,
                    @CostPrice,
                    @SalesPrice,
                    @SKU,
                    @VariantImagePath,
                    @ProductID
                );
                SELECT SCOPE_IDENTITY();";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@VariantName", variant.VariantName);
                        cmd.Parameters.AddWithValue("@UOM", variant.UOM ?? "");
                        cmd.Parameters.AddWithValue("@CostPrice", variant.CostPrice);
                        cmd.Parameters.AddWithValue("@SalesPrice", variant.SalesPrice);
                        cmd.Parameters.AddWithValue("@SKU", variant.SKU ?? "");
                        cmd.Parameters.AddWithValue("@VariantImagePath", variant.VariantImagePath ?? "");
                        cmd.Parameters.AddWithValue("@ProductID", variant.ProductID);

                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            newVariantId = Convert.ToInt32(result);

                            // Log the action
                            LogAudit(userId, "CREATE", "Variants", newVariantId,
                                null, $"Created variant: {variant.VariantName} for ProductID: {variant.ProductID}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to add variant: {ex.Message}", ex);
            }

            return newVariantId;
        }

        public static bool UpdateVariant(Variant variant, int userId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    string oldValues = GetVariantOldValues(variant.VariantID, conn);

                    if (!IsSkuAvailable(variant.SKU, variant.VariantID, conn))
                    {
                        throw new Exception($"SKU '{variant.SKU}' is already in use. Please use a unique SKU.");
                    }

                    string query = @"
                UPDATE Variants 
                SET 
                    VariantName = @VariantName,
                    UOM = @UOM,
                    CostPrice = @CostPrice,
                    SalesPrice = @SalesPrice,
                    SKU = @SKU,
                    VariantImagePath = @VariantImagePath
                WHERE VariantID = @VariantID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@VariantID", variant.VariantID);
                        cmd.Parameters.AddWithValue("@VariantName", variant.VariantName);
                        cmd.Parameters.AddWithValue("@UOM", variant.UOM ?? "");
                        cmd.Parameters.AddWithValue("@CostPrice", variant.CostPrice);
                        cmd.Parameters.AddWithValue("@SalesPrice", variant.SalesPrice);
                        cmd.Parameters.AddWithValue("@SKU", variant.SKU ?? "");
                        cmd.Parameters.AddWithValue("@VariantImagePath", variant.VariantImagePath ?? "");

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Log the action
                            LogAudit(userId, "UPDATE", "Variants", variant.VariantID,
                                oldValues, $"Updated variant: {variant.VariantName}");
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update variant: {ex.Message}", ex);
            }

            return false;
        }

        public static bool DeleteVariant(int variantId, int userId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    string variantName = GetVariantName(variantId, conn);

                    string query = "DELETE FROM Variants WHERE VariantID = @VariantID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@VariantID", variantId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            DeleteInventoryByVariantId(variantId, conn);

                            LogAudit(userId, "DELETE", "Variants", variantId,
                                variantName, "Variant deleted");
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete variant: {ex.Message}", ex);
            }

            return false;
        }

        public static bool IsSkuAvailable(string sku, int excludeVariantId = 0)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    return IsSkuAvailable(sku, excludeVariantId, conn);
                }
            }
            catch
            {
                return false;
            }
        }

        private static bool IsSkuAvailable(string sku, SqlConnection conn)
        {
            string query = "SELECT COUNT(*) FROM Variants WHERE SKU = @SKU";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@SKU", sku);
                int count = (int)cmd.ExecuteScalar();
                return count == 0;
            }
        }


        private static bool IsSkuAvailable(string sku, int excludeVariantId, SqlConnection conn)
        {
            string query = "SELECT COUNT(*) FROM Variants WHERE SKU = @SKU AND VariantID != @ExcludeVariantId";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@SKU", sku);
                cmd.Parameters.AddWithValue("@ExcludeVariantId", excludeVariantId);
                int count = (int)cmd.ExecuteScalar();
                return count == 0;
            }
        }

        public static int GetVariantStock(int variantId)
        {
            int stock = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                SELECT ISNULL(SUM(Quantity), 0) as TotalStock
                FROM Inventory
                WHERE VariantID = @VariantID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@VariantID", variantId);

                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            stock = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get variant stock: {ex.Message}", ex);
            }

            return stock;
        }


        // =============================================
        // HELPER FUNCTIONS
        // =============================================

        private static string GetProductOldValues(int productId, SqlConnection conn)
        {
            string query = @"
        SELECT 
            ProductName,
            Description,
            TaxRate,
            IsActive,
            CategoryID
        FROM Products 
        WHERE ProductID = @ProductID";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ProductID", productId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return $"Name: {reader["ProductName"]}, " +
                               $"Desc: {reader["Description"]}, " +
                               $"Tax: {reader["TaxRate"]}, " +
                               $"Active: {reader["IsActive"]}, " +
                               $"CategoryID: {reader["CategoryID"]}";
                    }
                }
            }

            return "";
        }

        private static string GetVariantOldValues(int variantId, SqlConnection conn)
        {
            string query = @"
        SELECT 
            VariantName,
            UOM,
            CostPrice,
            SalesPrice,
            SKU,
            ProductID
        FROM Variants 
        WHERE VariantID = @VariantID";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@VariantID", variantId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return $"Name: {reader["VariantName"]}, " +
                               $"UOM: {reader["UOM"]}, " +
                               $"Cost: {reader["CostPrice"]}, " +
                               $"Price: {reader["SalesPrice"]}, " +
                               $"SKU: {reader["SKU"]}, " +
                               $"ProductID: {reader["ProductID"]}";
                    }
                }
            }

            return "";
        }

        private static string GetProductName(int productId, SqlConnection conn)
        {
            string query = "SELECT ProductName FROM Products WHERE ProductID = @ProductID";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ProductID", productId);

                object result = cmd.ExecuteScalar();
                return result != null ? result.ToString() : "Unknown Product";
            }
        }

        private static string GetVariantName(int variantId, SqlConnection conn)
        {
            string query = "SELECT VariantName FROM Variants WHERE VariantID = @VariantID";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@VariantID", variantId);

                object result = cmd.ExecuteScalar();
                return result != null ? result.ToString() : "Unknown Variant";
            }
        }

        private static void DeleteVariantsByProductId(int productId, SqlConnection conn)
        {
            try
            {
                var variantIds = new List<int>();
                string getVariantsQuery = "SELECT VariantID FROM Variants WHERE ProductID = @ProductID";

                using (SqlCommand getCmd = new SqlCommand(getVariantsQuery, conn))
                {
                    getCmd.Parameters.AddWithValue("@ProductID", productId);

                    using (SqlDataReader reader = getCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            variantIds.Add(Convert.ToInt32(reader["VariantID"]));
                        }
                    }
                }

                foreach (int variantId in variantIds)
                {
                    DeleteInventoryByVariantId(variantId, conn);
                }

                string deleteQuery = "DELETE FROM Variants WHERE ProductID = @ProductID";

                using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn))
                {
                    deleteCmd.Parameters.AddWithValue("@ProductID", productId);
                    deleteCmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete variants: {ex.Message}", ex);
            }
        }

        private static void DeleteInventoryByVariantId(int variantId, SqlConnection conn)
        {
            string query = "DELETE FROM Inventory WHERE VariantID = @VariantID";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@VariantID", variantId);
                cmd.ExecuteNonQuery();
            }
        }

        // =============================================
        // AUDIT LOG FUNCTIONS
        // =============================================

        public static void LogAudit(int userId, string action, string tableName, int? recordId, string oldValue, string newValue)
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
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        cmd.Parameters.AddWithValue("@Action", action);
                        cmd.Parameters.AddWithValue("@TableName", tableName);

                        if (recordId.HasValue)
                            cmd.Parameters.AddWithValue("@RecordID", recordId.Value);
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
                System.Diagnostics.Debug.WriteLine($"Failed to log audit: {ex.Message}");
            }
        }

        public static List<AuditLog> GetAuditLogs(int limit = 100)
        {
            var logs = new List<AuditLog>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                SELECT TOP (@limit) 
                    al.LogID,
                    al.UserID,
                    u.Username,
                    al.Action,
                    al.TableName,
                    al.RecordID,
                    al.OldValue,
                    al.NewValue,
                    al.LogDate
                FROM AuditLogs al
                LEFT JOIN Users u ON al.UserID = u.UserID
                ORDER BY al.LogDate DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@limit", limit);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                logs.Add(new AuditLog
                                {
                                    LogID = Convert.ToInt32(reader["LogID"]),
                                    UserID = Convert.ToInt32(reader["UserID"]),
                                    Username = reader["Username"] != DBNull.Value ? reader["Username"].ToString() : "System",
                                    Action = reader["Action"].ToString(),
                                    TableName = reader["TableName"].ToString(),
                                    RecordID = reader["RecordID"] != DBNull.Value ? Convert.ToInt32(reader["RecordID"]) : (int?)null,
                                    OldValue = reader["OldValue"].ToString(),
                                    NewValue = reader["NewValue"].ToString(),
                                    LogDate = Convert.ToDateTime(reader["LogDate"])
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to load audit logs: {ex.Message}", ex);
            }

            return logs;
        }
    }
}
