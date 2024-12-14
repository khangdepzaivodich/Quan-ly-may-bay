using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
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
    public partial class PQ : Form
    {
        private databaseDataContext db = new databaseDataContext();
        public PQ()

        {
            InitializeComponent();
            datas.DataSource = db.PhanQuyens.Select(p => new { p.PQ,p.ViewTicket, p.FlightItinerary, p.CreateFlight, p.ManageStaff }).ToList();
        }

        private void data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 1 && e.ColumnIndex <= 4) // Kiểm tra cột [1-4]
            {
                string pqValue = datas.Rows[e.RowIndex].Cells[0].Value?.ToString(); // Lấy mã PQ
                if (!string.IsNullOrEmpty(pqValue))
                {
                    PhanQuyen p = db.PhanQuyens.FirstOrDefault(k => k.PQ == pqValue);
                    if (p != null)
                    {
                        // Cập nhật giá trị theo cột được click
                        if (e.ColumnIndex == 1) p.ViewTicket = p.ViewTicket == 1 ? 0 : 1;
                        else if (e.ColumnIndex == 2) p.FlightItinerary = p.FlightItinerary == 1 ? 0 : 1;
                        else if (e.ColumnIndex == 3) p.CreateFlight = p.CreateFlight == 1 ? 0 : 1;
                        else if (e.ColumnIndex == 4) p.ManageStaff = p.ManageStaff == 1 ? 0 : 1;

                        // Lưu thay đổi vào database
                        db.SubmitChanges();

                        // Cập nhật lại DataGridView
                        datas.DataSource = db.PhanQuyens.Select(m => new
                        {
                            m.PQ,
                            m.ViewTicket,
                            m.FlightItinerary,
                            m.CreateFlight,
                            m.ManageStaff
                        }).ToList();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy bản ghi phù hợp để cập nhật.", "Thông báo");
                    }
                }
                else
                {
                    MessageBox.Show("Giá trị cột đầu tiên không hợp lệ.", "Thông báo");
                }
            }
        }

    }
}
