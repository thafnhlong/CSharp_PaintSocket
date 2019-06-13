using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_3.Custom
{
    public class LineSD : SurfaceDraw
    {
        public LineSD(Point p1, Point p2)
        {
            Left = Math.Min(p1.X, p2.X);
            Top = Math.Min(p1.Y, p2.Y);

            Vertexes = new List<Point> {
                new Point(p1.X - Left,p1.Y - Top),
                new Point(p2.X - Left,p2.Y-Top)
            };
            drawContent = g =>
            {
                g.DrawLine(pen, Vertexes[0], Vertexes[1]);
            };
        }
    }
}
