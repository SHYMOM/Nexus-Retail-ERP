namespace Nexus_Retail_ERP.Forms
{
    partial class EmployeeRegistrationPage
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
            btnBack = new Label();
            lblTitle = new Label();
            lblSubtitle = new Label();
            btnClose = new Label();
            pnlHeaderLine = new Panel();
            pnlCard = new Panel();
            consoleLBL = new Label();
            lblPhoneStatus = new Label();
            lblUserStatus = new Label();
            chkShowPass = new CheckBox();
            btnReset = new Button();
            btnSave = new Button();
            btnUpload = new Button();
            lblImage = new Label();
            picProfile = new PictureBox();
            lblUser = new Label();
            pnlUser = new Panel();
            txtUsername = new TextBox();
            lblPass = new Label();
            pnlPass = new Panel();
            txtPassword = new TextBox();
            lblRole = new Label();
            pnlRole = new Panel();
            cmbRole = new ComboBox();
            lblBranch = new Label();
            pnlBranch = new Panel();
            cmbBranch = new ComboBox();
            lblName = new Label();
            pnlName = new Panel();
            txtName = new TextBox();
            lblPhone = new Label();
            pnlPhone = new Panel();
            txtPhone = new TextBox();
            lblDOB = new Label();
            pnlDOB = new Panel();
            dtpDOB = new DateTimePicker();
            lblSalary = new Label();
            pnlSalary = new Panel();
            txtSalary = new TextBox();
            lblAddress = new Label();
            pnlAddress = new Panel();
            txtAddress = new TextBox();
            pnlCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picProfile).BeginInit();
            pnlUser.SuspendLayout();
            pnlPass.SuspendLayout();
            pnlRole.SuspendLayout();
            pnlBranch.SuspendLayout();
            pnlName.SuspendLayout();
            pnlPhone.SuspendLayout();
            pnlDOB.SuspendLayout();
            pnlSalary.SuspendLayout();
            pnlAddress.SuspendLayout();
            SuspendLayout();
            // 
            // btnBack
            // 
            btnBack.AutoSize = true;
            btnBack.Location = new Point(31, 31);
            btnBack.Margin = new Padding(4, 0, 4, 0);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(22, 20);
            btnBack.TabIndex = 99;
            btnBack.Text = "←";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(88, 28);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(448, 54);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Employee Registration";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 11F);
            lblSubtitle.ForeColor = Color.FromArgb(180, 180, 185);
            lblSubtitle.Location = new Point(94, 88);
            lblSubtitle.Margin = new Padding(4, 0, 4, 0);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(336, 25);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Create and assign staff access securely";
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.AutoSize = true;
            btnClose.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            btnClose.ForeColor = Color.FromArgb(160, 160, 165);
            btnClose.Location = new Point(1444, 25);
            btnClose.Margin = new Padding(4, 0, 4, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(36, 37);
            btnClose.TabIndex = 2;
            btnClose.Text = "×";
            // 
            // pnlHeaderLine
            // 
            pnlHeaderLine.BackColor = Color.FromArgb(0, 180, 216);
            pnlHeaderLine.Location = new Point(94, 131);
            pnlHeaderLine.Margin = new Padding(4);
            pnlHeaderLine.Name = "pnlHeaderLine";
            pnlHeaderLine.Size = new Size(1312, 4);
            pnlHeaderLine.TabIndex = 3;
            // 
            // pnlCard
            // 
            pnlCard.BackColor = Color.White;
            pnlCard.Controls.Add(consoleLBL);
            pnlCard.Controls.Add(lblPhoneStatus);
            pnlCard.Controls.Add(lblUserStatus);
            pnlCard.Controls.Add(chkShowPass);
            pnlCard.Controls.Add(btnReset);
            pnlCard.Controls.Add(btnSave);
            pnlCard.Controls.Add(btnUpload);
            pnlCard.Controls.Add(lblImage);
            pnlCard.Controls.Add(picProfile);
            pnlCard.Controls.Add(lblUser);
            pnlCard.Controls.Add(pnlUser);
            pnlCard.Controls.Add(lblPass);
            pnlCard.Controls.Add(pnlPass);
            pnlCard.Controls.Add(lblRole);
            pnlCard.Controls.Add(pnlRole);
            pnlCard.Controls.Add(lblBranch);
            pnlCard.Controls.Add(pnlBranch);
            pnlCard.Controls.Add(lblName);
            pnlCard.Controls.Add(pnlName);
            pnlCard.Controls.Add(lblPhone);
            pnlCard.Controls.Add(pnlPhone);
            pnlCard.Controls.Add(lblDOB);
            pnlCard.Controls.Add(pnlDOB);
            pnlCard.Controls.Add(lblSalary);
            pnlCard.Controls.Add(pnlSalary);
            pnlCard.Controls.Add(lblAddress);
            pnlCard.Controls.Add(pnlAddress);
            pnlCard.Location = new Point(94, 162);
            pnlCard.Margin = new Padding(4);
            pnlCard.Name = "pnlCard";
            pnlCard.Size = new Size(1312, 725);
            pnlCard.TabIndex = 4;
            // 
            // consoleLBL
            // 
            consoleLBL.AutoSize = true;
            consoleLBL.Location = new Point(1139, 696);
            consoleLBL.Name = "consoleLBL";
            consoleLBL.Size = new Size(50, 20);
            consoleLBL.TabIndex = 27;
            consoleLBL.Text = "label1";
            // 
            // lblPhoneStatus
            // 
            lblPhoneStatus.AutoSize = true;
            lblPhoneStatus.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPhoneStatus.Location = new Point(742, 248);
            lblPhoneStatus.Name = "lblPhoneStatus";
            lblPhoneStatus.Size = new Size(31, 19);
            lblPhoneStatus.TabIndex = 26;
            lblPhoneStatus.Text = "LBL";
            lblPhoneStatus.Visible = false;
            // 
            // lblUserStatus
            // 
            lblUserStatus.AutoSize = true;
            lblUserStatus.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUserStatus.Location = new Point(350, 136);
            lblUserStatus.Name = "lblUserStatus";
            lblUserStatus.Size = new Size(31, 19);
            lblUserStatus.TabIndex = 25;
            lblUserStatus.Text = "LBL";
            lblUserStatus.Visible = false;
            // 
            // chkShowPass
            // 
            chkShowPass.AutoSize = true;
            chkShowPass.Font = new Font("Segoe UI", 9F);
            chkShowPass.ForeColor = Color.FromArgb(110, 110, 115);
            chkShowPass.Location = new Point(50, 248);
            chkShowPass.Margin = new Padding(4);
            chkShowPass.Name = "chkShowPass";
            chkShowPass.Size = new Size(132, 24);
            chkShowPass.TabIndex = 0;
            chkShowPass.Text = "Show Password";
            // 
            // btnReset
            // 
            btnReset.Font = new Font("Segoe UI Semibold", 10F);
            btnReset.Location = new Point(350, 644);
            btnReset.Margin = new Padding(4);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(200, 60);
            btnReset.TabIndex = 1;
            btnReset.Text = "Reset Form";
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI Semibold", 11F);
            btnSave.Location = new Point(50, 644);
            btnSave.Margin = new Padding(4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(275, 60);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save Employee";
            // 
            // btnUpload
            // 
            btnUpload.BackColor = Color.Transparent;
            btnUpload.Font = new Font("Segoe UI Semibold", 9.5F);
            btnUpload.Location = new Point(938, 319);
            btnUpload.Margin = new Padding(4);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(175, 50);
            btnUpload.TabIndex = 3;
            btnUpload.Text = "📷 Upload Photo";
            btnUpload.UseVisualStyleBackColor = false;
            // 
            // lblImage
            // 
            lblImage.AutoSize = true;
            lblImage.Font = new Font("Segoe UI Semibold", 9.5F);
            lblImage.ForeColor = Color.FromArgb(110, 110, 115);
            lblImage.Location = new Point(912, 44);
            lblImage.Margin = new Padding(4, 0, 4, 0);
            lblImage.Name = "lblImage";
            lblImage.Size = new Size(113, 21);
            lblImage.TabIndex = 4;
            lblImage.Text = "Profile Picture";
            // 
            // picProfile
            // 
            picProfile.BackColor = Color.FromArgb(245, 245, 250);
            picProfile.Location = new Point(912, 75);
            picProfile.Margin = new Padding(4);
            picProfile.Name = "picProfile";
            picProfile.Size = new Size(225, 225);
            picProfile.SizeMode = PictureBoxSizeMode.StretchImage;
            picProfile.TabIndex = 5;
            picProfile.TabStop = false;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Segoe UI Semibold", 9.5F);
            lblUser.ForeColor = Color.FromArgb(110, 110, 115);
            lblUser.Location = new Point(50, 44);
            lblUser.Margin = new Padding(4, 0, 4, 0);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(145, 21);
            lblUser.TabIndex = 6;
            lblUser.Text = "Username or Email";
            // 
            // pnlUser
            // 
            pnlUser.Controls.Add(txtUsername);
            pnlUser.Location = new Point(50, 72);
            pnlUser.Margin = new Padding(4);
            pnlUser.Name = "pnlUser";
            pnlUser.Size = new Size(400, 60);
            pnlUser.TabIndex = 7;
            // 
            // txtUsername
            // 
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Font = new Font("Segoe UI", 11F);
            txtUsername.Location = new Point(15, 15);
            txtUsername.Margin = new Padding(4);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(370, 25);
            txtUsername.TabIndex = 0;
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.Font = new Font("Segoe UI Semibold", 9.5F);
            lblPass.ForeColor = Color.FromArgb(110, 110, 115);
            lblPass.Location = new Point(50, 150);
            lblPass.Margin = new Padding(4, 0, 4, 0);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(79, 21);
            lblPass.TabIndex = 8;
            lblPass.Text = "Password";
            // 
            // pnlPass
            // 
            pnlPass.Controls.Add(txtPassword);
            pnlPass.Location = new Point(50, 179);
            pnlPass.Margin = new Padding(4);
            pnlPass.Name = "pnlPass";
            pnlPass.Size = new Size(400, 60);
            pnlPass.TabIndex = 9;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.Location = new Point(15, 15);
            txtPassword.Margin = new Padding(4);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(370, 25);
            txtPassword.TabIndex = 0;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Segoe UI Semibold", 9.5F);
            lblRole.ForeColor = Color.FromArgb(110, 110, 115);
            lblRole.Location = new Point(50, 294);
            lblRole.Margin = new Padding(4, 0, 4, 0);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(100, 21);
            lblRole.TabIndex = 10;
            lblRole.Text = "System Role";
            // 
            // pnlRole
            // 
            pnlRole.Controls.Add(cmbRole);
            pnlRole.Location = new Point(50, 322);
            pnlRole.Margin = new Padding(4);
            pnlRole.Name = "pnlRole";
            pnlRole.Size = new Size(400, 60);
            pnlRole.TabIndex = 11;
            // 
            // cmbRole
            // 
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.FlatStyle = FlatStyle.Flat;
            cmbRole.Font = new Font("Segoe UI", 11F);
            cmbRole.Location = new Point(10, 12);
            cmbRole.Margin = new Padding(4);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(379, 33);
            cmbRole.TabIndex = 0;
            // 
            // lblBranch
            // 
            lblBranch.AutoSize = true;
            lblBranch.Font = new Font("Segoe UI Semibold", 9.5F);
            lblBranch.ForeColor = Color.FromArgb(110, 110, 115);
            lblBranch.Location = new Point(50, 400);
            lblBranch.Margin = new Padding(4, 0, 4, 0);
            lblBranch.Name = "lblBranch";
            lblBranch.Size = new Size(112, 21);
            lblBranch.TabIndex = 12;
            lblBranch.Text = "Assign Branch";
            // 
            // pnlBranch
            // 
            pnlBranch.Controls.Add(cmbBranch);
            pnlBranch.Location = new Point(50, 429);
            pnlBranch.Margin = new Padding(4);
            pnlBranch.Name = "pnlBranch";
            pnlBranch.Size = new Size(400, 60);
            pnlBranch.TabIndex = 13;
            // 
            // cmbBranch
            // 
            cmbBranch.FlatStyle = FlatStyle.Flat;
            cmbBranch.Font = new Font("Segoe UI", 11F);
            cmbBranch.Location = new Point(10, 12);
            cmbBranch.Margin = new Padding(4);
            cmbBranch.Name = "cmbBranch";
            cmbBranch.Size = new Size(379, 33);
            cmbBranch.TabIndex = 0;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI Semibold", 9.5F);
            lblName.ForeColor = Color.FromArgb(110, 110, 115);
            lblName.Location = new Point(500, 44);
            lblName.Margin = new Padding(4, 0, 4, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(82, 21);
            lblName.TabIndex = 14;
            lblName.Text = "Full Name";
            // 
            // pnlName
            // 
            pnlName.Controls.Add(txtName);
            pnlName.Location = new Point(500, 72);
            pnlName.Margin = new Padding(4);
            pnlName.Name = "pnlName";
            pnlName.Size = new Size(350, 60);
            pnlName.TabIndex = 15;
            // 
            // txtName
            // 
            txtName.BorderStyle = BorderStyle.None;
            txtName.Font = new Font("Segoe UI", 11F);
            txtName.Location = new Point(15, 15);
            txtName.Margin = new Padding(4);
            txtName.Name = "txtName";
            txtName.Size = new Size(320, 25);
            txtName.TabIndex = 0;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI Semibold", 9.5F);
            lblPhone.ForeColor = Color.FromArgb(110, 110, 115);
            lblPhone.Location = new Point(500, 150);
            lblPhone.Margin = new Padding(4, 0, 4, 0);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(120, 21);
            lblPhone.TabIndex = 16;
            lblPhone.Text = "Phone Number";
            // 
            // pnlPhone
            // 
            pnlPhone.Controls.Add(txtPhone);
            pnlPhone.Location = new Point(500, 179);
            pnlPhone.Margin = new Padding(4);
            pnlPhone.Name = "pnlPhone";
            pnlPhone.Size = new Size(350, 60);
            pnlPhone.TabIndex = 17;
            // 
            // txtPhone
            // 
            txtPhone.BorderStyle = BorderStyle.None;
            txtPhone.Font = new Font("Segoe UI", 11F);
            txtPhone.Location = new Point(15, 15);
            txtPhone.Margin = new Padding(4);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(320, 25);
            txtPhone.TabIndex = 0;
            // 
            // lblDOB
            // 
            lblDOB.AutoSize = true;
            lblDOB.Font = new Font("Segoe UI Semibold", 9.5F);
            lblDOB.ForeColor = Color.FromArgb(110, 110, 115);
            lblDOB.Location = new Point(500, 256);
            lblDOB.Margin = new Padding(4, 0, 4, 0);
            lblDOB.Name = "lblDOB";
            lblDOB.Size = new Size(103, 21);
            lblDOB.TabIndex = 18;
            lblDOB.Text = "Date of Birth";
            // 
            // pnlDOB
            // 
            pnlDOB.Controls.Add(dtpDOB);
            pnlDOB.Location = new Point(500, 285);
            pnlDOB.Margin = new Padding(4);
            pnlDOB.Name = "pnlDOB";
            pnlDOB.Size = new Size(350, 60);
            pnlDOB.TabIndex = 19;
            // 
            // dtpDOB
            // 
            dtpDOB.Font = new Font("Segoe UI", 11F);
            dtpDOB.Format = DateTimePickerFormat.Short;
            dtpDOB.Location = new Point(12, 12);
            dtpDOB.Margin = new Padding(4);
            dtpDOB.Name = "dtpDOB";
            dtpDOB.Size = new Size(324, 32);
            dtpDOB.TabIndex = 0;
            // 
            // lblSalary
            // 
            lblSalary.AutoSize = true;
            lblSalary.Font = new Font("Segoe UI Semibold", 9.5F);
            lblSalary.ForeColor = Color.FromArgb(110, 110, 115);
            lblSalary.Location = new Point(500, 362);
            lblSalary.Margin = new Padding(4, 0, 4, 0);
            lblSalary.Name = "lblSalary";
            lblSalary.Size = new Size(121, 21);
            lblSalary.TabIndex = 20;
            lblSalary.Text = "Base Salary (৳)";
            // 
            // pnlSalary
            // 
            pnlSalary.Controls.Add(txtSalary);
            pnlSalary.Location = new Point(500, 391);
            pnlSalary.Margin = new Padding(4);
            pnlSalary.Name = "pnlSalary";
            pnlSalary.Size = new Size(200, 60);
            pnlSalary.TabIndex = 21;
            // 
            // txtSalary
            // 
            txtSalary.BorderStyle = BorderStyle.None;
            txtSalary.Font = new Font("Segoe UI", 11F);
            txtSalary.Location = new Point(15, 15);
            txtSalary.Margin = new Padding(4);
            txtSalary.Name = "txtSalary";
            txtSalary.Size = new Size(170, 25);
            txtSalary.TabIndex = 0;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Segoe UI Semibold", 9.5F);
            lblAddress.ForeColor = Color.FromArgb(110, 110, 115);
            lblAddress.Location = new Point(500, 469);
            lblAddress.Margin = new Padding(4, 0, 4, 0);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(152, 21);
            lblAddress.TabIndex = 22;
            lblAddress.Text = "Permanent Address";
            // 
            // pnlAddress
            // 
            pnlAddress.Controls.Add(txtAddress);
            pnlAddress.Location = new Point(500, 498);
            pnlAddress.Margin = new Padding(4);
            pnlAddress.Name = "pnlAddress";
            pnlAddress.Size = new Size(350, 112);
            pnlAddress.TabIndex = 23;
            // 
            // txtAddress
            // 
            txtAddress.BorderStyle = BorderStyle.None;
            txtAddress.Font = new Font("Segoe UI", 10F);
            txtAddress.Location = new Point(15, 15);
            txtAddress.Margin = new Padding(4);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(320, 82);
            txtAddress.TabIndex = 0;
            // 
            // EmployeeRegistrationPage
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1500, 938);
            Controls.Add(pnlCard);
            Controls.Add(pnlHeaderLine);
            Controls.Add(btnClose);
            Controls.Add(lblSubtitle);
            Controls.Add(lblTitle);
            Controls.Add(btnBack);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "EmployeeRegistrationPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Employee Registration";
            pnlCard.ResumeLayout(false);
            pnlCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picProfile).EndInit();
            pnlUser.ResumeLayout(false);
            pnlUser.PerformLayout();
            pnlPass.ResumeLayout(false);
            pnlPass.PerformLayout();
            pnlRole.ResumeLayout(false);
            pnlBranch.ResumeLayout(false);
            pnlName.ResumeLayout(false);
            pnlName.PerformLayout();
            pnlPhone.ResumeLayout(false);
            pnlPhone.PerformLayout();
            pnlDOB.ResumeLayout(false);
            pnlSalary.ResumeLayout(false);
            pnlSalary.PerformLayout();
            pnlAddress.ResumeLayout(false);
            pnlAddress.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label btnBack;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label btnClose;
        private System.Windows.Forms.Panel pnlHeaderLine;
        private System.Windows.Forms.Panel pnlCard;

        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Panel pnlUser;
        private System.Windows.Forms.TextBox txtUsername;

        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Panel pnlPass;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox chkShowPass;

        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Panel pnlRole;
        private System.Windows.Forms.ComboBox cmbRole;

        private System.Windows.Forms.Label lblBranch;
        private System.Windows.Forms.Panel pnlBranch;
        private System.Windows.Forms.ComboBox cmbBranch;

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Panel pnlName;
        private System.Windows.Forms.TextBox txtName;

        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Panel pnlPhone;
        private System.Windows.Forms.TextBox txtPhone;

        private System.Windows.Forms.Label lblDOB;
        private System.Windows.Forms.Panel pnlDOB;
        private System.Windows.Forms.DateTimePicker dtpDOB;

        private System.Windows.Forms.Label lblSalary;
        private System.Windows.Forms.Panel pnlSalary;
        private System.Windows.Forms.TextBox txtSalary;

        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Panel pnlAddress;
        private System.Windows.Forms.TextBox txtAddress;

        private System.Windows.Forms.PictureBox picProfile;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.Button btnUpload;

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnReset;
        private Label lblUserStatus;
        private Label lblPhoneStatus;
        private Label consoleLBL;
    }
}