using ComponentFactory.Krypton.Toolkit;
using Quan_ly_may_bay.UCFlight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_ly_may_bay
{
    public partial class MainLogin : Form
    {
        private List<string> kh = new List<string>
        {
            "View Ticket",
            "Booked Ticket",
        };
        private List<string> nv = new List<string>
        {
            "View Ticket",
            "Flight Itinerary",
            "Create Flight",
            "Manage Staff",
        };
        private List<string> admin = new List<string>
        {
            "View Ticket",
            "Flight Itinerary",
            "Create Flight",
            "Manage Staff",
        };
        private Form frm;
        private Account account;
        private databaseDataContext db = new databaseDataContext();

        public MainLogin(int _id)
        {
            InitializeComponent();
                account = db.Accounts.FirstOrDefault(p => p.ID == _id);
            if (NameObject.Text.Length <= 7)
            {
                NameObject.Text = account.Username.ToString();
            }
            else NameObject.Text = account.Username.ToString().Substring(0,6) + "...";
            if (account.LevelID == 0) NhiemVu.Text = "Admin";
            else if (account.LevelID == 2) NhiemVu.Text = "KhachHang";
            else
            {
                NhanVien box = db.NhanViens.FirstOrDefault(p => p.ID == account.ID);
                NhiemVu.Text = box.MaCV.ToString();
            }
            if (account.LevelID == 2)
            {
                for (int i = 0; i < kh.Count; i++)
                {
                    UC_btnMainForm uC = new UC_btnMainForm();
                    uC.Dock = DockStyle.Top;
                    uC.lbl.Click += Btnclick;
                    uC.lbl.Text = kh[i];
                    fpanelBtn.Controls.Add(uC);
                    uC.lbl.Click += Btnclick;
                }
            }
            else if(account.LevelID == 0)
            {
                for (int i = 0; i < admin.Count; i++)
                {
                    UC_btnMainForm uC = new UC_btnMainForm();
                    uC.Dock = DockStyle.Top;
                    uC.lbl.Click += Btnclick;
                    uC.lbl.Text = admin[i];
                    fpanelBtn.Controls.Add(uC);
                    uC.lbl.Click += Btnclick;
                }
            }
            else 
            {
                NhanVien box =  db.NhanViens.FirstOrDefault(p => p.ID == account.ID);
                PhanQuyen pQ = db.PhanQuyens.FirstOrDefault(p => p.PQ == box.MaCV);
                var columnList = new List<object>
                {
                    pQ.ViewTicket,
                    pQ.FlightItinerary,
                    pQ.CreateFlight,
                    pQ.ManageStaff,
                    // Thêm các cột khác nếu cần
                };
                for(int i = 0; i < nv.Count; i++)
                {
                    if (columnList[i].Equals(1))
                    {
                        UC_btnMainForm uC = new UC_btnMainForm();
                        uC.Dock = DockStyle.Top;
                        uC.lbl.Click += Btnclick;
                        uC.lbl.Text = nv[i];
                        fpanelBtn.Controls.Add(uC);
                        uC.lbl.Click += Btnclick;
                    }
                }
            }
        }


        private void Btnclick(object sender, EventArgs e)
        {
            //foreach(Form frm in panelMain.Controls)
            //{
            //    panelMain.Controls.Remove(frm);
            //}
            panelMain.Controls.Remove(frm);
            foreach (UC_btnMainForm btn in fpanelBtn.Controls)
            {
               if (btn.ColorBtn != Color.Transparent)
                {
                    btn.ColorBtn = Color.Transparent;
                    break;
                }
            }
            Label uc = (Label)sender;
            uc.BackColor = Color.FromArgb(128, 255, 255, 255);
            if (uc.Text == "View Ticket")
            {
                frm = new Datve();
                frm.TopLevel = false;
                panelMain.Controls.Add(frm);
                frm.Show();
            }
            else if (uc.Text == "Booked Ticket")
            {
                frm = new BookedTicket();
                frm.TopLevel = false;
                panelMain.Controls.Add(frm);
                frm.Show();
            }
            else if (uc.Text == "Flight Itinerary")
            {
                frm = new CapNhatLoTrinhBay();
                frm.TopLevel = false;
                panelMain.Controls.Add(frm);
                frm.Show();
            }
            else if (uc.Text == "Create Flight")
            {
                frm = new Capnhatchuyenbay();
                frm.TopLevel = false;
                panelMain.Controls.Add(frm);
                frm.Show();
            }
            else if (uc.Text == "Manage Staff")
            {
                frm = new ManageStaff();
                frm.TopLevel = false;
                panelMain.Controls.Add(frm);
                frm.Show();
            }
        }

        private void xemThongTin(object sender, EventArgs e)
        {
            panelMain.Controls.Remove(frm);
            foreach (UC_btnMainForm btn in fpanelBtn.Controls)
            {
                if (btn.ColorBtn != Color.Transparent)
                {
                    btn.ColorBtn = Color.Transparent;
                    break;
                }
            }
            frm = new InformationAccount(account.ID);
            frm.TopLevel = false;
            frm.Location = new Point(50, 10);
            panelMain.Controls.Add(frm);
            frm.Show();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
            MainNotLogin frm = new MainNotLogin();
            frm.ShowDialog();
         }
    }
}
