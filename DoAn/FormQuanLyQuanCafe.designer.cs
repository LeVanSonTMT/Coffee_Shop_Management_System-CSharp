namespace DoAn
{
    partial class FormQuanLyQuanCafe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quanLyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thongTinCaNhanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dangXuatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelTenBanAn = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelTongTien = new System.Windows.Forms.Label();
            this.textBoxTongTien = new System.Windows.Forms.TextBox();
            this.comboBoxChuyenBan = new System.Windows.Forms.ComboBox();
            this.btnChuyenBan = new System.Windows.Forms.Button();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelSL = new System.Windows.Forms.Label();
            this.labelfoodname = new System.Windows.Forms.Label();
            this.nmSoluongMA = new System.Windows.Forms.NumericUpDown();
            this.btnThemMA = new System.Windows.Forms.Button();
            this.comboBoxFoodName = new System.Windows.Forms.ComboBox();
            this.flpBanAn = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmSoluongMA)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(808, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.adminToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quanLyToolStripMenuItem,
            this.thongTinCaNhanToolStripMenuItem,
            this.dangXuatToolStripMenuItem});
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.adminToolStripMenuItem.Text = "Admin";
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // quanLyToolStripMenuItem
            // 
            this.quanLyToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.quanLyToolStripMenuItem.Name = "quanLyToolStripMenuItem";
            this.quanLyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.quanLyToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.quanLyToolStripMenuItem.Text = "Quản lý";
            this.quanLyToolStripMenuItem.Click += new System.EventHandler(this.quanLyToolStripMenuItem_Click);
            // 
            // thongTinCaNhanToolStripMenuItem
            // 
            this.thongTinCaNhanToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.thongTinCaNhanToolStripMenuItem.Name = "thongTinCaNhanToolStripMenuItem";
            this.thongTinCaNhanToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.thongTinCaNhanToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.thongTinCaNhanToolStripMenuItem.Text = "Thông tin cá nhân";
            this.thongTinCaNhanToolStripMenuItem.Click += new System.EventHandler(this.thongTinCaNhanToolStripMenuItem_Click);
            // 
            // dangXuatToolStripMenuItem
            // 
            this.dangXuatToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.dangXuatToolStripMenuItem.Name = "dangXuatToolStripMenuItem";
            this.dangXuatToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.dangXuatToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.dangXuatToolStripMenuItem.Text = "Đăng xuất";
            this.dangXuatToolStripMenuItem.Click += new System.EventHandler(this.dangXuatToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelTenBanAn);
            this.panel2.Controls.Add(this.listView1);
            this.panel2.Location = new System.Drawing.Point(417, 113);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(379, 272);
            this.panel2.TabIndex = 2;
            // 
            // labelTenBanAn
            // 
            this.labelTenBanAn.AutoSize = true;
            this.labelTenBanAn.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTenBanAn.Location = new System.Drawing.Point(5, 5);
            this.labelTenBanAn.Name = "labelTenBanAn";
            this.labelTenBanAn.Size = new System.Drawing.Size(0, 22);
            this.labelTenBanAn.TabIndex = 1;
            this.labelTenBanAn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(3, 30);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(373, 239);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên";
            this.columnHeader1.Width = 107;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Số Lượng";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 79;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Giá Tiền";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader3.Width = 82;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Thành Tiền";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader4.Width = 96;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.labelTongTien);
            this.panel3.Controls.Add(this.textBoxTongTien);
            this.panel3.Controls.Add(this.comboBoxChuyenBan);
            this.panel3.Controls.Add(this.btnChuyenBan);
            this.panel3.Controls.Add(this.btnThanhToan);
            this.panel3.Location = new System.Drawing.Point(417, 391);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(379, 80);
            this.panel3.TabIndex = 3;
            // 
            // labelTongTien
            // 
            this.labelTongTien.AutoSize = true;
            this.labelTongTien.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTongTien.Location = new System.Drawing.Point(132, 9);
            this.labelTongTien.Name = "labelTongTien";
            this.labelTongTien.Size = new System.Drawing.Size(117, 25);
            this.labelTongTien.TabIndex = 7;
            this.labelTongTien.Text = "Tổng Tiền:";
            this.labelTongTien.Click += new System.EventHandler(this.labelTongTien_Click);
            // 
            // textBoxTongTien
            // 
            this.textBoxTongTien.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTongTien.ForeColor = System.Drawing.Color.Red;
            this.textBoxTongTien.Location = new System.Drawing.Point(137, 40);
            this.textBoxTongTien.Name = "textBoxTongTien";
            this.textBoxTongTien.ReadOnly = true;
            this.textBoxTongTien.Size = new System.Drawing.Size(136, 29);
            this.textBoxTongTien.TabIndex = 6;
            this.textBoxTongTien.Text = "0";
            this.textBoxTongTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // comboBoxChuyenBan
            // 
            this.comboBoxChuyenBan.FormattingEnabled = true;
            this.comboBoxChuyenBan.Location = new System.Drawing.Point(3, 42);
            this.comboBoxChuyenBan.Name = "comboBoxChuyenBan";
            this.comboBoxChuyenBan.Size = new System.Drawing.Size(118, 27);
            this.comboBoxChuyenBan.TabIndex = 5;
            this.comboBoxChuyenBan.SelectedIndexChanged += new System.EventHandler(this.comboBoxChuyenBan_SelectedIndexChanged);
            // 
            // btnChuyenBan
            // 
            this.btnChuyenBan.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnChuyenBan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChuyenBan.Location = new System.Drawing.Point(3, 4);
            this.btnChuyenBan.Name = "btnChuyenBan";
            this.btnChuyenBan.Size = new System.Drawing.Size(118, 35);
            this.btnChuyenBan.TabIndex = 4;
            this.btnChuyenBan.Text = "Chuyển Bàn";
            this.btnChuyenBan.UseVisualStyleBackColor = false;
            this.btnChuyenBan.Click += new System.EventHandler(this.btnChuyenBan_Click);
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnThanhToan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThanhToan.Location = new System.Drawing.Point(296, 8);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(77, 62);
            this.btnThanhToan.TabIndex = 3;
            this.btnThanhToan.Text = "Thanh Toán";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.labelSL);
            this.panel4.Controls.Add(this.labelfoodname);
            this.panel4.Controls.Add(this.nmSoluongMA);
            this.panel4.Controls.Add(this.btnThemMA);
            this.panel4.Controls.Add(this.comboBoxFoodName);
            this.panel4.Location = new System.Drawing.Point(417, 27);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(379, 80);
            this.panel4.TabIndex = 4;
            // 
            // labelSL
            // 
            this.labelSL.AutoSize = true;
            this.labelSL.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSL.Location = new System.Drawing.Point(3, 48);
            this.labelSL.Name = "labelSL";
            this.labelSL.Size = new System.Drawing.Size(95, 22);
            this.labelSL.TabIndex = 5;
            this.labelSL.Text = "Số Lượng:";
            this.labelSL.Click += new System.EventHandler(this.labelSL_Click);
            // 
            // labelfoodname
            // 
            this.labelfoodname.AutoSize = true;
            this.labelfoodname.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelfoodname.Location = new System.Drawing.Point(3, 13);
            this.labelfoodname.Name = "labelfoodname";
            this.labelfoodname.Size = new System.Drawing.Size(47, 22);
            this.labelfoodname.TabIndex = 4;
            this.labelfoodname.Text = "Tên:";
            this.labelfoodname.Click += new System.EventHandler(this.labelfoodname_Click);
            // 
            // nmSoluongMA
            // 
            this.nmSoluongMA.Location = new System.Drawing.Point(99, 46);
            this.nmSoluongMA.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nmSoluongMA.Name = "nmSoluongMA";
            this.nmSoluongMA.Size = new System.Drawing.Size(57, 26);
            this.nmSoluongMA.TabIndex = 3;
            this.nmSoluongMA.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnThemMA
            // 
            this.btnThemMA.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnThemMA.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemMA.Location = new System.Drawing.Point(296, 10);
            this.btnThemMA.Name = "btnThemMA";
            this.btnThemMA.Size = new System.Drawing.Size(73, 61);
            this.btnThemMA.TabIndex = 2;
            this.btnThemMA.Text = "Thêm";
            this.btnThemMA.UseVisualStyleBackColor = false;
            this.btnThemMA.Click += new System.EventHandler(this.btnThemMA_Click);
            // 
            // comboBoxFoodName
            // 
            this.comboBoxFoodName.FormattingEnabled = true;
            this.comboBoxFoodName.Location = new System.Drawing.Point(56, 11);
            this.comboBoxFoodName.Name = "comboBoxFoodName";
            this.comboBoxFoodName.Size = new System.Drawing.Size(193, 27);
            this.comboBoxFoodName.TabIndex = 0;
            // 
            // flpBanAn
            // 
            this.flpBanAn.AutoScroll = true;
            this.flpBanAn.Location = new System.Drawing.Point(12, 27);
            this.flpBanAn.Name = "flpBanAn";
            this.flpBanAn.Size = new System.Drawing.Size(399, 444);
            this.flpBanAn.TabIndex = 5;
            // 
            // FormQuanLyQuanCafe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 472);
            this.Controls.Add(this.flpBanAn);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormQuanLyQuanCafe";
            this.Text = "Phần Mềm Quản Lý Quán CaFe";
            this.Load += new System.EventHandler(this.FormQuanLyQuan_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmSoluongMA)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thongTinCaNhanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dangXuatToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnThemMA;
        private System.Windows.Forms.ComboBox comboBoxFoodName;
        private System.Windows.Forms.NumericUpDown nmSoluongMA;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button btnChuyenBan;
        private System.Windows.Forms.ComboBox comboBoxChuyenBan;
        private System.Windows.Forms.ToolStripMenuItem quanLyToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel flpBanAn;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TextBox textBoxTongTien;
        private System.Windows.Forms.Label labelTongTien;
        private System.Windows.Forms.Label labelSL;
        private System.Windows.Forms.Label labelfoodname;
        private System.Windows.Forms.Label labelTenBanAn;
    }
}