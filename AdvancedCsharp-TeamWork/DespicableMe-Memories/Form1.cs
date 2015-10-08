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
using System.Configuration;
using WMPLib;

namespace DespicableMe_Memories
{
    public partial class MainForm : Form
    {
        static PictureBox fixedStart;
        static PictureBox fixedGame;

        static string fullscreenSetting = "fullscreen";
        static string soundSetting = "sound";

        static string fullscreenSettingState = ReadSetting(fullscreenSetting);
        static string soundSettingState = ReadSetting(soundSetting);

        WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();

        int globalTop;
        int globalLeft;

        int globalWidth;
        int globalHeight;

        int moves = 0;
        int count = 0;

        //veriables
        Random location = new Random();
        List<Point> list = new List<Point>();
        PictureBox CardHolder1;
        PictureBox CardHolder2;

        public MainForm()
        {
            InitializeComponent();
            fixedStart = StartMenu;
            fixedGame = easyGameScreen;
            //wplayer.URL = "Resources/buttonSound.mp3";

            this.MaximumSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);  

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

            var backPos = this.PointToScreen(back.Location);         
            MakeTransparent(back, backPos);

            var soundPos = this.PointToScreen(sound.Location);
            MakeTransparent(sound, soundPos);

            var fullscreenPos = this.PointToScreen(fullscreen.Location);
            MakeTransparent(fullscreen, fullscreenPos);

            var fullscreenOnPos = this.PointToScreen(fullscreenOn.Location);
            MakeTransparent(fullscreenOn, fullscreenOnPos);

            var fullscreenOffPos = this.PointToScreen(fullscreenOff.Location);
            MakeTransparent(fullscreenOff, fullscreenOffPos);

            var soundOnPos = this.PointToScreen(soundOn.Location);
            MakeTransparent(soundOn, soundOnPos);

            var soundOffPos = this.PointToScreen(soundOff.Location);
            MakeTransparent(soundOff, soundOffPos);

            var helpBoxPos = this.PointToScreen(helpBox.Location);
            helpBoxPos = StartMenu.PointToClient(helpBoxPos);
            helpBox.Parent = fixedStart;
            helpBox.Location = helpBoxPos;
            helpBox.BackColor = Color.FromArgb(130, 0, 0, 0);

            var movesPicBoxPos = this.PointToScreen(movesPicBox.Location);
            MakeTransparentDuringGame(movesPicBox, movesPicBoxPos);

            var victoryPos = this.PointToScreen(victory.Location);
            MakeTransparentDuringGame(victory, victoryPos);

            var gameOverPos = this.PointToScreen(gameOver.Location);
            MakeTransparentDuringGame(gameOver, gameOverPos);

            var tryAgainPos = this.PointToScreen(tryAgain.Location);
            MakeTransparentDuringGame(tryAgain, tryAgainPos);


            //var MainMenuPos = this.PointToScreen(MainMenu.Location);
            //MakeTransparentDuringGame(MainMenu, MainMenuPos);

            if (soundSettingState == "true")
            {
                soundOn.Image = Resources.onShadow;
                soundOff.Image = Resources.off;

            }
            else if (soundSettingState == "false")
            {
                soundOn.Image = Resources.on;
                soundOff.Image = Resources.offShadow;
            }

