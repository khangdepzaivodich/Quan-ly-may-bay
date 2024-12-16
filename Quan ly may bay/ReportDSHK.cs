using Microsoft.Reporting.WinForms;
using Quan_ly_may_bay.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Quan_ly_may_bay
{
    public partial class ReportDSHK : Form
    {
        string macb, malt, giokhoihanh, noidi, noiden;
        public ReportDSHK(string _macb, string _malt, string _giokhoihanh, string _noidi, string _noiden)
        {
            InitializeComponent();
            macb = _macb;
            malt = _malt;
            giokhoihanh = _giokhoihanh;
            noidi = _noidi;
            noiden = _noiden;
        }

        private void ReportDSHK_Load(object sender, EventArgs e)
        {
            databaseDataContext db = new databaseDataContext(Common.connectionString);

            // Lấy thông tin về mã máy bay từ chuyến bay
            string mamb = db.LoTrinhs.FirstOrDefault(p => p.MaLT == malt).MaMB;

            // Thiết lập tham số cho báo cáo
            ReportParameter[] para = new ReportParameter[5];
            para[0] = new ReportParameter("chuyenbay", macb);
            para[1] = new ReportParameter("loai", db.MayBays.FirstOrDefault(p => p.MaMB == mamb).TypeMB);
            para[2] = new ReportParameter("from", db.SanBays.First(p => p.City == noidi).TenSB);
            para[3] = new ReportParameter("to", db.SanBays.First(p => p.City == noiden).TenSB);
            para[4] = new ReportParameter("ngaygiokhoihanh", giokhoihanh);
            // Cập nhật tham số vào báo cáo
            this.reportViewer1.LocalReport.SetParameters(para);

            // Xóa các nguồn dữ liệu cũ
            this.reportViewer1.LocalReport.DataSources.Clear();
            var list =  from cb in db.ChuyenBays
                           join v in db.Ves on cb.MaCB equals v.MaCB
                           join k in db.KhachHangs on v.MaKH equals k.MaKH
                           where cb.MaCB == macb
                           select new Mydatabase
                           {
                               maVe = v.MaVe,
                               tenKH = k.HoTenKH,
                               Seat = v.Seat,
                           };
            ReportDataSource reportDataSource = new ReportDataSource("DataSet1",list.ToList());
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.RefreshReport();
        }
    }
}
