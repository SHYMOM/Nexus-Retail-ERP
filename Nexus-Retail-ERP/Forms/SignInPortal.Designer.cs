namespace Nexus_Retail_ERP.Forms
{
    partial class SignInPortal
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
            pnlLeft = new Panel();
            lblTagline = new Label();
            lblBrandName = new Label();
            picLogo = new PictureBox();
            pnlRight = new Panel();
            lblSuccessMessage = new Label();
            lblBranch = new Label();
            pnlBranch = new Panel();
            cmbBranch = new ComboBox();
            btnClose = new Label();
            lblErrorMessage = new Label();
            chkShowPass = new CheckBox();
            btnLogin = new Button();
            pnlPassContainer = new Panel();
            txtPassword = new TextBox();
            lblPass = new Label();
            pnlUserContainer = new Panel();
            txtUsername = new TextBox();
            lblUser = new Label();
            lblTitle = new Label();
            pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            pnlRight.SuspendLayout();
            pnlBranch.SuspendLayout();
            pnlPassContainer.SuspendLayout();
            pnlUserContainer.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLeft
            // 
            pnlLeft.BackColor = Color.FromArgb(64, 64, 64);
            pnlLeft.Controls.Add(lblTagline);
            pnlLeft.Controls.Add(lblBrandName);
            pnlLeft.Controls.Add(picLogo);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Margin = new Padding(4);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(438, 688);
            pnlLeft.TabIndex = 0;
            // 
            // lblTagline
            // 
            lblTagline.AutoSize = true;
            lblTagline.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTagline.ForeColor = Color.Gray;
            lblTagline.Location = new Point(50, 325);
            lblTagline.Margin = new Padding(4, 0, 4, 0);
            lblTagline.Name = "lblTagline";
            lblTagline.Size = new Size(296, 20);
            lblTagline.TabIndex = 2;
            lblTagline.Text = "Secure. Scalable. Centralized Retail Control.";
            // 
            // lblBrandName
            // 
            lblBrandName.AutoSize = true;
            lblBrandName.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBrandName.ForeColor = Color.White;
            lblBrandName.Location = new Point(45, 275);
            lblBrandName.Margin = new Padding(4, 0, 4, 0);
            lblBrandName.Name = "lblBrandName";
            lblBrandName.Size = new Size(249, 41);
            lblBrandName.TabIndex = 1;
            lblBrandName.Text = "Nexus Retail ERP";
            // 
            // picLogo
            // 
            picLogo.BackColor = Color.Transparent;
            picLogo.Image = Properties.Resources.ic_logo;
            picLogo.Location = new Point(50, 76);
            picLogo.Margin = new Padding(4);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(242, 256);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // pnlRight
            // 
            pnlRight.BackColor = Color.WhiteSmoke;
            pnlRight.Controls.Add(lblSuccessMessage);
            pnlRight.Controls.Add(lblBranch);
            pnlRight.Controls.Add(pnlBranch);
            pnlRight.Controls.Add(btnClose);
            pnlRight.Controls.Add(lblErrorMessage);
            pnlRight.Controls.Add(chkShowPass);
            pnlRight.Controls.Add(btnLogin);
            pnlRight.Controls.Add(pnlPassContainer);
            pnlRight.Controls.Add(lblPass);
            pnlRight.Controls.Add(pnlUserContainer);
            pnlRight.Controls.Add(lblUser);
            pnlRight.Controls.Add(lblTitle);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(438, 0);
            pnlRight.Margin = new Padding(4);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(687, 688);
            pnlRight.TabIndex = 1;
            // 
            // lblSuccessMessage
            // 
            lblSuccessMessage.AutoSize = true;
            lblSuccessMessage.Font = new Font("Segoe UI", 9F);
            lblSuccessMessage.ForeColor = Color.PaleGreen;
            lblSuccessMessage.Location = new Point(8, 659);
            lblSuccessMessage.Margin = new Padding(4, 0, 4, 0);
            lblSuccessMessage.Name = "lblSuccessMessage";
            lblSuccessMessage.Size = new Size(59, 20);
            lblSuccessMessage.TabIndex = 16;
            lblSuccessMessage.Text = "Success";
            lblSuccessMessage.Visible = false;
            // 
            // lblBranch
            // 
            lblBranch.AutoSize = true;
            lblBranch.Font = new Font("Segoe UI Semibold", 9.5F);
            lblBranch.ForeColor = Color.FromArgb(110, 110, 115);
            lblBranch.Location = new Point(119, 157);
            lblBranch.Margin = new Padding(4, 0, 4, 0);
            lblBranch.Name = "lblBranch";
            lblBranch.Size = new Size(109, 21);
            lblBranch.TabIndex = 14;
            lblBranch.Text = "Select Branch";
            // 
            // pnlBranch
            // 
            pnlBranch.Controls.Add(cmbBranch);
            pnlBranch.Location = new Point(119, 186);
            pnlBranch.Margin = new Padding(4);
            pnlBranch.Name = "pnlBranch";
            pnlBranch.Size = new Size(325, 43);
            pnlBranch.TabIndex = 15;
            // 
            // cmbBranch
            // 
            cmbBranch.FlatStyle = FlatStyle.Flat;
            cmbBranch.Font = new Font("Segoe UI", 11F);
            cmbBranch.Location = new Point(4, 4);
            cmbBranch.Margin = new Padding(4);
            cmbBranch.Name = "cmbBranch";
            cmbBranch.Size = new Size(316, 33);
            cmbBranch.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.AutoSize = true;
            btnClose.Cursor = Cursors.Hand;
            btnClose.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnClose.ForeColor = Color.DimGray;
            btnClose.Location = new Point(637, 12);
            btnClose.Margin = new Padding(4, 0, 4, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(25, 28);
            btnClose.TabIndex = 8;
            btnClose.Text = "X";
            // 
            // lblErrorMessage
            // 
            lblErrorMessage.AutoSize = true;
            lblErrorMessage.Font = new Font("Segoe UI", 9F);
            lblErrorMessage.ForeColor = Color.Firebrick;
            lblErrorMessage.Location = new Point(119, 441);
            lblErrorMessage.Margin = new Padding(4, 0, 4, 0);
            lblErrorMessage.Name = "lblErrorMessage";
            lblErrorMessage.Size = new Size(41, 20);
            lblErrorMessage.TabIndex = 7;
            lblErrorMessage.Text = "Error";
            lblErrorMessage.Visible = false;
            // 
            // chkShowPass
            // 
            chkShowPass.AutoSize = true;
            chkShowPass.Cursor = Cursors.Hand;
            chkShowPass.FlatStyle = FlatStyle.Flat;
            chkShowPass.Font = new Font("Segoe UI", 8F);
            chkShowPass.ForeColor = Color.DimGray;
            chkShowPass.Location = new Point(444, 413);
            chkShowPass.Margin = new Padding(4);
            chkShowPass.Name = "chkShowPass";
            chkShowPass.Size = new Size(122, 23);
            chkShowPass.TabIndex = 3;
            chkShowPass.Text = "Show Password";
            chkShowPass.UseVisualStyleBackColor = true;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.DodgerBlue;
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(119, 475);
            btnLogin.Margin = new Padding(4);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(450, 56);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            // 
            // pnlPassContainer
            // 
            pnlPassContainer.BackColor = Color.White;
            pnlPassContainer.Controls.Add(txtPassword);
            pnlPassContainer.Location = new Point(119, 351);
            pnlPassContainer.Margin = new Padding(4);
            pnlPassContainer.Name = "pnlPassContainer";
            pnlPassContainer.Size = new Size(450, 50);
            pnlPassContainer.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.Location = new Point(12, 12);
            txtPassword.Margin = new Padding(4);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(425, 25);
            txtPassword.TabIndex = 0;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblPass.ForeColor = Color.FromArgb(64, 64, 64);
            lblPass.Location = new Point(115, 326);
            lblPass.Margin = new Padding(4, 0, 4, 0);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(73, 20);
            lblPass.TabIndex = 4;
            lblPass.Text = "Password";
            // 
            // pnlUserContainer
            // 
            pnlUserContainer.BackColor = Color.White;
            pnlUserContainer.Controls.Add(txtUsername);
            pnlUserContainer.Location = new Point(119, 266);
            pnlUserContainer.Margin = new Padding(4);
            pnlUserContainer.Name = "pnlUserContainer";
            pnlUserContainer.Size = new Size(450, 50);
            pnlUserContainer.TabIndex = 1;
            // 
            // txtUsername
            // 
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Font = new Font("Segoe UI", 11F);
            txtUsername.Location = new Point(12, 12);
            txtUsername.Margin = new Padding(4);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(425, 25);
            txtUsername.TabIndex = 0;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblUser.ForeColor = Color.FromArgb(64, 64, 64);
            lblUser.Location = new Point(115, 242);
            lblUser.Margin = new Padding(4, 0, 4, 0);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(78, 20);
            lblUser.TabIndex = 2;
            lblUser.Text = "Username";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(28, 28, 30);
            lblTitle.Location = new Point(112, 100);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(290, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Sign in to your account";
            // 
            // SignInPortal
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1125, 688);
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "SignInPortal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nexus Retail ERP - Login";
            pnlLeft.ResumeLayout(false);
            pnlLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            pnlRight.ResumeLayout(false);
            pnlRight.PerformLayout();
            pnlBranch.ResumeLayout(false);
            pnlPassContainer.ResumeLayout(false);
            pnlPassContainer.PerformLayout();
            pnlUserContainer.ResumeLayout(false);
            pnlUserContainer.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Label lblBrandName;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblTagline;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlUserContainer;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Panel pnlPassContainer;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.CheckBox chkShowPass;
        private System.Windows.Forms.Label lblErrorMessage;
        private System.Windows.Forms.Label btnClose;
        private Label lblBranch;
        private Panel pnlBranch;
        private ComboBox cmbBranch;
        private Label lblSuccessMessage;
    }
}