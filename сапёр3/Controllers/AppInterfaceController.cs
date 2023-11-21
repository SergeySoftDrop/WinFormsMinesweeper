using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Сапёр3.Controllers;
using Сапёр3.Setings;
using Label = System.Windows.Forms.Label;

namespace сапёр3.Controllers
{
    static class AppInterfaceController
    {
        private static Form1 currentForm;

        private static Settings setingsForm;

        private static Label flagCounterLabel;

        private static Label timerLabel;

        private static Button RestartBtn;

        private static Button SetingsBtn;

        private static Control menu;

        private static Control tableSetings;

        private static Label MapXLabel;

        private static Label MapYLabel;

        private static Label BombsQuantityLabel;

        private static Label CellSizeLabel;

        private static TrackBar MapXTrackBar;

        private static TrackBar MapYTrackBar;

        private static TrackBar BombsQuantityTrackBar;

        private static TrackBar CellSizeTrackBar;

        private static CheckBox EasyCheckBox;

        private static CheckBox MiddleCheckBox;

        private static CheckBox HardCheckBox;

        private static CheckBox UserCheckBox;

        public static void Init(Form1 current, Settings settingsForm)
        {
            currentForm = current;
            setingsForm = settingsForm;

            flagCounterLabel = current.Controls.Find("FlagCounterLabel", true).FirstOrDefault() as Label;
            timerLabel = current.Controls.Find("TimerLabel", true).FirstOrDefault() as Label;
            RestartBtn = current.Controls.Find("RestartBtn", true).FirstOrDefault() as Button;
            SetingsBtn = current.Controls.Find("SetingsBtn", true).FirstOrDefault() as Button;
            menu = current.Controls.Find("Panel", true).FirstOrDefault() as Control;

            int width = ConfigureMapSize();
            ConfigureMenu(width);

            tableSetings = settingsForm.Controls.Find("TableControlsSetings", true).FirstOrDefault() as Control;
            MapXLabel = settingsForm.Controls.Find("MapXLabel", true).FirstOrDefault() as Label;
            MapYLabel = settingsForm.Controls.Find("MapYLabel", true).FirstOrDefault() as Label;
            BombsQuantityLabel = settingsForm.Controls.Find("BombsQuantityLabel", true).FirstOrDefault() as Label;
            CellSizeLabel = settingsForm.Controls.Find("CellSizeLabel", true).FirstOrDefault() as Label;

            MapXTrackBar = settingsForm.Controls.Find("MapXTrackBar", true).FirstOrDefault() as TrackBar;
            MapYTrackBar = settingsForm.Controls.Find("MapYTrackBar", true).FirstOrDefault() as TrackBar;
            BombsQuantityTrackBar = settingsForm.Controls.Find("BombsQuantityTrackBar", true).FirstOrDefault() as TrackBar;
            CellSizeTrackBar = settingsForm.Controls.Find("CellSizeTrackBar", true).FirstOrDefault() as TrackBar;

            EasyCheckBox = settingsForm.Controls.Find("EasyCheckBox", true).FirstOrDefault() as CheckBox;
            MiddleCheckBox = settingsForm.Controls.Find("MiddleCheckBox", true).FirstOrDefault() as CheckBox;
            HardCheckBox = settingsForm.Controls.Find("HardCheckBox", true).FirstOrDefault() as CheckBox;
            UserCheckBox = settingsForm.Controls.Find("UserCheckBox", true).FirstOrDefault() as CheckBox;

            ConfigureSetingsSize();
            SetSetingsValue();
        }

        public static void NewSetings()
        {
            ClearMap();
            int width = ConfigureMapSize();
            ConfigureMenu(width);
        }

        private static void SetSetingsValue()
        {
            MapXLabel.Text = MapXLabel.Text + GameSetings.MapSize[0];
            MapYLabel.Text = MapYLabel.Text + GameSetings.MapSize[1];
            BombsQuantityLabel.Text = BombsQuantityLabel.Text + GameSetings.BombsQuantity;
            CellSizeLabel.Text = CellSizeLabel.Text + GameSetings.CellSize;

            MapXTrackBar.Value = GameSetings.MapSize[0];
            MapYTrackBar.Value = GameSetings.MapSize[1];
            BombsQuantityTrackBar.Value = GameSetings.BombsQuantity;
            BombsQuantityTrackBar.Maximum = Math.Abs((GameSetings.MapSize[0] * GameSetings.MapSize[1]) / 4);
            CellSizeTrackBar.Value = GameSetings.CellSize;
        }

        private static void ConfigureSetingsSize()
        {
            setingsForm.Size = new Size(tableSetings.Width + 80, tableSetings.Height + (tableSetings.Margin.Top * 2) + 50);
            setingsForm.MaximumSize = setingsForm.Size;

            tableSetings.Location = new Point((setingsForm.Width - tableSetings.Width) / 2 - 8, (setingsForm.Height - tableSetings.Height) / 2 - 20);
        }