            if(ReadSetting(fullscreenSetting) == "true")
            {
                CheckFullscreen();
            }
            else if(ReadSetting(fullscreenSetting) == "false")
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                this.WindowState = FormWindowState.Normal;
                fullscreenOff.Image = Resources.offShadow;
                fullscreenOn.Image = Resources.on;
            }
        }

        string GetLine(string fileName, int line)
        {
            using (var sr = new StreamReader(fileName))
            {
                for (int i = 1; i <= line; i++)
                { 
                    sr.ReadLine();
                }
                return sr.ReadLine();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        static public void MakeTransparent(Control button, System.Drawing.Point pos)
        {
            pos = fixedStart.PointToClient(pos);
            button.Parent = fixedStart;  
            button.Location = pos;
            button.BackColor = Color.Transparent;
        }

        static public void MakeTransparentDuringGame(Control button, System.Drawing.Point pos)
        {
            pos = fixedGame.PointToClient(pos);
            button.Parent = fixedGame;
            button.Location = pos;
            button.BackColor = Color.Transparent;
        }

        //-----------On-Click-Function-----------\\
        private void start_Click(object sender, EventArgs e)
        {
            i = 0;
            chek = 0;
            count = 0;
            CardHolder1 = null;
            CardHolder2 = null;

            card1.Enabled = true;
            card2.Enabled = true;
            card3.Enabled = true;
            card4.Enabled = true;
            card5.Enabled = true;
            card6.Enabled = true;
            card7.Enabled = true;
            card8.Enabled = true;
            card9.Enabled = true;
            card10.Enabled = true;
            card11.Enabled = true;
            card12.Enabled = true;
            card13.Enabled = true;
            card14.Enabled = true;
            card15.Enabled = true;
            card16.Enabled = true;

            start.Visible = false;
            score.Visible = false;
            options.Visible = false;
            exit.Visible = false;
            help.Visible = false;
            PlaySound(soundSettingState);
            moves = 16;
            movesLabel.Text = moves.ToString();

            fixedGame = easyGameScreen;
            StartMenu.Visible = false;
            easyGameScreen.Visible = true;
            PlaySound(soundSettingState);

            MainMenu.Visible = true;
            var MainMenuPos = this.PointToScreen(MainMenu.Location);
            MakeTransparentDuringGame(MainMenu, MainMenuPos);

            CardHolderPanel.Visible = true;
            movesPicBox.Visible = true;
            movesLabel.Visible = true;

            card1.Image = Properties.Resources.img1;
            card2.Image = Properties.Resources.img1;
            card3.Image = Properties.Resources.img2;
            card4.Image = Properties.Resources.img2;
            card5.Image = Properties.Resources.img3;
            card6.Image = Properties.Resources.img3;
            card7.Image = Properties.Resources.img4;
            card8.Image = Properties.Resources.img4;
            card9.Image = Properties.Resources.img5;
            card10.Image = Properties.Resources.img5;
            card11.Image = Properties.Resources.img6;
            card12.Image = Properties.Resources.img6;
            card13.Image = Properties.Resources.img7;
            card14.Image = Properties.Resources.img7;
            card15.Image = Properties.Resources.img8;
            card16.Image = Properties.Resources.img8;


            foreach (PictureBox picture in CardHolderPanel.Controls)
            {
                picture.Cursor = Cursors.Hand;
                picture.Image = Properties.Resources.backSite;
            }

            foreach (PictureBox picture in CardHolderPanel.Controls)
            {
                list.Add(picture.Location);
            }

            foreach (PictureBox picture in CardHolderPanel.Controls)
            {
                int next = location.Next(list.Count - 1);
                Point p = list[next];
                picture.Location = p;
                list.Remove(p);
            }

            Random rand = new Random();
            int randRange = rand.Next(1, 9);
            questionsLabel.Text = GetLine("../../questions.txt", randRange);
            arr = GetLine("../../answers.txt", randRange).Split(',').ToArray();
            correctAnswer = GetLine("../../correctAnswer.txt", randRange);
        }

        private void score_Click(object sender, EventArgs e)
        {
            PlaySound(soundSettingState);
        }

        private void options_Click(object sender, EventArgs e)
        {
            back.Visible = true;
            sound.Visible = true;
            soundOn.Visible = true;
            soundOff.Visible = true;
            fullscreen.Visible = true;
            fullscreenOn.Visible = true;
            fullscreenOff.Visible = true;

            start.Visible = false;
            score.Visible = false;
            options.Visible = false;
            exit.Visible = false;
            help.Visible = false;
            PlaySound(soundSettingState);
        }

        private void exit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void back_Click(object sender, EventArgs e)
        {
            back.Visible = false;
            sound.Visible = false;
            soundOn.Visible = false;
            soundOff.Visible = false;
            fullscreen.Visible = false;
            fullscreenOn.Visible = false;
            fullscreenOff.Visible = false;
            back.Visible = false;

            start.Visible = true;
            score.Visible = true;
            options.Visible = true;
            exit.Visible = true;
            help.Visible = true;
            PlaySound(soundSettingState);

        }

        private void soundOn_Click(object sender, EventArgs e)
        {
            AddUpdateAppSettings(soundSetting, "true");
            soundSettingState = "true";
            soundOn.Image = Resources.onShadow;
            soundOff.Image = Resources.off;
            PlaySound(soundSettingState);
        }

        private void soundOff_Click(object sender, EventArgs e)
        {
            AddUpdateAppSettings(soundSetting, "false");
            soundSettingState = "false";
            soundOff.Image = Resources.offShadow;
            soundOn.Image = Resources.on;
            PlaySound(soundSettingState);
        }

        private void fullscreenOn_Click(object sender, EventArgs e)
        {
            if(fullscreenSettingState == "false")
            {
                AddUpdateAppSettings(fullscreenSetting, "true");
                fullscreenSettingState = "true";
                fullscreenOn.Image = Resources.onShadow;
                fullscreenOff.Image = Resources.off;
                PlaySound(soundSettingState);
                CheckFullscreen();
            }

            //this.TopMost = true;
            //this.WindowState = FormWindowState.Normal;
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.WindowState = FormWindowState.Maximized;
        }

        private void fullscreenOff_Click(object sender, EventArgs e)
        {
            if(fullscreenSettingState == "true")
            {
                AddUpdateAppSettings(fullscreenSetting, "false");
                fullscreenSettingState = "false";
                fullscreenOff.Image = Resources.offShadow;
                fullscreenOn.Image = Resources.on;
                PlaySound(soundSettingState);
                CheckFullscreen();
            }
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            //this.WindowState = FormWindowState.Normal;
        }

        private void MainMenu_Click(object sender, EventArgs e)
        {
            i = 0;
            chek = 0;
            count = 0;
            CardHolder1 = null;
            CardHolder2 = null;

            StartMenu.Visible = true;
            start.Visible = true;
            score.Visible = true;
            options.Visible = true;
            exit.Visible = true;
            help.Visible = true;

            easyGameScreen.Visible = false;
            PlaySound(soundSettingState);
            MainMenu.Visible = false;

            questionsLabel.Visible = false;
            CardHolderPanel.Visible = false;
            movesPicBox.Visible = false;
            movesLabel.Visible = false;

            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            gameOver.Visible = false;
            victory.Visible = false;
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

        private void back_MouseEnter(object sender, EventArgs e)
        {

            back.Image = Resources.backShadow;
        }

        private void back_MouseLeave(object sender, EventArgs e)
        {
            back.Image = Resources.back;
        }

        private void MainMenu_MouseEnter(object sender, EventArgs e)
        {
            MainMenu.Image = Resources.mainMenuShadow;
        }

        private void MainMenu_MouseLeave(object sender, EventArgs e)
        {
            MainMenu.Image = Resources.mainMenu;
        }

        static string ReadSetting(string key)
        {

            var appSettings = ConfigurationManager.AppSettings;
            string result = appSettings[key] ?? "Not Found";
            return result;
        }

        static void AddUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                MessageBox.Show("Error writing app settings");
            }
        } 
        
        public void PlaySound(string key)
        {
            if (key == "true")
            {
                wplayer.URL = "Resources/buttonSound.mp3";
                wplayer.controls.play();
            }
        }
        public void Resizer(int top, int left)
        {
            double x, y;
            if(fullscreenSettingState == "true")
            {
                y = (double)top * ((double)Screen.PrimaryScreen.Bounds.Height / (double)720);
                x = (double)left * ((double)Screen.PrimaryScreen.Bounds.Width / (double)1280);
                globalTop = (int)y;
                globalLeft = (int)x;
            }
            else if (fullscreenSettingState == "false")
            {
                y = (double)top / ((double)Screen.PrimaryScreen.Bounds.Height / (double)720);
                x = (double)left / ((double)Screen.PrimaryScreen.Bounds.Width / (double)1280);
                globalTop = (int)y;
                globalLeft = (int)x;
            }

        }
        public void CheckFullscreen()
        {
            if (fullscreenSettingState == "true")
            {
                fullscreenOn.Image = Resources.onShadow;
                fullscreenOff.Image = Resources.off;
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;

                Resizer(start.Top, start.Left);
                start.Top = globalTop;
                start.Left = globalLeft;

                Resizer(exit.Top, exit.Left);
                exit.Top = globalTop;
                exit.Left = globalLeft;

                Resizer(options.Top, options.Left);
                options.Top = globalTop;
                options.Left = globalLeft;

                Resizer(score.Top, score.Left);
                score.Top = globalTop;
                score.Left = globalLeft;

                Resizer(sound.Top, sound.Left);
                sound.Top = globalTop;
                sound.Left = globalLeft;

                Resizer(fullscreen.Top, fullscreen.Left);
                fullscreen.Top = globalTop;
                fullscreen.Left = globalLeft;

                Resizer(fullscreenOn.Top, fullscreenOn.Left);
                fullscreenOn.Top = globalTop;
                fullscreenOn.Left = globalLeft;

                Resizer(fullscreenOff.Top, fullscreenOff.Left);
                fullscreenOff.Top = globalTop;
                fullscreenOff.Left = globalLeft;

                Resizer(soundOn.Top, soundOn.Left);
                soundOn.Top = globalTop;
                soundOn.Left = globalLeft;

                Resizer(soundOff.Top, soundOff.Left);
                soundOff.Top = globalTop;
                soundOff.Left = globalLeft;

                Resizer(CardHolderPanel.Top, CardHolderPanel.Left);
                CardHolderPanel.Top = globalTop;
                CardHolderPanel.Left = globalLeft;
                //Resizer(CardHolderPanel.Size.Height, CardHolderPanel.Size.Width);

                Resizer(movesPicBox.Top, movesPicBox.Left);
                movesPicBox.Top = globalTop;
                movesPicBox.Left = globalLeft;

                Resizer(movesLabel.Top, movesLabel.Left);
                movesLabel.Top = globalTop;
                movesLabel.Left = globalLeft;

                Resizer(gameOver.Top, gameOver.Left);
                gameOver.Top = globalTop;
                gameOver.Left = globalLeft;

                Resizer(victory.Top, victory.Left);
                victory.Top = globalTop;
                victory.Left = globalLeft;

                Resizer(tryAgain.Top, tryAgain.Left);
                tryAgain.Top = globalTop;
                tryAgain.Left = globalLeft;

                CardHolderPanelResizer(CardHolderPanel);

                CardResizer(card1);
                CardResizer(card2);
                CardResizer(card3);
                CardResizer(card4);
                CardResizer(card5);
                CardResizer(card6);
                CardResizer(card7);
                CardResizer(card8);
                CardResizer(card9);
                CardResizer(card10);
                CardResizer(card11);
                CardResizer(card12);
                CardResizer(card13);
                CardResizer(card14);
                CardResizer(card15);
                CardResizer(card16);

            }
            else if (fullscreenSettingState == "false")
            {
                fullscreenOn.Image = Resources.on;
                fullscreenOff.Image = Resources.offShadow;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                this.WindowState = FormWindowState.Normal;

                Resizer(start.Top, start.Left);
                start.Top = globalTop;
                start.Left = globalLeft;

                Resizer(exit.Top, exit.Left);
                exit.Top = globalTop;
                exit.Left = globalLeft;

                Resizer(options.Top, options.Left);
                options.Top = globalTop;
                options.Left = globalLeft;

                Resizer(score.Top, score.Left);
                score.Top = globalTop;
                score.Left = globalLeft;

                Resizer(sound.Top, sound.Left);
                sound.Top = globalTop;
                sound.Left = globalLeft;

                Resizer(fullscreen.Top, fullscreen.Left);
                fullscreen.Top = globalTop;
                fullscreen.Left = globalLeft;

                Resizer(fullscreenOn.Top, fullscreenOn.Left);
                fullscreenOn.Top = globalTop;
                fullscreenOn.Left = globalLeft;

                Resizer(fullscreenOff.Top, fullscreenOff.Left);
                fullscreenOff.Top = globalTop;
                fullscreenOff.Left = globalLeft;

                Resizer(soundOn.Top, soundOn.Left);
                soundOn.Top = globalTop;
                soundOn.Left = globalLeft;

                Resizer(soundOff.Top, soundOff.Left);
                soundOff.Top = globalTop;
                soundOff.Left = globalLeft;

                Resizer(movesPicBox.Top, movesPicBox.Left);
                movesPicBox.Top = globalTop;
                movesPicBox.Left = globalLeft;

                Resizer(movesLabel.Top, movesLabel.Left);
                movesLabel.Top = globalTop;
                movesLabel.Left = globalLeft;

                //Resizer(gameOver.Top, gameOver.)

                Resizer(movesPicBox.Top, movesPicBox.Left);
                movesPicBox.Top = globalTop;
                movesPicBox.Left = globalLeft;

                Resizer(movesLabel.Top, movesLabel.Left);
                movesLabel.Top = globalTop;
                movesLabel.Left = globalLeft;

                Resizer(gameOver.Top, gameOver.Left);
                gameOver.Top = globalTop;
                gameOver.Left = globalLeft;

                Resizer(victory.Top, victory.Left);
                victory.Top = globalTop;
                victory.Left = globalLeft;

                Resizer(tryAgain.Top, tryAgain.Left);
                tryAgain.Top = globalTop;
                tryAgain.Left = globalLeft;

                CardHolderPanelResizer(CardHolderPanel);





                CardResizer(card1);
                CardResizer(card2);
                CardResizer(card3);
                CardResizer(card4);
                CardResizer(card5);
                CardResizer(card6);
                CardResizer(card7);
                CardResizer(card8);
                CardResizer(card9);
                CardResizer(card10);
                CardResizer(card11);
                CardResizer(card12);
                CardResizer(card13);
                CardResizer(card14);
                CardResizer(card15);
                CardResizer(card16);

            }
        }

        public void CardResizer(Control card)
        {
            if(fullscreenSettingState == "true")
            {
                double newCardWidth = (double)card.Size.Width * (double)(Screen.PrimaryScreen.Bounds.Width / (double)1280);
                double newCardHeight = (double)card.Size.Height * (double)(Screen.PrimaryScreen.Bounds.Height / (double)720);
                card.MaximumSize = new Size((int)newCardWidth, (int)newCardHeight);
                card.Size = new Size((int)newCardWidth, (int)newCardHeight);
                Resizer(card.Top, card.Left);
                card.Top = globalTop;
                card.Left = globalLeft;
            }
            else if(fullscreenSettingState == "false")
            {
                double newCardWidth = (double)card.Size.Width / (double)(Screen.PrimaryScreen.Bounds.Width / (double)1280);
                double newCardHeight = (double)card.Size.Height / (double)(Screen.PrimaryScreen.Bounds.Height / (double)720);
                card.MaximumSize = new Size((int)newCardWidth, (int)newCardHeight);
                card.Size = new Size((int)newCardWidth, (int)newCardHeight);
                Resizer(card.Top, card.Left);
                card.Top = globalTop;
                card.Left = globalLeft;
            }
            
        }

        public void CardHolderPanelResizer(Control panel)
        {
            if(fullscreenSettingState == "true")
            {
                double newWidth = (double)CardHolderPanel.Size.Width * (double)(Screen.PrimaryScreen.Bounds.Width / (double)1280);
                double newHeight = (double)CardHolderPanel.Size.Height * (double)(Screen.PrimaryScreen.Bounds.Height / (double)720);
                globalWidth = (int)newWidth;
                globalHeight = (int)newHeight;
                CardHolderPanel.MaximumSize = new Size(globalWidth, globalHeight);
                CardHolderPanel.Size = new Size(globalWidth, globalHeight);
                //Resizer(CardHolderPanel.Top, CardHolderPanel.Left);
                //CardHolderPanel.Top = globalTop;
                //CardHolderPanel.Left = globalLeft;
            }
            else if(fullscreenSettingState == "false")
            {
                double newWidth = (double)CardHolderPanel.Size.Width / (double)(Screen.PrimaryScreen.Bounds.Width / (double)1280);
                double newHeight = (double)CardHolderPanel.Size.Height / (double)(Screen.PrimaryScreen.Bounds.Height / (double)720);
                globalWidth = (int)newWidth;
                globalHeight = (int)newHeight;
                CardHolderPanel.MaximumSize = new Size(globalWidth, globalHeight);
                CardHolderPanel.Size = new Size(globalWidth, globalHeight);
                Resizer(CardHolderPanel.Top, CardHolderPanel.Left);
                CardHolderPanel.Top = globalTop;
                CardHolderPanel.Left = globalLeft;
            }
        }

        //timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            CardHolder1.Image = Properties.Resources.backSite;
            CardHolder2.Image = Properties.Resources.backSite;
            CardHolder1 = null;
            CardHolder2 = null;
        }

        //static Random rand = new Random();
        //int randRange = rand.Next(1, 7);

        string correctAnswer = "";
        string[] arr = new string[4];

        int i = 0;
        public void IfMovesAreZero(int moves)
        {
            if(victory.Visible == false)
            {
                if (i == 0)
                {
                    CardHolderPanel.Visible = false;
                    movesLabel.Visible = false;
                    movesPicBox.Visible = false;
                    questionsLabel.Visible = true;
                    //questionsLabel.Text = GetLine("../../questions.txt", randRange);

                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;

                    //arr = GetLine("../../answers.txt", randRange).Split(',').ToArray();
                    button1.Text = arr[0];
                    button2.Text = arr[1];
                    button3.Text = arr[2];
                    button4.Text = arr[3];

                    //correctAnswer = GetLine("../../correctAnswer.txt", randRange);
                    i++;
                }
                else
                {
                    CardHolderPanel.Visible = false;
                    movesLabel.Visible = false;
                    movesPicBox.Visible = false;

                    gameOver.Visible = true;
                    tryAgain.Visible = true;
                }
            }
            
        }

        #region Cards

        private void card1_Click(object sender, EventArgs e)
        {
            card1.Image = Properties.Resources.img1;



            count = count + 1;

            if(CardHolder1 == card1)
            {
                count = count - 1;
            }

            if (count == 2)
            {
                moves = moves - 1;
                movesLabel.Text = moves.ToString();
                count = 0;
            }

            
            if (CardHolder1 == null)
            {
                CardHolder1 = card1;
            }
            else if (CardHolder1 != null && CardHolder2 == null && CardHolder1 != card1)
            {
                CardHolder2 = card1;
            }
            if (CardHolder1 != null && CardHolder2 != null && CardHolder1 != card1)
            {
                if (CardHolder1.Tag == CardHolder2.Tag)
                {
                    CardHolder1 = null;
                    CardHolder2 = null;
                    card1.Enabled = false;
                    card2.Enabled = false;
                }
                else
                {
                    timer1.Start();
                }
            }
            if (card1.Enabled == false && card2.Enabled == false && card3.Enabled == false && card4.Enabled == false && card5.Enabled == false && card6.Enabled == false && card7.Enabled == false && card8.Enabled == false && card9.Enabled == false && card10.Enabled == false && card11.Enabled == false && card12.Enabled == false && card13.Enabled == false && card14.Enabled == false && card15.Enabled == false && card16.Enabled == false)
            {
                CardHolderPanel.Visible = false;
                movesLabel.Visible = false;
                movesPicBox.Visible = false;

                victory.Visible = true;
            }
            if (moves == 0)
            {
                IfMovesAreZero(moves);
            }
            //card1.Enabled = false;
        }

        private void card2_Click(object sender, EventArgs e)
        {
            card2.Image = Properties.Resources.img1;



            count = count + 1;
            if (CardHolder1 == card2)
            {
                count = count - 1;
            }
            if (count == 2)
            {
                moves = moves - 1;
                movesLabel.Text = moves.ToString();
                count = 0;
            }



            if (CardHolder1 == null)
            {
                CardHolder1 = card2;
            }
            else if (CardHolder1 != null && CardHolder2 == null && CardHolder1 != card2)
            {
                CardHolder2 = card2;
            }
            if (CardHolder1 != null && CardHolder2 != null && CardHolder1 != card2)
            {
                if (CardHolder1.Tag == CardHolder2.Tag)
                {
                    CardHolder1 = null;
                    CardHolder2 = null;
                    card1.Enabled = false;
                    card2.Enabled = false;
                }
                else
                {
                    timer1.Start();
                }
            }
            if (card1.Enabled == false && card2.Enabled == false && card3.Enabled == false && card4.Enabled == false && card5.Enabled == false && card6.Enabled == false && card7.Enabled == false && card8.Enabled == false && card9.Enabled == false && card10.Enabled == false && card11.Enabled == false && card12.Enabled == false && card13.Enabled == false && card14.Enabled == false && card15.Enabled == false && card16.Enabled == false)
            {
                CardHolderPanel.Visible = false;
                movesLabel.Visible = false;
                movesPicBox.Visible = false;

                victory.Visible = true;
            }
            if (moves == 0)
            {
                IfMovesAreZero(moves);
            }
        }

        private void card3_Click(object sender, EventArgs e)
        {
            card3.Image = Properties.Resources.img2;


            count = count + 1;
            if (CardHolder1 == card3)
            {
                count = count - 1;
            }
            if (count == 2)
            {
                moves = moves - 1;
                movesLabel.Text = moves.ToString();
                count = 0;
            }


            if (CardHolder1 == null)
            {
                CardHolder1 = card3;
            }
            else if (CardHolder1 != null && CardHolder2 == null && CardHolder1 != card3)
            {
                CardHolder2 = card3;
            }
            if (CardHolder1 != null && CardHolder2 != null && CardHolder1 != card3)
            {
                if (CardHolder1.Tag == CardHolder2.Tag)
                {
                    CardHolder1 = null;
                    CardHolder2 = null;
                    card3.Enabled = false;
                    card4.Enabled = false;
                }
                else
                {
                    timer1.Start();
                }
            }
            if (card1.Enabled == false && card2.Enabled == false && card3.Enabled == false && card4.Enabled == false && card5.Enabled == false && card6.Enabled == false && card7.Enabled == false && card8.Enabled == false && card9.Enabled == false && card10.Enabled == false && card11.Enabled == false && card12.Enabled == false && card13.Enabled == false && card14.Enabled == false && card15.Enabled == false && card16.Enabled == false)
            {
                CardHolderPanel.Visible = false;
                movesLabel.Visible = false;
                movesPicBox.Visible = false;

                victory.Visible = true;
            }
            if (moves == 0)
            {
                IfMovesAreZero(moves);
            }
        }

        private void card4_Click(object sender, EventArgs e)
        {
            card4.Image = Properties.Resources.img2;



            count = count + 1;
            if (CardHolder1 == card4)
            {
                count = count - 1;
            }
            if (count == 2)
            {
                moves = moves - 1;
                movesLabel.Text = moves.ToString();
                count = 0;
            }


            if (CardHolder1 == null)
            {
                CardHolder1 = card4;
            }
            else if (CardHolder1 != null && CardHolder2 == null && CardHolder1 != card4)
            {
                CardHolder2 = card4;
            }
            if (CardHolder1 != null && CardHolder2 != null && CardHolder1 != card4)
            {
                if (CardHolder1.Tag == CardHolder2.Tag)
                {
                    CardHolder1 = null;
                    CardHolder2 = null;
                    card3.Enabled = false;
                    card4.Enabled = false;
                }
                else
                {
                    timer1.Start();
                }
            }
            if (card1.Enabled == false && card2.Enabled == false && card3.Enabled == false && card4.Enabled == false && card5.Enabled == false && card6.Enabled == false && card7.Enabled == false && card8.Enabled == false && card9.Enabled == false && card10.Enabled == false && card11.Enabled == false && card12.Enabled == false && card13.Enabled == false && card14.Enabled == false && card15.Enabled == false && card16.Enabled == false)
            {
                CardHolderPanel.Visible = false;
                movesLabel.Visible = false;
                movesPicBox.Visible = false;

                victory.Visible = true;
            }
            if (moves == 0)
            {
                IfMovesAreZero(moves);
            }
        }

        
        private void card5_Click(object sender, EventArgs e)
        {
            card5.Image = Properties.Resources.img3;


            count = count + 1;
            if (CardHolder1 == card5)
            {
                count = count - 1;
            }
            if (count == 2)
            {
                moves = moves - 1;
                movesLabel.Text = moves.ToString();
                count = 0;
            }


            if (CardHolder1 == null)
            {
                CardHolder1 = card5;
            }
            else if (CardHolder1 != null && CardHolder2 == null && CardHolder1 != card5)
            {
                CardHolder2 = card5;
            }
            if (CardHolder1 != null && CardHolder2 != null && CardHolder1 != card5)
            {
                if (CardHolder1.Tag == CardHolder2.Tag)
                {
                    CardHolder1 = null;
                    CardHolder2 = null;
                    card5.Enabled = false;
                    card6.Enabled = false;
                }
                else
                {
                    timer1.Start();
                }
            }
            if (card1.Enabled == false && card2.Enabled == false && card3.Enabled == false && card4.Enabled == false && card5.Enabled == false && card6.Enabled == false && card7.Enabled == false && card8.Enabled == false && card9.Enabled == false && card10.Enabled == false && card11.Enabled == false && card12.Enabled == false && card13.Enabled == false && card14.Enabled == false && card15.Enabled == false && card16.Enabled == false)
            {
                CardHolderPanel.Visible = false;
                movesLabel.Visible = false;
                movesPicBox.Visible = false;

                victory.Visible = true;
            }
            if (moves == 0)
            {
                IfMovesAreZero(moves);
            }
        }

        private void card6_Click(object sender, EventArgs e)
        {
            card6.Image = Properties.Resources.img3;

         
            count = count + 1;
            if (CardHolder1 == card6)
            {
                count = count - 1;
            }
            if (count == 2)
            {
                moves = moves - 1;
                movesLabel.Text = moves.ToString();
                count = 0;
            }


            if (CardHolder1 == null)
            {
                CardHolder1 = card6;
            }
            else if (CardHolder1 != null && CardHolder2 == null && CardHolder1 != card6)
            {
                CardHolder2 = card6;
            }
            if (CardHolder1 != null && CardHolder2 != null && CardHolder1 != card6)
            {
                if (CardHolder1.Tag == CardHolder2.Tag)
                {
                    CardHolder1 = null;
                    CardHolder2 = null;
                    card5.Enabled = false;
                    card6.Enabled = false;
                }
                else
                {
                    timer1.Start();
                }
            }
            if (card1.Enabled == false && card2.Enabled == false && card3.Enabled == false && card4.Enabled == false && card5.Enabled == false && card6.Enabled == false && card7.Enabled == false && card8.Enabled == false && card9.Enabled == false && card10.Enabled == false && card11.Enabled == false && card12.Enabled == false && card13.Enabled == false && card14.Enabled == false && card15.Enabled == false && card16.Enabled == false)
            {
                CardHolderPanel.Visible = false;
                movesLabel.Visible = false;
                movesPicBox.Visible = false;

                victory.Visible = true;
            }
            if (moves == 0)
            {
                IfMovesAreZero(moves);
            }
        }

        private void card7_Click(object sender, EventArgs e)
        {
            card7.Image = Properties.Resources.img4;


            count = count + 1;
            if (CardHolder1 == card7)
            {
                count = count - 1;
            }
            if (count == 2)
            {
                moves = moves - 1;
                movesLabel.Text = moves.ToString();
                count = 0;
            }


            if (CardHolder1 == null)
            {
                CardHolder1 = card7;
            }
            else if (CardHolder1 != null && CardHolder2 == null && CardHolder1 != card7)
            {
                CardHolder2 = card7;
            }
            if (CardHolder1 != null && CardHolder2 != null && CardHolder1 != card7)
            {
                if (CardHolder1.Tag == CardHolder2.Tag)
                {
                    CardHolder1 = null;
                    CardHolder2 = null;
                    card7.Enabled = false;
                    card8.Enabled = false;
                }
                else
                {
                    timer1.Start();
                }
            }
            if (card1.Enabled == false && card2.Enabled == false && card3.Enabled == false && card4.Enabled == false && card5.Enabled == false && card6.Enabled == false && card7.Enabled == false && card8.Enabled == false && card9.Enabled == false && card10.Enabled == false && card11.Enabled == false && card12.Enabled == false && card13.Enabled == false && card14.Enabled == false && card15.Enabled == false && card16.Enabled == false)
            {
                CardHolderPanel.Visible = false;
                movesLabel.Visible = false;
                movesPicBox.Visible = false;

                victory.Visible = true;
            }

            if (moves == 0)
            {
                IfMovesAreZero(moves);
            }
        }

        private void card8_Click(object sender, EventArgs e)
        {
            card8.Image = Properties.Resources.img4;


            count = count + 1;
            if (CardHolder1 == card8)
            {
                count = count - 1;
            }
            if (count == 2)
            {
                moves = moves - 1;
                movesLabel.Text = moves.ToString();
                count = 0;
            }


            if (CardHolder1 == null)
            {
                CardHolder1 = card8;
            }
            else if (CardHolder1 != null && CardHolder2 == null && CardHolder1 != card8)
            {
                CardHolder2 = card8;
            }
            if (CardHolder1 != null && CardHolder2 != null && CardHolder1 != card8)
            {
                if (CardHolder1.Tag == CardHolder2.Tag)
                {
                    CardHolder1 = null;
                    CardHolder2 = null;
                    card7.Enabled = false;
                    card8.Enabled = false;
                }
                else
                {
                    timer1.Start();
                }
            }
            if (card1.Enabled == false && card2.Enabled == false && card3.Enabled == false && card4.Enabled == false && card5.Enabled == false && card6.Enabled == false && card7.Enabled == false && card8.Enabled == false && card9.Enabled == false && card10.Enabled == false && card11.Enabled == false && card12.Enabled == false && card13.Enabled == false && card14.Enabled == false && card15.Enabled == false && card16.Enabled == false)
            {
                CardHolderPanel.Visible = false;
                movesLabel.Visible = false;
                movesPicBox.Visible = false;

                victory.Visible = true;
            }
            if (moves == 0)
            {
                IfMovesAreZero(moves);
            }
        }

        private void card9_Click(object sender, EventArgs e)
        {
            card9.Image = Properties.Resources.img5;


            count = count + 1;
            if (CardHolder1 == card9)
            {
                count = count - 1;
            }
            if (count == 2)
            {
                moves = moves - 1;
                movesLabel.Text = moves.ToString();
                count = 0;
            }


            if (CardHolder1 == null)
            {
                CardHolder1 = card9;
            }
            else if (CardHolder1 != null && CardHolder2 == null && CardHolder1 != card9)
            {
                CardHolder2 = card9;
            }
            if (CardHolder1 != null && CardHolder2 != null && CardHolder1 != card9)
            {
                if (CardHolder1.Tag == CardHolder2.Tag)
                {
                    CardHolder1 = null;
                    CardHolder2 = null;
                    card9.Enabled = false;
                    card10.Enabled = false;
                }
                else
                {
                    timer1.Start();
                }
            }
            if (card1.Enabled == false && card2.Enabled == false && card3.Enabled == false && card4.Enabled == false && card5.Enabled == false && card6.Enabled == false && card7.Enabled == false && card8.Enabled == false && card9.Enabled == false && card10.Enabled == false && card11.Enabled == false && card12.Enabled == false && card13.Enabled == false && card14.Enabled == false && card15.Enabled == false && card16.Enabled == false)
            {
                CardHolderPanel.Visible = false;
                movesLabel.Visible = false;
                movesPicBox.Visible = false;

                victory.Visible = true;
            }
            if (moves == 0)
            {
                IfMovesAreZero(moves);
            }
        }

        private void card10_Click(object sender, EventArgs e)
        {
            card10.Image = Properties.Resources.img5;


            count = count + 1;
            if (CardHolder1 == card10)
            {
                count = count - 1;
            }
            if (count == 2)
            {
                moves = moves - 1;
                movesLabel.Text = moves.ToString();
                count = 0;
            }


            if (CardHolder1 == null)
            {
                CardHolder1 = card10;
            }
            else if (CardHolder1 != null && CardHolder2 == null && CardHolder1 != card10)
            {
                CardHolder2 = card10;
            }
            if (CardHolder1 != null && CardHolder2 != null && CardHolder1 != card10)
            {
                if (CardHolder1.Tag == CardHolder2.Tag)
                {
                    CardHolder1 = null;
                    CardHolder2 = null;
                    card9.Enabled = false;
                    card10.Enabled = false;
                }
                else
                {
                    timer1.Start();
                }
            }
            if (card1.Enabled == false && card2.Enabled == false && card3.Enabled == false && card4.Enabled == false && card5.Enabled == false && card6.Enabled == false && card7.Enabled == false && card8.Enabled == false && card9.Enabled == false && card10.Enabled == false && card11.Enabled == false && card12.Enabled == false && card13.Enabled == false && card14.Enabled == false && card15.Enabled == false && card16.Enabled == false)
            {
                CardHolderPanel.Visible = false;
                movesLabel.Visible = false;
                movesPicBox.Visible = false;

                victory.Visible = true;
            }
            if (moves == 0)
            {
                IfMovesAreZero(moves);
            }
        }

        private void card11_Click(object sender, EventArgs e)
        {
            card11.Image = Properties.Resources.img6;


            count = count + 1;
            if (CardHolder1 == card11)
            {
                count = count - 1;
            }
            if (count == 2)
            {
                moves = moves - 1;
                movesLabel.Text = moves.ToString();
                count = 0;
            }


            if (CardHolder1 == null)
            {
                CardHolder1 = card11;
            }
            else if (CardHolder1 != null && CardHolder2 == null && CardHolder1 != card11)
            {
                CardHolder2 = card11;
            }
            if (CardHolder1 != null && CardHolder2 != null && CardHolder1 != card11)
            {
                if (CardHolder1.Tag == CardHolder2.Tag)
                {
                    CardHolder1 = null;
                    CardHolder2 = null;
                    card11.Enabled = false;
                    card12.Enabled = false;
                }
                else
                {
                    timer1.Start();
                }
            }
            if (card1.Enabled == false && card2.Enabled == false && card3.Enabled == false && card4.Enabled == false && card5.Enabled == false && card6.Enabled == false && card7.Enabled == false && card8.Enabled == false && card9.Enabled == false && card10.Enabled == false && card11.Enabled == false && card12.Enabled == false && card13.Enabled == false && card14.Enabled == false && card15.Enabled == false && card16.Enabled == false)
            {
                CardHolderPanel.Visible = false;
                movesLabel.Visible = false;
                movesPicBox.Visible = false;

                victory.Visible = true;
            }
            if (moves == 0)
            {
                IfMovesAreZero(moves);
            }
        }

        private void card12_Click(object sender, EventArgs e)
        {
            card12.Image = Properties.Resources.img6;


            count = count + 1;
            if (CardHolder1 == card12)
            {
                count = count - 1;
            }
            if (count == 2)
            {
                moves = moves - 1;
                movesLabel.Text = moves.ToString();
                count = 0;
            }


            if (CardHolder1 == null)
            {
                CardHolder1 = card12;
            }
            else if (CardHolder1 != null && CardHolder2 == null && CardHolder1 != card12)
            {
                CardHolder2 = card12;
            }
            if (CardHolder1 != null && CardHolder2 != null && CardHolder1 != card12)
            {
                if (CardHolder1.Tag == CardHolder2.Tag)
                {
                    CardHolder1 = null;
                    CardHolder2 = null;
                    card11.Enabled = false;
                    card12.Enabled = false;
                }
                else
                {
                    timer1.Start();
                }
            }
            if (card1.Enabled == false && card2.Enabled == false && card3.Enabled == false && card4.Enabled == false && card5.Enabled == false && card6.Enabled == false && card7.Enabled == false && card8.Enabled == false && card9.Enabled == false && card10.Enabled == false && card11.Enabled == false && card12.Enabled == false && card13.Enabled == false && card14.Enabled == false && card15.Enabled == false && card16.Enabled == false)
            {
                CardHolderPanel.Visible = false;
                movesLabel.Visible = false;
                movesPicBox.Visible = false;

                victory.Visible = true;
            }
            if (moves == 0)
            {
                IfMovesAreZero(moves);
            }
        }

        private void card13_Click(object sender, EventArgs e)
        {
            card13.Image = Properties.Resources.img7;



            count = count + 1;
            if (CardHolder1 == card13)
            {
                count = count - 1;
            }
            if (count == 2)
            {
                moves = moves - 1;
                movesLabel.Text = moves.ToString();
                count = 0;
            }


            if (CardHolder1 == null)
            {
                CardHolder1 = card13;
            }
            else if (CardHolder1 != null && CardHolder2 == null && CardHolder1 != card13)
            {
                CardHolder2 = card13;
            }
            if (CardHolder1 != null && CardHolder2 != null && CardHolder1 != card13)
            {
                if (CardHolder1.Tag == CardHolder2.Tag)
                {
                    CardHolder1 = null;
                    CardHolder2 = null;
                    card13.Enabled = false;
                    card14.Enabled = false;
                }
                else
                {
                    timer1.Start();
                }
            }
            if (card1.Enabled == false && card2.Enabled == false && card3.Enabled == false && card4.Enabled == false && card5.Enabled == false && card6.Enabled == false && card7.Enabled == false && card8.Enabled == false && card9.Enabled == false && card10.Enabled == false && card11.Enabled == false && card12.Enabled == false && card13.Enabled == false && card14.Enabled == false && card15.Enabled == false && card16.Enabled == false)
            {
                CardHolderPanel.Visible = false;
                movesLabel.Visible = false;
                movesPicBox.Visible = false;

                victory.Visible = true;
            }
            if (moves == 0)
            {
                IfMovesAreZero(moves);
            }
        }

        private void card14_Click(object sender, EventArgs e)
        {
            card14.Image = Properties.Resources.img7;



            count = count + 1;
            if (CardHolder1 == card14)
            {
                count = count - 1;
            }
            if (count == 2)
            {
                moves = moves - 1;
                movesLabel.Text = moves.ToString();
                count = 0;
            }


            if (CardHolder1 == null)
            {
                CardHolder1 = card14;
            }
            else if (CardHolder1 != null && CardHolder2 == null && CardHolder1 != card14)
            {
                CardHolder2 = card14;
            }
            if (CardHolder1 != null && CardHolder2 != null && CardHolder1 != card14)
            {
                if (CardHolder1.Tag == CardHolder2.Tag)
                {
                    CardHolder1 = null;
                    CardHolder2 = null;
                    card13.Enabled = false;
                    card14.Enabled = false;
                }
                else
                {
                    timer1.Start();
                }
            }
            if (card1.Enabled == false && card2.Enabled == false && card3.Enabled == false && card4.Enabled == false && card5.Enabled == false && card6.Enabled == false && card7.Enabled == false && card8.Enabled == false && card9.Enabled == false && card10.Enabled == false && card11.Enabled == false && card12.Enabled == false && card13.Enabled == false && card14.Enabled == false && card15.Enabled == false && card16.Enabled == false)
            {
                CardHolderPanel.Visible = false;
                movesLabel.Visible = false;
                movesPicBox.Visible = false;

                victory.Visible = true;
            }
            if (moves == 0)
            {
                IfMovesAreZero(moves);
            }
        }

        private void card15_Click(object sender, EventArgs e)
        {
            card15.Image = Properties.Resources.img8;



            count = count + 1;
            if (CardHolder1 == card15)
            {
                count = count - 1;
            }
            if (count == 2)
            {
                moves = moves - 1;
                movesLabel.Text = moves.ToString();
                count = 0;
            }


            if (CardHolder1 == null)
            {
                CardHolder1 = card15;
            }
            else if (CardHolder1 != null && CardHolder2 == null && CardHolder1 != card15)
            {
                CardHolder2 = card15;
            }
            if (CardHolder1 != null && CardHolder2 != null && CardHolder1 != card15)
            {
                if (CardHolder1.Tag == CardHolder2.Tag)
                {
                    CardHolder1 = null;
                    CardHolder2 = null;
                    card15.Enabled = false;
                    card16.Enabled = false;
                }
                else
                {
                    timer1.Start();
                }
            }
            if (card1.Enabled == false && card2.Enabled == false && card3.Enabled == false && card4.Enabled == false && card5.Enabled == false && card6.Enabled == false && card7.Enabled == false && card8.Enabled == false && card9.Enabled == false && card10.Enabled == false && card11.Enabled == false && card12.Enabled == false && card13.Enabled == false && card14.Enabled == false && card15.Enabled == false && card16.Enabled == false)
            {
                CardHolderPanel.Visible = false;
                movesLabel.Visible = false;
                movesPicBox.Visible = false;

                victory.Visible = true;
            }
            if (moves == 0)
            {
                IfMovesAreZero(moves);
            }
        }

        private void card16_Click(object sender, EventArgs e)
        {
            card16.Image = Properties.Resources.img8;



            count = count + 1;
            if (CardHolder1 == card16)
            {
                count = count - 1;
            }
            if (count == 2)
            {
                moves = moves - 1;
                movesLabel.Text = moves.ToString();
                count = 0;
            }


            if (CardHolder1 == null)
            {
                CardHolder1 = card16;
            }
            else if (CardHolder1 != null && CardHolder2 == null && CardHolder1 != card16)
            {
                CardHolder2 = card16;
            }
            if (CardHolder1 != null && CardHolder2 != null && CardHolder1 != card16)
            {
                if (CardHolder1.Tag == CardHolder2.Tag)
                {
                    CardHolder1 = null;
                    CardHolder2 = null;
                    card15.Enabled = false;
                    card16.Enabled = false;        
                }
                else
                {
                    timer1.Start();
                }
            }
            if (card1.Enabled == false && card2.Enabled == false && card3.Enabled == false && card4.Enabled == false && card5.Enabled == false && card6.Enabled == false && card7.Enabled == false && card8.Enabled == false && card9.Enabled == false && card10.Enabled == false && card11.Enabled == false && card12.Enabled == false && card13.Enabled == false && card14.Enabled == false && card15.Enabled == false && card16.Enabled == false)
            {
                CardHolderPanel.Visible = false;
                movesLabel.Visible = false;
                movesPicBox.Visible = false;

                victory.Visible = true;
            }
            if (moves == 0)
            {
                IfMovesAreZero(moves);
            }
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            if (correctAnswer == arr[0])
            {
                if (chek == 0)
                {
                    moves = moves + 3;
                    movesLabel.Text = moves.ToString();
                    chek++;
                }

                CardHolderPanel.Visible = true;
                movesLabel.Visible = true;
                movesPicBox.Visible = true;

                questionsLabel.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
            }
            else
            {
                gameOver.Visible = true;
                tryAgain.Visible = true;

                questionsLabel.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
            }
        }
        int chek = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            if (correctAnswer == arr[1])
            {
                if (chek == 0)
                {
                    moves = moves + 3;
                    movesLabel.Text = moves.ToString();
                    chek++;
                }

                CardHolderPanel.Visible = true;
                movesLabel.Visible = true;
                movesPicBox.Visible = true;

                questionsLabel.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
            }
            else
            {
                gameOver.Visible = true;
                tryAgain.Visible = true;

                questionsLabel.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (correctAnswer == arr[2])
            {
                if (chek == 0)
                {
                    moves = moves + 3;
                    movesLabel.Text = moves.ToString();
                    chek++;
                }

                CardHolderPanel.Visible = true;
                movesLabel.Visible = true;
                movesPicBox.Visible = true;

                questionsLabel.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
            }
            else
            {
                gameOver.Visible = true;
                tryAgain.Visible = true;

                questionsLabel.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (correctAnswer == arr[3])
            {
                if (chek == 0)
                {
                    moves = moves + 3;
                    movesLabel.Text = moves.ToString();
                    chek++;
                }

                CardHolderPanel.Visible = true;
                movesLabel.Visible = true;
                movesPicBox.Visible = true;

                questionsLabel.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
            }
            else
            {
                gameOver.Visible = true;
                tryAgain.Visible = true;

                questionsLabel.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
            }
        }

        private void tryAgain_MouseEnter(object sender, EventArgs e)
        {
            tryAgain.Image = Resources.tryAgainShadow;
        }

        private void tryAgain_MouseLeave(object sender, EventArgs e)
        {
            tryAgain.Image = Resources.tryAgain;
        }

        private void tryAgain_Click(object sender, EventArgs e)
        {
            gameOver.Visible = false;
            start_Click(sender, e);
        }
    }
}