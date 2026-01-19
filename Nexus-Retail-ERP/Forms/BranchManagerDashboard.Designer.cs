namespace Nexus_Retail_ERP.Forms
{
    partial class BranchManagerDashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pnlSidebar = new Panel();
            btnStaff = new Button();
            btnTransfer = new Button();
            btnInventory = new Button();
            btnOverview = new Button();
            btnLogout = new Button();
            pnlLogo = new Panel();
            lblLogo = new Label();
            pnlRightMain = new Panel();
            pnlContent = new Panel();
            pnlFooter = new Panel();
            lblFooter = new Label();
            pnlHeader = new Panel();
            lblBadge = new Label();
            btnNotif = new Button();
            btnClose = new Button();
            lblBranchName = new Label();
            lblPageTitle = new Label();
            timerFadeIn = new System.Windows.Forms.Timer(components);
            timerFooterTicker = new System.Windows.Forms.Timer(components);
            pnlSidebar.SuspendLayout();
            pnlLogo.SuspendLayout();
            pnlRightMain.SuspendLayout();
            pnlFooter.SuspendLayout();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(32, 35, 45);
            pnlSidebar.Controls.Add(btnStaff);
            pnlSidebar.Controls.Add(btnTransfer);
            pnlSidebar.Controls.Add(btnInventory);
            pnlSidebar.Controls.Add(btnOverview);
            pnlSidebar.Controls.Add(btnLogout);
            pnlSidebar.Controls.Add(pnlLogo);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(260, 768);
            pnlSidebar.TabIndex = 1;
            // 
            // btnStaff
            // 
            btnStaff.Dock = DockStyle.Top;
            btnStaff.FlatAppearance.BorderSize = 0;
            btnStaff.FlatStyle = FlatStyle.Flat;
            btnStaff.ForeColor = Color.White;
            btnStaff.Location = new Point(0, 245);
            btnStaff.Name = "btnStaff";
            btnStaff.Size = new Size(260, 55);
            btnStaff.TabIndex = 0;
            btnStaff.Text = "  👥 My Staff";
            btnStaff.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnTransfer
            // 
            btnTransfer.Dock = DockStyle.Top;
            btnTransfer.FlatAppearance.BorderSize = 0;
            btnTransfer.FlatStyle = FlatStyle.Flat;
            btnTransfer.ForeColor = Color.White;
            btnTransfer.Location = new Point(0, 190);
            btnTransfer.Name = "btnTransfer";
            btnTransfer.Size = new Size(260, 55);
            btnTransfer.TabIndex = 1;
            btnTransfer.Text = "  🚚 Transfer Center";
            btnTransfer.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnInventory
            // 
            btnInventory.Dock = DockStyle.Top;
            btnInventory.FlatAppearance.BorderSize = 0;
            btnInventory.FlatStyle = FlatStyle.Flat;
            btnInventory.ForeColor = Color.White;
            btnInventory.Location = new Point(0, 135);
            btnInventory.Name = "btnInventory";
            btnInventory.Size = new Size(260, 55);
            btnInventory.TabIndex = 2;
            btnInventory.Text = "  📦 Inventory & Restock";
            btnInventory.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnOverview
            // 
            btnOverview.Dock = DockStyle.Top;
            btnOverview.FlatAppearance.BorderSize = 0;
            btnOverview.FlatStyle = FlatStyle.Flat;
            btnOverview.ForeColor = Color.White;
            btnOverview.Location = new Point(0, 80);
            btnOverview.Name = "btnOverview";
            btnOverview.Size = new Size(260, 55);
            btnOverview.TabIndex = 3;
            btnOverview.Text = "  🏠 Overview";
            btnOverview.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnLogout
            // 
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.ForeColor = Color.IndianRed;
            btnLogout.Location = new Point(0, 713);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(260, 55);
            btnLogout.TabIndex = 4;
            btnLogout.Text = "  🚪 Logout";
            btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlLogo
            // 
            pnlLogo.Controls.Add(lblLogo);
            pnlLogo.Dock = DockStyle.Top;
            pnlLogo.Location = new Point(0, 0);
            pnlLogo.Name = "pnlLogo";
            pnlLogo.Size = new Size(260, 80);
            pnlLogo.TabIndex = 5;
            // 
            // lblLogo
            // 
            lblLogo.AutoSize = true;
            lblLogo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblLogo.ForeColor = Color.White;
            lblLogo.Location = new Point(12, 9);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(136, 64);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "NEXUS\nMANAGER";
            lblLogo.Click += lblLogo_Click;
            // 
            // pnlRightMain
            // 
            pnlRightMain.Controls.Add(pnlContent);
            pnlRightMain.Controls.Add(pnlFooter);
            pnlRightMain.Controls.Add(pnlHeader);
            pnlRightMain.Dock = DockStyle.Fill;
            pnlRightMain.Location = new Point(260, 0);
            pnlRightMain.Name = "pnlRightMain";
            pnlRightMain.Size = new Size(1020, 768);
            pnlRightMain.TabIndex = 0;
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.FromArgb(245, 247, 250);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 60);
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(20);
            pnlContent.Size = new Size(1020, 678);
            pnlContent.TabIndex = 0;
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = Color.FromArgb(40, 40, 40);
            pnlFooter.Controls.Add(lblFooter);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 738);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(1020, 30);
            pnlFooter.TabIndex = 1;
            // 
            // lblFooter
            // 
            lblFooter.Dock = DockStyle.Fill;
            lblFooter.ForeColor = Color.LightGray;
            lblFooter.Location = new Point(0, 0);
            lblFooter.Name = "lblFooter";
            lblFooter.Padding = new Padding(10, 0, 0, 0);
            lblFooter.Size = new Size(1020, 30);
            lblFooter.TabIndex = 0;
            lblFooter.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.White;
            pnlHeader.Controls.Add(lblBadge);
            pnlHeader.Controls.Add(btnNotif);
            pnlHeader.Controls.Add(btnClose);
            pnlHeader.Controls.Add(lblBranchName);
            pnlHeader.Controls.Add(lblPageTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1020, 60);
            pnlHeader.TabIndex = 2;
            // 
            // lblBadge
            // 
            lblBadge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblBadge.BackColor = Color.Red;
            lblBadge.ForeColor = Color.White;
            lblBadge.Location = new Point(1765, 10);
            lblBadge.Name = "lblBadge";
            lblBadge.Size = new Size(20, 20);
            lblBadge.TabIndex = 0;
            lblBadge.Text = "0";
            lblBadge.TextAlign = ContentAlignment.MiddleCenter;
            lblBadge.Visible = false;
            // 
            // btnNotif
            // 
            btnNotif.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNotif.Cursor = Cursors.Hand;
            btnNotif.FlatAppearance.BorderSize = 0;
            btnNotif.FlatStyle = FlatStyle.Flat;
            btnNotif.Font = new Font("Segoe UI Emoji", 14F);
            btnNotif.Location = new Point(1740, 0);
            btnNotif.Name = "btnNotif";
            btnNotif.Size = new Size(50, 60);
            btnNotif.TabIndex = 1;
            btnNotif.Text = "🔔";
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnClose.ForeColor = Color.IndianRed;
            btnClose.Location = new Point(1790, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(50, 60);
            btnClose.TabIndex = 2;
            btnClose.Text = "X";
            // 
            // lblBranchName
            // 
            lblBranchName.Font = new Font("Swis721 BlkCn BT", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBranchName.Location = new Point(214, 12);
            lblBranchName.Name = "lblBranchName";
            lblBranchName.Size = new Size(594, 34);
            lblBranchName.TabIndex = 3;
            lblBranchName.Text = "Branch Name";
            lblBranchName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPageTitle
            // 
            lblPageTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPageTitle.Location = new Point(6, 12);
            lblPageTitle.Name = "lblPageTitle";
            lblPageTitle.Size = new Size(100, 34);
            lblPageTitle.TabIndex = 4;
            lblPageTitle.Text = "Title";
            // 
            // BranchManagerDashboard
            // 
            ClientSize = new Size(1280, 768);
            Controls.Add(pnlRightMain);
            Controls.Add(pnlSidebar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "BranchManagerDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            pnlSidebar.ResumeLayout(false);
            pnlLogo.ResumeLayout(false);
            pnlLogo.PerformLayout();
            pnlRightMain.ResumeLayout(false);
            pnlFooter.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlRightMain;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Label lblBranchName;
        private System.Windows.Forms.Label lblFooter;
        private System.Windows.Forms.Label lblBadge;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnNotif;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnStaff;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.Button btnOverview;
        private System.Windows.Forms.Timer timerFadeIn;
        private System.Windows.Forms.Timer timerFooterTicker;
    }
}