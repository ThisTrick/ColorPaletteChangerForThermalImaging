﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorPaletteChangerForThermalImaging
{

    public partial class SelectingColorPalette : Form
    {
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);


        private ColorPalette _selectedPalette;
        public SelectingColorPalette()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SelectingColorPalette_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void SelectingColorPalette_Load(object sender, EventArgs e)
        {
            InitColorPalettes("TestImage");
        }

        private void InitColorPalettes(string path)
        {
            List<ColorPalette> colorPalettes = new List<ColorPalette>();

            var images = GetImages(path);
            var x = 0;
            var y = 0;
            foreach (var img in images)
            {
                if (x > 3)
                {
                    y++;
                    x = 0;
                }
                colorPalettes.Add(CreateColorPalette(img, new Point(x, y)));
                x++;
            }
            this.pColorPalettes.Controls.AddRange(colorPalettes.ToArray());
        }

        private ColorPalette CreateColorPalette(Bitmap img, Point locationModificator)
        {
            var colPalette = new ColorPalette();
            colPalette.ColorPaletteName = img.Tag.ToString();
            colPalette.Image = img;
            var newLocation = new Point
                (
                    colPalette.Width * locationModificator.X,
                    colPalette.Height * locationModificator.Y
                );
            colPalette.Location = newLocation;
            colPalette.Click += ColorPalette_Click;
            return colPalette;
        }

        private List<Bitmap> GetImages(string path)
        {
            var images = new List<Bitmap>();
            var fullPath = Path.GetFullPath(path);
            var imgPaths = Directory.GetFiles(fullPath);

            foreach (var imgPath in imgPaths)
            {
                var imgName = Path.GetFileNameWithoutExtension(imgPath);
                images.Add(new Bitmap(imgPath) { Tag = imgName});
            }
            return images;
        }

        private void ColorPalette_Click(object sender, EventArgs e)
        {
            if (_selectedPalette != null)
            {
                _selectedPalette.BackColor = Color.Transparent;
            }
            var clickedPalette = sender as ColorPalette;
            if (clickedPalette != null)
            {
                clickedPalette.BackColor = Color.FromArgb(15, 185, 177);
                _selectedPalette = clickedPalette;
            }
        }

    }
}
