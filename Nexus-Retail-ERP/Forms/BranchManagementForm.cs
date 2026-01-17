using Nexus_Retail_ERP.Data;
using Nexus_Retail_ERP.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Xml.Linq;
using Timer = System.Windows.Forms.Timer;

namespace Nexus_Retail_ERP.Forms
{
    public partial class BranchManagementForm : Form
    {
        // =========================================================
        // UI COLORS
        // =========================================================
        private readonly Color clrBackground = Color.FromArgb(38, 42, 50);
        private readonly Color clrCard = Color.FromArgb(255, 255, 255);
        private readonly Color clrAccent = Color.FromArgb(0, 180, 216);
        private readonly Color clrTextDark = Color.FromArgb(45, 45, 48);
        private readonly Color clrSuccess = Color.FromArgb(34, 197, 94);
        private readonly Color clrError = Color.FromArgb(239, 68, 68);

        private int _selectedBranchID = 0;
        private Timer fadeTimer;

        public BranchManagementForm()
        {
            InitializeComponent();
            ApplyModernStyling();
            SetupEventHandlers();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            RefreshBranchList();
            fadeTimer.Start();
        }

        // =========================================================
        // DATA LOGIC
        // =========================================================
        private void RefreshBranchList()
        {
            try
            {
                List<BranchInfo> branches = DatabaseHelper.GetAllBranches(includeInactive: true);

                dgvBranches.DataSource = null;
                dgvBranches.DataSource = branches;
                if (dgvBranches.Columns["BranchID"] != null) dgvBranches.Columns["BranchID"].Visible = false;

                ClearInputForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading branches: " + ex.Message);
            }
        }

        private void SaveBranchData()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text)) { MessageBox.Show("Branch Name is required."); return; }
            if (string.IsNullOrWhiteSpace(txtLocation.Text)) { MessageBox.Show("Location is required."); return; }

            string name = txtName.Text.Trim();
            string loc = txtLocation.Text.Trim();
            string phone = txtPhone.Text.Trim();
            bool isActive = tglActive.Checked;

            bool success = false;
            string message = "";

            try
            {
                if (_selectedBranchID == 0)
                {
                    success = DatabaseHelper.AddBranch(name, loc, phone, isActive);
                    message = "Branch created successfully!";
                }
                else
                {
                    success = DatabaseHelper.UpdateBranch(_selectedBranchID, name, loc, phone, isActive);
                    message = "Branch updated successfully!";
                }

                if (success)
                {
                    MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshBranchList();
                }
                else
                {
                    MessageBox.Show("Operation failed. Check database logs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteBranch()
        {
            if (_selectedBranchID == 0) return;

            var result = MessageBox.Show(
                "Are you sure you want to delete this branch?\n\nNOTE: It is safer to just deactivate it if it has transaction history.",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                bool success = DatabaseHelper.DeleteBranch(_selectedBranchID);
                if (success)
                {
                    MessageBox.Show("Branch deleted. (Archived!!)", "Success");
                    RefreshBranchList();
                }
                else
                {
                    MessageBox.Show("Could not delete. It might be linked to existing sales.", "Error");
                }
            }
        }

        // =========================================================
        // EVENT HANDLING
        // =========================================================
        private void SetupEventHandlers()
        {
            btnClose.Click += (s, e) =>
            {
                Form mainForm = new OwnerDashboard();
                this.Hide();
                mainForm.FormClosed += (s, args) => this.Close();
                mainForm.Show();
            };

            // Grid Selection
            dgvBranches.CellClick += (s, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    var row = dgvBranches.Rows[e.RowIndex];
                    _selectedBranchID = Convert.ToInt32(row.Cells["BranchID"].Value);
                    txtName.Text = row.Cells["BranchName"].Value?.ToString();
                    txtLocation.Text = row.Cells["Location"].Value?.ToString();
                    txtPhone.Text = row.Cells["Phone"].Value?.ToString();
                    tglActive.Checked = Convert.ToBoolean(row.Cells["IsActive"].Value);

                    lblMode.Text = $"EDITING: {txtName.Text}";
                    btnDelete.Enabled = true;
                }
            };

            // Buttons
            btnSave.Click += (s, e) => SaveBranchData();
            btnNew.Click += (s, e) => ClearInputForm();
            btnDelete.Click += (s, e) => DeleteBranch();

            // Dragging
            this.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    NativeMethods.ReleaseCapture();
                    NativeMethods.SendMessage(Handle, 0xA1, 0x2, 0);
                }
            };

            // Fade In
            fadeTimer = new Timer { Interval = 15 };
            fadeTimer.Tick += (s, e) =>
            {
                if (Opacity < 1) Opacity += 0.05;
                else fadeTimer.Stop();
            };
        }

        private void ClearInputForm()
        {
            _selectedBranchID = 0;
            txtName.Clear();
            txtLocation.Clear();
            txtPhone.Clear();
            tglActive.Checked = true;
            lblMode.Text = "CREATE NEW BRANCH";
            btnDelete.Enabled = false;
            txtName.Focus();
        }

        private void ApplyModernStyling()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(1000, 600);
            this.BackColor = clrBackground;
            this.DoubleBuffered = true;
            this.Opacity = 0;

            // Panel Styling
            pnlEditor.BackColor = clrCard;
            pnlList.BackColor = clrCard;

            // Button Styling
            StyleButton(btnSave, clrAccent);
            StyleButton(btnNew, Color.Gray);
            StyleButton(btnDelete, clrError);

            // Grid Styling
            dgvBranches.BackgroundColor = Color.WhiteSmoke;
            dgvBranches.BorderStyle = BorderStyle.None;
            dgvBranches.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBranches.RowHeadersVisible = false;
            dgvBranches.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBranches.ReadOnly = true;
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

        // Native Drag
        private static class NativeMethods
        {
            [System.Runtime.InteropServices.DllImport("user32.dll")]
            public static extern bool ReleaseCapture();
            [System.Runtime.InteropServices.DllImport("user32.dll")]
            public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        }
    }
}