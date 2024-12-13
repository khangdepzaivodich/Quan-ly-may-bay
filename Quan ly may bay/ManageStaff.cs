using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Quan_ly_may_bay.UCFlight;

namespace Quan_ly_may_bay
{
    public partial class ManageStaff : KryptonForm
    {
        databaseDataContext db = new databaseDataContext();
        List<NhanVien> nv;
        int soluong;
        public ManageStaff()
        {
            InitializeComponent();
            lblSubstract.Hide();
            loadDuLieu();
        }

        public void loadDuLieu()
        {
            flpContain.Controls.Clear();
            nv = db.NhanViens.OrderByDescending(p => p.MaNV).ToList();
            soluong = nv.Count();
            if (soluong <= 5) lblAdd.Hide();
            for (int i = 5 * int.Parse(lblStt.Text); i < 5 * int.Parse(lblStt.Text) + 5; i++)
            {
                if (i >= soluong)
                {
                    lblAdd.Hide();
                    break;
                }
                UC_Staff uc = new UC_Staff();
                uc.MaNV = nv[i].MaNV;
                uc.TenNV = nv[i].HoTenNV;
                uc.MaCV = nv[i].MaCV;
                uc.Luong = nv[i].Luong.ToString() + " VND";
                flpContain.Controls.Add(uc);
            }
        }

        private void lblSubstract_Click(object sender, EventArgs e)
        {
            lblAdd.Show();
            flpContain.Controls.Clear();
            lblStt.Text = (int.Parse(lblStt.Text) - 1).ToString();
            for (int i = 5 * int.Parse(lblStt.Text); i < 5 * int.Parse(lblStt.Text) + 5; i++)
            {
                if (i < 5)
                {
                    lblSubstract.Hide();
                    break;
                }
                UC_Staff uc = new UC_Staff();
                uc.MaNV = nv[i].MaNV;
                uc.TenNV = nv[i].HoTenNV;
                uc.MaCV = nv[i].MaCV;
                uc.Luong = nv[i].Luong.ToString() + " VND";
                flpContain.Controls.Add(uc);
            }
        }

        private void lblAdd_Click(object sender, EventArgs e)
        {
            lblSubstract.Show();
            flpContain.Controls.Clear();
            lblStt.Text = (int.Parse(lblStt.Text)+1).ToString();
            for (int i = 5 * int.Parse(lblStt.Text); i < 5 * int.Parse(lblStt.Text) + 5; i++)
            {
                if (i >= soluong)
                {
                    lblAdd.Hide();
                    break;
                }
                UC_Staff uc = new UC_Staff();
                uc.MaNV = nv[i].MaNV;
                uc.TenNV = nv[i].HoTenNV;
                uc.MaCV = nv[i].MaCV;
                uc.Luong = nv[i].Luong.ToString() + " VND";
                flpContain.Controls.Add(uc);
            }
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            AddStaff add = new AddStaff();
            add.Show();
        }

        private void ManageStaff_Load(object sender, EventArgs e)
        {
            loadDuLieu();
        }
    }
}
