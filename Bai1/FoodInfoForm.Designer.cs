#nullable disable
namespace Bai1
{
    partial class FoodInfoForm
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
            lblID = new Label();
            lblName = new Label();
            lblUnit = new Label();
            lblCategory = new Label();
            lblPrice = new Label();
            lblNotes = new Label();
            txtID = new TextBox();
            txtName = new TextBox();
            txtUnit = new TextBox();
            cbbCatName = new ComboBox();
            btnNewCategory = new Button();
            txtPrice = new TextBox();
            txtNotes = new TextBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.Location = new Point(18, 20);
            lblID.Name = "lblID";
            lblID.Size = new Size(55, 15);
            lblID.TabIndex = 0;
            lblID.Text = "Mã món:";
            lblID.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(18, 56);
            lblName.Name = "lblName";
            lblName.Size = new Size(57, 15);
            lblName.TabIndex = 1;
            lblName.Text = "Tên món:";
            lblName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblUnit
            // 
            lblUnit.AutoSize = true;
            lblUnit.Location = new Point(18, 92);
            lblUnit.Name = "lblUnit";
            lblUnit.Size = new Size(44, 15);
            lblUnit.TabIndex = 2;
            lblUnit.Text = "Đơn vị:";
            lblUnit.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(18, 128);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(72, 15);
            lblCategory.TabIndex = 3;
            lblCategory.Text = "Nhóm món:";
            lblCategory.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(18, 164);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(51, 15);
            lblPrice.TabIndex = 4;
            lblPrice.Text = "Đơn giá:";
            lblPrice.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.Location = new Point(18, 200);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(51, 15);
            lblNotes.TabIndex = 5;
            lblNotes.Text = "Ghi chú:";
            lblNotes.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtID
            // 
            txtID.Location = new Point(135, 18);
            txtID.Name = "txtID";
            txtID.ReadOnly = true;
            txtID.Size = new Size(140, 23);
            txtID.TabIndex = 6;
            txtID.TabStop = false;
            // 
            // txtName
            // 
            txtName.Location = new Point(135, 54);
            txtName.MaxLength = 1000;
            txtName.Name = "txtName";
            txtName.Size = new Size(405, 23);
            txtName.TabIndex = 7;
            // 
            // txtUnit
            // 
            txtUnit.Location = new Point(135, 90);
            txtUnit.MaxLength = 100;
            txtUnit.Name = "txtUnit";
            txtUnit.Size = new Size(405, 23);
            txtUnit.TabIndex = 8;
            // 
            // cbbCatName
            // 
            cbbCatName.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbCatName.FormattingEnabled = true;
            cbbCatName.Location = new Point(135, 126);
            cbbCatName.Name = "cbbCatName";
            cbbCatName.Size = new Size(300, 23);
            cbbCatName.TabIndex = 9;
            // 
            // btnNewCategory
            // 
            btnNewCategory.Location = new Point(445, 124);
            btnNewCategory.Name = "btnNewCategory";
            btnNewCategory.Size = new Size(95, 27);
            btnNewCategory.TabIndex = 10;
            btnNewCategory.Text = "Add New";
            btnNewCategory.UseVisualStyleBackColor = true;
            btnNewCategory.Click += btnNewCategory_Click;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(135, 162);
            txtPrice.MaxLength = 10;
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(180, 23);
            txtPrice.TabIndex = 11;
            txtPrice.Text = "0";
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(135, 198);
            txtNotes.MaxLength = 3000;
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.ScrollBars = ScrollBars.Vertical;
            txtNotes.Size = new Size(405, 70);
            txtNotes.TabIndex = 12;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(232, 290);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(96, 30);
            btnAdd.TabIndex = 13;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(338, 290);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(96, 30);
            btnUpdate.TabIndex = 14;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(444, 290);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(96, 30);
            btnCancel.TabIndex = 15;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // FoodInfoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(560, 340);
            Controls.Add(lblID);
            Controls.Add(lblName);
            Controls.Add(lblUnit);
            Controls.Add(lblCategory);
            Controls.Add(lblPrice);
            Controls.Add(lblNotes);
            Controls.Add(txtID);
            Controls.Add(txtName);
            Controls.Add(txtUnit);
            Controls.Add(cbbCatName);
            Controls.Add(btnNewCategory);
            Controls.Add(txtPrice);
            Controls.Add(txtNotes);
            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(btnCancel);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FoodInfoForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thông tin món ăn";
            Load += FoodInfoForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblID;
        private Label lblName;
        private Label lblUnit;
        private Label lblCategory;
        private Label lblPrice;
        private Label lblNotes;
        private TextBox txtID;
        private TextBox txtName;
        private TextBox txtUnit;
        private ComboBox cbbCatName;
        private Button btnNewCategory;
        private TextBox txtPrice;
        private TextBox txtNotes;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnCancel;
    }
}
