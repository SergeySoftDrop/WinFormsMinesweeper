using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using Сапёр3.Controllers;
using Сапёр3.Setings;

namespace сапёр3.Controllers
{
    static class GameLogicController
    {
        private static bool isFirstStep;

        private static TimeSpan time;

        public static Timer timer;

        private static int bombsCount;

        private static int flags;

        private static int[,] map = new int[GameSetings.MapSize[0], GameSetings.MapSize[1]];

        private static Button[,] buttons = new Button[GameSetings.MapSize[0], GameSetings.MapSize[1]];

        public static void Init()
        {
            isFirstStep = true;
            InitMap();
            InitTimer();
        }

        public static void Reastart()
        {
            timer.Stop();
            Init();
        }

        public static void NewSettings()
        {
            map = new int[GameSetings.MapSize[0], GameSetings.MapSize[1]];
            buttons = new Button[GameSetings.MapSize[0], GameSetings.MapSize[1]];
            Reastart();
        }

        private static void InitMap()
        {
            for (int i = 0; i < GameSetings.MapSize[0]; i++)
            {
                for (int j = 0; j < GameSetings.MapSize[1]; j++)
                {
                    map[i, j] = 0;

                    buttons[i, j] = AppInterfaceController.InitButtons(i, j);
                    buttons[i, j].MouseUp += new MouseEventHandler(OnButtonPressedMouse);
                }
            }

            //DEBUG CODE
            Console.Write("map in IM: \n" + "Length: " + map.Length + "\n");
            foreach (int el in map)
            {
                Console.Write(el + ", ");
            }
            Console.WriteLine("\n");

            Console.Write("buttons in IM: \n" + "Length: " + buttons.Length + "\n");
            foreach (Button el in buttons)
            {
                Console.WriteLine("X(i):" + Convert.ToInt32(el.Location.X) / 50 + " " + "Y(j):" + Convert.ToInt32(el.Location.Y) / 50);
                Console.WriteLine(el.Enabled);
            }

            Console.WriteLine("\n");
            //
        }

        private static void InitTimer()
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += TickTimer;

            time = new TimeSpan(0, 0, 0);
        }

        private static void TickTimer(object sender, EventArgs e)
        {
            time = time.Add(TimeSpan.FromSeconds(1));

            AppInterfaceController.SetValueTimerLabel(time);
        }

        private static void OnButtonPressedMouse(Object sender, MouseEventArgs e)
        {
            Button pressedButton = sender as Button;

            switch (e.Button.ToString())
            {
                case "Right":
                    OnRightButtonPressed(pressedButton);
                    break;
                case "Left":
                    OnLeftButtonPressed(pressedButton);
                    break;
            }
        }

        private static void OnRightButtonPressed(Button pressedButton)
        {
            //DEBUG CODE

            Console.WriteLine("ORBP Btn Location: ");
            Console.WriteLine("In form: " + pressedButton.Location);
            Console.WriteLine("In buttons arr: " + pressedButton.Location.X / 50 + ", " + pressedButton.Location.Y / 50 + "\n");

            //

            if (ImageController.AreImagesEqual(pressedButton.Image, ImageController.FindNeededImage(0, 0)))
            {
                if (!isFirstStep)
                {
                    flags--;
                    AppInterfaceController.SetValueFlagCounterLabel(flags);

                    if (Win())
                    {
                        int iButton = pressedButton.Location.Y / GameSetings.CellSize;
                        int jButton = pressedButton.Location.X / GameSetings.CellSize;

                        WinCase(iButton, jButton);
                    }
                }

                pressedButton.Image = ImageController.FindNeededImage(0, 2);
            }
            else if (ImageController.AreImagesEqual(pressedButton.Image, ImageController.FindNeededImage(0, 2)))
            {
                if (!isFirstStep)
                {
                    flags++;
                    AppInterfaceController.SetValueFlagCounterLabel(flags);

                    if (Win())
                    {
                        int iButton = pressedButton.Location.Y / GameSetings.CellSize;
                        int jButton = pressedButton.Location.X / GameSetings.CellSize;

                        WinCase(iButton, jButton);
                    }
                }

                pressedButton.Image = ImageController.FindNeededImage(2, 2);
            }
            else if (ImageController.AreImagesEqual(pressedButton.Image, ImageController.FindNeededImage(2, 2)))
            {
                pressedButton.Image = ImageController.FindNeededImage(0, 0);
            }
        }

