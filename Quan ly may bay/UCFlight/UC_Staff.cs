using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_ly_may_bay.UCFlight
{ 
    public partial class UC_Staff : UserControl
    {
        public event EventHandler DataChanged;
        public UC_Staff()
        {
            InitializeComponent();
        }
        public KryptonButton Delete
        {
            get => btnDelete;
            set => btnDelete = value;
        }
        public KryptonButton Edit
        {
            get => btnEdit;
            set => btnEdit = value;
        }
        public int MaNV
        {
            get => int.Parse(lblMaNV.Text);
            set => lblMaNV.Text = value.ToString();
        }

        public string TenNV
        {
            get => lblTenNV.Text;
            set => lblTenNV.Text = value;
        }

        public string MaCV
        {
            get => lblMaCV.Text;
            set => lblMaCV.Text = value;
        }

        public string Luong
        {
            get => lblLuong.Text;
            set => lblLuong.Text = value;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            AddStaff add = new AddStaff(MaNV); // Khởi tạo form AddStaff với chế độ sửa
            add.ShowDialog();
            DataChanged?.Invoke(this, EventArgs.Empty);

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            databaseDataContext db = new databaseDataContext();
            NhanVien nv = db.NhanViens.Where(p => p.MaNV == MaNV).FirstOrDefault();
            Account ac = db.Accounts.Where(p => p.ID == nv.ID).FirstOrDefault();
            db.NhanViens.DeleteOnSubmit(nv);
            db.Accounts.DeleteOnSubmit(ac);
            db.SubmitChanges();

            DataChanged?.Invoke(this, EventArgs.Empty); // Gọi sự kiện khi xóa dữ liệu
        }
    }
}
