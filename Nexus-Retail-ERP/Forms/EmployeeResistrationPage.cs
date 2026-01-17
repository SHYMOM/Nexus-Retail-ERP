using Microsoft.Data.SqlClient;
using Nexus_Retail_ERP.Data;
using Nexus_Retail_ERP.Models;
using Nexus_Retail_ERP.Properties;
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Nexus_Retail_ERP.Forms
{
    public partial class EmployeeRegistrationPage : Form
    {
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["NexusDB"]?.ConnectionString;

        // =========================================================
        // UI Colors
        // =========================================================

        private readonly Color clrBackground = Color.FromArgb(38, 42, 50);
        private readonly Color clrCard = Color.FromArgb(255, 255, 255);
        private readonly Color clrCardShadow = Color.FromArgb(15, 0, 0, 0);
        private readonly Color clrAccent = Color.FromArgb(0, 180, 216);
        private readonly Color clrAccentHover = Color.FromArgb(0, 200, 230);
        private readonly Color clrTextDark = Color.FromArgb(35, 35, 38);
        private readonly Color clrTextMuted = Color.FromArgb(110, 110, 115);
        private readonly Color clrError = Color.FromArgb(239, 68, 68);
        private readonly Color clrSuccess = Color.FromArgb(34, 197, 94);
        private readonly Color clrInputBorder = Color.FromArgb(220, 220, 225);
        private readonly Color clrInputFocus = Color.FromArgb(0, 180, 216);

        private Timer? fadeTimer;
        private Timer? buttonHoverTimer;
        private string? selectedImagePath;
        private bool isSaveButtonHovered = false;
        private bool isResetButtonHovered = false;
        private bool isUploadButtonHovered = false;

        public EmployeeRegistrationPage()
        {
            InitializeComponent();
            if (SessionDetails.CurrentUserRole != "Owner")
            {
                MessageBox.Show("Access Denied! Only Owner can register new employees.",
                    "Security Restriction", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            ApplyModernStyling();
            SetupEventHandlers();
            LoadData();
        }

        private void ApplyModernStyling()
        {
            // Base Form
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(1200, 750);
            this.BackColor = clrBackground;
            this.DoubleBuffered = true;
            this.Opacity = 0;
            this.Paint += Form_Paint;

            // Header
            lblTitle.ForeColor = Color.White;
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);

            lblSubtitle.ForeColor = Color.FromArgb(180, 180, 185);
            lblSubtitle.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            lblSubtitle.Text = $"Register New Employee | Logged in as: {SessionDetails.CurrentUserName} ({SessionDetails.CurrentUserRole})";

            // Back Button
            btnBack.Text = "←";
            btnBack.Font = new Font("Segoe UI Symbol", 20F, FontStyle.Regular);
            btnBack.ForeColor = Color.FromArgb(160, 160, 165);
            btnBack.Cursor = Cursors.Hand;

            // Close Button
            btnClose.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            btnClose.ForeColor = Color.FromArgb(160, 160, 165);
            btnClose.Cursor = Cursors.Hand;


            pnlHeaderLine.Paint += (s, e) =>
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    pnlHeaderLine.ClientRectangle,
                    clrAccent,
                    Color.FromArgb(0, 140, 180),
                    LinearGradientMode.Horizontal))
                {
                    e.Graphics.FillRectangle(brush, pnlHeaderLine.ClientRectangle);
                }
            };

            pnlCard.BackColor = clrCard;
            pnlCard.Paint += Card_Paint;

            void StyleInputPanel(Panel p, Control input)
            {
                p.BackColor = Color.White;
                p.Padding = new Padding(2);
                p.Paint += (s, e) =>
                {
                    bool focused = input.Focused;
                    Color borderColor = focused ? clrInputFocus : clrInputBorder;
                    int borderWidth = focused ? 2 : 1;

                    using (Pen pen = new Pen(borderColor, borderWidth))
                    {
                        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        Rectangle rect = new Rectangle(0, 0, p.Width - 1, p.Height - 1);

                        using (GraphicsPath path = GetRoundedRect(rect, 6))
                        {
                            e.Graphics.DrawPath(pen, path);
                        }
                    }
                };
            }


            StyleInputPanel(pnlUser, txtUsername);
            StyleInputPanel(pnlPass, txtPassword);
            StyleInputPanel(pnlName, txtName);
            StyleInputPanel(pnlPhone, txtPhone);
            StyleInputPanel(pnlAddress, txtAddress);
            StyleInputPanel(pnlSalary, txtSalary);
            StyleInputPanel(pnlRole, cmbRole);
            StyleInputPanel(pnlBranch, cmbBranch);
            StyleInputPanel(pnlDOB, dtpDOB);

            // Checkbox
            chkShowPass.ForeColor = clrTextMuted;
            chkShowPass.Font = new Font("Segoe UI", 9F);

            // Buttons
            btnSave.BackColor = clrAccent;
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Font = new Font("Segoe UI Semibold", 11F);
            btnSave.Cursor = Cursors.Hand;
            btnSave.Paint += SaveButton_Paint;

            btnReset.BackColor = Color.FromArgb(240, 240, 245);
            btnReset.ForeColor = clrTextDark;
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.FlatAppearance.BorderSize = 0;
            btnReset.Font = new Font("Segoe UI Semibold", 10F);
            btnReset.Cursor = Cursors.Hand;
            btnReset.Paint += ResetButton_Paint;

            btnUpload.BackColor = Color.White;
            btnUpload.ForeColor = clrAccent;
            btnUpload.FlatStyle = FlatStyle.Flat;
            btnUpload.FlatAppearance.BorderColor = clrAccent;
            btnUpload.FlatAppearance.BorderSize = 2;
            btnUpload.Font = new Font("Segoe UI Semibold", 9F);
            btnUpload.Cursor = Cursors.Hand;
            btnUpload.Paint += UploadButton_Paint;

            picProfile.SizeMode = PictureBoxSizeMode.StretchImage;
            picProfile.Paint += Profile_Paint;

            picProfile.Image = Properties.Resources.default_profile;

            // Label
            foreach (Control ctrl in pnlCard.Controls)
            {
                if (ctrl is Label lbl && lbl != lblImage)
                {
                    lbl.Font = new Font("Segoe UI Semibold", 9.5F);
                    lbl.ForeColor = clrTextMuted;
                }
            }

            consoleLBL.ForeColor = Color.FromArgb(180, 180, 185);
            consoleLBL.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            consoleLBL.Visible = false;
        }

        private void LoadData()
        {
            try
            {
                cmbRole.Items.Clear();
                var roles = DatabaseHelper.GetAvailableRoles();
                foreach (var role in roles)
                {
                    cmbRole.Items.Add(role);
                }
                cmbRole.SelectedIndex = 0;

                LoadBranches();

                // Default date (18 years ago)
                dtpDOB.Value = DateTime.Now.AddYears(-18);
                dtpDOB.MaxDate = DateTime.Now.AddYears(-18);
                dtpDOB.MinDate = DateTime.Now.AddYears(-70);

                txtName.TextChanged += (s, e) =>
                {
                    if (!string.IsNullOrWhiteSpace(txtName.Text) && string.IsNullOrWhiteSpace(txtUsername.Text))
                    {
                        string name = txtName.Text.Trim();
                        string[] nameParts = name.Split(' ');
                        if (nameParts.Length >= 2)
                        {
                            string firstName = nameParts[0].ToLower();
                            string lastName = nameParts[nameParts.Length - 1].ToLower();
                            string suggestedUsername = $"{firstName}.{lastName}";

                            if (DatabaseHelper.IsUsernameAvailable(suggestedUsername))
                            {
                                txtUsername.Text = suggestedUsername;
                            }
                            else
                            {
                                for (int i = 1; i <= 99; i++)
                                {
                                    string tempUsername = $"{firstName}.{lastName}{i}";
                                    if (DatabaseHelper.IsUsernameAvailable(tempUsername))
                                    {
                                        txtUsername.Text = tempUsername;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                };

                txtPhone.TextChanged += (s, e) =>
                {
                    string phone = txtPhone.Text;
                    if (!string.IsNullOrWhiteSpace(phone) && phone.Length >= 10)
                    {
                        if (!DatabaseHelper.IsPhoneAvailable(phone))
                        {
                            lblPhoneStatus.Text = "⚠ Phone already registered";
                            lblPhoneStatus.ForeColor = clrError;
                            lblPhoneStatus.Visible = true;
                        }
                        else
                        {
                            lblPhoneStatus.Text = "✓ Phone available";
                            lblPhoneStatus.ForeColor = clrSuccess;
                            lblPhoneStatus.Visible = true;
                        }
                    }
                    else
                    {
                        lblPhoneStatus.Visible = false;
                    }
                };

                txtUsername.TextChanged += (s, e) =>
                {
                    string username = txtUsername.Text;
                    if (!string.IsNullOrWhiteSpace(username) && username.Length >= 3)
                    {
                        if (!DatabaseHelper.IsUsernameAvailable(username))
                        {
                            lblUserStatus.Text = "⚠ Username taken";
                            lblUserStatus.ForeColor = clrError;
                            lblUserStatus.Visible = true;
                        }
                        else
                        {
                            lblUserStatus.Text = "✓ Username available";
                            lblUserStatus.ForeColor = clrSuccess;
                            lblUserStatus.Visible = true;
                        }
                    }
                    else
                    {
                        lblUserStatus.Visible = false;
                    }
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load data: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================
        //  LoadBranches
        // ==========================================
        private void LoadBranches()
        {
            try
            {
                var branches = DatabaseHelper.GetAllBranches(includeInactive: false);

                cmbBranch.Items.Clear();

                foreach (var branch in branches)
                {
                    cmbBranch.Items.Add(branch);
                }

                if (cmbBranch.Items.Count > 0)
                {
                    cmbBranch.SelectedIndex = 0;
                    consoleLBL.Text = $"{cmbBranch.Items.Count} branches loaded";
                    consoleLBL.Visible = true;
                }
            }
            catch (Exception ex)
            {
                consoleLBL.Text = $"Failed to load branches: {ex.Message}";
                consoleLBL.Visible = true;
                cmbBranch.Enabled = false;
            }
        }

        private void SetupEventHandlers()
        {
            // Fade-in animation
            fadeTimer = new Timer { Interval = 15 };
            fadeTimer.Tick += (s, e) =>
            {
                if (this.Opacity < 1) this.Opacity += 0.05;
                else fadeTimer?.Stop();
            };

            // Button hover effects
            btnSave.MouseEnter += (s, e) => { isSaveButtonHovered = true; btnSave.Invalidate(); };
            btnSave.MouseLeave += (s, e) => { isSaveButtonHovered = false; btnSave.Invalidate(); };

            btnReset.MouseEnter += (s, e) => { isResetButtonHovered = true; btnReset.Invalidate(); };
            btnReset.MouseLeave += (s, e) => { isResetButtonHovered = false; btnReset.Invalidate(); };

            btnUpload.MouseEnter += (s, e) => { isUploadButtonHovered = true; btnUpload.Invalidate(); };
            btnUpload.MouseLeave += (s, e) => { isUploadButtonHovered = false; btnUpload.Invalidate(); };

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

            btnClose.MouseEnter += (s, e) => { btnClose.ForeColor = clrError; };
            btnClose.MouseLeave += (s, e) => { btnClose.ForeColor = Color.FromArgb(160, 160, 165); };

            // Back button
            btnBack.Click += (s, e) => this.Close();
            btnBack.MouseEnter += (s, e) => btnBack.ForeColor = Color.White;
            btnBack.MouseLeave += (s, e) => btnBack.ForeColor = Color.FromArgb(160, 160, 165);

            // Form dragging
            this.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    NativeMethods.ReleaseCapture();
                    NativeMethods.SendMessage(Handle, 0xA1, 0x2, 0);
                }
            };

            // Focus effects for inputs
            void BindFocus(Control c, Panel p)
            {
                c.Enter += (s, e) => p.Invalidate();
                c.Leave += (s, e) => p.Invalidate();
            }

            BindFocus(txtUsername, pnlUser);
            BindFocus(txtPassword, pnlPass);
            BindFocus(txtName, pnlName);
            BindFocus(txtPhone, pnlPhone);
            BindFocus(txtAddress, pnlAddress);
            BindFocus(txtSalary, pnlSalary);
            BindFocus(cmbRole, pnlRole);
            BindFocus(cmbBranch, pnlBranch);
            BindFocus(dtpDOB, pnlDOB);

            // Input validation
            txtPhone.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '+' && e.KeyChar != '-' && e.KeyChar != '(' && e.KeyChar != ')')
                    e.Handled = true;
            };

            txtSalary.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                    e.Handled = true;
            };

            // Button actions
            btnSave.Click += ValidateAndSave;
            btnReset.Click += ConfirmAndReset;
            btnUpload.Click += UploadImage;
            chkShowPass.CheckedChanged += (s, e) => txtPassword.UseSystemPasswordChar = !chkShowPass.Checked;

            // Enter key to save
            this.KeyPreview = true;
            this.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter && !(ActiveControl is Button))
                {
                    ValidateAndSave(null, EventArgs.Empty);
                }
            };
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            fadeTimer?.Start();
            txtName.Focus();
        }

        private void ValidateAndSave(object? sender, EventArgs e)
        {
            string errors = "";

            // Validation function
            bool Validate(Control c, string name, bool required = true)
            {
                if (required && string.IsNullOrWhiteSpace(c.Text))
                {
                    errors += $"\n• {name} is required";
                    return false;
                }
                return true;
            }

            bool v1 = Validate(txtUsername, "Username");
            bool v2 = Validate(txtPassword, "Password");
            bool v3 = Validate(txtName, "Full Name");
            bool v4 = Validate(txtPhone, "Phone Number");
            bool v5 = Validate(txtAddress, "Address");
            bool v6 = Validate(txtSalary, "Salary");

            if (txtPassword.Text.Length < 6)
            {
                errors += "\n• Password must be at least 6 characters";
                v2 = false;
            }

            if (!string.IsNullOrWhiteSpace(txtPhone.Text) && txtPhone.Text.Length < 11)
            {
                errors += "\n• Phone number must be at least 11 digits";
                v4 = false;
            }

            if (!decimal.TryParse(txtSalary.Text, out decimal salary) || salary < 0)
            {
                errors += "\n• Salary must be a valid positive number";
                v6 = false;
            }

            if (dtpDOB.Value > DateTime.Now.AddYears(-18))
            {
                errors += "\n• Employee must be at least 18 years old";
            }

            if (cmbBranch.SelectedItem == null)
            {
                errors += "\n• Branch selection is required";
            }

            if (!DatabaseHelper.IsUsernameAvailable(txtUsername.Text.Trim()))
            {
                errors += "\n• Username is already taken";
                v1 = false;
            }

            if (!DatabaseHelper.IsPhoneAvailable(txtPhone.Text.Trim()))
            {
                errors += "\n• Phone number is already registered";
                v4 = false;
            }

            if (!string.IsNullOrEmpty(errors))
            {
                MessageBox.Show("Please correct the following:" + errors,
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Disable save button
            btnSave.Enabled = false;
            btnSave.Text = "Saving...";
            Cursor = Cursors.WaitCursor;

            try
            {
                BranchInfo selectedBranch = (BranchInfo)cmbBranch.SelectedItem;

                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text;
                string role = cmbRole.SelectedItem.ToString();
                string fullName = txtName.Text.Trim();
                string phone = txtPhone.Text.Trim();
                string address = txtAddress.Text.Trim();
                DateTime? dob = dtpDOB.Value;
                decimal salaryValue = decimal.Parse(txtSalary.Text);
                int branchID = selectedBranch.BranchID;

                string message;
                bool success = DatabaseHelper.RegisterEmployee(
                    username, password, role, fullName, phone, address,
                    dob, salaryValue, selectedImagePath, branchID, out message);

                if (success)
                {
                    MessageBox.Show($"✓ Employee '{fullName}' registered successfully!\n\n" +
                                    $"Username: {username}\n" +
                                    $"Role: {role}\n" +
                                    $"Branch: {selectedBranch.BranchName}\n\n" +
                                    $"Default Password: {password}\n" +
                                    "Please inform the employee to change their password after first login.",
                        "Registration Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ResetForm();
                }
                else
                {
                    MessageBox.Show($"Registration failed: {message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during registration: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSave.Enabled = true;
                btnSave.Text = "Save Employee";
                Cursor = Cursors.Default;
            }
        }

        private void ConfirmAndReset(object? sender, EventArgs e)
        {
            if (IsFormDirty())
            {
                var result = MessageBox.Show(
                    "Are you sure you want to reset the form?\nAll unsaved data will be lost.",
                    "Confirm Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes) ResetForm();
            }
        }

        private bool IsFormDirty()
        {
            return !string.IsNullOrWhiteSpace(txtUsername.Text) ||
                   !string.IsNullOrWhiteSpace(txtPassword.Text) ||
                   !string.IsNullOrWhiteSpace(txtName.Text) ||
                   !string.IsNullOrWhiteSpace(txtPhone.Text) ||
                   !string.IsNullOrWhiteSpace(txtAddress.Text) ||
                   !string.IsNullOrWhiteSpace(txtSalary.Text) ||
                   selectedImagePath != null;
        }

        private void ResetForm()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtName.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            txtSalary.Clear();
            cmbRole.SelectedIndex = 0;

            if (cmbBranch.Items.Count > 0)
                cmbBranch.SelectedIndex = 0;

            dtpDOB.Value = DateTime.Now.AddYears(-18);
            picProfile.Image = Resources.default_profile;
            selectedImagePath = null;
            lblUserStatus.Visible = false;
            lblPhoneStatus.Visible = false;
            chkShowPass.Checked = false;
            txtPassword.UseSystemPasswordChar = true;

            // Reset panel borders
            pnlUser.Invalidate();
            pnlPass.Invalidate();
            pnlName.Invalidate();
            pnlPhone.Invalidate();
            pnlSalary.Invalidate();
            pnlRole.Invalidate();
            pnlBranch.Invalidate();
            pnlDOB.Invalidate();

            txtName.Focus();
        }

        private void UploadImage(object? sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif",
                Title = "Select Profile Picture",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
            })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        FileInfo fileInfo = new FileInfo(ofd.FileName);
                        if (fileInfo.Length > 5 * 1024 * 1024) // 5MB
                        {
                            MessageBox.Show("Image size must be less than 5MB.",
                                "File Too Large", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        using (Image img = Image.FromFile(ofd.FileName))
                        {
                            if (img.Width > 2000 || img.Height > 2000)
                            {
                                MessageBox.Show("Image dimensions must be less than 2000x2000 pixels.",
                                    "Image Too Large", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }

                        string appPath = Application.StartupPath;
                        string profileImagesDir = Path.Combine(appPath, "ProfileImages");

                        if (!Directory.Exists(profileImagesDir))
                            Directory.CreateDirectory(profileImagesDir);

                        string extension = Path.GetExtension(ofd.FileName);
                        string newFilename = $"profile_{Guid.NewGuid()}{extension}";
                        string destPath = Path.Combine(profileImagesDir, newFilename);

                        File.Copy(ofd.FileName, destPath, true);

                        using (Image original = Image.FromFile(destPath))
                        {
                            Bitmap resized = new Bitmap(150, 150);
                            using (Graphics g = Graphics.FromImage(resized))
                            {
                                g.SmoothingMode = SmoothingMode.AntiAlias;
                                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                                g.DrawImage(original, 0, 0, 150, 150);
                            }

                            if (picProfile.Image != null && picProfile.Image != Properties.Resources.default_profile)
                                picProfile.Image.Dispose();

                            picProfile.Image = resized;
                        }

                        selectedImagePath = destPath;

                        lblImage.Text = "✓ Image uploaded";
                        lblImage.ForeColor = clrSuccess;

                        Timer t = new Timer { Interval = 2000 };
                        t.Tick += (s, e) =>
                        {
                            t.Stop();
                            t.Dispose();
                            lblImage.Text = "Profile Picture";
                            lblImage.ForeColor = clrTextMuted;
                        };
                        t.Start();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to upload image: {ex.Message}",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Card_Paint(object? sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath cardPath = GetRoundedRect(
                new Rectangle(0, 0, pnlCard.Width - 1, pnlCard.Height - 1), 12))
            {
                using (SolidBrush brush = new SolidBrush(clrCard))
                {
                    e.Graphics.FillPath(brush, cardPath);
                }

                using (Pen pen = new Pen(Color.FromArgb(230, 230, 235), 1))
                {
                    e.Graphics.DrawPath(pen, cardPath);
                }
            }
        }

        private void Form_Paint(object? sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(
                this.ClientRectangle,
                Color.FromArgb(38, 42, 50),
                Color.FromArgb(48, 52, 62),
                45f))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void SaveButton_Paint(object? sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Color bgColor = isSaveButtonHovered ? clrAccentHover : clrAccent;

            using (GraphicsPath path = GetRoundedRect(
                new Rectangle(0, 0, btnSave.Width - 1, btnSave.Height - 1), 8))
            {
                using (SolidBrush brush = new SolidBrush(bgColor))
                {
                    e.Graphics.FillPath(brush, path);
                }
            }

            TextRenderer.DrawText(e.Graphics, btnSave.Text, btnSave.Font,
                btnSave.ClientRectangle, btnSave.ForeColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        private void ResetButton_Paint(object? sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Color bgColor = isResetButtonHovered ? Color.FromArgb(230, 230, 235) : Color.FromArgb(240, 240, 245);

            using (GraphicsPath path = GetRoundedRect(
                new Rectangle(0, 0, btnReset.Width - 1, btnReset.Height - 1), 8))
            {
                using (SolidBrush brush = new SolidBrush(bgColor))
                {
                    e.Graphics.FillPath(brush, path);
                }
            }

            TextRenderer.DrawText(e.Graphics, btnReset.Text, btnReset.Font,
                btnReset.ClientRectangle, btnReset.ForeColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        private void UploadButton_Paint(object? sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Color borderColor = isUploadButtonHovered ? clrAccentHover : clrAccent;

            using (GraphicsPath path = GetRoundedRect(
                new Rectangle(0, 0, btnUpload.Width - 1, btnUpload.Height - 1), 8))
            {
                using (SolidBrush brush = new SolidBrush(Color.White))
                {
                    e.Graphics.FillPath(brush, path);
                }

                using (Pen pen = new Pen(borderColor, 2))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }

            TextRenderer.DrawText(e.Graphics, btnUpload.Text, btnUpload.Font,
                btnUpload.ClientRectangle, isUploadButtonHovered ? clrAccentHover : clrAccent,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        private void Profile_Paint(object? sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            GraphicsPath circle = new GraphicsPath();
            circle.AddEllipse(0, 0, picProfile.Width - 1, picProfile.Height - 1);
            picProfile.Region = new Region(circle);

            using (Pen borderPen = new Pen(clrAccent, 3))
            {
                e.Graphics.DrawEllipse(borderPen, 1, 1, picProfile.Width - 4, picProfile.Height - 4);
            }
        }

        private GraphicsPath GetRoundedRect(Rectangle bounds, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;

            path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
            path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            return path;
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