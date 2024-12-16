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
using Microsoft.Reporting.WinForms;
using Quan_ly_may_bay.Base;

namespace Quan_ly_may_bay
{
    public partial class ReportVeMayBay : KryptonForm
    {
        string mave;
        public ReportVeMayBay(string _mave)
        {
            InitializeComponent();
            mave = _mave;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReportChuyenBay_Load(object sender, EventArgs e)
        {
            databaseDataContext db = new databaseDataContext(Common.connectionString);
            Ve ve = db.Ves.FirstOrDefault(p => p.MaVe == mave);
            KhachHang kh = db.KhachHangs.FirstOrDefault(p => p.MaKH == ve.MaKH);
            ChuyenBay cb = db.ChuyenBays.FirstOrDefault(p => p.MaCB == ve.MaCB);
            LoTrinh lt = db.LoTrinhs.FirstOrDefault(p => p.MaLT == cb.MaLT);
            DateTime ngayKhoiHanh = cb.NgayKH.Value; // Ngày khởi hành
            TimeSpan gioCatCanh = lt.GioCatCanh.Value; // Giờ cất cánh
            TimeSpan gioHaCanh = lt.GioHaCanh.Value;   // Giờ hạ cánh
            DateTime ngaygicatcanh = ngayKhoiHanh + gioCatCanh;
            ReportParameter[] para = new ReportParameter[9];
            para[0] = new ReportParameter("hoten", kh.HoTenKH);
            para[1] = new ReportParameter("cccd", kh.CCCD);
            para[2] = new ReportParameter("sdt", kh.SDT);
            para[3] = new ReportParameter("chuyenbay",cb.MaCB);
            para[4] = new ReportParameter("from", lt.NoiXuatPhat);
            para[5] = new ReportParameter("to", lt.NoiDen);
            para[6] = new ReportParameter("thoigian", ngaygicatcanh.ToString("dd/MM/yyyy"));
            para[7] = new ReportParameter("soghe", ve.Seat);
            para[8] = new ReportParameter("hanhly", ve.HanhLy.ToString());
            this.reportViewer1.LocalReport.SetParameters(para);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.RefreshReport();
        }

    }
}
