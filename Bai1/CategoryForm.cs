using System.Data;
using Microsoft.Data.SqlClient;

namespace Bai1;

public partial class CategoryForm : Form
{
    public int CategoryId { get; private set; }
    public CategoryForm() => InitializeComponent();
    private void btnAdd_Click(object sender, EventArgs e)
    {
        var name = txtName.Text.Trim();
        if (name.Length == 0 || cmbType.SelectedIndex < 0) { MessageBox.Show("Nhập tên và chọn loại nhóm món."); return; }
        try
        {
            var id = new SqlParameter("@ID", SqlDbType.Int) { Direction = ParameterDirection.Output };
            Database.ExecuteNonQuery("dbo.C5_InsertCategory", CommandType.StoredProcedure,
                Database.Param("@Name", SqlDbType.NVarChar, name, 1000),
                Database.Param("@Type", SqlDbType.Int, cmbType.SelectedIndex == 0 ? 1 : 0), id);
            CategoryId = Convert.ToInt32(id.Value); DialogResult = DialogResult.OK; Close();
        }
        catch (Exception ex) { MessageBox.Show($"Không thêm được nhóm món: {ex.Message}"); }
    }
}
