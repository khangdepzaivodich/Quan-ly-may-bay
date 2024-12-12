using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
namespace Quan_ly_may_bay
{
    public partial class OTPForm : KryptonForm
    {
        private Form frm;
        private Account account;
        int seconds = DateTime.Now.Second;
        public OTPForm(Form _frm)
        {
            InitializeComponent();
            ResendButton.Enabled = false;
            frm = _frm;
        }
        public OTPForm(Form _frm, Account _account)
        {
            InitializeComponent();
            ResendButton.Enabled = false;
            frm = _frm;
            account = _account;
        }
        private void CloseLabel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (frm is SignupForm)
            {
                MainNotLogin mainLogin = new MainNotLogin();
                mainLogin.ShowDialog();
            }
            else
            {
                ResetPassForm resetPassForm = new ResetPassForm();
                resetPassForm.ShowDialog();
            }
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(seconds <= 0)
            {
                SubmitButton.Enabled = false;
                ResendButton.Enabled = true;
                timer1.Stop();
            }
            seconds -= 1;
        }

        private void ResendButton_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int rd = random.Next(100000, 999999);
            while(rd == account.OTP)
            {
                rd = random.Next(100000, 999999);
            }
            account.OTP = account.RandomKey = rd;
            SendMail.SendMailTo(account.Email, rd.ToString());
            seconds = DateTime.Now.Second;
            timer1.Start();
            ResendButton.Enabled = false;
        }
    }
}
