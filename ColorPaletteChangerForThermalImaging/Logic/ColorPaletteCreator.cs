using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorPaletteChangerForThermalImaging.Logic
{
    public class ColorPaletteCreator
    {
        public Bitmap Create(params Color[] colors)
        {
            var img = new Bitmap(100, 256);

            using (var graphics = Graphics.FromImage(img))
            {
                var rectangle = new Rectangle(0, 0, img.Width, img.Height);
                using (var brush = new LinearGradientBrush
                                        (
                                            rectangle,
                                            colors[0],
                                            colors[colors.Length - 1],
                                            LinearGradientMode.Vertical
                                        ))
                {
                    var positions = CalcPositions(colors.Length);

                    var blend = new ColorBlend(colors.Length);
                    blend.Colors = colors;
                    blend.Positions = positions;

                    brush.InterpolationColors = blend;
                    graphics.FillRectangle(brush, rectangle);
                }
            }
                return img;
        }
        public bool Save(string path, Bitmap imgColorPalette)
        {
            try
            {
                imgColorPalette.Save(path);
                return true;
            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
        }
        public Bitmap CreateAndSave(string path, params Color[] colors)
        {
            var imgColorPalette = Create(colors);
            if (Save(path, imgColorPalette))
            {
                imgColorPalette.Tag = true;
                return imgColorPalette;
            }
            else
            {
                return new Bitmap(imgColorPalette.Width, imgColorPalette.Height) { Tag = false};
            }
        }
        private float[] CalcPositions(int length)
        {
            var positions = new float[length];
            positions[0] = 0.0f;
            positions[length - 1] = 1.0f;
            var step = 1.0f / (length - 1);
            int index = 1;
            for (float position = step; position < 1.0f; position += step)
            {
                positions[index] = position;
                index++;
            }
            return positions;
        }
    }
}
