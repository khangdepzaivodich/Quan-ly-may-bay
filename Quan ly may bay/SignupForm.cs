using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Quan_ly_may_bay.Base;
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
            this.DialogResult = DialogResult.Cancel;
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
            if (UsernameTextBox.Text.Length == 0)
            {
                errUsername.SetError(UsernameTextBox, "Vui lòng nhập Username");
                check = false;
            }
            if (ConfirmPasswordTextBox.Text != PasswordTextBox.Text)
            {
                errConfirm.SetError(ConfirmPasswordTextBox, "Nhập đúng mật khẩu");

                check = false;
            }
            if (CCCDTextBox.Text.Length != 12)
            {
                errCCCD.SetError(CCCDTextBox, "Nhập đúng mã CCCD");
                check = false;
            }
            if (PhoneNumTextBox.Text.Length != 10)
            {
                errSDT.SetError(PhoneNumTextBox, "Nhập đúng số điện thoại");
                check = false;
            }
            if (EmailTextBox.Text.Trim().LastIndexOf("@gmail.com") == -1)
            {
                errEmail.SetError(EmailTextBox, "Nhập đúng định dạng email");

                check = false;
            }
            if (!check)
            {
                return;
            }
            databaseDataContext db = new databaseDataContext(Common.connectionString);
            Account newAccount = new Account();
            newAccount.Username = UsernameTextBox.Text;
            newAccount.Email = EmailTextBox.Text;
            newAccount.LevelID = 2;
            newAccount.DateCreated = DateTime.Now;
            newAccount.OTPDateSend = DateTime.Now;
            newAccount.Active = 0;
            
            if(db.Accounts.FirstOrDefault(p => p.Username == UsernameTextBox.Text) != null)
            {
                errUsername.SetError(UsernameTextBox, "Username đã tồn tại!");
                UsernameTextBox.Focus();
                return;
            }
            else if (db.Accounts.FirstOrDefault(p => p.Email == EmailTextBox.Text) != null)
            {
                errEmail.SetError(EmailTextBox, "Email đã được dùng!");
                EmailTextBox.Focus();
                return;
            }

            Random random = new Random();
            int rd = random.Next(100000, 999999);

            newAccount.OTP = newAccount.RandomKey = rd;
            newAccount.Password = Common.HashPassword(PasswordTextBox.Text + rd.ToString());
            db.Accounts.InsertOnSubmit(newAccount);
            db.SubmitChanges();

            KhachHang newKhachHang = new KhachHang();
            newKhachHang.MaKH = newAccount.ID;
            newKhachHang.HoTenKH = FullnameTextBox.Text;
            newKhachHang.NgaySinh = dPkDOB.Value;
            newKhachHang.DiaChi = DiaChiTextBox.Text;
            if (MaleRadioButton.Checked) newKhachHang.GioiTinh = "Nam";
            else newKhachHang.GioiTinh = "Nu";
            newKhachHang.SDT = PhoneNumTextBox.Text;
            newKhachHang.CCCD = CCCDTextBox.Text;
            db.KhachHangs.InsertOnSubmit(newKhachHang);
            db.SubmitChanges();

            SendMail.SendMailTo(newAccount.Email, "Mã xác thực của bạn là " + rd.ToString());
            this.Hide();
            OTPForm oTPForm = new OTPForm(this, newAccount.ID);
            oTPForm.ShowDialog();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
