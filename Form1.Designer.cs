namespace Do_An_3
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblIP = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblPort = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsslblCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnLine = new System.Windows.Forms.ToolStripButton();
            this.tsbtnRectangle = new System.Windows.Forms.ToolStripButton();
            this.tsbtnElipse = new System.Windows.Forms.ToolStripButton();
            this.tsbtnCircle = new System.Windows.Forms.ToolStripButton();
            this.tsbtnPolygon = new System.Windows.Forms.ToolStripButton();
            this.tsbtnSelect = new System.Windows.Forms.ToolStripButton();
            this.tsbtnFillColor = new System.Windows.Forms.ToolStripButton();
            this.tsbtnStatusColor = new System.Windows.Forms.ToolStripButton();
            this.tsddbtnSelectColor = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbtnStatusWidth = new System.Windows.Forms.ToolStripButton();
            this.tsddbtnSelectWidth = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tstxtWidth = new System.Windows.Forms.ToolStripTextBox();
            this.tsbtnStatusBrushes = new System.Windows.Forms.ToolStripButton();
            this.tsddbtnSelectBrushes = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbtnSocket = new System.Windows.Forms.ToolStripButton();
            this.tsbtnLoad = new System.Windows.Forms.ToolStripButton();
            this.tsbtnSave = new System.Windows.Forms.ToolStripButton();
            this.tsbtnExport = new System.Windows.Forms.ToolStripButton();
            this.tssbtnCopy = new System.Windows.Forms.ToolStripSplitButton();
            this.tssbtnPaste = new System.Windows.Forms.ToolStripSplitButton();
            this.tssbtnDelete = new System.Windows.Forms.ToolStripSplitButton();
            this.tsslblMouseLocation = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnMain = new Do_An_3.Custom.PanelDraw();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tssbtnCopy,
            this.tssbtnPaste,
            this.tssbtnDelete,
            this.tsslblMouseLocation,
            this.toolStripStatusLabel2,
            this.tsslblStatus,
            this.toolStripStatusLabel3,
            this.tsslblIP,
            this.toolStripStatusLabel5,
            this.tsslblPort,
            this.tsslblCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 416);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(834, 25);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(59, 20);
            this.toolStripStatusLabel1.Text = "Optional: ";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(46, 20);
            this.toolStripStatusLabel2.Text = "Socket";
            // 
            // tsslblStatus
            // 
            this.tsslblStatus.Name = "tsslblStatus";
            this.tsslblStatus.Size = new System.Drawing.Size(66, 20);
            this.tsslblStatus.Text = "Disconnect";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(24, 20);
            this.toolStripStatusLabel3.Text = "IP:";
            // 
            // tsslblIP
            // 
            this.tsslblIP.Name = "tsslblIP";
            this.tsslblIP.Size = new System.Drawing.Size(40, 20);
            this.tsslblIP.Text = "0.0.0.0";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabel5.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(43, 20);
            this.toolStripStatusLabel5.Text = "PORT:";
            // 
            // tsslblPort
            // 
            this.tsslblPort.Name = "tsslblPort";
            this.tsslblPort.Size = new System.Drawing.Size(13, 20);
            this.tsslblPort.Text = "0";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnLine,
            this.tsbtnRectangle,
            this.tsbtnElipse,
            this.tsbtnCircle,
            this.tsbtnPolygon,
            this.toolStripSeparator1,
            this.tsbtnSelect,
            this.toolStripSeparator2,
            this.tsbtnFillColor,
            this.toolStripSeparator4,
            this.tsbtnStatusColor,
            this.tsddbtnSelectColor,
            this.toolStripSeparator5,
            this.tsbtnStatusWidth,
            this.tsddbtnSelectWidth,
            this.toolStripSeparator6,
            this.tsbtnStatusBrushes,
            this.tsddbtnSelectBrushes,
            this.toolStripSeparator3,
            this.tsbtnSocket,
            this.toolStripSeparator8,
            this.tsbtnLoad,
            this.tsbtnSave,
            this.toolStripSeparator9,
            this.tsbtnExport});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(834, 32);
            this.toolStrip1.TabIndex = 1;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 32);
            // 
            // tsslblCount
            // 
            this.tsslblCount.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tsslblCount.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.tsslblCount.Name = "tsslblCount";
            this.tsslblCount.Size = new System.Drawing.Size(4, 20);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 32);
            // 
            // tsbtnLine
            // 
            this.tsbtnLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnLine.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnLine.Image")));
            this.tsbtnLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnLine.Name = "tsbtnLine";
            this.tsbtnLine.Size = new System.Drawing.Size(29, 29);
            this.tsbtnLine.Text = "Line";
            // 
            // tsbtnRectangle
            // 
            this.tsbtnRectangle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnRectangle.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnRectangle.Image")));
            this.tsbtnRectangle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRectangle.Name = "tsbtnRectangle";
            this.tsbtnRectangle.Size = new System.Drawing.Size(29, 29);
            this.tsbtnRectangle.Text = "Rectangle";
            // 
            // tsbtnElipse
            // 
            this.tsbtnElipse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnElipse.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnElipse.Image")));
            this.tsbtnElipse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnElipse.Name = "tsbtnElipse";
            this.tsbtnElipse.Size = new System.Drawing.Size(29, 29);
            this.tsbtnElipse.Text = "Elipse";
            // 
            // tsbtnCircle
            // 
            this.tsbtnCircle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnCircle.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnCircle.Image")));
            this.tsbtnCircle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnCircle.Name = "tsbtnCircle";
            this.tsbtnCircle.Size = new System.Drawing.Size(29, 29);
            this.tsbtnCircle.Text = "Circle";
            // 
            // tsbtnPolygon
            // 
            this.tsbtnPolygon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnPolygon.Image = global::Do_An_3.Properties.Resources.icons8_polygon_40;
            this.tsbtnPolygon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnPolygon.Name = "tsbtnPolygon";
            this.tsbtnPolygon.Size = new System.Drawing.Size(29, 29);
            this.tsbtnPolygon.Text = "Polygon";
            // 
            // tsbtnSelect
            // 
            this.tsbtnSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnSelect.Image = global::Do_An_3.Properties.Resources.icons8_cursor_40;
            this.tsbtnSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSelect.Name = "tsbtnSelect";
            this.tsbtnSelect.Size = new System.Drawing.Size(29, 29);
            this.tsbtnSelect.Text = "Select";
            // 
            // tsbtnFillColor
            // 
            this.tsbtnFillColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnFillColor.Image = global::Do_An_3.Properties.Resources.icons8_fill_color_40;
            this.tsbtnFillColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnFillColor.Name = "tsbtnFillColor";
            this.tsbtnFillColor.Size = new System.Drawing.Size(29, 29);
            this.tsbtnFillColor.Text = "Fill";
            // 
            // tsbtnStatusColor
            // 
            this.tsbtnStatusColor.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnStatusColor.Image")));
            this.tsbtnStatusColor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnStatusColor.ImageTransparentColor = System.Drawing.SystemColors.Control;
            this.tsbtnStatusColor.Name = "tsbtnStatusColor";
            this.tsbtnStatusColor.Size = new System.Drawing.Size(62, 29);
            this.tsbtnStatusColor.Text = "Color: ";
            this.tsbtnStatusColor.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.tsbtnStatusColor.ToolTipText = "Color of Tool";
            // 
            // tsddbtnSelectColor
            // 
            this.tsddbtnSelectColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsddbtnSelectColor.Image = global::Do_An_3.Properties.Resources.icons8_paint_palette_40;
            this.tsddbtnSelectColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddbtnSelectColor.Name = "tsddbtnSelectColor";
            this.tsddbtnSelectColor.Size = new System.Drawing.Size(38, 29);
            this.tsddbtnSelectColor.Text = "Color";
            this.tsddbtnSelectColor.ToolTipText = "Color";
            // 
            // tsbtnStatusWidth
            // 
            this.tsbtnStatusWidth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnStatusWidth.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnStatusWidth.Image")));
            this.tsbtnStatusWidth.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnStatusWidth.Name = "tsbtnStatusWidth";
            this.tsbtnStatusWidth.Size = new System.Drawing.Size(23, 29);
            this.tsbtnStatusWidth.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.tsbtnStatusWidth.ToolTipText = "Width of Tool";
            // 
            // tsddbtnSelectWidth
            // 
            this.tsddbtnSelectWidth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsddbtnSelectWidth.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator7,
            this.tstxtWidth});
            this.tsddbtnSelectWidth.Image = global::Do_An_3.Properties.Resources.icons8_line_width_40;
            this.tsddbtnSelectWidth.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddbtnSelectWidth.Name = "tsddbtnSelectWidth";
            this.tsddbtnSelectWidth.Size = new System.Drawing.Size(38, 29);
            this.tsddbtnSelectWidth.Text = "Width";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(157, 6);
            // 
            // tstxtWidth
            // 
            this.tstxtWidth.Name = "tstxtWidth";
            this.tstxtWidth.Size = new System.Drawing.Size(100, 23);
            this.tstxtWidth.Text = "Enter here";
            // 
            // tsbtnStatusBrushes
            // 
            this.tsbtnStatusBrushes.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnStatusBrushes.Image")));
            this.tsbtnStatusBrushes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnStatusBrushes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnStatusBrushes.Name = "tsbtnStatusBrushes";
            this.tsbtnStatusBrushes.Size = new System.Drawing.Size(23, 29);
            this.tsbtnStatusBrushes.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // tsddbtnSelectBrushes
            // 
            this.tsddbtnSelectBrushes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsddbtnSelectBrushes.Image = global::Do_An_3.Properties.Resources.icons8_paint_40;
            this.tsddbtnSelectBrushes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddbtnSelectBrushes.Name = "tsddbtnSelectBrushes";
            this.tsddbtnSelectBrushes.Size = new System.Drawing.Size(38, 29);
            this.tsddbtnSelectBrushes.Text = "Brushes";
            // 
            // tsbtnSocket
            // 
            this.tsbtnSocket.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnSocket.Image = global::Do_An_3.Properties.Resources.icons8_internet_40;
            this.tsbtnSocket.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSocket.Name = "tsbtnSocket";
            this.tsbtnSocket.Size = new System.Drawing.Size(29, 29);
            this.tsbtnSocket.ToolTipText = "Connect/Make";
            // 
            // tsbtnLoad
            // 
            this.tsbtnLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnLoad.Image = global::Do_An_3.Properties.Resources.icons8_opened_folder_40;
            this.tsbtnLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnLoad.Name = "tsbtnLoad";
            this.tsbtnLoad.Size = new System.Drawing.Size(29, 29);
            this.tsbtnLoad.Text = "Open File";
            // 
            // tsbtnSave
            // 
            this.tsbtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnSave.Image = global::Do_An_3.Properties.Resources.icons8_save_as_40;
            this.tsbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSave.Name = "tsbtnSave";
            this.tsbtnSave.Size = new System.Drawing.Size(29, 29);
            this.tsbtnSave.Text = "Save File";
            // 
            // tsbtnExport
            // 
            this.tsbtnExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnExport.Image = global::Do_An_3.Properties.Resources.icons8_export_pdf_40;
            this.tsbtnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnExport.Name = "tsbtnExport";
            this.tsbtnExport.Size = new System.Drawing.Size(29, 29);
            this.tsbtnExport.Text = "Export File";
            // 
            // tssbtnCopy
            // 
            this.tssbtnCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tssbtnCopy.DropDownButtonWidth = 0;
            this.tssbtnCopy.Image = ((System.Drawing.Image)(resources.GetObject("tssbtnCopy.Image")));
            this.tssbtnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssbtnCopy.Name = "tssbtnCopy";
            this.tssbtnCopy.Size = new System.Drawing.Size(40, 23);
            this.tssbtnCopy.Text = "Copy";
            // 
            // tssbtnPaste
            // 
            this.tssbtnPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tssbtnPaste.DropDownButtonWidth = 0;
            this.tssbtnPaste.Image = ((System.Drawing.Image)(resources.GetObject("tssbtnPaste.Image")));
            this.tssbtnPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssbtnPaste.Name = "tssbtnPaste";
            this.tssbtnPaste.Size = new System.Drawing.Size(40, 23);
            this.tssbtnPaste.Text = "Paste";
            // 
            // tssbtnDelete
            // 
            this.tssbtnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tssbtnDelete.DropDownButtonWidth = 0;
            this.tssbtnDelete.Image = ((System.Drawing.Image)(resources.GetObject("tssbtnDelete.Image")));
            this.tssbtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssbtnDelete.Name = "tssbtnDelete";
            this.tssbtnDelete.Size = new System.Drawing.Size(45, 23);
            this.tssbtnDelete.Text = "Delete";
            // 
            // tsslblMouseLocation
            // 
            this.tsslblMouseLocation.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tsslblMouseLocation.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.tsslblMouseLocation.Image = global::Do_An_3.Properties.Resources.icons8_drag_24;
            this.tsslblMouseLocation.Name = "tsslblMouseLocation";
            this.tsslblMouseLocation.Size = new System.Drawing.Size(60, 20);
            this.tsslblMouseLocation.Text = "0, 0 px";
            // 
            // pnMain
            // 
            this.pnMain.BackColor = System.Drawing.Color.White;
            this.pnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMain.DrawMode = Do_An_3.Form1.DrawMode.line;
            this.pnMain.Location = new System.Drawing.Point(0, 32);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(834, 384);
            this.pnMain.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 441);
            this.Controls.Add(this.pnMain);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.MinimumSize = new System.Drawing.Size(850, 480);
            this.Name = "Form1";
            this.Text = "Bé tập vẽ cùng nhau - 1760357";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnLine;
        private System.Windows.Forms.ToolStripButton tsbtnRectangle;
        private System.Windows.Forms.ToolStripButton tsbtnElipse;
        private System.Windows.Forms.ToolStripButton tsbtnCircle;
        private System.Windows.Forms.ToolStripButton tsbtnPolygon;
        private System.Windows.Forms.ToolStripButton tsbtnSelect;
        private System.Windows.Forms.ToolStripButton tsbtnFillColor;
        private Custom.PanelDraw pnMain;
        private System.Windows.Forms.ToolStripDropDownButton tsddbtnSelectColor;
        private System.Windows.Forms.ToolStripDropDownButton tsddbtnSelectBrushes;
        private System.Windows.Forms.ToolStripDropDownButton tsddbtnSelectWidth;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripTextBox tstxtWidth;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbtnStatusColor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton tsbtnStatusWidth;
        private System.Windows.Forms.ToolStripButton tsbtnStatusBrushes;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripSplitButton tssbtnCopy;
        private System.Windows.Forms.ToolStripSplitButton tssbtnPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel tsslblStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel tsslblIP;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel tsslblPort;
        private System.Windows.Forms.ToolStripButton tsbtnSocket;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripStatusLabel tsslblMouseLocation;
        private System.Windows.Forms.ToolStripSplitButton tssbtnDelete;
        private System.Windows.Forms.ToolStripStatusLabel tsslblCount;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton tsbtnLoad;
        private System.Windows.Forms.ToolStripButton tsbtnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton tsbtnExport;
    }
}

