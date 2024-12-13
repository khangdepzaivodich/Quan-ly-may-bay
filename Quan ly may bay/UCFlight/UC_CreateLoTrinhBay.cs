using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_ly_may_bay.UCFlight
{
    public partial class UC_CreateLoTrinhBay : UserControl
    {
        public UC_CreateLoTrinhBay()
        {
            InitializeComponent();
        }
        public KryptonButton kf
        {
            get => kryptonButton1;
            set => kryptonButton1 = value;
        }
        public Label GioCC
        {
            get => giocc;
            set => giocc = value;
        }
        public Label GioHC
        {
            get => giohc;
            set => giohc = value;
        }

        public Label NoiDi
        {
            get => noidi; 
            set => noidi = value;
        }
        public Label NoiDen
        {
            get => noiden;
            set => noiden = value;
        }
        public Label Gia
        {
            get => gia;
            set => gia = value;
        }
    }
}
