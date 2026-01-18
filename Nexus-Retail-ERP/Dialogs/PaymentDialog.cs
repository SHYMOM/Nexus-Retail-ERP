using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Nexus_Retail_ERP.Dialogs
{
    public class PaymentDialog : Form
    {
        public string SelectedMethod { get; private set; } = "Cash";
        public string ReferenceInfo { get; private set; } = "";

        private ComboBox cmbMethod;
        private TextBox txtRef;
        private Label lblRef;

        public PaymentDialog(decimal amount)
        {
            this.Text = "Select Payment Method";
            this.Size = new Size(350, 300);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;

            Label lblTitle = new Label
            {
                Text = $"Total Due: ৳ {amount:N2}",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 180, 216),
                Location = new Point(20, 20),
                AutoSize = true
            };

            Label lblMethod = new Label
            {
                Text = "Payment Type:",
                Location = new Point(20, 70),
                AutoSize = true
            };
            cmbMethod = new ComboBox
            {
                Location = new Point(20, 95),
                Width = 280,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 11)
            };
            cmbMethod.Items.AddRange(new object[] { "Cash", "Card", "Mobile Banking", "Bank Transfer" });
            cmbMethod.SelectedIndex = 0;
            cmbMethod.SelectedIndexChanged += (s, e) => ToggleRefField();

            lblRef = new Label
            {
                Text = "Transaction ID / Auth Code:",
                Location = new Point(20, 140),
                AutoSize = true,
                Visible = false
            };
            txtRef = new TextBox
            {
                Location = new Point(20, 165),
                Width = 280,
                Font = new Font("Segoe UI", 11),
                Visible = false
            };

            Button btnConfirm = new Button
            {
                Text = "CONFIRM PAYMENT",
                DialogResult = DialogResult.OK,
                Location = new Point(20, 210),
                Width = 280,
                Height = 40,
                BackColor = Color.SeaGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            this.Controls.AddRange(new Control[] { lblTitle, lblMethod, cmbMethod, lblRef, txtRef, btnConfirm });

            btnConfirm.Click += (s, e) =>
            {
                SelectedMethod = cmbMethod.SelectedItem.ToString();
                ReferenceInfo = txtRef.Text.Trim();
            };
        }

        private void ToggleRefField()
        {
            bool needsRef = cmbMethod.SelectedItem.ToString() != "Cash";
            lblRef.Visible = needsRef;
            txtRef.Visible = needsRef;
        }
    }
}
