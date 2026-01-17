using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Nexus_Retail_ERP.Data;
using Nexus_Retail_ERP.Models;
using Timer = System.Windows.Forms.Timer;

namespace Nexus_Retail_ERP.Forms
{
    public partial class InventoryManagementForm : Form
    {
        // =========================================================
        // UI Colors
        // =========================================================
        private readonly Color clrBackground = Color.FromArgb(38, 42, 50);
        private readonly Color clrCard = Color.FromArgb(255, 255, 255);
        private readonly Color clrAccent = Color.FromArgb(0, 180, 216);
        private readonly Color clrTextDark = Color.FromArgb(45, 45, 48);

        private int _selectedInventoryID = 0;
        private int _selectedBranchID = 0;
        private Timer fadeTimer;

        // Filtering the "New Product" dropdown
        private BindingSource _newProductSource = new BindingSource();

        public InventoryManagementForm()
        {
            InitializeComponent();
            ApplySafeStyling();
            SetupSafeEvents();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            try
            {
                if (SessionDetails.CurrentUserID == 0)
                {
                    System.Diagnostics.Debug.WriteLine("Warning: Logged in as Guest.");
                }

                LoadBranches();
                RefreshMainGrid();
                LoadUnregisteredProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Startup Error");
            }

            this.Opacity = 0;
            fadeTimer = new Timer { Interval = 15 };
            fadeTimer.Tick += (s, args) =>
            {
                if (Opacity < 1) Opacity += 0.05;
                else fadeTimer.Stop();
            };
            fadeTimer.Start();
        }

        // =========================================================
        // DATA LOAD
        // =========================================================
        private void LoadBranches()
        {
            try
            {
                var branches = DatabaseHelper.GetAllBranches(false);
                cmbBranchFilter.Items.Clear();

                if (SessionDetails.CurrentUserRole == "Owner")
                {
                    cmbBranchFilter.Items.Add(new BranchInfo { BranchID = 0, BranchName = "All Branches" });
                }

                foreach (var b in branches) cmbBranchFilter.Items.Add(b);

                cmbBranchFilter.DisplayMember = "BranchName";
                cmbBranchFilter.ValueMember = "BranchID";

                if (cmbBranchFilter.Items.Count > 0)
                    cmbBranchFilter.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Branch Load Error: " + ex.Message);
            }
        }