        private static void OnLeftButtonPressed(Button pressedButton)
        {
            //DEBUG CODE

            Console.WriteLine("OLBP Btn Location: ");
            Console.WriteLine("In form: " + pressedButton.Location);
            Console.WriteLine("In buttons arr: " + pressedButton.Location.X / 50 + ", " + pressedButton.Location.Y / 50 + "\n");

            //
            if (!ImageController.AreImagesEqual(pressedButton.Image, ImageController.FindNeededImage(0, 2)) || isFirstStep)
            {
                pressedButton.Enabled = false;

                int iButton = (pressedButton.Location.Y - 100) / GameSetings.CellSize;
                int jButton = pressedButton.Location.X / GameSetings.CellSize;

                if (isFirstStep)
                {
                    SeedMap(new Point(jButton, iButton));
                    CountCellBomb();
                    isFirstStep = false;
                    timer.Start();
                }

                if (map[jButton, iButton] == -1)
                {
                    Console.WriteLine("LOSE");
                    ShowAllBombs();
                    timer.Stop();
                    MessageBox.Show("Вы проиграли!", "Поражение!");
                    AppInterfaceController.ClearMap();
                    MainController.ReastartApp(); //??
                }
                else
                {
                    OpenCells(jButton, iButton);
                }

                if (Win())
                {
                    WinCase(jButton, iButton);
                }
            }
        }

