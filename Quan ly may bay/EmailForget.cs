using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Quan_ly_may_bay.Base;

namespace Quan_ly_may_bay
{
    public partial class EmailForget : KryptonForm
    {
        public EmailForget()
        {
            InitializeComponent();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            databaseDataContext db = new databaseDataContext(Common.connectionString);
            Account account = db.Accounts.FirstOrDefault(p => p.Email == email);
            if (account == null)
            {
                MessageBox.Show("Không tìm thấy Email!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if(account.Active == 0)
            {
                MessageBox.Show("Tài khoản chưa được kích hoạt!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Random random = new Random();
            int rd = random.Next(100000, 999999);
            while(rd == account.OTP)
            {
                rd = random.Next(100000, 999999);
            }
            account.RandomKey = rd;
            account.OTPDateSend = DateTime.Now;
            SendMail.SendMailTo(account.Email,"Mã xác thực của bạn là " + rd.ToString());
            db.SubmitChanges();


            this.Hide();
            OTPForm oTPForm = new OTPForm(this, account.ID);
            oTPForm.ShowDialog();
            if(oTPForm.DialogResult == DialogResult.Cancel)
            {
                this.Show();
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

    }
}
