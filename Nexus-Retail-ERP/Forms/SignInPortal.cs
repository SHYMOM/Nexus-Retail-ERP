using System;
using System.Configuration;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;
using Timer = System.Windows.Forms.Timer;
using Microsoft.Data.SqlClient;
using Nexus_Retail_ERP.Data;
using Nexus_Retail_ERP.Forms;
using Nexus_Retail_ERP.Models;

namespace Nexus_Retail_ERP.Forms
{
    public partial class SignInPortal : Form
    {
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["NexusDB"]?.ConnectionString;
        // =========================================================
        // UI Colors
        // =========================================================
        private readonly Color clrBrandPanel = Color.FromArgb(65, 65, 68);
        private readonly Color clrContentPanel = Color.FromArgb(248, 249, 250);
        private readonly Color clrAccent = Color.FromArgb(0, 160, 210);
        private readonly Color clrTextDark = Color.FromArgb(45, 45, 48);
        private readonly Color clrError = Color.FromArgb(220, 53, 69);
        private readonly Color clrSuccess = Color.FromArgb(40, 167, 69);

        private Timer? fadeTimer;
        private Timer? shakeTimer;
        private int shakeTicks = 0;
        private Point originalLoc;
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;


        public SignInPortal()
        {
            InitializeComponent();
            SetupEventHandlers();
            LoadBranches();
        }

        private void SetupEventHandlers()
        {
            this.MouseDown += (s, e) => { dragging = true; dragCursorPoint = Cursor.Position; dragFormPoint = this.Location; };
            this.MouseMove += (s, e) =>
            {
                if (dragging)
                {
                    Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                    this.Location = Point.Add(dragFormPoint, new Size(dif));
                }
            };
            this.MouseUp += (s, e) => { dragging = false; };

            pnlLeft.MouseDown += (s, e) => { dragging = true; dragCursorPoint = Cursor.Position; dragFormPoint = this.Location; };
            pnlLeft.MouseMove += (s, e) => { if (dragging) { Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint)); this.Location = Point.Add(dragFormPoint, new Size(dif)); } };
            pnlLeft.MouseUp += (s, e) => { dragging = false; };

