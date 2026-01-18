namespace Nexus_Retail_ERP.Forms
{
    partial class InventoryManagementForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Label();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.cmbBranchFilter = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvInventory = new System.Windows.Forms.DataGridView();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.tabControlActions = new System.Windows.Forms.TabControl();
            this.tabManage = new System.Windows.Forms.TabPage();
            this.pnlManage = new System.Windows.Forms.Panel();
            this.lblSelectedName = new System.Windows.Forms.Label();
            this.lblCurrentStock = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.btnAddStock = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLimit = new System.Windows.Forms.TextBox();
            this.btnSetLimit = new System.Windows.Forms.Button();
            this.tabRegister = new System.Windows.Forms.TabPage();
            this.lblRegTitle = new System.Windows.Forms.Label();
            this.lblFilterTitle = new System.Windows.Forms.Label();
            this.txtRegisterFilter = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbNewProducts = new System.Windows.Forms.ComboBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            this.pnlRight.SuspendLayout();
            this.tabControlActions.SuspendLayout();
            this.tabManage.SuspendLayout();
            this.pnlManage.SuspendLayout();
            this.tabRegister.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(285, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Inventory Management";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.AutoSize = true;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnClose.ForeColor = System.Drawing.Color.LightGray;
            this.btnClose.Location = new System.Drawing.Point(1100, 15);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(24, 25);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "X";
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.cmbBranchFilter);
            this.pnlTop.Controls.Add(this.txtSearch);
            this.pnlTop.Controls.Add(this.btnSearch);
            this.pnlTop.Location = new System.Drawing.Point(25, 70);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1100, 50);
            this.pnlTop.TabIndex = 2;
            // 
            // cmbBranchFilter
            // 
            this.cmbBranchFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBranchFilter.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbBranchFilter.Location = new System.Drawing.Point(0, 10);
            this.cmbBranchFilter.Name = "cmbBranchFilter";
            this.cmbBranchFilter.Size = new System.Drawing.Size(200, 25);
            this.cmbBranchFilter.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSearch.Location = new System.Drawing.Point(220, 10);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "Search Product Name...";
            this.txtSearch.Size = new System.Drawing.Size(300, 25);
            this.txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(0, 180, 216);
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(530, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(80, 30);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // dgvInventory
            // 
            this.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventory.Location = new System.Drawing.Point(25, 130);
            this.dgvInventory.Name = "dgvInventory";
            this.dgvInventory.Size = new System.Drawing.Size(750, 540);
            this.dgvInventory.TabIndex = 3;
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.White;
            this.pnlRight.Controls.Add(this.tabControlActions);
            this.pnlRight.Location = new System.Drawing.Point(790, 130);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(335, 540);
            this.pnlRight.TabIndex = 4;
            // 
            // tabControlActions
            // 
            this.tabControlActions.Controls.Add(this.tabManage);
            this.tabControlActions.Controls.Add(this.tabRegister);
            this.tabControlActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlActions.Location = new System.Drawing.Point(0, 0);
            this.tabControlActions.Name = "tabControlActions";
            this.tabControlActions.SelectedIndex = 0;
            this.tabControlActions.Size = new System.Drawing.Size(335, 540);
            this.tabControlActions.TabIndex = 0;
            // 
            // tabManage
            // 
            this.tabManage.BackColor = System.Drawing.Color.White;
            this.tabManage.Controls.Add(this.pnlManage);
            this.tabManage.Location = new System.Drawing.Point(4, 24);
            this.tabManage.Name = "tabManage";
            this.tabManage.Padding = new System.Windows.Forms.Padding(15);
            this.tabManage.Size = new System.Drawing.Size(327, 512);
            this.tabManage.TabIndex = 0;
            this.tabManage.Text = "Manage Item";
            // 
            // pnlManage
            // 
            this.pnlManage.Controls.Add(this.lblSelectedName);
            this.pnlManage.Controls.Add(this.lblCurrentStock);
            this.pnlManage.Controls.Add(this.label1);
            this.pnlManage.Controls.Add(this.txtQuantity);
            this.pnlManage.Controls.Add(this.txtReason);
            this.pnlManage.Controls.Add(this.btnAddStock);
            this.pnlManage.Controls.Add(this.label2);
            this.pnlManage.Controls.Add(this.txtLimit);
            this.pnlManage.Controls.Add(this.btnSetLimit);
            this.pnlManage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlManage.Enabled = false;
            this.pnlManage.Location = new System.Drawing.Point(15, 15);
            this.pnlManage.Name = "pnlManage";
            this.pnlManage.Size = new System.Drawing.Size(297, 482);
            this.pnlManage.TabIndex = 0;
            // 
            // lblSelectedName
            // 
            this.lblSelectedName.AutoSize = true;
            this.lblSelectedName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSelectedName.Location = new System.Drawing.Point(10, 10);
            this.lblSelectedName.Name = "lblSelectedName";
            this.lblSelectedName.Size = new System.Drawing.Size(193, 20);
            this.lblSelectedName.TabIndex = 0;
            this.lblSelectedName.Text = "Select an item from grid...";
            // 
            // lblCurrentStock
            // 
            this.lblCurrentStock.AutoSize = true;
            this.lblCurrentStock.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCurrentStock.ForeColor = System.Drawing.Color.FromArgb(0, 180, 216);
            this.lblCurrentStock.Location = new System.Drawing.Point(10, 40);
            this.lblCurrentStock.Name = "lblCurrentStock";
            this.lblCurrentStock.Size = new System.Drawing.Size(56, 45);
            this.lblCurrentStock.TabIndex = 1;
            this.lblCurrentStock.Text = "---";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Adjust Stock (+/-)";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtQuantity.Location = new System.Drawing.Point(10, 120);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.PlaceholderText = "Enter Qty (e.g. 10 or -5)";
            this.txtQuantity.Size = new System.Drawing.Size(280, 27);
            this.txtQuantity.TabIndex = 3;
            // 
            // txtReason
            // 
            this.txtReason.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtReason.Location = new System.Drawing.Point(10, 155);
            this.txtReason.Name = "txtReason";
            this.txtReason.PlaceholderText = "Reason (e.g. Restock)";
            this.txtReason.Size = new System.Drawing.Size(280, 27);
            this.txtReason.TabIndex = 4;
            // 
            // btnAddStock
            // 
            this.btnAddStock.BackColor = System.Drawing.Color.FromArgb(0, 180, 216);
            this.btnAddStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddStock.ForeColor = System.Drawing.Color.White;
            this.btnAddStock.Location = new System.Drawing.Point(10, 190);
            this.btnAddStock.Name = "btnAddStock";
            this.btnAddStock.Size = new System.Drawing.Size(280, 40);
            this.btnAddStock.TabIndex = 5;
            this.btnAddStock.Text = "Update Stock";
            this.btnAddStock.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 260);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Low Stock Alert Limit";
            // 
            // txtLimit
            // 
            this.txtLimit.Location = new System.Drawing.Point(10, 280);
            this.txtLimit.Name = "txtLimit";
            this.txtLimit.Size = new System.Drawing.Size(180, 23);
            this.txtLimit.TabIndex = 7;
            // 
            // btnSetLimit
            // 
            this.btnSetLimit.BackColor = System.Drawing.Color.DimGray;
            this.btnSetLimit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetLimit.ForeColor = System.Drawing.Color.White;
            this.btnSetLimit.Location = new System.Drawing.Point(200, 279);
            this.btnSetLimit.Name = "btnSetLimit";
            this.btnSetLimit.Size = new System.Drawing.Size(90, 27);
            this.btnSetLimit.TabIndex = 8;
            this.btnSetLimit.Text = "Set Limit";
            this.btnSetLimit.UseVisualStyleBackColor = false;
            // 
            // tabRegister
            // 
            this.tabRegister.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabRegister.Controls.Add(this.lblRegTitle);
            this.tabRegister.Controls.Add(this.lblFilterTitle);
            this.tabRegister.Controls.Add(this.txtRegisterFilter);
            this.tabRegister.Controls.Add(this.label3);
            this.tabRegister.Controls.Add(this.cmbNewProducts);
            this.tabRegister.Controls.Add(this.btnRegister);
            this.tabRegister.Location = new System.Drawing.Point(4, 24);
            this.tabRegister.Name = "tabRegister";
            this.tabRegister.Padding = new System.Windows.Forms.Padding(3);
            this.tabRegister.Size = new System.Drawing.Size(327, 512);
            this.tabRegister.TabIndex = 1;
            this.tabRegister.Text = "Register New";
            // 
            // lblRegTitle
            // 
            this.lblRegTitle.AutoSize = true;
            this.lblRegTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRegTitle.Location = new System.Drawing.Point(15, 20);
            this.lblRegTitle.Name = "lblRegTitle";
            this.lblRegTitle.Size = new System.Drawing.Size(188, 21);
            this.lblRegTitle.TabIndex = 0;
            this.lblRegTitle.Text = "Register Item to Branch";
            // 
            // lblFilterTitle
            // 
            this.lblFilterTitle.AutoSize = true;
            this.lblFilterTitle.ForeColor = System.Drawing.Color.DimGray;
            this.lblFilterTitle.Location = new System.Drawing.Point(15, 60);
            this.lblFilterTitle.Name = "lblFilterTitle";
            this.lblFilterTitle.Size = new System.Drawing.Size(130, 15);
            this.lblFilterTitle.TabIndex = 4;
            this.lblFilterTitle.Text = "1. Search Product Name:";
            // 
            // txtRegisterFilter
            // 
            this.txtRegisterFilter.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtRegisterFilter.Location = new System.Drawing.Point(15, 80);
            this.txtRegisterFilter.Name = "txtRegisterFilter";
            this.txtRegisterFilter.PlaceholderText = "Type to filter list...";
            this.txtRegisterFilter.Size = new System.Drawing.Size(280, 25);
            this.txtRegisterFilter.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(15, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "2. Select from list:";
            // 
            // cmbNewProducts
            // 
            this.cmbNewProducts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNewProducts.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbNewProducts.Location = new System.Drawing.Point(15, 140);
            this.cmbNewProducts.Name = "cmbNewProducts";
            this.cmbNewProducts.Size = new System.Drawing.Size(280, 25);
            this.cmbNewProducts.TabIndex = 2;
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.SeaGreen;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRegister.Location = new System.Drawing.Point(15, 190);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(280, 45);
            this.btnRegister.TabIndex = 3;
            this.btnRegister.Text = "ADD TO INVENTORY";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            // 
            // InventoryManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 700);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.dgvInventory);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InventoryManagementForm";
            this.Text = "InventoryManagementForm";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.tabControlActions.ResumeLayout(false);
            this.tabManage.ResumeLayout(false);
            this.pnlManage.ResumeLayout(false);
            this.pnlManage.PerformLayout();
            this.tabRegister.ResumeLayout(false);
            this.tabRegister.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label btnClose;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.ComboBox cmbBranchFilter;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvInventory;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.TabControl tabControlActions;
        private System.Windows.Forms.TabPage tabManage;
        private System.Windows.Forms.Panel pnlManage;
        private System.Windows.Forms.Label lblSelectedName;
        private System.Windows.Forms.Label lblCurrentStock;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Button btnAddStock;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLimit;
        private System.Windows.Forms.Button btnSetLimit;
        private System.Windows.Forms.TabPage tabRegister;
        private System.Windows.Forms.Label lblRegTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbNewProducts;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label lblFilterTitle;
        private System.Windows.Forms.TextBox txtRegisterFilter;
    }
}