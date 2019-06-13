using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_An_3.Sockets
{
    public partial class frmSocket : Form
    {
        public delegate void GetDataHandler(string Ip, int Port);
        public GetDataHandler GetData;
        public frmSocket()
        {
            InitializeComponent();
            btnMake.Click += btnMake_Click;
            btnConnect.Click += btnConnect_Click;
            txtPort.KeyPress += TxtPort_KeyPress;
            DialogResult = DialogResult.No;
        }

        private void TxtPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Retry;
            int Port;
            if (!int.TryParse(txtPort.Text, out Port))
            {
                Port = 0;
            }
            GetData?.Invoke(txtIP.Text, Port);
        }
        private void btnMake_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            int Port;
            if (!int.TryParse(txtPort.Text, out Port))
            {
                Port = 0;
            }
            GetData?.Invoke(txtIP.Text, Port);
        }
    }
}
