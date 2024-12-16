using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Quan_ly_may_bay.UCFlight;
using Quan_ly_may_bay.Base;
namespace Quan_ly_may_bay
{
    public partial class Capnhatchuyenbay : KryptonForm
    {
        private List<UC_CreateChuyenBay> list = new List<UC_CreateChuyenBay>();
        private databaseDataContext db = new databaseDataContext(Common.connectionString);
        private List<ChuyenBay> listCB;
        public Capnhatchuyenbay()
        {
            InitializeComponent();
            listCB = db.ChuyenBays.ToList();
            for (int i = 0; i < listCB.Count; i++)
            {
                UC_CreateChuyenBay uc = new UC_CreateChuyenBay();
                uc.maCB.Text = listCB[i].MaCB;
                uc.maLT.Text = listCB[i].MaLT;

                LoTrinh lb = db.LoTrinhs.FirstOrDefault(p=>p.MaLT == listCB[i].MaLT);


                DateTime ngayKhoiHanh = listCB[i].NgayKH.Value; // Ngày khởi hành
                TimeSpan gioCatCanh = lb.GioCatCanh.Value; // Giờ cất cánh
                TimeSpan gioHaCanh = lb.GioHaCanh.Value; // Giờ hạ cánh

                // Tính giờ khởi hành và hạ cánh
                DateTime thoiGianKhoiHanh = ngayKhoiHanh + gioCatCanh;
                DateTime thoiGianHaCanh = ngayKhoiHanh + gioHaCanh;

                // Xác định ngày hạ cánh, nếu giờ hạ cánh nhỏ hơn giờ cất cánh thì hạ cánh vào ngày hôm sau
                if (gioHaCanh < gioCatCanh)
                {
                    thoiGianHaCanh = thoiGianHaCanh.AddDays(1);
                }

                // Định dạng giờ khởi hành và hạ cánh
                uc.gioDen.Text = thoiGianHaCanh.ToString("HH'h' dd/MM/yyyy");
                uc.gioKhoiHanh.Text = thoiGianKhoiHanh.ToString("HH'h' dd/MM/yyyy");


                SanBay sb1 = db.SanBays.FirstOrDefault(p => p.MaSB == lb.NoiXuatPhat);
                uc.noiDen.Text = sb1.City;

                SanBay sb2 = db.SanBays.FirstOrDefault(p => p.MaSB == lb.NoiDen);
                uc.noiKhoiHanh.Text = sb2.City;
                uc.SoGhe.Text = $"{db.Ves.Count(p => p.MaCB == listCB[i].MaCB)}/100";

                list.Add(uc);
            }
            for (int i = 5 * int.Parse(lblStt.Text); i < 5 * int.Parse(lblStt.Text) + 5; i++)
            {
                if (i >= list.Count)
                {
                    Add.Visible = false;
                    break;
                }
                PanelTicket.Controls.Add(list[i]);
            }
            Substract.Visible = false;
        }
        private void pAdd_Click(object sender, EventArgs e)
        {
            TaoChuyenBay frm = new TaoChuyenBay();
            frm.ShowDialog();

            
            PanelTicket.Controls.Clear();
            ChuyenBay cb = db.ChuyenBays.OrderByDescending(p=>p.Stt).FirstOrDefault();
            UC_CreateChuyenBay uc = new UC_CreateChuyenBay();
            uc.maCB.Text = cb.MaCB;
            uc.maLT.Text = cb.MaLT;

            LoTrinh lb = db.LoTrinhs.FirstOrDefault(p => p.MaLT == cb.MaLT);


            if (lb.GioHaCanh.HasValue && lb.GioCatCanh.HasValue && cb.NgayKH.HasValue)
            {
                DateTime ngayKhoiHanh = cb.NgayKH.Value; // Ngày khởi hành
                TimeSpan gioCatCanh = lb.GioCatCanh.Value; // Giờ cất cánh
                TimeSpan gioHaCanh = lb.GioHaCanh.Value;   // Giờ hạ cánh

                // Xác định ngày hạ cánh
                DateTime ngayHaCanh = ngayKhoiHanh + gioHaCanh;
                if (gioHaCanh < gioCatCanh) // Hạ cánh vào ngày hôm sau
                {
                    ngayHaCanh = ngayHaCanh.AddDays(1);
                }

                // Định dạng giờ và ngày hạ cánh
                uc.gioDen.Text = DateTime.Today.Add(gioHaCanh).ToString("hh:mm tt") + " " + ngayHaCanh.ToString("dd/MM/yyyy");
                uc.gioKhoiHanh.Text = DateTime.Today.Add(gioCatCanh).ToString("hh:mm tt") + " " + ngayKhoiHanh.ToString("dd/MM/yyyy");
            }
            else
            {
                uc.gioDen.Text = "Không xác định"; // Xử lý nếu giá trị bị thiếu
                uc.gioKhoiHanh.Text = "Không xác định"; // Xử lý nếu giá trị bị thiếu
            }

            SanBay sb1 = db.SanBays.FirstOrDefault(p => p.MaSB == lb.NoiXuatPhat);
            uc.noiDen.Text = sb1.City;

            SanBay sb2 = db.SanBays.FirstOrDefault(p => p.MaSB == lb.NoiDen);
            uc.noiKhoiHanh.Text = sb2.City;
            uc.SoGhe.Text = "100/100";

            list.Insert(0, uc);

            for (int i = 5 * int.Parse(lblStt.Text); i < 5 * int.Parse(lblStt.Text) + 5; i++)
            {
                if (i >= list.Count)
                {
                    Add.Visible = false;
                    break;
                }
                PanelTicket.Controls.Add(list[i]);
            }
            Substract.Visible = false;
        }


        private void Substract_Click(object sender, EventArgs e)
        {
            PanelTicket.Controls.Clear();
            lblStt.Text = (int.Parse(lblStt.Text) - 1).ToString();
            if (int.Parse(lblStt.Text) == 0)
            {
                Substract.Visible = false;
            }
            Add.Visible = true;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            PanelTicket.Controls.Clear();
            lblStt.Text = (int.Parse(lblStt.Text) + 1).ToString();
            Substract.Visible = true;
        }

        private void lblStt_TextChanged(object sender, EventArgs e)
        {
                for (int i = 5 * int.Parse(lblStt.Text); i < 5 * int.Parse(lblStt.Text) + 5; i++)
                {
                    if (i >= list.Count)
                    {
                        Add.Visible = false;
                        break;
                    }
                    PanelTicket.Controls.Add(list[i]);
                }
        }
    }
}
