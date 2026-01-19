using Nexus_Retail_ERP.Data;
using Nexus_Retail_ERP.Models;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;
using Timer = System.Windows.Forms.Timer;

namespace Nexus_Retail_ERP.Forms
{
    public partial class EmployeeManagementForm : Form
    {
        // =========================================================
        // UI Colors
        // =========================================================
        private readonly Color clrBackground = Color.FromArgb(38, 42, 50);
        private readonly Color clrCard = Color.FromArgb(255, 255, 255);
        private readonly Color clrAccent = Color.FromArgb(0, 180, 216);
        private readonly Color clrRed = Color.FromArgb(239, 68, 68);
        private readonly Color clrGreen = Color.FromArgb(34, 197, 94);

        private int _selectedUserID = 0;
        private Timer fadeTimer;

        public EmployeeManagementForm()
        {
            InitializeComponent();
            ApplyModernStyling();
            SetupEventHandlers();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            try
            {
                LoadBranches();
                LoadRoles();
                RefreshEmployeeList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Startup Error: " + ex.Message);
            }

            // Animation
            this.Opacity = 0;
            fadeTimer = new Timer { Interval = 15 };
            fadeTimer.Tick += (s, args) => { if (Opacity < 1) Opacity += 0.05; else fadeTimer.Stop(); };
            fadeTimer.Start();
        }

        // =========================================================
        // DATA LOAD
        // =========================================================
        private void LoadBranches()
        {
            var branches = DatabaseHelper.GetAllBranches(includeInactive: false);
            cmbBranch.Items.Clear();
            foreach (var b in branches) cmbBranch.Items.Add(b);
            cmbBranch.DisplayMember = "BranchName";
            cmbBranch.ValueMember = "BranchID";
        }

        private void LoadRoles()
        {
            cmbRole.Items.Clear();
            cmbRole.Items.AddRange(new object[] { "Cashier", "Manager", "Owner", "Employee" });
        }

        private void RefreshEmployeeList()
        {
            try
            {
                string search = txtSearch.Text.Trim();
                DataTable dt = DatabaseHelper.GetAllEmployees(search);

                dgvEmployees.DataSource = dt;

                string[] hideCols = { "UserID", "PasswordHash", "ProfileImagePath", "BranchID" };
                foreach (var c in hideCols)
                    if (dgvEmployees.Columns.Contains(c)) dgvEmployees.Columns[c].Visible = false;

                foreach (DataGridViewRow row in dgvEmployees.Rows)
                {
                    bool isActive = Convert.ToBoolean(row.Cells["IsActive"].Value);
                    if (!isActive)
                    {
                        row.DefaultCellStyle.ForeColor = Color.Gray;
                        row.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Italic);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Grid Error: " + ex.Message);
            }
        }

        // =========================================================
        // ACTIONS
        // =========================================================
        private void SaveChanges()
        {
            if (_selectedUserID == 0) return;

            if (string.IsNullOrEmpty(txtName.Text) || cmbBranch.SelectedItem == null)
            {
                MessageBox.Show("Name and Branch are required.");
                return;
            }

            try
            {
                BranchInfo branch = (BranchInfo)cmbBranch.SelectedItem;
                string role = cmbRole.SelectedItem.ToString();
                decimal salary = decimal.Parse(txtSalary.Text);
                bool isActive = tglActive.Checked;

                bool success = DatabaseHelper.UpdateEmployee(
                    _selectedUserID,
                    role,
                    salary,
                    branch.BranchID,
                    isActive
                );

                if (success)
                {
                    MessageBox.Show("Employee details updated successfully.");
                    RefreshEmployeeList();
                }
                else
                {
                    MessageBox.Show("Update failed.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving: " + ex.Message);
            }
        }

        private void OpenRegistrationPage()
        {
            EmployeeRegistrationPage regForm = new EmployeeRegistrationPage();
            regForm.FormClosed += (s, e) => RefreshEmployeeList();
            regForm.ShowDialog();
        }

        // =========================================================
        // EVENTS
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

            txtSearch.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) RefreshEmployeeList(); };
            btnSearch.Click += (s, e) => RefreshEmployeeList();

            btnAddEmployee.Click += (s, e) => OpenRegistrationPage();

            dgvEmployees.CellClick += (s, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    var row = dgvEmployees.Rows[e.RowIndex];
                    _selectedUserID = Convert.ToInt32(row.Cells["UserID"].Value);

                    txtName.Text = row.Cells["FullName"].Value.ToString();
                    txtPhone.Text = row.Cells["Phone"].Value.ToString();
                    txtSalary.Text = row.Cells["Salary"].Value.ToString();

                    string role = row.Cells["Role"].Value.ToString();
                    if (cmbRole.Items.Contains(role)) cmbRole.SelectedItem = role;

                    int branchID = Convert.ToInt32(row.Cells["BranchID"].Value);
                    foreach (BranchInfo b in cmbBranch.Items)
                    {
                        if (b.BranchID == branchID)
                        {
                            cmbBranch.SelectedItem = b;
                            break;
                        }
                    }

                    tglActive.Checked = Convert.ToBoolean(row.Cells["IsActive"].Value);

                    pnlEditor.Enabled = true;
                    lblEditorTitle.Text = "Editing: " + txtName.Text;
                }
            };

            btnSave.Click += (s, e) => SaveChanges();

            this.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage(Handle, 0xA1, 0x2, 0);
                }
            };
        }

        private void ApplyModernStyling()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(1100, 650);
            this.BackColor = clrBackground;
            this.DoubleBuffered = true;

            pnlList.BackColor = clrCard;
            pnlEditor.BackColor = clrCard;

            StyleButton(btnAddEmployee, clrAccent);
            StyleButton(btnSave, clrGreen);
            StyleButton(btnSearch, clrAccent);

            dgvEmployees.BackgroundColor = Color.WhiteSmoke;
            dgvEmployees.BorderStyle = BorderStyle.None;
            dgvEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmployees.ReadOnly = true;
            dgvEmployees.RowHeadersVisible = false;
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

        [DllImport("user32.dll")] public static extern bool ReleaseCapture();
        [DllImport("user32.dll")] public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
    }
}