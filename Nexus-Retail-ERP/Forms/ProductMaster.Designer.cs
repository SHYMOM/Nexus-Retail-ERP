namespace Nexus_Retail_ERP.Forms
{
    partial class ProductMaster
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
            pnlMain = new Panel();
            pnlEdit = new Panel();
            lblFormTitle = new Label();
            label7 = new Label();
            picProductImage = new PictureBox();
            btnBrowseImage = new Button();
            btnClearImage = new Button();
            lblImageStatus = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            chkActive = new CheckBox();
            label5 = new Label();
            txtTaxRate = new TextBox();
            label4 = new Label();
            cmbCategory = new ComboBox();
            label3 = new Label();
            txtDescription = new TextBox();
            label2 = new Label();
            txtProductName = new TextBox();
            label1 = new Label();
            pnlList = new Panel();
            lblTotalProducts = new Label();
            dgvProducts = new DataGridView();
            pnlVariantContainer = new Panel();
            pnlVariantEdit = new Panel();
            label17 = new Label();
            label16 = new Label();
            label15 = new Label();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            picVariantImage = new PictureBox();
            btnBrowseVariantImage = new Button();
            btnClearVariantImage = new Button();
            lblVariantImageStatus = new Label();
            btnSaveVariant = new Button();
            btnCancelVariant = new Button();
            txtSKU = new TextBox();
            txtSalesPrice = new TextBox();
            txtCostPrice = new TextBox();
            cmbUOM = new ComboBox();
            txtVariantName = new TextBox();
            lblVariantFormTitle = new Label();
            panel1 = new Panel();
            lblProductVariants = new Label();
            lblTotalVariants = new Label();
            txtSearchVariants = new TextBox();
            label8 = new Label();
            btnRefreshVariants = new Button();
            btnDeactivateVariant = new Button();
            btnActivateVariant = new Button();
            btnDeleteVariant = new Button();
            btnEditVariant = new Button();
            btnAddVariant = new Button();
            dgvVariants = new DataGridView();
            pnlControls = new Panel();
            txtSearch = new TextBox();
            label6 = new Label();
            btnRefresh = new Button();
            btnDelete = new Button();
            btnEdit = new Button();
            btnAddNew = new Button();
            timerFadeIn = new System.Windows.Forms.Timer(components);
            pnlTitleBar.SuspendLayout();
            pnlMain.SuspendLayout();
            pnlEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picProductImage).BeginInit();
            pnlList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            pnlVariantContainer.SuspendLayout();
            pnlVariantEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picVariantImage).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVariants).BeginInit();
            pnlControls.SuspendLayout();
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
            pnlTitleBar.Size = new Size(1333, 62);
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
            lblTitle.Size = new Size(255, 28);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Product Master - Nexus ERP";
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
            btnClose.Location = new Point(1280, 0);
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
            // pnlMain
            // 
            pnlMain.Controls.Add(pnlEdit);
            pnlMain.Controls.Add(pnlList);
            pnlMain.Controls.Add(pnlVariantContainer);
            pnlMain.Controls.Add(pnlControls);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 62);
            pnlMain.Margin = new Padding(4, 5, 4, 5);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(1333, 1169);
            pnlMain.TabIndex = 1;
            // 
            // pnlEdit
            // 
            pnlEdit.BackColor = Color.FromArgb(245, 245, 245);
            pnlEdit.BorderStyle = BorderStyle.FixedSingle;
            pnlEdit.Controls.Add(lblFormTitle);
            pnlEdit.Controls.Add(label7);
            pnlEdit.Controls.Add(picProductImage);
            pnlEdit.Controls.Add(btnBrowseImage);
            pnlEdit.Controls.Add(btnClearImage);
            pnlEdit.Controls.Add(lblImageStatus);
            pnlEdit.Controls.Add(btnSave);
            pnlEdit.Controls.Add(btnCancel);
            pnlEdit.Controls.Add(chkActive);
            pnlEdit.Controls.Add(label5);
            pnlEdit.Controls.Add(txtTaxRate);
            pnlEdit.Controls.Add(label4);
            pnlEdit.Controls.Add(cmbCategory);
            pnlEdit.Controls.Add(label3);
            pnlEdit.Controls.Add(txtDescription);
            pnlEdit.Controls.Add(label2);
            pnlEdit.Controls.Add(txtProductName);
            pnlEdit.Controls.Add(label1);
            pnlEdit.Location = new Point(27, 154);
            pnlEdit.Margin = new Padding(4, 5, 4, 5);
            pnlEdit.Name = "pnlEdit";
            pnlEdit.Size = new Size(1279, 768);
            pnlEdit.TabIndex = 2;
            pnlEdit.Visible = false;
            // 
            // lblFormTitle
            // 
            lblFormTitle.AutoSize = true;
            lblFormTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblFormTitle.ForeColor = Color.FromArgb(45, 166, 178);
            lblFormTitle.Location = new Point(27, 31);
            lblFormTitle.Margin = new Padding(4, 0, 4, 0);
            lblFormTitle.Name = "lblFormTitle";
            lblFormTitle.Size = new Size(159, 32);
            lblFormTitle.TabIndex = 0;
            lblFormTitle.Text = "Add Product";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F);
            label7.Location = new Point(27, 338);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(127, 23);
            label7.TabIndex = 12;
            label7.Text = "Product Image:";
            // 
            // picProductImage
            // 
            picProductImage.BackColor = Color.White;
            picProductImage.BorderStyle = BorderStyle.FixedSingle;
            picProductImage.Location = new Point(160, 338);
            picProductImage.Margin = new Padding(4, 5, 4, 5);
            picProductImage.Name = "picProductImage";
            picProductImage.Size = new Size(199, 230);
            picProductImage.SizeMode = PictureBoxSizeMode.Zoom;
            picProductImage.TabIndex = 13;
            picProductImage.TabStop = false;
            // 
            // btnBrowseImage
            // 
            btnBrowseImage.BackColor = Color.FromArgb(45, 166, 178);
            btnBrowseImage.Cursor = Cursors.Hand;
            btnBrowseImage.FlatAppearance.BorderSize = 0;
            btnBrowseImage.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 140, 152);
            btnBrowseImage.FlatStyle = FlatStyle.Flat;
            btnBrowseImage.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBrowseImage.ForeColor = Color.White;
            btnBrowseImage.Location = new Point(373, 338);
            btnBrowseImage.Margin = new Padding(4, 5, 4, 5);
            btnBrowseImage.Name = "btnBrowseImage";
            btnBrowseImage.Size = new Size(160, 46);
            btnBrowseImage.TabIndex = 8;
            btnBrowseImage.Text = "📁 Browse Image";
            btnBrowseImage.UseVisualStyleBackColor = false;
            btnBrowseImage.Click += BtnBrowseImage_Click;
            btnBrowseImage.MouseEnter += Button_MouseEnter;
            btnBrowseImage.MouseLeave += Button_MouseLeave;
            // 
            // btnClearImage
            // 
            btnClearImage.BackColor = Color.FromArgb(244, 67, 54);
            btnClearImage.Cursor = Cursors.Hand;
            btnClearImage.FlatAppearance.BorderSize = 0;
            btnClearImage.FlatAppearance.MouseDownBackColor = Color.FromArgb(200, 50, 40);
            btnClearImage.FlatStyle = FlatStyle.Flat;
            btnClearImage.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnClearImage.ForeColor = Color.White;
            btnClearImage.Location = new Point(373, 400);
            btnClearImage.Margin = new Padding(4, 5, 4, 5);
            btnClearImage.Name = "btnClearImage";
            btnClearImage.Size = new Size(160, 46);
            btnClearImage.TabIndex = 9;
            btnClearImage.Text = "❌ Clear Image";
            btnClearImage.UseVisualStyleBackColor = false;
            btnClearImage.Click += BtnClearImage_Click;
            btnClearImage.MouseEnter += Button_MouseEnter;
            btnClearImage.MouseLeave += Button_MouseLeave;
            // 
            // lblImageStatus
            // 
            lblImageStatus.AutoSize = true;
            lblImageStatus.Font = new Font("Segoe UI", 9F);
            lblImageStatus.ForeColor = Color.FromArgb(100, 100, 100);
            lblImageStatus.Location = new Point(373, 462);
            lblImageStatus.Margin = new Padding(4, 0, 4, 0);
            lblImageStatus.Name = "lblImageStatus";
            lblImageStatus.Size = new Size(75, 20);
            lblImageStatus.TabIndex = 14;
            lblImageStatus.Text = "No Image";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(76, 175, 80);
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 150, 65);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(933, 677);
            btnSave.Margin = new Padding(4, 5, 4, 5);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(160, 62);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save Product";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_Click;
            btnSave.MouseEnter += Button_MouseEnter;
            btnSave.MouseLeave += Button_MouseLeave;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(244, 67, 54);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatAppearance.MouseDownBackColor = Color.FromArgb(200, 50, 40);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(1107, 677);
            btnCancel.Margin = new Padding(4, 5, 4, 5);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(160, 62);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += BtnCancel_Click;
            btnCancel.MouseEnter += Button_MouseEnter;
            btnCancel.MouseLeave += Button_MouseLeave;
            // 
            // chkActive
            // 
            chkActive.AutoSize = true;
            chkActive.Checked = true;
            chkActive.CheckState = CheckState.Checked;
            chkActive.Font = new Font("Segoe UI", 10F);
            chkActive.Location = new Point(373, 523);
            chkActive.Margin = new Padding(4, 5, 4, 5);
            chkActive.Name = "chkActive";
            chkActive.Size = new Size(159, 27);
            chkActive.TabIndex = 5;
            chkActive.Text = "Product is Active";
            chkActive.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.Location = new Point(27, 585);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(77, 23);
            label5.TabIndex = 10;
            label5.Text = "Tax Rate:";
            // 
            // txtTaxRate
            // 
            txtTaxRate.Font = new Font("Segoe UI", 10F);
            txtTaxRate.Location = new Point(160, 580);
            txtTaxRate.Margin = new Padding(4, 5, 4, 5);
            txtTaxRate.Name = "txtTaxRate";
            txtTaxRate.Size = new Size(199, 30);
            txtTaxRate.TabIndex = 4;
            txtTaxRate.Text = "0.00";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.Location = new Point(27, 215);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(83, 23);
            label4.TabIndex = 8;
            label4.Text = "Category:";
            // 
            // cmbCategory
            // 
            cmbCategory.Font = new Font("Segoe UI", 10F);
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(160, 211);
            cmbCategory.Margin = new Padding(4, 5, 4, 5);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(332, 31);
            cmbCategory.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(27, 154);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(100, 23);
            label3.TabIndex = 6;
            label3.Text = "Description:";
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 10F);
            txtDescription.Location = new Point(160, 149);
            txtDescription.Margin = new Padding(4, 5, 4, 5);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(1105, 30);
            txtDescription.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(27, 92);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(125, 23);
            label2.TabIndex = 4;
            label2.Text = "Product Name:";
            // 
            // txtProductName
            // 
            txtProductName.Font = new Font("Segoe UI", 10F);
            txtProductName.Location = new Point(160, 88);
            txtProductName.Margin = new Padding(4, 5, 4, 5);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(1105, 30);
            txtProductName.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(373, 585);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(24, 23);
            label1.TabIndex = 0;
            label1.Text = "%";
            // 
            // pnlList
            // 
            pnlList.BackColor = Color.FromArgb(245, 245, 245);
            pnlList.BorderStyle = BorderStyle.FixedSingle;
            pnlList.Controls.Add(lblTotalProducts);
            pnlList.Controls.Add(dgvProducts);
            pnlList.Location = new Point(27, 92);
            pnlList.Margin = new Padding(4, 5, 4, 5);
            pnlList.Name = "pnlList";
            pnlList.Size = new Size(1279, 460);
            pnlList.TabIndex = 1;
            // 
            // lblTotalProducts
            // 
            lblTotalProducts.AutoSize = true;
            lblTotalProducts.Font = new Font("Segoe UI", 10F);
            lblTotalProducts.ForeColor = Color.FromArgb(100, 100, 100);
            lblTotalProducts.Location = new Point(27, 31);
            lblTotalProducts.Margin = new Padding(4, 0, 4, 0);
            lblTotalProducts.Name = "lblTotalProducts";
            lblTotalProducts.Size = new Size(136, 23);
            lblTotalProducts.TabIndex = 1;
            lblTotalProducts.Text = "Total Products: 0";
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.BackgroundColor = Color.FromArgb(245, 245, 245);
            dgvProducts.BorderStyle = BorderStyle.None;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Location = new Point(27, 77);
            dgvProducts.Margin = new Padding(4, 5, 4, 5);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersVisible = false;
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(1227, 354);
            dgvProducts.TabIndex = 0;
            dgvProducts.CellMouseEnter += DgvProducts_CellMouseEnter;
            dgvProducts.CellMouseLeave += DgvProducts_CellMouseLeave;
            dgvProducts.SelectionChanged += DgvProducts_SelectionChanged;
            // 
            // pnlVariantContainer
            // 
            pnlVariantContainer.BackColor = Color.Transparent;
            pnlVariantContainer.Controls.Add(pnlVariantEdit);
            pnlVariantContainer.Controls.Add(panel1);
            pnlVariantContainer.Location = new Point(27, 569);
            pnlVariantContainer.Margin = new Padding(4, 5, 4, 5);
            pnlVariantContainer.Name = "pnlVariantContainer";
            pnlVariantContainer.Size = new Size(1280, 538);
            pnlVariantContainer.TabIndex = 3;
            pnlVariantContainer.Visible = false;
            // 
            // pnlVariantEdit
            // 
            pnlVariantEdit.BackColor = Color.FromArgb(245, 245, 245);
            pnlVariantEdit.BorderStyle = BorderStyle.FixedSingle;
            pnlVariantEdit.Controls.Add(label17);
            pnlVariantEdit.Controls.Add(label16);
            pnlVariantEdit.Controls.Add(label15);
            pnlVariantEdit.Controls.Add(label14);
            pnlVariantEdit.Controls.Add(label13);
            pnlVariantEdit.Controls.Add(label12);
            pnlVariantEdit.Controls.Add(label11);
            pnlVariantEdit.Controls.Add(picVariantImage);
            pnlVariantEdit.Controls.Add(btnBrowseVariantImage);
            pnlVariantEdit.Controls.Add(btnClearVariantImage);
            pnlVariantEdit.Controls.Add(lblVariantImageStatus);
            pnlVariantEdit.Controls.Add(btnSaveVariant);
            pnlVariantEdit.Controls.Add(btnCancelVariant);
            pnlVariantEdit.Controls.Add(txtSKU);
            pnlVariantEdit.Controls.Add(txtSalesPrice);
            pnlVariantEdit.Controls.Add(txtCostPrice);
            pnlVariantEdit.Controls.Add(cmbUOM);
            pnlVariantEdit.Controls.Add(txtVariantName);
            pnlVariantEdit.Controls.Add(lblVariantFormTitle);
            pnlVariantEdit.Location = new Point(0, 0);
            pnlVariantEdit.Margin = new Padding(4, 5, 4, 5);
            pnlVariantEdit.Name = "pnlVariantEdit";
            pnlVariantEdit.Size = new Size(1279, 537);
            pnlVariantEdit.TabIndex = 1;
            pnlVariantEdit.Visible = false;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 10F);
            label17.Location = new Point(27, 262);
            label17.Margin = new Padding(4, 0, 4, 0);
            label17.Name = "label17";
            label17.Size = new Size(45, 23);
            label17.TabIndex = 29;
            label17.Text = "SKU:";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 10F);
            label16.Location = new Point(27, 200);
            label16.Margin = new Padding(4, 0, 4, 0);
            label16.Name = "label16";
            label16.Size = new Size(94, 23);
            label16.TabIndex = 28;
            label16.Text = "Sales Price:";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 10F);
            label15.Location = new Point(27, 138);
            label15.Margin = new Padding(4, 0, 4, 0);
            label15.Name = "label15";
            label15.Size = new Size(90, 23);
            label15.TabIndex = 27;
            label15.Text = "Cost Price:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 10F);
            label14.Location = new Point(27, 323);
            label14.Margin = new Padding(4, 0, 4, 0);
            label14.Name = "label14";
            label14.Size = new Size(121, 23);
            label14.TabIndex = 26;
            label14.Text = "Variant Image:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 10F);
            label13.Location = new Point(27, 77);
            label13.Margin = new Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new Size(54, 23);
            label13.TabIndex = 25;
            label13.Text = "UOM:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 10F);
            label12.Location = new Point(27, 15);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(119, 23);
            label12.TabIndex = 24;
            label12.Text = "Variant Name:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 10F);
            label11.Location = new Point(373, 262);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(196, 23);
            label11.TabIndex = 23;
            label11.Text = "(Barcode/Stock Keeping)";
            // 
            // picVariantImage
            // 
            picVariantImage.BackColor = Color.White;
            picVariantImage.BorderStyle = BorderStyle.FixedSingle;
            picVariantImage.Location = new Point(173, 323);
            picVariantImage.Margin = new Padding(4, 5, 4, 5);
            picVariantImage.Name = "picVariantImage";
            picVariantImage.Size = new Size(133, 153);
            picVariantImage.SizeMode = PictureBoxSizeMode.Zoom;
            picVariantImage.TabIndex = 22;
            picVariantImage.TabStop = false;
            // 
            // btnBrowseVariantImage
            // 
            btnBrowseVariantImage.BackColor = Color.FromArgb(45, 166, 178);
            btnBrowseVariantImage.Cursor = Cursors.Hand;
            btnBrowseVariantImage.FlatAppearance.BorderSize = 0;
            btnBrowseVariantImage.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 140, 152);
            btnBrowseVariantImage.FlatStyle = FlatStyle.Flat;
            btnBrowseVariantImage.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBrowseVariantImage.ForeColor = Color.White;
            btnBrowseVariantImage.Location = new Point(320, 323);
            btnBrowseVariantImage.Margin = new Padding(4, 5, 4, 5);
            btnBrowseVariantImage.Name = "btnBrowseVariantImage";
            btnBrowseVariantImage.Size = new Size(160, 46);
            btnBrowseVariantImage.TabIndex = 5;
            btnBrowseVariantImage.Text = "📁 Browse Image";
            btnBrowseVariantImage.UseVisualStyleBackColor = false;
            btnBrowseVariantImage.Click += BtnBrowseVariantImage_Click;
            btnBrowseVariantImage.MouseEnter += Button_MouseEnter;
            btnBrowseVariantImage.MouseLeave += Button_MouseLeave;
            // 
            // btnClearVariantImage
            // 
            btnClearVariantImage.BackColor = Color.FromArgb(244, 67, 54);
            btnClearVariantImage.Cursor = Cursors.Hand;
            btnClearVariantImage.FlatAppearance.BorderSize = 0;
            btnClearVariantImage.FlatAppearance.MouseDownBackColor = Color.FromArgb(200, 50, 40);
            btnClearVariantImage.FlatStyle = FlatStyle.Flat;
            btnClearVariantImage.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnClearVariantImage.ForeColor = Color.White;
            btnClearVariantImage.Location = new Point(320, 385);
            btnClearVariantImage.Margin = new Padding(4, 5, 4, 5);
            btnClearVariantImage.Name = "btnClearVariantImage";
            btnClearVariantImage.Size = new Size(160, 46);
            btnClearVariantImage.TabIndex = 6;
            btnClearVariantImage.Text = "❌ Clear Image";
            btnClearVariantImage.UseVisualStyleBackColor = false;
            btnClearVariantImage.Click += BtnClearVariantImage_Click;
            btnClearVariantImage.MouseEnter += Button_MouseEnter;
            btnClearVariantImage.MouseLeave += Button_MouseLeave;
            // 
            // lblVariantImageStatus
            // 
            lblVariantImageStatus.AutoSize = true;
            lblVariantImageStatus.Font = new Font("Segoe UI", 9F);
            lblVariantImageStatus.ForeColor = Color.FromArgb(100, 100, 100);
            lblVariantImageStatus.Location = new Point(320, 446);
            lblVariantImageStatus.Margin = new Padding(4, 0, 4, 0);
            lblVariantImageStatus.Name = "lblVariantImageStatus";
            lblVariantImageStatus.Size = new Size(75, 20);
            lblVariantImageStatus.TabIndex = 19;
            lblVariantImageStatus.Text = "No Image";
            // 
            // btnSaveVariant
            // 
            btnSaveVariant.BackColor = Color.FromArgb(76, 175, 80);
            btnSaveVariant.Cursor = Cursors.Hand;
            btnSaveVariant.FlatAppearance.BorderSize = 0;
            btnSaveVariant.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 150, 65);
            btnSaveVariant.FlatStyle = FlatStyle.Flat;
            btnSaveVariant.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSaveVariant.ForeColor = Color.White;
            btnSaveVariant.Location = new Point(933, 446);
            btnSaveVariant.Margin = new Padding(4, 5, 4, 5);
            btnSaveVariant.Name = "btnSaveVariant";
            btnSaveVariant.Size = new Size(160, 62);
            btnSaveVariant.TabIndex = 7;
            btnSaveVariant.Text = "Save Variant";
            btnSaveVariant.UseVisualStyleBackColor = false;
            btnSaveVariant.Click += BtnSaveVariant_Click;
            btnSaveVariant.MouseEnter += Button_MouseEnter;
            btnSaveVariant.MouseLeave += Button_MouseLeave;
            // 
            // btnCancelVariant
            // 
            btnCancelVariant.BackColor = Color.FromArgb(244, 67, 54);
            btnCancelVariant.Cursor = Cursors.Hand;
            btnCancelVariant.FlatAppearance.BorderSize = 0;
            btnCancelVariant.FlatAppearance.MouseDownBackColor = Color.FromArgb(200, 50, 40);
            btnCancelVariant.FlatStyle = FlatStyle.Flat;
            btnCancelVariant.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancelVariant.ForeColor = Color.White;
            btnCancelVariant.Location = new Point(1107, 446);
            btnCancelVariant.Margin = new Padding(4, 5, 4, 5);
            btnCancelVariant.Name = "btnCancelVariant";
            btnCancelVariant.Size = new Size(160, 62);
            btnCancelVariant.TabIndex = 8;
            btnCancelVariant.Text = "Cancel";
            btnCancelVariant.UseVisualStyleBackColor = false;
            btnCancelVariant.Click += BtnCancelVariant_Click;
            btnCancelVariant.MouseEnter += Button_MouseEnter;
            btnCancelVariant.MouseLeave += Button_MouseLeave;
            // 
            // txtSKU
            // 
            txtSKU.Font = new Font("Segoe UI", 10F);
            txtSKU.Location = new Point(173, 257);
            txtSKU.Margin = new Padding(4, 5, 4, 5);
            txtSKU.Name = "txtSKU";
            txtSKU.Size = new Size(199, 30);
            txtSKU.TabIndex = 4;
            // 
            // txtSalesPrice
            // 
            txtSalesPrice.Font = new Font("Segoe UI", 10F);
            txtSalesPrice.Location = new Point(173, 195);
            txtSalesPrice.Margin = new Padding(4, 5, 4, 5);
            txtSalesPrice.Name = "txtSalesPrice";
            txtSalesPrice.Size = new Size(199, 30);
            txtSalesPrice.TabIndex = 3;
            txtSalesPrice.Text = "0.00";
            // 
            // txtCostPrice
            // 
            txtCostPrice.Font = new Font("Segoe UI", 10F);
            txtCostPrice.Location = new Point(173, 134);
            txtCostPrice.Margin = new Padding(4, 5, 4, 5);
            txtCostPrice.Name = "txtCostPrice";
            txtCostPrice.Size = new Size(199, 30);
            txtCostPrice.TabIndex = 2;
            txtCostPrice.Text = "0.00";
            // 
            // cmbUOM
            // 
            cmbUOM.Font = new Font("Segoe UI", 10F);
            cmbUOM.FormattingEnabled = true;
            cmbUOM.Items.AddRange(new object[] { "Pcs", "Kg", "Ltr", "Mtr", "Box", "Pack", "Set", "Pair", "Dozen" });
            cmbUOM.Location = new Point(173, 72);
            cmbUOM.Margin = new Padding(4, 5, 4, 5);
            cmbUOM.Name = "cmbUOM";
            cmbUOM.Size = new Size(199, 31);
            cmbUOM.TabIndex = 1;
            // 
            // txtVariantName
            // 
            txtVariantName.Font = new Font("Segoe UI", 10F);
            txtVariantName.Location = new Point(173, 11);
            txtVariantName.Margin = new Padding(4, 5, 4, 5);
            txtVariantName.Name = "txtVariantName";
            txtVariantName.Size = new Size(332, 30);
            txtVariantName.TabIndex = 0;
            // 
            // lblVariantFormTitle
            // 
            lblVariantFormTitle.AutoSize = true;
            lblVariantFormTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblVariantFormTitle.ForeColor = Color.FromArgb(45, 166, 178);
            lblVariantFormTitle.Location = new Point(533, 15);
            lblVariantFormTitle.Margin = new Padding(4, 0, 4, 0);
            lblVariantFormTitle.Name = "lblVariantFormTitle";
            lblVariantFormTitle.Size = new Size(123, 28);
            lblVariantFormTitle.TabIndex = 0;
            lblVariantFormTitle.Text = "Add Variant";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(245, 245, 245);
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lblProductVariants);
            panel1.Controls.Add(lblTotalVariants);
            panel1.Controls.Add(txtSearchVariants);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(btnRefreshVariants);
            panel1.Controls.Add(btnDeactivateVariant);
            panel1.Controls.Add(btnActivateVariant);
            panel1.Controls.Add(btnDeleteVariant);
            panel1.Controls.Add(btnEditVariant);
            panel1.Controls.Add(btnAddVariant);
            panel1.Controls.Add(dgvVariants);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(1279, 537);
            panel1.TabIndex = 0;
            // 
            // lblProductVariants
            // 
            lblProductVariants.AutoSize = true;
            lblProductVariants.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblProductVariants.ForeColor = Color.FromArgb(45, 166, 178);
            lblProductVariants.Location = new Point(27, 31);
            lblProductVariants.Margin = new Padding(4, 0, 4, 0);
            lblProductVariants.Name = "lblProductVariants";
            lblProductVariants.Size = new Size(226, 23);
            lblProductVariants.TabIndex = 11;
            lblProductVariants.Text = "Variants for: Laptop (ID: 1)";
            // 
            // lblTotalVariants
            // 
            lblTotalVariants.AutoSize = true;
            lblTotalVariants.Font = new Font("Segoe UI", 9F);
            lblTotalVariants.ForeColor = Color.FromArgb(100, 100, 100);
            lblTotalVariants.Location = new Point(310, 69);
            lblTotalVariants.Margin = new Padding(4, 0, 4, 0);
            lblTotalVariants.Name = "lblTotalVariants";
            lblTotalVariants.Size = new Size(113, 20);
            lblTotalVariants.TabIndex = 10;
            lblTotalVariants.Text = "Total Variants: 0";
            // 
            // txtSearchVariants
            // 
            txtSearchVariants.Font = new Font("Segoe UI", 9F);
            txtSearchVariants.Location = new Point(667, 69);
            txtSearchVariants.Margin = new Padding(4, 5, 4, 5);
            txtSearchVariants.Name = "txtSearchVariants";
            txtSearchVariants.Size = new Size(265, 27);
            txtSearchVariants.TabIndex = 9;
            txtSearchVariants.TextChanged += TxtSearchVariants_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F);
            label8.ForeColor = Color.FromArgb(100, 100, 100);
            label8.Location = new Point(587, 74);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(56, 20);
            label8.TabIndex = 8;
            label8.Text = "Search:";
            // 
            // btnRefreshVariants
            // 
            btnRefreshVariants.BackColor = Color.FromArgb(45, 166, 178);
            btnRefreshVariants.Cursor = Cursors.Hand;
            btnRefreshVariants.FlatAppearance.BorderSize = 0;
            btnRefreshVariants.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 140, 152);
            btnRefreshVariants.FlatStyle = FlatStyle.Flat;
            btnRefreshVariants.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRefreshVariants.ForeColor = Color.White;
            btnRefreshVariants.Location = new Point(960, 69);
            btnRefreshVariants.Margin = new Padding(4, 5, 4, 5);
            btnRefreshVariants.Name = "btnRefreshVariants";
            btnRefreshVariants.Size = new Size(133, 35);
            btnRefreshVariants.TabIndex = 7;
            btnRefreshVariants.Text = "🔄 Refresh";
            btnRefreshVariants.UseVisualStyleBackColor = false;
            btnRefreshVariants.Click += BtnRefresh_Click;
            btnRefreshVariants.MouseEnter += Button_MouseEnter;
            btnRefreshVariants.MouseLeave += Button_MouseLeave;
            // 
            // btnDeactivateVariant
            // 
            btnDeactivateVariant.BackColor = Color.FromArgb(244, 67, 54);
            btnDeactivateVariant.Cursor = Cursors.Hand;
            btnDeactivateVariant.Enabled = false;
            btnDeactivateVariant.FlatAppearance.BorderSize = 0;
            btnDeactivateVariant.FlatAppearance.MouseDownBackColor = Color.FromArgb(200, 50, 40);
            btnDeactivateVariant.FlatStyle = FlatStyle.Flat;
            btnDeactivateVariant.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDeactivateVariant.ForeColor = Color.White;
            btnDeactivateVariant.Location = new Point(453, 69);
            btnDeactivateVariant.Margin = new Padding(4, 5, 4, 5);
            btnDeactivateVariant.Name = "btnDeactivateVariant";
            btnDeactivateVariant.Size = new Size(120, 35);
            btnDeactivateVariant.TabIndex = 6;
            btnDeactivateVariant.Text = "⛔ Deactivate";
            btnDeactivateVariant.UseVisualStyleBackColor = false;
            btnDeactivateVariant.MouseEnter += Button_MouseEnter;
            btnDeactivateVariant.MouseLeave += Button_MouseLeave;
            // 
            // btnActivateVariant
            // 
            btnActivateVariant.BackColor = Color.FromArgb(76, 175, 80);
            btnActivateVariant.Cursor = Cursors.Hand;
            btnActivateVariant.Enabled = false;
            btnActivateVariant.FlatAppearance.BorderSize = 0;
            btnActivateVariant.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 150, 65);
            btnActivateVariant.FlatStyle = FlatStyle.Flat;
            btnActivateVariant.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnActivateVariant.ForeColor = Color.White;
            btnActivateVariant.Location = new Point(320, 69);
            btnActivateVariant.Margin = new Padding(4, 5, 4, 5);
            btnActivateVariant.Name = "btnActivateVariant";
            btnActivateVariant.Size = new Size(120, 35);
            btnActivateVariant.TabIndex = 5;
            btnActivateVariant.Text = "✅ Activate";
            btnActivateVariant.UseVisualStyleBackColor = false;
            btnActivateVariant.MouseEnter += Button_MouseEnter;
            btnActivateVariant.MouseLeave += Button_MouseLeave;
            // 
            // btnDeleteVariant
            // 
            btnDeleteVariant.BackColor = Color.FromArgb(244, 67, 54);
            btnDeleteVariant.Cursor = Cursors.Hand;
            btnDeleteVariant.Enabled = false;
            btnDeleteVariant.FlatAppearance.BorderSize = 0;
            btnDeleteVariant.FlatAppearance.MouseDownBackColor = Color.FromArgb(200, 50, 40);
            btnDeleteVariant.FlatStyle = FlatStyle.Flat;
            btnDeleteVariant.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDeleteVariant.ForeColor = Color.White;
            btnDeleteVariant.Location = new Point(187, 69);
            btnDeleteVariant.Margin = new Padding(4, 5, 4, 5);
            btnDeleteVariant.Name = "btnDeleteVariant";
            btnDeleteVariant.Size = new Size(120, 35);
            btnDeleteVariant.TabIndex = 4;
            btnDeleteVariant.Text = "🗑️ Delete";
            btnDeleteVariant.UseVisualStyleBackColor = false;
            btnDeleteVariant.Click += BtnDeleteVariant_Click;
            btnDeleteVariant.MouseEnter += Button_MouseEnter;
            btnDeleteVariant.MouseLeave += Button_MouseLeave;
            // 
            // btnEditVariant
            // 
            btnEditVariant.BackColor = Color.FromArgb(45, 166, 178);
            btnEditVariant.Cursor = Cursors.Hand;
            btnEditVariant.Enabled = false;
            btnEditVariant.FlatAppearance.BorderSize = 0;
            btnEditVariant.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 140, 152);
            btnEditVariant.FlatStyle = FlatStyle.Flat;
            btnEditVariant.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEditVariant.ForeColor = Color.White;
            btnEditVariant.Location = new Point(93, 69);
            btnEditVariant.Margin = new Padding(4, 5, 4, 5);
            btnEditVariant.Name = "btnEditVariant";
            btnEditVariant.Size = new Size(80, 35);
            btnEditVariant.TabIndex = 3;
            btnEditVariant.Text = "✏️ Edit";
            btnEditVariant.UseVisualStyleBackColor = false;
            btnEditVariant.Click += BtnEditVariant_Click;
            btnEditVariant.MouseEnter += Button_MouseEnter;
            btnEditVariant.MouseLeave += Button_MouseLeave;
            // 
            // btnAddVariant
            // 
            btnAddVariant.BackColor = Color.FromArgb(45, 166, 178);
            btnAddVariant.Cursor = Cursors.Hand;
            btnAddVariant.FlatAppearance.BorderSize = 0;
            btnAddVariant.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 140, 152);
            btnAddVariant.FlatStyle = FlatStyle.Flat;
            btnAddVariant.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAddVariant.ForeColor = Color.White;
            btnAddVariant.Location = new Point(27, 69);
            btnAddVariant.Margin = new Padding(4, 5, 4, 5);
            btnAddVariant.Name = "btnAddVariant";
            btnAddVariant.Size = new Size(53, 35);
            btnAddVariant.TabIndex = 2;
            btnAddVariant.Text = "➕";
            btnAddVariant.UseVisualStyleBackColor = false;
            btnAddVariant.Click += BtnAddVariant_Click;
            btnAddVariant.MouseEnter += Button_MouseEnter;
            btnAddVariant.MouseLeave += Button_MouseLeave;
            // 
            // dgvVariants
            // 
            dgvVariants.AllowUserToAddRows = false;
            dgvVariants.AllowUserToDeleteRows = false;
            dgvVariants.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVariants.BackgroundColor = Color.FromArgb(245, 245, 245);
            dgvVariants.BorderStyle = BorderStyle.None;
            dgvVariants.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVariants.Location = new Point(27, 123);
            dgvVariants.Margin = new Padding(4, 5, 4, 5);
            dgvVariants.Name = "dgvVariants";
            dgvVariants.ReadOnly = true;
            dgvVariants.RowHeadersVisible = false;
            dgvVariants.RowHeadersWidth = 51;
            dgvVariants.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVariants.Size = new Size(1227, 385);
            dgvVariants.TabIndex = 0;
            dgvVariants.CellMouseEnter += DgvVariants_CellMouseEnter;
            dgvVariants.CellMouseLeave += DgvVariants_CellMouseLeave;
            dgvVariants.SelectionChanged += DgvVariants_SelectionChanged;
            // 
            // pnlControls
            // 
            pnlControls.BackColor = Color.Transparent;
            pnlControls.Controls.Add(txtSearch);
            pnlControls.Controls.Add(label6);
            pnlControls.Controls.Add(btnRefresh);
            pnlControls.Controls.Add(btnDelete);
            pnlControls.Controls.Add(btnEdit);
            pnlControls.Controls.Add(btnAddNew);
            pnlControls.Dock = DockStyle.Top;
            pnlControls.Location = new Point(0, 0);
            pnlControls.Margin = new Padding(4, 5, 4, 5);
            pnlControls.Name = "pnlControls";
            pnlControls.Size = new Size(1333, 77);
            pnlControls.TabIndex = 0;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(667, 15);
            txtSearch.Margin = new Padding(4, 5, 4, 5);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(332, 30);
            txtSearch.TabIndex = 5;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F);
            label6.ForeColor = Color.FromArgb(100, 100, 100);
            label6.Location = new Point(573, 20);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(65, 23);
            label6.TabIndex = 4;
            label6.Text = "Search:";
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(45, 166, 178);
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 140, 152);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(400, 15);
            btnRefresh.Margin = new Padding(4, 5, 4, 5);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(160, 46);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "🔄 Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += BtnRefresh_Click;
            btnRefresh.MouseEnter += Button_MouseEnter;
            btnRefresh.MouseLeave += Button_MouseLeave;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(244, 67, 54);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.Enabled = false;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatAppearance.MouseDownBackColor = Color.FromArgb(200, 50, 40);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(267, 15);
            btnDelete.Margin = new Padding(4, 5, 4, 5);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(120, 46);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "🗑️ Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += BtnDelete_Click;
            btnDelete.MouseEnter += Button_MouseEnter;
            btnDelete.MouseLeave += Button_MouseLeave;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(45, 166, 178);
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.Enabled = false;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 140, 152);
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(133, 15);
            btnEdit.Margin = new Padding(4, 5, 4, 5);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(120, 46);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "✏️ Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += BtnEdit_Click;
            btnEdit.MouseEnter += Button_MouseEnter;
            btnEdit.MouseLeave += Button_MouseLeave;
            // 
            // btnAddNew
            // 
            btnAddNew.BackColor = Color.FromArgb(45, 166, 178);
            btnAddNew.Cursor = Cursors.Hand;
            btnAddNew.FlatAppearance.BorderSize = 0;
            btnAddNew.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 140, 152);
            btnAddNew.FlatStyle = FlatStyle.Flat;
            btnAddNew.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAddNew.ForeColor = Color.White;
            btnAddNew.Location = new Point(27, 15);
            btnAddNew.Margin = new Padding(4, 5, 4, 5);
            btnAddNew.Name = "btnAddNew";
            btnAddNew.Size = new Size(93, 46);
            btnAddNew.TabIndex = 0;
            btnAddNew.Text = "➕ Add";
            btnAddNew.UseVisualStyleBackColor = false;
            btnAddNew.Click += BtnAddNew_Click;
            btnAddNew.MouseEnter += Button_MouseEnter;
            btnAddNew.MouseLeave += Button_MouseLeave;
            // 
            // timerFadeIn
            // 
            timerFadeIn.Interval = 20;
            timerFadeIn.Tick += TimerFadeIn_Tick;
            // 
            // ProductMaster
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(31, 33, 33);
            ClientSize = new Size(1333, 1231);
            Controls.Add(pnlMain);
            Controls.Add(pnlTitleBar);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "ProductMaster";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Product Master";
            Load += ProductMaster_Load;
            pnlTitleBar.ResumeLayout(false);
            pnlTitleBar.PerformLayout();
            pnlMain.ResumeLayout(false);
            pnlEdit.ResumeLayout(false);
            pnlEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picProductImage).EndInit();
            pnlList.ResumeLayout(false);
            pnlList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            pnlVariantContainer.ResumeLayout(false);
            pnlVariantEdit.ResumeLayout(false);
            pnlVariantEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picVariantImage).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVariants).EndInit();
            pnlControls.ResumeLayout(false);
            pnlControls.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitleBar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel pnlList;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Panel pnlEdit;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTaxRate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblTotalProducts;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer timerFadeIn;
        private System.Windows.Forms.PictureBox picProductImage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnBrowseImage;
        private System.Windows.Forms.Button btnClearImage;
        private System.Windows.Forms.Label lblImageStatus;
        private System.Windows.Forms.Panel pnlVariantContainer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvVariants;
        private System.Windows.Forms.Button btnAddVariant;
        private System.Windows.Forms.Button btnEditVariant;
        private System.Windows.Forms.Button btnDeleteVariant;
        private System.Windows.Forms.Button btnRefreshVariants;
        private System.Windows.Forms.Button btnDeactivateVariant;
        private System.Windows.Forms.Button btnActivateVariant;
        private System.Windows.Forms.TextBox txtSearchVariants;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTotalVariants;
        private System.Windows.Forms.Label lblProductVariants;
        private System.Windows.Forms.Panel pnlVariantEdit;
        private System.Windows.Forms.Label lblVariantFormTitle;
        private System.Windows.Forms.TextBox txtVariantName;
        private System.Windows.Forms.ComboBox cmbUOM;
        private System.Windows.Forms.TextBox txtCostPrice;
        private System.Windows.Forms.TextBox txtSalesPrice;
        private System.Windows.Forms.TextBox txtSKU;
        private System.Windows.Forms.Button btnSaveVariant;
        private System.Windows.Forms.Button btnCancelVariant;
        private System.Windows.Forms.Label lblVariantImageStatus;
        private System.Windows.Forms.Button btnClearVariantImage;
        private System.Windows.Forms.Button btnBrowseVariantImage;
        private System.Windows.Forms.PictureBox picVariantImage;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
    }
}