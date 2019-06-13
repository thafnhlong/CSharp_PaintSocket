using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_3.Custom
{
    class PolygonDraw : BasicDraw
    {
        public PolygonDraw() { TypeOf = Form1.DrawMode.polygon; }
        public PolygonDraw(List<Point> Pointlist, Pen penCur)
        {
            TypeOf = Form1.DrawMode.polygon;
            isPolygon = true;
            foreach (var pl in Pointlist)
            {
                Vertices.Add(new Vertex { X = pl.X, Y = pl.Y });
            }

            pen = penCur.Clone() as Pen;

            UpdateBounds();
        }

        protected override void GetPathContent(ref GraphicsPath gp)
        {
            if (gp != null) gp.Dispose();
            gp = new GraphicsPath();
            if (Vertices.Count < 3)
            {
                gp.AddLine(Vertices[0].X, Vertices[0].Y, Vertices[1].X, Vertices[1].Y);
            }
            else
            {
                List<Point> listPoint = new List<Point>();
                Vertices.ForEach(p =>
                   {
                       listPoint.Add(new Point(p.X, p.Y));
                   }
                );
                gp.AddPolygon(listPoint.ToArray());
            }
        }
        public override BasicDraw clone()
        {
            var temp = (PolygonDraw)base.clone();
            temp.UpdateBounds();
            return temp;
        }
        protected override BasicDraw CreateInstanceForClone()
        {
            return new PolygonDraw();
        }
        protected override void UpdateBounds()
        {
            int minX = int.MaxValue, minY = int.MaxValue, maxX = int.MinValue, maxY = int.MinValue;
            Vertices.ForEach(p =>
            {
                if (minX > p.X)
                {
                    minX = p.X;
                }
                if (minY > p.Y)
                {
                    minY = p.Y;
                }
                if (maxX < p.X)
                {
                    maxX = p.X;
                }
                if (maxY < p.Y)
                {
                    maxY = p.Y;
                }
            });

            Left = minX;
            Top = minY;
            Width = maxX - minX;
            Height = maxY - minY;
        }
    }
}
