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
using Quan_ly_may_bay.Base;
namespace Quan_ly_may_bay
{
    public partial class ChangePasswordForm : KryptonForm
    {
        private databaseDataContext db = new databaseDataContext(Common.connectionString);
        private int id;
        public ChangePasswordForm(int _id)
        {
            InitializeComponent();
            id = _id;
        }

        private void CloseLabel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            errConfirm.Clear();
            if (NewPassTextBox.Text != ConfirmNewPassTextBox.Text)
            {
                errConfirm.SetError(ConfirmNewPassTextBox, "Vui lòng nhập đúng mật khẩu mới!");
                return;
            }
            Account account = db.Accounts.FirstOrDefault(p => p.ID == id);
            if(account == null)
            {
                MessageBox.Show("Mật khẩu cũ không chính xác!","Warning",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            else
            {
                account.Password = Common.HashPassword(NewPassTextBox.Text + account.OTP);
                db.SubmitChanges();
                MessageBox.Show("Đổi mật khẩu thành công!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }
        }
    }
}
