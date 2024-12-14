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
        List<Ve> ve = new List<Ve>();
        public BookedTicket(int _id)
        {
            InitializeComponent();
            ve = db.Ves.Where(p => p.MaKH == _id).OrderBy(p => p.MaVe).ToList();
            for(int i = 0; i < ve.Count; ++i)
            {
                Console.WriteLine("Có");
                ChuyenBay chuyenBay = db.ChuyenBays.FirstOrDefault(p => p.MaCB == ve[i].MaCB);
                LoTrinh loTrinh = db.LoTrinhs.FirstOrDefault(p => p.MaLT == chuyenBay.MaLT);
                UCInfo1 uc = new UCInfo1();
                int levelSeat = (int)ve[i].LevelSeat;
                DateTime ngayKhoiHanh = chuyenBay.NgayKH.Value; // Ngày khởi hành
                TimeSpan gioCatCanh = loTrinh.GioCatCanh.Value; // Giờ cất cánh
                TimeSpan gioHaCanh = loTrinh.GioHaCanh.Value;   // Giờ hạ cánh

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
                list.Add(uc);
            }
            for (int i = 5 * int.Parse(lblStt.Text); i < 5 * int.Parse(lblStt.Text) + 5; i++)
            {
                if (i >= list.Count)
                {
                    Add.Enabled = false;
                    break;
                }
                PanelTicket.Controls.Add(list[i]);
            }
        }

        private void lblStt_TextChanged(object sender, EventArgs e)
        {
            for (int i = 5 * int.Parse(lblStt.Text); i < 5 * int.Parse(lblStt.Text) + 5; i++)
            {
                if (i >= list.Count)
                {
                    Add.Enabled = false;
                    break;
                }
                PanelTicket.Controls.Add(list[i]);
            }
        }

        private void Substract_Click(object sender, EventArgs e)
        {
            for (int i = 5 * int.Parse(lblStt.Text); i < 5 * int.Parse(lblStt.Text) + 5; i++)
            {
                if (i >= list.Count)
                {
                    Add.Enabled = false;
                    break;
                }
                PanelTicket.Controls.Remove(list[i]);
            }

            lblStt.Text = (int.Parse(lblStt.Text) - 1).ToString();
            if (int.Parse(lblStt.Text) == 0)
            {
                Substract.Enabled = false;
            }
            Add.Enabled = true;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            for (int i = 5 * int.Parse(lblStt.Text); i < 5 * int.Parse(lblStt.Text) + 5; i++)
            {
                if (i >= list.Count)
                {
                    Add.Enabled = false;
                    break;
                }
                PanelTicket.Controls.Remove(list[i]);
            }
            lblStt.Text = (int.Parse(lblStt.Text) + 1).ToString();
            Substract.Enabled = true;
        }
    }
}
