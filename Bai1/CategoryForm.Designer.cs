#nullable disable
namespace Bai1
{
    partial class CategoryForm
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
            lblName = new Label();
            txtName = new TextBox();
            lblType = new Label();
            cmbType = new ComboBox();
            btnAdd = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(18, 20);
            lblName.Name = "lblName";
            lblName.Size = new Size(64, 15);
            lblName.TabIndex = 0;
            lblName.Text = "Tên nhóm:";
            lblName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtName
            // 
            txtName.Location = new Point(118, 18);
            txtName.MaxLength = 1000;
            txtName.Name = "txtName";
            txtName.Size = new Size(314, 23);
            txtName.TabIndex = 1;
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Location = new Point(18, 56);
            lblType.Name = "lblType";
            lblType.Size = new Size(32, 15);
            lblType.TabIndex = 2;
            lblType.Text = "Loại:";
            lblType.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbType
            // 
            cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbType.FormattingEnabled = true;
            cmbType.Items.AddRange(new object[] { "Món ăn", "Đồ uống" });
            cmbType.Location = new Point(118, 54);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(314, 23);
            cmbType.TabIndex = 3;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(230, 108);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(96, 30);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Add New";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(336, 108);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(96, 30);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // CategoryForm
            // 
            AcceptButton = btnAdd;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(450, 160);
            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(lblType);
            Controls.Add(cmbType);
            Controls.Add(btnAdd);
            Controls.Add(btnCancel);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CategoryForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thêm nhóm món";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblName;
        private TextBox txtName;
        private Label lblType;
        private ComboBox cmbType;
        private Button btnAdd;
        private Button btnCancel;
    }
}
