﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Quan_ly_may_bay.UCFlight;

namespace Quan_ly_may_bay
{
    public partial class ManageStaff : KryptonForm
    {
        public ManageStaff()
        {
            InitializeComponent();
            UC_Staff uc = new UC_Staff();
            pnlContain.Controls.Add(uc);
            
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}