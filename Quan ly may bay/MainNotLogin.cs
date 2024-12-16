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
                Properties.Resources.hcm1,
                Properties.Resources.hcm2,
                Properties.Resources.hcm3,
            },
            new List<Image>
            {
                Properties.Resources.ho_hoan_kiem,
                Properties.Resources.hanoi2,
                Properties.Resources.hanoi3,
            },
            new List<Image>
            {
                Properties.Resources.quangninh1,
                Properties.Resources.quangninh2,
                Properties.Resources.quangninh3,
            },
        };
        List<UC_MainNotLogin> uC_MainNotLogins = new List<UC_MainNotLogin>();
        List<List<string>> Locations = new List<List<string>>
        {
            new List<string>
            {
                "TP.HCM",
                "Hà Nội - TP.HCM",
                "Huế - TP.HCM",
                "Đà Nẵng - TP.HCM"
            },
            new List<string>
            {
                "Hà Nội",
                "TP.HCM - Hà Nội",
                "Đà Nẵng - Hà Nội",
                "Phú Quốc - Hà Nội"
            },
            new List<string>
            {
                "Quảng Ninh",
                "TP.HCM - Quảng Ninh",
                "Khánh Hòa - Quảng Ninh",
                "Cần Thơ - Quảng Ninh"
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
                u.Ranking = "#" + (i + 1).ToString();
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

        private void SignupBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignupForm signupForm = new SignupForm();
            signupForm.ShowDialog();
            if(signupForm.DialogResult == DialogResult.Cancel)
            {
                this.Show();
            }
            else this.Close();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            if (loginForm.DialogResult == DialogResult.Cancel)
            {
                this.Show();
            }
            else this.Close();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
