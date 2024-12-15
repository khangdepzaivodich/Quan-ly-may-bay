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

namespace Quan_ly_may_bay
{
    public partial class ReportChuyenBay : KryptonForm
    {
        string mave;
        public ReportChuyenBay
        (   
            string _hoten, string _cccd, string _phoneNum, string _maCB, string _from, string _to,
            string _time1, string _seat, int _hanhLy, string _mave
        )
        {
            InitializeComponent();
            mave = _mave;
            nameLabel.Text = _hoten;
            CCCDLabel.Text = _cccd;
            phoneNumLabel.Text = _phoneNum;
            maCB.Text = _maCB;
            from.Text = _from;
            to.Text = _to;
            time1.Text = _time1;    
            seat.Text = _seat;
            hanhLy.Text = _hanhLy.ToString() + "kg";
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Submitbtn_Click(object sender, EventArgs e)
        {
            ReportVeMayBay report = new ReportVeMayBay(mave);
            report.Show();
            this.Close();
        }
    }
}
