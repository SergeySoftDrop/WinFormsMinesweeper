using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace сапёр3.Custom
{
    public class CustomButton : Button
    {
        private bool customEnabled = true;

        public new bool Enabled
        {
            get { return customEnabled; }
            set
            {
                if (customEnabled != value)
                {
                    customEnabled = value;
                    this.Invalidate(); // Перерисовываем кнопку при изменении состояния Enabled
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (customEnabled)
            {
                base.OnPaint(e); // Используем стандартную отрисовку для включенной кнопки
            }
            else
            {
                // Ваша логика отрисовки для отключенной кнопки (например, без затемнения)
                using (SolidBrush brush = new SolidBrush(this.BackColor))
                {
                    e.Graphics.FillRectangle(brush, this.ClientRectangle);
                }

                // Рисуем текст кнопки (если необходимо)
                TextRenderer.DrawText(e.Graphics, this.Text, this.Font, this.ClientRectangle, this.ForeColor);
            }
        }
    }
}
