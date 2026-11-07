using System.Data;

namespace Bai2;

public partial class OrderDetailsForm : Form
{
    private readonly int _id;
    public OrderDetailsForm() : this(0) { }
    public OrderDetailsForm(int id) { _id = id; InitializeComponent(); }
    private void OrderDetailsForm_Load(object sender, EventArgs e)
    {
        try
        {
            var header = Database.ReadTable("dbo.C5_OrderHeader", Database.Param("@ID", SqlDbType.Int, _id));
            if (header.Rows.Count == 0) { MessageBox.Show("Không tìm thấy hóa đơn."); Close(); return; }
            var row = header.Rows[0];
            decimal gross = Convert.ToDecimal(row["Amount"]), discount = Convert.ToDecimal(row["Discount"]), tax = Convert.ToDecimal(row["Tax"]);
            var date = row.IsNull("CheckoutDate") ? "Chưa có ngày" : Convert.ToDateTime(row["CheckoutDate"]).ToString("dd/MM/yyyy HH:mm");
            lblHeader.Text = $"#{_id} - {row["Name"]} | Bàn {row["TableName"]} | {date}\nTrước giảm: {gross:N0} | Giảm: {gross * discount:N0} | Thuế: {gross * tax:N0} | Thực thu: {gross * (1 - discount + tax):N0}";
            dgvDetails.DataSource = Database.ReadTable("dbo.C5_OrderDetails", Database.Param("@ID", SqlDbType.Int, _id));
        }
        catch (Exception ex) { MessageBox.Show($"Không tải được chi tiết hóa đơn: {ex.Message}"); }
    }
}
