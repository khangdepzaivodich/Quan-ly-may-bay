using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_ly_may_bay
{
    public partial class MainLogin : Form
    {
        
        public MainLogin()
        {
            InitializeComponent();
        }
        private void label2_Click(object sender, EventArgs e)
        {
            foreach(Label label in panel3.Controls)
            {
                if(label == sender)
                {
                    label.BackColor = Color.FromArgb(200, 0, 0, 0);
                }
                else
                {
                    label.BackColor = Color.Transparent;
                }
            }
        }
    }
}