        private static void SeedMap(Point firstCoord)
        {
            //DEBUG CODE

            Console.WriteLine("SM point firstCoord: " + firstCoord + "\n");
            //

            Random r = new Random();

            bombsCount = GameSetings.BombsQuantity;

            flags = bombsCount;

            AppInterfaceController.SetValueFlagCounterLabel(flags);

            for (int i = 0; i < bombsCount; i++)
            {
                int posI = r.Next(0, GameSetings.MapSize[0] - 1);
                int posJ = r.Next(0, GameSetings.MapSize[1] - 1);

                while (map[posI, posJ] == -1 || (Math.Abs(posJ - firstCoord.Y) <= 1 && Math.Abs(posI - firstCoord.X) <= 1) || ChekAround(new Point(posI, posJ), 2, 1) || ChekAround(new Point(posI, posJ), 3, 2))
                {
                    posI = r.Next(0, GameSetings.MapSize[0] - 1);
                    posJ = r.Next(0, GameSetings.MapSize[1] - 1);
                }
                map[posI, posJ] = -1;
            }

            // DEBUG CODE
            Console.WriteLine("SM map: ");
            for (int i = 0; i < GameSetings.MapSize[1]; i++)
            {
                Console.Write("Line: ");
                for (int j = 0; j < GameSetings.MapSize[0]; j++)
                {
                    Console.Write(map[j, i] + ", ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            //
        }

        private static bool ChekAround(Point pos, int quantity, int radius)
        {
            int tmp = 0;
            Random r = new Random();

            for (int i = Math.Max(0, pos.X - radius); i <= Math.Min(4, pos.X + radius); i++)
            {
                for (int j = Math.Max(0, pos.Y - radius); j <= Math.Min(4, pos.Y + radius); j++)
                {
                    if(map[i, j] == -1)
                    {
                        tmp++;
                    }
                }
            }

            if(tmp > quantity)
            {
                if(r.Next(0, 10) == 1)
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        private static void OpenCell(int i, int j)
        {
            //DEBUG CODE
            Console.WriteLine("OC btn arr coord: " + i + "," + j + "\n");
            //

            buttons[i, j].Enabled = false;

            switch (map[i, j])
            {
                case 1:
                    buttons[i, j].Image = ImageController.  FindNeededImage(1, 0);
                    break;
                case 2:
                    buttons[i, j].Image = ImageController.FindNeededImage(2, 0);
                    break;
                case 3:
                    buttons[i, j].Image = ImageController.FindNeededImage(3, 0);
                    break;
                case 4:
                    buttons[i, j].Image = ImageController.FindNeededImage(4, 0);
                    break;
                case 5:
                    buttons[i, j].Image = ImageController.FindNeededImage(0, 1);
                    break;
                case 6:
                    buttons[i, j].Image = ImageController.FindNeededImage(1, 1);
                    break;
                case 7:
                    buttons[i, j].Image = ImageController.FindNeededImage(2, 1);
                    break;
                case 8:
                    buttons[i, j].Image = ImageController.FindNeededImage(3, 1);
                    break;
                case -1:
                    buttons[i, j].Image = ImageController.FindNeededImage(1, 2);
                    break;
                case 0:
                    buttons[i, j].Image = ImageController.FindNeededImage(0, 0);
                    break;
            }
        }

        private static void OpenCells(int i, int j)
        {            
            //DEBUG CODE
            Console.WriteLine("OCS btn arr: " + i + "," + j + "\n");
            //
            OpenCell(i, j);

            if (map[i, j] > 0)
                return;

            for (int k = i - 1; k < i + 2; k++)
            {
                for (int l = j - 1; l < j + 2; l++)
                {
                    if (!IsInBorder(k, l))
                        continue;
                    if (!buttons[k, l].Enabled)
                        continue;
                    if (map[k, l] == 0)
                        OpenCells(k, l);
                    else if (map[k, l] > 0)
                        OpenCell(k, l);
                }
            }
        }

        private static void CountCellBomb()
        {
            for (int i = 0; i < GameSetings.MapSize[0]; i++)
            {
                for (int j = 0; j < GameSetings.MapSize[1]; j++)
                {
                    if (map[i, j] == -1)
                    {
                        for (int k = i - 1; k < i + 2; k++)
                        {
                            for (int l = j - 1; l < j + 2; l++)
                            {
                                if (!IsInBorder(k, l) || map[k, l] == -1)
                                    continue;
                                map[k, l] = map[k, l] + 1;
                            }
                        }
                    }
                }
            }
        }

        private static bool IsInBorder(int i, int j)
        {
            if (i < 0 || j < 0 || j > GameSetings.MapSize[1] - 1 || i > GameSetings.MapSize[0] - 1)
            {
                return false;
            }
            return true;
        }

        private static bool Win()
        {
            int tmp = 0;

            foreach (Control control in AppInterfaceController.getCurrentForm().Controls)
            {
                if (control is Button)
                {
                    if (control.Enabled)
                    {
                        tmp++;
                    }
                }
            }

            if (tmp == bombsCount && flags == 0)
            {
                return true;
            }

            return false;
        }

        private static void WinCase(int iButton, int jButton)
        {
            //DEBUG CODE
            Console.WriteLine("WIN");
            //
            ShowAllBombs();
            timer.Stop();
            MessageBox.Show($"Вы победили!\nВpемя: {time}", "Победа!");
            AppInterfaceController.ClearMap();
            MainController.ReastartApp(); //??
        }

        private static void ShowAllBombs()
        {
            for (int i = 0; i < GameSetings.MapSize[0]; i++)
            {
                for (int j = 0; j < GameSetings.MapSize[1]; j++)
                {
                    if (map[i, j] == -1)
                    {
                        buttons[i, j].Image = ImageController.FindNeededImage(3, 2);
                    }
                }
            }
        }
    }
}
