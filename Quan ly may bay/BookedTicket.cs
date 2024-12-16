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
using Quan_ly_may_bay.Base;

namespace Quan_ly_may_bay
{
    public partial class BookedTicket : Form
    {
        private List<UCInfo1> list = new List<UCInfo1>();
        databaseDataContext db = new databaseDataContext(Common.connectionString);
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
                TimeSpan gioHaCanh = loTrinh.GioHaCanh.Value; // Giờ hạ cánh
                timeSpans.Add(gioHaCanh);

                // Tính giờ khởi hành và hạ cánh
                DateTime thoiGianKhoiHanh = ngayKhoiHanh + gioCatCanh;
                DateTime thoiGianHaCanh = ngayKhoiHanh + gioHaCanh;

                // Xác định ngày hạ cánh, nếu giờ hạ cánh nhỏ hơn giờ cất cánh thì hạ cánh vào ngày hôm sau
                if (gioHaCanh < gioCatCanh)
                {
                    thoiGianHaCanh = thoiGianHaCanh.AddDays(1);
                }

                // Định dạng giờ khởi hành và hạ cánh
                uc.Date1.Text = thoiGianKhoiHanh.ToString("HH'h' dd/MM/yyyy");
                uc.Date2.Text = thoiGianHaCanh.ToString("HH'h' dd/MM/yyyy");

                string noiXuatPhat = db.SanBays.FirstOrDefault(p => p.MaSB == loTrinh.NoiXuatPhat).City.ToString();
                string noiDen = db.SanBays.FirstOrDefault(p => p.MaSB == loTrinh.NoiDen).City.ToString();
                uc.From.Text = noiXuatPhat;
                uc.To.Text = noiDen;
                uc.MaVe = ve[i].MaVe;
                uc.WatchBtn.Click += WatchBtn_Click;
                uc.WatchBtn.Tag = i;
                list.Add(uc);
            }
            if (list.Count <= 5) Add.Hide();
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
            string mave = ve[(int)btn.Tag].MaVe;
            ReportChuyenBay reportChuyenBay = new ReportChuyenBay(hoten, cccd, phoneNum, maCB, from, to, time1, seat, hanhLy, mave);
            reportChuyenBay.Show();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            Substract.Show();
            PanelTicket.Controls.Clear();
            lblStt.Text = (int.Parse(lblStt.Text) + 1).ToString();
            if (int.Parse(lblStt.Text) * 5 + 5 >= list.Count) Add.Hide();
            for (int i = 5 * int.Parse(lblStt.Text); i < 5 * int.Parse(lblStt.Text) + 5; i++)
            {
                if (i >= list.Count) return;
                PanelTicket.Controls.Add(list[i]);
            }
        }
        private void Substract_Click(object sender, EventArgs e)
        {
            Add.Show();
            PanelTicket.Controls.Clear();
            lblStt.Text = (int.Parse(lblStt.Text) - 1).ToString();
            if (int.Parse(lblStt.Text) == 0) Substract.Hide();
            if (int.Parse(lblStt.Text) * 5 + 5 >= list.Count) Add.Hide();
            for (int i = 5 * int.Parse(lblStt.Text); i < 5 * int.Parse(lblStt.Text) + 5; i++)
            {
                PanelTicket.Controls.Add(list[i]);
            }
        }
    }
}
