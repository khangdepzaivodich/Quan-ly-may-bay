﻿using Quan_ly_may_bay.UCFlight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_ly_may_bay
{
    public partial class BookedTicket : Form
    {
        private List<UCInfo1> list = new List<UCInfo1>();
        public BookedTicket()
        {
            InitializeComponent();
            for (int i = 0; i < 16; i++)
            {
                UCInfo1 uc = new UCInfo1();
                list.Add(uc);
            }
            for (int i = 5 * int.Parse(lblStt.Text); i < 5 * int.Parse(lblStt.Text) + 5; i++)
            {
                if (i >= list.Count)
                {
                    Add.Enabled = false;
                    break;
                }
                PanelTicket.Controls.Add(list[i]);
            }
        }

        private void lblStt_TextChanged(object sender, EventArgs e)
        {
            for (int i = 5 * int.Parse(lblStt.Text); i < 5 * int.Parse(lblStt.Text) + 5; i++)
            {
                if (i >= list.Count)
                {
                    Add.Enabled = false;
                    break;
                }
                PanelTicket.Controls.Add(list[i]);
            }
        }

        private void Substract_Click(object sender, EventArgs e)
        {
            for (int i = 5 * int.Parse(lblStt.Text); i < 5 * int.Parse(lblStt.Text) + 5; i++)
            {
                if (i >= list.Count)
                {
                    Add.Enabled = false;
                    break;
                }
                PanelTicket.Controls.Remove(list[i]);
            }

            lblStt.Text = (int.Parse(lblStt.Text) - 1).ToString();
            if (int.Parse(lblStt.Text) == 0)
            {
                Substract.Enabled = false;
            }
            Add.Enabled = true;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            for (int i = 5 * int.Parse(lblStt.Text); i < 5 * int.Parse(lblStt.Text) + 5; i++)
            {
                if (i >= list.Count)
                {
                    Add.Enabled = false;
                    break;
                }
                PanelTicket.Controls.Remove(list[i]);
            }
            lblStt.Text = (int.Parse(lblStt.Text) + 1).ToString();
            Substract.Enabled = true;
        }
    }
}
