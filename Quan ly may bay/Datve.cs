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
using Quan_ly_may_bay.Base;

namespace Quan_ly_may_bay
{
    public partial class Datve : KryptonForm
    {
        private List<UC_Ticket> list = new List<UC_Ticket>();
        private List<UC_Ticket> filteredList = new List<UC_Ticket>();
        private List<ChuyenBay> chuyenBays = new List<ChuyenBay>();
        private int id;
        private databaseDataContext db = new databaseDataContext(Common.connectionString);
        public Datve(int _id)
        {
            InitializeComponent();
            id = _id;
            chuyenBays = db.ChuyenBays.Where(p => p.NgayKH > DateTime.Now).OrderBy(p => p.Stt).ToList();
            Substract.Visible = false;
            for(int i = 0; i < chuyenBays.Count; ++i)
            {
                UC_Ticket uc = new UC_Ticket();
                LoTrinh lb = db.LoTrinhs.FirstOrDefault(p => p.MaLT == chuyenBays[i].MaLT);

                DateTime ngayKhoiHanh = chuyenBays[i].NgayKH.Value; // Ngày khởi hành
                TimeSpan gioCatCanh = lb.GioCatCanh.Value; // Giờ cất cánh
                TimeSpan gioHaCanh = lb.GioHaCanh.Value; // Giờ hạ cánh

                // Tính thời gian cất cánh và hạ cánh
                DateTime thoiGianCatCanh = ngayKhoiHanh + gioCatCanh;
                DateTime thoiGianHaCanh = ngayKhoiHanh + gioHaCanh;

                // Xác định ngày hạ cánh, nếu giờ hạ cánh nhỏ hơn giờ cất cánh thì là ngày hôm sau
                if (gioHaCanh < gioCatCanh)
                {
                    thoiGianHaCanh = thoiGianHaCanh.AddDays(1);
                }

                // Định dạng giờ và ngày cho UI
                uc.time1.Text = thoiGianCatCanh.ToString("HH'h'"); // Giờ cất cánh
                uc.time2.Text = thoiGianHaCanh.ToString("HH'h'"); // Giờ hạ cánh
                uc.date1.Text = thoiGianCatCanh.ToString("dd/MM/yyyy"); // Ngày cất cánh
                uc.date2.Text = thoiGianHaCanh.ToString("dd/MM/yyyy"); // Ngày hạ cánh



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
            filteredList = new List<UC_Ticket>(list);
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
        private void RefreshList()
        {
            db = new databaseDataContext(Common.connectionString);
            chuyenBays.Clear();
            chuyenBays = db.ChuyenBays.Where(p => p.NgayKH > DateTime.Now).OrderBy(p => p.Stt).ToList();


            for (int i = 0; i < chuyenBays.Count; ++i)
            {
                int passengerCount = db.Ves.Count(p => p.MaCB == chuyenBays[i].MaCB);
                list[i].passengers.Text = $"{passengerCount}/100";
            }
            PanelTicket.Controls.Clear();
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
            Add.Visible = true;
        }
        private void DetailBtn_Click(object sender, EventArgs e)
        {
            KryptonButton btn = sender as KryptonButton;
            int indx = (int)btn.Tag;
            string maCB = chuyenBays[indx].MaCB;
            Chitietchuyenbay chitietchuyenbay = new Chitietchuyenbay(maCB, id);
            chitietchuyenbay.FormClosed += (s, args) => RefreshList();
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
                if (list[i].from.Text == cbbFrom.Text && list[i].to.Text == cbbTo.Text && list[i].date1.Text == Time.Value.ToString("dd/MM/yyyy")) // Điều kiện lọc
                {
                    filteredList.Add(list[i]);
                }
            }

            if (filteredList.Count == 0)
            {
                MessageBox.Show("Không tìm thấy kết quả phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Add.Visible = false;
                Substract.Visible = false;
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Add.Visible = true;
            Substract.Visible = false;
            filteredList = new List<UC_Ticket>(list);
            lblStt.Text = "0";
            PanelTicket.Controls.Clear();
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
