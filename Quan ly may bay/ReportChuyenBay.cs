using System;
using System.Windows.Forms;

namespace Quan_ly_may_bay
{
    public partial class ReportChuyenBay : Form
    {
        public ReportChuyenBay()
        {
            InitializeComponent();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
            this.reportViewer2.RefreshReport();
        }
    }
}
