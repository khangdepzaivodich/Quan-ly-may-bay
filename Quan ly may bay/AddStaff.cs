using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace Quan_ly_may_bay
{
    public partial class AddStaff : KryptonForm
    {
        int manv = -1;
        public AddStaff()
        {
            InitializeComponent();
        }

        public AddStaff(int _manv)
        {
            InitializeComponent();
            manv= _manv;
        }


        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddStaff_Load(object sender, EventArgs e)
        {
            if (manv == -1)
            {

            }
            else
            {
                databaseDataContext db = new databaseDataContext();
                NhanVien nv = db.NhanViens.FirstOrDefault(p => p.MaNV == manv);
                Account ac = db.Accounts.FirstOrDefault(p => p.ID == nv.ID);
                txtUsername.Text = ac.Username;
                txtEmail.Text = ac.Email;
                txtHoten.Text = nv.HoTenNV;
                txtDiachi.Text = nv.DiaChi;
                dpkNgaySinh.Value = nv.NgaySinh.Value;
                if (nv.GioiTinh == "Nam")
                {
                    rdbNam.Checked = true;
                    rdbNu.Checked = false;
                }
                else
                {
                    rdbNam.Checked = false;
                    rdbNu.Checked = true;
                }
                txtSdt.Text = nv.SDT;

                txtUsername.Enabled = false;
                txtEmail.Enabled = false;
                txtHoten.Enabled = false;
                txtDiachi.Enabled = false;
                dpkNgaySinh.Enabled = false;
                rdbNam.Enabled = rdbNu.Enabled = false;
                txtSdt.Enabled = false;

                dpkNgayKy.Value = nv.NgayVaoLam.Value;
                cbbMaCV.Text = nv.MaCV;
                txtLuong.Text = nv.Luong.ToString();
            }
        }

    }
}
