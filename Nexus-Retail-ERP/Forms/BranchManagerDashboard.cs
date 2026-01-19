using Nexus_Retail_ERP.Data;
using Nexus_Retail_ERP.Dialogs;
using Nexus_Retail_ERP.Models;
using System;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Nexus_Retail_ERP.Forms
{
    public partial class BranchManagerDashboard : Form
    {
        private readonly Color clrSidebar = Color.FromArgb(32, 35, 45);
        private readonly Color clrActive = Color.FromArgb(45, 50, 60);

        private int _branchID;
        private Button _currentBtn;
        private Timer _timer;

        private DataGridView dgvData;
        private Label lblSalesVal, lblStockVal, lblReqVal;

        public BranchManagerDashboard()
        {
            InitializeComponent();
            ApplyStyling();

            _branchID = DatabaseHelper.GetBranchIDByUserID(SessionDetails.CurrentUserID);

            SetupEvents();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            lblBranchName.Text = $"Branch: {DatabaseHelper.GetBranchNameByID(_branchID)}";

            _timer = new Timer { Interval = 5000 };
            _timer.Tick += (s, args) => RefreshDashboardData();
            _timer.Start();

            RefreshDashboardData();
            NavigateTo(btnOverview, "Overview");
        }

        private void RefreshDashboardData()
        {
            try
            {
                decimal sales; int lowStock, pending;
                DatabaseHelper.GetBranchStats(_branchID, out sales, out lowStock, out pending);

                if (lblSalesVal != null && !lblSalesVal.IsDisposed)
                {
                    lblSalesVal.Text = $"৳ {sales:N0}";
                    lblStockVal.Text = $"{lowStock} Items";
                    lblReqVal.Text = $"{pending} Pending";
                }

                if (pending > 0)
                {
                    lblBadge.Text = pending.ToString();
                    lblBadge.Visible = true;
                    lblBadge.BringToFront();
                }
                else lblBadge.Visible = false;

                lblFooter.Text = $"NOTIFICATIONS: {lowStock} Low Stock Alerts | {pending} Requests needing approval.";
            }
            catch { }
        }

        // =========================================================
        //  NAVIGATION
        // =========================================================
        private void NavigateTo(Button btn, string page)
        {
            if (_currentBtn != null) _currentBtn.BackColor = clrSidebar;
            btn.BackColor = clrActive; _currentBtn = btn;

            lblPageTitle.Text = page.ToUpper();
            pnlContent.Controls.Clear();

            switch (page)
            {
                case "Overview": LoadOverview(); break;
                case "Inventory": LoadInventory(); break;
                case "Transfer": LoadTransferCenter(); break;
                case "Staff": LoadStaff(); break;
            }
        }

        private void LoadOverview()
        {
            CreateStatCard("Today's Revenue", "৳ 0", Color.SeaGreen, 0, out lblSalesVal);
            CreateStatCard("Low Stock Alerts", "0", Color.Orange, 260, out lblStockVal);
            CreateStatCard("Incoming Requests", "0", Color.SteelBlue, 520, out lblReqVal);

            Label lbl = new Label { Text = "Recent Branch Transactions (Last 30)", Font = new Font("Segoe UI", 12, FontStyle.Bold), Location = new Point(0, 140), AutoSize = true };
            dgvData = CreateGrid();
            dgvData.Location = new Point(0, 170); dgvData.Size = new Size(pnlContent.Width, pnlContent.Height - 180);

            dgvData.DataSource = DatabaseHelper.GetBranchTransactions(_branchID, 30);

            pnlContent.Controls.AddRange(new Control[] { lbl, dgvData });
            RefreshDashboardData();
        }

        private void LoadInventory()
        {
            Button btnHQ = new Button
            {
                Text = "REQUEST RESTOCK (HQ)",
                BackColor = Color.FromArgb(0, 180, 216),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(200, 40),
                Location = new Point(pnlContent.Width - 200, 0),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };

            dgvData = CreateGrid();
            dgvData.Location = new Point(0, 50); dgvData.Size = new Size(pnlContent.Width, pnlContent.Height - 50);
            dgvData.DataSource = DatabaseHelper.GetPOSProducts(_branchID, "");

            btnHQ.Click += (s, e) =>
            {
                if (dgvData.SelectedRows.Count > 0)
                {
                    var row = dgvData.SelectedRows[0];
                    int varID = Convert.ToInt32(row.Cells["VariantID"].Value);
                    string name = row.Cells["ProductName"].Value.ToString();
                    string varName = row.Cells["VariantName"].Value.ToString();
                    int stock = Convert.ToInt32(row.Cells["CurrentStock"].Value);

                    using (var d = new RestockDialog(name, varName, stock))
                    {
                        if (d.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                DatabaseHelper.SendTransferRequest(null, _branchID, varID, d.Quantity, SessionDetails.CurrentUserID);
                                MessageBox.Show("Restock Request Sent Successfully!");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Failed to send: " + ex.Message);
                            }
                        }
                    }
                }
                else MessageBox.Show("Select a product first.");
            };

            pnlContent.Controls.AddRange(new Control[] { btnHQ, dgvData });
        }

        private void LoadTransferCenter()
        {
            TabControl tabs = new TabControl { Dock = DockStyle.Fill, Font = new Font("Segoe UI", 10) };

            TabPage t1 = new TabPage("Incoming Requests (Action Required)");
            DataGridView g1 = CreateGrid();
            g1.Dock = DockStyle.Fill;
            g1.DataSource = DatabaseHelper.GetIncomingTransferRequests(_branchID);

            Panel pnlActs = new Panel { Dock = DockStyle.Bottom, Height = 50, BackColor = Color.WhiteSmoke };

            Button btnApprove = new Button
            {
                Text = "APPROVE",
                BackColor = Color.SeaGreen,
                ForeColor = Color.White,
                Width = 120,
                Dock = DockStyle.Left,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };

            Button btnReject = new Button
            {
                Text = "REJECT",
                BackColor = Color.IndianRed,
                ForeColor = Color.White,
                Width = 120,
                Dock = DockStyle.Left,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };

            btnApprove.Click += (s, e) => ProcessRequest(g1, true);
            btnReject.Click += (s, e) => ProcessRequest(g1, false);

            pnlActs.Controls.Add(btnReject); pnlActs.Controls.Add(btnApprove);
            t1.Controls.Add(g1); t1.Controls.Add(pnlActs);

            TabPage t2 = new TabPage("New Transfer Request");
            Label l = new Label { Text = "Select Item to Find Stock in Other Branches:", Dock = DockStyle.Top, Height = 30, Padding = new Padding(0, 5, 0, 0) };
            DataGridView g2 = CreateGrid();
            g2.Dock = DockStyle.Fill;
            g2.DataSource = DatabaseHelper.GetPOSProducts(_branchID, "");

            Panel pnlFind = new Panel { Dock = DockStyle.Bottom, Height = 50 };
            Button btnFind = new Button { Text = "FIND STOCK & REQUEST", BackColor = Color.FromArgb(0, 180, 216), ForeColor = Color.White, Dock = DockStyle.Fill, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 11, FontStyle.Bold) };

            btnFind.Click += (s, e) =>
            {
                if (g2.SelectedRows.Count > 0)
                {
                    int varID = Convert.ToInt32(g2.SelectedRows[0].Cells["VariantID"].Value);
                    string name = g2.SelectedRows[0].Cells["ProductName"].Value.ToString();

                    using (var d = new StockRequestDialog(varID, name, 10, _branchID))
                    {
                        if (d.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                DatabaseHelper.SendTransferRequest(d.SelectedBranchID, _branchID, varID, d.RequestedQty, SessionDetails.CurrentUserID);
                                MessageBox.Show("Transfer Request Sent Successfully!");
                                LoadTransferCenter();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Failed to send: " + ex.Message);
                            }
                        }
                    }
                }
            };

            pnlFind.Controls.Add(btnFind);
            t2.Controls.Add(g2); t2.Controls.Add(l); t2.Controls.Add(pnlFind);

            TabPage t3 = new TabPage("Request History");
            DataGridView g3 = CreateGrid();
            g3.Dock = DockStyle.Fill;

            g3.DataSource = DatabaseHelper.GetAllTransferHistory(_branchID);

            g3.CellFormatting += (s, e) =>
            {
                if (g3.Columns[e.ColumnIndex].Name == "Status")
                {
                    string status = e.Value?.ToString();
                    if (status == "Approved") e.CellStyle.ForeColor = Color.SeaGreen;
                    else if (status == "Rejected") e.CellStyle.ForeColor = Color.IndianRed;
                    else if (status == "Pending") e.CellStyle.ForeColor = Color.Orange;
                }
            };

            t3.Controls.Add(g3);

            tabs.TabPages.AddRange(new TabPage[] { t1, t2, t3 });
            pnlContent.Controls.Add(tabs);
        }

        private void ProcessRequest(DataGridView g, bool approve)
        {
            if (g.SelectedRows.Count > 0)
            {
                int reqID = Convert.ToInt32(g.SelectedRows[0].Cells["RequestID"].Value);
                try
                {
                    string action = approve ? "Approve" : "Reject";
                    if (MessageBox.Show($"Are you sure you want to {action} this request?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        bool ok = DatabaseHelper.ProcessTransferRequest(reqID, approve, SessionDetails.CurrentUserID);

                        if (ok)
                        {
                            MessageBox.Show("Success!");
                            LoadTransferCenter();
                            RefreshDashboardData();
                        }
                        else
                        {
                            MessageBox.Show("Action Failed. Check database logs.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Action Failed: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a request row first.");
            }
        }

        private void LoadStaff()
        {
            DataGridView g = CreateGrid(); g.Dock = DockStyle.Fill;
            g.DataSource = DatabaseHelper.GetBranchStaff(_branchID);
            pnlContent.Controls.Add(g);
        }

        // =========================================================
        //  HELPERS
        // =========================================================
        private void CreateStatCard(string title, string val, Color c, int x, out Label valLabel)
        {
            Panel p = new Panel { Size = new Size(240, 120), Location = new Point(x, 0), BackColor = Color.White };
            Panel b = new Panel { Height = 5, Dock = DockStyle.Top, BackColor = c };
            Label l1 = new Label { Text = title, Location = new Point(10, 20), ForeColor = Color.Gray, AutoSize = true };
            valLabel = new Label { Text = val, Location = new Point(10, 50), Font = new Font("Segoe UI", 18, FontStyle.Bold), AutoSize = true };
            p.Controls.AddRange(new Control[] { b, l1, valLabel });
            pnlContent.Controls.Add(p);
        }

        private DataGridView CreateGrid()
        {
            var g = new DataGridView
            {
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
                Font = new Font("Segoe UI", 10)
            };

            g.CellFormatting += (s, e) =>
            {
                if (g.Columns[e.ColumnIndex].Name == "CurrentStock")
                {
                    if (e.Value != null && int.TryParse(e.Value.ToString(), out int stock))
                    {
                        if (stock == 0)
                        {
                            g.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 200, 200);
                            g.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 150, 150);
                        }
                        else if (stock < 10)
                        {
                            g.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 240, 200);
                            g.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 220, 150);
                        }
                    }
                }
            };
            return g;
        }

        private void SetupEvents()
        {
            btnClose.Click += (s, e) => this.Close();
            btnLogout.Click += (s, e) => this.Close();
            btnNotif.Click += (s, e) => NavigateTo(btnTransfer, "Transfer");

            btnOverview.Click += (s, e) => NavigateTo(btnOverview, "Overview");
            btnInventory.Click += (s, e) => NavigateTo(btnInventory, "Inventory");
            btnTransfer.Click += (s, e) => NavigateTo(btnTransfer, "Transfer");
            btnStaff.Click += (s, e) => NavigateTo(btnStaff, "Staff");

            pnlHeader.MouseDown += (s, e) => { if (e.Button == MouseButtons.Left) { ReleaseCapture(); SendMessage(Handle, 0xA1, 0x2, 0); } };
        }

        private void ApplyStyling()
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, 20, 20);
            lblBadge.Region = new Region(path);
        }

        [DllImport("user32.dll")] public static extern bool ReleaseCapture();
        [DllImport("user32.dll")] public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void lblLogo_Click(object sender, EventArgs e)
        {

        }
    }
}