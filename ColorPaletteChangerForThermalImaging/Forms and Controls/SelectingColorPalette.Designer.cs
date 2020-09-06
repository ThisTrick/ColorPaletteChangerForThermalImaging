namespace ColorPaletteChangerForThermalImaging
{
    partial class SelectingColorPalette
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnClose = new System.Windows.Forms.Button();
            this.pColorPalettes = new System.Windows.Forms.Panel();
            this.btnAddNewPalette = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(503, 3);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(45, 45);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pColorPalettes
            // 
            this.pColorPalettes.AutoScroll = true;
            this.pColorPalettes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(177)))), ((int)(((byte)(194)))));
            this.pColorPalettes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pColorPalettes.Location = new System.Drawing.Point(12, 51);
            this.pColorPalettes.Name = "pColorPalettes";
            this.pColorPalettes.Size = new System.Drawing.Size(526, 431);
            this.pColorPalettes.TabIndex = 2;
            // 
            // btnAddNewPalette
            // 
            this.btnAddNewPalette.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnAddNewPalette.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAddNewPalette.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.btnAddNewPalette.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewPalette.Location = new System.Drawing.Point(0, 485);
            this.btnAddNewPalette.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddNewPalette.Name = "btnAddNewPalette";
            this.btnAddNewPalette.Size = new System.Drawing.Size(550, 65);
            this.btnAddNewPalette.TabIndex = 3;
            this.btnAddNewPalette.Text = "Add New Color Palette";
            this.btnAddNewPalette.UseVisualStyleBackColor = true;
            this.btnAddNewPalette.Click += new System.EventHandler(this.btnAddNewPalette_Click);
            // 
            // SelectingColorPalette
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(101)))), ((int)(((byte)(132)))));
            this.ClientSize = new System.Drawing.Size(550, 550);
            this.Controls.Add(this.btnAddNewPalette);
            this.Controls.Add(this.pColorPalettes);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Rockwell", 16.2F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximumSize = new System.Drawing.Size(550, 550);
            this.MinimumSize = new System.Drawing.Size(550, 550);
            this.Name = "SelectingColorPalette";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SelectingColorPalette";
            this.Load += new System.EventHandler(this.SelectingColorPalette_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SelectingColorPalette_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pColorPalettes;
        private System.Windows.Forms.Button btnAddNewPalette;
    }
}