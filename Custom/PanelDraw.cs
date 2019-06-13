using Do_An_3.Sockets;
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
    public class PanelDraw : Panel
    {
        public delegate void ChangeColorEventHandler(Color rgb);
        public ChangeColorEventHandler ChangeColorEvent;
        public delegate void ChangeWidthEventHandler(float width);
        public ChangeWidthEventHandler ChangeWidthEvent;
        public delegate void ChangeBrushesEventHandler(DashStyle ds);
        public ChangeBrushesEventHandler ChangeBrushesEvent;
        public delegate void NonselectedHandler(bool isNon);
        public NonselectedHandler Nonselected;
        public delegate void DetectSocketHandler(string Status, string IP, int PORT);
        public DetectSocketHandler DetectSocket;
        public delegate void ClientStatusHandler(int count);
        public ClientStatusHandler ClientStatus;

        public Form1.DrawMode DrawMode { get; set; }
        public Bitmap buffer, backbuffer;

        public PanelDraw()
        {
            dsHinh.Add(0, new List<BasicDraw>());

            Vertex.setCursor = (s) => { Cursor = s; };
            BasicDraw.setCursor = (s) => { Cursor = s; };

            PolygonTemp = new List<Point>();

            BackColor = Color.White;
            buffer = new Bitmap(Width, Height);
            backbuffer = new Bitmap(Width, Height);

            using (var g = Graphics.FromImage(backbuffer))
            {
                var br = new SolidBrush(BackColor);
                g.FillRectangle(br, 0, 0, Width, Height);
            }
        }

        public void ChangeColor(Color rgb)
        {
            if (drawCur != null)
            {
                drawCur.pen.Color = rgb;

                Invalidate();
                ChangeColorEvent?.Invoke(rgb);
                Updates();
            }
            else
            {
                penLast.Color = rgb;

                returnOldPen();
            }
        }
        public void ChangeWidth(float width)
        {
            if (drawCur != null)
            {
                drawCur.pen.Width = width;
                drawCur.pen = drawCur.pen; //call event set

                Invalidate();
                ChangeWidthEvent?.Invoke(drawCur.pen.Width);
                Updates();
            }
            else
            {
                penLast.Width = width;

                returnOldPen();
            }
        }
        public void ChangeBrushes(DashStyle ds)
        {
            if (drawCur != null)
            {
                drawCur.pen.DashStyle = ds;
                Invalidate();
                ChangeWidthEvent?.Invoke(drawCur.pen.Width);
                Updates();
            }
            else
            {
                penLast.DashStyle = ds;
                returnOldPen();
            }
        }
        public void ChangeType()
        {
            AddPolygon();
            if (DrawMode != Form1.DrawMode.select && drawCur != null)
            {
                drawCur.isForcused = false;
                drawCur = null;
                Nonselected?.Invoke(false);
                Invalidate();
                returnOldPen();
            }

        }
        public BasicDraw CopyCur()
        {
            AddPolygon();
            if (drawCur != null)
            {
                return drawCur.clone();
            }
            return null;
        }
        public void PasteData(BasicDraw bd)
        {
            AddPolygon();
            var Shapes = dsHinh[0];
            Shapes.Add(bd);
            Invalidate();
            Updates();
        }
        public void DeleteShape()
        {
            AddPolygon();
            var Shapes = dsHinh[0];
            Shapes.Remove(drawCur);
            drawCur = null;
            Nonselected?.Invoke(false);
            Invalidate();
            Updates();
            returnOldPen();
        }
        //
        public bool MakeServer(string IP, int PORT)
        {
            isSV = true;
            se = new SocketExt(IP, PORT, true);
            se.ReceiveData = Reload;
            se.ExitDraw = ExitDraw;
            se.ClientStatus = (s) => ClientStatus?.Invoke(s);

            if (!se.MakeSV())
            {
                DetectSocket?.Invoke("Disconnect", "0.0.0.0", 0);
                return false;
            }
            DetectSocket?.Invoke("Listening", IP, PORT);
            ClientStatus?.Invoke(0);
            return true;
        }
        public bool ConnectServer(string IP, int PORT)
        {
            isSV = false;
            se = new SocketExt(IP, PORT, false);
            se.ReceiveData = Reload;
            se.ExitDraw = ExitDraw;

            if (!se.ConnectSV())
            {
                DetectSocket?.Invoke("Disconnect", "0.0.0.0", 0);
                return false;
            }
            DetectSocket?.Invoke("Connecting", IP, PORT);
            Updates();
            return true;
        }
        public void Disconnect()
        {
            if (se != null)
                se.Release();
            se = null;
            DetectSocket?.Invoke("Disconnect", "0.0.0.0", 0);
            ClientStatus?.Invoke(-1);
        }
        //
        //
        public string SavePj()
        {
            string data = "0;";
            foreach (var t in dsHinh[0])
            {
                data += t + ";";
            }
            return data;
        }
        public void LoadPj(string Data)
        {
            dsHinh.Clear();
            Reload(Data);
        }
        //
        //   
        protected override void CreateHandle()
        {
            base.CreateHandle();
            returnOldPen();
        }
        protected override void OnResize(EventArgs eventargs)
        {
            if (buffer != null)
            {
                buffer.Dispose();
            }
            if (backbuffer != null)
            {
                backbuffer.Dispose();
            }

            if (Width == 0 || Width == 0) return;

            buffer = new Bitmap(Width, Height);
            backbuffer = new Bitmap(Width, Height);

            using (var g = Graphics.FromImage(backbuffer))
            {
                var br = new SolidBrush(BackColor);
                g.FillRectangle(br, 0, 0, Width, Height);
            }
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //base.OnPaintBackground(e);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;

            using (var gb = Graphics.FromImage(buffer))
            {
                gb.SmoothingMode = SmoothingMode.HighQuality;

                gb.DrawImage(backbuffer, 0, 0, Width, Height);

                Dictionary<int, List<BasicDraw>> dsHinhTemp = new Dictionary<int, List<BasicDraw>>(dsHinh);
                foreach (var hinh in dsHinhTemp)
                {
                    foreach (var bd in hinh.Value)
                    {
                        bd.Draw(gb);
                    }
                }

                if (isDown || DrawMode == Form1.DrawMode.polygon)
                {
                    switch (DrawMode)
                    {
                        case Form1.DrawMode.line:
                            gb.DrawLine(penCur, pStart, pEnd);
                            break;
                        case Form1.DrawMode.rectangle:
                            Rectangle rt = new Rectangle
                            {
                                X = Math.Min(pStart.X, pEnd.X),
                                Y = Math.Min(pStart.Y, pEnd.Y),
                                Width = Math.Abs(pStart.X - pEnd.X),
                                Height = Math.Abs(pStart.Y - pEnd.Y),
                            };
                            gb.DrawRectangle(penCur, rt);
                            break;
                        case Form1.DrawMode.eplise:
                            rt = new Rectangle
                            {
                                X = Math.Min(pStart.X, pEnd.X),
                                Y = Math.Min(pStart.Y, pEnd.Y),
                                Width = Math.Abs(pStart.X - pEnd.X),
                                Height = Math.Abs(pStart.Y - pEnd.Y),
                            };
                            gb.DrawEllipse(penCur, rt);
                            break;
                        case Form1.DrawMode.circle:
                            int min = Math.Min(Math.Abs(pStart.X - pEnd.X), Math.Abs(pStart.Y - pEnd.Y));
                            rt = new Rectangle
                            {
                                X = pStart.X,
                                Y = pStart.Y,
                                Width = min,
                                Height = min,
                            };
                            if (pStart.X > pEnd.X) rt.X -= min;
                            if (pStart.Y > pEnd.Y) rt.Y -= min;
                            gb.DrawEllipse(penCur, rt);
                            break;
                        case Form1.DrawMode.polygon:
                            if (PolygonTemp.Count < 2)
                            {
                                gb.DrawLine(penCur, pStart, pEnd);
                            }
                            else
                            {
                                List<Point> listPoint = new List<Point>(PolygonTemp);
                                listPoint.Add(pEnd);
                                gb.DrawPolygon(penCur, listPoint.ToArray());
                            }
                            break;
                    }
                }
            }
            g.DrawImage(buffer, 0, 0, Width, Height);
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            isDown = true;
            pEnd = pStart = e.Location;
            if (DrawMode == Form1.DrawMode.fillcolor)
            {
                var Shapes = dsHinh[0];

                foreach (var bd in Shapes)
                {
                    var checkline = bd as LineDraw;
                    if (checkline == null && bd.HitTestAll(e))
                    {
                        bd.isFill = true;
                        bd.pen.Color = penLast.Color;
                        Invalidate();
                        Updates();
                        break;
                    }
                }
            }
            else if (DrawMode == Form1.DrawMode.polygon)
            {
                if (PolygonTemp.Count > 1)
                {
                    Invalidate();
                }
            }
            else if (DrawMode == Form1.DrawMode.select)
            {
                bool needInvalidate = false;
                if (drawCur != null && !drawCur.HitTest(e))
                {
                    drawCur.isForcused = false;
                    drawCur = null;
                    needInvalidate = true;
                }
                if (drawCur == null)
                {
                    var Shapes = dsHinh[0];

                    foreach (var bd in Shapes)
                    {
                        if (bd.HitTest(e))
                        {
                            drawCur = bd;
                            drawCur.isForcused = true;
                            needInvalidate = true;
                            SelectedDrawCur();
                            break;
                        }
                    }
                }
                if (needInvalidate)
                {
                    Invalidate();
                }

                if (drawCur != null)
                {
                    Nonselected?.Invoke(true);
                    drawCur.OnMouseDown(e);
                }
                else
                {
                    Nonselected?.Invoke(false);
                    returnOldPen();
                }
            }

        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (!isDown)
            {
                if (DrawMode == Form1.DrawMode.fillcolor)
                {
                    Cursor = Cursors.Hand;
                }
                else
                {
                    Cursor = Cursors.Default;
                }
            }

            if (DrawMode == Form1.DrawMode.select)
            {
                var Shapes = dsHinh[0];

                foreach (var bd in Shapes)
                {
                    if (bd.HitTest(e))
                    {
                        bd.OnMouseMove(e);
                        break;
                    }
                }
            }


            if (isDown)
            {
                bool isNonSelect = true;
                switch (DrawMode)
                {
                    case Form1.DrawMode.line:
                        pEnd = e.Location;
                        break;
                    case Form1.DrawMode.rectangle:
                        pEnd = e.Location;
                        break;
                    case Form1.DrawMode.eplise:
                        pEnd = e.Location;
                        break;
                    case Form1.DrawMode.circle:
                        pEnd = e.Location;
                        break;
                    case Form1.DrawMode.polygon:
                        pEnd = e.Location;
                        break;
                    case Form1.DrawMode.select:
                        isNonSelect = false;
                        break;
                    case Form1.DrawMode.fillcolor:
                        isNonSelect = false;
                        break;
                    default:
                        break;
                }

                if (isNonSelect)
                {
                    Invalidate();
                }
                else if (drawCur != null) // ko phai lo fillcolor vi ko ton tai cur.
                {
                    drawCur.OnMouseMove(e);
                }

            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (isDown)
            {
                isDown = false;
                if (DrawMode == Form1.DrawMode.polygon)
                {
                    if (isDouble)
                    {
                        isDouble = false;
                        AddPolygon();
                    }
                    else
                    {
                        if (PolygonTemp.Count == 0)
                        {
                            if (!pStart.Equals(pEnd))
                            {
                                PolygonTemp.Add(pStart);
                                PolygonTemp.Add(pEnd);
                            }
                        }
                        else if (!PolygonTemp[PolygonTemp.Count - 1].Equals(pEnd))
                        {
                            PolygonTemp.Add(pEnd);
                        }
                    }
                }

                else if (DrawMode != Form1.DrawMode.select)
                {
                    if (pEnd == pStart) return;

                    BasicDraw shape = null;
                    switch (DrawMode)
                    {
                        case Form1.DrawMode.line:
                            shape = new LineDraw(pStart, pEnd, penCur);
                            break;
                        case Form1.DrawMode.rectangle:
                            shape = new RectangleDraw(pStart, pEnd, penCur);
                            break;
                        case Form1.DrawMode.eplise:
                            shape = new ElipseDraw(pStart, pEnd, penCur);
                            break;
                        case Form1.DrawMode.circle:
                            shape = new CircleDraw(pStart, pEnd, penCur);
                            break;
                    }
                    shape.Invalidate = () => Invalidate();
                    var Shapes = dsHinh[0];

                    Shapes.Add(shape);
                    Invalidate();
                    Updates();
                }
                else if (drawCur != null)
                {
                    drawCur.OnMouseUp(e);
                    Updates();
                }
            }

        }
        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            isDouble = true;
        }

        private Dictionary<int, List<BasicDraw>> dsHinh = new Dictionary<int, List<BasicDraw>>();
        private Pen penLast = new Pen(Color.Black, 2);
        private Pen penCur = null;
        private BasicDraw drawCur = null;
        private bool isDown = false;
        private Point pStart, pEnd;
        private List<Point> PolygonTemp;
        private bool isDouble = false;
        private SocketExt se = null;
        private bool isSV = false;

        private void returnOldPen()
        {
            penCur = penLast;
            ChangeColorEvent?.Invoke(penCur.Color);
            ChangeWidthEvent?.Invoke(penCur.Width);
            ChangeBrushesEvent?.Invoke(penCur.DashStyle);
        }
        private void SelectedDrawCur()
        {
            ChangeColorEvent?.Invoke(drawCur.pen.Color);
            ChangeWidthEvent?.Invoke(drawCur.pen.Width);
            ChangeBrushesEvent?.Invoke(drawCur.pen.DashStyle);
            //bringtofont
            var Shapes = dsHinh[0];

            Shapes.Remove(drawCur);
            Shapes.Add(drawCur);
        }
        private void AddPolygon()
        {
            if (PolygonTemp.Count == 0)
            {
                return;
            }
            else
            {
                PolygonDraw pd = new PolygonDraw(PolygonTemp, penCur);
                pd.Invalidate = () => Invalidate();
                var Shapes = dsHinh[0];

                Shapes.Add(pd);
                PolygonTemp.Clear();
                Invalidate();
                Updates();
            }
        }
        //
        private void Updates()
        {
            if (se != null && !se.IsDisopose)
            {
                string data = "";
                if (isSV)
                {
                    foreach (var cl in se.clientList)
                    {
                        string dataall = "";
                        foreach (var hinh in dsHinh)
                        {
                            if (hinh.Key == cl.clientdata.ID) continue;

                            data = hinh.Key.ToString() + ";";

                            if (hinh.Key == 0)
                                data = "-1;";

                            foreach (var t in hinh.Value)
                            {
                                data += t + ";";
                            }
                            dataall += data + "|";
                        }
                        se.Send(cl.client, dataall);
                    }
                }
                else
                {
                    data += se.ID.ToString() + ";";
                    foreach (var t in dsHinh[0])
                    {
                        data += t + ";";
                    }
                    se.Send(se.sl.MySocket, data);
                }
            }
        }
        private void Reload(string data)
        {
            var clientsplit = data.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var clientx in clientsplit)
            {
                var datas = clientx.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                var key = int.Parse(datas[0]);

                if (dsHinh.ContainsKey(key))
                    dsHinh[key].Clear();
                else
                    dsHinh.Add(key, new List<BasicDraw>());
                for (int i = 1; i < datas.Length; i++)
                {
                    string[] hinhsplit = datas[i].Split(new string[] { ".-." }, StringSplitOptions.RemoveEmptyEntries);

                    var loaihinh = (Form1.DrawMode)int.Parse(hinhsplit[0]);
                    BasicDraw bd = null;
                    switch (loaihinh)
                    {
                        case Form1.DrawMode.line:
                            bd = new LineDraw();
                            break;
                        case Form1.DrawMode.rectangle:
                            bd = new RectangleDraw();
                            break;
                        case Form1.DrawMode.eplise:
                            bd = new ElipseDraw();
                            break;
                        case Form1.DrawMode.circle:
                            bd = new CircleDraw();
                            break;
                        case Form1.DrawMode.polygon:
                            bd = new PolygonDraw();
                            break;
                    }
                    bd.Invalidate = () => Invalidate();
                    bd.Restore(datas[i]);
                    dsHinh[key].Add(bd);
                }
            }
            if (isSV) Updates();

            Invalidate();
        }
        private void ExitDraw(int index)
        {
            switch (index)
            {
                case -1:
                    var old = dsHinh[0];
                    var news = old.ToList();
                    dsHinh.Clear();
                    dsHinh.Add(0, news);

                    if (se != null)
                    {
                        DetectSocket?.Invoke("DisconnectClick", "0", 0);
                    }
                    else
                    {
                        Disconnect();
                    }
                    break;
                default:
                    dsHinh[index].Clear();
                    Updates();
                    break;
            }
            Invalidate();
        }
        //
    }
}
