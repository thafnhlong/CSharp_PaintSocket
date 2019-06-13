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
    public class SurfaceDraw : Control
    {
        public Panel Parent { get; set; }
        public delegate void DrawContentHandle(Graphics g);
        protected DrawContentHandle drawContent;

        public List<Point> Vertexes { get; set; }
        public Pen pen { get; set; } = new Pen(Color.Black, 2);

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x20;
                return cp;
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //base.OnPaintBackground(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            drawContent?.Invoke(e.Graphics);
            //base.OnPaint(e);    
        }

        bool isDown = false;
        Point pStart;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            isDown = true;
            pStart = e.Location;
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            isDown = false;
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (isDown)
            {
                Left += e.X - pStart.X;
                Top += e.Y - pStart.Y;
                Parent.Invalidate();
            }
        }
    }
}
