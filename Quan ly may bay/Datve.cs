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
    public partial class Datve : KryptonForm
    {
        public Datve()
        {
            InitializeComponent();
            for (int i = 0; i < 7; i++)
            {
                UC_Ticket uc = new UC_Ticket();
                PanelTicket.Controls.Add(uc);
            }
        }
    }
}
