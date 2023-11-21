using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Сапёр.Controllers;
using ContentAlignment = System.Drawing.ContentAlignment;

namespace Сапёр2.Controllers
{
    public static class MenuController
    {
        private static Form form;
        public static int Init(Form current, int width)
        {
            form = current;

            return MakeMenu(current, width).Height;
        }

        private static Control MakeMenu(Form current, int width)
        {
            TableLayoutPanel panel = new TableLayoutPanel();
            panel.Location = new Point(0, 0);
            panel.Size = new Size(width, 40);
            panel.BackColor = Color.Aqua;
            panel.Margin = new Padding(0);
            panel.Padding = new Padding(10, 5, 10, 5);
            panel.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            panel.Text = null;

            Label flagCounter = new Label();
            flagCounter.ForeColor = Color.Black;
            flagCounter.BackColor = Color.Transparent;
            flagCounter.Font = new Font(flagCounter.Font.FontFamily, float.Parse("10,5"), FontStyle.Bold);
            flagCounter.TextAlign = ContentAlignment.MiddleLeft;
            flagCounter.Text = "0 флажков";
            flagCounter.Margin = new Padding(0);
            flagCounter.Name = "flagCounter";

            Label TimeCounter = new Label();
            TimeCounter.ForeColor = Color.Black;
            TimeCounter.BackColor = Color.Transparent;
            TimeCounter.Font = new Font(TimeCounter.Font.FontFamily, 14, FontStyle.Bold);
            TimeCounter.TextAlign = ContentAlignment.MiddleCenter;
            TimeCounter.Text = "00:00:00";
            TimeCounter.Margin = new Padding(0);
            TimeCounter.Name = "TimeCounter";

            Button restartBtn = new Button();
            restartBtn.ForeColor = Color.Black;
            restartBtn.BackColor = Color.Transparent;
            restartBtn.Size = new Size(25, 25);
            restartBtn.Font = new Font(restartBtn.Font.FontFamily, 7, FontStyle.Bold);
            restartBtn.Text = "R";
            restartBtn.TextAlign = ContentAlignment.MiddleCenter;
            restartBtn.Cursor = Cursors.Hand;
            restartBtn.Margin = new Padding(0, 0, 0, 0);
            restartBtn.Padding = new Padding(0, 0, 0, 0);
            restartBtn.TabStop = false;
            restartBtn.Anchor = AnchorStyles.Right;
            restartBtn.Name = "restartBtn";
            restartBtn.MouseUp += RestartGame;

            panel.ColumnCount = 3;
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            panel.Controls.Add(flagCounter, 0, 0);
            panel.Controls.Add(TimeCounter, 1, 0);
            panel.Controls.Add(restartBtn, 2, 0);

            current.Controls.Add(panel);

            return panel;
        }

        private static void RestartGame(object sender, EventArgs e)
        {
            form.Controls.Clear();
            MapController.timer.Stop();
            MapController.Init(form);
        }

        public static void FlagCounter(int flag)
        { 
            Label flagCounter = form.Controls.Find("flagCounter", true).FirstOrDefault() as Label;
            flagCounter.Text = flag.ToString() + " Флажков";
        }
    }
}
