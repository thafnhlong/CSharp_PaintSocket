using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_An_3.Custom
{
    public class ObjectDraw
    {
        public Rectangle Bounds
        {
            get
            {
                return new Rectangle(Left, Top, (int)r, (int)r);
            }
        }

        float r = 40;
        Pen pen = new Pen(Color.Orange, 2);
        public int Left { get; set; }
        public int Top { get; set; }
        public void Draw(Graphics g)
        {
            g.DrawEllipse(pen, Bounds);
        }

        bool isDown = false;
        Point pStart, locStart;

        public void OnMouseDown(MouseEventArgs e)
        {
            isDown = true;
            pStart = e.Location;
            locStart = Bounds.Location;
        }
        public void OnMouseUp(MouseEventArgs e)
        {
            isDown = false;
        }
        public void OnMouseMove(MouseEventArgs e)
        {
            if (isDown)
            {
                Left = locStart.X + e.X - pStart.X;
                Top = locStart.Y + e.Y - pStart.Y;
            }
        }
    }
}
