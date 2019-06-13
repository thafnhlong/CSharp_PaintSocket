using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_An_3.Custom
{
    public class Vertex
    {
        private static Pen penHL;
        static Vertex()
        {
            penHL = new Pen(Color.Black, 1);
            penHL.DashStyle = DashStyle.Dash;
        }
        public delegate void setCursorHandler(Cursor cur);
        public static setCursorHandler setCursor;

        public static float R = 4;
        public int X { get; set; }
        public int Y { get; set; }
        public GraphicsPath gpHitTest { get; private set; }

        public override string ToString()
        {
            return $"{X}={Y}";
        }

        public void Draw(Graphics g, int sizeWidth)
        {
            R = sizeWidth < 10 ? 5 : sizeWidth * 1 / 2;

            if (gpHitTest != null) gpHitTest.Dispose();
            gpHitTest = new GraphicsPath();
            gpHitTest.AddEllipse(X - R, Y - R, 2 * R, 2 * R);
            g.DrawPath(penHL, gpHitTest);
        }
        public void OnMouseDown(MouseEventArgs e)
        {
            isDown = true;
            pStart = e.Location;
        }
        public void OnMouseUp(MouseEventArgs e)
        {
            isDown = false;
        }
        public void OnMouseMove(MouseEventArgs e)
        {
            if (isDown)
            {
                X += e.X - pStart.X;
                Y += e.Y - pStart.Y;

                pStart = e.Location;
            }
            setCursor?.Invoke(Cursors.SizeNS);

        }
        public bool HitTest(MouseEventArgs e)
        {
            if (gpHitTest == null) return false;
            return gpHitTest.IsVisible(e.Location);

        }

        private bool isDown = false;
        private Point pStart;
    }
}
