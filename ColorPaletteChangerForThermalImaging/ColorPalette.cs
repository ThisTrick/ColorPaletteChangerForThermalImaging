using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorPaletteChangerForThermalImaging
{
    public partial class ColorPalette : Panel
    {

        public string ColorPaletteName
        {
            get { return label.Text; }
            set { label.Text = value; }
        }

        public Image Image
        {
            get { return pictureBox.Image; }
            set { pictureBox.Image = value; }
        }


        public ColorPalette()
        {
            InitializeComponent();
        }

        private void ColorPalette_FontChanged(object sender, EventArgs e)
        {
            this.label.Font = this.Font;
        }

    }
}
