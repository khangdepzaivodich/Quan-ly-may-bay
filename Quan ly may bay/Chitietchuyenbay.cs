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
    public partial class Chitietchuyenbay : KryptonForm
    {
        ChuyenBay chuyenbay = new ChuyenBay();
        LoTrinh lotrinh = new LoTrinh();
        databaseDataContext db = new databaseDataContext(Common.connectionString);
        private int id;
        private string maCB;
        Ve ve = new Ve();
        public Chitietchuyenbay(string _maCB, int _id)
        {
            InitializeComponent();
            id = _id;
            maCB = _maCB;
            chuyenbay = db.ChuyenBays.FirstOrDefault(p => p.MaCB == _maCB);
            lotrinh = db.LoTrinhs.FirstOrDefault(p => p.MaLT == chuyenbay.MaLT);
            label1.Text = _maCB;
            DateTime ngayKhoiHanh = chuyenbay.NgayKH.Value; // Ngày khởi hành
            TimeSpan gioCatCanh = lotrinh.GioCatCanh.Value; // Giờ cất cánh
            TimeSpan gioHaCanh = lotrinh.GioHaCanh.Value;   // Giờ hạ cánh

            // Xác định ngày hạ cánh
            DateTime ngayHaCanh = ngayKhoiHanh + gioHaCanh;
            if (gioHaCanh < gioCatCanh) // Hạ cánh vào ngày hôm sau
            {
                ngayHaCanh = ngayHaCanh.AddDays(1);
            }

            // Định dạng giờ và ngày hạ cánh
            time2.Text = DateTime.Today.Add(gioHaCanh).ToString("hh:mm tt");
            time1.Text = DateTime.Today.Add(gioCatCanh).ToString("hh:mm tt");
            date1.Text = ngayKhoiHanh.ToString("dd/MM/yyyy");
            date2.Text = ngayHaCanh.ToString("dd/MM/yyyy");
            from.Text = db.SanBays.FirstOrDefault(p => p.MaSB == lotrinh.NoiXuatPhat).City.ToString();
            to.Text = db.SanBays.FirstOrDefault(p => p.MaSB == lotrinh.NoiDen).City.ToString();
            sanbay1.Text = db.SanBays.FirstOrDefault(p => p.MaSB == lotrinh.NoiXuatPhat).TenSB.ToString();
            sanbay2.Text = db.SanBays.FirstOrDefault(p => p.MaSB == lotrinh.NoiDen).TenSB.ToString();

        }

        public void SetValue(string val)
        {
            textBox1.Text = val;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChoseSeat frm = new ChoseSeat(maCB, id, this);
            frm.ShowDialog();
            double giaVe = (double)lotrinh.Gia;
            int soHanhLy = (int)numericUpDown1.Value;
            double giaHanhLy = soHanhLy * 0.1 * (giaVe);
            if (textBox1.Text != "")
            {
                if (textBox1.Text.Contains("A"))
                {
                    giaVe *= 1.5;
                }
                giaVeTextBox.Text = $"Giá vé    {giaVe}";
                giaHanhLyTextBox.Text = $"Giá hành lý    {giaHanhLy}";
                tongSoTextBox.Text = $"Tổng số    {giaVe + giaHanhLy}";
            }
            ve.Gia = (int)(giaVe + giaHanhLy);
            ve.HanhLy = soHanhLy;

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            double giaVe = (double)lotrinh.Gia;
            int soHanhLy = (int)numericUpDown1.Value;
            double giaHanhLy = soHanhLy * 0.1 * (giaVe);
            if (textBox1.Text != "")
            {
                if (textBox1.Text.Contains("A"))
                {
                    giaVe *= 1.5;
                }
                giaVeTextBox.Text = $"Giá vé    {giaVe}";
                giaHanhLyTextBox.Text = $"Giá hành lý    {giaHanhLy}";
                tongSoTextBox.Text = $"Tổng số    {giaVe + giaHanhLy}";
            }
            ve.Gia = (int)(giaVe + giaHanhLy);
            ve.HanhLy = soHanhLy;
        }
        public void SetVe(Ve _ve)
        {
            ve = _ve;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                db.Ves.InsertOnSubmit(ve);
                db.SubmitChanges();
                MessageBox.Show("Đặt vé thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Text = "";
            }
            else
            {
                MessageBox.Show("Đặt vé không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Close();
        }

    }
}



