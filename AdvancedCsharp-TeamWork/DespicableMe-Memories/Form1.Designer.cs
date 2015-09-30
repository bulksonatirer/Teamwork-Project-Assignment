namespace DespicableMe_Memories
{
    partial class MainForm
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
            this.StartMenu = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.StartMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // StartMenu
            // 
            this.StartMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StartMenu.Image = global::DespicableMe_Memories.Properties.Resources.menu;
            this.StartMenu.Location = new System.Drawing.Point(0, 0);
            this.StartMenu.Name = "StartMenu";
            this.StartMenu.Size = new System.Drawing.Size(1264, 681);
            this.StartMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.StartMenu.TabIndex = 0;
            this.StartMenu.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.StartMenu);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Despicable Me - Memories";
            ((System.ComponentModel.ISupportInitialize)(this.StartMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox StartMenu;

    }
}

