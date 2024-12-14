using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Quan_ly_may_bay
{
    public partial class ThongkeTaichinh : Form
    {
        private databaseDataContext db = new databaseDataContext();
        public ThongkeTaichinh()
        {
            InitializeComponent();
            chart1.Series.Clear();
        }

        private void btnFInd_Click(object sender, EventArgs e)
        {
            //var chuyenBayVe = from cb in db.ChuyenBays
            //                  join v in db.Ves on cb.MaCB equals v.MaCB
            //                  group cb by new {cb.NgayKH.Month, int.Parse(txtTenN.Text) } into  g
            //                  select new
            //                  {
            //                      cb.MaCB,
            //                      cb.GioCatCanh,
            //                      v.MaVe,
            //                      v.NgayDatVe,
            //                      v.GiaVe
            //                  };
        }
    }
}
