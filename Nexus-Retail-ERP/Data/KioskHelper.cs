using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Configuration;

namespace Nexus_Retail_ERP.Data
{
    internal class KioskHelper
    {
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["NexusDB"]?.ConnectionString;

        public static DataTable GetCategories()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT CategoryID, CategoryName FROM Categories", conn);
                DataTable dt = new DataTable(); da.Fill(dt);

                DataRow row = dt.NewRow(); row["CategoryID"] = 0; row["CategoryName"] = "All Categories";
                dt.Rows.InsertAt(row, 0);
                return dt;
            }
        }

        public static DataTable GetKioskProducts(string searchText, int categoryID, string sortOrder, int branchID)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string orderBy = "p.ProductName ASC";

                switch (sortOrder)
                {
                    case "Price: Low to High": orderBy = "MinPrice ASC"; break;
                    case "Price: High to Low": orderBy = "MinPrice DESC"; break;
                    case "Name: Z to A": orderBy = "p.ProductName DESC"; break;
                    default: orderBy = "p.ProductName ASC"; break;
                }

                string query = $@"
            SELECT 
                p.ProductID,
                p.ProductName,
                p.ProductImagePath, 
                MIN(v.SalesPrice) as MinPrice,
                c.CategoryName
            FROM Products p
            JOIN Variants v ON p.ProductID = v.ProductID
            JOIN Categories c ON p.CategoryID = c.CategoryID
            JOIN Inventory i ON v.VariantID = i.VariantID
            WHERE p.IsActive = 1 
            AND i.BranchID = @BranchID
            AND (@CatID = 0 OR p.CategoryID = @CatID)
            AND (@Search = '' OR p.ProductName LIKE '%' + @Search + '%')
            GROUP BY p.ProductID, p.ProductName, p.ProductImagePath, c.CategoryName
            ORDER BY {orderBy}";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@BranchID", branchID); // Pass Branch ID
                    cmd.Parameters.AddWithValue("@CatID", categoryID);
                    cmd.Parameters.AddWithValue("@Search", searchText);
                    DataTable dt = new DataTable();
                    new SqlDataAdapter(cmd).Fill(dt);
                    return dt;
                }
            }
        }

        public static DataTable GetProductVariants(int productID, int branchID)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = @"
            SELECT 
                v.VariantID,
                v.VariantName,
                v.SalesPrice,
                v.VariantImagePath,
                v.UOM,
                p.Description,
                ISNULL(i.CurrentStock, 0) as Stock
            FROM Variants v
            JOIN Products p ON v.ProductID = p.ProductID
            LEFT JOIN Inventory i ON v.VariantID = i.VariantID AND i.BranchID = @BranchID
            WHERE v.ProductID = @ProdID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProdID", productID);
                    cmd.Parameters.AddWithValue("@BranchID", branchID);
                    DataTable dt = new DataTable();
                    new SqlDataAdapter(cmd).Fill(dt);
                    return dt;
                }
            }
        }
    }
}
