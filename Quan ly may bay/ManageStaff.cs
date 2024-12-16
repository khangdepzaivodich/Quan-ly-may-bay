using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Quan_ly_may_bay.UCFlight;
using Quan_ly_may_bay.Base;

namespace Quan_ly_may_bay
{
    public partial class ManageStaff : KryptonForm
    {
        databaseDataContext db;
        List<NhanVien> nv;
        List<NhanVien> tkiem;
        int ID;
        bool check = true;
        int soluong;
        public ManageStaff(int _ID)
        {
            InitializeComponent();
            ID = _ID;
            db = new databaseDataContext(Common.connectionString);
            cbbMaCV.DataSource = db.ChucVus.OrderBy(p => p.MaCV);
            cbbMaCV.DisplayMember = "MaCV";
            cbbMaCV.ValueMember = "MaCV";
            lblSubstract.Hide();
            loadDuLieu();
        }

        public void loadDuLieu()
        {
            flpContain.Controls.Clear();
            if (check)
            {
                btnIn.Hide();
                db = new databaseDataContext(Common.connectionString);
                nv = db.NhanViens.OrderByDescending(p => p.MaNV).ToList();    
            }
            else
            {
                btnIn.Show();
                nv = tkiem;
            }
            soluong = nv.Count;
            if (soluong <= 5) lblSubstract.Hide();
            for (int i = 5 * int.Parse(lblStt.Text); i < 5 * int.Parse(lblStt.Text) + 5; i++)
            {

                if (i >= soluong)
                {
                    lblAdd.Hide();
                    break;
                }
                UC_Staff uc = new UC_Staff();

                uc.MaNV = nv[i].MaNV;
                uc.TenNV = nv[i].HoTenNV.Length < 15 ? nv[i].HoTenNV : nv[i].HoTenNV.Substring(0,14) + "...";
                uc.MaCV = nv[i].MaCV;
                uc.Luong = nv[i].Luong.ToString() + " VND";
                if (nv[i].ID == ID)
                {
                    uc.Delete.Visible = false;
                    uc.Edit.Visible = false;
                }
                // Đăng ký sự kiện DataChanged
                uc.DataChanged += (s, args) =>
                {
                    loadDuLieu(); // Gọi lại phương thức tải dữ liệu
                };

                flpContain.Controls.Add(uc);
            }
        }

        private void lblSubstract_Click(object sender, EventArgs e)
        {
                lblAdd.Show();
                flpContain.Controls.Clear();
                lblStt.Text = (int.Parse(lblStt.Text) - 1).ToString();
                if (int.Parse(lblStt.Text) == 0) lblSubstract.Hide();
                for (int i = 5 * int.Parse(lblStt.Text); i < 5 * int.Parse(lblStt.Text) + 5; i++)
                {
                    UC_Staff uc = new UC_Staff();
                    uc.MaNV = nv[i].MaNV;
                    uc.TenNV = nv[i].HoTenNV;
                    uc.MaCV = nv[i].MaCV;
                    uc.Luong = nv[i].Luong.ToString() + " VND";
                if (nv[i].ID == ID)
                {
                    uc.Delete.Visible = false;
                    uc.Edit.Visible = false;
                }
                flpContain.Controls.Add(uc);
                }
            
        }

        private void lblAdd_Click(object sender, EventArgs e)
        {
                lblSubstract.Show();
                flpContain.Controls.Clear();
                lblStt.Text = (int.Parse(lblStt.Text) + 1).ToString();
                if (int.Parse(lblStt.Text)*5+5 >= soluong) lblAdd.Hide();
                for (int i = 5 * int.Parse(lblStt.Text); i < 5 * int.Parse(lblStt.Text) + 5; i++)
                {
                    if (i >= soluong)
                    {
                        lblAdd.Hide();
                        break;
                    }
                    UC_Staff uc = new UC_Staff();
                    uc.MaNV = nv[i].MaNV;
                    uc.TenNV = nv[i].HoTenNV;
                    uc.MaCV = nv[i].MaCV;
                    uc.Luong = nv[i].Luong.ToString() + " VND";
                if (nv[i].ID == ID)
                {
                    uc.Delete.Visible = false;
                    uc.Edit.Visible = false;
                }
                flpContain.Controls.Add(uc);
                }
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            check = true;
            AddStaff add = new AddStaff();
            add.DataChanged += (s, args) =>
            {
                loadDuLieu(); // Gọi lại hàm tải dữ liệu khi có thay đổi
            };
            add.Show();
        }

        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {
            if (txtMaNV.Text != "")
            {
                txtTenNV.Hide();
                txtLuong.Hide();
                cbbMaCV.Hide();
            }
            else
            {
                check = true;
                txtTenNV.Show();
                txtLuong.Show();
                cbbMaCV.Show();
                loadDuLieu();
            }
        }

