using DoAn.DAO;
using DoAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace DoAn
{
    public partial class FormQuanLy : Form
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
            }
        }

        BindingSource foodList = new BindingSource();
        BindingSource BanAnList = new BindingSource();
        BindingSource NhanVienList = new BindingSource();

        public FormQuanLy(Account acc)
        {
            InitializeComponent();
            this.LoginAccount = acc;
            load();
            AddBanAnBinding();
            AddFoodBinding();
            AddNhanVienBinding();
        }

        #region method

        private void FormQuanLy_Load(object sender, EventArgs e)
        {

        }

        //chạy các hàm
        void load()
        {
            dataGridViewMonAn.DataSource = foodList;
            dataGridViewBanAn.DataSource = BanAnList;
            dataGridViewNV.DataSource = NhanVienList;
            layDateTime();
            LoadDoanhThu(dateTimeVao.Value, dateTimeRa.Value);
            LoadBanAn();
            LoadMonAn();
            LoadNhanVien();
        }
        //lấy ngày, tháng, năm hiện tại
        void layDateTime()
        {
            DateTime today = dateTimeVao.Value;
            dateTimeVao.Value = new DateTime(today.Year, today.Month, 1);
            dateTimeRa.Value = dateTimeVao.Value.AddMonths(1).AddDays(-1);
        }

        //lấy dl và hiển thị doanh thu của các bàn thông qua thoigianVao và thoigianRa
        void LoadDoanhThu(DateTime a, DateTime b)
        {
            dataGridViewDT.DataSource = BillDAO.Instance.hienthiDoanhThu(a,b);
        }

        //lấy dl và hiển thị danh sách Món ăn
        void LoadMonAn()
        {
            foodList.DataSource = FoodDAO.Instance.GetFoodList();
        }

        // Thêm ràng buộc thông tin Món ăn
        void AddFoodBinding()
        {
            textBoxTenMA.DataBindings.Add(new Binding("Text", dataGridViewMonAn.DataSource, "tenFood", true, DataSourceUpdateMode.Never));
            textBoxIDMA.DataBindings.Add(new Binding("Text", dataGridViewMonAn.DataSource, "idfood", true, DataSourceUpdateMode.Never));
            numericUpDownGiaMA.DataBindings.Add(new Binding("Value", dataGridViewMonAn.DataSource, "giafood", true, DataSourceUpdateMode.Never));
        }

        // tìm món ăn theo tên
        List<Food> TimKiemMonAnTheoTen(string ten)
        {
            List<Food> listFood = FoodDAO.Instance.TimKiemMonAn(ten);
            return listFood;
        }

        //lấy dl và hiển thị danh sách Bàn Ăn
        void LoadBanAn()
        {
            BanAnList.DataSource = TableDAO.Instance.LoadTableList();
        }

        // Thêm ràng buộc thông tin Bàn ăn
        void AddBanAnBinding()
        {
            textBoxIDban.DataBindings.Add(new Binding("Text", dataGridViewBanAn.DataSource, "idban", true, DataSourceUpdateMode.Never));
            textBoxTenban.DataBindings.Add(new Binding("Text", dataGridViewBanAn.DataSource, "tenban", true, DataSourceUpdateMode.Never));
            textBoxTTban.DataBindings.Add(new Binding("Text", dataGridViewBanAn.DataSource, "ttban", true, DataSourceUpdateMode.Never));
        }

        // tìm bàn ăn theo tên bàn
        List<Table> TimKiemBanTheoTen(string ten)
        {
            List<Table> list = TableDAO.Instance.TimKiemBanAn(ten);
            return list;
        }

        // hiển thị danh sách nhân viên lên
        void LoadNhanVien()
        {
            NhanVienList.DataSource = AccountDAO.Instance.GetAccount();
        }

        // Thêm ràng buộc thông tin nhân viên
        void AddNhanVienBinding()
        {
            textBoxIDNV.DataBindings.Add(new Binding("Text", dataGridViewNV.DataSource, "id", true, DataSourceUpdateMode.Never));
            textBoxTenNV.DataBindings.Add(new Binding("Text", dataGridViewNV.DataSource, "tendK", true, DataSourceUpdateMode.Never));
            textBoxTenTK.DataBindings.Add(new Binding("Text", dataGridViewNV.DataSource, "username", true, DataSourceUpdateMode.Never));
            numericUpDownLoai.DataBindings.Add(new Binding("Value", dataGridViewNV.DataSource, "loai", true, DataSourceUpdateMode.Never));
        }

        // tìm nhân viên theo tên nhân viên
        List<Account> TimKiemNVTheoTen(string ten)
        {
            List<Account> list = AccountDAO.Instance.TimKiemNVTheoTen(ten);
            return list;
        }


        #endregion
        #region event

        // sự kiện load doanh thu lên
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            LoadDoanhThu(dateTimeVao.Value , dateTimeRa.Value);
        }

        // sự kiện xem Bảng món ăn
        private void btXem_Click(object sender, EventArgs e)
        {
            LoadMonAn();
        }

        // sự kiện xem Bảng bàn ăn
        private void btnXemBan_Click(object sender, EventArgs e)
        {
            LoadBanAn();
        }

        //sự kiện xem Bảng nhân viên
        private void btnXemNV_Click(object sender, EventArgs e)
        {
            LoadNhanVien();
        }

        // sự kiện thêm món ăn
        private void btThem_Click(object sender, EventArgs e)
        {
            string ten = textBoxTenMA.Text;
            int gia = (int)numericUpDownGiaMA.Value;
            bool kt = true;

            List<Food> foodList = FoodDAO.Instance.GetFoodList();
            foreach (Food food in foodList)
            {
                if(ten.Equals(food.TenFood.ToString()))
                {
                    kt = false;
                    break;
                }
            }

            if (kt)
            {
                if (FoodDAO.Instance.InsertFood(ten, gia))
                {
                    MessageBox.Show("Thêm thành công!");
                    LoadMonAn();

                }
                else MessageBox.Show("Có lỗi khi thêm!");
            }
            else MessageBox.Show("Đồ uống này đã tồn tại!");
        }

        // sự kiện sửa thông tin món ăn 
        private void btSua_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBoxIDMA.Text);
            string ten = textBoxTenMA.Text;
            int gia = (int)numericUpDownGiaMA.Value;

            if (FoodDAO.Instance.UpdateFood(id, ten, gia))
            {
                MessageBox.Show("Sửa thành công!");
                load();
               
            }
            else MessageBox.Show("Có lỗi khi sửa!");
        }

        // sự kiện xóa thông tin món ăn
        private void btXoa_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBoxIDMA.Text);
            if (FoodDAO.Instance.DeleteFood(id))
            {
                MessageBox.Show("Xóa thành công!");
                load();
            }
            else MessageBox.Show("Có lỗi khi xóa!");
        }

        // sự kiện sửa thông tin bàn ăn
        private void btnSuaBan_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBoxIDban.Text);
            string ten = textBoxTenban.Text;

            if (TableDAO.Instance.UpdateBanAn(id, ten))
            {
                MessageBox.Show("Sửa thành công!");
                load();
            }
            else MessageBox.Show("Có lỗi khi sửa!");
        }
        // sự kiện xóa thông tin bàn ăn
        private void btnXoaBan_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBoxIDban.Text);
           
            if (TableDAO.Instance.DeleteBanAn(id))
            {
                MessageBox.Show("Xóa thành công!");
                load();
            }
            else MessageBox.Show("Có lỗi khi xóa!");
        }
        // sự kiện thêm thông tin bàn ăn
        private void btnThemBan_Click(object sender, EventArgs e)
        {
            string ten = textBoxTenban.Text;
            bool kt = true;

            List<Table> List = TableDAO.Instance.LoadTableList();
            foreach (Table ban in List)
            {
                if (ten.Equals(ban.Tenban.ToString()))
                {
                    kt = false;
                    break;
                }
            }

            if (kt)
            {
                if (TableDAO.Instance.InsertBanAn(ten))
                {
                    MessageBox.Show("Thêm bàn thành công!");
                    LoadBanAn();
                }
                else MessageBox.Show("Có lỗi khi thêm bàn!");
            }
            else MessageBox.Show("Bàn này đã tồn tại!");
        }

        // sự kiện thêm thông tin nhân viên
        private void btnThemNV_Click(object sender, EventArgs e)
        {
            string username = textBoxTenTK.Text;
            string tenNV = textBoxTenNV.Text;
            int loai = Convert.ToInt32(numericUpDownLoai.Text);
            bool kt = true;

            List<Account> AccList = AccountDAO.Instance.GetAccount();
            foreach (Account acc in AccList)
            {
                if (username == (acc.Username.ToString()))
                {
                    kt = false;
                    break;
                }
            }

            if (kt)
            {
                if (AccountDAO.Instance.InsertNV(tenNV, username, loai))
                {
                    MessageBox.Show("Thêm thành công!");
                    LoadNhanVien();

                }
                else MessageBox.Show("Có lỗi khi thêm!");
            }
            else MessageBox.Show("Đã có sự tồn tại!");
        }
        
        // sự kiện xóa thông tin nhân viên
        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            string Accusername = LoginAccount.Username; // lay usename hiện hành
            string username = textBoxTenTK.Text;
            // nếu username hiện hành thì không được xóa
            if (Accusername.Equals(username)) MessageBox.Show("Tài khoản đang hoạt động không thể xóa!");
            else
                if (AccountDAO.Instance.DeleteNV(username))
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadNhanVien();
                }
                else MessageBox.Show("Có lỗi khi xóa ");
        }
        // sự kiện sửa thông tin nhân viên
        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBoxIDNV.Text);
            string username = textBoxTenTK.Text;
            string tenNV = textBoxTenNV.Text;
            int loai = Convert.ToInt32(numericUpDownLoai.Text);

            if (AccountDAO.Instance.UpdateNV(tenNV, username, loai, id))
            {
                MessageBox.Show("Sửa thành công!");
                LoadNhanVien();
            }
            else MessageBox.Show("Có lỗi khi sửa!");
        }

        //sự kiện tìm kiếm tên món ăn
        private void btTimKiem_Click(object sender, EventArgs e)
        {
            foodList.DataSource = TimKiemMonAnTheoTen(textBoxTimKiemTenMA.Text);
        }

        //sự kiện tìm kiếm tên bàn
        private void btnTKBan_Click(object sender, EventArgs e)
        {
            BanAnList.DataSource = TimKiemBanTheoTen(textBoxTKBan.Text);
        }

        //sự kiện tìm kiếm tên nhân viên
        private void btnTKNV_Click(object sender, EventArgs e)
        {
            NhanVienList.DataSource = TimKiemNVTheoTen(textBoxTKNV.Text);
        }

        private void btnDoiPass_Click(object sender, EventArgs e)
        {
            FormThongTinAccount fn = new FormThongTinAccount(LoginAccount);
            fn.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tpMonAn_Click(object sender, EventArgs e)
        {

        }

        private void textBoxTenTK_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelTenTK_Click(object sender, EventArgs e)
        {

        }

        private void textBoxTKBan_TextChanged(object sender, EventArgs e)
        {

        }


        #endregion

        private void dataGridViewNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
