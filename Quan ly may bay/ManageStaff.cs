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
    public partial class ManageStaff : KryptonForm
    {
        public ManageStaff()
        {
            InitializeComponent();
            databaseDataContext db = new databaseDataContext();
            var nv = db.NhanViens.Where(p => p.MaCV != "QLNS").ToList();
            foreach(var list in nv)
            {

            }
            UC_Staff uc = new UC_Staff();
            pnlContain.Controls.Add(uc);
            uc = new UC_Staff();
            pnlContain.Controls.Add(uc);
            uc = new UC_Staff();
            pnlContain.Controls.Add(uc);

        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddStaff frm = new AddStaff();
            frm.ShowDialog();
            this.Show();
        }
    }
}
