using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quan_ly_may_bay.UCFlight;
using ComponentFactory.Krypton.Toolkit;
namespace Quan_ly_may_bay
{
    public partial class MainNotLogin : KryptonForm
    {
        List<List<Image>> images = new List<List<Image>>
        {
            new List<Image>
            {
                Properties.Resources.nui_phu_si_1,
                Properties.Resources.hinh_anh_may_bay,
                Properties.Resources.Suitcase_Flat_Icon_Vector_svg,
            },
            new List<Image>
            {
                Properties.Resources.nui_phu_si_1,
                 Properties.Resources.hinh_anh_may_bay,
                Properties.Resources.Suitcase_Flat_Icon_Vector_svg,
            },
            new List<Image>
            {
                Properties.Resources.nui_phu_si_1,
                Properties.Resources.hinh_anh_may_bay,
                Properties.Resources.Suitcase_Flat_Icon_Vector_svg,
            },
        };
        List<UC_MainNotLogin> uC_MainNotLogins = new List<UC_MainNotLogin>();
        List<List<string>> Locations = new List<List<string>>
        {
            new List<string>
            {
                "Hà Nội",
                "TP.HCM - Hà Nội",
                "Đà Nẵng - Hà Nội",
                "Sapa - Hà nội"
            },
            new List<string>
            {
                "Hà Nội",
                "TP.HCM - Hà Nội",
                "Đà Nẵng - Hà Nội",
                "Sapa - Hà nội"
            },
            new List<string>
            {
                "Hà Nội",
                "TP.HCM - Hà Nội",
                "Đà Nẵng - Hà Nội",
                "Sapa - Hà nội"
            },

        };
        public MainNotLogin()
        {
            InitializeComponent();
        }
        private void MainNotLogin_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; ++i)
            {
                UC_MainNotLogin u = new UC_MainNotLogin();
                u.Title = Locations[i][0];
                u.Text1 = Locations[i][1];
                u.Text2 = Locations[i][2];
                u.Text3 = Locations[i][3];
                u.Location = new Point(i * 270 + 25, 150);
                uC_MainNotLogins.Add(u);
                Controls.Add(u);
            }
        }
        int j = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (j > 2) j = 0;
            for (int i = 0; i < 3; i++)
            {
                uC_MainNotLogins[i].BgImage = images[i][j];
            }
            ++j;
        }

        private void TacGiaBtn_Click(object sender, EventArgs e)
        {
            Author frm = new Author();  
            frm.ShowDialog();
        }
    }
}
