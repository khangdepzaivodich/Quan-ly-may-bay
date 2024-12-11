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
        private List<string> str = new List<string>
        {
            "View Ticket",
            "Booked Ticket",
            "Flight Itinerary",
            "Create Flight",
        };
        private Form frm;
        private Account account;
        public MainLogin(Account _ac)
        {
            account = _ac;
            InitializeComponent();
            for(int i = 0; i < str.Count; i++)
            {
                UC_btnMainForm uC = new UC_btnMainForm();
                uC.Dock = DockStyle.Top;
                uC.lbl.Click += Btnclick;
                uC.lbl.Text = str[i];
                fpanelBtn.Controls.Add(uC);
                uC.lbl.Click += Btnclick;
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
            frm = new InformationAccount();
            frm.TopLevel = false;
            frm.Location = new Point(50, 10);
            panelMain.Controls.Add(frm);
            frm.Show();
        }

    }
}
