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

namespace Quan_ly_may_bay.UCFlight
{
    public partial class UCInfo1 : UserControl
    {
        string mave;
        public UCInfo1()
        {
            InitializeComponent();
        }

        public Label Level
        {
            get => label1;
            set => label1 = value;
        }
        public Label Date1
        {
            get => label2; 
            set => label2 = value;
        }
        public Label From
        {
            get => label6;
            set => label6 = value;
        }
        public Label Date2
        {
            get => label4;
            set => label4 = value;
        }
        public Label To
        {
            get => label7; 
            set => label7 = value;
        }

        public string MaVe
        {
            get => mave;
            set => mave = value;
        }

        public KryptonButton WatchBtn
        {
            get => XemBtn;
            set => XemBtn = value;
        }
    
    }
}
