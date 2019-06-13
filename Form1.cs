using Do_An_3.Custom;
using Do_An_3.Sockets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Do_An_3
{
    public partial class Form1 : Form
    {
        public enum DrawMode
        {
            line, rectangle, eplise, circle, polygon, select, fillcolor
        }
        public Form1()
        {
            InitializeComponent();

            tsbtnLine.Tag = DrawMode.line;
            tsbtnRectangle.Tag = DrawMode.rectangle;
            tsbtnElipse.Tag = DrawMode.eplise;
            tsbtnCircle.Tag = DrawMode.circle;
            tsbtnPolygon.Tag = DrawMode.polygon;
            tsbtnSelect.Tag = DrawMode.select;
            tsbtnFillColor.Tag = DrawMode.fillcolor;

            tsbtnLine.Click += tsbtnDrawMode_Click;
            tsbtnRectangle.Click += tsbtnDrawMode_Click;
            tsbtnElipse.Click += tsbtnDrawMode_Click;
            tsbtnCircle.Click += tsbtnDrawMode_Click;
            tsbtnPolygon.Click += tsbtnDrawMode_Click;
            tsbtnSelect.Click += tsbtnDrawMode_Click;
            tsbtnFillColor.Click += tsbtnDrawMode_Click;
            tsbtnSocket.Click += tsbtnSocket_Click;

            tsbtnLoad.Click += TsbtnLoad_Click;
            tsbtnSave.Click += TsbtnSave_Click;
            tsbtnExport.Click += TsbtnExport_Click;

            tssbtnCopy.Click += TssbtnCopy_Click;
            tssbtnPaste.Click += TssbtnPaste_Click;
            tssbtnDelete.Click += TssbtnDelete_Click; ;
            tssbtnDelete.Enabled = tssbtnCopy.Enabled = tssbtnPaste.Enabled = false;

            pnMain.ChangeColorEvent = ChangeColorEvent;
            pnMain.ChangeWidthEvent = ChangeWidthEvent;
            pnMain.ChangeBrushesEvent = ChangeBrushesEvent;
            pnMain.ClientStatus = ClientStatus;
            pnMain.Nonselected = (t) => tssbtnDelete.Enabled = tssbtnCopy.Enabled = t;
            pnMain.MouseMove += (s, e) => tsslblMouseLocation.Text = $"{e.X}, {e.Y} px";
            pnMain.MouseLeave += (s, e) => tsslblMouseLocation.Text = "                ";

            pnMain.DrawMode = DrawMode.line;
            NormalColor = tsbtnLine.BackColor;
            tsbtnOld = tsbtnLine;
            tsbtnOld.BackColor = SelectedColor;

            tstxtWidth.TextChanged += TstxtWidth_TextChanged;
            tstxtWidth.KeyPress += TstxtWidth_KeyPress;

            tsddbtnSelectColor.Click += TsddbtnSelectColor_Click;

            for (int i = 10; i > 0; i -= 1)
            {
                var tsmi = new ToolStripMenuItem
                {
                    Text = string.Format($"{i} px"),
                    Tag = i
                };
                tsddbtnSelectWidth.DropDownItems.Insert(0, tsmi);
                tsmi.Click += (s, e) => pnMain.ChangeWidth((int)tsmi.Tag);
            }

            for (int i = 0; i < 5; i++)
            {
                var tsmi = new ToolStripMenuItem
                {
                    Text = ((DashStyle)i).ToString(),
                    Tag = (DashStyle)i
                };
                tsddbtnSelectBrushes.DropDownItems.Add(tsmi);
                tsmi.Click += (s, e) => pnMain.ChangeBrushes((DashStyle)tsmi.Tag);
            }

            pnMain.DetectSocket = (a, b, c) =>
            {
                if (a == "DisconnectClick")
                {
                    tsbtnSocket_Click(null, null);
                    return;
                }
                tsslblStatus.Text = a;
                tsslblIP.Text = b;
                tsslblPort.Text = c.ToString();
            };

            FormClosed += (s, e) => pnMain.Disconnect();
        }
        private void TsbtnLoad_Click(object sender, EventArgs e)
        {
            using (var loadfdiag = new OpenFileDialog())
            {
                loadfdiag.Filter = "1760357Project3|*.pj3";
                loadfdiag.Title = "Open Project 3 File...";
                if (loadfdiag.ShowDialog() == DialogResult.OK)
                {
                    pnMain.LoadPj(File.ReadAllText(loadfdiag.FileName));
                }
            }
        }
        private void TsbtnSave_Click(object sender, EventArgs e)
        {
            using (var savefdiag = new SaveFileDialog())
            {
                savefdiag.Filter = "1760357Project3|*.pj3";
                savefdiag.Title = "Save Project 3 File...";
                if (savefdiag.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(savefdiag.FileName, pnMain.SavePj());
                }
            }
        }
        private void TsbtnExport_Click(object sender, EventArgs e)
        {
            using (var exfdiag = new SaveFileDialog())
            {
                exfdiag.Filter = "Images|*.png;*.bmp;*.jpg";
                exfdiag.Title = "Export To Image File...";
                ImageFormat format = ImageFormat.Png;
                if (exfdiag.ShowDialog() == DialogResult.OK)
                {
                    string ext = Path.GetExtension(exfdiag.FileName);
                    switch (ext)
                    {
                        case ".jpg":
                            format = ImageFormat.Jpeg;
                            break;
                        case ".bmp":
                            format = ImageFormat.Bmp;
                            break;
                    }
                    pnMain.buffer.Save(exfdiag.FileName, format);
                }
            }
        }

        private Color NormalColor, SelectedColor = Color.FromArgb(179, 215, 243);
        private ToolStripButton tsbtnOld;
        private BasicDraw CopyCur;

        private void tsbtnSocket_Click(object sender, EventArgs e)
        {
            if (tsbtnSocket.ToolTipText == "Disconnect")
            {
                tsbtnSocket.ToolTipText = "Connect/Make";
                tsbtnSocket.Image = Properties.Resources.icons8_internet_40;
                pnMain.Disconnect();
                return;
            }
            using (var frmsoc = new frmSocket())
            {
                string Ip = "127.0.0.1";
                int Port = 1234;
                frmsoc.GetData = (a, b) =>
                {
                    Ip = a;
                    Port = b;
                };
                frmsoc.StartPosition = FormStartPosition.CenterParent;
                switch (frmsoc.ShowDialog())
                {
                    case DialogResult.Retry:
                        if (!pnMain.ConnectServer(Ip, Port)) return;
                        break;
                    case DialogResult.Yes: // make
                        if (!pnMain.MakeServer(Ip, Port)) return;
                        break;
                    default:
                        return;
                }
                tsbtnSocket.ToolTipText = "Disconnect";
                tsbtnSocket.Image = Properties.Resources.icons8_broken_link_40;
            }
        }
        private void TssbtnDelete_Click(object sender, EventArgs e)
        {
            pnMain.DeleteShape();
        }
        private void TssbtnPaste_Click(object sender, EventArgs e)
        {
            pnMain.PasteData(CopyCur.clone());
        }
        private void TssbtnCopy_Click(object sender, EventArgs e)
        {
            tssbtnPaste.Enabled = true;
            CopyCur = pnMain.CopyCur();
        }
        private void TsddbtnSelectColor_Click(object sender, EventArgs e)
        {
            using (var cdg = new ColorDialog())
            {
                if (cdg.ShowDialog() == DialogResult.OK)
                {
                    pnMain.ChangeColor(cdg.Color);
                }
            }
        }
        private void TstxtWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void TstxtWidth_TextChanged(object sender, EventArgs e)
        {
            int width;
            if (!int.TryParse(tstxtWidth.Text, out width))
            {
                tstxtWidth.Text = "";
                width = 1;
            }
            pnMain.ChangeWidth(width);
        }
        private void tsbtnDrawMode_Click(object sender, EventArgs e)
        {
            if (tsbtnOld != null)
            {
                tsbtnOld.BackColor = NormalColor;
            }
            tsbtnOld = sender as ToolStripButton;
            tsbtnOld.BackColor = SelectedColor;

            pnMain.DrawMode = (DrawMode)tsbtnOld.Tag;
            pnMain.ChangeType();
        }
        private void ChangeColorEvent(Color rgb)
        {
            Bitmap tmpColor = new Bitmap(25, 25);
            using (var g = Graphics.FromImage(tmpColor))
            {
                g.FillRectangle(new SolidBrush(rgb), 0, 0, 25, 25);
            }
            tsbtnStatusColor.Image = tmpColor;
        }
        private void ChangeWidthEvent(float width)
        {
            tsbtnStatusWidth.Text = string.Format("Width: {0}px", width);
        }
        private void ChangeBrushesEvent(DashStyle ds)
        {
            tsbtnStatusBrushes.Text = "Brushes: " + ds.ToString();

            Bitmap tmpBrs = new Bitmap(60, 25);
            using (var g = Graphics.FromImage(tmpBrs))
            {
                Pen tmpP = new Pen(Color.Black, 4);
                tmpP.DashStyle = ds;
                g.DrawLine(tmpP, 0, 13, 60, 13);
            }
            tsbtnStatusBrushes.Image = tmpBrs;
        }
        private void ClientStatus(int count)
        {
            if (count == -1) tsslblCount.Text = "";
            else tsslblCount.Text = $"Clients: {count}";
        }
    }
}
