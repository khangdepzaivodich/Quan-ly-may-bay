using ComponentFactory.Krypton.Toolkit;
using Quan_ly_may_bay.UCFlight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_ly_may_bay
{
    public partial class BookedTicket : Form
    {
        private List<UCInfo1> list = new List<UCInfo1>();
        databaseDataContext db = new databaseDataContext();
        private int id;
        List<Ve> ve = new List<Ve>();
        private List<TimeSpan> timeSpans = new List<TimeSpan>();
        public BookedTicket(int _id)
        {
            InitializeComponent();
            Substract.Hide();
            id = _id;
            ve = db.Ves.Where(p => p.MaKH == _id).ToList();
            for(int i = 0; i < ve.Count; ++i)
            {
                ChuyenBay chuyenBay = db.ChuyenBays.FirstOrDefault(p => p.MaCB == ve[i].MaCB);
                LoTrinh loTrinh = db.LoTrinhs.FirstOrDefault(p => p.MaLT == chuyenBay.MaLT);
                UCInfo1 uc = new UCInfo1();
                int levelSeat = (int)ve[i].LevelSeat;
                DateTime ngayKhoiHanh = chuyenBay.NgayKH.Value; // Ngày khởi hành
                TimeSpan gioCatCanh = loTrinh.GioCatCanh.Value; // Giờ cất cánh
                TimeSpan gioHaCanh = loTrinh.GioHaCanh.Value;   // Giờ hạ cánh
                timeSpans.Add(gioCatCanh);
                // Xác định ngày hạ cánh
                DateTime ngayHaCanh = ngayKhoiHanh + gioHaCanh;
                if (gioHaCanh < gioCatCanh) // Hạ cánh vào ngày hôm sau
                {
                    ngayHaCanh = ngayHaCanh.AddDays(1);
                }
                uc.Level.Text = levelSeat == 0 ? "Thương gia" : "Phổ thông";
                // Định dạng giờ và ngày hạ cánh
                uc.Date1.Text = ngayKhoiHanh.ToString("dd/MM/yyyy");
                uc.Date2.Text = ngayHaCanh.ToString("dd/MM/yyyy");
                string noiXuatPhat = db.SanBays.FirstOrDefault(p => p.MaSB == loTrinh.NoiXuatPhat).City.ToString();
                string noiDen = db.SanBays.FirstOrDefault(p => p.MaSB == loTrinh.NoiDen).City.ToString();
                uc.From.Text = noiXuatPhat;
                uc.To.Text = noiDen;
                uc.MaVe = ve[i].MaVe;
                uc.WatchBtn.Click += WatchBtn_Click;
                uc.WatchBtn.Tag = i;
                list.Add(uc);
            }
            for (int i = 5 * int.Parse(lblStt.Text); i < 5 * int.Parse(lblStt.Text) + 5; i++)
            {
                if (i >= list.Count)
                {
                    Add.Hide();
                    break;
                }
                PanelTicket.Controls.Add(list[i]);
            }
        }
        private void WatchBtn_Click(object sender, EventArgs e)
        {
            KryptonButton btn = sender as KryptonButton;
            string hoten = db.KhachHangs.FirstOrDefault(p => p.MaKH == id).HoTenKH;
            string cccd = db.KhachHangs.FirstOrDefault(p => p.MaKH == id).CCCD;
            string phoneNum = db.KhachHangs.FirstOrDefault(p => p.MaKH == id).SDT;
            string maCB = ve[(int)btn.Tag].MaCB;
            string from = list[(int)btn.Tag].From.Text;
            string to = list[(int)btn.Tag].To.Text;
            string time1 = timeSpans[(int)btn.Tag].Hours.ToString() + "h " + list[(int)btn.Tag].Date1.Text;
            string seat = ve[(int)btn.Tag].Seat;
            int hanhLy = (int)ve[(int)btn.Tag].HanhLy;
            ReportChuyenBay reportChuyenBay = new ReportChuyenBay(hoten, cccd, phoneNum, maCB, from, to, time1, seat, hanhLy);
            reportChuyenBay.Show();
        }
        private void lblStt_TextChanged(object sender, EventArgs e)
        {
            Add.Show();
            PanelTicket.Controls.Clear();
            lblStt.Text = (int.Parse(lblStt.Text) + 1).ToString();
            if (int.Parse(lblStt.Text) * 5 + 5 >= list.Count) Add.Hide();
            for (int i = 5 * int.Parse(lblStt.Text); i < 5 * int.Parse(lblStt.Text) + 5; i++)
            {
                PanelTicket.Controls.Add(list[i]);
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            Substract.Show();
            PanelTicket.Controls.Clear();
            lblStt.Text = (int.Parse(lblStt.Text) - 1).ToString();
            if (int.Parse(lblStt.Text) == 0) Substract.Hide();
            for (int i = 5 * int.Parse(lblStt.Text); i < 5 * int.Parse(lblStt.Text) + 5; i++)
            {
                PanelTicket.Controls.Add(list[i]);
            }
        }
        private void Substract_Click(object sender, EventArgs e)
        {
            Add.Show();
            PanelTicket.Controls.Clear();
            lblStt.Text = (int.Parse(lblStt.Text) + 1).ToString();
            if (int.Parse(lblStt.Text) * 5 + 5 >= list.Count) Add.Hide();
            for (int i = 5 * int.Parse(lblStt.Text); i < 5 * int.Parse(lblStt.Text) + 5; i++)
            {
                PanelTicket.Controls.Add(list[i]);
            }
        }
    }
}
