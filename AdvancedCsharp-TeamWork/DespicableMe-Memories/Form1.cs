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
            //startPos = StartMenu.PointToClient(startPos);
            
            //StartButton.Parent = StartMenu;
            //StartButton.Location = startPos;
            //StartButton.BackColor = Color.Transparent;

            var startPos = this.PointToScreen(StartButton.Location);
            MakeButtonTrans(StartButton, startPos);

            //scorePos = StartMenu.PointToClient(scorePos);

            //ScoreButton.Parent = StartMenu;
            //ScoreButton.Location = scorePos;
            //ScoreButton.BackColor = Color.Transparent;

            var scorePos = this.PointToScreen(ScoreButton.Location);
            MakeButtonTrans(ScoreButton, scorePos);

            //optionsPos = StartMenu.PointToClient(optionsPos);
            
            //OptionsButton.Parent = StartMenu;
            //OptionsButton.Location = optionsPos;
            //OptionsButton.BackColor = Color.Transparent;

            var optionsPos = this.PointToScreen(OptionsButton.Location);
            MakeButtonTrans(OptionsButton, optionsPos);

            //endPos = StartMenu.PointToClient(endPos);

            //EndButton.Parent = StartMenu;
            //EndButton.Location = endPos;
            //EndButton.BackColor = Color.Transparent;

            var endPos = this.PointToScreen(EndButton.Location);
            MakeButtonTrans(EndButton, endPos);

        }

        static public void MakeButtonTrans(Control button, System.Drawing.Point pos)
        {
            pos = fixedStart.PointToClient(pos);
            button.Parent = fixedStart;
            button.Location = pos;
            button.BackColor = Color.Transparent;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {

        }
        //private void startPB_

        private void ScoreButton_Click(object sender, EventArgs e)
        {

        }

        private void OptionsButton_Click(object sender, EventArgs e)
        {

        }

        private void EndButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //private void MainForm_Load(object sender, EventArgs e)
        //{
        //    StartMenu.Controls.Add(startPB);
        //}



    }
}
