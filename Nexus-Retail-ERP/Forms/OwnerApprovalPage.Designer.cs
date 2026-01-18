namespace Nexus_Retail_ERP.Forms
{
    partial class OwnerApprovalPage
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            btnClose = new Label();
            pnlGrid = new Panel();
            lblStatus = new Label();
            dgvRequests = new DataGridView();
            pnlActions = new Panel();
            lblActionTitle = new Label();
            lblSelectedInfo = new Label();
            btnApprove = new Button();
            btnReject = new Button();
            btnTabPending = new Button();
            btnTabHistory = new Button();
            pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRequests).BeginInit();
            pnlActions.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(25, 25);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(303, 41);
            lblTitle.TabIndex = 5;
            lblTitle.Text = "Approvals & Requests";
            // 
            // btnClose
            // 
            btnClose.AutoSize = true;
            btnClose.Cursor = Cursors.Hand;
            btnClose.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnClose.ForeColor = Color.LightGray;
            btnClose.Location = new Point(1312, 25);
            btnClose.Margin = new Padding(4, 0, 4, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(30, 32);
            btnClose.TabIndex = 4;
            btnClose.Text = "X";
            // 
            // pnlGrid
            // 
            pnlGrid.Controls.Add(lblStatus);
            pnlGrid.Controls.Add(dgvRequests);
            pnlGrid.Location = new Point(31, 150);
            pnlGrid.Margin = new Padding(4, 4, 4, 4);
            pnlGrid.Name = "pnlGrid";
            pnlGrid.Size = new Size(938, 625);
            pnlGrid.TabIndex = 3;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI Semibold", 10F);
            lblStatus.ForeColor = Color.LightGray;
            lblStatus.Location = new Point(0, 6);
            lblStatus.Margin = new Padding(4, 0, 4, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(149, 23);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Waiting for Action";
            // 
            // dgvRequests
            // 
            dgvRequests.ColumnHeadersHeight = 29;
            dgvRequests.Location = new Point(0, 38);
            dgvRequests.Margin = new Padding(4, 4, 4, 4);
            dgvRequests.Name = "dgvRequests";
            dgvRequests.RowHeadersWidth = 51;
            dgvRequests.Size = new Size(938, 588);
            dgvRequests.TabIndex = 1;
            // 
            // pnlActions
            // 
            pnlActions.BackColor = Color.White;
            pnlActions.Controls.Add(lblActionTitle);
            pnlActions.Controls.Add(lblSelectedInfo);
            pnlActions.Controls.Add(btnApprove);
            pnlActions.Controls.Add(btnReject);
            pnlActions.Location = new Point(1000, 150);
            pnlActions.Margin = new Padding(4, 4, 4, 4);
            pnlActions.Name = "pnlActions";
            pnlActions.Size = new Size(344, 625);
            pnlActions.TabIndex = 2;
            // 
            // lblActionTitle
            // 
            lblActionTitle.AutoSize = true;
            lblActionTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblActionTitle.ForeColor = Color.FromArgb(0, 180, 216);
            lblActionTitle.Location = new Point(19, 25);
            lblActionTitle.Margin = new Padding(4, 0, 4, 0);
            lblActionTitle.Name = "lblActionTitle";
            lblActionTitle.Size = new Size(185, 28);
            lblActionTitle.TabIndex = 0;
            lblActionTitle.Text = "DECISION CENTER";
            // 
            // lblSelectedInfo
            // 
            lblSelectedInfo.Font = new Font("Segoe UI", 11F);
            lblSelectedInfo.ForeColor = Color.DimGray;
            lblSelectedInfo.Location = new Point(19, 75);
            lblSelectedInfo.Margin = new Padding(4, 0, 4, 0);
            lblSelectedInfo.Name = "lblSelectedInfo";
            lblSelectedInfo.Size = new Size(306, 125);
            lblSelectedInfo.TabIndex = 1;
            lblSelectedInfo.Text = "Select a request...";
            // 
            // btnApprove
            // 
            btnApprove.BackColor = Color.SeaGreen;
            btnApprove.FlatStyle = FlatStyle.Flat;
            btnApprove.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnApprove.ForeColor = Color.White;
            btnApprove.Location = new Point(19, 250);
            btnApprove.Margin = new Padding(4, 4, 4, 4);
            btnApprove.Name = "btnApprove";
            btnApprove.Size = new Size(306, 62);
            btnApprove.TabIndex = 2;
            btnApprove.Text = "APPROVE";
            btnApprove.UseVisualStyleBackColor = false;
            btnApprove.Click += btnApprove_Click;
            // 
            // btnReject
            // 
            btnReject.BackColor = Color.FromArgb(239, 68, 68);
            btnReject.FlatStyle = FlatStyle.Flat;
            btnReject.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnReject.ForeColor = Color.White;
            btnReject.Location = new Point(19, 325);
            btnReject.Margin = new Padding(4, 4, 4, 4);
            btnReject.Name = "btnReject";
            btnReject.Size = new Size(306, 62);
            btnReject.TabIndex = 3;
            btnReject.Text = "REJECT";
            btnReject.UseVisualStyleBackColor = false;
            // 
            // btnTabPending
            // 
            btnTabPending.Location = new Point(31, 88);
            btnTabPending.Margin = new Padding(4, 4, 4, 4);
            btnTabPending.Name = "btnTabPending";
            btnTabPending.Size = new Size(225, 50);
            btnTabPending.TabIndex = 1;
            btnTabPending.Text = "Pending Requests";
            // 
            // btnTabHistory
            // 
            btnTabHistory.Location = new Point(262, 88);
            btnTabHistory.Margin = new Padding(4, 4, 4, 4);
            btnTabHistory.Name = "btnTabHistory";
            btnTabHistory.Size = new Size(225, 50);
            btnTabHistory.TabIndex = 0;
            btnTabHistory.Text = "History Log";
            // 
            // OwnerApprovalPage
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1375, 812);
            Controls.Add(btnTabHistory);
            Controls.Add(btnTabPending);
            Controls.Add(pnlActions);
            Controls.Add(pnlGrid);
            Controls.Add(btnClose);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 4, 4, 4);
            Name = "OwnerApprovalPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Owner Approvals";
            pnlGrid.ResumeLayout(false);
            pnlGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRequests).EndInit();
            pnlActions.ResumeLayout(false);
            pnlActions.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }


        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label btnClose;
        private System.Windows.Forms.Button btnTabPending;
        private System.Windows.Forms.Button btnTabHistory;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgvRequests;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Label lblActionTitle;
        private System.Windows.Forms.Label lblSelectedInfo;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnReject;
    }
}