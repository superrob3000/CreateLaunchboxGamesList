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
using System.Xml.Linq;
using Unbroken.LaunchBox.Plugins;
using Unbroken.LaunchBox.Plugins.Data;

namespace RB_CreateGamesList
{
    public partial class CreateGamelist_Form : Form
    {
        public CreateGamelist_Form()
        {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                textBox_OutputFile.Text = file;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void button3_Click(object sender, EventArgs e)
        {

            if (textBox_OutputFile.Text.Length.Equals(0))
            {
                string message = "You must choose an output file.";
                const string caption = "Error";
                using (new CenterWinDialog(this))
                {
                    MessageBox.Show(message, caption,
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error);
                }
            }
            else
            {
                button_start.Enabled = false;
                Status.Visible = true;
                this.Refresh();

                //Open the file
                System.IO.StreamWriter file = null;
                try { file = new System.IO.StreamWriter(textBox_OutputFile.Text); }
                catch 
                {
                    string message = "Error creating the output file.";
                    const string caption = "Error";
                    using (new CenterWinDialog(this))
                    {
                        MessageBox.Show(message, caption,
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
                    }
                    button_start.Enabled = true;
                    Status.Visible = false;
                }

                if (button_start.Enabled == false)
                {
                    foreach (var platform in PluginHelper.DataManager.GetAllPlatforms())
                    {
                        SubWheelList.Add(new SubWheel(platform.Name, platform.SortTitle, platform, null));
                    }

                    if (checkBox_IncludePlaylists.Checked)
                    {
                        foreach (var playlist in PluginHelper.DataManager.GetAllPlaylists())
                        {
                            if (playlist.IncludeWithPlatforms || playlist.Name.Equals("Arcade - Mature Games"))
                            {
                                SubWheelList.Add(new SubWheel(playlist.Name, playlist.SortTitle, null, playlist));
                            }
                        }
                    }

                    //Put in alphabetical order.
                    SubWheelOrderedList = SubWheelList.OrderBy(o => o.SortTitle).ToList();


                    foreach(var subwheel in SubWheelOrderedList)
                    {
                        GameOrderedList.Clear();
                        GameList.Clear();

                        if (subwheel.Playlist != null)
                        {
                            foreach (var game in subwheel.Playlist.GetAllGames(false))
                            {
                                GameList.Add(new SubWheelGame(game.Title, game));
                            }

                        }
                        else
                        {
                            foreach (var game in subwheel.Platform.GetAllGames(true, false))
                            {
                                GameList.Add(new SubWheelGame(game.Title, game));
                            }

                        }

                        //Put in alphabetical order.
                        GameOrderedList = GameList.OrderBy(o => o.Name).ToList();

                        //Write these games out to the file.
                        if(subwheel.Platform != null)
                            file.WriteLine("*********** Platform: " + subwheel.Name + " ***********");
                        else
                            file.WriteLine("*********** Playlist: " + subwheel.Name + " ***********");

                        foreach (var game in GameOrderedList)
                        {
                            file.WriteLine(subwheel.Name + ", " + game.Name);
                        }

                        file.WriteLine("\r\n\r\n");
                    }

                    file.Flush();
                    file.Close();

                    Status.Visible = false;
                    this.Refresh();

                    string message = "Game list successfully written to:\r\n" + textBox_OutputFile.Text;
                    const string caption = "Success";

                    using (new CenterWinDialog(this))
                    {
                        MessageBox.Show(message, caption,
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Information);
                    }

                    this.Close();
                }
            }
        }


        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void listBox_platforms_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private List<SubWheel> SubWheelList = new List<SubWheel>();
        private List<SubWheel> SubWheelOrderedList;

        private List<SubWheelGame> GameList = new List<SubWheelGame>();
        private List<SubWheelGame> GameOrderedList = new List<SubWheelGame>();
    }

    public class SubWheel
    {
        public SubWheel(string name, string sortTitle,  IPlatform platform, IPlaylist playlist)
        {
            Name = name;
            SortTitle = sortTitle;
            Platform = platform;
            Playlist = playlist;
        }

        public string Name;
        public string SortTitle;
        public IPlatform Platform;
        public IPlaylist Playlist;
    }

    public class SubWheelGame
    {
        public SubWheelGame(string name, IGame game)
        {
            Name = name;
            Game = game;
        }

        public string Name;
        public IGame Game;
    }

}
