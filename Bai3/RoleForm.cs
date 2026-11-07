using System.Data;
using Microsoft.Data.SqlClient;

namespace Bai3;

public partial class RoleForm : Form
{
    public int RoleId { get; private set; }
    public RoleForm() => InitializeComponent();
    private void btnAdd_Click(object sender, EventArgs e)
    {
        var name = txtName.Text.Trim(); if (name.Length == 0) { MessageBox.Show("Nhập tên vai trò."); return; }
        try
        {
            var id = new SqlParameter("@ID", SqlDbType.Int) { Direction = ParameterDirection.Output };
            Database.ExecuteNonQuery("dbo.C5_InsertRole", CommandType.StoredProcedure,
                Database.Param("@RoleName", SqlDbType.NVarChar, name, 1000),
                Database.Param("@Path", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(txtPath.Text) ? null : txtPath.Text.Trim(), 3000),
                Database.Param("@Notes", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(txtNotes.Text) ? null : txtNotes.Text.Trim(), 3000), id);
            RoleId = Convert.ToInt32(id.Value); DialogResult = DialogResult.OK; Close();
        }
        catch (Exception ex) { MessageBox.Show($"Không thêm được vai trò: {ex.Message}"); }
    }
}
