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
using Quan_ly_may_bay.Base;
namespace Quan_ly_may_bay
{
    public partial class OTPForm : KryptonForm
    {
        private Form frm;
        private int id;
        databaseDataContext db = new databaseDataContext(Common.connectionString);
        Account account;
        public OTPForm(Form _frm, int _id)
        {
            InitializeComponent();
            frm = _frm;
            id = _id;
            account = db.Accounts.FirstOrDefault(p => p.ID == id);
        }
        private void CloseLabel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            ///Kiem tra cac richtextbox co o trong ko
            foreach(KryptonRichTextBox textBox in this.Controls.OfType<KryptonRichTextBox>())
            {
                if(textBox.Text == "")
                {
                    MessageBox.Show("Vui Lòng nhập mã OTP!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            ///Chuoi OTP nguoi dung nhap
            string userOTP = kryptonRichTextBox1.Text + kryptonRichTextBox2.Text + kryptonRichTextBox3.Text + kryptonRichTextBox4.Text
                + kryptonRichTextBox5.Text + kryptonRichTextBox6.Text;

            ///Xuly ngoai le ve ma OTP
            TimeSpan timeDifference = (TimeSpan)(DateTime.Now - account.OTPDateSend);
            int secondsDifference = (int)timeDifference.TotalSeconds;
            if (secondsDifference > 200)
            {
                MessageBox.Show("Mã OTP không còn hiệu lực!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                foreach (KryptonRichTextBox textBox in this.Controls.OfType<KryptonRichTextBox>())
                {
                    textBox.Text = "";
                }
                return;
            }

            if (int.Parse(userOTP) != account.RandomKey)
            {
                MessageBox.Show("Mã OTP không chính xác", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                foreach (KryptonRichTextBox textBox in this.Controls.OfType<KryptonRichTextBox>())
                {
                    textBox.Text = "";
                }
                return;
            }

            MessageBox.Show("Xác nhận thành công!", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ////Phan quyen form sau OTP
            if (frm is SignupForm)
            {
                account.DateActive = DateTime.Now;
                account.OTP = account.RandomKey;
                account.Active = 1;
                db.SubmitChanges();
                MainNotLogin mainLogin = new MainNotLogin();
                mainLogin.ShowDialog();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else if (frm is LoginForm)
            {
                if(account.Active == 0) account.DateActive = DateTime.Now;
                account.RandomKey = account.OTP;
                account.Active = 1;
                db.SubmitChanges();
                MainNotLogin mainLogin = new MainNotLogin();
                mainLogin.ShowDialog();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                account.OTP = account.RandomKey;
                db.SubmitChanges();
                ResetPassForm resetPassForm = new ResetPassForm(account.ID);
                resetPassForm.ShowDialog();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ///Text box thoi gian con hieu luc ko
            TimeSpan timeDifference = (TimeSpan)(DateTime.Now - account.OTPDateSend);
            int secondsDifference = (int)timeDifference.TotalSeconds;
            if (60 - secondsDifference >= 0)
            {
                label2.Text = $"OTP code is valid for {60 - secondsDifference} seconds";
            }
        }

        private void ResendButton_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int rd = random.Next(100000, 999999);
            while(rd == account.OTP)
            {
                rd = random.Next(100000, 999999);
            }
            account.RandomKey = rd;
            SendMail.SendMailTo(account.Email, "Mã xác thực của bạn là " + rd.ToString());
            account.OTPDateSend = DateTime.Now;
            db.SubmitChanges();

            ///Xóa toàn bộ OTP nguoi dung nhap
            foreach (KryptonRichTextBox textBox in this.Controls.OfType<KryptonRichTextBox>())
            {
                textBox.Text = "";
            }
        }

        private void kryptonRichTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            ///Kiem tra richtextbox nhap vao la phai la so va xu ly hieu ung chuyen
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            KryptonRichTextBox currentTextBox = sender as KryptonRichTextBox;
            Control parent = currentTextBox.Parent;
            int currentIndex = parent.Controls.GetChildIndex(currentTextBox);
            if (currentIndex - 1 >= 0)
            {
                Control nextControl = parent.Controls[currentIndex - 1];
                if (nextControl is KryptonRichTextBox nextTextBox)
                {
                    nextTextBox.Focus();
                }
            }
        }
    }
}
