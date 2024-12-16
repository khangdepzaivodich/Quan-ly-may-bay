using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using ComponentFactory.Krypton.Toolkit;
using Quan_ly_may_bay.Base;
namespace Quan_ly_may_bay
{
    public partial class LoginForm : KryptonForm
    {
        public LoginForm()
        {
            InitializeComponent();
        }
       

        private void CloseLabel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void lblForget_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmailForget emailForget = new EmailForget();
            emailForget.ShowDialog();
            if (emailForget.DialogResult == DialogResult.Cancel)
            {
                this.Show();
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void lblSignup_Click(object sender, EventArgs e)
        {
            this.Hide();
                SignupForm signupForm = new SignupForm();
                signupForm.ShowDialog();
            if (signupForm.DialogResult == DialogResult.Cancel)
            {
                this.Show();
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void labelHover(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.ForeColor = Color.Blue;
        }

        private void labelLeft(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.ForeColor = Color.Black;
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            bool check = true;
            errPassword.Clear();
            errUsername.Clear();
            if(UsernameTextBox.Text.Length == 0)
            {
                check = false;
                errUsername.SetError(UsernameTextBox, "Vui lòng nhập username!");
            }
            if(PasswordTextBox.Text.Length == 0)
            {
                check = false;
                errPassword.SetError(PasswordTextBox, "Vui lòng nhập mật khẩu!");
            }
            if (!check) return;


            databaseDataContext db = new databaseDataContext(Common.connectionString);
            Account account = db.Accounts.FirstOrDefault(p => p.Username == UsernameTextBox.Text);
            if (account == null)
            {
                MessageBox.Show("Username không tồn tại!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UsernameTextBox.Focus();
                return;
            }
            if(account.Active == 0)
            {
                MessageBox.Show("Tài khoản chưa được kích hoạt! Nhấn OK để gửi mã OTP để kích hoạt", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Random random = new Random();
                int rd = random.Next(100000, 999999);
                while (rd == account.OTP)
                {
                    rd = random.Next(100000, 999999);
                }
                account.RandomKey = rd;
                account.OTPDateSend = DateTime.Now;
                SendMail.SendMailTo(account.Email, "Mã xác thực của bạn là " + rd.ToString());
                db.SubmitChanges();
                this.Hide();
                OTPForm oTPForm = new OTPForm(this, account.ID);
                oTPForm.ShowDialog();
                if (oTPForm.DialogResult == DialogResult.Cancel)
                {
                    this.Show();
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                return;
            }
            string str = PasswordTextBox.Text + account.OTP;
            byte[] hashedPassword = Common.HashPassword(str);
            byte[] dbPasswordBytes = account.Password.ToArray();
            if (!dbPasswordBytes.SequenceEqual(hashedPassword))
            {
                MessageBox.Show("Mật khẩu sai!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (account.Active == 1 && account.RandomKey != account.OTP)
            {
                MessageBox.Show("Tài khoản cần xác nhận lại mã OTP", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Random random = new Random();
                int rd = random.Next(100000, 999999);
                while (rd == account.OTP)
                {
                    rd = random.Next(100000, 999999);
                }
                account.RandomKey = rd;
                account.OTPDateSend = DateTime.Now;
                SendMail.SendMailTo(account.Email, "Mã xác thực của bạn là " + rd.ToString());
                db.SubmitChanges();
                this.Hide();
                OTPForm oTPForm = new OTPForm(this, account.ID);
                oTPForm.ShowDialog();
                if (oTPForm.DialogResult == DialogResult.Cancel)
                {
                    this.Show();
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                return;
            }
            // Nếu mật khẩu hợp lệ, thực hiện các thao tác tiếp theo
            MessageBox.Show("Đăng nhập thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
                this.DialogResult = DialogResult.OK;
                this.Close();
            MainLogin frm = new MainLogin(account.ID);
            frm.ShowDialog();
        }
    }
}
