using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ColorPaletteChangerForThermalImaging
{
    public partial class NewColorPaletteAdder : Form
    {

        #region Перемещение формы

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void NewColorPaletteAdder_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion
        int _panelIndex;
        public NewColorPaletteAdder()
        {
            InitializeComponent();
        }
        private void NewColorPaletteAdder_Load(object sender, EventArgs e)
        {
            _panelIndex = 1;
            BaseLoad();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var controls = pColors.Controls;
            var colors = new List<Color>();
            foreach (Control pColor in controls)
            {
                if (pColor.Controls.Count <= 0)
                {
                    colors.Add(pColor.BackColor);
                }
            }
            this.Tag = colors;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnAddColor_Click(object sender, EventArgs e)
        {
            pColors.Controls.Add(NewColorPanel());
            var countColors = pColors.Controls.Count;
            var size = new Size(pColors.Width, pColors.Height / countColors);
            foreach (Control control in pColors.Controls)
            {
                control.Size = size;
            }
        }

        private Panel NewColorPanel(Size size)
        {
            var panel = NewColorPanel();
            panel.Width = size.Width;
            panel.Height = size.Height;
            return panel;
        }
        private Panel NewColorPanel()
        {
            var panel = new Panel();
            panel.Dock = DockStyle.Bottom;
            panel.BorderStyle = BorderStyle.FixedSingle;
            var label = new Label();
            label.Font = this.Font;
            label.Text = "Click";
            label.Location = new Point(10, 10);
            panel.Controls.Add(label);
            panel.Click += ColorPanel_Click;
            PanelNameChenger(panel);
            return panel;
        }
        private void BaseLoad()
        {
            var size = new Size(pColors.Width, pColors.Height / 2);
            var panel1 = NewColorPanel(size);
            var panel2 = NewColorPanel(size);
            pColors.Controls.Add(panel1);
            pColors.Controls.Add(panel2);
        }
        private void PanelNameChenger(Panel panel)
        {
            panel.Name = $"panel{_panelIndex}";
            _panelIndex++;
        }
        private void ColorPanel_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                if (sender is Panel panel)
                {
                    panel.BackColor = colorDialog.Color;
                    if (panel.Controls.Count > 0)
                    {
                        panel.Controls.RemoveAt(0);
                    }
                }
            }
        }


    }
}