        private void RefreshMainGrid()
        {
            try
            {
                if (cmbBranchFilter.SelectedItem is BranchInfo b)
                    _selectedBranchID = b.BranchID;

                string search = txtSearch.Text.Trim();

                DataTable dt = DatabaseHelper.GetInventoryData(_selectedBranchID, search);
                dgvInventory.DataSource = dt;

                string[] hiddenCols = { "InventoryID", "ProductID", "VariantID", "BranchID" };
                foreach (var col in hiddenCols)
                    if (dgvInventory.Columns.Contains(col)) dgvInventory.Columns[col].Visible = false;

                foreach (DataGridViewRow row in dgvInventory.Rows)
                {
                    int current = GetSafeInt(row.Cells["CurrentStock"].Value);
                    int limit = GetSafeInt(row.Cells["LowStockLimit"].Value);

                    if (current <= 0)
                        row.DefaultCellStyle.ForeColor = Color.Red;
                    else if (current <= limit)
                        row.DefaultCellStyle.ForeColor = Color.OrangeRed;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Grid Error: " + ex.Message);
            }
        }

        // =========================================================
        // REGISTER NEW ITEM
        // =========================================================
        private void LoadUnregisteredProducts()
        {
            try
            {
                if (_selectedBranchID == 0)
                {
                    cmbNewProducts.DataSource = null;
                    txtRegisterFilter.Enabled = false;
                    btnRegister.Enabled = false;
                    return;
                }

                txtRegisterFilter.Enabled = true;
                btnRegister.Enabled = true;

                DataTable dt = DatabaseHelper.GetMissingProducts(_selectedBranchID);

                _newProductSource.DataSource = dt;

                cmbNewProducts.DataSource = _newProductSource;
                cmbNewProducts.DisplayMember = "FullProductName";
                cmbNewProducts.ValueMember = "VariantID";
                cmbNewProducts.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Product Load Error: " + ex.Message);
            }
        }

        private void FilterNewProducts()
        {
            try
            {
                string filterText = txtRegisterFilter.Text.Trim().Replace("'", "''");
                if (string.IsNullOrEmpty(filterText))
                    _newProductSource.RemoveFilter();
                else
                    _newProductSource.Filter = $"FullProductName LIKE '%{filterText}%'";
            }
            catch { }
        }

        // =========================================================
        // ACTIONS
        // =========================================================
        private void UpdateStock()
        {
            if (_selectedInventoryID == 0)
            {
                MessageBox.Show("Please select an item from the grid.");
                return;
            }

            if (int.TryParse(txtQuantity.Text, out int qty) && qty != 0)
            {
                string reason = string.IsNullOrWhiteSpace(txtReason.Text) ? "Manual Update" : txtReason.Text;

                if (DatabaseHelper.AdjustStock(_selectedInventoryID, qty, reason, SessionDetails.CurrentUserID))
                {
                    RefreshMainGrid();
                    txtQuantity.Clear();
                    txtReason.Clear();
                    MessageBox.Show("Stock Updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Update Failed. Check Audit Logs.", "Error");
                }
            }
            else
            {
                MessageBox.Show("Enter valid quantity (+ to add, - to remove).");
            }
        }

        private void SetLimit()
        {
            if (_selectedInventoryID == 0) return;

            if (int.TryParse(txtLimit.Text, out int limit) && limit >= 0)
            {
                if (DatabaseHelper.UpdateLowStockLimit(_selectedInventoryID, limit))
                {
                    RefreshMainGrid();
                    MessageBox.Show("Alert limit updated.");
                }
            }
            else
            {
                MessageBox.Show("Enter a valid positive number.");
            }
        }

        private void RegisterNewItem()
        {
            if (_selectedBranchID == 0 || cmbNewProducts.SelectedValue == null)
            {
                MessageBox.Show("Please select a branch and a product.");
                return;
            }

            try
            {
                int variantID = Convert.ToInt32(cmbNewProducts.SelectedValue);
                DataRowView row = (DataRowView)cmbNewProducts.SelectedItem;
                int productID = Convert.ToInt32(row["ProductID"]);

                if (DatabaseHelper.RegisterInventoryItem(productID, variantID, _selectedBranchID))
                {
                    MessageBox.Show("Item Added!");
                    RefreshMainGrid();
                    LoadUnregisteredProducts();
                    txtRegisterFilter.Clear();
                }
                else
                {
                    MessageBox.Show("Failed to add item.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Registration Error: " + ex.Message);
            }
        }

        // =========================================================
        // HELPER
        // =========================================================
        private int GetSafeInt(object value)
        {
            if (value == null || value == DBNull.Value) return 0;
            if (int.TryParse(value.ToString(), out int result)) return result;
            return 0;
        }

        // =========================================================
        // UI EVENTS
        // =========================================================
        private void SetupSafeEvents()
        {
            // Close Button
            btnClose.Click += (s, e) =>
            {
                Form mainForm = new OwnerDashboard();
                this.Hide();
                mainForm.FormClosed += (s, args) => this.Close();
                mainForm.Show();
            };

            // Dragging
            this.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
            };

            // Filters
            btnSearch.Click += (s, e) => RefreshMainGrid();
            txtSearch.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) RefreshMainGrid(); };

            cmbBranchFilter.SelectedIndexChanged += (s, e) =>
            {
                RefreshMainGrid();
                LoadUnregisteredProducts();
            };

            txtRegisterFilter.TextChanged += (s, e) => FilterNewProducts();

            dgvInventory.CellClick += (s, e) =>
            {
                if (e.RowIndex >= 0 && e.RowIndex < dgvInventory.RowCount)
                {
                    var row = dgvInventory.Rows[e.RowIndex];

                    _selectedInventoryID = GetSafeInt(row.Cells["InventoryID"].Value);

                    string prodName = row.Cells["ProductName"].Value?.ToString();
                    string varName = row.Cells["VariantName"].Value?.ToString();

                    lblSelectedName.Text = $"{prodName} [{varName}]";
                    lblCurrentStock.Text = row.Cells["CurrentStock"].Value?.ToString() ?? "0";
                    txtLimit.Text = row.Cells["LowStockLimit"].Value?.ToString() ?? "0";

                    pnlManage.Enabled = true;
                    tabControlActions.SelectedTab = tabManage;
                }
            };

            // Buttons
            btnAddStock.Click += (s, e) => UpdateStock();
            btnSetLimit.Click += (s, e) => SetLimit();
            btnRegister.Click += (s, e) => RegisterNewItem();
        }

        private void ApplySafeStyling()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(1150, 700);
            this.BackColor = clrBackground;
            this.DoubleBuffered = true;

            StyleButton(btnAddStock, clrAccent);
            StyleButton(btnSetLimit, Color.DimGray);
            StyleButton(btnRegister, Color.SeaGreen);
            StyleButton(btnSearch, clrAccent);

            // Grid Styles
            dgvInventory.BackgroundColor = Color.WhiteSmoke;
            dgvInventory.BorderStyle = BorderStyle.None;
            dgvInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInventory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInventory.ReadOnly = true;
            dgvInventory.RowHeadersVisible = false;
            dgvInventory.AllowUserToAddRows = false;
        }

        private void StyleButton(Button btn, Color bg)
        {
            btn.BackColor = bg;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;
            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        }

        // Native Dragging
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
    }
}