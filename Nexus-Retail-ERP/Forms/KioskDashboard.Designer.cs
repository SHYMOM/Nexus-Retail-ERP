namespace Nexus_Retail_ERP.Forms
{
    partial class KioskDashboard
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();

            this.lblSearch = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblSort = new System.Windows.Forms.Label();

            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.cmbSort = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();

            this.pnlContent = new System.Windows.Forms.Panel();
            this.flowProducts = new System.Windows.Forms.FlowLayoutPanel();

            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();

            // 
            // HEADER PANEL
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 110;
            this.pnlHeader.Controls.Add(this.lblLogo);
            this.pnlHeader.Controls.Add(this.lblSearch);
            this.pnlHeader.Controls.Add(this.txtSearch);
            this.pnlHeader.Controls.Add(this.btnSearch);
            this.pnlHeader.Controls.Add(this.lblCategory);
            this.pnlHeader.Controls.Add(this.cmbCategory);
            this.pnlHeader.Controls.Add(this.lblSort);
            this.pnlHeader.Controls.Add(this.cmbSort);

            // 
            // LOGO
            // 
            this.lblLogo.AutoSize = true;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.FromArgb(0, 180, 216);
            this.lblLogo.Location = new System.Drawing.Point(20, 30);
            this.lblLogo.Text = "KIOSK BROWSER";
            this.lblLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLogo.DoubleClick += new System.EventHandler(this.lblLogo_DoubleClick); // Wired Event

            // 
            // SEARCH SECTION
            // 
            this.lblSearch.Text = "Search Product";
            this.lblSearch.Location = new System.Drawing.Point(350, 15);
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSearch.ForeColor = System.Drawing.Color.Gray;
            this.lblSearch.AutoSize = true;

            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtSearch.Location = new System.Drawing.Point(350, 40);
            this.txtSearch.Width = 300;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);

            this.btnSearch.Text = "🔍";
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnSearch.Location = new System.Drawing.Point(660, 39);
            this.btnSearch.Width = 50;
            this.btnSearch.Height = 31;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(32, 35, 45);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // 
            // CATEGORY SECTION
            // 
            this.lblCategory.Text = "Select Category";
            this.lblCategory.Location = new System.Drawing.Point(740, 15);
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCategory.ForeColor = System.Drawing.Color.Gray;
            this.lblCategory.AutoSize = true;

            this.cmbCategory.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbCategory.Location = new System.Drawing.Point(740, 40);
            this.cmbCategory.Width = 220;
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);

            // 
            // SORT SECTION
            // 
            this.lblSort.Text = "Sort By";
            this.lblSort.Location = new System.Drawing.Point(990, 15);
            this.lblSort.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSort.ForeColor = System.Drawing.Color.Gray;
            this.lblSort.AutoSize = true;

            this.cmbSort.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbSort.Location = new System.Drawing.Point(990, 40);
            this.cmbSort.Width = 200;
            this.cmbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSort.Items.AddRange(new object[] { "Name: A to Z", "Name: Z to A", "Price: Low to High", "Price: High to Low" });
            this.cmbSort.SelectedIndexChanged += new System.EventHandler(this.cmbSort_SelectedIndexChanged);

            // 
            // CONTENT PANEL
            // 
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.AutoScroll = true;
            this.pnlContent.Padding = new System.Windows.Forms.Padding(20);
            this.pnlContent.Controls.Add(this.flowProducts);

            this.flowProducts.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowProducts.AutoSize = true;
            this.flowProducts.Padding = new System.Windows.Forms.Padding(10);

            // 
            // MAIN FORM
            // 
            this.ClientSize = new System.Drawing.Size(1300, 800);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Name = "KioskDashboard";
            this.Text = "Kiosk";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.KioskDashboard_Load);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblLogo;

        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;

        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;

        private System.Windows.Forms.Label lblSort;
        private System.Windows.Forms.ComboBox cmbSort;

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.FlowLayoutPanel flowProducts;
    }
}