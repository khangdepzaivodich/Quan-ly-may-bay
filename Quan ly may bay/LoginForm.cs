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
            this.Close();
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
    }
}
