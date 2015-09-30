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
            this.StartButton = new System.Windows.Forms.Label();
            this.ScoreButton = new System.Windows.Forms.Label();
            this.OptionsButton = new System.Windows.Forms.Label();
            this.EndButton = new System.Windows.Forms.Label();
            this.startPB = new System.Windows.Forms.PictureBox();
            this.StartMenu = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.startPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(687, 131);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(199, 59);
            this.StartButton.TabIndex = 1;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // ScoreButton
            // 
            this.ScoreButton.Location = new System.Drawing.Point(698, 254);
            this.ScoreButton.Name = "ScoreButton";
            this.ScoreButton.Size = new System.Drawing.Size(188, 71);
            this.ScoreButton.TabIndex = 2;
            this.ScoreButton.Click += new System.EventHandler(this.ScoreButton_Click);
            // 
            // OptionsButton
            // 
            this.OptionsButton.Location = new System.Drawing.Point(698, 364);
            this.OptionsButton.Name = "OptionsButton";
            this.OptionsButton.Size = new System.Drawing.Size(227, 73);
            this.OptionsButton.TabIndex = 3;
            this.OptionsButton.Click += new System.EventHandler(this.OptionsButton_Click);
            // 
            // EndButton
            // 
            this.EndButton.Location = new System.Drawing.Point(698, 476);
            this.EndButton.Name = "EndButton";
            this.EndButton.Size = new System.Drawing.Size(152, 68);
            this.EndButton.TabIndex = 4;
            this.EndButton.Click += new System.EventHandler(this.EndButton_Click);
            // 
            // startPB
            // 
            this.startPB.BackColor = System.Drawing.Color.Transparent;
            this.startPB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.startPB.Image = global::DespicableMe_Memories.Properties.Resources.start;
            this.startPB.Location = new System.Drawing.Point(690, 131);
            this.startPB.Name = "startPB";
            this.startPB.Size = new System.Drawing.Size(196, 59);
            this.startPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.startPB.TabIndex = 5;
            this.startPB.TabStop = false;
            // 
            // StartMenu
            // 
            this.StartMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StartMenu.Image = global::DespicableMe_Memories.Properties.Resources.menu;
            this.StartMenu.ImageLocation = "";
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
            this.Controls.Add(this.startPB);
            this.Controls.Add(this.EndButton);
            this.Controls.Add(this.OptionsButton);
            this.Controls.Add(this.ScoreButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.StartMenu);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1280, 720);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1280, 720);
            this.Name = "MainForm";
            this.Text = "Despicable Me - Memories";
            ((System.ComponentModel.ISupportInitialize)(this.startPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox StartMenu;
        private System.Windows.Forms.Label StartButton;
        private System.Windows.Forms.Label ScoreButton;
        private System.Windows.Forms.Label OptionsButton;
        private System.Windows.Forms.Label EndButton;
        private System.Windows.Forms.PictureBox startPB;

    }
}

