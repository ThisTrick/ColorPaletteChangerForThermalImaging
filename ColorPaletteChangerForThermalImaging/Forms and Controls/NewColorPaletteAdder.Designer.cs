namespace ColorPaletteChangerForThermalImaging
{
    partial class NewColorPaletteAdder
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
            this.pButton = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pMain = new System.Windows.Forms.Panel();
            this.pColors = new System.Windows.Forms.Panel();
            this.btnAddColor = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.pButton.SuspendLayout();
            this.pMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Rockwell", 16.2F, System.Drawing.FontStyle.Bold);
            this.btnClose.Location = new System.Drawing.Point(366, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(184, 61);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pButton
            // 
            this.pButton.Controls.Add(this.btnAdd);
            this.pButton.Controls.Add(this.btnClose);
            this.pButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.pButton.Location = new System.Drawing.Point(0, 0);
            this.pButton.Margin = new System.Windows.Forms.Padding(6);
            this.pButton.Name = "pButton";
            this.pButton.Size = new System.Drawing.Size(550, 61);
            this.pButton.TabIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Rockwell", 16.2F, System.Drawing.FontStyle.Bold);
            this.btnAdd.Location = new System.Drawing.Point(0, 0);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(366, 61);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add New  Palette";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pMain
            // 
            this.pMain.Controls.Add(this.pColors);
            this.pMain.Controls.Add(this.btnAddColor);
            this.pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pMain.Location = new System.Drawing.Point(0, 61);
            this.pMain.Margin = new System.Windows.Forms.Padding(6);
            this.pMain.Name = "pMain";
            this.pMain.Size = new System.Drawing.Size(550, 439);
            this.pMain.TabIndex = 3;
            // 
            // pColors
            // 
            this.pColors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pColors.Location = new System.Drawing.Point(0, 0);
            this.pColors.Name = "pColors";
            this.pColors.Size = new System.Drawing.Size(550, 380);
            this.pColors.TabIndex = 3;
            // 
            // btnAddColor
            // 
            this.btnAddColor.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnAddColor.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnAddColor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnAddColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddColor.Font = new System.Drawing.Font("Rockwell", 16.2F, System.Drawing.FontStyle.Bold);
            this.btnAddColor.Location = new System.Drawing.Point(0, 380);
            this.btnAddColor.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddColor.Name = "btnAddColor";
            this.btnAddColor.Size = new System.Drawing.Size(550, 59);
            this.btnAddColor.TabIndex = 2;
            this.btnAddColor.Text = "Add Color";
            this.btnAddColor.UseVisualStyleBackColor = true;
            this.btnAddColor.Click += new System.EventHandler(this.btnAddColor_Click);
            // 
            // NewColorPaletteAdder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(550, 500);
            this.Controls.Add(this.pMain);
            this.Controls.Add(this.pButton);
            this.Font = new System.Drawing.Font("Rockwell", 16.2F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "NewColorPaletteAdder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewColorPaletteAdder";
            this.Load += new System.EventHandler(this.NewColorPaletteAdder_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NewColorPaletteAdder_MouseDown);
            this.pButton.ResumeLayout(false);
            this.pMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pButton;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.Button btnAddColor;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Panel pColors;
    }
}