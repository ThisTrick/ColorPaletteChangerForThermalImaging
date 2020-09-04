using System.Drawing;

namespace ColorPaletteChangerForThermalImaging.Logic
{
    public class ColorPaletteEditor
    {
        public Bitmap Edit(Bitmap img, Bitmap colorPalette)
        {
            var standard = BitmapToColorArray(colorPalette);
            var palette = img.Palette;
            for (int i = 0; i < palette.Entries.Length; i++)
            {
                var pixel = (Color)palette.Entries.GetValue(i);
                var intensity = (int)(0.3 * pixel.R + 0.59 * pixel.G + 0.11 * pixel.B);
                var color = standard[intensity];
                palette.Entries.SetValue(color, i);
            }
            img.Palette = palette;
            return img;
        }
        private Color[] BitmapToColorArray(Bitmap colorPalette)
        {
            var standard = new Color[colorPalette.Height];
            for (int y = 0; y < colorPalette.Height; y++)
            {
                standard[y] = colorPalette.GetPixel(0, y);
            }
            return standard;
        }
    }
}
