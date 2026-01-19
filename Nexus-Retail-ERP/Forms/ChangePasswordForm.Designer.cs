namespace Nexus_Retail_ERP.Forms
{
    partial class ChangePasswordForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblNewPass = new System.Windows.Forms.Label();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.lblConfirm = new System.Windows.Forms.Label();
            this.txtConfirmPass = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlBorder = new System.Windows.Forms.Panel();
            this.pnlBorder.SuspendLayout();
            this.SuspendLayout();

            // 
            // MAIN BORDER PANEL
            // 
            this.pnlBorder.BackColor = System.Drawing.Color.White;
            this.pnlBorder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBorder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBorder.Controls.Add(this.btnCancel);
            this.pnlBorder.Controls.Add(this.btnReset);
            this.pnlBorder.Controls.Add(this.txtConfirmPass);
            this.pnlBorder.Controls.Add(this.lblConfirm);
            this.pnlBorder.Controls.Add(this.txtNewPass);
            this.pnlBorder.Controls.Add(this.lblNewPass);
            this.pnlBorder.Controls.Add(this.txtUsername);
            this.pnlBorder.Controls.Add(this.lblUser);
            this.pnlBorder.Controls.Add(this.lblTitle);
            this.pnlBorder.Location = new System.Drawing.Point(0, 0);
            this.pnlBorder.Size = new System.Drawing.Size(400, 380);

            // Title
            this.lblTitle.Text = "Reset Password";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(0, 180, 216);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.AutoSize = true;

            // Username
            this.lblUser.Text = "Username:";
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblUser.Location = new System.Drawing.Point(30, 70);
            this.lblUser.AutoSize = true;

            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtUsername.Location = new System.Drawing.Point(30, 95);
            this.txtUsername.Size = new System.Drawing.Size(330, 27);

            // New Password
            this.lblNewPass.Text = "New Password:";
            this.lblNewPass.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNewPass.Location = new System.Drawing.Point(30, 140);
            this.lblNewPass.AutoSize = true;

            this.txtNewPass.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtNewPass.Location = new System.Drawing.Point(30, 165);
            this.txtNewPass.Size = new System.Drawing.Size(330, 27);
            this.txtNewPass.PasswordChar = '●';

            // Confirm Password
            this.lblConfirm.Text = "Confirm Password:";
            this.lblConfirm.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblConfirm.Location = new System.Drawing.Point(30, 210);
            this.lblConfirm.AutoSize = true;

            this.txtConfirmPass.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtConfirmPass.Location = new System.Drawing.Point(30, 235);
            this.txtConfirmPass.Size = new System.Drawing.Size(330, 27);
            this.txtConfirmPass.PasswordChar = '●';

            // Reset Button
            this.btnReset.Text = "RESET PASSWORD";
            this.btnReset.BackColor = System.Drawing.Color.SeaGreen;
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnReset.Location = new System.Drawing.Point(30, 290);
            this.btnReset.Size = new System.Drawing.Size(180, 40);
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);

            // Cancel Button
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.BackColor = System.Drawing.Color.IndianRed;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location = new System.Drawing.Point(230, 290);
            this.btnCancel.Size = new System.Drawing.Size(130, 40);
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // Form Settings
            this.ClientSize = new System.Drawing.Size(400, 380);
            this.Controls.Add(this.pnlBorder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Name = "ForgotPasswordDialog";
            this.Text = "Reset Password";

            this.pnlBorder.ResumeLayout(false);
            this.pnlBorder.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlBorder;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblNewPass;
        private System.Windows.Forms.TextBox txtNewPass;
        private System.Windows.Forms.Label lblConfirm;
        private System.Windows.Forms.TextBox txtConfirmPass;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnCancel;
    }
}