using ColorPaletteChangerForThermalImaging.Logic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ColorPaletteChangerForThermalImaging
{

    public partial class SelectingColorPalette : Form
    {
        #region Перемещение формы

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void SelectingColorPalette_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        private const string ResourcesPash = "ColorPalettes";
        private ColorPaletteCreator _paletteCreator;
        private ColorPalette _selectedPalette;
        public SelectingColorPalette()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void SelectingColorPalette_Load(object sender, EventArgs e)
        {

            _paletteCreator = new ColorPaletteCreator();
            InitColorPalettes();
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
        private void ColorPalette_DoubleClick(object sender, EventArgs e)
        {
            this.Tag = _selectedPalette.Image;
            this.DialogResult = DialogResult.OK;
        }

        private void InitColorPalettes()
        {
            List<ColorPalette> colorPalettes = new List<ColorPalette>();

            var images = GetImages(ResourcesPash);
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
            this.pColorPalettes.Controls.Clear();
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
            colPalette.DoubleClick += ColorPalette_DoubleClick;
            return colPalette;
        }

        private List<Bitmap> GetImages(string path)
        {
            var images = new List<Bitmap>();
            var appPath = Application.StartupPath;
            var fullPath = Path.Combine(appPath, path);
            var imgPaths = Directory.GetFiles(fullPath);

            foreach (var imgPath in imgPaths)
            {
                var imgName = Path.GetFileNameWithoutExtension(imgPath);
                images.Add(new Bitmap(imgPath) { Tag = imgName });
            }
            return images;
        }

        private void btnAddNewPalette_Click(object sender, EventArgs e)
        {
            using (var addPaletteForm = new NewColorPaletteAdder())
            {
                if (addPaletteForm.ShowDialog() == DialogResult.OK)
                {
                    if (addPaletteForm.Tag is List<Color> colors)
                    {
                        var colorPaletteImg = _paletteCreator.Create(colors.ToArray());
                        var name = "";
                        using (var writeName = new WriteColorPaletteName())
                        {
                            if (writeName.ShowDialog() == DialogResult.OK)
                            {
                                name = writeName.Tag as string;
                            }
                        }
                        AddPaletteToResources(colorPaletteImg, name, ResourcesPash);
                    }
                }
            }
            InitColorPalettes();
        }
        private void AddPaletteToResources(Bitmap img, string name, string path)
        {
            var appPath = Application.StartupPath;
            var imgPath = $"{path}\\{name}.png";
            var fullPath = Path.Combine(appPath, imgPath);
            img.Save(fullPath);
        }

    }
}

