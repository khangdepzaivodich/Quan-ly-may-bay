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
            this.Close();
        }

        private void lblForget_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmailForget emailForget = new EmailForget();
            emailForget.ShowDialog();
        }

        private void lblSignup_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
                SignupForm signupForm = new SignupForm();
                signupForm.ShowDialog();
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


            databaseDataContext db = new databaseDataContext();
            Account account = db.Accounts.FirstOrDefault(p => p.Username == UsernameTextBox.Text);
            if (account == null)
            {
                MessageBox.Show("Username không tồn tại!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            // Nếu mật khẩu hợp lệ, thực hiện các thao tác tiếp theo
            MessageBox.Show("Đăng nhập thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
            MainLogin frm = new MainLogin(account);
            frm.ShowDialog();
        }
    }
}
