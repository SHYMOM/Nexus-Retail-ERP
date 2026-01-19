using Nexus_Retail_ERP.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Nexus_Retail_ERP.Dialogs
{
    public class SettingsDialog : Form
    {
        public int SelectedBranchID { get; private set; } = -1;
        public bool RequestExit { get; private set; } = false;

        private ComboBox cmbBranches;

        public SettingsDialog(int currentBranchID)
        {
            this.Text = "Kiosk Configuration";
            this.Size = new Size(400, 300);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;

            Label lblTitle = new Label
            {
                Text = "Kiosk Settings",
                Location = new Point(20, 20),
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                AutoSize = true
            };

            Label lblBranch = new Label { Text = "Select Current Branch:", Location = new Point(20, 70), AutoSize = true };

            cmbBranches = new ComboBox { Location = new Point(20, 95), Width = 340, DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 11) };
            LoadBranches(currentBranchID);

            Button btnSave = new Button { Text = "SAVE & CONTINUE", Location = new Point(20, 160), Width = 340, Height = 40, BackColor = Color.SeaGreen, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10, FontStyle.Bold) };

            Button btnExitApp = new Button { Text = "CLOSE APPLICATION", Location = new Point(20, 210), Width = 340, Height = 40, BackColor = Color.IndianRed, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10, FontStyle.Bold) };

            // Logic
            btnSave.Click += (s, e) =>
            {
                if (cmbBranches.SelectedValue != null)
                {
                    SelectedBranchID = Convert.ToInt32(cmbBranches.SelectedValue);
                    this.Close();
                }
            };

            btnExitApp.Click += (s, e) =>
            {
                if (MessageBox.Show("Are you sure you want to shut down the Kiosk?", "Confirm Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    RequestExit = true;
                    this.Close();
                }
            };

            this.Controls.AddRange(new Control[] { lblTitle, lblBranch, cmbBranches, btnSave, btnExitApp });
        }

        private void LoadBranches(int currentID)
        {
            try
            {
                DataTable dt = DatabaseHelper.GetBranches();
                cmbBranches.DataSource = dt;
                cmbBranches.DisplayMember = "BranchName";
                cmbBranches.ValueMember = "BranchID";
                cmbBranches.SelectedValue = currentID;
            }
            catch { }
        }
    }
}
