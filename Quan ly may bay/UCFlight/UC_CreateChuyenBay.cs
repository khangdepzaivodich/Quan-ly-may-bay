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
    public partial class UC_CreateChuyenBay : UserControl
    {
        public UC_CreateChuyenBay()
        {
            InitializeComponent();
        }
        public Label maCB
        {
            get => MaCB;
            set => MaCB = value;   
        }
        public Label maLT
        {
            get => MaLT;
            set => MaLT = value;
        }
        public Label gioKhoiHanh
        {
            get => GioKhoiHanh;
            set => GioKhoiHanh = value;
        }
        public Label gioDen
        {
            get => GioDen;
            set => GioDen = value;
        }
        public Label noiKhoiHanh
        {
            get => NoiKhoiHanh;
            set => NoiKhoiHanh = value;
        }
        public Label noiDen
        {
            get => NoiDen;
            set => NoiDen = value;
        }

        public Label SoGhe
        {
            get => SoGheConLai;
            set => SoGheConLai = value;
        }

        private void XuatBtn_Click(object sender, EventArgs e)
        {
            ReportDSHK rp =new ReportDSHK(MaCB.Text, MaLT.Text, gioKhoiHanh.Text, noiKhoiHanh.Text, noiDen.Text);
            rp.Show();
        }
    }
}
