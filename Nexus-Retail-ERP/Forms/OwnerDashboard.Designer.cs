namespace Nexus_Retail_ERP.Forms
{
    partial class OwnerDashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pnlTitleBar = new Panel();
            lblTitle = new Label();
            btnClose = new Button();
            pnlTopSection = new Panel();
            cardRevenue = new Panel();
            lblTotalRevenue = new Label();
            lblRevenueLabel = new Label();
            cardBranch = new Panel();
            lblBestBranch = new Label();
            lblBranchLabel = new Label();
            cardLoss = new Panel();
            lblLossAnalysis = new Label();
            lblLossLabel = new Label();
            pnlMainContent = new Panel();
            pnlCenterLeft = new Panel();
            dgvTransactions = new DataGridView();
            lblGridTitle = new Label();
            pnlCenterRight = new Panel();
            pnlStats = new Panel();
            lblStat3 = new Label();
            lblStat3Label = new Label();
            lblStat2 = new Label();
            lblStat2Label = new Label();
            lblStat1 = new Label();
            lblStat1Label = new Label();
            lblStat0 = new Label();
            lblStat0Label = new Label();
            lblStatsTitle = new Label();
            pnlActionSidebar = new Panel();
            btnApprovalCenter = new Button();
            btnStockManager = new Button();
            btnCategoryManager = new Button();
            btnBranchManager = new Button();
            btnViewReports = new Button();
            btnEmployeeManager = new Button();
            btnPriceDiscounts = new Button();
            btnProductMaster = new Button();
            pnlFooter = new Panel();
            lblFooterTicker = new Label();
            lblFooterTitle = new Label();
            timerFadeIn = new System.Windows.Forms.Timer(components);
            timerFooterTicker = new System.Windows.Forms.Timer(components);
            pnlTitleBar.SuspendLayout();
            pnlTopSection.SuspendLayout();
            cardRevenue.SuspendLayout();
            cardBranch.SuspendLayout();
            cardLoss.SuspendLayout();
            pnlMainContent.SuspendLayout();
            pnlCenterLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).BeginInit();
            pnlCenterRight.SuspendLayout();
            pnlStats.SuspendLayout();
            pnlActionSidebar.SuspendLayout();
            pnlFooter.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTitleBar
            // 
            pnlTitleBar.BackColor = Color.FromArgb(31, 33, 33);
            pnlTitleBar.Controls.Add(lblTitle);
            pnlTitleBar.Controls.Add(btnClose);
            pnlTitleBar.Dock = DockStyle.Top;
            pnlTitleBar.Location = new Point(0, 0);
            pnlTitleBar.Margin = new Padding(4, 5, 4, 5);
            pnlTitleBar.Name = "pnlTitleBar";
            pnlTitleBar.Size = new Size(1600, 62);
            pnlTitleBar.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(245, 245, 245);
            lblTitle.Location = new Point(16, 14);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(332, 28);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Owner Dashboard - Nexus Retail ERP";
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.BackColor = Color.Transparent;
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatAppearance.MouseDownBackColor = Color.FromArgb(232, 17, 35);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.FromArgb(200, 200, 200);
            btnClose.Location = new Point(1547, 0);
            btnClose.Margin = new Padding(4, 5, 4, 5);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(53, 62);
            btnClose.TabIndex = 1;
            btnClose.Text = "✕";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += BtnClose_Click;
            btnClose.MouseEnter += BtnClose_MouseEnter;
            btnClose.MouseLeave += BtnClose_MouseLeave;
            // 
            // pnlTopSection
            // 
            pnlTopSection.BackColor = Color.Transparent;
            pnlTopSection.Controls.Add(cardRevenue);
            pnlTopSection.Controls.Add(cardBranch);
            pnlTopSection.Controls.Add(cardLoss);
            pnlTopSection.Dock = DockStyle.Top;
            pnlTopSection.Location = new Point(0, 62);
            pnlTopSection.Margin = new Padding(4, 5, 4, 5);
            pnlTopSection.Name = "pnlTopSection";
            pnlTopSection.Size = new Size(1600, 192);
            pnlTopSection.TabIndex = 1;
            pnlTopSection.Paint += pnlTopSection_Paint;
            // 
            // cardRevenue
            // 
            cardRevenue.BackColor = Color.FromArgb(245, 245, 245);
            cardRevenue.BorderStyle = BorderStyle.FixedSingle;
            cardRevenue.Controls.Add(lblTotalRevenue);
            cardRevenue.Controls.Add(lblRevenueLabel);
            cardRevenue.Location = new Point(27, 15);
            cardRevenue.Margin = new Padding(4, 5, 4, 5);
            cardRevenue.Name = "cardRevenue";
            cardRevenue.Size = new Size(321, 153);
            cardRevenue.TabIndex = 0;
            cardRevenue.MouseEnter += Card_MouseEnter;
            cardRevenue.MouseLeave += Card_MouseLeave;
            // 
            // lblTotalRevenue
            // 
            lblTotalRevenue.AutoSize = true;
            lblTotalRevenue.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalRevenue.ForeColor = Color.FromArgb(45, 166, 178);
            lblTotalRevenue.Location = new Point(27, 62);
            lblTotalRevenue.Margin = new Padding(4, 0, 4, 0);
            lblTotalRevenue.Name = "lblTotalRevenue";
            lblTotalRevenue.Size = new Size(126, 54);
            lblTotalRevenue.TabIndex = 1;
            lblTotalRevenue.Text = "$0.00";
            // 
            // lblRevenueLabel
            // 
            lblRevenueLabel.AutoSize = true;
            lblRevenueLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblRevenueLabel.ForeColor = Color.FromArgb(100, 100, 100);
            lblRevenueLabel.Location = new Point(27, 23);
            lblRevenueLabel.Margin = new Padding(4, 0, 4, 0);
            lblRevenueLabel.Name = "lblRevenueLabel";
            lblRevenueLabel.Size = new Size(136, 23);
            lblRevenueLabel.TabIndex = 0;
            lblRevenueLabel.Text = "TODAY'S SALES";
            // 
            // cardBranch
            // 
            cardBranch.BackColor = Color.FromArgb(245, 245, 245);
            cardBranch.BorderStyle = BorderStyle.FixedSingle;
            cardBranch.Controls.Add(lblBestBranch);
            cardBranch.Controls.Add(lblBranchLabel);
            cardBranch.Location = new Point(393, 15);
            cardBranch.Margin = new Padding(4, 5, 4, 5);
            cardBranch.Name = "cardBranch";
            cardBranch.Size = new Size(312, 153);
            cardBranch.TabIndex = 1;
            cardBranch.MouseEnter += Card_MouseEnter;
            cardBranch.MouseLeave += Card_MouseLeave;
            // 
            // lblBestBranch
            // 
            lblBestBranch.AutoSize = true;
            lblBestBranch.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblBestBranch.ForeColor = Color.FromArgb(76, 175, 80);
            lblBestBranch.Location = new Point(27, 69);
            lblBestBranch.Margin = new Padding(4, 0, 4, 0);
            lblBestBranch.Name = "lblBestBranch";
            lblBestBranch.Size = new Size(86, 46);
            lblBestBranch.TabIndex = 1;
            lblBestBranch.Text = "N/A";
            // 
            // lblBranchLabel
            // 
            lblBranchLabel.AutoSize = true;
            lblBranchLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblBranchLabel.ForeColor = Color.FromArgb(100, 100, 100);
            lblBranchLabel.Location = new Point(27, 23);
            lblBranchLabel.Margin = new Padding(4, 0, 4, 0);
            lblBranchLabel.Name = "lblBranchLabel";
            lblBranchLabel.Size = new Size(126, 23);
            lblBranchLabel.TabIndex = 0;
            lblBranchLabel.Text = "BEST BRANCH";
            // 
            // cardLoss
            // 
            cardLoss.BackColor = Color.FromArgb(245, 245, 245);
            cardLoss.BorderStyle = BorderStyle.FixedSingle;
            cardLoss.Controls.Add(lblLossAnalysis);
            cardLoss.Controls.Add(lblLossLabel);
            cardLoss.Location = new Point(748, 15);
            cardLoss.Margin = new Padding(4, 5, 4, 5);
            cardLoss.Name = "cardLoss";
            cardLoss.Size = new Size(319, 153);
            cardLoss.TabIndex = 2;
            cardLoss.MouseEnter += Card_MouseEnter;
            cardLoss.MouseLeave += Card_MouseLeave;
            // 
            // lblLossAnalysis
            // 
            lblLossAnalysis.AutoSize = true;
            lblLossAnalysis.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLossAnalysis.ForeColor = Color.FromArgb(255, 152, 0);
            lblLossAnalysis.Location = new Point(27, 62);
            lblLossAnalysis.Margin = new Padding(4, 0, 4, 0);
            lblLossAnalysis.Name = "lblLossAnalysis";
            lblLossAnalysis.Size = new Size(126, 54);
            lblLossAnalysis.TabIndex = 1;
            lblLossAnalysis.Text = "$0.00";
            // 
            // lblLossLabel
            // 
            lblLossLabel.AutoSize = true;
            lblLossLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblLossLabel.ForeColor = Color.FromArgb(100, 100, 100);
            lblLossLabel.Location = new Point(27, 23);
            lblLossLabel.Margin = new Padding(4, 0, 4, 0);
            lblLossLabel.Name = "lblLossLabel";
            lblLossLabel.Size = new Size(147, 23);
            lblLossLabel.TabIndex = 0;
            lblLossLabel.Text = "TODAY'S LOSSES";
            // 
            // pnlMainContent
            // 
            pnlMainContent.Controls.Add(pnlCenterLeft);
            pnlMainContent.Controls.Add(pnlCenterRight);
            pnlMainContent.Dock = DockStyle.Fill;
            pnlMainContent.Location = new Point(0, 254);
            pnlMainContent.Margin = new Padding(4, 5, 4, 5);
            pnlMainContent.Name = "pnlMainContent";
            pnlMainContent.Size = new Size(1600, 761);
            pnlMainContent.TabIndex = 2;
            // 
            // pnlCenterLeft
            // 
            pnlCenterLeft.BackColor = Color.FromArgb(245, 245, 245);
            pnlCenterLeft.BorderStyle = BorderStyle.FixedSingle;
            pnlCenterLeft.Controls.Add(dgvTransactions);
            pnlCenterLeft.Controls.Add(lblGridTitle);
            pnlCenterLeft.Dock = DockStyle.Fill;
            pnlCenterLeft.Location = new Point(0, 0);
            pnlCenterLeft.Margin = new Padding(4, 5, 4, 5);
            pnlCenterLeft.Name = "pnlCenterLeft";
            pnlCenterLeft.Size = new Size(1067, 761);
            pnlCenterLeft.TabIndex = 0;
            // 
            // dgvTransactions
            // 
            dgvTransactions.AllowUserToAddRows = false;
            dgvTransactions.AllowUserToDeleteRows = false;
            dgvTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTransactions.BackgroundColor = Color.FromArgb(245, 245, 245);
            dgvTransactions.BorderStyle = BorderStyle.None;
            dgvTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTransactions.Location = new Point(27, 92);
            dgvTransactions.Margin = new Padding(4, 5, 4, 5);
            dgvTransactions.Name = "dgvTransactions";
            dgvTransactions.ReadOnly = true;
            dgvTransactions.RowHeadersVisible = false;
            dgvTransactions.RowHeadersWidth = 51;
            dgvTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTransactions.Size = new Size(1000, 646);
            dgvTransactions.TabIndex = 1;
            // 
            // lblGridTitle
            // 
            lblGridTitle.AutoSize = true;
            lblGridTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblGridTitle.ForeColor = Color.FromArgb(50, 50, 50);
            lblGridTitle.Location = new Point(27, 31);
            lblGridTitle.Margin = new Padding(4, 0, 4, 0);
            lblGridTitle.Name = "lblGridTitle";
            lblGridTitle.Size = new Size(347, 32);
            lblGridTitle.TabIndex = 0;
            lblGridTitle.Text = "GLOBAL TRANSACTIONS (30)";
            // 
            // pnlCenterRight
            // 
            pnlCenterRight.BackColor = Color.Transparent;
            pnlCenterRight.Controls.Add(pnlStats);
            pnlCenterRight.Controls.Add(pnlActionSidebar);
            pnlCenterRight.Dock = DockStyle.Right;
            pnlCenterRight.Location = new Point(1067, 0);
            pnlCenterRight.Margin = new Padding(4, 5, 4, 5);
            pnlCenterRight.Name = "pnlCenterRight";
            pnlCenterRight.Size = new Size(533, 761);
            pnlCenterRight.TabIndex = 1;
            // 
            // pnlStats
            // 
            pnlStats.BackColor = Color.FromArgb(245, 245, 245);
            pnlStats.BorderStyle = BorderStyle.FixedSingle;
            pnlStats.Controls.Add(lblStat3);
            pnlStats.Controls.Add(lblStat3Label);
            pnlStats.Controls.Add(lblStat2);
            pnlStats.Controls.Add(lblStat2Label);
            pnlStats.Controls.Add(lblStat1);
            pnlStats.Controls.Add(lblStat1Label);
            pnlStats.Controls.Add(lblStat0);
            pnlStats.Controls.Add(lblStat0Label);
            pnlStats.Controls.Add(lblStatsTitle);
            pnlStats.Location = new Point(31, 0);
            pnlStats.Margin = new Padding(4, 5, 4, 5);
            pnlStats.Name = "pnlStats";
            pnlStats.Size = new Size(479, 228);
            pnlStats.TabIndex = 1;
            // 
            // lblStat3
            // 
            lblStat3.AutoSize = true;
            lblStat3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblStat3.ForeColor = Color.FromArgb(45, 166, 178);
            lblStat3.Location = new Point(333, 180);
            lblStat3.Margin = new Padding(4, 0, 4, 0);
            lblStat3.Name = "lblStat3";
            lblStat3.Size = new Size(24, 28);
            lblStat3.TabIndex = 8;
            lblStat3.Text = "0";
            lblStat3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblStat3Label
            // 
            lblStat3Label.AutoSize = true;
            lblStat3Label.Font = new Font("Segoe UI", 10F);
            lblStat3Label.ForeColor = Color.FromArgb(100, 100, 100);
            lblStat3Label.Location = new Point(27, 180);
            lblStat3Label.Margin = new Padding(4, 0, 4, 0);
            lblStat3Label.Name = "lblStat3Label";
            lblStat3Label.Size = new Size(156, 23);
            lblStat3Label.TabIndex = 7;
            lblStat3Label.Text = "Pending Approvals:";
            // 
            // lblStat2
            // 
            lblStat2.AutoSize = true;
            lblStat2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblStat2.ForeColor = Color.FromArgb(45, 166, 178);
            lblStat2.Location = new Point(333, 149);
            lblStat2.Margin = new Padding(4, 0, 4, 0);
            lblStat2.Name = "lblStat2";
            lblStat2.Size = new Size(24, 28);
            lblStat2.TabIndex = 6;
            lblStat2.Text = "0";
            lblStat2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblStat2Label
            // 
            lblStat2Label.AutoSize = true;
            lblStat2Label.Font = new Font("Segoe UI", 10F);
            lblStat2Label.ForeColor = Color.FromArgb(100, 100, 100);
            lblStat2Label.Location = new Point(27, 149);
            lblStat2Label.Margin = new Padding(4, 0, 4, 0);
            lblStat2Label.Name = "lblStat2Label";
            lblStat2Label.Size = new Size(98, 23);
            lblStat2Label.TabIndex = 5;
            lblStat2Label.Text = "Active Staff:";
            // 
            // lblStat1
            // 
            lblStat1.AutoSize = true;
            lblStat1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblStat1.ForeColor = Color.FromArgb(45, 166, 178);
            lblStat1.Location = new Point(333, 113);
            lblStat1.Margin = new Padding(4, 0, 4, 0);
            lblStat1.Name = "lblStat1";
            lblStat1.Size = new Size(24, 28);
            lblStat1.TabIndex = 4;
            lblStat1.Text = "0";
            lblStat1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblStat1Label
            // 
            lblStat1Label.AutoSize = true;
            lblStat1Label.Font = new Font("Segoe UI", 10F);
            lblStat1Label.ForeColor = Color.FromArgb(100, 100, 100);
            lblStat1Label.Location = new Point(27, 113);
            lblStat1Label.Margin = new Padding(4, 0, 4, 0);
            lblStat1Label.Name = "lblStat1Label";
            lblStat1Label.Size = new Size(124, 23);
            lblStat1Label.TabIndex = 3;
            lblStat1Label.Text = "Total Branches:";
            // 
            // lblStat0
            // 
            lblStat0.AutoSize = true;
            lblStat0.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblStat0.ForeColor = Color.FromArgb(45, 166, 178);
            lblStat0.Location = new Point(333, 72);
            lblStat0.Margin = new Padding(4, 0, 4, 0);
            lblStat0.Name = "lblStat0";
            lblStat0.Size = new Size(24, 28);
            lblStat0.TabIndex = 2;
            lblStat0.Text = "0";
            lblStat0.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblStat0Label
            // 
            lblStat0Label.AutoSize = true;
            lblStat0Label.Font = new Font("Segoe UI", 10F);
            lblStat0Label.ForeColor = Color.FromArgb(100, 100, 100);
            lblStat0Label.Location = new Point(27, 77);
            lblStat0Label.Margin = new Padding(4, 0, 4, 0);
            lblStat0Label.Name = "lblStat0Label";
            lblStat0Label.Size = new Size(149, 23);
            lblStat0Label.TabIndex = 1;
            lblStat0Label.Text = "Total Transactions:";
            // 
            // lblStatsTitle
            // 
            lblStatsTitle.AutoSize = true;
            lblStatsTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblStatsTitle.ForeColor = Color.FromArgb(50, 50, 50);
            lblStatsTitle.Location = new Point(27, 23);
            lblStatsTitle.Margin = new Padding(4, 0, 4, 0);
            lblStatsTitle.Name = "lblStatsTitle";
            lblStatsTitle.Size = new Size(220, 32);
            lblStatsTitle.TabIndex = 0;
            lblStatsTitle.Text = "QUICK STATISTICS";
            // 
            // pnlActionSidebar
            // 
            pnlActionSidebar.BackColor = Color.Transparent;
            pnlActionSidebar.Controls.Add(btnApprovalCenter);
            pnlActionSidebar.Controls.Add(btnStockManager);
            pnlActionSidebar.Controls.Add(btnCategoryManager);
            pnlActionSidebar.Controls.Add(btnBranchManager);
            pnlActionSidebar.Controls.Add(btnViewReports);
            pnlActionSidebar.Controls.Add(btnEmployeeManager);
            pnlActionSidebar.Controls.Add(btnPriceDiscounts);
            pnlActionSidebar.Controls.Add(btnProductMaster);
            pnlActionSidebar.Location = new Point(30, 207);
            pnlActionSidebar.Margin = new Padding(4, 5, 4, 5);
            pnlActionSidebar.Name = "pnlActionSidebar";
            pnlActionSidebar.Size = new Size(480, 532);
            pnlActionSidebar.TabIndex = 0;
            // 
            // btnApprovalCenter
            // 
            btnApprovalCenter.BackColor = Color.FromArgb(45, 166, 178);
            btnApprovalCenter.Cursor = Cursors.Hand;
            btnApprovalCenter.FlatAppearance.BorderSize = 0;
            btnApprovalCenter.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 140, 152);
            btnApprovalCenter.FlatStyle = FlatStyle.Flat;
            btnApprovalCenter.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnApprovalCenter.ForeColor = Color.White;
            btnApprovalCenter.Location = new Point(0, 473);
            btnApprovalCenter.Margin = new Padding(4, 5, 4, 5);
            btnApprovalCenter.Name = "btnApprovalCenter";
            btnApprovalCenter.Size = new Size(480, 46);
            btnApprovalCenter.TabIndex = 7;
            btnApprovalCenter.Text = "📋 Approval Center";
            btnApprovalCenter.UseVisualStyleBackColor = false;
            btnApprovalCenter.Click += BtnApprovalCenter_Click;
            btnApprovalCenter.MouseEnter += Button_MouseEnter;
            btnApprovalCenter.MouseLeave += Button_MouseLeave;
            // 
            // btnStockManager
            // 
            btnStockManager.BackColor = Color.FromArgb(45, 166, 178);
            btnStockManager.Cursor = Cursors.Hand;
            btnStockManager.FlatAppearance.BorderSize = 0;
            btnStockManager.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 140, 152);
            btnStockManager.FlatStyle = FlatStyle.Flat;
            btnStockManager.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnStockManager.ForeColor = Color.White;
            btnStockManager.Location = new Point(0, 349);
            btnStockManager.Margin = new Padding(4, 5, 4, 5);
            btnStockManager.Name = "btnStockManager";
            btnStockManager.Size = new Size(480, 46);
            btnStockManager.TabIndex = 6;
            btnStockManager.Text = "📦 Stock Manager";
            btnStockManager.UseVisualStyleBackColor = false;
            btnStockManager.Click += BtnStockManager_Click;
            btnStockManager.MouseEnter += Button_MouseEnter;
            btnStockManager.MouseLeave += Button_MouseLeave;
            // 
            // btnCategoryManager
            // 
            btnCategoryManager.BackColor = Color.FromArgb(45, 166, 178);
            btnCategoryManager.Cursor = Cursors.Hand;
            btnCategoryManager.FlatAppearance.BorderSize = 0;
            btnCategoryManager.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 140, 152);
            btnCategoryManager.FlatStyle = FlatStyle.Flat;
            btnCategoryManager.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCategoryManager.ForeColor = Color.White;
            btnCategoryManager.Location = new Point(0, 287);
            btnCategoryManager.Margin = new Padding(4, 5, 4, 5);
            btnCategoryManager.Name = "btnCategoryManager";
            btnCategoryManager.Size = new Size(480, 46);
            btnCategoryManager.TabIndex = 5;
            btnCategoryManager.Text = "🏷️ Category Manager";
            btnCategoryManager.UseVisualStyleBackColor = false;
            btnCategoryManager.Click += BtnCategoryManager_Click;
            btnCategoryManager.MouseEnter += Button_MouseEnter;
            btnCategoryManager.MouseLeave += Button_MouseLeave;
            // 
            // btnBranchManager
            // 
            btnBranchManager.BackColor = Color.FromArgb(45, 166, 178);
            btnBranchManager.Cursor = Cursors.Hand;
            btnBranchManager.FlatAppearance.BorderSize = 0;
            btnBranchManager.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 140, 152);
            btnBranchManager.FlatStyle = FlatStyle.Flat;
            btnBranchManager.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBranchManager.ForeColor = Color.White;
            btnBranchManager.Location = new Point(0, 224);
            btnBranchManager.Margin = new Padding(4, 5, 4, 5);
            btnBranchManager.Name = "btnBranchManager";
            btnBranchManager.Size = new Size(480, 46);
            btnBranchManager.TabIndex = 4;
            btnBranchManager.Text = "🏢 Branch Manager";
            btnBranchManager.UseVisualStyleBackColor = false;
            btnBranchManager.Click += BtnBranchManager_Click;
            btnBranchManager.MouseEnter += Button_MouseEnter;
            btnBranchManager.MouseLeave += Button_MouseLeave;
            // 
            // btnViewReports
            // 
            btnViewReports.BackColor = Color.FromArgb(45, 166, 178);
            btnViewReports.Cursor = Cursors.Hand;
            btnViewReports.FlatAppearance.BorderSize = 0;
            btnViewReports.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 140, 152);
            btnViewReports.FlatStyle = FlatStyle.Flat;
            btnViewReports.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnViewReports.ForeColor = Color.White;
            btnViewReports.Location = new Point(0, 411);
            btnViewReports.Margin = new Padding(4, 5, 4, 5);
            btnViewReports.Name = "btnViewReports";
            btnViewReports.Size = new Size(480, 46);
            btnViewReports.TabIndex = 3;
            btnViewReports.Text = "📊 View Reports";
            btnViewReports.UseVisualStyleBackColor = false;
            btnViewReports.Click += BtnViewReports_Click;
            btnViewReports.MouseEnter += Button_MouseEnter;
            btnViewReports.MouseLeave += Button_MouseLeave;
            // 
            // btnEmployeeManager
            // 
            btnEmployeeManager.BackColor = Color.FromArgb(45, 166, 178);
            btnEmployeeManager.Cursor = Cursors.Hand;
            btnEmployeeManager.FlatAppearance.BorderSize = 0;
            btnEmployeeManager.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 140, 152);
            btnEmployeeManager.FlatStyle = FlatStyle.Flat;
            btnEmployeeManager.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEmployeeManager.ForeColor = Color.White;
            btnEmployeeManager.Location = new Point(0, 161);
            btnEmployeeManager.Margin = new Padding(4, 5, 4, 5);
            btnEmployeeManager.Name = "btnEmployeeManager";
            btnEmployeeManager.Size = new Size(480, 46);
            btnEmployeeManager.TabIndex = 2;
            btnEmployeeManager.Text = "👥 Employee Manager";
            btnEmployeeManager.UseVisualStyleBackColor = false;
            btnEmployeeManager.Click += BtnEmployeeManager_Click;
            btnEmployeeManager.MouseEnter += Button_MouseEnter;
            btnEmployeeManager.MouseLeave += Button_MouseLeave;
            // 
            // btnPriceDiscounts
            // 
            btnPriceDiscounts.BackColor = Color.FromArgb(45, 166, 178);
            btnPriceDiscounts.Cursor = Cursors.Hand;
            btnPriceDiscounts.FlatAppearance.BorderSize = 0;
            btnPriceDiscounts.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 140, 152);
            btnPriceDiscounts.FlatStyle = FlatStyle.Flat;
            btnPriceDiscounts.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnPriceDiscounts.ForeColor = Color.White;
            btnPriceDiscounts.Location = new Point(0, 99);
            btnPriceDiscounts.Margin = new Padding(4, 5, 4, 5);
            btnPriceDiscounts.Name = "btnPriceDiscounts";
            btnPriceDiscounts.Size = new Size(480, 46);
            btnPriceDiscounts.TabIndex = 1;
            btnPriceDiscounts.Text = "💰 Price & Discounts";
            btnPriceDiscounts.UseVisualStyleBackColor = false;
            btnPriceDiscounts.Click += BtnPriceDiscounts_Click;
            btnPriceDiscounts.MouseEnter += Button_MouseEnter;
            btnPriceDiscounts.MouseLeave += Button_MouseLeave;
            // 
            // btnProductMaster
            // 
            btnProductMaster.BackColor = Color.FromArgb(45, 166, 178);
            btnProductMaster.Cursor = Cursors.Hand;
            btnProductMaster.FlatAppearance.BorderSize = 0;
            btnProductMaster.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 140, 152);
            btnProductMaster.FlatStyle = FlatStyle.Flat;
            btnProductMaster.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnProductMaster.ForeColor = Color.White;
            btnProductMaster.Location = new Point(0, 38);
            btnProductMaster.Margin = new Padding(4, 5, 4, 5);
            btnProductMaster.Name = "btnProductMaster";
            btnProductMaster.Size = new Size(480, 46);
            btnProductMaster.TabIndex = 0;
            btnProductMaster.Text = "📦 Product Master";
            btnProductMaster.UseVisualStyleBackColor = false;
            btnProductMaster.Click += BtnProductMaster_Click;
            btnProductMaster.MouseEnter += Button_MouseEnter;
            btnProductMaster.MouseLeave += Button_MouseLeave;
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = Color.FromArgb(30, 32, 32);
            pnlFooter.Controls.Add(lblFooterTicker);
            pnlFooter.Controls.Add(lblFooterTitle);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 1015);
            pnlFooter.Margin = new Padding(4, 5, 4, 5);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(1600, 62);
            pnlFooter.TabIndex = 3;
            // 
            // lblFooterTicker
            // 
            lblFooterTicker.AutoSize = true;
            lblFooterTicker.Font = new Font("Segoe UI", 9F);
            lblFooterTicker.ForeColor = Color.FromArgb(200, 200, 200);
            lblFooterTicker.Location = new Point(227, 18);
            lblFooterTicker.Margin = new Padding(4, 0, 4, 0);
            lblFooterTicker.Name = "lblFooterTicker";
            lblFooterTicker.Size = new Size(277, 20);
            lblFooterTicker.TabIndex = 1;
            lblFooterTicker.Text = "System initialized. Ready for monitoring.";
            // 
            // lblFooterTitle
            // 
            lblFooterTitle.AutoSize = true;
            lblFooterTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFooterTitle.ForeColor = Color.FromArgb(76, 175, 80);
            lblFooterTitle.Location = new Point(27, 18);
            lblFooterTitle.Margin = new Padding(4, 0, 4, 0);
            lblFooterTitle.Name = "lblFooterTitle";
            lblFooterTitle.Size = new Size(164, 20);
            lblFooterTitle.TabIndex = 0;
            lblFooterTitle.Text = "🔒 Security Audit Log";
            // 
            // timerFadeIn
            // 
            timerFadeIn.Interval = 20;
            timerFadeIn.Tick += TimerFadeIn_Tick;
            // 
            // timerFooterTicker
            // 
            timerFooterTicker.Interval = 4000;
            timerFooterTicker.Tick += TimerFooterTicker_Tick;
            // 
            // OwnerDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(31, 33, 33);
            ClientSize = new Size(1600, 1077);
            Controls.Add(pnlMainContent);
            Controls.Add(pnlFooter);
            Controls.Add(pnlTopSection);
            Controls.Add(pnlTitleBar);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "OwnerDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Owner Dashboard - Nexus Retail ERP";
            Load += OwnerDashboard_Load;
            pnlTitleBar.ResumeLayout(false);
            pnlTitleBar.PerformLayout();
            pnlTopSection.ResumeLayout(false);
            cardRevenue.ResumeLayout(false);
            cardRevenue.PerformLayout();
            cardBranch.ResumeLayout(false);
            cardBranch.PerformLayout();
            cardLoss.ResumeLayout(false);
            cardLoss.PerformLayout();
            pnlMainContent.ResumeLayout(false);
            pnlCenterLeft.ResumeLayout(false);
            pnlCenterLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).EndInit();
            pnlCenterRight.ResumeLayout(false);
            pnlStats.ResumeLayout(false);
            pnlStats.PerformLayout();
            pnlActionSidebar.ResumeLayout(false);
            pnlFooter.ResumeLayout(false);
            pnlFooter.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitleBar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlTopSection;
        private System.Windows.Forms.Panel cardRevenue;
        private System.Windows.Forms.Label lblTotalRevenue;
        private System.Windows.Forms.Label lblRevenueLabel;
        private System.Windows.Forms.Panel cardBranch;
        private System.Windows.Forms.Label lblBestBranch;
        private System.Windows.Forms.Label lblBranchLabel;
        private System.Windows.Forms.Panel cardLoss;
        private System.Windows.Forms.Label lblLossAnalysis;
        private System.Windows.Forms.Label lblLossLabel;
        private System.Windows.Forms.Panel pnlMainContent;
        private System.Windows.Forms.Panel pnlCenterLeft;
        private System.Windows.Forms.DataGridView dgvTransactions;
        private System.Windows.Forms.Label lblGridTitle;
        private System.Windows.Forms.Panel pnlCenterRight;
        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.Label lblStat3;
        private System.Windows.Forms.Label lblStat3Label;
        private System.Windows.Forms.Label lblStat2;
        private System.Windows.Forms.Label lblStat2Label;
        private System.Windows.Forms.Label lblStat1;
        private System.Windows.Forms.Label lblStat1Label;
        private System.Windows.Forms.Label lblStat0;
        private System.Windows.Forms.Label lblStat0Label;
        private System.Windows.Forms.Label lblStatsTitle;
        private System.Windows.Forms.Panel pnlActionSidebar;
        private System.Windows.Forms.Button btnProductMaster;
        private System.Windows.Forms.Button btnPriceDiscounts;
        private System.Windows.Forms.Button btnEmployeeManager;
        private System.Windows.Forms.Button btnViewReports;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblFooterTicker;
        private System.Windows.Forms.Label lblFooterTitle;
        private System.Windows.Forms.Timer timerFadeIn;
        private System.Windows.Forms.Timer timerFooterTicker;
        private System.Windows.Forms.Button btnBranchManager;
        private System.Windows.Forms.Button btnCategoryManager;
        private System.Windows.Forms.Button btnStockManager;
        private System.Windows.Forms.Button btnApprovalCenter;
    }
}