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
    public partial class EmailForget : KryptonForm
    {
        public EmailForget()
        {
            InitializeComponent();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            OTPForm oTPForm = new OTPForm(this);
            oTPForm.ShowDialog();
        }
    }
}
