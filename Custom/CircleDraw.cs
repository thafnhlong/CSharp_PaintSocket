using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_3.Custom
{
    public class CircleDraw : BasicDraw
    {
        public CircleDraw() { TypeOf = Form1.DrawMode.circle; }
        public CircleDraw(Point p1, Point p2, Pen penCur)
        {
            TypeOf = Form1.DrawMode.circle;
            Vertices.Add(new Vertex { X = p1.X, Y = p1.Y });
            Vertices.Add(new Vertex { X = p2.X, Y = p2.Y });

            pen = penCur.Clone() as Pen;

            UpdateBounds();
        }

        protected override void GetPathContent(ref GraphicsPath gp)
        {
            if (gp != null) gp.Dispose();
            gp = new GraphicsPath();

            Vertex Start, End;
            if (vCur != null && vCur.Equals(Vertices[0]))
            {
                Start = Vertices[1]; End = Vertices[0];
            }
            else
            {
                Start = Vertices[0]; End = Vertices[1];
            }

            int min = Math.Min(Math.Abs(Start.X - End.X), Math.Abs(Start.Y - End.Y));
            Rectangle rt = new Rectangle
            {
                X = Start.X,
                Y = Start.Y,
                Width = min,
                Height = min,
            };
            if (Start.X > End.X) rt.X -= min;
            if (Start.Y > End.Y) rt.Y -= min;
            gp.AddEllipse(rt);
        }
        public override BasicDraw clone()
        {
            var temp = (CircleDraw)base.clone();
            temp.UpdateBounds();
            return temp;
        }
        protected override BasicDraw CreateInstanceForClone()
        {
            return new CircleDraw();
        }
        protected override void UpdateBounds()
        {
            Vertex Start, End;
            if (vCur != null && vCur.Equals(Vertices[0]))
            {
                Start = Vertices[1]; End = Vertices[0];
            }
            else
            {
                Start = Vertices[0]; End = Vertices[1];
            }

            int min = Math.Min(Math.Abs(Start.X - End.X), Math.Abs(Start.Y - End.Y));

            if (Start.X > End.X) End.X = Start.X - min;
            else End.X = Start.X + min;
            if (Start.Y > End.Y) End.Y = Start.Y - min;
            else End.Y = Start.Y + min;

            Left = Math.Min(Start.X, End.X);
            Top = Math.Min(Start.Y, End.Y);
            Width = min;
            Height = min;
        }
    }
}
