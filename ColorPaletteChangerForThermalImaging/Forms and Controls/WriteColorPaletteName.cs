using System;
using System.Windows.Forms;

namespace ColorPaletteChangerForThermalImaging.Forms_and_Controls
{
    public partial class WriteColorPaletteName : Form
    {
        public WriteColorPaletteName()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var name = textBox.Text;
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Write color palette name.", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.Tag = name;
        }
    }
}
