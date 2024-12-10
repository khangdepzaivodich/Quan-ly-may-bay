using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Quan_ly_may_bay.UCFlight;

namespace Quan_ly_may_bay
{
    public partial class Capnhatchuyenbay : KryptonForm
    {
        private List<UC_CreateChuyenBay> list = new List<UC_CreateChuyenBay>();
        public Capnhatchuyenbay()
        {
            InitializeComponent();
            for (int i = 0; i < 3; i++)
            {
                UC_CreateChuyenBay uc = new UC_CreateChuyenBay();
                list.Add(uc);
            }
            for (int i = 0; i < list.Count; i++)
            {
                PanelTicket.Controls.Add(list[i]);
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (list.Count < 6)
            {
                TaoChuyenBay frm = new TaoChuyenBay();
                frm.ShowDialog();
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
    }
}
