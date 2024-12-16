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
using System.Windows.Media.Media3D.Converters;
using ComponentFactory.Krypton.Toolkit;
using Quan_ly_may_bay.Base;

namespace Quan_ly_may_bay
{
    public partial class InformationAccount : KryptonForm
    {
        private databaseDataContext db = new databaseDataContext(Common.connectionString);
        private Account account;
        private KhachHang khachang;
        private NhanVien nhanvien;
        public InformationAccount(int id)
        {
            InitializeComponent();
            account = db.Accounts.FirstOrDefault(x => x.ID == id);
            if(account.LevelID == 2)
            {
                khachang = db.KhachHangs.FirstOrDefault(x => x.MaKH == id);
                lblUsername.Text = "Username: " + account.Username;
                lblGmail.Text = "Gmail: " + account.Email;
                txtHoTen.Text = khachang.HoTenKH;
                txtNgaySinh.Value = khachang.NgaySinh.Value;
                if (khachang.GioiTinh == "Nam") rdbNam.Checked = true;
                else rdbNu.Checked = true;
                txtDiaChi.Text = khachang.DiaChi;
                txtSDT.Text = khachang.SDT;
                txtCCCD.Text = khachang.CCCD;
            }
            else
            {
                nhanvien = db.NhanViens.FirstOrDefault(x => x.ID == id);
                lblUsername.Text = "Username: " + account.Username;
                lblGmail.Text = "Gmail: " + account.Email;
                txtHoTen.Text = nhanvien.HoTenNV;
                txtNgaySinh.Value = nhanvien.NgaySinh.Value;
                if (nhanvien.GioiTinh == "Nam") rdbNam.Checked = true;
                else rdbNu.Checked = true;
                txtDiaChi.Text = nhanvien.DiaChi;
                txtSDT.Text = nhanvien.SDT;
                txtCCCD.Text = nhanvien.Luong.ToString();
                lblCCCD.Text = "Luong";
            }
            btnSubmit.Text = "Edit";
                txtCCCD.Enabled = false;
                txtDiaChi.Enabled = false;
                txtHoTen.Enabled = false;
                txtNgaySinh.Enabled = false;
                txtSDT.Enabled = false;
            rdbNam.Enabled = false;
            rdbNu.Enabled = false;
        }
        private bool check = true;
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (check) btnSubmit.Text = "Submit";
            else btnSubmit.Text = "Edit";
            check = !check;

            if(btnSubmit.Text == "Edit")
            {
                txtCCCD.Enabled = false;
                txtDiaChi.Enabled = false;
                txtHoTen.Enabled = false;
                txtNgaySinh.Enabled = false;
                txtSDT.Enabled = false;
                rdbNam.Enabled = false;
                rdbNu.Enabled = false;

                if (account.LevelID == 2)
                {
                    khachang.HoTenKH = txtHoTen.Text;
                    khachang.NgaySinh = txtNgaySinh.Value;
                    khachang.DiaChi = txtDiaChi.Text;
                    khachang.CCCD = txtCCCD.Text;
                    khachang.SDT = txtSDT.Text;
                    if (rdbNam.Checked) khachang.GioiTinh = "Nam";
                    else khachang.GioiTinh = "Nữ";

                }
                else
                {
                    nhanvien.HoTenNV = txtHoTen.Text;
                    nhanvien.NgaySinh = txtNgaySinh.Value;
                    nhanvien.DiaChi = txtDiaChi.Text;
                    nhanvien.SDT = txtSDT.Text;
                    if (rdbNam.Checked) nhanvien.GioiTinh = "Nam";
                    else nhanvien.GioiTinh = "Nữ";
                }
                db.SubmitChanges();
            }
            else
            {
                if (account.LevelID == 2) txtCCCD.Enabled = true;
                txtDiaChi.Enabled = true;
                txtHoTen.Enabled = true;
                txtNgaySinh.Enabled = true;
                txtSDT.Enabled = true;
                rdbNam.Enabled = true;
                rdbNu.Enabled = true;  
            }
        }
    }
}
