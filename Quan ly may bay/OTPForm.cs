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
    public partial class OTPForm : KryptonForm
    {
        private Form frm;
        public OTPForm(Form _frm)
        {
            InitializeComponent();
            frm = _frm;
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
    }
}
