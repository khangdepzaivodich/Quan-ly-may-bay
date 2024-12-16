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
    public partial class CapNhatLoTrinhBay : Form
    {
        private List<UC_CreateLoTrinhBay> list = new List<UC_CreateLoTrinhBay>();
        private databaseDataContext db = new databaseDataContext(Common.connectionString);
        List<LoTrinh> listLo;
        public CapNhatLoTrinhBay()
        {
            InitializeComponent();
            listLo = db.LoTrinhs.ToList();

            // Tạo danh sách các UserControl từ dữ liệu lộ trình
            for (int i = 0; i < listLo.Count; i++)
            {
                UC_CreateLoTrinhBay uc = new UC_CreateLoTrinhBay();

                // Xử lý giờ cất cánh
                uc.GioCC.Text = listLo[i].GioCatCanh.HasValue
                    ? DateTime.Today.Add(listLo[i].GioCatCanh.Value).ToString("hh:mm tt")
                    : "Không xác định";

                // Xử lý giờ hạ cánh
                uc.GioHC.Text = listLo[i].GioHaCanh.HasValue
                    ? DateTime.Today.Add(listLo[i].GioHaCanh.Value).ToString("hh:mm tt")
                    : "Không xác định";

                // Lấy thông tin sân bay xuất phát
                SanBay sb = db.SanBays.FirstOrDefault(p => p.MaSB == listLo[i].NoiXuatPhat);
                uc.NoiDi.Text = sb != null ? sb.City : "Không xác định";

                // Lấy thông tin sân bay đến
                SanBay sbs = db.SanBays.FirstOrDefault(p => p.MaSB == listLo[i].NoiDen);
                uc.NoiDen.Text = sbs != null ? sbs.City : "Không xác định";

                // Xử lý giá vé
                uc.Gia.Text = $"{listLo[i].Gia:N0}" + "VNĐ";

                // Thêm vào danh sách
                list.Add(uc);
            }

            // Xử lý phân trang
            int stt = 0;
            if (!int.TryParse(lblStt.Text, out stt))
            {
                stt = 0;
            }

            for (int i = 5 * stt; i < 5 * stt + 5; i++)
            {
                if (i >= list.Count)
                {
                    Add.Visible = false; // Tắt nút "Add" nếu không còn mục nào
                    break;
                }
                PanelTicket.Controls.Add(list[i]);
            }
        }


        private void pAdd_Click(object sender, EventArgs e)
        {

            TaoLoTrinh taoLoTrinh = new TaoLoTrinh();
            taoLoTrinh.ShowDialog();

            listLo = db.LoTrinhs.ToList();
            LoTrinh rowWithMaxStt = db.LoTrinhs
          .OrderByDescending(v => v.Stt) // Sắp xếp theo Stt giảm dần
          .FirstOrDefault();
            UC_CreateLoTrinhBay uc = new UC_CreateLoTrinhBay();
            uc.GioCC.Text = DateTime.Today.Add(rowWithMaxStt.GioCatCanh.Value).ToString(@"hh\:mm tt");
            uc.GioHC.Text = DateTime.Today.Add(rowWithMaxStt.GioHaCanh.Value).ToString(@"hh\:mm tt");
            uc.Gia.Text = rowWithMaxStt.Gia.ToString();
            SanBay sb = db.SanBays.FirstOrDefault(p => p.MaSB == rowWithMaxStt.NoiXuatPhat);
            uc.NoiDi.Text = sb.City;
            SanBay sbs = db.SanBays.FirstOrDefault(p => p.MaSB == rowWithMaxStt.NoiDen);
            uc.NoiDen.Text = sbs.City.ToString();

            list.Insert(0,uc);

            foreach(UC_CreateLoTrinhBay ucs in PanelTicket.Controls) PanelTicket.Controls.Remove(ucs);

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
