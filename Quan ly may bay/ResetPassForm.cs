using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quan_ly_may_bay.Base;
using ComponentFactory.Krypton.Toolkit;
namespace Quan_ly_may_bay
{
    public partial class ResetPassForm : KryptonForm
    {
        Account account;
        databaseDataContext db = new databaseDataContext(Common.connectionString);
        int id;
        public ResetPassForm(int _id)
        {
            InitializeComponent();
            id = _id;
            account = db.Accounts.FirstOrDefault(p => p.ID == id);
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            PasswordError.Clear();
            ConfirmPasswordError.Clear();
            if(PasswordTexBox.Text == "")
            {
                PasswordError.SetError(PasswordTexBox, "Mật khẩu không được để trống");
                return;
            }
            if(ConfirmPassTextBox.Text != PasswordTexBox.Text)
            {
                ConfirmPasswordError.SetError(ConfirmPassTextBox, "Hãy nhập đúng mật khẩu");
                return;
            }
            string pass = PasswordTexBox.Text + account.OTP; 
            account.Password = Common.HashPassword(pass);
            db.SubmitChanges();
            MainNotLogin frm = new MainNotLogin();
            frm.ShowDialog();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
