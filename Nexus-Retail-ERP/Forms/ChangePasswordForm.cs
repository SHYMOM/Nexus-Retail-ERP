using Microsoft.Data.SqlClient;
using Nexus_Retail_ERP.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace Nexus_Retail_ERP.Forms
{
    public partial class ChangePasswordForm : Form
    {
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public ChangePasswordForm()
        {
            InitializeComponent();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string newPass = txtNewPass.Text;
            string confirmPass = txtConfirmPass.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(newPass))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPass != confirmPass)
            {
                MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DatabaseHelper.ResetPassword(username, newPass))
            {
                MessageBox.Show("Password Reset Successfully!\nYou can now login.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Username not found or database error.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
