namespace ColorPaletteChangerForThermalImaging.Forms_and_Controls
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
            this.btnAddColor = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.pButton.SuspendLayout();
            this.pMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Rockwell", 16.2F, System.Drawing.FontStyle.Bold);
            this.btnClose.Location = new System.Drawing.Point(326, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(206, 74);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // pButton
            // 
            this.pButton.Controls.Add(this.btnAdd);
            this.pButton.Controls.Add(this.btnClose);
            this.pButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.pButton.Location = new System.Drawing.Point(0, 0);
            this.pButton.Name = "pButton";
            this.pButton.Size = new System.Drawing.Size(532, 74);
            this.pButton.TabIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Rockwell", 16.2F, System.Drawing.FontStyle.Bold);
            this.btnAdd.Location = new System.Drawing.Point(0, 0);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(326, 74);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add New  Palette";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // pMain
            // 
            this.pMain.Controls.Add(this.btnAddColor);
            this.pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pMain.Location = new System.Drawing.Point(0, 74);
            this.pMain.Name = "pMain";
            this.pMain.Size = new System.Drawing.Size(532, 429);
            this.pMain.TabIndex = 3;
            // 
            // btnAddColor
            // 
            this.btnAddColor.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnAddColor.FlatAppearance.BorderSize = 0;
            this.btnAddColor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnAddColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddColor.Font = new System.Drawing.Font("Rockwell", 16.2F, System.Drawing.FontStyle.Bold);
            this.btnAddColor.Location = new System.Drawing.Point(0, 362);
            this.btnAddColor.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddColor.Name = "btnAddColor";
            this.btnAddColor.Size = new System.Drawing.Size(532, 67);
            this.btnAddColor.TabIndex = 2;
            this.btnAddColor.Text = "Add Color";
            this.btnAddColor.UseVisualStyleBackColor = true;
            // 
            // NewColorPaletteAdder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(532, 503);
            this.Controls.Add(this.pMain);
            this.Controls.Add(this.pButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NewColorPaletteAdder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewColorPaletteAdder";
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
    }
}