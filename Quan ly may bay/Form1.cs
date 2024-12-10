using ComponentFactory.Krypton.Toolkit;
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
    public partial class Form1 : KryptonForm
    {
        private KryptonButton[,] seats = new KryptonButton[6, 8];
        public Form1()
        {
            InitializeComponent();
            CreateSeats();
        }
        private void CreateSeats()
        {
            for(int i = 0; i < 6; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    KryptonButton button = new KryptonButton();
                    CreateButton(button);
                    button.Location = new Point(j * (button.Size.Width + 20) + 85, i * (button.Size.Height + 20) + 30);
                    seats[i,j] = button;
                    Controls.Add(button);
                }
            }
        }

        private void CreateButton(KryptonButton _btn)
        {
            //Default
            _btn.PaletteMode = PaletteMode.ProfessionalSystem;
            _btn.OverrideDefault.Back.Color1 = Color.Black;
            _btn.OverrideDefault.Back.Color2 = Color.Black;
            _btn.OverrideDefault.Back.GraphicsHint = PaletteGraphicsHint.AntiAlias;
            _btn.Size = new Size(60, 50);
            _btn.Text = "";

            //Common
            _btn.StateCommon.Back.Color1 = Color.Black;
            _btn.StateCommon.Back.Color2 = Color.Black;
            _btn.StateCommon.Back.GraphicsHint = PaletteGraphicsHint.AntiAlias;
            _btn.StateCommon.Border.Rounding = 20;
            _btn.StateCommon.Border.Color1 = Color.FromArgb(20, 176, 238);
            _btn.StateCommon.Border.Color2 = Color.FromArgb(20, 176, 238);
            _btn.StateCommon.Border.GraphicsHint = PaletteGraphicsHint.AntiAlias;
            _btn.StateCommon.Border.Width = 2;

            //Tracking
            _btn.StateTracking.Back.Color1 = Color.FromArgb(200, 0, 0, 0);
            _btn.StateTracking.Back.Color2 = Color.FromArgb(200, 0, 0, 0);
        }
    }
}
