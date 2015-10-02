using DespicableMe_Memories.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DespicableMe_Memories
{
    public partial class MainForm : Form
    {
        static PictureBox fixedStart;

        public MainForm()
        {
            InitializeComponent();
            fixedStart = StartMenu;

            //--------PictureBox-Remove-Transparent--------\\
            var startPos = this.PointToScreen(start.Location);          
            MakeTransparent(start, startPos);
                    
            var exitPos = this.PointToScreen(exit.Location);
            MakeTransparent(exit, exitPos);

            var optionsPos = this.PointToScreen(options.Location);    
            MakeTransparent(options, optionsPos);                      
                                                                      
            var scorePos = this.PointToScreen(score.Location);
            MakeTransparent(score, scorePos);

            var helpPos = this.PointToScreen(help.Location);
            MakeTransparent(help, helpPos);

            var helpBoxPos = this.PointToScreen(helpBox.Location);
            helpBoxPos = StartMenu.PointToClient(helpBoxPos);
            helpBox.Parent = fixedStart;
            helpBox.Location = helpBoxPos;
            helpBox.BackColor = Color.FromArgb(130, 0, 0, 0);

        }

        static public void MakeTransparent(Control button, System.Drawing.Point pos)
        {
            pos = fixedStart.PointToClient(pos);
            button.Parent = fixedStart;
            button.Location = pos;
            button.BackColor = Color.Transparent;
        }

        private void start_Click(object sender, EventArgs e)
        {
            StartMenu.Visible = false;
        }

        private void score_Click(object sender, EventArgs e)
        {

        }

        private void options_Click(object sender, EventArgs e)
        {

        }

        private void exit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

            //----------Make-Mouse-Enter------------\\
        private void start_MouseEnter(object sender, EventArgs e)
        {
            start.Image = Resources.startShadow;
        }                                                        

        private void start_MouseLeave(object sender, EventArgs e)
        {
            start.Image = Resources.start;     
        }

        private void score_MouseEnter(object sender, EventArgs e)
        {
            score.Image = Resources.scoreShadow;   
        }

        private void score_MouseLeave(object sender, EventArgs e)
        {
            score.Image = Resources.score;   
        }

        private void options_MouseEnter(object sender, EventArgs e)
        {
            options.Image = Resources.optionsShadow;
        }

        private void options_MouseLeave(object sender, EventArgs e)
        {
            options.Image = Resources.options;
        }

        private void exit_MouseEnter(object sender, EventArgs e)
        {
            exit.Image = Resources.exitShadow;  
        }

        private void exit_MouseLeave(object sender, EventArgs e)
        {
            exit.Image = Resources.exit;  
        }

        private void help_MouseEnter(object sender, EventArgs e)
        {
            help.Image = Resources.helpShadow;

            helpBox.Visible = true;

            start.Visible = false;
            score.Visible = false;
            options.Visible = false;
            exit.Visible = false;
        }

        private void help_MouseLeave(object sender, EventArgs e)
        {
            help.Image = Resources.help;

            helpBox.Visible = false;

            start.Visible = true;
            score.Visible = true;
            options.Visible = true;
            exit.Visible = true;
        }

        

        

        

    }
}
