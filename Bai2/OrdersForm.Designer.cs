#nullable disable
namespace Bai2
{
    partial class OrdersForm
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
            lblFrom = new Label();
            dtFrom = new DateTimePicker();
            lblTo = new Label();
            dtTo = new DateTimePicker();
            btnLoad = new Button();
            dgvOrders = new DataGridView();
            lblTotals = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            SuspendLayout();
            // 
            // lblFrom
            // 
            lblFrom.AutoSize = true;
            lblFrom.Location = new Point(12, 16);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new Size(53, 15);
            lblFrom.TabIndex = 0;
            lblFrom.Text = "Từ ngày:";
            lblFrom.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dtFrom
            // 
            dtFrom.Format = DateTimePickerFormat.Short;
            dtFrom.Location = new Point(80, 14);
            dtFrom.Name = "dtFrom";
            dtFrom.Size = new Size(140, 23);
            dtFrom.TabIndex = 1;
            // 
            // lblTo
            // 
            lblTo.AutoSize = true;
            lblTo.Location = new Point(244, 16);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(60, 15);
            lblTo.TabIndex = 2;
            lblTo.Text = "Đến ngày:";
            lblTo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dtTo
            // 
            dtTo.Format = DateTimePickerFormat.Short;
            dtTo.Location = new Point(320, 14);
            dtTo.Name = "dtTo";
            dtTo.Size = new Size(140, 23);
            dtTo.TabIndex = 3;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(480, 11);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(120, 30);
            btnLoad.TabIndex = 4;
            btnLoad.Text = "Xem hóa đơn";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // dgvOrders
            // 
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.AllowUserToDeleteRows = false;
            dgvOrders.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrders.Location = new Point(12, 52);
            dgvOrders.MultiSelect = false;
            dgvOrders.Name = "dgvOrders";
            dgvOrders.ReadOnly = true;
            dgvOrders.RowHeadersVisible = false;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.Size = new Size(976, 432);
            dgvOrders.TabIndex = 5;
            dgvOrders.CellDoubleClick += dgvOrders_CellDoubleClick;
            // 
            // lblTotals
            // 
            lblTotals.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblTotals.Location = new Point(12, 498);
            lblTotals.Name = "lblTotals";
            lblTotals.Size = new Size(976, 30);
            lblTotals.TabIndex = 6;
            lblTotals.Text = "Trước giảm: 0    Giảm giá: 0    Thuế: 0    Thực thu: 0";
            lblTotals.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // OrdersForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 540);
            Controls.Add(lblFrom);
            Controls.Add(dtFrom);
            Controls.Add(lblTo);
            Controls.Add(dtTo);
            Controls.Add(btnLoad);
            Controls.Add(dgvOrders);
            Controls.Add(lblTotals);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(900, 480);
            Name = "OrdersForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Danh sách hóa đơn";
            Load += OrdersForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblFrom;
        private DateTimePicker dtFrom;
        private Label lblTo;
        private DateTimePicker dtTo;
        private Button btnLoad;
        private DataGridView dgvOrders;
        private Label lblTotals;
    }
}
