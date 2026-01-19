using System;
using System.Collections.Generic;
using System.Text;

namespace Nexus_Retail_ERP.Dialogs
{
    public class PasswordDialog : Form
    {
        public bool IsAuthorized { get; private set; } = false;
        private TextBox txtPass;

        public PasswordDialog()
        {
            this.Size = new Size(400, 250);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.ControlBox = false;
            this.Text = "Admin Verification";
            this.BackColor = Color.WhiteSmoke;

            Label lbl = new Label { Text = "Enter Kiosk PIN to Exit:", Location = new Point(40, 40), AutoSize = true, Font = new Font("Segoe UI", 12) };

            txtPass = new TextBox { Location = new Point(40, 80), Width = 300, PasswordChar = '●', Font = new Font("Segoe UI", 14), TextAlign = HorizontalAlignment.Center };

            Button btnUnlock = new Button
            {
                Text = "UNLOCK SYSTEM",
                Location = new Point(40, 140),
                Width = 140,
                Height = 45,
                BackColor = Color.IndianRed,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Cursor = Cursors.Hand
            };

            Button btnCancel = new Button
            {
                Text = "CANCEL",
                Location = new Point(200, 140),
                Width = 140,
                Height = 45,
                BackColor = Color.Gray,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Cursor = Cursors.Hand
            };

            // PIN is 1234
            btnUnlock.Click += (s, e) =>
            {
                if (txtPass.Text == "1234")
                {
                    IsAuthorized = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Incorrect PIN", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPass.Clear();
                    txtPass.Focus();
                }
            };

            btnCancel.Click += (s, e) => this.Close();

            this.Controls.AddRange(new Control[] { lbl, txtPass, btnUnlock, btnCancel });
            this.AcceptButton = btnUnlock;
        }
    }
}
