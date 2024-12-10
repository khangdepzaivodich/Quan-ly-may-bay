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
    public partial class ChoseSeat : KryptonForm
    {
        private KryptonButton[,] seats = new KryptonButton[7, 10];
        private int prevI = -1, prevJ = -1;
        public ChoseSeat()
        {
            InitializeComponent();
            CreateSeats();
        }
        private void CreateSeats()
        {
            for(int i = 0; i < 2; ++i)
            {
                for(int j = 0; j < 5; ++j)
                {
                    KryptonButton button = new KryptonButton();
                    CreateButton(button);
                    button.Location = new Point(j*(button.Width + 40) + 50, i*(button.Height + 15) + 30);
                    button.Tag = "deluxe left";
                    seats[i,j] = button;
                    Controls.Add(button);
                    button.BringToFront();
                }
                for(int j = 5; j < 10; ++j)
                {
                    KryptonButton button = new KryptonButton();
                    CreateButton(button);
                    button.Location = new Point(j * (button.Width + 40) + 160, i * (button.Height + 15) + 30);
                    button.Tag = "deluxe right";
                    seats[i, j] = button;
                    Controls.Add(button);
                    button.BringToFront();
                }
            }
            for(int i = 2; i < 7; ++i)
            {
                for (int j = 0; j < 5; ++j)
                {
                    KryptonButton button = new KryptonButton();
                    CreateButton(button);
                    button.Location = new Point(j * (button.Width + 40) + 50, i * (button.Height + 15) + 90);
                    button.Tag = "economic left";
                    seats[i, j] = button;
                    Controls.Add(button);
                    button.BringToFront();
                }
                for (int j = 5; j < 10; ++j)
                {
                    KryptonButton button = new KryptonButton();
                    CreateButton(button);
                    button.Location = new Point(j * (button.Width + 40) + 160, i * (button.Height + 15) + 90);
                    button.Tag = "economic right";
                    seats[i, j] = button;
                    Controls.Add(button);
                    button.BringToFront();
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
            _btn.StateTracking.Back.Color1 = Color.FromArgb(100, 0, 0, 0);
            _btn.StateTracking.Back.Color2 = Color.FromArgb(100, 0, 0, 0);

            //Disabled
            _btn.StateDisabled.Back.Color1 = Color.Green;
            _btn.StateDisabled.Back.Color2 = Color.Green;
            _btn.StateDisabled.Border.Color1 = Color.White;
            _btn.StateDisabled.Border.Color2 = Color.White;

            //Event
            _btn.Click += _btn_Click;

        }

        private void _btn_Click(object sender, EventArgs e)
        {
            KryptonButton btn = (KryptonButton)sender;
            if(prevI != -1 || prevJ != -1)
            {
                seats[prevI, prevJ].Enabled = true;
            }
            int paddingX, paddingY;
            if (btn.Tag.ToString() == "deluxe left")
            {
                paddingX = 50; 
                paddingY = 30;
            }
            else if (btn.Tag.ToString() == "deluxe right")
            {
                paddingX = 160;
                paddingY = 30;
            }
            else if (btn.Tag.ToString() == "economic left")
            {
                paddingX = 50;
                paddingY = 90;
            }
            else
            {
                paddingX = 160;
                paddingY = 90;
            }

            prevJ = (btn.Location.X - paddingX)/(btn.Width+40);
            prevI = (btn.Location.Y - paddingY)/(btn.Height+15);
            seats[prevI, prevJ].Enabled = false;
        }

    }
}
