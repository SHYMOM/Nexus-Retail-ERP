using Nexus_Retail_ERP.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Nexus_Retail_ERP.Dialogs
{
    public class StockRequestDialog : Form
    {
        public int SelectedBranchID { get; private set; } = 0;
        public int RequestedQty { get; private set; } = 0;

        private DataGridView dgvBranches;
        private NumericUpDown numQty;

        public StockRequestDialog(int variantID, string itemName, int neededQty, int currentBranchID)
        {
            this.Text = "Request Stock Transfer";
            this.Size = new Size(500, 400);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;

            Label lblTitle = new Label
            {
                Text = "Source Stock For:",
                Location = new Point(20, 15),
                AutoSize = true,
                ForeColor = Color.Gray,
                Font = new Font("Segoe UI", 9)
            };
            Label lblItem = new Label { Text = itemName, Location = new Point(20, 35), AutoSize = true, Font = new Font("Segoe UI", 12, FontStyle.Bold) };

            dgvBranches = new DataGridView
            {
                Location = new Point(20, 70),
                Size = new Size(440, 180),
                BackgroundColor = Color.WhiteSmoke,
                BorderStyle = BorderStyle.None,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                ReadOnly = true,
                Font = new Font("Segoe UI", 10),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            DataTable dt = DatabaseHelper.GetStockAvailability(variantID, currentBranchID);
            dgvBranches.DataSource = dt;

            if (dgvBranches.Columns.Contains("BranchID"))
            {
                dgvBranches.Columns["BranchID"].Visible = false;
            }

            Label lblQty = new Label
            {
                Text = "Request Quantity:",
                Location = new Point(20, 270),
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            numQty = new NumericUpDown
            {
                Location = new Point(150, 268),
                Width = 100,
                Font = new Font("Segoe UI", 11),
                Minimum = 1,
                Maximum = 1000,
                Value = neededQty
            };

            Button btnRequest = new Button
            {
                Text = "SEND REQUEST",
                DialogResult = DialogResult.OK,
                Location = new Point(20, 310),
                Width = 440,
                Height = 40,
                BackColor = Color.FromArgb(0, 180, 216),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            this.Controls.AddRange(new Control[] { lblTitle, lblItem, dgvBranches, lblQty, numQty, btnRequest });

            //Request Button
            btnRequest.Click += (s, e) =>
            {
                if (dgvBranches.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a branch to request from.");
                    this.DialogResult = DialogResult.None;
                    return;
                }

                SelectedBranchID = Convert.ToInt32(dgvBranches.SelectedRows[0].Cells["BranchID"].Value);
                RequestedQty = (int)numQty.Value;
            };

            if (dt.Rows.Count == 0)
            {
                Label lblEmpty = new Label { Text = "No other branch has this item in stock.", ForeColor = Color.Red, AutoSize = true, Location = new Point(130, 150) };
                dgvBranches.Visible = false;
                this.Controls.Add(lblEmpty);
                btnRequest.Enabled = false;
                btnRequest.BackColor = Color.Gray;
            }
        }
    }
}
