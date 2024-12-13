﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_ly_may_bay.UCFlight
{
    public partial class UC_Staff : UserControl
    {
        public UC_Staff()
        {
            InitializeComponent();
        }
        public int MaNV
        {
            get => int.Parse(lblMaNV.Text);
            set => lblMaNV.Text = value.ToString();
        }

        public string TenNV
        {
            get => lblTenNV.Text;
            set => lblTenNV.Text = value;
        }

        public string MaCV
        {
            get => lblMaCV.Text;
            set => lblMaCV.Text = value;
        }

        public string Luong
        {
            get => lblLuong.Text;
            set => lblLuong.Text = value;
        }
    }
}
