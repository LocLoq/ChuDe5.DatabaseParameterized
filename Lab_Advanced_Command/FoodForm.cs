using System.Data;
using Microsoft.Data.SqlClient;

namespace Lab_Advanced_Command;

public partial class FoodForm : Form
{
    private DataTable? _foods;
    public FoodForm() => InitializeComponent();

    private void FoodForm_Load(object sender, EventArgs e) => LoadCategories();

    private void LoadCategories(int? selectedId = null)
    {
        try
        {
            using var reader = Database.ExecuteQuery("SELECT ID, Name, Type FROM dbo.Category ORDER BY Name, ID");
            var categories = new DataTable(); categories.Load(reader);
            cbbCategory.DisplayMember = "Name";
            cbbCategory.ValueMember = "ID";
            cbbCategory.DataSource = categories;
            if (selectedId.HasValue) cbbCategory.SelectedValue = selectedId.Value;
            if (categories.Rows.Count == 0) { _foods = null; dgvFoodList.DataSource = null; lblQuantity.Text = "0"; lblCateName.Text = ""; }
        }
        catch (Exception ex) { MessageBox.Show($"Không tải được nhóm món: {ex.Message}"); }
    }

    private void cbbCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cbbCategory.SelectedValue is not int categoryId) return;
        try
        {
            using var reader = Database.ExecuteQuery("SELECT ID, Name, Unit, FoodCategoryID, Price, Notes FROM dbo.Food WHERE FoodCategoryID=@categoryID ORDER BY ID",
                new Dictionary<string, object> { ["@categoryID"] = categoryId }, new List<SqlDbType> { SqlDbType.Int });
            _foods = new DataTable(); _foods.Load(reader);
            lblCateName.Text = cbbCategory.Text;
            ApplyFilter();
        }
        catch (Exception ex) { MessageBox.Show($"Không tải được món ăn: {ex.Message}"); }
    }

    private void txtSearchByName_TextChanged(object sender, EventArgs e) => ApplyFilter();

    private void ApplyFilter()
    {
        if (_foods == null) return;
        var text = txtSearchByName.Text.Replace("'", "''").Replace("[", "[[]").Replace("%", "[%]").Replace("*", "[*]");
        var view = new DataView(_foods) { RowFilter = $"Name LIKE '%{text}%'", Sort = "Price DESC" };
        dgvFoodList.DataSource = view;
        foreach (var (name, title) in new[] { ("ID", "Mã món"), ("Name", "Tên món"), ("Unit", "Đơn vị"), ("FoodCategoryID", "Mã nhóm"), ("Price", "Đơn giá"), ("Notes", "Ghi chú") })
            if (dgvFoodList.Columns[name] is DataGridViewColumn column) column.HeaderText = title;
        lblQuantity.Text = view.Count.ToString();
    }

    private DataRowView? SelectedFood() => dgvFoodList.CurrentRow?.DataBoundItem as DataRowView;
    private void dgvFoodList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
    {
        if (e.Button != MouseButtons.Right) return;
        dgvFoodList.CurrentCell = e.RowIndex >= 0 ? dgvFoodList.Rows[e.RowIndex].Cells[0] : null;
    }
    private void menuQuantity_Click(object sender, EventArgs e)
    {
        var food = SelectedFood(); if (food == null) return;
        try
        {
            var quantity = new SqlParameter("@Quantity", SqlDbType.Int) { Direction = ParameterDirection.Output };
            Database.ExecuteNonQuery("SELECT @Quantity=COALESCE(SUM(Quantity),0) FROM dbo.BillDetails WHERE FoodID=@FoodID", CommandType.Text,
                Database.Param("@FoodID", SqlDbType.Int, food["ID"]), quantity);
            MessageBox.Show($"Tổng số lượng món {food["Name"]} đã bán: {quantity.Value} {food["Unit"]}");
        }
        catch (Exception ex) { MessageBox.Show($"Không tính được số lượng: {ex.Message}"); }
    }
    private void menuAdd_Click(object sender, EventArgs e) => EditFood(null);
    private void menuUpdate_Click(object sender, EventArgs e)
    {
        var food = SelectedFood(); if (food != null) EditFood(food);
    }
    private void EditFood(DataRowView? food)
    {
        using var form = new FoodInfoForm(food, cbbCategory.SelectedValue is int id ? id : null);
        if (form.ShowDialog(this) == DialogResult.OK) LoadCategories(form.CategoryId);
    }
}