        private static int ConfigureMapSize()
        {
            int[] mapSize = GameSetings.MapSize;
            int cellSize = GameSetings.CellSize;

            int width = mapSize[0] * cellSize + 20;
            int height = (mapSize[1] + 1) * cellSize + menu.Height;

            currentForm.Width = width;
            currentForm.Height = height;
            currentForm.MaximumSize = new Size(width, height);
            currentForm.MinimumSize = new Size(width, height);
            currentForm.Size = new Size(width, height);

            //DEBUG CODE
            Console.Write("form size in CMZ: \n");
            Console.WriteLine(currentForm.Size + "\n");
            //

            return width;
        }

        private static void ConfigureMenu(int width)
        {

            menu.Width = width - ((menu.Padding.Left + menu.Padding.Right) * 2);

            //DEBUG CODE
            Console.Write("menu width in CM: \n");
            Console.WriteLine(menu.Width + "\n");
            //

            if (width <= 370 && flagCounterLabel.Font.Size != 7)
            {
                flagCounterLabel.Font = new Font(flagCounterLabel.Font.FontFamily, 7, flagCounterLabel.Font.Style);
                timerLabel.Font = new Font(timerLabel.Font.FontFamily, 10, timerLabel.Font.Style);

                RestartBtn.Font = new Font(RestartBtn.Font.FontFamily, 9, RestartBtn.Font.Style);
                RestartBtn.Size = new Size(82, 25);
                SetingsBtn.Font = new Font(SetingsBtn.Font.FontFamily, 9, SetingsBtn.Font.Style);
                SetingsBtn.Size = new Size(82, 25);
            }
            else if (width > 370 && flagCounterLabel.Font.Size == 7)
            {
                RestartBtn.Font = new Font(RestartBtn.Font.FontFamily, 12, RestartBtn.Font.Style);
                RestartBtn.Size = new Size(92, 31);
                SetingsBtn.Font = new Font(SetingsBtn.Font.FontFamily, 12, SetingsBtn.Font.Style);
                SetingsBtn.Size = new Size(92, 31);

                flagCounterLabel.Font = new Font(flagCounterLabel.Font.FontFamily, 14, flagCounterLabel.Font.Style);
                timerLabel.Font = new Font(timerLabel.Font.FontFamily, 14, timerLabel.Font.Style);
            }
        }

        public static Button InitButtons(int posX, int posY)
        {
            Button button = new Button();
            button.Location = new Point(posX * GameSetings.CellSize, posY * GameSetings.CellSize + menu.Height);
            button.Size = new Size(GameSetings.CellSize, GameSetings.CellSize);
            button.Image = ImageController.FindNeededImage(0, 0);
            button.TabStop = false;
            button.Enabled = true;
            button.FlatAppearance.MouseOverBackColor = button.BackColor;
            button.FlatAppearance.MouseDownBackColor = button.BackColor;
            button.UseVisualStyleBackColor = true;
            currentForm.Controls.Add(button);

            return button;
        }

        public static void SetValueFlagCounterLabel(int quantity)
        {
            flagCounterLabel.Text = "Флажков: " + quantity;
        }

        public static void SetValueTimerLabel(TimeSpan time)
        {
            timerLabel.Text = time.ToString();
        }

        public static TrackBar GetMapXTrackBar()
        {
            return MapXTrackBar;
        }

        public static TrackBar GetMapYTrackBar()
        {
            return MapYTrackBar;
        }

        public static TrackBar GetBombsQuantityTrackBar()
        {
            return BombsQuantityTrackBar;
        }

        public static TrackBar GetCellSizeTrackBar()
        {
            return CellSizeTrackBar;
        }

        public static void SetValuMapXLabel(int value)
        {
            MapXLabel.Text = "По горизонтали: " + value;
        }

        public static void SetValuMapYLabele(int value)
        {
            MapYLabel.Text = "По вертикали: " + value;
        }

        public static void SetValueBombsQuantityLabel(int value)
        {
            BombsQuantityLabel.Text = "Количество бомб: " + value;
        }

        public static void SetValueCellSizeLabel(int value)
        {
            CellSizeLabel.Text = "Ширина ячейки: " + value;
        }

        public static CheckBox GetEasyCheckBox()
        {
            return EasyCheckBox;
        }

        public static CheckBox GetMiddleCheckBox()
        {
            return MiddleCheckBox;
        }

        public static CheckBox GetHardCheckBox()
        {
            return HardCheckBox;
        }

        public static CheckBox GetUserCheckBox()
        {
            return UserCheckBox;
        }

        public static Form1 getCurrentForm()
        {
            return currentForm;
        }
        
        public static Settings getCurrentSetingsForm()
        {
            return setingsForm;
        }

        public static void ClearMap()
        {
            for (int i = currentForm.Controls.Count - 1; i >= 0; i--)
            {
                Control ctrl = currentForm.Controls[i];
                if (ctrl is Button)
                {
                    currentForm.Controls.RemoveAt(i);
                    ctrl.Dispose();
                }
            }

            timerLabel.Text = "00:00:00";
            flagCounterLabel.Text = "Флажков: 0";
        }
    }
}
