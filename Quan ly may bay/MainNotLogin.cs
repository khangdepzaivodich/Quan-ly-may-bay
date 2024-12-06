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

namespace Quan_ly_may_bay
{
    public partial class MainNotLogin : Form
    {
        public MainNotLogin()
        {
            InitializeComponent();
        }

        private void MainNotLogin_Load(object sender, EventArgs e)
        {
            UC_MainNotLogin userControl1 = new UC_MainNotLogin();
            UC_MainNotLogin userControl2 = new UC_MainNotLogin();
            UC_MainNotLogin userControl3 = new UC_MainNotLogin();
            // Đặt vị trí cho mỗi UserControl
            userControl1.Location = new Point(245, 353);
            userControl2.Location = new Point(815, 361);
            userControl3.Location = new Point(1388, 364);

            // Thêm UserControl vào form
            this.Controls.Add(userControl1);
            this.Controls.Add(userControl2);
            this.Controls.Add(userControl3);
        }
    }
}
