using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Nexus_Retail_ERP.Data;
using Nexus_Retail_ERP.Models;

namespace Nexus_Retail_ERP.Forms
{
    public partial class OwnerApprovalPage : Form
    {
        // =========================================================
        // UI Colors
        // =========================================================
        private readonly Color clrBackground = Color.FromArgb(38, 42, 50);
        private readonly Color clrCard = Color.FromArgb(255, 255, 255);
        private readonly Color clrAccent = Color.FromArgb(0, 180, 216);
        private readonly Color clrGreen = Color.FromArgb(34, 197, 94);
        private readonly Color clrRed = Color.FromArgb(239, 68, 68);

        private int _selectedRequestID = 0;
        private string _selectedType = "";

        public OwnerApprovalPage()
        {
            InitializeComponent();
            ApplyStyling();
            SetupEventHandlers();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            RefreshGrid("Pending");
        }

        // =========================================================
        // DATA
        // =========================================================
        private void RefreshGrid(string statusFilter)
        {
            try
            {
                DataTable dt = DatabaseHelper.GetStockRequests(statusFilter);
                dgvRequests.DataSource = dt;

                string[] hidden = { "RequestID", "FromBranchID", "ToBranchID", "VariantID" };
                foreach (string col in hidden)
                {
                    if (dgvRequests.Columns.Contains(col))
                        dgvRequests.Columns[col].Visible = false;
                }

                lblStatus.Text = statusFilter == "Pending" ? "Waiting for Action" : "History Archive";
                btnApprove.Enabled = statusFilter == "Pending";
                btnReject.Enabled = statusFilter == "Pending";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void ProcessRequest(bool isApproved)
        {
            if (_selectedRequestID == 0)
            {
                MessageBox.Show("Please select a request from the list.");
                return;
            }

            string action = isApproved ? "Approve" : "Reject";
            var result = MessageBox.Show($"Are you sure you want to {action} this request?", "Confirm Action", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                bool success = DatabaseHelper.ProcessStockRequest(_selectedRequestID, isApproved);

                if (success)
                {
                    MessageBox.Show($"Request {action}d successfully.");
                    RefreshGrid("Pending");
                    _selectedRequestID = 0;
                    lblSelectedInfo.Text = "Select a request...";
                }
                else
                {
                    MessageBox.Show("Operation failed. Check inventory levels (for Transfers) or database connection.");
                }
            }
        }

        // =========================================================
        // HELPER
        // =========================================================
        private int GetSafeInt(object value)
        {
            if (value == null || value == DBNull.Value) return 0;
            if (int.TryParse(value.ToString(), out int result)) return result;
            return 0;
        }

        // =========================================================
        // EVENTS
        // =========================================================
        private void SetupEventHandlers()
        {
            btnClose.Click += (s, e) =>
            {
                Form mainForm = new OwnerDashboard();
                this.Hide();
                mainForm.FormClosed += (s, args) => this.Close();
                mainForm.Show();
            };

            btnTabPending.Click += (s, e) =>
            {
                StyleTab(btnTabPending, true);
                StyleTab(btnTabHistory, false);
                RefreshGrid("Pending");
            };

            btnTabHistory.Click += (s, e) =>
            {
                StyleTab(btnTabPending, false);
                StyleTab(btnTabHistory, true);
                RefreshGrid("Completed");
            };

            dgvRequests.CellClick += (s, e) =>
            {
                if (e.RowIndex >= 0 && e.RowIndex < dgvRequests.RowCount)
                {
                    var row = dgvRequests.Rows[e.RowIndex];

                    _selectedRequestID = GetSafeInt(row.Cells["RequestID"].Value);

                    _selectedType = row.Cells["RequestType"].Value?.ToString() ?? "Unknown";
                    string item = row.Cells["FullProductName"].Value?.ToString() ?? "Unknown Item";
                    string qty = row.Cells["Quantity"].Value?.ToString() ?? "0";
                    string type = _selectedType.ToUpper();

                    lblSelectedInfo.Text = $"{type} REQUEST\n{item}\nQty: {qty}";
                }
            };

            btnApprove.Click += (s, e) => ProcessRequest(true);
            btnReject.Click += (s, e) => ProcessRequest(false);

            // Dragging
            this.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage(Handle, 0xA1, 0x2, 0);
                }
            };
        }

        // =========================================================
        // STYLING
        // =========================================================
        private void ApplyStyling()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(1100, 650);
            this.BackColor = clrBackground;

            dgvRequests.BackgroundColor = Color.WhiteSmoke;
            dgvRequests.BorderStyle = BorderStyle.None;
            dgvRequests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRequests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRequests.ReadOnly = true;
            dgvRequests.RowHeadersVisible = false;

            StyleTab(btnTabPending, true);
            StyleTab(btnTabHistory, false);
        }

        private void StyleTab(Button btn, bool isActive)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            if (isActive)
            {
                btn.BackColor = clrAccent;
                btn.ForeColor = Color.White;
            }
            else
            {
                btn.BackColor = Color.FromArgb(50, 55, 65);
                btn.ForeColor = Color.Gray;
            }
        }

        [DllImport("user32.dll")] public static extern bool ReleaseCapture();
        [DllImport("user32.dll")] public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void btnApprove_Click(object sender, EventArgs e)
        {

        }
    }
}