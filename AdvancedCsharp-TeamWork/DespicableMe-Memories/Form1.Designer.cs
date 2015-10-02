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
            this.helpBox = new System.Windows.Forms.PictureBox();
            this.help = new System.Windows.Forms.PictureBox();
            this.score = new System.Windows.Forms.PictureBox();
            this.options = new System.Windows.Forms.PictureBox();
            this.exit = new System.Windows.Forms.PictureBox();
            this.start = new System.Windows.Forms.PictureBox();
            this.StartMenu = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.helpBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.help)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.score)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.options)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.start)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // helpBox
            // 
            this.helpBox.Image = global::DespicableMe_Memories.Properties.Resources.instuction;
            this.helpBox.Location = new System.Drawing.Point(587, 113);
            this.helpBox.Name = "helpBox";
            this.helpBox.Size = new System.Drawing.Size(665, 424);
            this.helpBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.helpBox.TabIndex = 10;
            this.helpBox.TabStop = false;
            this.helpBox.Visible = false;
            // 
            // help
            // 
            this.help.Image = global::DespicableMe_Memories.Properties.Resources.help;
            this.help.Location = new System.Drawing.Point(1073, 614);
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(179, 55);
            this.help.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.help.TabIndex = 9;
            this.help.TabStop = false;
            this.help.MouseEnter += new System.EventHandler(this.help_MouseEnter);
            this.help.MouseLeave += new System.EventHandler(this.help_MouseLeave);
            // 
            // score
            // 
            this.score.Image = global::DespicableMe_Memories.Properties.Resources.score;
            this.score.Location = new System.Drawing.Point(696, 240);
            this.score.Name = "score";
            this.score.Size = new System.Drawing.Size(176, 58);
            this.score.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.score.TabIndex = 8;
            this.score.TabStop = false;
            this.score.Click += new System.EventHandler(this.score_Click);
            this.score.MouseEnter += new System.EventHandler(this.score_MouseEnter);
            this.score.MouseLeave += new System.EventHandler(this.score_MouseLeave);
            // 
            // options
            // 
            this.options.Image = global::DespicableMe_Memories.Properties.Resources.options;
            this.options.Location = new System.Drawing.Point(696, 342);
            this.options.Name = "options";
            this.options.Size = new System.Drawing.Size(235, 58);
            this.options.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.options.TabIndex = 7;
            this.options.TabStop = false;
            this.options.Click += new System.EventHandler(this.options_Click);
            this.options.MouseEnter += new System.EventHandler(this.options_MouseEnter);
            this.options.MouseLeave += new System.EventHandler(this.options_MouseLeave);
            // 
            // exit
            // 
            this.exit.Image = global::DespicableMe_Memories.Properties.Resources.exit;
            this.exit.Location = new System.Drawing.Point(696, 444);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(176, 52);
            this.exit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.exit.TabIndex = 6;
            this.exit.TabStop = false;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            this.exit.MouseEnter += new System.EventHandler(this.exit_MouseEnter);
            this.exit.MouseLeave += new System.EventHandler(this.exit_MouseLeave);
            // 
            // start
            // 
            this.start.BackColor = System.Drawing.Color.Transparent;
            this.start.Image = global::DespicableMe_Memories.Properties.Resources.start;
            this.start.Location = new System.Drawing.Point(696, 144);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(176, 58);
            this.start.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.start.TabIndex = 5;
            this.start.TabStop = false;
            this.start.Click += new System.EventHandler(this.start_Click);
            this.start.MouseEnter += new System.EventHandler(this.start_MouseEnter);
            this.start.MouseLeave += new System.EventHandler(this.start_MouseLeave);
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
            this.Controls.Add(this.helpBox);
            this.Controls.Add(this.help);
            this.Controls.Add(this.score);
            this.Controls.Add(this.options);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.start);
            this.Controls.Add(this.StartMenu);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1280, 720);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1280, 720);
            this.Name = "MainForm";
            this.Text = "Despicable Me - Memories";
            ((System.ComponentModel.ISupportInitialize)(this.helpBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.help)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.score)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.options)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.start)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartMenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox StartMenu;
        private System.Windows.Forms.PictureBox start;
        private System.Windows.Forms.PictureBox exit;
        private System.Windows.Forms.PictureBox options;
        private System.Windows.Forms.PictureBox score;
        private System.Windows.Forms.PictureBox help;
        private System.Windows.Forms.PictureBox helpBox;
    }
}

