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
    public partial class UC_Ticket : UserControl
    {
        public UC_Ticket()
        {
            InitializeComponent();
        }
        public Label time1
        {
            get => label1;
            set => label1 = value;
        }
        public Label date1
        {
            get => label7;
            set => label7 = value;
        }
        public Label from
        {
            get => label2; 
            set => label2 = value;
        }
        public Label time2
        {
            get => label3;
            set => label3 = value;
        }
        public Label date2
        {
            get => label8; 
            set => label8 = value;
        }
        public Label to
        {
            get => label4; 
            set => label4 = value;
        }
        public Label passengers
        {
            get => label9; 
            set => label9 = value;
        }
        public KryptonButton detailBtn
        {
            get => DetailBtn;
            set => DetailBtn = value;
        }
    }
}
