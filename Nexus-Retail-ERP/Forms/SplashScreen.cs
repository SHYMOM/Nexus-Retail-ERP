using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Nexus_Retail_ERP
{
    public partial class SplashScreen : Form
    {
        private int animationTick = 0;
        private int fadeCounter = 0;
        private int progressValue = 0;
        private int statusChangeCounter = 0;
        private int currentStatusIndex = 0;
        private float logoScale = 0.8f;
        private bool fadeInComplete = false;
        private bool loadingComplete = false;

        private readonly string[] statusMessages =
        {
            "Initializing application...",
            "Loading core modules...",
            "Connecting to database services...",
            "Verifying system licenses...",
            "Preparing workspace environment...",
            "Finalizing startup sequence...",
            "Ready"
        };

        public SplashScreen()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                         ControlStyles.AllPaintingInWmPaint |
                         ControlStyles.UserPaint, true);
            this.UpdateStyles();
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            progressContainer.Left = (this.ClientSize.Width - progressContainer.Width) / 2;
            progressFill.Width = 0;
            lblStatus.Text = statusMessages[0];
            animationTimer.Start();
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            animationTick++;

            // 25 ticks ~ 0.75 seconds
            if (fadeCounter < 25 && !fadeInComplete)
            {
                fadeCounter++;
                this.Opacity = Math.Min(1.0, fadeCounter / 25.0);
                logoScale = 0.8f + (0.2f * (fadeCounter / 25.0f));

                if (fadeCounter >= 25)
                {
                    fadeInComplete = true;
                    this.Opacity = 1.0;
                }

                this.Invalidate();
                return;
            }

            if (progressValue < 100 && fadeInComplete)
            {
                float progressSpeed = 1.0f + (progressValue / 100.0f) * 0.5f;
                progressValue = Math.Min(100, progressValue + (int)progressSpeed);

                int targetWidth = (int)(progressContainer.Width * (progressValue / 100.0));
                progressFill.Width = targetWidth;

                // Update status message every 17 ticks (~0.5 seconds)
                statusChangeCounter++;
                if (statusChangeCounter >= 17 && currentStatusIndex < statusMessages.Length - 1)
                {
                    currentStatusIndex++;
                    lblStatus.Text = statusMessages[currentStatusIndex];
                    statusChangeCounter = 0;
                }

                if (progressValue > 80)
                {
                    float pulse = (float)(0.85 + Math.Sin(animationTick * 0.15) * 0.15);
                    int r = (int)(0 * pulse);
                    int g = (int)(180 * pulse);
                    int b = (int)(216 * pulse);
                    progressFill.BackColor = Color.FromArgb(255, r, g, b);
                }

                // Loading complete
                if (progressValue >= 100 && !loadingComplete)
                {
                    loadingComplete = true;
                    lblStatus.Text = statusMessages[statusMessages.Length - 1];
                    animationTimer.Stop();

                    System.Threading.Tasks.Task.Delay(400).ContinueWith(_ =>
                    {
                        if (this.InvokeRequired)
                        {
                            this.Invoke(new Action(BeginFadeOut));
                        }
                        else
                        {
                            BeginFadeOut();
                        }
                    });
                }
            }
            progressGlow.Invalidate();
        }

        private void BeginFadeOut()
        {
            System.Windows.Forms.Timer fadeOutTimer = new System.Windows.Forms.Timer();
            fadeOutTimer.Interval = 30;
            int fadeOutCounter = 0;

            fadeOutTimer.Tick += (s, args) =>
            {
                fadeOutCounter++;
                this.Opacity = Math.Max(0, 1.0 - (fadeOutCounter / 20.0));

                if (fadeOutCounter >= 20)
                {
                    fadeOutTimer.Stop();
                    this.Hide();

                    // Transition to Login Form

                    this.Close();
                }
            };

            fadeOutTimer.Start();
        }

        private void SplashScreen_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            using (LinearGradientBrush bgBrush = new LinearGradientBrush(
                this.ClientRectangle,
                Color.FromArgb(48, 52, 60),
                Color.FromArgb(38, 42, 50),
                45f))
            {
                g.FillRectangle(bgBrush, this.ClientRectangle);
            }

            if (fadeInComplete)
            {
                Rectangle topOverlay = new Rectangle(0, 0, this.Width, this.Height / 2);
                using (LinearGradientBrush accentBrush = new LinearGradientBrush(
                    topOverlay,
                    Color.FromArgb(12, 0, 180, 216),
                    Color.FromArgb(0, 0, 180, 216),
                    LinearGradientMode.Vertical))
                {
                    g.FillRectangle(accentBrush, topOverlay);
                }
            }

            using (Pen borderPen = new Pen(Color.FromArgb(80, 85, 95), 1))
            {
                g.DrawRectangle(borderPen, 0, 0, this.Width - 1, this.Height - 1);
            }

            using (Pen shadowPen = new Pen(Color.FromArgb(15, 0, 0, 0), 1))
            {
                g.DrawRectangle(shadowPen, 1, 1, this.Width - 3, this.Height - 3);
            }
        }

        private void progressGlow_Paint(object sender, PaintEventArgs e)
        {
            if (!fadeInComplete || loadingComplete) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            float glowIntensity = (float)(0.3 + Math.Sin(animationTick * 0.1) * 0.15);
            int alpha = (int)(glowIntensity * 255);

            using (Pen glowPen = new Pen(Color.FromArgb(alpha, 0, 180, 216), 2))
            {
                g.DrawRectangle(glowPen, -2, -2, progressContainer.Width + 3, progressContainer.Height + 3);
            }

            using (Pen softGlowPen = new Pen(Color.FromArgb(alpha / 2, 0, 180, 216), 4))
            {
                g.DrawRectangle(softGlowPen, -4, -4, progressContainer.Width + 7, progressContainer.Height + 7);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Prevent default background painting for custom gradient rendering
        }
    }
}