using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Сапёр3.Setings;

namespace Сапёр3.Controllers
{
    static class ImageController
    {
        public static Image FindNeededImage(int xPos, int yPos)
        {
            int cellSize = GameSetings.CellSize;
            Bitmap spriteSet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\tiles.png"));

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
    }
}
