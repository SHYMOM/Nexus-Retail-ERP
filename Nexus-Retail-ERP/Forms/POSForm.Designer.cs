namespace Nexus_Retail_ERP.Forms
{
    partial class POSForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblTitle = new Label();
            btnClose = new Button();
            layoutMain = new TableLayoutPanel();
            pnlLeft = new Panel();
            pnlCustCard = new Panel();
            lblCustName = new Label();
            lblCustPhone = new Label();
            lblPointsTitle = new Label();
            lblPoints = new Label();
            btnSearchCust = new Button();
            txtCustSearch = new TextBox();
            lblCustTitle = new Label();
            pnlMiddle = new Panel();
            flowProducts = new FlowLayoutPanel();
            pnlProdControls = new Panel();
            txtProdSearch = new TextBox();
            txtInputQty = new TextBox();
            lblQtyTitle = new Label();
            pnlRight = new Panel();
            pnlCartCard = new Panel();
            dgvCart = new DataGridView();
            pnlTotals = new Panel();
            lblSubtotal = new Label();
            lblSubtotalVal = new Label();
            lblTax = new Label();
            lblTaxVal = new Label();
            lblTotalVal = new Label();
            btnPay = new Button();
            btnAddCust = new Button();
            pnlHeader.SuspendLayout();
            layoutMain.SuspendLayout();
            pnlLeft.SuspendLayout();
            pnlCustCard.SuspendLayout();
            pnlMiddle.SuspendLayout();
            pnlProdControls.SuspendLayout();
            pnlRight.SuspendLayout();
            pnlCartCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            pnlTotals.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.Transparent;
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(btnClose);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1368, 50);
            pnlHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(145, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "NEXUS POS";
            // 
            // btnClose
            // 
            btnClose.Dock = DockStyle.Right;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Location = new Point(1318, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(50, 50);
            btnClose.TabIndex = 1;
            btnClose.Text = "X";
            // 
            // layoutMain
            // 
            layoutMain.ColumnCount = 3;
            layoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22F));
            layoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48F));
            layoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            layoutMain.Controls.Add(pnlLeft, 0, 0);
            layoutMain.Controls.Add(pnlMiddle, 1, 0);
            layoutMain.Controls.Add(pnlRight, 2, 0);
            layoutMain.Dock = DockStyle.Fill;
            layoutMain.Location = new Point(0, 50);
            layoutMain.Name = "layoutMain";
            layoutMain.Padding = new Padding(10);
            layoutMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutMain.Size = new Size(1368, 711);
            layoutMain.TabIndex = 0;
            // 
            // pnlLeft
            // 
            pnlLeft.Controls.Add(pnlCustCard);
            pnlLeft.Controls.Add(btnSearchCust);
            pnlLeft.Controls.Add(txtCustSearch);
            pnlLeft.Controls.Add(lblCustTitle);
            pnlLeft.Dock = DockStyle.Fill;
            pnlLeft.Location = new Point(13, 13);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(290, 685);
            pnlLeft.TabIndex = 0;
            // 
            // pnlCustCard
            // 
            pnlCustCard.Controls.Add(lblCustName);
            pnlCustCard.Controls.Add(lblCustPhone);
            pnlCustCard.Controls.Add(lblPointsTitle);
            pnlCustCard.Controls.Add(lblPoints);
            pnlCustCard.Location = new Point(0, 80);
            pnlCustCard.Name = "pnlCustCard";
            pnlCustCard.Size = new Size(240, 150);
            pnlCustCard.TabIndex = 0;
            pnlCustCard.Visible = false;
            // 
            // lblCustName
            // 
            lblCustName.AutoSize = true;
            lblCustName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCustName.Location = new Point(10, 10);
            lblCustName.Name = "lblCustName";
            lblCustName.Size = new Size(68, 28);
            lblCustName.TabIndex = 0;
            lblCustName.Text = "Name";
            // 
            // lblCustPhone
            // 
            lblCustPhone.AutoSize = true;
            lblCustPhone.ForeColor = Color.Gray;
            lblCustPhone.Location = new Point(10, 35);
            lblCustPhone.Name = "lblCustPhone";
            lblCustPhone.Size = new Size(50, 20);
            lblCustPhone.TabIndex = 1;
            lblCustPhone.Text = "Phone";
            // 
            // lblPointsTitle
            // 
            lblPointsTitle.AutoSize = true;
            lblPointsTitle.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblPointsTitle.ForeColor = Color.FromArgb(0, 180, 216);
            lblPointsTitle.Location = new Point(10, 80);
            lblPointsTitle.Name = "lblPointsTitle";
            lblPointsTitle.Size = new Size(60, 19);
            lblPointsTitle.TabIndex = 2;
            lblPointsTitle.Text = "POINTS";
            // 
            // lblPoints
            // 
            lblPoints.AutoSize = true;
            lblPoints.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblPoints.Location = new Point(10, 95);
            lblPoints.Name = "lblPoints";
            lblPoints.Size = new Size(33, 37);
            lblPoints.TabIndex = 3;
            lblPoints.Text = "0";
            // 
            // btnSearchCust
            // 
            btnSearchCust.Location = new Point(190, 29);
            btnSearchCust.Name = "btnSearchCust";
            btnSearchCust.Size = new Size(50, 31);
            btnSearchCust.TabIndex = 1;
            btnSearchCust.Text = "Go";
            // 
            // txtCustSearch
            // 
            txtCustSearch.Font = new Font("Segoe UI", 12F);
            txtCustSearch.Location = new Point(0, 30);
            txtCustSearch.Name = "txtCustSearch";
            txtCustSearch.PlaceholderText = "Phone...";
            txtCustSearch.Size = new Size(180, 34);
            txtCustSearch.TabIndex = 2;
            // 
            // lblCustTitle
            // 
            lblCustTitle.AutoSize = true;
            lblCustTitle.Font = new Font("Segoe UI Semibold", 9F);
            lblCustTitle.ForeColor = Color.LightGray;
            lblCustTitle.Location = new Point(0, 5);
            lblCustTitle.Name = "lblCustTitle";
            lblCustTitle.Size = new Size(145, 20);
            lblCustTitle.TabIndex = 3;
            lblCustTitle.Text = "CUSTOMER SEARCH";
            // 
            // pnlMiddle
            // 
            pnlMiddle.Controls.Add(flowProducts);
            pnlMiddle.Controls.Add(pnlProdControls);
            pnlMiddle.Dock = DockStyle.Fill;
            pnlMiddle.Location = new Point(309, 13);
            pnlMiddle.Name = "pnlMiddle";
            pnlMiddle.Padding = new Padding(10, 0, 10, 0);
            pnlMiddle.Size = new Size(641, 685);
            pnlMiddle.TabIndex = 1;
            // 
            // flowProducts
            // 
            flowProducts.AutoScroll = true;
            flowProducts.Dock = DockStyle.Fill;
            flowProducts.Location = new Point(10, 60);
            flowProducts.Name = "flowProducts";
            flowProducts.Size = new Size(621, 625);
            flowProducts.TabIndex = 0;
            // 
            // pnlProdControls
            // 
            pnlProdControls.Controls.Add(txtProdSearch);
            pnlProdControls.Controls.Add(txtInputQty);
            pnlProdControls.Controls.Add(lblQtyTitle);
            pnlProdControls.Dock = DockStyle.Top;
            pnlProdControls.Location = new Point(10, 0);
            pnlProdControls.Name = "pnlProdControls";
            pnlProdControls.Size = new Size(621, 60);
            pnlProdControls.TabIndex = 1;
            // 
            // txtProdSearch
            // 
            txtProdSearch.Font = new Font("Segoe UI", 12F);
            txtProdSearch.Location = new Point(0, 20);
            txtProdSearch.Name = "txtProdSearch";
            txtProdSearch.PlaceholderText = "Search Product Name...";
            txtProdSearch.Size = new Size(350, 34);
            txtProdSearch.TabIndex = 0;
            // 
            // txtInputQty
            // 
            txtInputQty.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txtInputQty.Location = new Point(410, 20);
            txtInputQty.Name = "txtInputQty";
            txtInputQty.Size = new Size(60, 34);
            txtInputQty.TabIndex = 1;
            txtInputQty.Text = "1";
            txtInputQty.TextAlign = HorizontalAlignment.Center;
            // 
            // lblQtyTitle
            // 
            lblQtyTitle.AutoSize = true;
            lblQtyTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblQtyTitle.ForeColor = Color.White;
            lblQtyTitle.Location = new Point(370, 23);
            lblQtyTitle.Name = "lblQtyTitle";
            lblQtyTitle.Size = new Size(47, 23);
            lblQtyTitle.TabIndex = 2;
            lblQtyTitle.Text = "QTY:";
            // 
            // pnlRight
            // 
            pnlRight.Controls.Add(pnlCartCard);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(956, 13);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(399, 685);
            pnlRight.TabIndex = 2;
            // 
            // pnlCartCard
            // 
            pnlCartCard.Controls.Add(dgvCart);
            pnlCartCard.Controls.Add(pnlTotals);
            pnlCartCard.Dock = DockStyle.Fill;
            pnlCartCard.Location = new Point(0, 0);
            pnlCartCard.Name = "pnlCartCard";
            pnlCartCard.Size = new Size(399, 685);
            pnlCartCard.TabIndex = 0;
            // 
            // dgvCart
            // 
            dgvCart.BackgroundColor = Color.White;
            dgvCart.ColumnHeadersHeight = 29;
            dgvCart.Dock = DockStyle.Fill;
            dgvCart.Location = new Point(0, 0);
            dgvCart.Name = "dgvCart";
            dgvCart.RowHeadersWidth = 51;
            dgvCart.Size = new Size(399, 415);
            dgvCart.TabIndex = 0;
            // 
            // pnlTotals
            // 
            pnlTotals.BackColor = Color.WhiteSmoke;
            pnlTotals.Controls.Add(lblSubtotal);
            pnlTotals.Controls.Add(lblSubtotalVal);
            pnlTotals.Controls.Add(lblTax);
            pnlTotals.Controls.Add(lblTaxVal);
            pnlTotals.Controls.Add(lblTotalVal);
            pnlTotals.Controls.Add(btnPay);
            pnlTotals.Dock = DockStyle.Bottom;
            pnlTotals.Location = new Point(0, 415);
            pnlTotals.Name = "pnlTotals";
            pnlTotals.Padding = new Padding(15);
            pnlTotals.Size = new Size(399, 270);
            pnlTotals.TabIndex = 1;
            // 
            // lblSubtotal
            // 
            lblSubtotal.Location = new Point(20, 20);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new Size(100, 23);
            lblSubtotal.TabIndex = 0;
            lblSubtotal.Text = "Subtotal";
            // 
            // lblSubtotalVal
            // 
            lblSubtotalVal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblSubtotalVal.Location = new Point(200, 20);
            lblSubtotalVal.Name = "lblSubtotalVal";
            lblSubtotalVal.Size = new Size(180, 23);
            lblSubtotalVal.TabIndex = 1;
            lblSubtotalVal.Text = "0.00";
            lblSubtotalVal.TextAlign = ContentAlignment.TopRight;
            // 
            // lblTax
            // 
            lblTax.Location = new Point(20, 50);
            lblTax.Name = "lblTax";
            lblTax.Size = new Size(100, 23);
            lblTax.TabIndex = 2;
            lblTax.Text = "Tax Total";
            // 
            // lblTaxVal
            // 
            lblTaxVal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTaxVal.Location = new Point(200, 50);
            lblTaxVal.Name = "lblTaxVal";
            lblTaxVal.Size = new Size(180, 23);
            lblTaxVal.TabIndex = 3;
            lblTaxVal.Text = "0.00";
            lblTaxVal.TextAlign = ContentAlignment.TopRight;
            // 
            // lblTotalVal
            // 
            lblTotalVal.AutoSize = true;
            lblTotalVal.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTotalVal.ForeColor = Color.FromArgb(0, 180, 216);
            lblTotalVal.Location = new Point(267, 110);
            lblTotalVal.Name = "lblTotalVal";
            lblTotalVal.Size = new Size(113, 41);
            lblTotalVal.TabIndex = 4;
            lblTotalVal.Text = "৳ 0.00";
            lblTotalVal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnPay
            // 
            btnPay.BackColor = Color.SeaGreen;
            btnPay.Dock = DockStyle.Bottom;
            btnPay.FlatStyle = FlatStyle.Flat;
            btnPay.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnPay.ForeColor = Color.White;
            btnPay.Location = new Point(15, 195);
            btnPay.Name = "btnPay";
            btnPay.Size = new Size(369, 60);
            btnPay.TabIndex = 5;
            btnPay.Text = "CHARGE";
            btnPay.UseVisualStyleBackColor = false;
            // 
            // btnAddCust
            // 
            btnAddCust.Location = new Point(0, 0);
            btnAddCust.Name = "btnAddCust";
            btnAddCust.Size = new Size(75, 23);
            btnAddCust.TabIndex = 0;
            // 
            // POSForm
            // 
            ClientSize = new Size(1368, 761);
            Controls.Add(layoutMain);
            Controls.Add(pnlHeader);
            Name = "POSForm";
            Text = "POS";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            layoutMain.ResumeLayout(false);
            pnlLeft.ResumeLayout(false);
            pnlLeft.PerformLayout();
            pnlCustCard.ResumeLayout(false);
            pnlCustCard.PerformLayout();
            pnlMiddle.ResumeLayout(false);
            pnlProdControls.ResumeLayout(false);
            pnlProdControls.PerformLayout();
            pnlRight.ResumeLayout(false);
            pnlCartCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            pnlTotals.ResumeLayout(false);
            pnlTotals.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TableLayoutPanel layoutMain;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlMiddle;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlCustCard;
        private System.Windows.Forms.Label lblCustName;
        private System.Windows.Forms.Label lblCustPhone;
        private System.Windows.Forms.Label lblPointsTitle;
        private System.Windows.Forms.Label lblPoints;
        private System.Windows.Forms.TextBox txtCustSearch;
        private System.Windows.Forms.Button btnSearchCust;
        private System.Windows.Forms.Button btnAddCust;
        private System.Windows.Forms.Label lblCustTitle;
        private System.Windows.Forms.Panel pnlProdControls;
        private System.Windows.Forms.TextBox txtProdSearch;
        private System.Windows.Forms.TextBox txtInputQty;
        private System.Windows.Forms.Label lblQtyTitle;
        private System.Windows.Forms.FlowLayoutPanel flowProducts;
        private System.Windows.Forms.Panel pnlCartCard;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.Panel pnlTotals;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblSubtotalVal;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.Label lblTaxVal;
        private System.Windows.Forms.Label lblTotalVal;
        private System.Windows.Forms.Button btnPay;
    }
}