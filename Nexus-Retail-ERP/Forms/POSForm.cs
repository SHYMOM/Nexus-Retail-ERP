using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Nexus_Retail_ERP.Data;
using Nexus_Retail_ERP.Models;
using Nexus_Retail_ERP.Dialogs;
using Timer = System.Windows.Forms.Timer;

namespace Nexus_Retail_ERP.Forms
{
    public partial class POSForm : Form
    {
        // =========================================================
        // UI COLORS
        // =========================================================
        private readonly Color clrBackground = Color.FromArgb(38, 42, 50);
        private readonly Color clrCard = Color.White;
        private readonly Color clrAccent = Color.FromArgb(0, 180, 216);
        private readonly Color clrSuccess = Color.FromArgb(34, 197, 94);

        private int _currentBranchID;
        private int? _currentCustomerID = null;
        private int _customerPoints = 0;
        private bool _isBirthdayToday = false;
        private DataTable _cartTable;
        private Timer fadeTimer;

        private CheckBox chkRedeemPoints;
        private CheckBox chkBirthdayDisc;

        public POSForm()
        {
            InitializeComponent();
            ApplyNexusStyling();
            InitializeDiscountControls();
            InitializeCart();
            SetupEventHandlers();

            _currentBranchID = DatabaseHelper.GetBranchIDByUserID(SessionDetails.CurrentUserID);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            lblTitle.Text = $"NEXUS POS | Branch : {DatabaseHelper.GetBranchNameByID(_currentBranchID)}";
            LoadProducts("");

            // Fade In
            this.Opacity = 0;
            fadeTimer = new Timer { Interval = 15 };
            fadeTimer.Tick += (s, args) => { if (Opacity < 1) Opacity += 0.05; else fadeTimer.Stop(); };
            fadeTimer.Start();
        }

        private void InitializeDiscountControls()
        {
            chkRedeemPoints = new CheckBox
            {
                Text = "Redeem Points (0)",
                Location = new Point(20, 90),
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.DimGray,
                Enabled = false,
                Cursor = Cursors.Hand
            };

            chkBirthdayDisc = new CheckBox
            {
                Text = "🎂 Birthday Discount (5%)",
                Location = new Point(20, 120),
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.Purple,
                Visible = false,
                Cursor = Cursors.Hand
            };

            chkRedeemPoints.CheckedChanged += (s, e) => CalculateTotals();
            chkBirthdayDisc.CheckedChanged += (s, e) => CalculateTotals();

            pnlTotals.Controls.Add(chkRedeemPoints);
            pnlTotals.Controls.Add(chkBirthdayDisc);

            lblTotalVal.AutoSize = false;
            lblTotalVal.TextAlign = ContentAlignment.MiddleRight;
            lblTotalVal.Size = new Size(120, 60);
            lblTotalVal.Location = new Point(pnlTotals.Width - 150, 80);
            lblTotalVal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTotalVal.BringToFront();
        }

        // =========================================================
        // CUSTOMER
        // =========================================================
        private void SearchCustomer()
        {
            string phone = txtCustSearch.Text.Trim();
            if (!ValidationHelper.IsValidPhone(phone))
            {
                MessageBox.Show("Invalid Phone Number.\nMust be 11 digits starting with '01'.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustSearch.Focus();
                return;
            }

            DataRow cust = DatabaseHelper.GetCustomerByPhone(phone);
            if (cust != null)
            {
                _currentCustomerID = (int)cust["CustomerID"];
                _customerPoints = cust["LoyaltyPoints"] != DBNull.Value ? Convert.ToInt32(cust["LoyaltyPoints"]) : 0;

                _isBirthdayToday = false;
                if (cust["DOB"] != DBNull.Value)
                {
                    DateTime dob = Convert.ToDateTime(cust["DOB"]);
                    if (dob.Month == DateTime.Now.Month && dob.Day == DateTime.Now.Day)
                        _isBirthdayToday = true;
                }

                pnlCustCard.Visible = true;
                lblCustName.Text = cust["CustomerName"].ToString();
                lblCustPhone.Text = phone;
                lblPoints.Text = _customerPoints.ToString();

                chkRedeemPoints.Text = $"Redeem Points ({_customerPoints})";
                chkRedeemPoints.Enabled = _customerPoints > 0;
                chkRedeemPoints.Checked = false;

                chkBirthdayDisc.Visible = _isBirthdayToday;
                chkBirthdayDisc.Checked = false;

                if (_isBirthdayToday) MessageBox.Show("🎉 Birthday Discount Available!", "Customer Alert");

                CalculateTotals();
            }
            else
            {
                if (MessageBox.Show("Customer not found. Register new?", "Search", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    AddNewCustomer();
                }
                else
                {
                    ResetCustomer();
                }
            }
        }

        private void ResetCustomer()
        {
            _currentCustomerID = null;
            _customerPoints = 0;
            pnlCustCard.Visible = false;
            txtCustSearch.Clear();
            chkRedeemPoints.Checked = false;
            chkRedeemPoints.Enabled = false;
            chkRedeemPoints.Text = "Redeem Points (0)";
            chkBirthdayDisc.Checked = false;
            chkBirthdayDisc.Visible = false;
            CalculateTotals();
        }

        private void AddNewCustomer()
        {
            using (var dialog = new AddCustomerDialog(txtCustSearch.Text.Trim()))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtCustSearch.Text = dialog.NewPhone;
                    SearchCustomer();
                }
            }
        }

