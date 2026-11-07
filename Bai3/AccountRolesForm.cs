using System.Data;
using Microsoft.Data.SqlClient;

namespace Bai3;

public partial class AccountRolesForm : Form
{
    private readonly string _account;
    private DataTable? _roles;
    public AccountRolesForm() : this(string.Empty) { }
    public AccountRolesForm(string account) { _account = account; InitializeComponent(); Text = $"Vai trò của {account}"; }
    private void AccountRolesForm_Load(object sender, EventArgs e) => LoadRoles();
    private void LoadRoles(Dictionary<int, bool>? previous = null)
    {
        try
        {
            _roles = Database.ReadTable("dbo.C5_AccountRoles", Database.Param("@AccountName", SqlDbType.NVarChar, _account, 100));
            _roles.Columns["Selected"]!.ReadOnly = false;
            if (previous != null)
                foreach (DataRow row in _roles.Rows)
                    if (previous.TryGetValue(Convert.ToInt32(row["ID"]), out bool selected)) row["Selected"] = selected;
            dgvRoles.DataSource = _roles;
            foreach (DataGridViewColumn column in dgvRoles.Columns) column.ReadOnly = column.Name != "Selected";
            dgvRoles.Columns["Selected"]!.HeaderText = "Được gán";
            foreach (var (name, title) in new[] { ("ID", "Mã vai trò"), ("RoleName", "Tên vai trò"), ("Path", "Đường dẫn"), ("Notes", "Ghi chú") })
                if (dgvRoles.Columns[name] is DataGridViewColumn column) column.HeaderText = title;
        }
        catch (Exception ex) { MessageBox.Show($"Không tải được vai trò: {ex.Message}"); }
    }
    private void CommitGrid()
    {
        dgvRoles.EndEdit();
        if (dgvRoles.DataSource is object source && BindingContext?[source] is CurrencyManager manager) manager.EndCurrentEdit();
    }
    private void btnAdd_Click(object sender, EventArgs e)
    {
        CommitGrid();
        var previous = _roles?.Rows.Cast<DataRow>().ToDictionary(row => Convert.ToInt32(row["ID"]), row => Convert.ToBoolean(row["Selected"])) ?? new();
        using var form = new RoleForm();
        if (form.ShowDialog(this) == DialogResult.OK) { previous[form.RoleId] = true; LoadRoles(previous); }
    }
    private void btnUpdate_Click(object sender, EventArgs e)
    {
        if (_roles == null) return; CommitGrid();
        try
        {
            using var connection = new SqlConnection(Program.ConnectionString); connection.Open();
            using var transaction = connection.BeginTransaction();
            foreach (DataRow row in _roles.Rows)
                Database.ExecuteNonQuery("dbo.C5_SetAccountRole", CommandType.StoredProcedure, connection, transaction,
                    Database.Param("@AccountName", SqlDbType.NVarChar, _account, 100),
                    Database.Param("@RoleID", SqlDbType.Int, row["ID"]), Database.Param("@Selected", SqlDbType.Bit, row["Selected"]));
            transaction.Commit(); MessageBox.Show("Đã cập nhật vai trò."); DialogResult = DialogResult.OK; Close();
        }
        catch (Exception ex) { MessageBox.Show($"Không cập nhật được vai trò: {ex.Message}"); }
    }
}
