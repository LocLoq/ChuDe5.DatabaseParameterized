using System.Data;

namespace Bai3;

public partial class AccountJournalForm : Form
{
    private readonly string _account;
    private DataTable? _orders;
    private sealed record DateItem(DateTime? Date)
    {
        public override string ToString() => Date?.ToString("dd/MM/yyyy") ?? "Chưa có ngày";
    }
    public AccountJournalForm() : this(string.Empty) { }
    public AccountJournalForm(string account) { _account = account; InitializeComponent(); Text = $"Nhật ký hoạt động - {account}"; }
    private void AccountJournalForm_Load(object sender, EventArgs e)
    {
        try
        {
            _orders = Database.ReadTable("dbo.C5_AccountJournal", Database.Param("@AccountName", SqlDbType.NVarChar, _account, 100));
            decimal total = 0;
            var dates = new HashSet<DateTime?>();
            foreach (DataRow row in _orders.Rows)
            {
                total += Convert.ToDecimal(row["Net"]);
                dates.Add(row.IsNull("CheckoutDate") ? null : Convert.ToDateTime(row["CheckoutDate"]).Date);
            }
            lblSummary.Text = $"Số hóa đơn: {_orders.Rows.Count}    Tổng thực thu: {total:N0}";
            foreach (var date in dates.OrderByDescending(date => date)) lstDates.Items.Add(new DateItem(date));
            if (lstDates.Items.Count > 0) lstDates.SelectedIndex = 0;
        }
        catch (Exception ex) { MessageBox.Show($"Không tải được nhật ký: {ex.Message}"); }
    }
    private void lstDates_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (_orders == null || lstDates.SelectedItem is not DateItem selected) return;
        var filtered = _orders.Clone();
        foreach (DataRow row in _orders.Rows)
        {
            DateTime? date = row.IsNull("CheckoutDate") ? null : Convert.ToDateTime(row["CheckoutDate"]).Date;
            if (date == selected.Date) filtered.ImportRow(row);
        }
        dgvOrders.DataSource = filtered;
        foreach (var (name, title) in new[] { ("ID", "Mã hóa đơn"), ("Name", "Tên hóa đơn"), ("TableName", "Bàn"), ("CheckoutDate", "Ngày thanh toán"), ("Status", "Đã thanh toán"), ("Gross", "Trước giảm"), ("Net", "Thực thu") })
            if (dgvOrders.Columns[name] is DataGridViewColumn column) column.HeaderText = title;
        if (filtered.Rows.Count == 0) dgvDetails.DataSource = null;
    }
    private void dgvOrders_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvOrders.CurrentRow?.DataBoundItem is not DataRowView row) { dgvDetails.DataSource = null; return; }
        try { dgvDetails.DataSource = Database.ReadTable("dbo.C5_OrderDetails", Database.Param("@ID", SqlDbType.Int, row["ID"])); }
        catch (Exception ex) { MessageBox.Show($"Không tải được món trong hóa đơn: {ex.Message}"); }
    }
}
