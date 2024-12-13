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
        private databaseDataContext db = new databaseDataContext();
        private List<Ve> ve = new List<Ve>();
       private List<Ve> tongVe = new List<Ve>(); 
        private int prevI = -1, prevJ = -1;
        private string currentMaVe;
        private Account account;
        string maChuyenBay;
        public ChoseSeat(string _maChuyenBay, int _id)
        {
            InitializeComponent();
            ve = db.Ves.Where(p => p.MaCB == _maChuyenBay).ToList();
            maChuyenBay = _maChuyenBay;
            account = db.Accounts.FirstOrDefault(p => p.ID == _id);
            tongVe = db.Ves.OrderBy(p => p.MaVe).ToList();
            currentMaVe = tongVe[tongVe.Count - 1].MaVe;
            CreateSeats();
            LoadSeats();
        }   
        private void LoadSeats()
        {
            for(int i = 0; i < ve.Count; i++)
            {
                int levelSeat = (int)(ve[i].LevelSeat);
                string seat = ve[i].Seat;
                int seatNum = int.Parse(seat.Substring(1, 2));
                int row = seatNum / 11;
                int col = seatNum - row * 10 - 1;
                if(levelSeat == 1)
                {
                    seats[row + 2, col].Enabled = false;
                }
                else
                {
                    seats[row, col].Enabled = false;
                }
            }
        }
        private void CreateSeats()
        {
            for(int i = 0; i < 2; ++i)
            {
                for(int j = 0; j < 5; ++j)
                {
                    KryptonButton button = new KryptonButton();
                    CreateButton(button);
                    button.Location = new Point(j*(button.Width + 30) + 50, i*(button.Height + 10) + 30);
                    button.StateCommon.Border.Color1 = Color.Yellow;
                    button.Tag = "deluxe left";
                    seats[i,j] = button;
                    Controls.Add(button);
                    button.BringToFront();
                }
                for(int j = 5; j < 10; ++j)
                {
                    KryptonButton button = new KryptonButton();
                    CreateButton(button);
                    button.Location = new Point(j * (button.Width + 30) + 90, i * (button.Height + 10) + 30);
                    button.StateCommon.Border.Color1 = Color.Yellow;
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
                    button.Location = new Point(j * (button.Width + 30) + 50, i * (button.Height + 10) + 60);
                    button.StateCommon.Border.Color1 = Color.Green;
                    button.Tag = "economic left";
                    seats[i, j] = button;
                    Controls.Add(button);
                    button.BringToFront();
                }
                for (int j = 5; j < 10; ++j)
                {
                    KryptonButton button = new KryptonButton();
                    CreateButton(button);
                    button.Location = new Point(j * (button.Width + 30) + 90, i * (button.Height + 10) + 60);
                    button.StateCommon.Border.Color1 = Color.Green;
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
            _btn.Size = new Size(40, 30);
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

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if(prevI != -1 && prevJ != -1)
            {
                string newMaVe = GenerateMaVe();
                Ve newVe = new Ve();
                newVe.MaVe = newMaVe;
                newVe.MaCB = maChuyenBay;
                newVe.MaKH = account.ID;
                string newSeat;
                int numSeat = prevI * 10 + prevJ + 1;
                if (prevI <= 1)
                {
                    newVe.LevelSeat = 0;
                    newSeat = "A";
                }
                else
                {
                    newSeat = "B";
                    newVe.LevelSeat = 1;
                    numSeat -= 20;
                }
                while(numSeat + newSeat.ToString().Length < 3)
                {
                    newSeat += "0";
                }
                newSeat += numSeat.ToString();
                newVe.Seat = newSeat;
                label3.Text = newSeat;
            }
        }

        private string GenerateMaVe()
        {
            string maVe = currentMaVe;
            int soMaVe = int.Parse(maVe.Substring(1, 7)) + 1;
            string newMaVe = "V";
            while (newMaVe.Length + soMaVe.ToString().Length < 8)
            {
                newMaVe += "0";
            }
            newMaVe += soMaVe.ToString();
            currentMaVe = newMaVe;
            return newMaVe;
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
                paddingX = 90;
                paddingY = 30;
            }
            else if (btn.Tag.ToString() == "economic left")
            {
                paddingX = 50;
                paddingY = 60;
            }
            else
            {
                paddingX = 90;
                paddingY = 60;
            }

            prevJ = (btn.Location.X - paddingX)/(btn.Width+30);
            prevI = (btn.Location.Y - paddingY)/(btn.Height+10);
            seats[prevI, prevJ].Enabled = false;
        }

    }
}
