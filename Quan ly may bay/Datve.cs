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
        private databaseDataContext db = new databaseDataContext();
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
                    Add.Visible = false;
                    break;
                }
                PanelTicket.Controls.Add(list[i]);
            }

            cbbFrom.DataSource = db.SanBays;
            cbbFrom.DisplayMember = "City";

            cbbTo.DataSource = db.SanBays.ToList();
            cbbTo.DisplayMember = "City";
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
                    Add.Visible = false;
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

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            PanelTicket.Controls.Clear();
            filteredList = new List<UC_Ticket>();

            if(cbbFrom.Text == "" || cbbTo.Text == "")
            {
                cbbFrom.Text = "";
                cbbTo.Text = "";
            }
            if(cbbFrom.Text != "" && cbbTo.Text != "" && Time.Value == null)
            {
                return;
            }
            for (int i = 0; i < list.Count; ++i)
            {
                if(cbbFrom.Text != "" && cbbTo.Text != "")
                if (list[i].from.Text == cbbFrom.Text && list[i].to.Text == cbbTo.Text && list[i].date1.Text == Time.Value.ToString("dd/MM/yyyy")) // Điều kiện lọc
                {
                    filteredList.Add(list[i]);
                }
                else if(Time.Value.ToString("dd/MM/yyyy") != "")
                    {
                        if (list[i].date1.Text == Time.Value.ToString("dd/MM/yyyy")) // Điều kiện lọc
                        {
                            filteredList.Add(list[i]);
                        }
                    }
            }

            if (list.Count == 0)
            {
                MessageBox.Show("Không tìm thấy kết quả phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Add.Visible = false;
                return;
            }

            lblStt.Text = "0";

            for (int i = 5 * int.Parse(lblStt.Text); i < 5 * int.Parse(lblStt.Text) + 5; i++)
            {
                if (i >= filteredList.Count)
                {
                    Add.Visible = false;
                    break;
                }
                PanelTicket.Controls.Add(filteredList[i]);
            }
            Substract.Visible = false;
        }
    }
}
