using DespicableMe_Memories.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

            var optionsPos = this.PointToScreen(options.Location);    //Наложи се да премахна всичките "label" защото след като сложа "PictureBox" върху тях 
            MakeTransparent(options, optionsPos);                     //те не работят... А и проверих дали може да зададен "exit" дирекно на "PictureBox-a" 
                                                                      // и става без проблеми :) 
            var scorePos = this.PointToScreen(score.Location);
            MakeTransparent(score, scorePos);

            var helpPos = this.PointToScreen(help.Location);
            MakeTransparent(help, helpPos);
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

            //----------Make-Mouse-Hover------------\\
        private void start_MouseHover(object sender, EventArgs e)
        {
            start.Image = Resources.startShadow;                          // Наложи се картините да бъдат auto-size защото картинките с сянка ги взема дирекно
        }                                                                // от "Resources" и не ги сляга с тяхния размер...Но мисля че и така не е лошо.

        private void start_MouseLeave(object sender, EventArgs e)
        {
            start.Image = Resources.start;     
        }

        private void score_MouseHover(object sender, EventArgs e)
        {
            score.Image = Resources.scoreShadow;   
        }

        private void score_MouseLeave(object sender, EventArgs e)
        {
            score.Image = Resources.score;   
        }

        private void options_MouseHover(object sender, EventArgs e)
        {
            options.Image = Resources.optionsShadow;   
        }

        private void options_MouseLeave(object sender, EventArgs e)
        {
            options.Image = Resources.options;
        }

        private void exit_MouseHover(object sender, EventArgs e)
        {
            exit.Image = Resources.exitShadow;  
        }

        private void exit_MouseLeave(object sender, EventArgs e)
        {
            exit.Image = Resources.exit;  
        }

        private void help_MouseHover(object sender, EventArgs e)
        {
            help.Image = Resources.helpShadow;  
        }

        private void help_MouseLeave(object sender, EventArgs e)
        {
            help.Image = Resources.help;  
        }

    }
}
