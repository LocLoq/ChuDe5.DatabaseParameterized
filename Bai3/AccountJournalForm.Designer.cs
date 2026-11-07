#nullable disable
namespace Bai3
{
    partial class AccountJournalForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblDates = new Label();
            lblOrders = new Label();
            lstDates = new ListBox();
            dgvOrders = new DataGridView();
            lblDetails = new Label();
            dgvDetails = new DataGridView();
            lblSummary = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetails).BeginInit();
            SuspendLayout();
            // 
            // lblDates
            // 
            lblDates.AutoSize = true;
            lblDates.Location = new Point(12, 10);
            lblDates.Name = "lblDates";
            lblDates.Size = new Size(82, 15);
            lblDates.TabIndex = 0;
            lblDates.Text = "Ngày hóa đơn";
            lblDates.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblOrders
            // 
            lblOrders.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblOrders.Location = new Point(188, 10);
            lblOrders.Name = "lblOrders";
            lblOrders.Size = new Size(860, 23);
            lblOrders.TabIndex = 1;
            lblOrders.Text = "Hóa đơn trong ngày";
            lblOrders.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lstDates
            // 
            lstDates.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lstDates.FormattingEnabled = true;
            lstDates.IntegralHeight = false;
            lstDates.Location = new Point(12, 36);
            lstDates.Name = "lstDates";
            lstDates.Size = new Size(160, 510);
            lstDates.TabIndex = 2;
            lstDates.SelectedIndexChanged += lstDates_SelectedIndexChanged;
            // 
            // dgvOrders
            // 
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.AllowUserToDeleteRows = false;
            dgvOrders.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrders.Location = new Point(188, 36);
            dgvOrders.MultiSelect = false;
            dgvOrders.Name = "dgvOrders";
            dgvOrders.ReadOnly = true;
            dgvOrders.RowHeadersVisible = false;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.Size = new Size(860, 220);
            dgvOrders.TabIndex = 3;
            dgvOrders.SelectionChanged += dgvOrders_SelectionChanged;
            // 
            // lblDetails
            // 
            lblDetails.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblDetails.Location = new Point(188, 266);
            lblDetails.Name = "lblDetails";
            lblDetails.Size = new Size(860, 23);
            lblDetails.TabIndex = 4;
            lblDetails.Text = "Các món của hóa đơn đang chọn";
            lblDetails.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dgvDetails
            // 
            dgvDetails.AllowUserToAddRows = false;
            dgvDetails.AllowUserToDeleteRows = false;
            dgvDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetails.Location = new Point(188, 296);
            dgvDetails.MultiSelect = false;
            dgvDetails.Name = "dgvDetails";
            dgvDetails.ReadOnly = true;
            dgvDetails.RowHeadersVisible = false;
            dgvDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetails.Size = new Size(860, 250);
            dgvDetails.TabIndex = 5;
            // 
            // lblSummary
            // 
            lblSummary.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblSummary.Location = new Point(12, 558);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(1036, 30);
            lblSummary.TabIndex = 6;
            lblSummary.Text = "Số hóa đơn: 0    Tổng thực thu: 0";
            lblSummary.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // AccountJournalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1060, 600);
            Controls.Add(lblDates);
            Controls.Add(lblOrders);
            Controls.Add(lstDates);
            Controls.Add(dgvOrders);
            Controls.Add(lblDetails);
            Controls.Add(dgvDetails);
            Controls.Add(lblSummary);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(960, 540);
            Name = "AccountJournalForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nhật ký hoạt động";
            Load += AccountJournalForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetails).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDates;
        private Label lblOrders;
        private ListBox lstDates;
        private DataGridView dgvOrders;
        private Label lblDetails;
        private DataGridView dgvDetails;
        private Label lblSummary;
    }
}
