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
using Quan_ly_may_bay.Base;

namespace Quan_ly_may_bay
{
    public partial class PQ : Form
    {
        private databaseDataContext db = new databaseDataContext(Common.connectionString);
        public PQ()

        {
            InitializeComponent();
            datas.DataSource = db.PhanQuyens.Select(p => new { p.PQ,p.ViewTicket, p.FlightItinerary, p.CreateFlight, p.ManageStaff,p.FinancialStatistics }).ToList();
        }

        private void data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string pqValue = "";
            if (e.RowIndex == 0) pqValue = "GDDH";
            else if (e.RowIndex == 1) pqValue = "NVCB";
            else if (e.RowIndex == 2) pqValue = "QLNS";
            if(pqValue != "")
            {
                PhanQuyen p = db.PhanQuyens.FirstOrDefault(k => k.PQ == pqValue);
                // Cập nhật giá trị theo cột được click
                if (e.ColumnIndex == 1) p.ViewTicket = p.ViewTicket == 1 ? 0 : 1;
                else if (e.ColumnIndex == 2) p.FlightItinerary = p.FlightItinerary == 1 ? 0 : 1;
                else if (e.ColumnIndex == 3) p.CreateFlight = p.CreateFlight == 1 ? 0 : 1;
                else if (e.ColumnIndex == 4) p.ManageStaff = p.ManageStaff == 1 ? 0 : 1;
                else if (e.ColumnIndex == 5) p.FinancialStatistics = p.FinancialStatistics == 1 ? 0 : 1;
                // Lưu thay đổi vào database
                db.SubmitChanges();
                datas.DataSource = db.PhanQuyens.Select(m => new
                {
                    m.PQ,
                    m.ViewTicket,
                    m.FlightItinerary,
                    m.CreateFlight,
                    m.ManageStaff,
                    m.FinancialStatistics,
                }).ToList();
            }

        }

    }
}
