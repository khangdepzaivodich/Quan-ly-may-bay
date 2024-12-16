using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq.Mapping;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quan_ly_may_bay.Base;

namespace Quan_ly_may_bay
{
    public partial class ReportDSNV : Form
    {
        int IDnguoiin;

        int manv;
        string tennv, macv;
        int luong;

        public ReportDSNV(int _IDnguoiin, int _manv, string _tennv, string _macv, int _luong)
        {
            InitializeComponent();
            IDnguoiin = _IDnguoiin;
            manv = _manv;
            tennv = _tennv;
            macv = _macv;
            luong = _luong;
        }

        private void ReportDSNV_Load(object sender, EventArgs e)
        {
            databaseDataContext db = new databaseDataContext(Common.connectionString);
            ReportParameter[] para = new ReportParameter[2];

            // Lấy thông tin người in
            para[0] = new ReportParameter("nguoiin", db.Accounts
                                        .FirstOrDefault(p => p.ID == IDnguoiin).Username);
                                     

            IQueryable<NhanVien> query = db.NhanViens;

            if (manv==-1&&tennv==""&&macv==""&&luong==-1)
            {
                MessageBox.Show("hah");

                // Không có điều kiện tìm kiếm
                para[1] = new ReportParameter("soluong", query.Count().ToString());
                AddReportDataSource(query.OrderBy(p => p.MaNV), para);
            }
            else
            {
                // Lọc dữ liệu dựa trên các điều kiện
                if (manv != -1)
                {
                    query = query.Where(p => p.MaNV == manv);
                }
                else
                {
                    if (!string.IsNullOrEmpty(tennv))
                    {
                        query = query.Where(p => p.HoTenNV == tennv);
                    }

                    if (!string.IsNullOrEmpty(macv))
                    {
                        query = query.Where(p => p.MaCV == macv);
                    }

                    if (luong != -1)
                    {
                        query = query.Where(p => p.Luong >= luong);
                    }
                }

                // Đếm số lượng nhân viên sau khi áp dụng điều kiện
                para[1] = new ReportParameter("soluong", query.Count().ToString());
                AddReportDataSource(query, para);
            }

            // Làm mới báo cáo
            this.reportViewer1.RefreshReport();
        }

        private void AddReportDataSource(IQueryable<NhanVien> query, ReportParameter[] para)
        {
            this.reportViewer1.LocalReport.SetParameters(para);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", query.ToList()));
        }

    }
}
