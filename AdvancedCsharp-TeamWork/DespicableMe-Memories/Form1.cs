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

namespace DespicableMe_Memories
{
    public partial class MainForm : Form
    {
        static PictureBox fixedStart;

        static string fullscreenSetting = "fullscreen";
        static string soundSetting = "sound";

        static string fullscreenSettingState = ReadSetting(fullscreenSetting);
        static string soundSettingState = ReadSetting(soundSetting);

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

            if (fullscreenSettingState == "true")
            {
                fullscreenOn.Image = Resources.onShadow;
                fullscreenOff.Image = Resources.off;
            }
            else if (fullscreenSettingState == "false")
            {
                fullscreenOn.Image = Resources.on;
                fullscreenOff.Image = Resources.offShadow;
            }

        }

        static public void MakeTransparent(Control button, System.Drawing.Point pos)
        {
            pos = fixedStart.PointToClient(pos);
            button.Parent = fixedStart;
            button.Location = pos;
            button.BackColor = Color.Transparent;
        }
        //-----------On-Click-Function-----------\\
        private void start_Click(object sender, EventArgs e)
        {
            StartMenu.Visible = false;

        }

        private void score_Click(object sender, EventArgs e)
        {

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

            start.Visible = true;
            score.Visible = true;
            options.Visible = true;
            exit.Visible = true;
            help.Visible = true;
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

        private void fullscreenOn_Click(object sender, EventArgs e)
        {
            AddUpdateAppSettings(fullscreenSetting, "true");
            fullscreenOn.Image = Resources.onShadow;
            fullscreenOff.Image = Resources.off;
        }

        private void fullscreenOff_Click(object sender, EventArgs e)
        {
            AddUpdateAppSettings(fullscreenSetting, "false");
            fullscreenOff.Image = Resources.offShadow;
            fullscreenOn.Image = Resources.on;
        }

        private void soundOn_Click(object sender, EventArgs e)
        {
            AddUpdateAppSettings(soundSetting, "true");
            soundOn.Image = Resources.onShadow;
            soundOff.Image = Resources.off;
        }

        private void soundOff_Click(object sender, EventArgs e)
        {
            AddUpdateAppSettings(soundSetting, "false");
            soundOff.Image = Resources.offShadow;
            soundOn.Image = Resources.on;
        }

    }
}
