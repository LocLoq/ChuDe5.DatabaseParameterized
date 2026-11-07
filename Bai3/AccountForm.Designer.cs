#nullable disable
namespace Bai3
{
    partial class AccountForm
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
            components = new System.ComponentModel.Container();
            lblAccount = new Label();
            lblFullName = new Label();
            lblPhone = new Label();
            lblPassword = new Label();
            lblEmail = new Label();
            lblRole = new Label();
            txtAccount = new TextBox();
            txtPassword = new TextBox();
            txtFullName = new TextBox();
            txtEmail = new TextBox();
            txtPhone = new TextBox();
            cmbRole = new ComboBox();
            btnNewRole = new Button();
            btnNew = new Button();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnReset = new Button();
            dgvAccounts = new DataGridView();
            ctmAccounts = new ContextMenuStrip(components);
            tsmRoles = new ToolStripMenuItem();
            tsmJournal = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dgvAccounts).BeginInit();
            ctmAccounts.SuspendLayout();
            SuspendLayout();
            // 
            // lblAccount
            // 
            lblAccount.AutoSize = true;
            lblAccount.Location = new Point(12, 20);
            lblAccount.Name = "lblAccount";
            lblAccount.Size = new Size(61, 15);
            lblAccount.TabIndex = 0;
            lblAccount.Text = "Tài khoản:";
            lblAccount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(12, 60);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(46, 15);
            lblFullName.TabIndex = 1;
            lblFullName.Text = "Họ tên:";
            lblFullName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(12, 100);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(64, 15);
            lblPhone.TabIndex = 2;
            lblPhone.Text = "Điện thoại:";
            lblPhone.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(490, 20);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(60, 15);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Mật khẩu:";
            lblPassword.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(490, 60);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(39, 15);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "Email:";
            lblEmail.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Location = new Point(490, 100);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(67, 15);
            lblRole.TabIndex = 5;
            lblRole.Text = "Vai trò mới:";
            lblRole.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtAccount
            // 
            txtAccount.Location = new Point(116, 18);
            txtAccount.MaxLength = 100;
            txtAccount.Name = "txtAccount";
            txtAccount.Size = new Size(320, 23);
            txtAccount.TabIndex = 6;
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPassword.Location = new Point(600, 18);
            txtPassword.MaxLength = 200;
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(388, 23);
            txtPassword.TabIndex = 7;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(116, 58);
            txtFullName.MaxLength = 1000;
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(320, 23);
            txtFullName.TabIndex = 8;
            // 
            // txtEmail
            // 
            txtEmail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtEmail.Location = new Point(600, 58);
            txtEmail.MaxLength = 1000;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(388, 23);
            txtEmail.TabIndex = 9;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(116, 98);
            txtPhone.MaxLength = 200;
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(320, 23);
            txtPhone.TabIndex = 10;
            // 
            // cmbRole
            // 
            cmbRole.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.FormattingEnabled = true;
            cmbRole.Location = new Point(600, 98);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(270, 23);
            cmbRole.TabIndex = 11;
            // 
            // btnNewRole
            // 
            btnNewRole.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNewRole.Location = new Point(882, 94);
            btnNewRole.Name = "btnNewRole";
            btnNewRole.Size = new Size(106, 30);
            btnNewRole.TabIndex = 12;
            btnNewRole.Text = "Thêm vai trò";
            btnNewRole.UseVisualStyleBackColor = true;
            btnNewRole.Click += btnNewRole_Click;
            // 
            // btnNew
            // 
            btnNew.Location = new Point(116, 142);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(100, 30);
            btnNew.TabIndex = 13;
            btnNew.Text = "Nhập mới";
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += btnNew_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(226, 142);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(90, 30);
            btnAdd.TabIndex = 14;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(326, 142);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(100, 30);
            btnUpdate.TabIndex = 15;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(436, 142);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(140, 30);
            btnReset.TabIndex = 16;
            btnReset.Text = "Reset mật khẩu";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // dgvAccounts
            // 
            dgvAccounts.AllowUserToAddRows = false;
            dgvAccounts.AllowUserToDeleteRows = false;
            dgvAccounts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvAccounts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAccounts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAccounts.ContextMenuStrip = ctmAccounts;
            dgvAccounts.Location = new Point(12, 190);
            dgvAccounts.MultiSelect = false;
            dgvAccounts.Name = "dgvAccounts";
            dgvAccounts.ReadOnly = true;
            dgvAccounts.RowHeadersVisible = false;
            dgvAccounts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAccounts.Size = new Size(976, 398);
            dgvAccounts.TabIndex = 17;
            dgvAccounts.CellMouseDown += dgvAccounts_CellMouseDown;
            dgvAccounts.SelectionChanged += dgvAccounts_SelectionChanged;
            // 
            // ctmAccounts
            // 
            ctmAccounts.Items.AddRange(new ToolStripItem[] { tsmRoles, tsmJournal });
            ctmAccounts.Name = "ctmAccounts";
            ctmAccounts.Size = new Size(213, 48);
            // 
            // tsmRoles
            // 
            tsmRoles.Name = "tsmRoles";
            tsmRoles.Size = new Size(212, 22);
            tsmRoles.Text = "Xem danh sách các vai trò";
            tsmRoles.Click += menuRoles_Click;
            // 
            // tsmJournal
            // 
            tsmJournal.Name = "tsmJournal";
            tsmJournal.Size = new Size(212, 22);
            tsmJournal.Text = "Xem nhật ký hoạt động";
            tsmJournal.Click += menuJournal_Click;
            // 
            // AccountForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 600);
            Controls.Add(lblAccount);
            Controls.Add(lblFullName);
            Controls.Add(lblPhone);
            Controls.Add(lblPassword);
            Controls.Add(lblEmail);
            Controls.Add(lblRole);
            Controls.Add(txtAccount);
            Controls.Add(txtPassword);
            Controls.Add(txtFullName);
            Controls.Add(txtEmail);
            Controls.Add(txtPhone);
            Controls.Add(cmbRole);
            Controls.Add(btnNewRole);
            Controls.Add(btnNew);
            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(btnReset);
            Controls.Add(dgvAccounts);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(960, 540);
            Name = "AccountForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý tài khoản";
            Load += AccountForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAccounts).EndInit();
            ctmAccounts.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblAccount;
        private Label lblFullName;
        private Label lblPhone;
        private Label lblPassword;
        private Label lblEmail;
        private Label lblRole;
        private TextBox txtAccount;
        private TextBox txtPassword;
        private TextBox txtFullName;
        private TextBox txtEmail;
        private TextBox txtPhone;
        private ComboBox cmbRole;
        private Button btnNewRole;
        private Button btnNew;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnReset;
        private DataGridView dgvAccounts;
        private ContextMenuStrip ctmAccounts;
        private ToolStripMenuItem tsmRoles;
        private ToolStripMenuItem tsmJournal;
    }
}