        // =========================================================
        // PRODUCTS
        // =========================================================
        private void LoadProducts(string search)
        {
            flowProducts.Controls.Clear();
            flowProducts.SuspendLayout();

            DataTable dt = DatabaseHelper.GetPOSProducts(_currentBranchID, search);

            foreach (DataRow row in dt.Rows)
            {
                string name = row["ProductName"].ToString();
                string variant = row["VariantName"].ToString();
                decimal price = Convert.ToDecimal(row["SalesPrice"]);
                int stock = Convert.ToInt32(row["CurrentStock"]);
                decimal tax = Convert.ToDecimal(row["TaxRate"]);
                int varID = Convert.ToInt32(row["VariantID"]);
                string imgPath = row["ProductImagePath"].ToString();
                bool isOutOfStock = stock <= 0;

                // Build Card
                Panel card = new Panel
                {
                    Size = new Size(160, 220),
                    BackColor = Color.White,
                    Margin = new Padding(10),
                    Cursor = Cursors.Hand
                };

                PictureBox pic = new PictureBox
                {
                    Size = new Size(160, 120),
                    Location = new Point(0, 0),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BackColor = Color.WhiteSmoke
                };

                if (!string.IsNullOrEmpty(imgPath) && File.Exists(imgPath))
                {
                    try
                    {
                        pic.Image = Image.FromFile(imgPath);
                    }
                    catch
                    {

                    }
                }

                Label lblName = new Label
                {
                    Text = name,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    Location = new Point(5, 125),
                    AutoSize = true
                };

                Label lblVar = new Label
                {
                    Text = variant,
                    Font = new Font("Segoe UI", 9),
                    Location = new Point(5, 145),
                    AutoSize = true,
                    ForeColor = Color.Gray
                };

                Label lblPrice = new Label
                {
                    Text = $"৳ {price:N0}",
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    Location = new Point(5, 170),
                    AutoSize = true,
                    ForeColor = clrAccent
                };

                Label lblStock = new Label
                {
                    Location = new Point(5, 195),
                    AutoSize = true,
                    Font = new Font("Segoe UI", 8, FontStyle.Bold)
                };

                if (isOutOfStock)
                {
                    lblStock.Text = "OUT OF STOCK"; lblStock.ForeColor = Color.Red; card.BackColor = Color.FromArgb(255, 235, 235);
                }
                else
                {
                    lblStock.Text = $"Stock: {stock}"; lblStock.ForeColor = Color.SeaGreen;
                }

                card.Controls.AddRange(new Control[] { pic, lblName, lblVar, lblPrice, lblStock });

                EventHandler click = (s, e) =>
                {
                    if (isOutOfStock)
                    {
                        if (MessageBox.Show("Item Out of Stock.\nRequest from another branch?", "Stock Alert", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            using (var req = new StockRequestDialog(varID, name, 5, _currentBranchID))
                            {
                                if (req.ShowDialog() == DialogResult.OK)
                                {
                                    bool sent = DatabaseHelper.SendTransferRequest(_currentBranchID, req.SelectedBranchID, varID, req.RequestedQty, SessionDetails.CurrentUserID);
                                    MessageBox.Show(sent ? "Request Sent!" : "Failed.");
                                }
                            }
                        }
                    }
                    else
                    {
                        int q = 1; int.TryParse(txtInputQty.Text, out q);
                        AddToCart(varID, $"{name} ({variant})", price, tax, stock, q);
                        txtInputQty.Text = "1";
                    }
                };

                card.Click += click; foreach (Control c in card.Controls) c.Click += click;
                flowProducts.Controls.Add(card);
            }
            flowProducts.ResumeLayout();
        }

        // =========================================================
        // CART
        // =========================================================
        private void InitializeCart()
        {
            _cartTable = new DataTable();
            _cartTable.Columns.Add("VariantID", typeof(int));
            _cartTable.Columns.Add("Product", typeof(string));
            _cartTable.Columns.Add("Price", typeof(decimal));
            _cartTable.Columns.Add("Qty", typeof(int));
            _cartTable.Columns.Add("TaxRate", typeof(decimal));
            _cartTable.Columns.Add("Total", typeof(decimal));
            dgvCart.DataSource = _cartTable;

            dgvCart.Columns["VariantID"].Visible = false;
            dgvCart.Columns["TaxRate"].Visible = false;
            dgvCart.Columns["Product"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCart.Columns["Qty"].Width = 50;
            dgvCart.Columns["Price"].Width = 70;
            dgvCart.Columns["Total"].Width = 80;

            dgvCart.ReadOnly = false;
            dgvCart.Columns["Product"].ReadOnly = true;
            dgvCart.Columns["Price"].ReadOnly = true;
            dgvCart.Columns["Total"].ReadOnly = true;
        }

        private void AddToCart(int varID, string name, decimal price, decimal taxRate, int maxStock, int qtyToAdd)
        {
            int current = 0;
            foreach (DataRow r in _cartTable.Rows) if ((int)r["VariantID"] == varID) { current = (int)r["Qty"]; break; }

            int totalNeeded = current + qtyToAdd;

            if (totalNeeded > maxStock)
            {
                int missing = totalNeeded - maxStock;
                if (MessageBox.Show($"Need {totalNeeded}, have {maxStock}.\nRequest missing {missing}?", "Stock Check", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (var req = new StockRequestDialog(varID, name, missing, _currentBranchID))
                    {
                        if (req.ShowDialog() == DialogResult.OK)
                        {
                            DatabaseHelper.SendTransferRequest(_currentBranchID, req.SelectedBranchID, varID, req.RequestedQty, SessionDetails.CurrentUserID);
                            MessageBox.Show("Request Sent!");
                        }
                    }
                }
                return;
            }

            bool found = false;
            foreach (DataRow row in _cartTable.Rows)
            {
                if ((int)row["VariantID"] == varID)
                {
                    row["Qty"] = totalNeeded;
                    row["Total"] = totalNeeded * price;
                    found = true; break;
                }
            }
            if (!found) _cartTable.Rows.Add(varID, name, price, qtyToAdd, taxRate, price * qtyToAdd);
            CalculateTotals();
        }

        private void CalculateTotals()
        {
            decimal subtotal = 0;
            decimal totalTax = 0;

            foreach (DataRow row in _cartTable.Rows)
            {
                decimal p = Convert.ToDecimal(row["Price"]);
                int q = Convert.ToInt32(row["Qty"]);
                decimal t = Convert.ToDecimal(row["TaxRate"]);
                subtotal += p * q;
                totalTax += (p * q) * (t / 100);
            }

            decimal gross = subtotal + totalTax;
            decimal discount = 0;

            if (chkBirthdayDisc.Checked) discount = subtotal * 0.05m;

            decimal payBeforePoints = gross - discount;
            decimal pointsUsed = 0;

            if (chkRedeemPoints.Checked && _customerPoints > 0)
            {
                pointsUsed = (_customerPoints >= payBeforePoints) ? payBeforePoints : _customerPoints;
            }

            decimal final = payBeforePoints - pointsUsed;

            lblSubtotalVal.Text = subtotal.ToString("N2");
            lblTaxVal.Text = totalTax.ToString("N2");
            lblTotalVal.Text = "৳ " + final.ToString("N0");
        }

        private void ProcessPayment()
        {
            if (_cartTable.Rows.Count == 0) return;

            decimal finalPayable = decimal.Parse(lblTotalVal.Text.Replace("৳ ", ""));
            decimal sub = decimal.Parse(lblSubtotalVal.Text);
            decimal tax = decimal.Parse(lblTaxVal.Text);
            decimal gross = sub + tax;

            decimal discount = chkBirthdayDisc.Checked ? (sub * 0.05m) : 0;
            decimal pointsVal = 0;

            decimal calcPay = gross - discount;
            if (chkRedeemPoints.Checked) pointsVal = calcPay - finalPayable;

            int pointsUsedInt = (int)pointsVal;

            string method = "Cash"; string refInfo = "";

            if (finalPayable > 0)
            {
                using (var pd = new PaymentDialog(finalPayable))
                {
                    if (pd.ShowDialog() == DialogResult.OK)
                    {
                        method = pd.SelectedMethod; refInfo = pd.ReferenceInfo;
                    }
                    else return;
                }
            }
            else
            {
                method = "Loyalty Points";
                if (MessageBox.Show("Pay fully with Points?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.No) return;
            }

            string inv;
            bool ok = DatabaseHelper.SaveTransaction(
                _currentBranchID, SessionDetails.CurrentUserID, _currentCustomerID,
                gross, discount, pointsUsedInt, finalPayable, tax,
                _cartTable, method, refInfo, out inv
            );

            if (ok)
            {
                MessageBox.Show($"Paid: {finalPayable:N2}\nMethod: {method}\nInvoice: {inv}", "Success");
                ResetPOS();
            }
            else
            {
                MessageBox.Show("Transaction Failed. Check User ID / DB.");
            }
        }

        private void ResetPOS()
        {
            _cartTable.Rows.Clear();
            ResetCustomer();
            CalculateTotals();
            LoadProducts("");
        }

        // =========================================================
        // SETUP & STYLING
        // =========================================================
        private void SetupEventHandlers()
        {
            btnClose.Click += (s, e) => Close();
            btnSearchCust.Click += (s, e) => SearchCustomer();
            txtCustSearch.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) SearchCustomer(); };
            btnAddCust.Click += (s, e) => AddNewCustomer();
            btnPay.Click += (s, e) => ProcessPayment();
            txtProdSearch.TextChanged += (s, e) => LoadProducts(txtProdSearch.Text.Trim());

            dgvCart.CellValueChanged += (s, e) =>
            {
                if (e.RowIndex >= 0 && dgvCart.Columns[e.ColumnIndex].Name == "Qty")
                {
                    try
                    {
                        int q = Convert.ToInt32(dgvCart.Rows[e.RowIndex].Cells["Qty"].Value);
                        decimal p = Convert.ToDecimal(dgvCart.Rows[e.RowIndex].Cells["Price"].Value);
                        if (q < 1) q = 1;
                        dgvCart.Rows[e.RowIndex].Cells["Qty"].Value = q;
                        dgvCart.Rows[e.RowIndex].Cells["Total"].Value = q * p;
                        CalculateTotals();
                    }
                    catch { }
                }
            };
            dgvCart.CurrentCellDirtyStateChanged += (s, e) => { if (dgvCart.IsCurrentCellDirty) dgvCart.CommitEdit(DataGridViewDataErrorContexts.Commit); };
            dgvCart.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex < 0 || e.RowIndex >= dgvCart.Rows.Count) return;

                try
                {
                    DataRowView drv = dgvCart.Rows[e.RowIndex].DataBoundItem as DataRowView;

                    if (drv != null)
                    {
                        drv.Row.Delete();
                        CalculateTotals();
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Remove Error: " + ex.Message);
                }
            };
            pnlHeader.MouseDown += (s, e) => { if (e.Button == MouseButtons.Left) { ReleaseCapture(); SendMessage(Handle, 0xA1, 0x2, 0); } };
        }

        private void ApplyNexusStyling()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(1280, 768);
            this.BackColor = clrBackground;
            pnlLeft.BackColor = clrBackground; pnlMiddle.BackColor = clrBackground; pnlRight.BackColor = clrBackground;
            pnlCustCard.BackColor = clrCard; pnlCartCard.BackColor = clrCard; flowProducts.BackColor = Color.FromArgb(240, 240, 245);
            dgvCart.BackgroundColor = Color.White; dgvCart.BorderStyle = BorderStyle.None; dgvCart.RowHeadersVisible = false;

            StyleButton(btnSearchCust, clrAccent);
            StyleButton(btnPay, clrSuccess);
            StyleButton(btnAddCust, Color.Gray);
            StyleButton(btnClose, Color.IndianRed);
        }

        private void StyleButton(Button btn, Color bg)
        {
            btn.BackColor = bg; btn.ForeColor = Color.White; btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0; btn.Cursor = Cursors.Hand; btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        }

        [DllImport("user32.dll")] public static extern bool ReleaseCapture();
        [DllImport("user32.dll")] public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
    }
}
