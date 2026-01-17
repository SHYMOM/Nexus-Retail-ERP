namespace Nexus_Retail_ERP.Forms
{
    partial class EmployeeManagementForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Label();
            this.pnlList = new System.Windows.Forms.Panel();
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnAddEmployee = new System.Windows.Forms.Button();
            this.pnlEditor = new System.Windows.Forms.Panel();
            this.lblEditorTitle = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.cmbBranch = new System.Windows.Forms.ComboBox();
            this.lblBranch = new System.Windows.Forms.Label();
            this.txtSalary = new System.Windows.Forms.TextBox();
            this.lblSalary = new System.Windows.Forms.Label();
            this.tglActive = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();

            this.pnlList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            this.pnlEditor.SuspendLayout();
            this.SuspendLayout();

            // Title
            this.lblTitle.Text = "Employee Management";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.AutoSize = true;

            // Close
            this.btnClose.Text = "X";
            this.btnClose.Location = new System.Drawing.Point(1050, 20);
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.LightGray;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.AutoSize = true;

            // --- LEFT PANEL (LIST) ---
            this.pnlList.Location = new System.Drawing.Point(25, 80);
            this.pnlList.Size = new System.Drawing.Size(700, 540);
            this.pnlList.Controls.Add(this.txtSearch);
            this.pnlList.Controls.Add(this.btnSearch);
            this.pnlList.Controls.Add(this.btnAddEmployee);
            this.pnlList.Controls.Add(this.dgvEmployees);

            this.txtSearch.Location = new System.Drawing.Point(15, 15);
            this.txtSearch.Size = new System.Drawing.Size(300, 25);
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.PlaceholderText = "Search by Name, Role or Branch...";

            this.btnSearch.Text = "Search";
            this.btnSearch.Location = new System.Drawing.Point(325, 13);
            this.btnSearch.Size = new System.Drawing.Size(90, 30);

            this.btnAddEmployee.Text = "+ New Employee";
            this.btnAddEmployee.Location = new System.Drawing.Point(530, 13);
            this.btnAddEmployee.Size = new System.Drawing.Size(150, 30);

            this.dgvEmployees.Location = new System.Drawing.Point(15, 60);
            this.dgvEmployees.Size = new System.Drawing.Size(665, 460);

            // --- RIGHT PANEL (EDITOR) ---
            this.pnlEditor.Location = new System.Drawing.Point(750, 80);
            this.pnlEditor.Size = new System.Drawing.Size(320, 540);
            this.pnlEditor.Enabled = false; // Disabled by default

            this.pnlEditor.Controls.Add(this.lblEditorTitle);
            this.pnlEditor.Controls.Add(this.lblName);
            this.pnlEditor.Controls.Add(this.txtName);
            this.pnlEditor.Controls.Add(this.lblPhone);
            this.pnlEditor.Controls.Add(this.txtPhone);
            this.pnlEditor.Controls.Add(this.lblRole);
            this.pnlEditor.Controls.Add(this.cmbRole);
            this.pnlEditor.Controls.Add(this.lblBranch);
            this.pnlEditor.Controls.Add(this.cmbBranch);
            this.pnlEditor.Controls.Add(this.lblSalary);
            this.pnlEditor.Controls.Add(this.txtSalary);
            this.pnlEditor.Controls.Add(this.tglActive);
            this.pnlEditor.Controls.Add(this.btnSave);

            this.lblEditorTitle.Text = "Employee Details";
            this.lblEditorTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblEditorTitle.ForeColor = System.Drawing.Color.FromArgb(0, 180, 216);
            this.lblEditorTitle.Location = new System.Drawing.Point(15, 15);
            this.lblEditorTitle.AutoSize = true;

            // Name (Read Only in this view usually, but editable here)
            this.lblName.Text = "Full Name";
            this.lblName.Location = new System.Drawing.Point(15, 60);
            this.lblName.AutoSize = true;
            this.txtName.Location = new System.Drawing.Point(15, 80);
            this.txtName.Size = new System.Drawing.Size(280, 25);
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtName.ReadOnly = true; // Names are usually fixed or edited in full profile

            // Phone
            this.lblPhone.Text = "Phone";
            this.lblPhone.Location = new System.Drawing.Point(15, 120);
            this.lblPhone.AutoSize = true;
            this.txtPhone.Location = new System.Drawing.Point(15, 140);
            this.txtPhone.Size = new System.Drawing.Size(280, 25);
            this.txtPhone.ReadOnly = true;

            // Role
            this.lblRole.Text = "System Role";
            this.lblRole.Location = new System.Drawing.Point(15, 180);
            this.lblRole.AutoSize = true;
            this.cmbRole.Location = new System.Drawing.Point(15, 200);
            this.cmbRole.Size = new System.Drawing.Size(280, 25);
            this.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // Branch
            this.lblBranch.Text = "Assigned Branch";
            this.lblBranch.Location = new System.Drawing.Point(15, 240);
            this.lblBranch.AutoSize = true;
            this.cmbBranch.Location = new System.Drawing.Point(15, 260);
            this.cmbBranch.Size = new System.Drawing.Size(280, 25);
            this.cmbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // Salary
            this.lblSalary.Text = "Current Salary";
            this.lblSalary.Location = new System.Drawing.Point(15, 300);
            this.lblSalary.AutoSize = true;
            this.txtSalary.Location = new System.Drawing.Point(15, 320);
            this.txtSalary.Size = new System.Drawing.Size(280, 25);

            // Active Toggle
            this.tglActive.Text = "Account is Active";
            this.tglActive.Location = new System.Drawing.Point(15, 370);
            this.tglActive.AutoSize = true;
            this.tglActive.Font = new System.Drawing.Font("Segoe UI", 10F);

            // Save Button
            this.btnSave.Text = "Update Profile";
            this.btnSave.Location = new System.Drawing.Point(15, 420);
            this.btnSave.Size = new System.Drawing.Size(280, 45);

            // Setup
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.pnlEditor);
            this.Controls.Add(this.pnlList);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EmployeeManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee Manager";

            this.pnlList.ResumeLayout(false);
            this.pnlList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
            this.pnlEditor.ResumeLayout(false);
            this.pnlEditor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label btnClose;
        private System.Windows.Forms.Panel pnlList;
        private System.Windows.Forms.DataGridView dgvEmployees;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAddEmployee;
        private System.Windows.Forms.Panel pnlEditor;
        private System.Windows.Forms.Label lblEditorTitle;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ComboBox cmbBranch;
        private System.Windows.Forms.Label lblBranch;
        private System.Windows.Forms.TextBox txtSalary;
        private System.Windows.Forms.Label lblSalary;
        private System.Windows.Forms.CheckBox tglActive;
        private System.Windows.Forms.Button btnSave;
    }
}