            btnLogin.Click += BtnLogin_Click;
            txtPassword.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) PerformLogin(); };
            txtUsername.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) txtPassword.Focus(); };

            chkShowPass.CheckedChanged += (s, e) => { txtPassword.UseSystemPasswordChar = !chkShowPass.Checked; };

            // Close button
            btnClose.Click += (s, e) =>
            {
                var result = MessageBox.Show("Are you sure you want to close?", "Warning",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.Cancel;
                    Application.Exit();
                }
            };
            btnClose.MouseEnter += (s, e) => btnClose.ForeColor = Color.Red;
            btnClose.MouseLeave += (s, e) => btnClose.ForeColor = clrTextDark;

            // Fade in animation
            fadeTimer = new Timer { Interval = 15 };
            fadeTimer.Tick += (s, e) =>
            {
                if (this.Opacity < 1) this.Opacity += 0.05;
                else fadeTimer?.Stop();
            };

            // Shake animation for errors
            shakeTimer = new Timer { Interval = 20 };
            shakeTimer.Tick += ShakeTimer_Tick;
        }

        private void LoadBranches()
        {
            try
            {
                var branches = DatabaseHelper.GetAllBranches(includeInactive: false);

                cmbBranch.Items.Clear();
                cmbBranch.DisplayMember = "DisplayText";
                cmbBranch.ValueMember = "BranchID";

                foreach (var branch in branches)
                {
                    cmbBranch.Items.Add(new
                    {
                        BranchID = branch.BranchID,
                        BranchName = branch.BranchName,
                        DisplayText = $"{branch.BranchName} ({branch.Location})"
                    });
                }

                if (cmbBranch.Items.Count > 0)
                {
                    cmbBranch.SelectedIndex = 0;
                    lblSuccessMessage.Text = $"{cmbBranch.Items.Count} branches loaded";
                    lblSuccessMessage.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = $"Failed to load branches: {ex.Message}";
                lblErrorMessage.Visible = true;
                cmbBranch.Enabled = false;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            fadeTimer?.Start();
            txtUsername.Focus();
        }

        // =========================================================
        // AUTHENTICATION LOGIC
        // =========================================================
        private void BtnLogin_Click(object? sender, EventArgs e)
        {
            PerformLogin();
        }

        private void PerformLogin()
        {
            lblErrorMessage.Visible = false;
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ShowError("Please enter both credentials.");
                return;
            }

            if (cmbBranch.SelectedItem == null)
            {
                ShowError("Please select a branch.");
                return;
            }

            btnLogin.Enabled = false;
            btnLogin.Text = "Verifying...";
            Cursor = Cursors.WaitCursor;

            try
            {
                dynamic selectedBranch = cmbBranch.SelectedItem;
                int selectedBranchID = selectedBranch.BranchID;
                string selectedBranchName = selectedBranch.BranchName;

                string passwordHash = DatabaseHelper.ComputeSHA256Hash(password);

                var authResult = DatabaseHelper.AuthenticateUser(username, passwordHash);

                if (authResult.IsAuthenticated)
                {
                    if (authResult.Role != "Owner" && authResult.BranchID != selectedBranchID)
                    {
                        ShowError("You are not assigned to this branch.");
                        TriggerShake();
                        ResetLoginButton();
                        return;
                    }

                    SessionDetails.CurrentUserID = authResult.UserID;
                    SessionDetails.CurrentUserRole = authResult.Role;
                    SessionDetails.CurrentUserName = authResult.FullName;
                    SessionDetails.CurrentBranchID = authResult.Role == "Owner" ? selectedBranchID : authResult.BranchID;
                    SessionDetails.CurrentBranchName = authResult.Role == "Owner" ? selectedBranchName : authResult.BranchName;

                    DatabaseHelper.NotifyOwner_Login(username, SessionDetails.CurrentUserRole, SessionDetails.CurrentBranchName);
                    DatabaseHelper.UpdateLastLogin(authResult.UserID);

                    OpenMainDashboard();
                }
                else
                {
                    ShowError("Invalid username or password.");
                    TriggerShake();
                    ResetLoginButton();
                }
            }
            catch (Exception ex)
            {
                ShowError($"Authentication error: {ex.Message}");
                ResetLoginButton();
            }
        }

        private void OpenMainDashboard()
        {
            Form mainForm = null;

            switch (SessionDetails.CurrentUserRole)
            {
                case "Owner":
                    mainForm = new OwnerDashboard();
                    this.Hide();
                    mainForm.FormClosed += (s, args) => this.Close();
                    mainForm.Show();
                    break;
                case "Manager":
                    mainForm = new BranchManagerDashboard();
                    break;
                case "Cashier":
                    mainForm = new POSForm();
                    this.Hide();
                    mainForm.FormClosed += (s, args) => this.Close();
                    mainForm.Show();
                    break;
                default:
                    MessageBox.Show("Unknown user role. Access denied.",
                        "Access Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ResetLoginButton();
                    return;
            }

            this.Hide();
            mainForm.FormClosed += (s, args) => this.Close();
            mainForm.Show();
        }

        private void ResetLoginButton()
        {
            btnLogin.Enabled = true;
            btnLogin.Text = "Login";
            Cursor = Cursors.Default;
        }

        private void ShowError(string msg)
        {
            lblErrorMessage.Text = msg;
            lblErrorMessage.Visible = true;
        }

        private void TriggerShake()
        {
            originalLoc = this.Location;
            shakeTicks = 0;
            shakeTimer?.Start();
        }

        private void ShakeTimer_Tick(object? sender, EventArgs e)
        {
            if (shakeTicks > 10)
            {
                shakeTimer?.Stop();
                this.Location = originalLoc;
                return;
            }
            int offset = (shakeTicks % 2 == 0) ? 5 : -5;
            this.Location = new Point(originalLoc.X + offset, originalLoc.Y);
            shakeTicks++;
        }

        private void lblForgetPassword_Click(object sender, EventArgs e)
        {
            using (var form = new ChangePasswordForm())
            {
                form.ShowDialog();
            }
        }
    }
}