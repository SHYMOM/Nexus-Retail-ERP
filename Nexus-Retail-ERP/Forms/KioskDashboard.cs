using Nexus_Retail_ERP.Data;
using Nexus_Retail_ERP.Dialogs;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Nexus_Retail_ERP.Forms
{
    public partial class KioskDashboard : Form
    {
        private int _currentBranchID = 1;
        private bool _isLoaded = false;

        public KioskDashboard()
        {
            InitializeComponent();
        }

        private void KioskDashboard_Load(object sender, EventArgs e)
        {
            LoadCategories();
            cmbSort.SelectedIndex = 0;
            _isLoaded = true;
            LoadProducts();
            this.Text = $"Kiosk (Branch #{_currentBranchID})";
        }

        private void LoadCategories()
        {
            try
            {
                DataTable dt = DatabaseHelper.GetCategories();
                cmbCategory.DataSource = dt;
                cmbCategory.DisplayMember = "CategoryName";
                cmbCategory.ValueMember = "CategoryID";
                if (cmbCategory.Items.Count > 0) cmbCategory.SelectedIndex = 0;
            }
            catch { }
        }

        private void LoadProducts()
        {
            if (!_isLoaded) return;

            flowProducts.SuspendLayout();
            flowProducts.Controls.Clear();

            try
            {
                string search = txtSearch.Text.Trim();
                int catID = 0;
                if (cmbCategory.SelectedValue != null) int.TryParse(cmbCategory.SelectedValue.ToString(), out catID);
                string sort = cmbSort.SelectedItem?.ToString() ?? "Name: A to Z";

                DataTable dt = DatabaseHelper.GetKioskProducts(search, catID, sort, _currentBranchID);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        flowProducts.Controls.Add(CreateProductCard(row));
                    }
                }
                else
                {
                    Label l = new Label
                    {
                        Text = "No products found available at this branch.",
                        Font = new Font("Segoe UI", 16),
                        AutoSize = true,
                        ForeColor = Color.DimGray,
                        Margin = new Padding(40)
                    };
                    flowProducts.Controls.Add(l);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message);
            }
            finally
            {
                flowProducts.ResumeLayout();
            }
        }

        private Panel CreateProductCard(DataRow row)
        {
            Panel card = new Panel
            {
                Width = 230,
                Height = 320,
                BackColor = Color.White,
                Margin = new Padding(15),
                Cursor = Cursors.Hand,
                BorderStyle = BorderStyle.FixedSingle
            };

            PictureBox pic = new PictureBox
            {
                Width = 210,
                Height = 190,
                Location = new Point(9, 10),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.WhiteSmoke
            };

            string imgPath = row["ProductImagePath"].ToString();
            if (File.Exists(imgPath)) pic.Image = Image.FromFile(imgPath);

            Label lblName = new Label
            {
                Text = row["ProductName"].ToString(),
                Location = new Point(5, 210),
                Width = 218,
                Height = 45,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                TextAlign = ContentAlignment.TopCenter,
                AutoEllipsis = true
            };

            Label lblPrice = new Label
            {
                Text = $"Starts: ৳ {Convert.ToDecimal(row["MinPrice"]):N0}",
                Location = new Point(5, 260),
                Width = 218,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.SeaGreen,
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label lblCat = new Label
            {
                Text = row["CategoryName"].ToString(),
                Location = new Point(5, 290),
                Width = 218,
                Font = new Font("Segoe UI", 8),
                ForeColor = Color.Gray,
                TextAlign = ContentAlignment.MiddleCenter
            };

            EventHandler openDetails = (s, e) =>
            {
                int pid = Convert.ToInt32(row["ProductID"]);
                string pname = row["ProductName"].ToString();
                string pImg = row["ProductImagePath"].ToString();


                using (var d = new ProductDetailsDialog(pid, pname, pImg, _currentBranchID))
                {
                    d.ShowDialog();
                }
            };

            card.Click += openDetails; pic.Click += openDetails; lblName.Click += openDetails;
            card.Controls.AddRange(new Control[] { pic, lblName, lblPrice, lblCat });
            return card;
        }


        private void lblLogo_DoubleClick(object sender, EventArgs e)
        {
            using (var pass = new PasswordDialog())
            {
                pass.ShowDialog();
                if (pass.IsAuthorized)
                {

                    using (var settings = new SettingsDialog(_currentBranchID))
                    {
                        settings.ShowDialog();


                        if (settings.RequestExit)
                        {
                            Application.Exit();
                        }

                        if (settings.SelectedBranchID != -1 && settings.SelectedBranchID != _currentBranchID)
                        {
                            _currentBranchID = settings.SelectedBranchID;
                            MessageBox.Show($"Kiosk is now set to Branch #{_currentBranchID}");
                            LoadProducts();
                        }
                    }
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e) => LoadProducts();
        private void txtSearch_KeyDown(object sender, KeyEventArgs e) { if (e.KeyCode == Keys.Enter) LoadProducts(); }
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e) => LoadProducts();
        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e) => LoadProducts();
    }
}