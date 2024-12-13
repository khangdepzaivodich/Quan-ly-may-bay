using Microsoft.Reporting.WinForms;
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
    public partial class ReportDSNV : Form
    {
        string nguoiin;
        int soluong;
        public ReportDSNV(string _nguoiin, int _soluong)
        {
            InitializeComponent();
            nguoiin = _nguoiin;
            soluong = _soluong;
        }

        private void ReportDSNV_Load(object sender, EventArgs e)
        {
            databaseDataContext db = new databaseDataContext();
            ReportParameter[] para = new ReportParameter[2];
            para[0] = new ReportParameter("nguoiin", nguoiin);
            //para[1] = new ReportParameter("soluong", db.N)
            this.reportViewer1.RefreshReport();
        }
    }
}
