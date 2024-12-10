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
    public partial class UC_btnMainForm : UserControl
    {
        public UC_btnMainForm()
        {
            InitializeComponent();
        }
        public Label lbl
        {
            get => TextButton;
            set => TextButton = value;

        }
        public Color ColorBtn
        {
            get => TextButton.BackColor;
            set => TextButton.BackColor = value;
        }
    }
}
