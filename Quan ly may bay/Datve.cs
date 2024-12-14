using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Quan_ly_may_bay.UCFlight;

namespace Quan_ly_may_bay
{
    public partial class Datve : KryptonForm
    {
        private List<UC_Ticket> list = new List<UC_Ticket>();
        private List<UC_Ticket> filteredList = new List<UC_Ticket>();
        private List<ChuyenBay> chuyenBays = new List<ChuyenBay>();
        private int id;
        databaseDataContext db = new databaseDataContext();
        public Datve(int _id)
        {
            InitializeComponent();
            id = _id;
            chuyenBays = db.ChuyenBays.OrderBy(p => p.Stt).ToList();
            for(int i = 0; i < chuyenBays.Count; ++i)
            {
                UC_Ticket uc = new UC_Ticket();
                LoTrinh lb = db.LoTrinhs.FirstOrDefault(p => p.MaLT == chuyenBays[i].MaLT);
                DateTime ngayKhoiHanh = chuyenBays[i].NgayKH.Value; // Ngày khởi hành
                TimeSpan gioCatCanh = lb.GioCatCanh.Value; // Giờ cất cánh
                TimeSpan gioHaCanh = lb.GioHaCanh.Value;   // Giờ hạ cánh

                // Xác định ngày hạ cánh
                DateTime ngayHaCanh = ngayKhoiHanh + gioHaCanh;
                if (gioHaCanh < gioCatCanh) // Hạ cánh vào ngày hôm sau
                {
                    ngayHaCanh = ngayHaCanh.AddDays(1);
                }

                // Định dạng giờ và ngày hạ cánh
                uc.time2.Text = DateTime.Today.Add(gioHaCanh).Hour.ToString() + "h";
                uc.time1.Text = DateTime.Today.Add(gioCatCanh).Hour.ToString() + "h";    
                uc.date1.Text = ngayKhoiHanh.ToString("dd/MM/yyyy"); 
                uc.date2.Text = ngayHaCanh.ToString("dd/MM/yyyy");

                int passengerCount = db.Ves.Count(p => p.MaCB == chuyenBays[i].MaCB);
                string noiXuatPhat = db.SanBays.FirstOrDefault(p => p.MaSB == lb.NoiXuatPhat).City.ToString();
                string noiDen = db.SanBays.FirstOrDefault(p => p.MaSB == lb.NoiDen).City.ToString();
                uc.from.Text = noiXuatPhat;
                uc.to.Text = noiDen;
                uc.passengers.Text = $"{passengerCount}/100";
                uc.detailBtn.Click += DetailBtn_Click;
                uc.detailBtn.Tag = i;
                list.Add(uc);
            }
            filteredList = list;
            for (int i = 5 * int.Parse(lblStt.Text); i < 5 * int.Parse(lblStt.Text) + 5; i++)
            {
                if (i >= list.Count)
                {
                    Add.Enabled = false;
                    break;
                }
                PanelTicket.Controls.Add(filteredList[i]);
            }
            cbbFrom.Items.Add("Đắk Lắk");
            cbbFrom.Items.Add("Cà Mau");
            cbbFrom.Items.Add("Khánh Hòa");
            cbbFrom.Items.Add("Đà Nẵng");
            cbbFrom.Items.Add("Điện Biên");
            cbbFrom.Items.Add("Lâm Đồng");
            cbbFrom.Items.Add("Hà Nội");
            cbbFrom.Items.Add("Thừa Thiên Huế");
            cbbFrom.Items.Add("Kiên Giang");
            cbbFrom.Items.Add("Gia Lai");
            cbbFrom.Items.Add("TP Hồ Chí Minh");
            cbbFrom.Items.Add("Phú Yên");
            cbbFrom.Items.Add("Thanh Hóa");
            cbbFrom.Items.Add("Cần Thơ");
            cbbFrom.Items.Add("Quảng Nam");
            cbbFrom.Items.Add("Bà Rịa - Vũng Tàu");
            cbbFrom.Items.Add("Quảng Bình");
            cbbFrom.Items.Add("Quảng Ninh");
            cbbFrom.Items.Add("Nghệ An");

            cbbTo.Items.Add("Đắk Lắk");
            cbbTo.Items.Add("Cà Mau");
            cbbTo.Items.Add("Khánh Hòa");
            cbbTo.Items.Add("Đà Nẵng");
            cbbTo.Items.Add("Điện Biên");
            cbbTo.Items.Add("Lâm Đồng");
            cbbTo.Items.Add("Hà Nội");
            cbbTo.Items.Add("Thừa Thiên Huế");
            cbbTo.Items.Add("Kiên Giang");
            cbbTo.Items.Add("Gia Lai");
            cbbTo.Items.Add("TP Hồ Chí Minh");
            cbbTo.Items.Add("Phú Yên");
            cbbTo.Items.Add("Thanh Hóa");
            cbbTo.Items.Add("Cần Thơ");
            cbbTo.Items.Add("Quảng Nam");
            cbbTo.Items.Add("Bà Rịa - Vũng Tàu");
            cbbTo.Items.Add("Quảng Bình");
            cbbTo.Items.Add("Quảng Ninh");
            cbbTo.Items.Add("Nghệ An");
        }
        private void DetailBtn_Click(object sender, EventArgs e)
        {
            KryptonButton btn = sender as KryptonButton;
            int indx = (int)btn.Tag;
            string maCB = chuyenBays[indx].MaCB;
            Chitietchuyenbay chitietchuyenbay = new Chitietchuyenbay(maCB, id);
            chitietchuyenbay.Show();

        }
        private void lblStt_TextChanged(object sender, EventArgs e)
        {
            for (int i = 5 * int.Parse(lblStt.Text); i < 5 * int.Parse(lblStt.Text) + 5; i++)
            {
                if (i >= filteredList.Count) {
                    Add.Enabled = false;
                    break;
                }
                PanelTicket.Controls.Add(filteredList[i]);
            }
        }

