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
using Microsoft.Reporting.WinForms;
using Quan_ly_may_bay.Base;

namespace Quan_ly_may_bay
{
    public partial class TaoChuyenBay : KryptonForm
    {
        private databaseDataContext db = new databaseDataContext(Common.connectionString);
        public TaoChuyenBay()
        {
            InitializeComponent();
            cbbLT.DataSource = db.LoTrinhs.OrderBy(x => x.Stt);
            cbbLT.DisplayMember = "MaLT";
            cbbLT.ValueMember = "MaLT";

            cbbLT.SelectedIndex = 0;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            if(dTpKhoiHanh.Value < DateTime.Now.AddDays(3))
            {
                MessageBox.Show("Thời gian phải lớn hơn 3 ngày so với hiện tại!","Warning",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ChuyenBay cb = db.ChuyenBays.OrderByDescending(p=>p.Stt).FirstOrDefault();
            ChuyenBay cbThem = new ChuyenBay();

            cbThem.MaCB = "HK" + (int.Parse(cb.MaCB.Substring(2, cb.MaCB.Length - 2)) + 1).ToString();

            cbThem.MaLT = cbbLT.SelectedValue.ToString();

            cbThem.NgayKH = dTpKhoiHanh.Value;

            cbThem.SoGhe = int.Parse(SoGhe.Text);

            ChuyenBay check = db.ChuyenBays.FirstOrDefault(p=>p.MaLT == cbThem.MaLT && p.NgayKH == dTpKhoiHanh.Value);
            if(check != null)
            {
                MessageBox.Show("Chuyến bay đã tồn tại!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            db.ChuyenBays.InsertOnSubmit(cbThem);
            db.SubmitChanges();
            
            this.Close();
        }

        private void cbbLT_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoTrinh lt = new LoTrinh();
            lt = db.LoTrinhs.FirstOrDefault(p=>p.MaLT == cbbLT.SelectedValue.ToString());
            if(lt != null)
            {
                txtMaMB.Text = lt.MaMB.ToString();
                SanBay sb = db.SanBays.FirstOrDefault(p => p.MaSB == lt.NoiXuatPhat);
                SanBay sbs = db.SanBays.FirstOrDefault(p => p.MaSB == lt.NoiDen);
                txtNoiXuatPhat.Text = sb.City;
                txtNoiDen.Text = sbs.City;
                txtGioCatCanh.Text = DateTime.Today.Add(lt.GioCatCanh.Value).ToString("hh:mm tt");
                txtGioHaCanh.Text = DateTime.Today.Add(lt.GioHaCanh.Value).ToString("hh:mm tt");
                txtGia.Text = $"{lt.Gia:N0}";
            }
        }
    }
}
