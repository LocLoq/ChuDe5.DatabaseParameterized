using System.Data;

namespace Bai3;

public partial class AccountForm : Form
{
    private bool _newAccount = true;
    public AccountForm() => InitializeComponent();
    private void AccountForm_Load(object sender, EventArgs e) { LoadRoles(); LoadAccounts(); NewAccount(); }
    private void LoadRoles(int? selectedId = null)
    {
        try
        {
            var roles = Database.ReadTable("dbo.C5_Roles");
            cmbRole.DisplayMember = "RoleName"; cmbRole.ValueMember = "ID"; cmbRole.DataSource = roles;
            if (selectedId.HasValue) cmbRole.SelectedValue = selectedId.Value;
        }
        catch (Exception ex) { MessageBox.Show($"Không tải được vai trò: {ex.Message}"); }
    }
    private void LoadAccounts()
    {
        try
        {
            dgvAccounts.DataSource = Database.ReadTable("dbo.C5_Accounts");
            foreach (var (name, title) in new[] { ("AccountName", "Tài khoản"), ("FullName", "Họ tên"), ("Email", "Email"), ("Tell", "Điện thoại"), ("DateCreated", "Ngày tạo") })
                if (dgvAccounts.Columns[name] is DataGridViewColumn column) column.HeaderText = title;
        }
        catch (Exception ex) { MessageBox.Show($"Không tải được tài khoản: {ex.Message}"); }
    }
    private void NewAccount()
    {
        _newAccount = true; dgvAccounts.ClearSelection(); dgvAccounts.CurrentCell = null;
        txtAccount.ReadOnly = false; txtAccount.Clear(); txtPassword.Clear(); txtFullName.Clear(); txtEmail.Clear(); txtPhone.Clear();
        btnAdd.Enabled = true; btnUpdate.Enabled = btnReset.Enabled = false;
    }
    private void btnNew_Click(object sender, EventArgs e) => NewAccount();
    private void dgvAccounts_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvAccounts.CurrentRow?.DataBoundItem is not DataRowView row) return;
        _newAccount = false; txtAccount.ReadOnly = true; txtAccount.Text = row["AccountName"].ToString();
        txtFullName.Text = row["FullName"].ToString(); txtEmail.Text = row["Email"].ToString(); txtPhone.Text = row["Tell"].ToString(); txtPassword.Clear();
        btnAdd.Enabled = false; btnUpdate.Enabled = btnReset.Enabled = true;
    }
    private bool ValidInput(bool passwordRequired)
    {
        if (string.IsNullOrWhiteSpace(txtAccount.Text) || string.IsNullOrWhiteSpace(txtFullName.Text) || (passwordRequired && string.IsNullOrWhiteSpace(txtPassword.Text)))
        { MessageBox.Show("Nhập tài khoản, họ tên và mật khẩu khi thêm mới."); return false; }
        return true;
    }
    private object? Optional(string text) => string.IsNullOrWhiteSpace(text) ? null : text.Trim();
    private void btnAdd_Click(object sender, EventArgs e)
    {
        if (!_newAccount || !ValidInput(true)) return;
        if (cmbRole.SelectedValue is not int role) { MessageBox.Show("Chọn vai trò cho tài khoản."); return; }
        try
        {
            Database.ExecuteNonQuery("dbo.C5_InsertAccount", CommandType.StoredProcedure,
                Database.Param("@AccountName", SqlDbType.NVarChar, txtAccount.Text.Trim(), 100),
                Database.Param("@Password", SqlDbType.NVarChar, txtPassword.Text, 200),
                Database.Param("@FullName", SqlDbType.NVarChar, txtFullName.Text.Trim(), 1000),
                Database.Param("@Email", SqlDbType.NVarChar, Optional(txtEmail.Text), 1000),
                Database.Param("@Tell", SqlDbType.NVarChar, Optional(txtPhone.Text), 200),
                Database.Param("@RoleID", SqlDbType.Int, role));
            LoadAccounts(); NewAccount(); MessageBox.Show("Đã thêm tài khoản.");
        }
        catch (Exception ex) { MessageBox.Show($"Không thêm được tài khoản: {ex.Message}"); }
    }
    private void btnUpdate_Click(object sender, EventArgs e)
    {
        if (_newAccount || !ValidInput(false)) return;
        try
        {
            Database.ExecuteNonQuery("dbo.C5_UpdateAccount", CommandType.StoredProcedure,
                Database.Param("@AccountName", SqlDbType.NVarChar, txtAccount.Text.Trim(), 100),
                Database.Param("@FullName", SqlDbType.NVarChar, txtFullName.Text.Trim(), 1000),
                Database.Param("@Email", SqlDbType.NVarChar, Optional(txtEmail.Text), 1000),
                Database.Param("@Tell", SqlDbType.NVarChar, Optional(txtPhone.Text), 200));
            LoadAccounts(); NewAccount(); MessageBox.Show("Đã cập nhật tài khoản.");
        }
        catch (Exception ex) { MessageBox.Show($"Không cập nhật được tài khoản: {ex.Message}"); }
    }
    private void btnReset_Click(object sender, EventArgs e)
    {
        if (_newAccount || string.IsNullOrWhiteSpace(txtPassword.Text)) { MessageBox.Show("Chọn tài khoản và nhập mật khẩu mới."); return; }
        try
        {
            Database.ExecuteNonQuery("dbo.C5_ResetPassword", CommandType.StoredProcedure,
                Database.Param("@AccountName", SqlDbType.NVarChar, txtAccount.Text.Trim(), 100), Database.Param("@Password", SqlDbType.NVarChar, txtPassword.Text, 200));
            txtPassword.Clear(); MessageBox.Show("Đã đặt lại mật khẩu.");
        }
        catch (Exception ex) { MessageBox.Show($"Không đặt lại được mật khẩu: {ex.Message}"); }
    }
    private void btnNewRole_Click(object sender, EventArgs e)
    {
        using var form = new RoleForm(); if (form.ShowDialog(this) == DialogResult.OK) LoadRoles(form.RoleId);
    }
    private string? SelectedAccount() => (dgvAccounts.CurrentRow?.DataBoundItem as DataRowView)?["AccountName"].ToString();
    private void menuRoles_Click(object sender, EventArgs e)
    {
        var account = SelectedAccount(); if (account == null) return;
        using var form = new AccountRolesForm(account); form.ShowDialog(this); LoadRoles();
    }
    private void menuJournal_Click(object sender, EventArgs e)
    {
        var account = SelectedAccount(); if (account == null) return;
        using var form = new AccountJournalForm(account); form.ShowDialog(this);
    }
    private void dgvAccounts_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
    {
        if (e.Button != MouseButtons.Right) return;
        dgvAccounts.CurrentCell = e.RowIndex >= 0 ? dgvAccounts.Rows[e.RowIndex].Cells[0] : null;
    }
}