        private void Substract_Click(object sender, EventArgs e)
        {
            PanelTicket.Controls.Clear();
            lblStt.Text = (int.Parse(lblStt.Text) - 1).ToString();
            if (int.Parse(lblStt.Text) == 0)
            {
                Substract.Enabled = false;
            }
            Add.Enabled = true;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            PanelTicket.Controls.Clear();
            lblStt.Text = (int.Parse(lblStt.Text) + 1).ToString();     
            Substract.Enabled = true;
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            PanelTicket.Controls.Clear();
            filteredList = list;

            if (!string.IsNullOrEmpty(cbbFrom.Text))
            {
                for(int i =  0; i < filteredList.Count; ++i)
                {
                    if (!filteredList[i].from.Text.Contains(cbbFrom.Text))
                    {
                        filteredList.RemoveAt(i);
                    }
                }
               
            }

            if (!string.IsNullOrEmpty(cbbTo.Text))
            {
                for (int i = 0; i < filteredList.Count; ++i)
                {
                    if (!filteredList[i].to.Text.Contains(cbbTo.Text))
                    {
                        filteredList.RemoveAt(i);
                    }
                }
                
            }

            //if (!string.IsNullOrEmpty(Time.Text))
            //{
            //    for (int i = 0; i < filteredList.Count; ++i)
            //    {
            //        if (filteredList[i].date1.Text != Time.Value.ToString("dd/MM/yyyy"))
            //        {
            //            filteredList.RemoveAt(i);
            //        }
            //    }
               
            //}

            for (int i = 5 * int.Parse(lblStt.Text); i < 5 * int.Parse(lblStt.Text) + 5; i++)
            {
                if (i >= filteredList.Count)
                {
                    Add.Enabled = false;
                    break;
                }
                PanelTicket.Controls.Add(filteredList[i]);
            }
            label4.Text = filteredList.Count.ToString();
        }
    }
}
