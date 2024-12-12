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
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            databaseDataContext db = new databaseDataContext();
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
            db.SubmitChanges();
            SendMail.SendMailTo(account.Email, rd.ToString());
            this.Hide();
            OTPForm oTPForm = new OTPForm(this, account.ID);
            oTPForm.ShowDialog();
            if(oTPForm.DialogResult == DialogResult.OK)
            {
                this.Show();
            }
            else
            {
                this.Close();
            }
        }

    }
}
