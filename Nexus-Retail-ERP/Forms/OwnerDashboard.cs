using Nexus_Retail_ERP.Data;
using Nexus_Retail_ERP.Forms;
using Nexus_Retail_ERP.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Nexus_Retail_ERP.Forms
{
    public partial class OwnerDashboard : Form
    {
        private int fadeInAlpha = 0;
        private int currentTickerIndex = 0;
        private List<string> securityLogs;

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        public OwnerDashboard()
        {
            InitializeComponent();

            if (false) // SessionDetails.CurrentUserRole != "Owner"
            {
                MessageBox.Show("Access Denied! Only Owner can access this dashboard.",
                    "Security Restriction", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            this.Opacity = 0;
            securityLogs = new List<string>();

            pnlTitleBar.MouseDown += PnlTitleBar_MouseDown;
            pnlTitleBar.MouseMove += PnlTitleBar_MouseMove;
            pnlTitleBar.MouseUp += PnlTitleBar_MouseUp;
            lblTitle.MouseDown += PnlTitleBar_MouseDown;
            lblTitle.MouseMove += PnlTitleBar_MouseMove;
            lblTitle.MouseUp += PnlTitleBar_MouseUp;
        }

        private void OwnerDashboard_Load(object sender, EventArgs e)
        {
            ConfigureDataGrids();
            timerFadeIn.Start();
            timerFooterTicker.Start();
            LoadDashboardData();
        }

        private void ConfigureDataGrids()
        {
            dgvTransactions.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 166, 178);
            dgvTransactions.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvTransactions.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvTransactions.ColumnHeadersHeight = 35;
            dgvTransactions.EnableHeadersVisualStyles = false;
            dgvTransactions.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvTransactions.DefaultCellStyle.ForeColor = Color.FromArgb(50, 50, 50);
            dgvTransactions.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 240, 240);
            dgvTransactions.DefaultCellStyle.SelectionForeColor = Color.FromArgb(50, 50, 50);
            dgvTransactions.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250);
            dgvTransactions.RowTemplate.Height = 30;
            dgvTransactions.BorderStyle = BorderStyle.None;
            dgvTransactions.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvTransactions.GridColor = Color.FromArgb(230, 230, 230);

            dgvTransactions.Columns.Clear();
            dgvTransactions.Columns.Add("Time", "Time");
            dgvTransactions.Columns.Add("Branch", "Branch");
            dgvTransactions.Columns.Add("Cashier", "Cashier");
            dgvTransactions.Columns.Add("Amount", "Total Amount");
            dgvTransactions.Columns.Add("Status", "Status");

            dgvTransactions.Columns["Time"].Width = 120;
            dgvTransactions.Columns["Branch"].Width = 150;
            dgvTransactions.Columns["Cashier"].Width = 150;
            dgvTransactions.Columns["Amount"].Width = 130;
            dgvTransactions.Columns["Status"].Width = 100;

            dgvTransactions.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvTransactions.Columns["Amount"].DefaultCellStyle.Format = "C2";
        }

        private void TimerFadeIn_Tick(object sender, EventArgs e)
        {
            fadeInAlpha += 25;
            if (fadeInAlpha >= 255)
            {
                fadeInAlpha = 255;
                timerFadeIn.Stop();
            }
            this.Opacity = fadeInAlpha / 255.0;
        }

        private void TimerFooterTicker_Tick(object sender, EventArgs e)
        {
            if (securityLogs != null && securityLogs.Count > 0)
            {
                currentTickerIndex = (currentTickerIndex + 1) % securityLogs.Count;
                lblFooterTicker.Text = securityLogs[currentTickerIndex];
            }
        }

        private void LoadDashboardData()
        {
            try
            {
                decimal todayRevenue = OwnerDashboardHelper.GetTodayRevenue();
                lblTotalRevenue.Text = $"${todayRevenue:N2}";

                string bestBranch = OwnerDashboardHelper.GetBestBranchToday();
                lblBestBranch.Text = !string.IsNullOrEmpty(bestBranch) ? bestBranch : "N/A";

                decimal todayLoss = OwnerDashboardHelper.GetTodayDamageLoss();
                lblLossAnalysis.Text = $"${todayLoss:N2}";

                List<dynamic> transactions = OwnerDashboardHelper.GetGlobalTransactions(30);
                dgvTransactions.Rows.Clear();
                if (transactions != null)
                {
                    foreach (var txn in transactions)
                    {
                        int rowIndex = dgvTransactions.Rows.Add(
                            txn.Time.ToString("HH:mm"),
                            txn.Branch,
                            txn.Cashier,
                            txn.Amount,
                            txn.Status
                        );

                        if (txn.Status == "Refunded")
                        {
                            dgvTransactions.Rows[rowIndex].Cells["Status"].Style.ForeColor = Color.FromArgb(255, 152, 0);
                        }
                        else if (txn.Status == "Completed")
                        {
                            dgvTransactions.Rows[rowIndex].Cells["Status"].Style.ForeColor = Color.FromArgb(76, 175, 80);
                        }
                    }
                }

                LoadStatistics();

                securityLogs = OwnerDashboardHelper.GetSecurityAuditLogs(10);
                if (securityLogs == null || securityLogs.Count == 0)
                {
                    securityLogs = new List<string>
                    {
                        "System initialized. Ready for monitoring.",
                        $"Owner logged in at {DateTime.Now:hh:mm tt}",
                        "All systems operational"
                    };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load dashboard data: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadStatistics()
        {
            try
            {
                int totalTransactions = OwnerDashboardHelper.GetTotalTransactionsToday();
                int totalBranches = OwnerDashboardHelper.GetTotalBranches();
                int activeStaff = OwnerDashboardHelper.GetActiveStaffCount();
                int pendingApprovals = OwnerDashboardHelper.GetPendingApprovalsCount();

                lblStat0.Text = totalTransactions.ToString("N0");
                lblStat1.Text = totalBranches.ToString("N0");
                lblStat2.Text = activeStaff.ToString("N0");
                lblStat3.Text = pendingApprovals.ToString("N0");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Failed to load statistics: {ex.Message}");
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnProductMaster_Click(object sender, EventArgs e)
        {
            Form mainForm = new ProductMaster();
            this.Hide();
            mainForm.FormClosed += (s, args) => this.Close();
            mainForm.Show();
        }

        private void BtnPriceDiscounts_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Price & Discounts page will open here.", "Feature Coming Soon");
        }

        private void BtnEmployeeManager_Click(object sender, EventArgs e)
        {
            Form mainForm = new EmployeeRegistrationPage();
            this.Hide();
            mainForm.FormClosed += (s, args) => this.Close();
            mainForm.Show();
        }

        private void BtnBranchManager_Click(object sender, EventArgs e)
        {
            Form mainForm = new BranchManagementForm();
            this.Hide();
            mainForm.FormClosed += (s, args) => this.Close();
            mainForm.Show();
        }

        private void BtnCategoryManager_Click(object sender, EventArgs e)
        {
            Form mainForm = new CategoryManagementForm();
            this.Hide();
            mainForm.FormClosed += (s, args) => this.Close();
            mainForm.Show();
        }

        private void BtnStockManager_Click(object sender, EventArgs e)
        {
            Form mainForm = new InventoryManagementForm();
            this.Hide();
            mainForm.FormClosed += (s, args) => this.Close();
            mainForm.Show();
        }

        private void BtnViewReports_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Reports page will open here.", "Feature Coming Soon");
        }

        private void BtnApprovalCenter_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Approval Center page will open here.", "Feature Coming Soon");
        }

        private void PnlTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void PnlTitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void PnlTitleBar_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void BtnClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.FromArgb(232, 17, 35);
            btnClose.ForeColor = Color.White;
        }

        private void BtnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.Transparent;
            btnClose.ForeColor = Color.FromArgb(200, 200, 200);
        }

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(30, 150, 162);
            }
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(45, 166, 178);
            }
        }

        private void Card_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Panel card)
            {
                card.BackColor = Color.FromArgb(255, 255, 255);
            }
        }

        private void Card_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Panel card)
            {
                card.BackColor = Color.FromArgb(245, 245, 245);
            }
        }

        private void pnlTopSection_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}