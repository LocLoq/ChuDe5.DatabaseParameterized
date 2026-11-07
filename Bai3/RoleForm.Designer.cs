#nullable disable
namespace Bai3
{
    partial class RoleForm
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
            lblPath = new Label();
            lblNotes = new Label();
            txtName = new TextBox();
            txtPath = new TextBox();
            txtNotes = new TextBox();
            btnAdd = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(18, 20);
            lblName.Name = "lblName";
            lblName.Size = new Size(65, 15);
            lblName.TabIndex = 0;
            lblName.Text = "Tên vai trò:";
            lblName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPath
            // 
            lblPath.AutoSize = true;
            lblPath.Location = new Point(18, 56);
            lblPath.Name = "lblPath";
            lblPath.Size = new Size(69, 15);
            lblPath.TabIndex = 1;
            lblPath.Text = "Đường dẫn:";
            lblPath.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.Location = new Point(18, 92);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(51, 15);
            lblNotes.TabIndex = 2;
            lblNotes.Text = "Ghi chú:";
            lblNotes.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtName
            // 
            txtName.Location = new Point(135, 18);
            txtName.MaxLength = 1000;
            txtName.Name = "txtName";
            txtName.Size = new Size(405, 23);
            txtName.TabIndex = 3;
            // 
            // txtPath
            // 
            txtPath.Location = new Point(135, 54);
            txtPath.MaxLength = 3000;
            txtPath.Name = "txtPath";
            txtPath.Size = new Size(405, 23);
            txtPath.TabIndex = 4;
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(135, 90);
            txtNotes.MaxLength = 3000;
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.ScrollBars = ScrollBars.Vertical;
            txtNotes.Size = new Size(405, 100);
            txtNotes.TabIndex = 5;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(338, 218);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(96, 30);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Add New";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(444, 218);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(96, 30);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // RoleForm
            // 
            AcceptButton = btnAdd;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(560, 270);
            Controls.Add(lblName);
            Controls.Add(lblPath);
            Controls.Add(lblNotes);
            Controls.Add(txtName);
            Controls.Add(txtPath);
            Controls.Add(txtNotes);
            Controls.Add(btnAdd);
            Controls.Add(btnCancel);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RoleForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thêm vai trò";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblName;
        private Label lblPath;
        private Label lblNotes;
        private TextBox txtName;
        private TextBox txtPath;
        private TextBox txtNotes;
        private Button btnAdd;
        private Button btnCancel;
    }
}
