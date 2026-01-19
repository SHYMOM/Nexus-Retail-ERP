using System;
using System.Collections.Generic;
using System.Text;

namespace Nexus_Retail_ERP.Dialogs
{
    public class RestockDialog : Form
    {
        public int Quantity { get; private set; }

        public RestockDialog(string productName, string variantName, int currentStock)
        {
            this.Text = "Request Stock";
            this.Size = new Size(400, 300);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;
            this.ControlBox = false;

            Label lblTitle = new Label { Text = "Initiate Stock Request", Location = new Point(20, 20), AutoSize = true, Font = new Font("Segoe UI", 12, FontStyle.Bold), ForeColor = Color.FromArgb(0, 180, 216) };

            Label lblInfo = new Label
            {
                Text = $"Product: {productName}\nVariant: {variantName}\nYour Current Stock: {currentStock}",
                Location = new Point(20, 60),
                AutoSize = true,
                Font = new Font("Segoe UI", 10)
            };

            Label lblQty = new Label { Text = "Quantity Needed:", Location = new Point(20, 140), AutoSize = true, Font = new Font("Segoe UI", 10, FontStyle.Bold) };
            NumericUpDown numQty = new NumericUpDown { Location = new Point(20, 165), Width = 340, Font = new Font("Segoe UI", 12), Minimum = 1, Maximum = 5000, Value = 10 };

            Button btnCancel = new Button { Text = "CANCEL", DialogResult = DialogResult.Cancel, Location = new Point(20, 210), Width = 100, Height = 35, FlatStyle = FlatStyle.Flat, ForeColor = Color.Gray };
            Button btnSend = new Button { Text = "SEND REQUEST", DialogResult = DialogResult.OK, Location = new Point(140, 210), Width = 220, Height = 35, BackColor = Color.SeaGreen, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10, FontStyle.Bold), Cursor = Cursors.Hand };

            this.Controls.AddRange(new Control[] { lblTitle, lblInfo, lblQty, numQty, btnCancel, btnSend });

            btnSend.Click += (s, e) => { Quantity = (int)numQty.Value; };
            btnCancel.Click += (s, e) => { this.Close(); };
        }
    }
}
