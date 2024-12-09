using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_ly_may_bay.UCFlight
{
    public partial class UC_MainNotLogin : UserControl
    {
        public UC_MainNotLogin()
        {
            InitializeComponent();
        }
        public Image BgImage
        {
            get => Btn1.StateCommon.Back.Image;
            set => Btn1.StateCommon.Back.Image = value;
        }
        public string Text1
        {
            get => Info1.Text;
            set => Info1.Text = value;
        }
        public string Text2
        {
            get => Info2.Text;
            set => Info2.Text = value;
        }
        public string Text3
        {
            get => Info3.Text;
            set => Info3.Text = value;
        }
        public string Title
        {
            get => Destination.Text;
            set => Destination.Text = value;
        }
        public string Ranking
        {
            get => Rank.Text;
            set => Rank.Text = value;
        }


        private void kryptonButton1_MouseEnter(object sender, EventArgs e)
        {
            Info1.BackColor = Color.FromArgb(200,0,0,0);
            Info2.BackColor = Color.FromArgb(200, 0, 0, 0);
            Info3.BackColor = Color.FromArgb(200, 0, 0, 0);
            Destination.BackColor = Color.FromArgb(200, 0, 0, 0);
            Rank.BackColor = Color.FromArgb(200, 0, 0, 0);
        }

        private void kryptonButton1_MouseLeave(object sender, EventArgs e)
        {
            Info1.BackColor = Color.FromArgb(128, 0, 0, 0);
            Info2.BackColor = Color.FromArgb(128, 0, 0, 0);
            Info3.BackColor = Color.FromArgb(128, 0, 0, 0);
            Destination.BackColor = Color.FromArgb(128, 0, 0, 0);
            Rank.BackColor = Color.FromArgb(128, 0, 0, 0);
        }

        private void kryptonButton1_MouseDown(object sender, MouseEventArgs e)
        {
            Info1.BackColor = Color.FromArgb(128, 0, 0, 0);
            Info2.BackColor = Color.FromArgb(128, 0, 0, 0);
            Info3.BackColor = Color.FromArgb(128, 0, 0, 0);
            Destination.BackColor = Color.FromArgb(128, 0, 0, 0);
            Rank.BackColor = Color.FromArgb(128, 0, 0, 0);
        }

        private void kryptonButton1_MouseUp(object sender, MouseEventArgs e)
        {
            Info1.BackColor = Color.FromArgb(200, 0, 0, 0);
            Info2.BackColor = Color.FromArgb(200, 0, 0, 0);
            Info3.BackColor = Color.FromArgb(200, 0, 0, 0);
            Destination.BackColor = Color.FromArgb(200, 0, 0, 0);
            Rank.BackColor = Color.FromArgb(200, 0, 0, 0);
        }
    }
}
