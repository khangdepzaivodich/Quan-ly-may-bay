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
    public partial class SignupForm : KryptonForm
    {
        public SignupForm()
        {
            InitializeComponent();
        }

        private void CloseLabel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            bool check = true;
            errUsername.Clear();
            errConfirm.Clear();
            errCCCD.Clear();
            errSDT.Clear();
            errEmail.Clear();
            //if (UsernameTextBox.Text.Length == 0)
            //{
            //    errUsername.SetError(UsernameTextBox, "Vui lòng nhập Username");
            //    check = false;
            //}
            //if (ConfirmPasswordTextBox.Text != PasswordTextBox.Text)
            //{
            //    errConfirm.SetError(ConfirmPasswordTextBox, "Nhập đúng mật khẩu");

            //    check = false;
            //}
            //if (CCCDTextBox.Text.Length != 12)
            //{
            //    errCCCD.SetError(CCCDTextBox, "Nhập đúng mã CCCD");
            //    check = false;
            //}
            //if (PhoneNumTextBox.Text.Length != 10)
            //{
            //    errSDT.SetError(PhoneNumTextBox, "Nhập đúng số điện thoại");
            //    check = false;
            //}
            //if (EmailTextBox.Text.Trim().LastIndexOf("@gmail.com") == -1)
            //{
            //    errEmail.SetError(EmailTextBox, "Nhập đúng định dạng email");

            //    check = false;
            //}
            if (check)
            {
                this.Hide();
                OTPForm frm = new OTPForm(this);
                    frm.ShowDialog();
                this.Close();
            }
        }
    }
}
