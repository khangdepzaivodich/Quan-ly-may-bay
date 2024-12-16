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
using Quan_ly_may_bay.Base;

namespace Quan_ly_may_bay
{
    public partial class ThongkeTaichinh : Form
    {
        private databaseDataContext db = new databaseDataContext(Common.connectionString);
        public ThongkeTaichinh()
        {
            InitializeComponent();
            chart1.Series.Clear();
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
            var soVe = from cb in db.ChuyenBays
                          join v in db.Ves on cb.MaCB equals v.MaCB
                          where cb.NgayKH.HasValue && cb.NgayKH.Value.Year == year // Điều kiện lọc
                          group v by cb.NgayKH.Value.Month into g
                          select new
                          {
                              Thang = g.Key,
                              Ve = g.Count() // Tính doanh thu từ tổng giá vé
                           };
            var soChuyenbay = from cb in db.ChuyenBays
                       where cb.NgayKH.HasValue && cb.NgayKH.Value.Year == year // Điều kiện lọc
                       group cb by cb.NgayKH.Value.Month into g
                       select new
                       {
                           Thang = g.Key,
                           ChuyenBay = g.Count() // Tính doanh thu từ tổng giá vé
                       };
            // Kiểm tra dữ liệu kết quả
            if (!doanhThu.Any())
            {
                MessageBox.Show("Không có dữ liệu doanh thu cho năm được chọn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Xóa dữ liệu cũ
            chart1.Series.Clear();

            // Thêm series mới

            var series = new Series();

            List<int> thang = new List<int>(new int[12]);
            if(cbbTieuChi.Text == "Số lượng khách")
            {
                series = chart1.Series.Add("Số lượng khách");
                series.Color = Color.Blue;
                foreach (var item in soVe.OrderBy(d => d.Thang))
                {
                    thang[item.Thang - 1] = (int)(item.Ve);
                }
                chart1.ChartAreas[0].AxisY.Title = "Số khách (Vé)";
            }
            else if (cbbTieuChi.Text == "Số lượng chuyến bay")
            {
                series = chart1.Series.Add("Số lượng chuyến bay");
                series.Color = Color.Green;
                foreach (var item in soChuyenbay.OrderBy(d => d.Thang))
                {
                    thang[item.Thang - 1] = (int)(item.ChuyenBay);
                }
                chart1.ChartAreas[0].AxisY.Title = "Chuyến bay(chuyến)";
            }
            else
            {
                series = chart1.Series.Add("Doanh Thu");
                series.Color = Color.Green;
                foreach (var item in doanhThu.OrderBy(d => d.Thang))
                {
                    thang[item.Thang - 1] = (int)(item.DoanhThu);
                }
                chart1.ChartAreas[0].AxisY.Title = "Doanh thu (VND)";
            }
            // Kiểm tra loại biểu đồ
            if (cbbMaCV.Text == "Biểu đồ đường")
                series.ChartType = SeriesChartType.Line;
            else if (cbbMaCV.Text == "Biểu đồ tròn")
                series.ChartType = SeriesChartType.Pie;
            else series.ChartType = SeriesChartType.Column;
            // Thêm dữ liệu vào biểu đồ
            for (int i = 0; i < 12; i++)
            {
                series.Points.AddXY($"Tháng {i + 1}", thang[i]);
            }

            // Cập nhật giới hạn trục Y
            var maxYValue = thang.Max(); // Tìm giá trị lớn nhất
            var minYValue = thang.Min(); // Tìm giá trị nhỏ nhất

            chart1.ChartAreas[0].AxisY.Minimum = minYValue > 0 ? 0 : minYValue * 1.1; // Mở rộng nếu nhỏ hơn 0
            chart1.ChartAreas[0].AxisY.Maximum = maxYValue * 1.1; // Mở rộng 10% cho đẹp hơn

            // Cài đặt khác cho trục Y
            chart1.ChartAreas[0].AxisY.Interval = maxYValue / 5; // Chia khoảng
            chart1.ChartAreas[0].AxisY.LabelStyle.Format = "#,0"; // Định dạng số hàng nghìn

            // Cài đặt biểu đồ
            series.IsValueShownAsLabel = true; // Hiển thị giá trị trên cột
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisX.Title = "Tháng";
            chart1.ChartAreas[0].AxisX.Interval = 1;

            // Đảm bảo chỉ thêm một legend
            if (!chart1.Legends.Any(legend => legend.Name == "Legend"))
            {
                chart1.Legends.Add("Legend");
            }
        }


    }
}
