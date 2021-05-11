using DoAn.DAO;
using DoAn.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn
{
    public partial class FormQuanLyQuanCafe : Form
    {
        private Account loginAccount;

        public Account LoginAccount
        {
            get
            {
                return loginAccount;
            }

            set
            {
                loginAccount = value;
                DoiThongTinTaiKhoan(loginAccount.Loai); 
            }
        }

        public FormQuanLyQuanCafe(Account acc)
        {
            InitializeComponent();

            this.LoginAccount = acc; //gan dl Account cho ham LoginAccount  

            loadTable();
            loadFoodList();
            hienThiComboboxBanAn();
        }

        private void FormQuanLyQuan_Load(object sender, EventArgs e)
        {

        }

        #region Method
        // load dữ liệu món ăn lên đển thêm/bớt món ăn vào bàn ăn.
        void loadFoodList()
        {
            List<Food> listFood = FoodDAO.Instance.GetFoodList();
            comboBoxFoodName.DataSource = listFood;
            comboBoxFoodName.DisplayMember = "tenFood";
        }
        // load dữ liệu bàn ăn lên để hiển thị danh sách bàn ăn
        void loadTable()
        {
            flpBanAn.Controls.Clear();
            List<Table> tableList = TableDAO.Instance.LoadTableList();
            foreach(Table table in tableList)
            {
                Button btn = new Button()
                { Width = TableDAO.tableWidth, Height = TableDAO.tableHeight};
                btn.Text = table.Tenban + Environment.NewLine + table.Ttban;

                btn.Click += btn_Click1234;
                btn.Tag = table;

                switch(table.Ttban)
                {
                    case "Trong":
                        btn.BackColor = Color.Aqua;
                        break;
                    default:
                        btn.BackColor = Color.LawnGreen;
                        break;

                }
                flpBanAn.Controls.Add(btn);
            }
        }
        // hiển thị thông tin hóa đơn theo bàn ăn
        void hienThiHoaDon(int idban)
        {
            listView1.Items.Clear();
            List<DTO.Menu> listBill = MenuDAO.Instance.GetListMenuByTable(idban);
            int TongTien = 0;
            foreach(DTO.Menu item in listBill)
            {
                ListViewItem lvi = new ListViewItem(item.Monan.ToString());
                lvi.SubItems.Add(item.Soluong.ToString());
                lvi.SubItems.Add(item.Gia.ToString());
                lvi.SubItems.Add(item.Thanhtien.ToString());
                TongTien += item.Thanhtien;
                listView1.Items.Add(lvi);
            }
            CultureInfo cul = new CultureInfo("vi-VN");
            textBoxTongTien.Text = TongTien.ToString("c",cul);          
        }

        void hienThiComboboxBanAn()
        {
            comboBoxChuyenBan.DataSource = TableDAO.Instance.LoadTableList();
            comboBoxChuyenBan.DisplayMember = "tenban";
        }

        void DoiThongTinTaiKhoan(int loai)
        {
            //neu la TK admin thi moi co chuc nang quan ly quan
            quanLyToolStripMenuItem.Enabled = loai == 1;
        }

        #endregion

        #region Events
        //tạo button bàn ăn chứa hóa đơn.
        void btn_Click1234(object sender, EventArgs e)
        {
            int idBanAn= ((sender as Button).Tag as Table).Idban;
            listView1.Tag = (sender as Button).Tag;
            hienThiHoaDon(idBanAn);
            labelTenBanAn.Text = ((sender as Button).Tag as Table).Tenban;
        }
        // button đăng xuất
        private void dangXuatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // chuyển đến Form xem thông tin cá nhân
        private void thongTinCaNhanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormThongTinAccount fn = new FormThongTinAccount(LoginAccount);
            this.Hide();
            fn.ShowDialog();
            this.Show();
        }
        // chuyển đến Form quản lý
        private void quanLyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormQuanLy fn = new FormQuanLy(LoginAccount);
            this.Hide();
            fn.ShowDialog();
            this.Show();
        }
        // chức năng thêm món vào bàn ăn được chọn
        private void btnThemMA_Click(object sender, EventArgs e)
        {
            Table table = listView1.Tag as Table;
            int idHoaDon = BillDAO.Instance.GetUncheckBillIDByTableID(table.Idban);
            int idFood = (comboBoxFoodName.SelectedItem as Food).Idfood;
            int soluong = (int)nmSoluongMA.Value;
            // kiem tra idHoaDon co ton tai khong?
            if (idHoaDon == -1)
            {
                BillDAO.Instance.InsertBill(table.Idban);
                ChiTietHoaDonDAO.Instance.InsertChiTietHoaDon(BillDAO.Instance.GetMaxID(), idFood, soluong);
            }
            else
            {
               ChiTietHoaDonDAO.Instance.InsertChiTietHoaDon(idHoaDon, idFood, soluong);
            }
            
            hienThiHoaDon(table.Idban);
            loadTable();
        }
        // chuc nang thanh toan
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            Table table = listView1.Tag as Table;
            int idHoaDon = BillDAO.Instance.GetUncheckBillIDByTableID(table.Idban);
            int tongtien = (int)float.Parse(textBoxTongTien.Text.Split(',')[0]);
            // kiem tra idHoaDon co ton tai khong?
            if (idHoaDon != -1)
            {
                if(MessageBox.Show("Bạn có chắc chắn muốn thanh toán hóa đơn cho bàn "+table.Tenban, "Thông báo!", MessageBoxButtons.OKCancel)== System.Windows.Forms.DialogResult.OK)
                {
                    BillDAO.Instance.ThanhToanHoaDon(idHoaDon, tongtien);
                    hienThiHoaDon(table.Idban);
                    loadTable();
                }
            }

        }

        private void btnChuyenBan_Click(object sender, EventArgs e)
        {
            int id1 = (listView1.Tag as Table).Idban;
            int id2 = (comboBoxChuyenBan.SelectedItem as Table).Idban;
            if(id1 != id2)
            {
                if (((listView1.Tag as Table).Ttban.Equals("Co nguoi")) && ((comboBoxChuyenBan.SelectedItem as Table).Ttban.Equals("Co nguoi"))) MessageBox.Show("Bàn đã có người!", "Thông báo", MessageBoxButtons.OK);
                if (((listView1.Tag as Table).Ttban.Equals("Co nguoi")) && ((comboBoxChuyenBan.SelectedItem as Table).Ttban.Equals("Trong")))
                {
                    if (MessageBox.Show("Bạn có chắc chắn muốn chuyển " + (listView1.Tag as Table).Tenban + " qua bàn " + (comboBoxChuyenBan.SelectedItem as Table).Tenban + " không? ", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                            TableDAO.Instance.ChuyenBan(id1, id2);
                            loadTable();
                            hienThiComboboxBanAn();
                            hienThiHoaDon(id1);
                            labelTenBanAn.Text = (listView1.Tag as Table).Tenban;
                    }
                }
             }
                             
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void labelTongTien_Click(object sender, EventArgs e)
        {

        }

        private void labelfoodname_Click(object sender, EventArgs e)
        {

        }

        private void labelSL_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxChuyenBan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion


    }
}
