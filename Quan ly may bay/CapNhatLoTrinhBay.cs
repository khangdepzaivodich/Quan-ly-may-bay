using Quan_ly_may_bay.UCFlight;
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
    public partial class CapNhatLoTrinhBay : Form
    {
        private List<UC_CreateLoTrinhBay> list = new List<UC_CreateLoTrinhBay>();
        public CapNhatLoTrinhBay()
        {
            InitializeComponent();
            for (int i = 0; i < 5; i++)
            {
                UC_CreateLoTrinhBay uc = new UC_CreateLoTrinhBay();
                list.Add(uc);
            }
            for (int i = 0; i < list.Count; i++)
            {
                PanelTicket.Controls.Add(list[i]);
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < list.Count; i++)
            {
                PanelTicket.Controls.Remove(list[i]);
            }
            list.Clear();
        }

        private void pAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
