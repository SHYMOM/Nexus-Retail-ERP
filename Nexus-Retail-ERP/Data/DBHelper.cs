using System;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace Nexus_Retail_ERP.Data
{
    public static class DBHelper
    {
        private static readonly string? connString = ConfigurationManager.ConnectionStrings["NexusDB"]?.ConnectionString;
        public static SqlConnection? GetConnection()
        {
            if (string.IsNullOrEmpty(connString))
            {
                MessageBox.Show("Connection String 'NexusDB' not found in App.config!", "Config Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            return new SqlConnection(connString);
        }
        public static bool ExecuteQuery(string query, SqlParameter[]? parameters = null)
        {
            using (SqlConnection? con = GetConnection())
            {
                if (con == null) return false;

                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Action Failed:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
        public static DataTable? ExecuteDataQuery(string query, SqlParameter[]? parameters = null)
        {
            using (SqlConnection? con = GetConnection())
            {
                if (con == null) return null;

                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            return dt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data Load Failed:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
        }
    }
}