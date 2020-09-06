using System.Drawing;

namespace ColorPaletteChangerForThermalImaging.Logic
{
    public class ColorPaletteEditor
    {
        public Bitmap Edit(Bitmap img, Bitmap colorPalette)
        {
            var standard = BitmapToColorArray(colorPalette);
            try
            {
                var newImg = new Bitmap(img);
                var palette = newImg.Palette;
                for (int i = 0; i < palette.Entries.Length; i++)
                {
                    var pixel = (Color)palette.Entries.GetValue(i);
                    var intensity = (int)(0.59 * pixel.R + 0.3 * pixel.G + 0.11 * pixel.B);
                    var color = standard[intensity];
                    palette.Entries.SetValue(color, i);
                }
                newImg.Palette = palette;
                return newImg;
            }
            catch (System.ArgumentException)
            {
                var newImg = new Bitmap(img);

                for (int x = 0; x < newImg.Width; x++)
                {
                    for (int y = 0; y < newImg.Height; y++)
                    {
                        var pixel = newImg.GetPixel(x, y);
                        var intensity = (int)(0.3 * pixel.R + 0.59 * pixel.G + 0.11 * pixel.B);
                        var color = standard[intensity];
                        newImg.SetPixel(x, y, color);
                    }
                }
                return newImg;
            }
        }
        private Color[] BitmapToColorArray(Bitmap colorPalette)
        {
            var standard = new Color[colorPalette.Height];
            for (int y = 0; y < colorPalette.Height; y++)
            {
                standard[y] = colorPalette.GetPixel(0, colorPalette.Height - 1 - y);
            }
            return standard;
        }
    }
}
