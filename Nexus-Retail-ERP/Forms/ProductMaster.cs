using Nexus_Retail_ERP.Data;
using Nexus_Retail_ERP.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Nexus_Retail_ERP.Forms
{
    public partial class ProductMaster : Form
    {
        private List<Product> products;
        private List<Category> categories;
        private List<Variant> variants;
        private int currentProductId = 0;
        private int currentVariantId = 0;
        private bool isEditMode = false;
        private bool isVariantEditMode = false;
        private string selectedImagePath = "";
        private string selectedVariantImagePath = "";
        private bool isLoading = false;

        public ProductMaster()
        {
            InitializeComponent();
            this.Opacity = 0;
        }

        private void ProductMaster_Load(object sender, EventArgs e)
        {
            ConfigureProductDataGrid();
            ConfigureVariantDataGrid();
            LoadCategories();
            LoadProducts();
            timerFadeIn.Start();

            btnActivateVariant.Visible = false;
            btnDeactivateVariant.Visible = false;

            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnEditVariant.Enabled = false;
            btnDeleteVariant.Enabled = false;

            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVariants.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void ConfigureProductDataGrid()
        {
            dgvProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 166, 178);
            dgvProducts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvProducts.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvProducts.ColumnHeadersHeight = 35;
            dgvProducts.EnableHeadersVisualStyles = false;
            dgvProducts.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvProducts.DefaultCellStyle.ForeColor = Color.FromArgb(50, 50, 50);
            dgvProducts.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 240, 240);
            dgvProducts.DefaultCellStyle.SelectionForeColor = Color.FromArgb(50, 50, 50);
            dgvProducts.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250);
            dgvProducts.RowTemplate.Height = 30;
            dgvProducts.BorderStyle = BorderStyle.None;
            dgvProducts.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvProducts.GridColor = Color.FromArgb(230, 230, 230);
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvProducts.Columns.Clear();
            dgvProducts.Columns.Add("ProductID", "ID");
            dgvProducts.Columns.Add("ProductName", "Product Name");
            dgvProducts.Columns.Add("Category", "Category");
            dgvProducts.Columns.Add("Variants", "Variants");
            dgvProducts.Columns.Add("TaxRate", "Tax Rate %");
            dgvProducts.Columns.Add("Status", "Status");
            dgvProducts.Columns.Add("HasImage", "Image");

            dgvProducts.Columns["ProductID"].Width = 60;
            dgvProducts.Columns["ProductName"].Width = 180;
            dgvProducts.Columns["Category"].Width = 130;
            dgvProducts.Columns["Variants"].Width = 80;
            dgvProducts.Columns["TaxRate"].Width = 90;
            dgvProducts.Columns["Status"].Width = 90;
            dgvProducts.Columns["HasImage"].Width = 70;

            dgvProducts.Columns["TaxRate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProducts.Columns["Variants"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProducts.Columns["HasImage"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void ConfigureVariantDataGrid()
        {
            dgvVariants.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 166, 178);
            dgvVariants.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvVariants.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvVariants.ColumnHeadersHeight = 30;
            dgvVariants.EnableHeadersVisualStyles = false;
            dgvVariants.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvVariants.DefaultCellStyle.ForeColor = Color.FromArgb(50, 50, 50);
            dgvVariants.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 240, 240);
            dgvVariants.DefaultCellStyle.SelectionForeColor = Color.FromArgb(50, 50, 50);
            dgvVariants.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250);
            dgvVariants.RowTemplate.Height = 28;
            dgvVariants.BorderStyle = BorderStyle.None;
            dgvVariants.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvVariants.GridColor = Color.FromArgb(230, 230, 230);
            dgvVariants.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvVariants.Columns.Clear();
            dgvVariants.Columns.Add("VariantID", "ID");
            dgvVariants.Columns.Add("VariantName", "Variant Name");
            dgvVariants.Columns.Add("UOM", "UOM");
            dgvVariants.Columns.Add("CostPrice", "Cost Price");
            dgvVariants.Columns.Add("SalesPrice", "Sales Price");
            dgvVariants.Columns.Add("SKU", "SKU/Barcode");

            dgvVariants.Columns["VariantID"].Width = 50;
            dgvVariants.Columns["VariantName"].Width = 150;
            dgvVariants.Columns["UOM"].Width = 70;
            dgvVariants.Columns["CostPrice"].Width = 90;
            dgvVariants.Columns["SalesPrice"].Width = 90;
            dgvVariants.Columns["SKU"].Width = 120;

            dgvVariants.Columns["CostPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvVariants.Columns["SalesPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void LoadCategories()
        {
            try
            {
                categories = ProductMasterHelper.GetAllCategories();

                cmbCategory.DataSource = categories;
                cmbCategory.DisplayMember = "CategoryName";
                cmbCategory.ValueMember = "CategoryID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load categories: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProducts()
        {
            try
            {
                isLoading = true;
                dgvProducts.ClearSelection();

                products = ProductMasterHelper.GetAllProducts();

                dgvProducts.Rows.Clear();
                foreach (var product in products)
                {
                    int rowIndex = dgvProducts.Rows.Add(
                        product.ProductID,
                        product.ProductName,
                        product.CategoryName,
                        product.VariantCount,
                        product.TaxRate,
                        product.IsActive ? "Active" : "Inactive",
                        !string.IsNullOrEmpty(product.ProductImagePath) ? "📷 Yes" : "❌ No"
                    );

                    dgvProducts.Rows[rowIndex].Cells["Status"].Style.ForeColor =
                        product.IsActive ? Color.FromArgb(76, 175, 80) : Color.FromArgb(244, 67, 54);
                }

                lblTotalProducts.Text = $"Total Products: {products.Count}";

                if (products.Count > 0 && currentProductId == 0)
                {
                    dgvProducts.Rows[0].Selected = true;
                    currentProductId = products[0].ProductID;
                    LoadVariants(currentProductId);
                    pnlVariantContainer.Visible = true;
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load products: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isLoading = false;
            }
        }

        private void LoadVariants(int productId)
        {
            try
            {
                isLoading = true;
                dgvVariants.ClearSelection();

                variants = ProductMasterHelper.GetVariantsByProductId(productId);

                dgvVariants.Rows.Clear();
                foreach (var variant in variants)
                {
                    int rowIndex = dgvVariants.Rows.Add(
                        variant.VariantID,
                        variant.VariantName,
                        variant.UOM,
                        variant.CostPrice.ToString("C"),
                        variant.SalesPrice.ToString("C"),
                        variant.SKU
                    );
                }

                lblTotalVariants.Text = $"Total Variants: {variants.Count}";

                var product = products.Find(p => p.ProductID == productId);
                lblProductVariants.Text = $"Variants for: {product?.ProductName ?? "Selected Product"}";

                btnAddVariant.Enabled = product != null && product.IsActive;

                if (variants.Count > 0)
                {
                    dgvVariants.Rows[0].Selected = true;
                    btnEditVariant.Enabled = true;
                    btnDeleteVariant.Enabled = true;
                }
                else
                {
                    btnEditVariant.Enabled = false;
                    btnDeleteVariant.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load variants: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isLoading = false;
            }
        }

        private void TimerFadeIn_Tick(object sender, EventArgs e)
        {
            this.Opacity += 0.05;
            if (this.Opacity >= 1)
            {
                timerFadeIn.Stop();
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Form mainForm = new OwnerDashboard();
            this.Hide();
            mainForm.FormClosed += (s, args) => this.Close();
            mainForm.Show();
        }

        private void BtnAddNew_Click(object sender, EventArgs e)
        {
            isEditMode = false;
            currentProductId = 0;
            selectedImagePath = "";
            ClearProductForm();
            ShowEditPanel(true);
            txtProductName.Focus();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product to edit.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedRowIndex = dgvProducts.SelectedRows[0].Index;
            int productId = Convert.ToInt32(dgvProducts.Rows[selectedRowIndex].Cells["ProductID"].Value);

            var product = products.Find(p => p.ProductID == productId);
            if (product != null)
            {
                isEditMode = true;
                currentProductId = productId;
                LoadProductData(product);
                ShowEditPanel(true);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product to delete.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this product? This will also delete all its variants. This action cannot be undone.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                int selectedRowIndex = dgvProducts.SelectedRows[0].Index;
                int productId = Convert.ToInt32(dgvProducts.Rows[selectedRowIndex].Cells["ProductID"].Value);

                try
                {
                    bool deleted = ProductMasterHelper.DeleteProduct(productId, SessionDetails.CurrentUserID);

                    if (deleted)
                    {
                        MessageBox.Show("Product deleted successfully.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadProducts();
                        ClearVariantSection();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete product.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to delete product: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateProductForm())
                return;

            try
            {
                var product = new Product
                {
                    ProductID = isEditMode ? currentProductId : 0,
                    ProductName = txtProductName.Text,
                    Description = txtDescription.Text,
                    CategoryID = (int)cmbCategory.SelectedValue,
                    CategoryName = ((Category)cmbCategory.SelectedItem).CategoryName,
                    TaxRate = decimal.Parse(txtTaxRate.Text),
                    IsActive = chkActive.Checked,
                    ProductImagePath = selectedImagePath
                };

                if (isEditMode)
                {
                    bool updated = ProductMasterHelper.UpdateProduct(product, SessionDetails.CurrentUserID);
                    if (updated)
                    {
                        MessageBox.Show("Product updated successfully.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadProducts();
                        ShowEditPanel(false);
                        ClearProductForm();
                    }
                    else
                    {
                        MessageBox.Show("Failed to update product.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    int newId = ProductMasterHelper.AddProduct(product, SessionDetails.CurrentUserID);
                    if (newId > 0)
                    {
                        MessageBox.Show("Product added successfully.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadProducts();
                        ShowEditPanel(false);
                        ClearProductForm();
                    }
                    else
                    {
                        MessageBox.Show("Failed to add product.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save product: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            ShowEditPanel(false);
            ClearProductForm();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadProducts();
            if (currentProductId > 0)
            {
                LoadVariants(currentProductId);
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterProducts();
        }

        private void BtnBrowseImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif; *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = openFileDialog.FileName;

                    try
                    {
                        picProductImage.Image = Image.FromFile(selectedImagePath);
                        lblImageStatus.Text = "✓ Image Selected";
                        lblImageStatus.ForeColor = Color.FromArgb(76, 175, 80);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading image: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        selectedImagePath = "";
                        picProductImage.Image = null;
                        lblImageStatus.Text = "No Image";
                        lblImageStatus.ForeColor = Color.FromArgb(100, 100, 100);
                    }
                }
            }
        }

        private void BtnClearImage_Click(object sender, EventArgs e)
        {
            selectedImagePath = "";
            picProductImage.Image = null;
            lblImageStatus.Text = "No Image";
            lblImageStatus.ForeColor = Color.FromArgb(100, 100, 100);
        }

        private void LoadProductData(Product product)
        {
            txtProductName.Text = product.ProductName;
            txtDescription.Text = product.Description ?? "";
            txtTaxRate.Text = product.TaxRate.ToString("0.00");
            cmbCategory.SelectedValue = product.CategoryID;
            chkActive.Checked = product.IsActive;

            selectedImagePath = product.ProductImagePath ?? "";
            if (!string.IsNullOrEmpty(selectedImagePath) && File.Exists(selectedImagePath))
            {
                try
                {
                    picProductImage.Image = Image.FromFile(selectedImagePath);
                    lblImageStatus.Text = "✓ Image Loaded";
                    lblImageStatus.ForeColor = Color.FromArgb(76, 175, 80);
                }
                catch
                {
                    picProductImage.Image = null;
                    lblImageStatus.Text = "Image Not Found";
                    lblImageStatus.ForeColor = Color.FromArgb(255, 152, 0);
                    selectedImagePath = "";
                }
            }
            else
            {
                picProductImage.Image = null;
                lblImageStatus.Text = "No Image";
                lblImageStatus.ForeColor = Color.FromArgb(100, 100, 100);
                selectedImagePath = "";
            }
        }

        private bool ValidateProductForm()
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("Product name is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProductName.Focus();
                return false;
            }

            if (cmbCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a category.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCategory.Focus();
                return false;
            }

            if (!decimal.TryParse(txtTaxRate.Text, out decimal taxRate) || taxRate < 0 || taxRate > 100)
            {
                MessageBox.Show("Please enter a valid tax rate between 0 and 100.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTaxRate.Focus();
                return false;
            }

            return true;
        }

        private void ClearProductForm()
        {
            txtProductName.Clear();
            txtDescription.Clear();
            txtTaxRate.Text = "0.00";
            if (cmbCategory.Items.Count > 0)
                cmbCategory.SelectedIndex = 0;
            chkActive.Checked = true;
            txtSearch.Clear();
            selectedImagePath = "";
            picProductImage.Image = null;
            lblImageStatus.Text = "No Image";
            lblImageStatus.ForeColor = Color.FromArgb(100, 100, 100);
        }

        private void ShowEditPanel(bool show)
        {
            pnlEdit.Visible = show;
            pnlList.Visible = !show;

            pnlVariantContainer.Visible = currentProductId > 0;

            lblFormTitle.Text = isEditMode ? "Edit Product" : "Add New Product";
            btnSave.Text = isEditMode ? "Update Product" : "Save Product";
        }

        private void FilterProducts()
        {
            string searchText = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                LoadProducts();
                return;
            }

            dgvProducts.Rows.Clear();
            foreach (var product in products)
            {
                if (product.ProductName.ToLower().Contains(searchText) ||
                    product.CategoryName.ToLower().Contains(searchText) ||
                    (product.Description ?? "").ToLower().Contains(searchText))
                {
                    int rowIndex = dgvProducts.Rows.Add(
                        product.ProductID,
                        product.ProductName,
                        product.CategoryName,
                        product.VariantCount,
                        product.TaxRate,
                        product.IsActive ? "Active" : "Inactive",
                        !string.IsNullOrEmpty(product.ProductImagePath) ? "📷 Yes" : "❌ No"
                    );

                    dgvProducts.Rows[rowIndex].Cells["Status"].Style.ForeColor =
                        product.IsActive ? Color.FromArgb(76, 175, 80) : Color.FromArgb(244, 67, 54);
                }
            }
        }

        private void DgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (isLoading) return;

            bool hasSelection = dgvProducts.SelectedRows.Count > 0;
            btnEdit.Enabled = hasSelection;
            btnDelete.Enabled = hasSelection;

            if (hasSelection)
            {
                try
                {
                    int selectedRowIndex = dgvProducts.SelectedRows[0].Index;

                    if (selectedRowIndex >= 0 && selectedRowIndex < dgvProducts.Rows.Count)
                    {
                        var cellValue = dgvProducts.Rows[selectedRowIndex].Cells["ProductID"].Value;
                        if (cellValue != null)
                        {
                            currentProductId = Convert.ToInt32(cellValue);

                            LoadVariants(currentProductId);
                            pnlVariantContainer.Visible = true;

                            var product = products.Find(p => p.ProductID == currentProductId);
                            btnAddVariant.Enabled = product != null && product.IsActive;
                        }
                    }
                }
                catch (Exception ex)
                {
                    currentProductId = 0;
                    ClearVariantSection();
                }
            }
            else
            {
                currentProductId = 0;
                ClearVariantSection();
            }
        }

        // ==================== VARIANT MANAGEMENT ====================

        private void BtnAddVariant_Click(object sender, EventArgs e)
        {
            if (currentProductId == 0)
            {
                MessageBox.Show("Please select a product first.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            isVariantEditMode = false;
            currentVariantId = 0;
            selectedVariantImagePath = "";
            ClearVariantForm();
            ShowVariantEditPanel(true);
            txtVariantName.Focus();
        }

        private void BtnEditVariant_Click(object sender, EventArgs e)
        {
            if (dgvVariants.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a variant to edit.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedRowIndex = dgvVariants.SelectedRows[0].Index;
            int variantId = Convert.ToInt32(dgvVariants.Rows[selectedRowIndex].Cells["VariantID"].Value);

            var variant = variants.Find(v => v.VariantID == variantId);
            if (variant != null)
            {
                isVariantEditMode = true;
                currentVariantId = variantId;
                LoadVariantData(variant);
                ShowVariantEditPanel(true);
            }
        }

        private void BtnDeleteVariant_Click(object sender, EventArgs e)
        {
            if (dgvVariants.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a variant to delete.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this variant? This will also remove it from inventory. This action cannot be undone.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                int selectedRowIndex = dgvVariants.SelectedRows[0].Index;
                int variantId = Convert.ToInt32(dgvVariants.Rows[selectedRowIndex].Cells["VariantID"].Value);

                try
                {
                    bool deleted = ProductMasterHelper.DeleteVariant(variantId, SessionDetails.CurrentUserID);

                    if (deleted)
                    {
                        MessageBox.Show("Variant deleted successfully.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadVariants(currentProductId);
                        LoadProducts();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete variant.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to delete variant: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnSaveVariant_Click(object sender, EventArgs e)
        {
            if (!ValidateVariantForm())
                return;

            try
            {
                var variant = new Variant
                {
                    VariantID = isVariantEditMode ? currentVariantId : 0,
                    VariantName = txtVariantName.Text,
                    UOM = cmbUOM.Text,
                    CostPrice = decimal.Parse(txtCostPrice.Text),
                    SalesPrice = decimal.Parse(txtSalesPrice.Text),
                    SKU = txtSKU.Text,
                    VariantImagePath = selectedVariantImagePath,
                    ProductID = currentProductId
                };

                if (isVariantEditMode)
                {
                    bool updated = ProductMasterHelper.UpdateVariant(variant, SessionDetails.CurrentUserID);
                    if (updated)
                    {
                        MessageBox.Show("Variant updated successfully.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadVariants(currentProductId);
                        ShowVariantEditPanel(false);
                        ClearVariantForm();

                        pnlVariantContainer.Visible = true;
                        panel1.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("Failed to update variant.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    int newId = ProductMasterHelper.AddVariant(variant, SessionDetails.CurrentUserID);
                    if (newId > 0)
                    {
                        MessageBox.Show("Variant added successfully.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadVariants(currentProductId);
                        ShowVariantEditPanel(false);
                        ClearVariantForm();

                        pnlVariantContainer.Visible = true;
                        panel1.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("Failed to add variant.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save variant: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelVariant_Click(object sender, EventArgs e)
        {
            ShowVariantEditPanel(false);
            ClearVariantForm();

            pnlVariantContainer.Visible = true;
            panel1.Visible = true;
        }

        private void LoadVariantData(Variant variant)
        {
            txtVariantName.Text = variant.VariantName;
            cmbUOM.Text = variant.UOM;
            txtCostPrice.Text = variant.CostPrice.ToString("0.00");
            txtSalesPrice.Text = variant.SalesPrice.ToString("0.00");
            txtSKU.Text = variant.SKU;

            selectedVariantImagePath = variant.VariantImagePath ?? "";
            if (!string.IsNullOrEmpty(selectedVariantImagePath) && File.Exists(selectedVariantImagePath))
            {
                try
                {
                    picVariantImage.Image = Image.FromFile(selectedVariantImagePath);
                    lblVariantImageStatus.Text = "✓ Image Loaded";
                    lblVariantImageStatus.ForeColor = Color.FromArgb(76, 175, 80);
                }
                catch
                {
                    picVariantImage.Image = null;
                    lblVariantImageStatus.Text = "Image Not Found";
                    lblVariantImageStatus.ForeColor = Color.FromArgb(255, 152, 0);
                    selectedVariantImagePath = "";
                }
            }
            else
            {
                picVariantImage.Image = null;
                lblVariantImageStatus.Text = "No Image";
                lblVariantImageStatus.ForeColor = Color.FromArgb(100, 100, 100);
                selectedVariantImagePath = "";
            }
        }

        private bool ValidateVariantForm()
        {
            if (string.IsNullOrWhiteSpace(txtVariantName.Text))
            {
                MessageBox.Show("Variant name is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVariantName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(cmbUOM.Text))
            {
                MessageBox.Show("Unit of Measure is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbUOM.Focus();
                return false;
            }

            if (!decimal.TryParse(txtCostPrice.Text, out decimal costPrice) || costPrice < 0)
            {
                MessageBox.Show("Please enter a valid cost price.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCostPrice.Focus();
                return false;
            }

            if (!decimal.TryParse(txtSalesPrice.Text, out decimal salesPrice) || salesPrice < 0)
            {
                MessageBox.Show("Please enter a valid sales price.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSalesPrice.Focus();
                return false;
            }

            if (salesPrice < costPrice)
            {
                MessageBox.Show("Sales price should be greater than or equal to cost price.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSalesPrice.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSKU.Text))
            {
                MessageBox.Show("SKU/Barcode is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSKU.Focus();
                return false;
            }

            if (!isVariantEditMode || variants.Find(v => v.VariantID == currentVariantId)?.SKU != txtSKU.Text)
            {
                bool skuAvailable = ProductMasterHelper.IsSkuAvailable(txtSKU.Text, currentVariantId);
                if (!skuAvailable)
                {
                    MessageBox.Show("This SKU/Barcode is already in use. Please enter a unique SKU.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSKU.Focus();
                    return false;
                }
            }

            return true;
        }

        private void ClearVariantForm()
        {
            txtVariantName.Clear();
            cmbUOM.SelectedIndex = -1;
            txtCostPrice.Text = "0.00";
            txtSalesPrice.Text = "0.00";
            txtSKU.Clear();
            selectedVariantImagePath = "";
            picVariantImage.Image = null;
            lblVariantImageStatus.Text = "No Image";
            lblVariantImageStatus.ForeColor = Color.FromArgb(100, 100, 100);
        }

        private void ClearVariantSection()
        {
            dgvVariants.Rows.Clear();
            lblTotalVariants.Text = "Total Variants: 0";
            lblProductVariants.Text = "Variants for: No Product Selected";
            pnlVariantContainer.Visible = false;
        }

        private void ShowVariantEditPanel(bool show)
        {
            pnlVariantEdit.Visible = show;

            if (show)
            {
                panel1.Visible = false;
            }
            else
            {
                panel1.Visible = true;
            }

            pnlVariantContainer.Visible = true;

            lblVariantFormTitle.Text = isVariantEditMode ? "Edit Variant" : "Add New Variant";
            btnSaveVariant.Text = isVariantEditMode ? "Update Variant" : "Save Variant";
        }

        private void DgvVariants_SelectionChanged(object sender, EventArgs e)
        {
            if (isLoading) return;

            bool hasSelection = dgvVariants.SelectedRows.Count > 0;
            btnEditVariant.Enabled = hasSelection;
            btnDeleteVariant.Enabled = hasSelection;
        }

        private void BtnBrowseVariantImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif; *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedVariantImagePath = openFileDialog.FileName;

                    try
                    {
                        picVariantImage.Image = Image.FromFile(selectedVariantImagePath);
                        lblVariantImageStatus.Text = "✓ Image Selected";
                        lblVariantImageStatus.ForeColor = Color.FromArgb(76, 175, 80);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading image: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        selectedVariantImagePath = "";
                        picVariantImage.Image = null;
                        lblVariantImageStatus.Text = "No Image";
                        lblVariantImageStatus.ForeColor = Color.FromArgb(100, 100, 100);
                    }
                }
            }
        }

        private void BtnClearVariantImage_Click(object sender, EventArgs e)
        {
            selectedVariantImagePath = "";
            picVariantImage.Image = null;
            lblVariantImageStatus.Text = "No Image";
            lblVariantImageStatus.ForeColor = Color.FromArgb(100, 100, 100);
        }

        private void TxtSearchVariants_TextChanged(object sender, EventArgs e)
        {
            FilterVariants();
        }

        private void FilterVariants()
        {
            string searchText = txtSearchVariants.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                LoadVariants(currentProductId);
                return;
            }

            dgvVariants.Rows.Clear();
            foreach (var variant in variants)
            {
                if (variant.VariantName.ToLower().Contains(searchText) ||
                    variant.SKU.ToLower().Contains(searchText) ||
                    variant.UOM.ToLower().Contains(searchText))
                {
                    int rowIndex = dgvVariants.Rows.Add(
                        variant.VariantID,
                        variant.VariantName,
                        variant.UOM,
                        variant.CostPrice.ToString("C"),
                        variant.SalesPrice.ToString("C"),
                        variant.SKU
                    );
                }
            }
        }

        // ==================== UI EFFECTS ====================

        private void BtnClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.FromArgb(232, 17, 35);
            btnClose.ForeColor = Color.White;
        }

        private void BtnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.Transparent;
            btnClose.ForeColor = Color.FromArgb(200, 200, 200);
        }

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button button && button != btnClose)
            {
                if (button == btnClearImage || button == btnCancel || button == btnDelete ||
                    button == btnClearVariantImage || button == btnCancelVariant ||
                    button == btnDeleteVariant)
                    button.BackColor = Color.FromArgb(200, 50, 40);
                else if (button == btnSave || button == btnSaveVariant)
                    button.BackColor = Color.FromArgb(60, 150, 65);
                else
                    button.BackColor = Color.FromArgb(30, 150, 162);
            }
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button && button != btnClose)
            {
                if (button == btnClearImage || button == btnCancel || button == btnDelete ||
                    button == btnClearVariantImage || button == btnCancelVariant ||
                    button == btnDeleteVariant)
                    button.BackColor = Color.FromArgb(244, 67, 54);
                else if (button == btnSave || button == btnSaveVariant)
                    button.BackColor = Color.FromArgb(76, 175, 80);
                else
                    button.BackColor = Color.FromArgb(45, 166, 178);
            }
        }

        private void DgvProducts_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvProducts.Rows.Count)
            {
                dgvProducts.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(240, 250, 250);
            }
        }

        private void DgvProducts_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvProducts.Rows.Count)
            {
                if (e.RowIndex % 2 == 0)
                {
                    dgvProducts.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
                }
                else
                {
                    dgvProducts.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250);
                }
            }
        }

        private void DgvVariants_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvVariants.Rows.Count)
            {
                dgvVariants.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(240, 250, 250);
            }
        }

        private void DgvVariants_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvVariants.Rows.Count)
            {
                if (e.RowIndex % 2 == 0)
                {
                    dgvVariants.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
                }
                else
                {
                    dgvVariants.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250);
                }
            }
        }
    }
}