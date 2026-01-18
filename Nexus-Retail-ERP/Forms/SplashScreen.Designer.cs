namespace Nexus_Retail_ERP.Forms
{
    partial class SplashScreen
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            mainPanel = new Panel();
            logoPanel = new Panel();
            lblAppName = new Label();
            lblAppSubtitle = new Label();
            lblTagline = new Label();
            progressContainer = new Panel();
            progressFill = new Panel();
            progressGlow = new Panel();
            lblStatus = new Label();
            footerPanel = new Panel();
            lblVersion = new Label();
            lblCopyright = new Label();
            animationTimer = new System.Windows.Forms.Timer(components);
            mainPanel.SuspendLayout();
            logoPanel.SuspendLayout();
            progressContainer.SuspendLayout();
            footerPanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.Transparent;
            mainPanel.Controls.Add(logoPanel);
            mainPanel.Controls.Add(lblTagline);
            mainPanel.Controls.Add(progressContainer);
            mainPanel.Controls.Add(lblStatus);
            mainPanel.Controls.Add(footerPanel);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Padding = new Padding(60, 80, 60, 40);
            mainPanel.Size = new Size(1000, 600);
            mainPanel.TabIndex = 0;
            // 
            // logoPanel
            // 
            logoPanel.BackColor = Color.Transparent;
            logoPanel.Controls.Add(lblAppName);
            logoPanel.Controls.Add(lblAppSubtitle);
            logoPanel.Dock = DockStyle.Top;
            logoPanel.Location = new Point(60, 80);
            logoPanel.Name = "logoPanel";
            logoPanel.Size = new Size(880, 140);
            logoPanel.TabIndex = 0;
            // 
            // lblAppName
            // 
            lblAppName.Dock = DockStyle.Top;
            lblAppName.Font = new System.Drawing.Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAppName.ForeColor = Color.FromArgb(245, 245, 245);
            lblAppName.Location = new Point(0, 0);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(880, 85);
            lblAppName.TabIndex = 0;
            lblAppName.Text = "NEXUS";
            lblAppName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAppSubtitle
            // 
            lblAppSubtitle.Dock = DockStyle.Bottom;
            lblAppSubtitle.Font = new System.Drawing.Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAppSubtitle.ForeColor = Color.FromArgb(180, 180, 180);
            lblAppSubtitle.Location = new Point(0, 95);
            lblAppSubtitle.Name = "lblAppSubtitle";
            lblAppSubtitle.Size = new Size(880, 45);
            lblAppSubtitle.TabIndex = 1;
            lblAppSubtitle.Text = "RETAIL ERP";
            lblAppSubtitle.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblTagline
            // 
            lblTagline.Dock = DockStyle.Top;
            lblTagline.Font = new System.Drawing.Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTagline.ForeColor = Color.FromArgb(160, 160, 160);
            lblTagline.Location = new Point(60, 220);
            lblTagline.Name = "lblTagline";
            lblTagline.Padding = new Padding(0, 10, 0, 0);
            lblTagline.Size = new Size(880, 50);
            lblTagline.TabIndex = 1;
            lblTagline.Text = "Unified Retail. Total Control.";
            lblTagline.TextAlign = ContentAlignment.TopCenter;
            // 
            // progressContainer
            // 
            progressContainer.Anchor = AnchorStyles.None;
            progressContainer.BackColor = Color.FromArgb(70, 70, 75);
            progressContainer.Controls.Add(progressFill);
            progressContainer.Controls.Add(progressGlow);
            progressContainer.Location = new Point(300, 405);
            progressContainer.Name = "progressContainer";
            progressContainer.Size = new Size(400, 6);
            progressContainer.TabIndex = 2;
            // 
            // progressFill
            // 
            progressFill.BackColor = Color.FromArgb(0, 180, 216);
            progressFill.Dock = DockStyle.Left;
            progressFill.Location = new Point(0, 0);
            progressFill.Name = "progressFill";
            progressFill.Size = new Size(0, 6);
            progressFill.TabIndex = 0;
            // 
            // progressGlow
            // 
            progressGlow.BackColor = Color.Transparent;
            progressGlow.Dock = DockStyle.Fill;
            progressGlow.Location = new Point(0, 0);
            progressGlow.Name = "progressGlow";
            progressGlow.Size = new Size(400, 6);
            progressGlow.TabIndex = 1;
            progressGlow.Paint += progressGlow_Paint;
            // 
            // lblStatus
            // 
            lblStatus.Dock = DockStyle.Top;
            lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStatus.ForeColor = Color.FromArgb(200, 200, 200);
            lblStatus.Location = new Point(60, 270);
            lblStatus.Name = "lblStatus";
            lblStatus.Padding = new Padding(0, 80, 0, 0);
            lblStatus.Size = new Size(880, 120);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "Initializing application...";
            lblStatus.TextAlign = ContentAlignment.TopCenter;
            // 
            // footerPanel
            // 
            footerPanel.BackColor = Color.Transparent;
            footerPanel.Controls.Add(lblVersion);
            footerPanel.Controls.Add(lblCopyright);
            footerPanel.Dock = DockStyle.Bottom;
            footerPanel.Location = new Point(60, 510);
            footerPanel.Name = "footerPanel";
            footerPanel.Size = new Size(880, 50);
            footerPanel.TabIndex = 4;
            // 
            // lblVersion
            // 
            lblVersion.Dock = DockStyle.Top;
            lblVersion.Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblVersion.ForeColor = Color.FromArgb(130, 130, 130);
            lblVersion.Location = new Point(0, 0);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(880, 22);
            lblVersion.TabIndex = 0;
            lblVersion.Text = "Version 2.1.0";
            lblVersion.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblCopyright
            // 
            lblCopyright.Dock = DockStyle.Bottom;
            lblCopyright.Font = new System.Drawing.Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCopyright.ForeColor = Color.FromArgb(110, 110, 110);
            lblCopyright.Location = new Point(0, 28);
            lblCopyright.Name = "lblCopyright";
            lblCopyright.Size = new Size(880, 22);
            lblCopyright.TabIndex = 1;
            lblCopyright.Text = "© 2026 Nexus Retail ERP. All rights reserved.";
            lblCopyright.TextAlign = ContentAlignment.TopCenter;
            // 
            // animationTimer
            // 
            animationTimer.Interval = 30;
            animationTimer.Tick += AnimationTimer_Tick;
            // 
            // SplashScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 28, 32);
            ClientSize = new Size(1000, 600);
            Controls.Add(mainPanel);
            DoubleBuffered = true;
            Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Name = "SplashScreen";
            Opacity = 0D;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nexus Retail ERP";
            Load += SplashScreen_Load;
            Paint += SplashScreen_Paint;
            mainPanel.ResumeLayout(false);
            logoPanel.ResumeLayout(false);
            progressContainer.ResumeLayout(false);
            footerPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel mainPanel;
        private Panel logoPanel;
        private Label lblAppName;
        private Label lblAppSubtitle;
        private Label lblTagline;
        private Panel progressContainer;
        private Panel progressFill;
        private Panel progressGlow;
        private Label lblStatus;
        private Panel footerPanel;
        private Label lblVersion;
        private Label lblCopyright;
        private System.Windows.Forms.Timer animationTimer;
    }
}