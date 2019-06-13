using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_An_3.Custom
{
    public class PanelDoubleBuffer : Panel
    {
        ObjectDraw obj = new ObjectDraw
        {
            Left = 100,
            Top = 10
        };
        public PanelDoubleBuffer()
        {
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            //foreach (SurfaceDraw sd in Controls)
            //{
            //    sd.Invalidate();
            //}

            obj.Draw(e.Graphics);

            base.OnPaint(e);
        }

        bool isDown = false;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (obj.Bounds.Contains(e.Location))
            {
                isDown = true;
                obj.OnMouseDown(e);
            }
            //base.OnMouseDown(e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            isDown = false;
            obj.OnMouseUp(e);
            //base.OnMouseUp(e);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (isDown)
            {
                obj.OnMouseMove(e);
                Invalidate();
            }
            //base.OnMouseMove(e);
        }
    }
}
