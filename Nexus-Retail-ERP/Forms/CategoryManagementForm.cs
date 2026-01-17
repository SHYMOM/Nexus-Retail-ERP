using Nexus_Retail_ERP.Data;
using Nexus_Retail_ERP.Models;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Xml.Linq;
using Timer = System.Windows.Forms.Timer;

namespace Nexus_Retail_ERP.Forms
{
    public partial class CategoryManagementForm : Form
    {
        // =========================================================
        // UI COLORS & CONSTANTS
        // =========================================================
        private readonly Color clrBackground = Color.FromArgb(38, 42, 50);
        private readonly Color clrCard = Color.FromArgb(255, 255, 255);
        private readonly Color clrAccent = Color.FromArgb(0, 180, 216);
        private readonly Color clrTextDark = Color.FromArgb(45, 45, 48);
        private readonly Color clrError = Color.FromArgb(239, 68, 68);

        private int _selectedCategoryID = 0;
        private Timer fadeTimer;

        public CategoryManagementForm()
        {
            InitializeComponent();
            ApplyModernStyling();
            SetupEventHandlers();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            RefreshCategoryList();
            fadeTimer.Start();
        }

        // =========================================================
        // DATA LOGIC
        // =========================================================
        private void RefreshCategoryList()
        {
            try
            {
                List<Category> categories = DatabaseHelper.GetAllCategories();
                DataTable dt = new DataTable();
                dt.Columns.Add("CategoryID", typeof(int));
                dt.Columns.Add("CategoryName", typeof(string));
                foreach (Category category in categories)
                {
                    dt.Rows.Add(category.CategoryID, category.CategoryName);
                }

                dgvCategories.DataSource = dt;

                if (dgvCategories.Columns["CategoryID"] != null)
                    dgvCategories.Columns["CategoryID"].Visible = false;

                if (dgvCategories.Columns["CategoryName"] != null)
                    dgvCategories.Columns["CategoryName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                ClearInputForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message);
            }
        }

        private void SaveCategory()
        {
            string name = txtName.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Category Name cannot be empty.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool success = false;
                string message = "";

                if (_selectedCategoryID == 0)
                {
                    success = DatabaseHelper.AddCategory(name);
                    message = "Category added successfully!";
                }
                else
                {
                    success = DatabaseHelper.UpdateCategory(_selectedCategoryID, name);
                    message = "Category updated successfully!";
                }

                if (success)
                {
                    MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshCategoryList();
                }
                else
                {
                    MessageBox.Show("Operation failed. Database error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving category: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteCategory()
        {
            if (_selectedCategoryID == 0) return;

            var result = MessageBox.Show(
                $"Are you sure you want to delete the category '{txtName.Text}'?\nThis might affect products linked to it.",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool success = DatabaseHelper.DeleteCategory(_selectedCategoryID);

                    if (success)
                    {
                        MessageBox.Show("Category deleted.", "Success");
                        RefreshCategoryList();
                    }
                    else
                    {
                        MessageBox.Show("Could not delete. It might be in use by products.", "Error");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Delete failed: " + ex.Message);
                }
            }
        }

        // =========================================================
        // UI INTERACTIONS
        // =========================================================
        private void SetupEventHandlers()
        {
            // Close
            btnClose.Click += (s, e) =>
            {
                Form mainForm = new OwnerDashboard();
                this.Hide();
                mainForm.FormClosed += (s, args) => this.Close();
                mainForm.Show();
            };

            // Grid Click
            dgvCategories.CellClick += (s, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    var row = dgvCategories.Rows[e.RowIndex];
                    if (row.Cells["CategoryID"].Value != DBNull.Value)
                    {
                        _selectedCategoryID = Convert.ToInt32(row.Cells["CategoryID"].Value);
                        txtName.Text = row.Cells["CategoryName"].Value.ToString();

                        lblMode.Text = "EDITING CATEGORY";
                        lblMode.ForeColor = clrAccent;
                        btnDelete.Enabled = true;
                        btnDelete.BackColor = clrError;
                    }
                }
            };

            // Buttons
            btnSave.Click += (s, e) => SaveCategory();
            btnNew.Click += (s, e) => ClearInputForm();
            btnDelete.Click += (s, e) => DeleteCategory();

            txtName.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SaveCategory();
                    e.SuppressKeyPress = true;
                }
            };

            // Dragging
            this.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    NativeMethods.ReleaseCapture();
                    NativeMethods.SendMessage(Handle, 0xA1, 0x2, 0);
                }
            };

            // Fade Animation
            fadeTimer = new Timer { Interval = 15 };
            fadeTimer.Tick += (s, e) =>
            {
                if (Opacity < 1) Opacity += 0.05;
                else fadeTimer.Stop();
            };
        }

        private void ClearInputForm()
        {
            _selectedCategoryID = 0;
            txtName.Clear();
            lblMode.Text = "CREATE NEW CATEGORY";
            lblMode.ForeColor = Color.DimGray;
            btnDelete.Enabled = false;
            btnDelete.BackColor = Color.LightGray;
            txtName.Focus();
        }

        private void ApplyModernStyling()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(800, 500);
            this.BackColor = clrBackground;
            this.DoubleBuffered = true;
            this.Opacity = 0;

            // Panels
            pnlList.BackColor = clrCard;
            pnlEditor.BackColor = clrCard;

            // Buttons
            StyleButton(btnSave, clrAccent);
            StyleButton(btnNew, Color.Gray);

            // Grid
            dgvCategories.BackgroundColor = Color.WhiteSmoke;
            dgvCategories.BorderStyle = BorderStyle.None;
            dgvCategories.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCategories.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvCategories.EnableHeadersVisualStyles = false;

            // Grid Header Style
            dgvCategories.ColumnHeadersDefaultCellStyle.BackColor = clrAccent;
            dgvCategories.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCategories.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvCategories.ColumnHeadersHeight = 35;

            // Grid Row Style
            dgvCategories.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvCategories.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 240, 255);
            dgvCategories.DefaultCellStyle.SelectionForeColor = clrTextDark;
            dgvCategories.RowTemplate.Height = 30;
            dgvCategories.RowHeadersVisible = false;
            dgvCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategories.ReadOnly = true;
            dgvCategories.AllowUserToAddRows = false;
        }

        private void StyleButton(Button btn, Color bg)
        {
            btn.BackColor = bg;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;
            btn.Font = new Font("Segoe UI Semibold", 10);
        }

        private static class NativeMethods
        {
            [System.Runtime.InteropServices.DllImport("user32.dll")]
            public static extern bool ReleaseCapture();
            [System.Runtime.InteropServices.DllImport("user32.dll")]
            public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        }
    }
}