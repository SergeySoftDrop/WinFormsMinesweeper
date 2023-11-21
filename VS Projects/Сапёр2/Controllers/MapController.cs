using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Сапёр2.Controllers;
using Label = System.Windows.Forms.Label;

namespace Сапёр.Controllers
{
    public static class MapController
    {
        public const int mapSize = 9;
        public const int cellSize = 50;

        public static int[,] map = new int[mapSize, mapSize];

        public static Button[,] buttons = new Button[mapSize, mapSize];

        public static Image spriteSet;

        private static bool isFirstStep;

        private static Point firstCoord;

        private static int bombsCount;
        private static int flags;

        private static TimeSpan time;
        public static Timer timer;

        public static Form form;

        private static void ConfigureMapSize(Form current, int menuHeight)
        {
            int width = mapSize * cellSize + 20;
            int height = (mapSize + 1) * cellSize + menuHeight;

            current.Width = width;
            current.Height = height;
            current.MaximumSize = new Size(width, height);
        }

        private static void InitMap()
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    map[i, j] = 0;
                }
            }
        }

        public static void Init(Form current)
        { 
            int menuHeight = MenuController.Init(current, mapSize * cellSize);
            isFirstStep = true;
            spriteSet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\tiles.png"));
            InitTimer();
            ConfigureMapSize(current, menuHeight);
            InitMap();
            InitButtons(current, menuHeight);
            form = current;
        }

        private static void InitButtons(Form current, int menuHeight)
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    Button button = new Button();
                    button.Location = new Point(j * cellSize, i * cellSize + menuHeight);
                    button.Size = new Size(cellSize, cellSize);
                    button.Image = FindNeededImage(0, 0);
                    button.TabStop = false;
                    button.MouseUp += new MouseEventHandler(OnButtonPressedMouse);
                    current.Controls.Add(button);
                    buttons[i, j] = button;
                }
            }
        }

        private static void InitTimer()
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += TickTimer;

            time = new TimeSpan(0,0,0);
        }

        private static void TickTimer(Object sender, EventArgs e)
        {
            time = time.Add(TimeSpan.FromSeconds(1));

            Label timeCounter = form.Controls.Find("TimeCounter", true).FirstOrDefault() as Label;
            timeCounter.Text = time.ToString();
        }

        private static void OnButtonPressedMouse(object sender, MouseEventArgs e)
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
            if (AreImagesEqual(pressedButton.Image, FindNeededImage(0, 0)))
            {
                if (!isFirstStep)
                {
                    flags--;
                    MenuController.FlagCounter(flags);

                    if (Win())
                    {
                        int iButton = pressedButton.Location.Y / cellSize;
                        int jButton = pressedButton.Location.X / cellSize;

                        WinCase(iButton, jButton);
                    }
                }

                pressedButton.Image = FindNeededImage(0, 2);
            } else if(AreImagesEqual(pressedButton.Image, FindNeededImage(0, 2)))
            {
                if (!isFirstStep)
                {
                    flags++;
                    MenuController.FlagCounter(flags);

                    if (Win())
                    {
                        int iButton = pressedButton.Location.Y / cellSize;
                        int jButton = pressedButton.Location.X / cellSize;

                        WinCase(iButton, jButton);
                    }
                }

                pressedButton.Image = FindNeededImage(2, 2);
            } else if(AreImagesEqual(pressedButton.Image, FindNeededImage(2, 2)))
            {
                pressedButton.Image = FindNeededImage(0, 0);
            }
        }

        private static void OnLeftButtonPressed(Button pressedButton)
        {
            if(!AreImagesEqual(pressedButton.Image, FindNeededImage(0, 2)) || isFirstStep)
            {
                pressedButton.Enabled = false;

                int iButton = pressedButton.Location.Y / cellSize;
                int jButton = pressedButton.Location.X / cellSize;

                if (isFirstStep)
                {
                    firstCoord = new Point(jButton, iButton);
                    SeedMap();
                    CountCellBomb();
                    isFirstStep = false;
                    timer.Start();
                }
                OpenCells(iButton, jButton);

                if (map[iButton, jButton] == -1)
                {
                    ShowAllBombs(iButton, jButton);
                    timer.Stop();
                    MessageBox.Show("Вы проиграли!", "Поражение!");
                    form.Controls.Clear();
                    Init(form);
                }

                if (Win())
                {
                    WinCase(iButton, jButton);
                }
            }
        }

        private static bool Win()
        {
            int tmp = 0;

            foreach (Control control in form.Controls)
            {
                if(control is Button)
                {
                    if (control.Enabled)
                    {
                        tmp++;
                    }
                }
            }

            if(tmp == bombsCount && flags == 0)
            {
                return true;
            }

            return false;
        }

        private static void WinCase(int iButton, int jButton)
        {
            ShowAllBombs(iButton, jButton);
            timer.Stop();
            MessageBox.Show($"Вы победили!\nВpемя: {time}", "Победа!");
            form.Controls.Clear();
            Init(form);
        }

        private static void ShowAllBombs(int iBomb, int jBomb)
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (map[i, j] == -1)
                    {
                        buttons[i, j].Image = FindNeededImage(3, 2);
                    }
                }
            }
        }

        public static Image FindNeededImage(int xPos, int yPos)
        {
            Image image = new Bitmap(cellSize, cellSize);
            Graphics g = Graphics.FromImage(image);
            g.DrawImage(spriteSet, new Rectangle(new Point(0, 0), new Size(cellSize, cellSize)), 0 + 32 * xPos, 0 + 32 * yPos, 33, 33, GraphicsUnit.Pixel);


            return image;
        }

        public static bool AreImagesEqual(Image img1, Image img2)
        {
            using (MemoryStream ms1 = new MemoryStream(), ms2 = new MemoryStream())
            {
                img1.Save(ms1, ImageFormat.Png);
                img2.Save(ms2, ImageFormat.Png);

                return ms1.ToArray().SequenceEqual(ms2.ToArray());
            }
        }

        private static void SeedMap()
        {
            Random r = new Random();
            bombsCount = r.Next(7, 15);

            flags = bombsCount;
            MenuController.FlagCounter(flags);

            for (int i = 0; i < bombsCount; i++)
            {
                int posI = r.Next(0, mapSize - 1);
                int posJ = r.Next(0, mapSize - 1);

                while (map[posI, posJ] == -1 || (Math.Abs(posI - firstCoord.Y) <= 1 && Math.Abs(posJ - firstCoord.X) <= 1))
                {
                    posI = r.Next(0, mapSize - 1);
                    posJ = r.Next(0, mapSize - 1);
                }
                map[posI, posJ] = -1;
            }
        }

        private static void CountCellBomb()
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
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

        private static void OpenCell(int i, int j)
        {
            buttons[i, j].Enabled = false;

            switch (map[i, j])
            {
                case 1:
                    buttons[i, j].Image = FindNeededImage(1, 0);
                    break;
                case 2:
                    buttons[i, j].Image = FindNeededImage(2, 0);
                    break;
                case 3:
                    buttons[i, j].Image = FindNeededImage(3, 0);
                    break;
                case 4:
                    buttons[i, j].Image = FindNeededImage(4, 0);
                    break;
                case 5:
                    buttons[i, j].Image = FindNeededImage(0, 1);
                    break;
                case 6:
                    buttons[i, j].Image = FindNeededImage(1, 1);
                    break;
                case 7:
                    buttons[i, j].Image = FindNeededImage(2, 1);
                    break;
                case 8:
                    buttons[i, j].Image = FindNeededImage(3, 1);
                    break;
                case -1:
                    buttons[i, j].Image = FindNeededImage(1, 2);
                    break;
                case 0:
                    buttons[i, j].Image = FindNeededImage(0, 0);
                    break;
            }
        }

        private static void OpenCells(int i, int j)
        {
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

        private static bool IsInBorder(int i, int j)
        {
            if (i < 0 || j < 0 || j > mapSize - 1 || i > mapSize - 1)
            {
                return false;
            }
            return true;
        }
    }
}
