using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ColorPaletteChangerForThermalImaging.Logic;

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

        private ColorPaletteCreator _paletteCreator;
        private ColorPalette _selectedPalette;
        private const string ResourcesName = "ColorPaletteChangerForThermalImaging.Properties.Resources.resources";
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
            InitColorPalettes("TestImage");
            _paletteCreator = new ColorPaletteCreator();
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

        private void InitColorPalettes(string path)
        {
            List<ColorPalette> colorPalettes = new List<ColorPalette>();

            var images = GetImages();
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
            colPalette.DoubleClick += ColorPalette_DoubleClick;
            return colPalette;
        }

        private List<Bitmap> GetImages()
        {
            var images = new List<Bitmap>();
            var assembly = Assembly.GetExecutingAssembly();
            using (var resStream = assembly.GetManifestResourceStream(ResourcesName))
            using (var resReader = new ResourceReader(resStream))
            {
                var dict = resReader.GetEnumerator();
                while (dict.MoveNext())
                {
                    if (typeof(Bitmap) == dict.Value.GetType())
                    {
                        var img = (Bitmap)dict.Value;
                        img.Tag = dict.Key;
                        images.Add(img);
                    }
                }
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
                        
                    }
                }

            }
        }
        private void AddPaletteToResources(Bitmap img, string name)
        {
            var images = new List<Bitmap>();
            var assembly = Assembly.GetExecutingAssembly();
            using (var resStream = assembly.GetManifestResourceStream(ResourcesName))
            using (var resWriter = new ResourceWriter(resStream))
            {
                resWriter.AddResource(,);
            }
        }
    }
}
