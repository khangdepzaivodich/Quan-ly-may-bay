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
    public partial class TaoLoTrinh : KryptonForm
    {
        private databaseDataContext db = new databaseDataContext(Common.connectionString);
        public static LoTrinh loTrinh = new LoTrinh();
        public TaoLoTrinh()
        {
            InitializeComponent();
            var maybays = db.MayBays
                   .Select(c => new { c.MaMB, c.TypeMB })
                   .ToList();
            cbbMaybay.DataSource = maybays;
            cbbMaybay.DisplayMember = "TypeMB"; // Cột hiển thị
            cbbMaybay.ValueMember = "MaMB";

            var noiDi = db.SanBays
                                         .Select(c => new { c.MaSB, c.TenSB })
                                         .ToList();

            // Gắn dữ liệu vào ComboBox
            cbbFrom.DataSource = noiDi;
            cbbFrom.DisplayMember = "TenSb"; // Cột hiển thị
            cbbFrom.ValueMember = "MaSB";

            var noiDen = db.SanBays
                             .Select(c => new { c.MaSB, c.TenSB })
                             .ToList();

            cbbTo.DataSource = noiDen;
            cbbTo.DisplayMember = "TenSb"; // Cột hiển thị
            cbbTo.ValueMember = "MaSB";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            if(!int.TryParse(gia.Text, out int id))
            {
                errGia.SetError(gia, "Giá vé nhập không đúng!");
                return;
            }
            if(cbbFrom.SelectedValue == cbbTo.SelectedValue)
            {
                MessageBox.Show("Nơi đến với nơi xuất phát không được trùng!","Warning",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            LoTrinh rowWithMaxStt = db.LoTrinhs
                      .OrderByDescending(v => v.Stt) // Sắp xếp theo Stt giảm dần
                      .FirstOrDefault();
            loTrinh.MaLT = "HK"+(int.Parse(rowWithMaxStt.MaLT.Substring(2, 2))+1).ToString();
            loTrinh.MaMB = cbbMaybay.SelectedValue.ToString();
            loTrinh.NoiXuatPhat = cbbFrom.SelectedValue.ToString();
            loTrinh.NoiDen = cbbTo.SelectedValue.ToString();
            loTrinh.GioCatCanh = TimeDi.Value.TimeOfDay;
            loTrinh.GioHaCanh = TimeDen.Value.TimeOfDay;
            loTrinh.Gia = int.Parse(gia.Text);
            db.LoTrinhs.InsertOnSubmit(loTrinh);
            db.SubmitChanges();
            this.Close();
        }
    }
}
