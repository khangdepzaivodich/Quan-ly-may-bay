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
    public partial class UC_Author : UserControl
    {
        public UC_Author()
        {
            InitializeComponent();
        }
        public string Ten
        {
            get => label1.Text; set => label1.Text = value;
        }
        public string Mssv
        {
            get => label2.Text; set => label2.Text = value;
        }
        public Image ImageMember
        {
            get => pictureBox1.BackgroundImage; set => pictureBox1.BackgroundImage = value;
        }
    }
}
