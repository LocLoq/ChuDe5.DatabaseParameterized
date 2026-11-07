#nullable disable
namespace Bai2
{
    partial class OrderDetailsForm
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
            lblHeader = new Label();
            dgvDetails = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvDetails).BeginInit();
            SuspendLayout();
            // 
            // lblHeader
            // 
            lblHeader.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblHeader.Location = new Point(12, 12);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(896, 66);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Thông tin hóa đơn";
            lblHeader.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dgvDetails
            // 
            dgvDetails.AllowUserToAddRows = false;
            dgvDetails.AllowUserToDeleteRows = false;
            dgvDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetails.Location = new Point(12, 90);
            dgvDetails.MultiSelect = false;
            dgvDetails.Name = "dgvDetails";
            dgvDetails.ReadOnly = true;
            dgvDetails.RowHeadersVisible = false;
            dgvDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetails.Size = new Size(896, 358);
            dgvDetails.TabIndex = 1;
            // 
            // OrderDetailsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(920, 460);
            Controls.Add(lblHeader);
            Controls.Add(dgvDetails);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(820, 400);
            Name = "OrderDetailsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chi tiết hóa đơn";
            Load += OrderDetailsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDetails).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblHeader;
        private DataGridView dgvDetails;
    }
}
