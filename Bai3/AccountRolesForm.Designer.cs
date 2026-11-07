#nullable disable
namespace Bai3
{
    partial class AccountRolesForm
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
            dgvRoles = new DataGridView();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvRoles).BeginInit();
            SuspendLayout();
            // 
            // dgvRoles
            // 
            dgvRoles.AllowUserToAddRows = false;
            dgvRoles.AllowUserToDeleteRows = false;
            dgvRoles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvRoles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRoles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRoles.Location = new Point(12, 12);
            dgvRoles.MultiSelect = false;
            dgvRoles.Name = "dgvRoles";
            dgvRoles.RowHeadersVisible = false;
            dgvRoles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRoles.Size = new Size(836, 406);
            dgvRoles.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAdd.Location = new Point(536, 434);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(96, 30);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Add New";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnUpdate.Location = new Point(642, 434);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(96, 30);
            btnUpdate.TabIndex = 2;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(748, 434);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(96, 30);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // AccountRolesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(860, 480);
            Controls.Add(dgvRoles);
            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(btnCancel);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(760, 400);
            Name = "AccountRolesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Vai trò tài khoản";
            Load += AccountRolesForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRoles).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvRoles;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnCancel;
    }
}
