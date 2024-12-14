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
            chartDoanhThu.Series.Clear();
        }

        private void btnFInd_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(txtNam.Text) || !int.TryParse(txtNam.Text, out int year))
            {
                MessageBox.Show("Vui lòng nhập năm hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Truy vấn doanh thu theo tháng
            var doanhThu = from cb in db.ChuyenBays
                           join v in db.Ves on cb.MaCB equals v.MaCB
                           where cb.NgayKH.HasValue && cb.NgayKH.Value.Year == year // Điều kiện lọc
                           group v by cb.NgayKH.Value.Month into g
                           select new
                           {
                               Thang = g.Key,
                               DoanhThu = g.Sum(v => v.Gia) // Tính doanh thu từ tổng giá vé
                           };

            // Kiểm tra dữ liệu kết quả
            if (!doanhThu.Any())
            {
                MessageBox.Show("Không có dữ liệu doanh thu cho năm được chọn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Xóa dữ liệu cũ
            chartDoanhThu.Series.Clear();

            // Thêm series mới
            var series = chartDoanhThu.Series.Add("Doanh Thu");
            series.ChartType = SeriesChartType.Column;

            // Thêm dữ liệu vào biểu đồ
            foreach (var item in doanhThu.OrderBy(d => d.Thang))
            {
                series.Points.AddXY($"Tháng {item.Thang}", item.DoanhThu);
            }

            // Cài đặt biểu đồ
            chartDoanhThu.ChartAreas[0].AxisX.Title = "Tháng";
            chartDoanhThu.ChartAreas[0].AxisY.Title = "Doanh thu (VND)";

            // Đảm bảo chỉ thêm một legend
            if (!chartDoanhThu.Legends.Any(legend => legend.Name == "Legend"))
            {
                chartDoanhThu.Legends.Add("Legend");
            }
        }

    }
}
