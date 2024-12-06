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
    public partial class UCInfo1 : UserControl
    {
        public UCInfo1()
        {
            InitializeComponent();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            ReportChuyenBay reportChuyenBay = new ReportChuyenBay();
            reportChuyenBay.ShowDialog();
        }
    }
}