        private void btnFInd_Click(object sender, EventArgs e)
        {
            check = false;
            if (txtMaNV.Text == "" && txtTenNV.Text == "" && cbbMaCV.Text == "" && txtLuong.Text == "")
            {
                tkiem = nv;
                loadDuLieu();
                return;
            }
            if (txtMaNV.Text != "")
            {
                string s = txtMaNV.Text;
                foreach (char c in s)
                {
                    if (!char.IsDigit(c))
                    {
                        MessageBox.Show("Mã nhân viên không hợp lệ");
                        check = true;
                        txtMaNV.Text = "";
                        txtMaNV.Focus();
                        return;
                    }
                }
                tkiem = db.NhanViens.Where(p => p.MaNV == int.Parse(s)).ToList();
                if (nv != null)
                {
                    loadDuLieu();
                    return;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên!", "Thông báo");
                    check = true;
                    return;
                }
            }
            else
            {
                if (txtTenNV.Text != "")
                {
                    if (cbbMaCV.Text != ""){
                        if (txtLuong.Text != "")
                        {
                            if (int.TryParse(txtLuong.Text, out int result)?false:true)
                            {
                                MessageBox.Show("Số lương không hợp lệ!", "Thông báo");
                                check = true;
                                txtLuong.Text = "";
                                txtLuong.Focus();
                                return;
                            }
                            tkiem = db.NhanViens.Where(p => p.HoTenNV == txtTenNV.Text
                                                                        && p.MaCV == cbbMaCV.SelectedValue.ToString()
                                                                        && p.Luong >= int.Parse(txtLuong.Text)).ToList();
                            if (tkiem != null)
                            {
                                loadDuLieu();
                                return;
                            }
                        }
                        else
                        {
                            tkiem = db.NhanViens.Where(p => p.HoTenNV == txtTenNV.Text
                                                                        && p.MaCV == cbbMaCV.SelectedValue.ToString()).ToList();
                            if (tkiem != null)
                            {
                                loadDuLieu();
                                return;
                            }
                        }
                    }
                    else
                    {
                        tkiem = db.NhanViens.Where(p => p.HoTenNV == txtTenNV.Text).ToList();
                        if (tkiem != null)
                        {
                            loadDuLieu();
                            return;
                        }
                    }
                }
                else
                {
                    if (cbbMaCV.Text != "")
                    {
                        if (txtLuong.Text != "")
                        {
                            if (int.TryParse(txtLuong.Text, out int result) ? false : true)
                            {
                                MessageBox.Show("Số lương không hợp lệ!", "Thông báo");
                                check = true;
                                txtLuong.Text = "";
                                txtLuong.Focus();
                                return;
                            }
                            tkiem = db.NhanViens.Where(p =>p.MaCV == cbbMaCV.SelectedValue.ToString()
                                                                        && p.Luong >= int.Parse(txtLuong.Text)).ToList();
                            if (tkiem != null)
                            {
                                loadDuLieu();
                                return;
                            }
                        }
                        else
                        {
                            tkiem = db.NhanViens.Where(p => p.MaCV == cbbMaCV.SelectedValue.ToString()).ToList();
                            if (tkiem != null)
                            {
                                loadDuLieu();
                                return;
                            }
                        }
                    }
                    else
                    {
                        if (txtLuong.Text != "")
                        {
                            if (int.TryParse(txtLuong.Text, out int result) ? false : true)
                            {
                                MessageBox.Show("Số lương không hợp lệ!", "Thông báo");
                                check = true;
                                txtLuong.Text = "";
                                txtLuong.Focus();
                                return;
                            }
                        }
                        
                        tkiem = db.NhanViens.Where(p =>p.Luong >= int.Parse(txtLuong.Text)).ToList();
                        if (tkiem != null)
                        {
                            loadDuLieu();
                            return;
                        }
                    }
                }
            }
            MessageBox.Show("Không tìm thấy nhân viên!", "Thông báo");
            check = true;
            loadDuLieu();
        }

        private void txtTenNV_TextChanged(object sender, EventArgs e)
        {
            if (txtTenNV.Text != ""||cbbMaCV.Text!=""||txtLuong.Text!="")
            {
                txtMaNV.Hide();
            }
            else
            {
                check = true;
                txtMaNV.Show();
                loadDuLieu();
            }
        }


        private void txtLuong_TextChanged(object sender, EventArgs e)
        {
            if (txtTenNV.Text != "" || cbbMaCV.Text != "" || txtLuong.Text != "")
            {
                txtMaNV.Hide();
            }
            else
            {
                check = true;
                txtMaNV.Show();
                loadDuLieu();
            }
        }

        private void cbbMaCV_TextChanged(object sender, EventArgs e)
        {
            if (txtTenNV.Text != "" || cbbMaCV.Text != "" || txtLuong.Text != "")
            {
                txtMaNV.Hide();
            }
            else
            {
                check = true;
                txtMaNV.Show();
                loadDuLieu();
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {       
                ReportDSNV rp = new ReportDSNV(ID, txtMaNV.Text == "" ? -1 : int.Parse(txtMaNV.Text), txtTenNV.Text, cbbMaCV.Text, txtLuong.Text == "" ? -1 : int.Parse(txtLuong.Text));
                rp.Show();
        }
    }
}
