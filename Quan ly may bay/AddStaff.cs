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
using Quan_ly_may_bay.Base;

namespace Quan_ly_may_bay
{
    public partial class AddStaff : KryptonForm
    {
        public event EventHandler DataChanged;
        databaseDataContext db = new databaseDataContext(Common.connectionString);
        int manv = -1;
        public AddStaff()
        {
            InitializeComponent();
            txtLuong.Text = string.Format("{0:N0}", 10000000);
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
            cbbMaCV.DataSource = db.ChucVus.OrderBy(p => p.MaCV);
            cbbMaCV.DisplayMember = "TenCv";
            cbbMaCV.ValueMember = "MaCV";
            if (manv != -1)
            {
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
                dpkNgayKy.Value = nv.NgayVaoLam.Value;

                txtUsername.Enabled = false;
                txtEmail.Enabled = false;
                txtHoten.Enabled = false;
                txtDiachi.Enabled = false;
                dpkNgaySinh.Enabled = false;
                rdbNam.Enabled = rdbNu.Enabled = false;
                txtSdt.Enabled = false;
                dpkNgayKy.Enabled = false;

                cbbMaCV.SelectedValue = nv.MaCV;
                txtLuong.Text = nv.Luong.ToString();
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            errUsername.Clear();
            errSDT.Clear();
            errEmail.Clear();
            if (manv == -1)
            {
                bool check = true;
                
                if (txtUsername.Text.Length == 0)
                {
                    errUsername.SetError(txtUsername, "Vui lòng nhập Username");
                    check = false;
                }
                if (txtSdt.Text.Length != 10)
                {
                    errSDT.SetError(txtSdt, "Nhập đúng số điện thoại");
                    check = false;
                }
                if (txtEmail.Text.Trim().LastIndexOf("@gmail.com") == -1)
                {
                    errEmail.SetError(txtEmail, "Nhập đúng định dạng email");

                    check = false;
                }
                if (!check)
                {
                    return;
                }
                

                if (db.Accounts.FirstOrDefault(p => p.Username == txtUsername.Text) != null)
                {
                    errUsername.SetError(txtUsername, "Username đã tồn tại!");
                    txtUsername.Focus();
                    return;
                }
                else if (db.Accounts.FirstOrDefault(p => p.Email == txtEmail.Text) != null)
                {
                    errEmail.SetError(txtEmail, "Email đã được dùng!");
                    txtEmail.Focus();
                    return;
                }
                Account newAccount = new Account();
                newAccount.Username = txtUsername.Text;
                newAccount.Email = txtEmail.Text;
                newAccount.LevelID = 1;
                newAccount.DateCreated = DateTime.Now;
                newAccount.OTPDateSend = DateTime.Now;
                newAccount.Active = 0;
                this.Hide();


                Random random = new Random();
                int rd = random.Next(100000, 999999);

                newAccount.OTP = newAccount.RandomKey = rd;
                newAccount.Password = Common.HashPassword("123456" + rd.ToString());
                db.Accounts.InsertOnSubmit(newAccount);
                db.SubmitChanges();

                NhanVien newNhanVien = new NhanVien();
                newNhanVien.HoTenNV = txtHoten.Text;
                newNhanVien.NgaySinh = dpkNgaySinh.Value;
                newNhanVien.DiaChi = txtDiachi.Text;
                if (rdbNam.Checked) newNhanVien.GioiTinh = "Nam";
                else newNhanVien.GioiTinh = "Nữ";
                newNhanVien.NgayVaoLam = dpkNgayKy.Value;
                newNhanVien.MaCV = cbbMaCV.SelectedValue.ToString();
                newNhanVien.SDT = txtSdt.Text;
                newNhanVien.ID = newAccount.ID;
                newNhanVien.Luong = int.Parse(txtLuong.Tag.ToString());
                db.NhanViens.InsertOnSubmit(newNhanVien);
                db.SubmitChanges();                
            }
            else
            {
                NhanVien nv = db.NhanViens.FirstOrDefault(p => p.MaNV == manv);
                nv.MaCV = cbbMaCV.SelectedValue.ToString() ;
                nv.Luong = int.Parse(txtLuong.Tag.ToString());
                db.SubmitChanges();
            }

            DataChanged?.Invoke(this, EventArgs.Empty);

            this.Close();
        }

        private void txtLuong_TextChanged(object sender, EventArgs e)
        {
            // Temporarily remove the event handler to prevent recursive calls
            txtLuong.TextChanged -= txtLuong_TextChanged;

            // Check if the input is numeric
            if (decimal.TryParse(txtLuong.Text, out decimal salary))
            {
                // Format the number with commas as thousands separators
                txtLuong.Tag = salary;
                txtLuong.Text = string.Format("{0:N0}", salary);
            }

            // Reattach the event handler
            txtLuong.TextChanged += txtLuong_TextChanged;

            // Move the cursor to the end of the TextBox
            txtLuong.Select(txtLuong.Text.Length, 0);
        }
    }
}
