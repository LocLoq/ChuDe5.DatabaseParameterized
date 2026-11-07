using System.Data;

namespace Bai2;

public partial class OrdersForm : Form
{
    public OrdersForm() { InitializeComponent(); dtFrom.Value = DateTime.Today.AddDays(-30); }
    private void OrdersForm_Load(object sender, EventArgs e) => LoadOrders();
    private void btnLoad_Click(object sender, EventArgs e) => LoadOrders();
    private void LoadOrders()
    {
        if (dtFrom.Value.Date > dtTo.Value.Date) { MessageBox.Show("Ngày bắt đầu phải trước hoặc bằng ngày kết thúc."); return; }
        try
        {
            var table = Database.ReadTable("dbo.C5_Orders", Database.Param("@From", SqlDbType.Date, dtFrom.Value.Date), Database.Param("@To", SqlDbType.Date, dtTo.Value.Date));
            dgvOrders.DataSource = table;
            foreach (var (name, title) in new[] { ("ID", "Mã hóa đơn"), ("Name", "Tên hóa đơn"), ("TableName", "Bàn"), ("CheckoutDate", "Ngày thanh toán"), ("Gross", "Trước giảm"), ("Discount", "Giảm giá"), ("Tax", "Thuế"), ("Net", "Thực thu") })
                if (dgvOrders.Columns[name] is DataGridViewColumn column) column.HeaderText = title;
            decimal gross = 0, discount = 0, tax = 0, net = 0;
            foreach (DataRow row in table.Rows)
            { gross += (decimal)row["Gross"]; discount += (decimal)row["Discount"]; tax += (decimal)row["Tax"]; net += (decimal)row["Net"]; }
            lblTotals.Text = $"Trước giảm: {gross:N0}    Giảm giá: {discount:N0}    Thuế: {tax:N0}    Thực thu: {net:N0}";
        }
        catch (Exception ex) { MessageBox.Show($"Không tải được hóa đơn: {ex.Message}"); }
    }
    private void dgvOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || dgvOrders.Rows[e.RowIndex].DataBoundItem is not DataRowView row) return;
        using var form = new OrderDetailsForm(Convert.ToInt32(row["ID"])); form.ShowDialog(this);
    }
}
