using Nexus_Retail_ERP.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Nexus_Retail_ERP.Dialogs
{
    public class AddCustomerDialog : Form
    {
        public string NewPhone { get; private set; }

        public AddCustomerDialog(string initialPhone = "")
        {
            this.Text = "Register New Customer";
            this.Size = new Size(450, 520);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;

            Label lblTitle = new Label
            {
                Text = "New Customer Profile",
                Location = new Point(25, 20),
                AutoSize = true,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 180, 216)
            };

            int startY = 70;
            int gap = 60;

            Label lName = new Label
            {
                Text = "Full Name *",
                Location = new Point(25, startY),
                AutoSize = true,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };

            TextBox txtName = new TextBox
            {
                Location = new Point(25, startY + 20),
                Width = 380,
                Font = new Font("Segoe UI", 11)
            };


            Label lPhone = new Label
            {
                Text = "Phone Number *",
                Location = new Point(25, startY + gap),
                AutoSize = true,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };

            TextBox txtPhone = new TextBox
            {
                Location = new Point(25, startY + gap + 20),
                Width = 380,
                Font = new Font("Segoe UI", 11),
                Text = initialPhone
            };

            Label lEmail = new Label
            {
                Text = "Email Address",
                Location = new Point(25, startY + (gap * 2)),
                AutoSize = true
            };

            TextBox txtEmail = new TextBox
            {
                Location = new Point(25, startY + (gap * 2) + 20),
                Width = 380,
                Font = new Font("Segoe UI", 11)
            };

            Label lAddress = new Label
            {
                Text = "Home Address",
                Location = new Point(25, startY + (gap * 3)),
                AutoSize = true
            };

            TextBox txtAddress = new TextBox
            {
                Location = new Point(25, startY + (gap * 3) + 20),
                Width = 380,
                Font = new Font("Segoe UI", 11)
            };

            CheckBox chkDOB = new CheckBox
            {
                Text = "Add Birthday?",
                Location = new Point(25, startY + (gap * 4)),
                AutoSize = true,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };
            DateTimePicker dtpDOB = new DateTimePicker
            {
                Location = new Point(140, startY + (gap * 4) - 3),
                Width = 265,
                Font = new Font("Segoe UI", 10),
                Format = DateTimePickerFormat.Short,
                Enabled = false
            };

            chkDOB.CheckedChanged += (s, e) => dtpDOB.Enabled = chkDOB.Checked;

            Button btnSave = new Button
            {
                Text = "SAVE PROFILE",
                Location = new Point(25, 410),
                Width = 380,
                Height = 45,
                BackColor = Color.SeaGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Cursor = Cursors.Hand
            };

            this.Controls.AddRange(new Control[] { lblTitle, lName, txtName, lPhone, txtPhone, lEmail, txtEmail, lAddress, txtAddress, chkDOB, dtpDOB, btnSave });

            btnSave.Click += (s, e) =>
            {
                string phone = txtPhone.Text.Trim();
                string name = txtName.Text.Trim();

                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(phone))
                {
                    MessageBox.Show("Name and Phone are mandatory.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidationHelper.IsValidPhone(phone))
                {
                    MessageBox.Show("Invalid Phone Number Format.\nPlease enter a valid 11-digit mobile number (e.g., 017XXXXXXXX).", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPhone.Focus();
                    return;
                }

                DateTime? dob = null;
                if (chkDOB.Checked) dob = dtpDOB.Value;

                bool success = DatabaseHelper.AddCustomer(name, phone, txtEmail.Text.Trim(), txtAddress.Text.Trim(), dob);

                if (success)
                {
                    NewPhone = phone;
                    MessageBox.Show("Customer Registered Successfully!", "Success");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Registration failed. This phone number might already be registered.", "Duplicate Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
        }
    }
}
