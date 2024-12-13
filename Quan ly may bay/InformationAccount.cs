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
    public partial class InformationAccount : KryptonForm
    {
        private databaseDataContext db = new databaseDataContext();
        private Account account;
        public InformationAccount(int id)
        {
            InitializeComponent();
            account = db.Accounts.FirstOrDefault(x => x.ID == id);
            lblUsername.Text = "Username: " + account.Username;
            lblGmail.Text = "Gmail: " + account.Username;
            btnSubmit.Text = "Edit";
        }
        private bool check = true;
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (check) btnSubmit.Text = "Submit";
            else btnSubmit.Text = "Edit";
            check = !check;
        }
    }
}
