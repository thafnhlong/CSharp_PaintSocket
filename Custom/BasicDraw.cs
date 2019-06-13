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
    public class BasicDraw
    {
        public delegate void setCursorHandler(Cursor cur);
        public static setCursorHandler setCursor;
        public delegate void InvalidateHandler();
        public InvalidateHandler Invalidate;

        public Pen pen
        {
            get
            {
                return penDraw;
            }
            set
            {
                penDraw = value;
                penHL.Width = penDraw.Width + 4;
            }
        }
        public int Left { get; set; }
        public int Top { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool isForcused { get; set; } = false;
        public bool isFill { get; set; } = false;
        public bool isPolygon { get; set; } = false;
        public Form1.DrawMode TypeOf { get; protected set; } = Form1.DrawMode.select;

        public BasicDraw()
        {
            penHL = new Pen(Color.Blue, 1);
        }

        public virtual BasicDraw clone()
        {
            BasicDraw temp = CreateInstanceForClone();
            temp.Invalidate = Invalidate;
            temp.isPolygon = isPolygon;
            temp.isFill = isFill;
            temp.isForcused = false;
            temp.penDraw = penDraw.Clone() as Pen;
            temp.penHL = penHL.Clone() as Pen;
            temp.Vertices = new List<Vertex>();

            foreach (var v in Vertices)
            {
                temp.Vertices.Add(new Vertex { X = v.X, Y = v.Y });
            }

            return temp;
        }
        protected virtual BasicDraw CreateInstanceForClone()
        {
            return new BasicDraw();
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append((int)TypeOf);
            result.Append(".-.");
            result.Append(isFill);
            result.Append(".-.");
            result.Append(penDraw.Color.ToArgb());
            result.Append(".-.");
            result.Append(penDraw.Width);
            result.Append(".-.");
            result.Append((int)penDraw.DashStyle);
            result.Append(".-.");
            foreach (var v in Vertices)
            {
                result.Append(v);
                result.Append(",");
            }
            return result.ToString();
        }
        public void Restore(string data)
        {
            string[] datasplit = data.Split(new string[] { ".-." }, StringSplitOptions.RemoveEmptyEntries);
            isFill = bool.Parse(datasplit[1]);
            pen = new Pen(Color.FromArgb(int.Parse(datasplit[2])), float.Parse(datasplit[3]));
            pen.DashStyle = (DashStyle)int.Parse(datasplit[4]);
            foreach (var v in datasplit[5].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                string[] location = v.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                Vertices.Add(new Vertex
                {
                    X = int.Parse(location[0]),
                    Y = int.Parse(location[1])
                });
            }
            UpdateBounds();
        }
        public void Draw(Graphics g)
        {
            //g.FillRectangle(Brushes.Red, Left, Top, 50, 50);
            GetPathContent(ref gpHitTest);

            if (isForcused)
            {
                g.DrawPath(penHL, gpHitTest);
                if (isFill && ((isPolygon && Vertices.Count > 2) || !isPolygon))
                {
                    g.FillPath(new SolidBrush(penDraw.Color), gpHitTest);
                }
                else
                {
                    g.DrawPath(penDraw, gpHitTest);
                }

                foreach (var v in Vertices)
                {
                    v.Draw(g, (int)penDraw.Width);
                }
            }
            else
            {
                if (isFill && ((isPolygon && Vertices.Count > 2) || !isPolygon))
                {
                    g.FillPath(new SolidBrush(penDraw.Color), gpHitTest);
                }
                else
                {
                    g.DrawPath(penDraw, gpHitTest);
                }
            }
        }
        public void OnMouseDown(MouseEventArgs e)
        {
            isDown = true;
            pStart = e.Location;

            vCur = null;
            foreach (var v in Vertices)
            {
                if (v.HitTest(e))
                {
                    vCur = v;
                    vCur.OnMouseDown(e);
                    break;
                }
            }
        }
        public void OnMouseUp(MouseEventArgs e)
        {
            isDown = false;
            if (vCur != null)
            {
                vCur.OnMouseUp(e);
                UpdateBounds();
                Invalidate?.Invoke();
            }
        }
        public void OnMouseMove(MouseEventArgs e)
        {
            setCursor(Cursors.SizeAll);

            if (isForcused)
            {
                foreach (var v in Vertices)
                {
                    if (v.HitTest(e))
                    {
                        v.OnMouseMove(e);
                        break;
                    }
                }
            }

            if (isDown)
            {
                if (vCur == null)
                {
                    Left += e.X - pStart.X;
                    Top += e.Y - pStart.Y;

                    foreach (var v in Vertices)
                    {
                        v.X += e.X - pStart.X;
                        v.Y += e.Y - pStart.Y;
                    }
                    pStart = e.Location;
                }
                else
                {
                    vCur.OnMouseMove(e);
                }

                Invalidate?.Invoke();
            }
        }
        public bool HitTest(MouseEventArgs e)
        {
            if (gpHitTest == null) return false;

            if (isForcused)
            {
                foreach (var v in Vertices)
                {
                    if (v.HitTest(e))
                    {
                        return true;
                    }
                }
            }

            if (isFill)
            {
                return gpHitTest.IsVisible(e.Location) || gpHitTest.IsOutlineVisible(e.Location, penHL);
            }

            return gpHitTest.IsOutlineVisible(e.Location, penHL);
        }
        public bool HitTestAll(MouseEventArgs e)
        {
            if (gpHitTest == null) return false;

            return gpHitTest.IsVisible(e.Location) || gpHitTest.IsOutlineVisible(e.Location, penHL);

        }

        protected List<Vertex> Vertices = new List<Vertex>();
        protected Vertex vCur;

        protected virtual void UpdateBounds() { }
        protected virtual void GetPathContent(ref GraphicsPath gp) { }

        private Pen penHL;
        private Pen penDraw;

        private bool isDown = false;
        private Point pStart;
        private GraphicsPath gpHitTest;
    }
}
