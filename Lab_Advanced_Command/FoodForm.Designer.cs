#nullable disable
namespace Lab_Advanced_Command
{
    partial class FoodForm
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
            lblCategory = new Label();
            cbbCategory = new ComboBox();
            lblSearch = new Label();
            txtSearchByName = new TextBox();
            dgvFoodList = new DataGridView();
            ctmFoodList = new ContextMenuStrip(components);
            tsmCalculateQuantity = new ToolStripMenuItem();
            tsmSeparator = new ToolStripSeparator();
            tsmAddFood = new ToolStripMenuItem();
            tsmUpdateFood = new ToolStripMenuItem();
            lblCountCaption = new Label();
            lblQuantity = new Label();
            lblCategoryCaption = new Label();
            lblCateName = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvFoodList).BeginInit();
            ctmFoodList.SuspendLayout();
            SuspendLayout();
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(12, 15);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(102, 15);
            lblCategory.TabIndex = 0;
            lblCategory.Text = "Chọn nhóm món:";
            lblCategory.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cbbCategory
            // 
            cbbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbCategory.FormattingEnabled = true;
            cbbCategory.Location = new Point(132, 14);
            cbbCategory.Name = "cbbCategory";
            cbbCategory.Size = new Size(220, 23);
            cbbCategory.TabIndex = 1;
            cbbCategory.SelectedIndexChanged += cbbCategory_SelectedIndexChanged;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(392, 15);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(78, 15);
            lblSearch.TabIndex = 2;
            lblSearch.Text = "Tìm theo tên:";
            lblSearch.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtSearchByName
            // 
            txtSearchByName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearchByName.Location = new Point(490, 14);
            txtSearchByName.Name = "txtSearchByName";
            txtSearchByName.Size = new Size(358, 23);
            txtSearchByName.TabIndex = 3;
            txtSearchByName.TextChanged += txtSearchByName_TextChanged;
            // 
            // dgvFoodList
            // 
            dgvFoodList.AllowUserToAddRows = false;
            dgvFoodList.AllowUserToDeleteRows = false;
            dgvFoodList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvFoodList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFoodList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFoodList.ContextMenuStrip = ctmFoodList;
            dgvFoodList.Location = new Point(12, 52);
            dgvFoodList.MultiSelect = false;
            dgvFoodList.Name = "dgvFoodList";
            dgvFoodList.ReadOnly = true;
            dgvFoodList.RowHeadersVisible = false;
            dgvFoodList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFoodList.Size = new Size(836, 404);
            dgvFoodList.TabIndex = 4;
            dgvFoodList.CellMouseDown += dgvFoodList_CellMouseDown;
            // 
            // ctmFoodList
            // 
            ctmFoodList.Items.AddRange(new ToolStripItem[] { tsmCalculateQuantity, tsmSeparator, tsmAddFood, tsmUpdateFood });
            ctmFoodList.Name = "ctmFoodList";
            ctmFoodList.Size = new Size(187, 76);
            // 
            // tsmCalculateQuantity
            // 
            tsmCalculateQuantity.Name = "tsmCalculateQuantity";
            tsmCalculateQuantity.Size = new Size(186, 22);
            tsmCalculateQuantity.Text = "Tính số lượng đã bán";
            tsmCalculateQuantity.Click += menuQuantity_Click;
            // 
            // tsmSeparator
            // 
            tsmSeparator.Name = "tsmSeparator";
            tsmSeparator.Size = new Size(183, 6);
            // 
            // tsmAddFood
            // 
            tsmAddFood.Name = "tsmAddFood";
            tsmAddFood.Size = new Size(186, 22);
            tsmAddFood.Text = "Thêm món ăn mới";
            tsmAddFood.Click += menuAdd_Click;
            // 
            // tsmUpdateFood
            // 
            tsmUpdateFood.Name = "tsmUpdateFood";
            tsmUpdateFood.Size = new Size(186, 22);
            tsmUpdateFood.Text = "Cập nhật món ăn";
            tsmUpdateFood.Click += menuUpdate_Click;
            // 
            // lblCountCaption
            // 
            lblCountCaption.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblCountCaption.AutoSize = true;
            lblCountCaption.Location = new Point(12, 470);
            lblCountCaption.Name = "lblCountCaption";
            lblCountCaption.Size = new Size(57, 15);
            lblCountCaption.TabIndex = 5;
            lblCountCaption.Text = "Có tất cả:";
            lblCountCaption.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblQuantity
            // 
            lblQuantity.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(82, 470);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(13, 15);
            lblQuantity.TabIndex = 6;
            lblQuantity.Text = "0";
            lblQuantity.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCategoryCaption
            // 
            lblCategoryCaption.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblCategoryCaption.AutoSize = true;
            lblCategoryCaption.Location = new Point(135, 470);
            lblCategoryCaption.Name = "lblCategoryCaption";
            lblCategoryCaption.Size = new Size(120, 15);
            lblCategoryCaption.TabIndex = 7;
            lblCategoryCaption.Text = "món ăn thuộc nhóm:";
            lblCategoryCaption.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCateName
            // 
            lblCateName.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblCateName.Location = new Point(280, 470);
            lblCateName.Name = "lblCateName";
            lblCateName.Size = new Size(568, 23);
            lblCateName.TabIndex = 8;
            lblCateName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FoodForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(860, 500);
            Controls.Add(lblCategory);
            Controls.Add(cbbCategory);
            Controls.Add(lblSearch);
            Controls.Add(txtSearchByName);
            Controls.Add(dgvFoodList);
            Controls.Add(lblCountCaption);
            Controls.Add(lblQuantity);
            Controls.Add(lblCategoryCaption);
            Controls.Add(lblCateName);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(800, 460);
            Name = "FoodForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Danh sách món ăn";
            Load += FoodForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvFoodList).EndInit();
            ctmFoodList.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCategory;
        private ComboBox cbbCategory;
        private Label lblSearch;
        private TextBox txtSearchByName;
        private DataGridView dgvFoodList;
        private Label lblCountCaption;
        private Label lblQuantity;
        private Label lblCategoryCaption;
        private Label lblCateName;
        private ContextMenuStrip ctmFoodList;
        private ToolStripMenuItem tsmCalculateQuantity;
        private ToolStripSeparator tsmSeparator;
        private ToolStripMenuItem tsmAddFood;
        private ToolStripMenuItem tsmUpdateFood;
    }
}
