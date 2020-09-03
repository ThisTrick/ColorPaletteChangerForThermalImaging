using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorPaletteChangerForThermalImaging
{
    public partial class MainForm : Form
    {
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void pbColorPalette_Click(object sender, EventArgs e)
        {
            using (SelectingColorPalette selectingColor = new SelectingColorPalette())
            {
                var dialogResult = selectingColor.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    var bitmapColorPalette = selectingColor.Tag as Bitmap;
                    pbColorPalette.Image = bitmapColorPalette ?? pbColorPalette.Image;
                }

            }
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
