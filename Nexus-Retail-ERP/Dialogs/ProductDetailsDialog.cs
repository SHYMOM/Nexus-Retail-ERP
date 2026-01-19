using Nexus_Retail_ERP.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Nexus_Retail_ERP.Dialogs
{
    public class ProductDetailsDialog : Form
    {
        private int _productID, _branchID;
        private string _mainImagePath;
        private DataTable _dtVariants;

        private PictureBox picProduct;
        private Label lblName, lblDesc, lblPrice, lblStock, lblUOM;
        private Label lblTransferInfo;
        private ComboBox cmbVariants;

        public ProductDetailsDialog(int productID, string productName, string mainImagePath, int branchID)
        {
            _productID = productID;
            _branchID = branchID;
            _mainImagePath = mainImagePath;

            InitializeUI(productName);
            LoadData();
        }

        private void InitializeUI(string productName)
        {
            this.Size = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.White;

            Panel pnlBorder = new Panel
            {
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(pnlBorder);

            Button btnClose = new Button
            {
                Text = "✕",
                Size = new Size(50, 50),
                Location = new Point(840, 10),
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.Gray,
                Font = new Font("Segoe UI", 16),
                Cursor = Cursors.Hand
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += (s, e) => this.Close();

            picProduct = new PictureBox
            {
                Location = new Point(40, 60),
                Size = new Size(400, 400),
                SizeMode = PictureBoxSizeMode.Zoom,
                BorderStyle = BorderStyle.FixedSingle
            };

            lblName = new Label
            {
                Text = productName,
                Location = new Point(470, 60),
                Size = new Size(380, 80),
                Font = new Font("Segoe UI", 22, FontStyle.Bold),
                AutoEllipsis = true
            };

            lblDesc = new Label
            {
                Location = new Point(470, 140),
                Size = new Size(380, 80),
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.DimGray,
                Text = "Loading details..."
            };

            Label lblVarTitle = new Label
            {
                Text = "Available Variants:",
                Location = new Point(470, 240),
                AutoSize = true,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.Gray
            };

            cmbVariants = new ComboBox
            {
                Location = new Point(470, 270),
                Size = new Size(350, 40),
                Font = new Font("Segoe UI", 14),
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            cmbVariants.SelectedIndexChanged += CmbVariants_SelectedIndexChanged;

            lblPrice = new Label
            {
                Text = "৳ 0.00",
                Location = new Point(470, 340),
                AutoSize = true,
                Font = new Font("Segoe UI", 26, FontStyle.Bold),
                ForeColor = Color.SeaGreen
            };

            lblStock = new Label
            {
                Text = "Checking...",
                Location = new Point(475, 400),
                AutoSize = true,
                Font = new Font("Segoe UI", 12)
            };

            lblUOM = new Label
            {
                Text = "Unit: -",
                Location = new Point(475, 430),
                AutoSize = true,
                Font = new Font("Segoe UI", 12)
            };

            lblTransferInfo = new Label
            {
                Text = "⚠ Item not available at this branch.\nPlease visit the counter to request a Stock Transfer.",
                Location = new Point(470, 470),
                Size = new Size(380, 60),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.DarkOrange,
                TextAlign = ContentAlignment.MiddleCenter,
                BorderStyle = BorderStyle.FixedSingle,
                Visible = false
            };

            pnlBorder.Controls.AddRange(new Control[] { btnClose, picProduct, lblName, lblDesc, lblVarTitle, cmbVariants, lblPrice, lblStock, lblUOM, lblTransferInfo });
        }

        private void LoadData()
        {
            if (File.Exists(_mainImagePath)) picProduct.Image = Image.FromFile(_mainImagePath);

            _dtVariants = DatabaseHelper.GetProductVariants(_productID, _branchID);

            if (_dtVariants.Rows.Count > 0)
            {
                lblDesc.Text = _dtVariants.Rows[0]["Description"].ToString();
                cmbVariants.DataSource = _dtVariants;
                cmbVariants.DisplayMember = "VariantName";
                cmbVariants.ValueMember = "VariantID";
                cmbVariants.SelectedIndex = 0;
            }
        }

        private void CmbVariants_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVariants.SelectedIndex == -1) return;
            DataRowView row = cmbVariants.SelectedItem as DataRowView;
            if (row == null) return;

            lblPrice.Text = $"৳ {Convert.ToDecimal(row["SalesPrice"]):N0}";
            string varImg = row["VariantImagePath"].ToString();
            if (!string.IsNullOrEmpty(varImg) && File.Exists(varImg)) picProduct.Image = Image.FromFile(varImg);
            else if (File.Exists(_mainImagePath)) picProduct.Image = Image.FromFile(_mainImagePath);

            int stock = Convert.ToInt32(row["Stock"]);
            lblUOM.Text = $"Unit: {row["UOM"]}";

            lblTransferInfo.Visible = true;

            if (stock > 0)
            {
                lblStock.Text = $"✓ In Stock ({stock} Available)";
                lblStock.ForeColor = Color.SeaGreen;

                lblTransferInfo.Text = "✨ Product Available!\nPlease visit the counter to purchase this item.";
                lblTransferInfo.ForeColor = Color.SeaGreen;
                lblTransferInfo.BackColor = Color.MintCream;
            }
            else
            {
                lblStock.Text = "✕ Out of Stock at this Branch";
                lblStock.ForeColor = Color.IndianRed;

                lblTransferInfo.Text = "⚠ Item currently unavailable.\nPlease visit the counter to request a Stock Transfer.";
                lblTransferInfo.ForeColor = Color.DarkOrange;
                lblTransferInfo.BackColor = Color.FloralWhite;
            }
        }
    }
}
