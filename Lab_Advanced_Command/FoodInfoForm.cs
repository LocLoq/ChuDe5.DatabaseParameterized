using System.Data;
using Microsoft.Data.SqlClient;

namespace Lab_Advanced_Command;

public partial class FoodInfoForm : Form
{
    private readonly DataRowView? _food;
    private readonly int? _initialCategory;
    public int CategoryId { get; private set; }
    public FoodInfoForm() : this(null, null) { }
    public FoodInfoForm(DataRowView? food, int? categoryId)
    {
        _food = food; _initialCategory = categoryId; InitializeComponent();
    }
    private void FoodInfoForm_Load(object sender, EventArgs e)
    {
        LoadCategories(_food == null ? _initialCategory : Convert.ToInt32(_food["FoodCategoryID"]));
        btnAdd.Enabled = _food == null; btnUpdate.Enabled = _food != null;
        if (_food == null) return;
        txtID.Text = _food["ID"].ToString(); txtName.Text = _food["Name"].ToString();
        txtUnit.Text = _food["Unit"].ToString(); txtPrice.Text = _food["Price"].ToString();
        txtNotes.Text = _food["Notes"].ToString();
    }
    private void LoadCategories(int? selectedId)
    {
        try
        {
            using var reader = Database.ExecuteQuery("SELECT ID, Name FROM dbo.Category ORDER BY Name, ID");
            var table = new DataTable(); table.Load(reader);
            cbbCatName.DisplayMember = "Name"; cbbCatName.ValueMember = "ID"; cbbCatName.DataSource = table;
            if (selectedId.HasValue) cbbCatName.SelectedValue = selectedId.Value;
        }
        catch (Exception ex) { MessageBox.Show($"Không tải được nhóm món: {ex.Message}"); }
    }
    private SqlParameter[]? ReadParameters(bool adding)
    {
        var name = txtName.Text.Trim(); var unit = txtUnit.Text.Trim();
        if (name.Length == 0 || unit.Length == 0 || cbbCatName.SelectedValue is not int id ||
            !int.TryParse(txtPrice.Text, out int price) || price < 0)
        { MessageBox.Show("Nhập tên, đơn vị, chọn nhóm và nhập giá là số nguyên không âm."); return null; }
        CategoryId = id;
        return new[] {
            adding ? new SqlParameter("@ID", SqlDbType.Int) { Direction = ParameterDirection.Output }
                   : Database.Param("@ID", SqlDbType.Int, int.Parse(txtID.Text)),
            Database.Param("@Name", SqlDbType.NVarChar, name, 1000),
            Database.Param("@Unit", SqlDbType.NVarChar, unit, 100),
            Database.Param("@FoodCategoryID", SqlDbType.Int, id),
            Database.Param("@Price", SqlDbType.Int, price),
            Database.Param("@Notes", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(txtNotes.Text) ? null : txtNotes.Text.Trim(), 3000)
        };
    }
    private void btnAdd_Click(object sender, EventArgs e)
    {
        var parameters = ReadParameters(true); if (parameters == null) return;
        try
        {
            Database.ExecuteNonQuery("EXEC dbo.C5_InsertFood @ID OUTPUT, @Name, @Unit, @FoodCategoryID, @Price, @Notes", CommandType.Text, parameters);
            MessageBox.Show($"Đã thêm món ăn, mã {parameters[0].Value}."); DialogResult = DialogResult.OK; Close();
        }
        catch (Exception ex) { MessageBox.Show($"Không thêm được món ăn: {ex.Message}"); }
    }
    private void btnUpdate_Click(object sender, EventArgs e)
    {
        var parameters = ReadParameters(false); if (parameters == null) return;
        try
        {
            var result = new SqlParameter("@Result", SqlDbType.Int) { Direction = ParameterDirection.ReturnValue };
            Database.ExecuteNonQuery("dbo.C5_UpdateFood", CommandType.StoredProcedure, parameters.Append(result).ToArray());
            if (Convert.ToInt32(result.Value) != 1) { MessageBox.Show("Không tìm thấy món ăn."); return; }
            DialogResult = DialogResult.OK; Close();
        }
        catch (Exception ex) { MessageBox.Show($"Không cập nhật được món ăn: {ex.Message}"); }
    }
}
