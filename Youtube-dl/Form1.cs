using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Renci.SshNet;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Security.Cryptography;

namespace Youtube_dl
{
    public partial class Form1 : Form
    {
        string Video;
        List<string> qualities;
        static string SERVER_IP = null;
        static int SERVER_PORT = 0;
        static string SERVER_USERNAME = null;
        static string SERVER_PASSWORD = null;
        static string SETTINGS_FILE_ADDRESS;

        public Form1()
        {
            InitializeComponent();
            SETTINGS_FILE_ADDRESS = Properties.Resources.SETTINGS_FILE_ADDRESS;
            qualities = new List<string>();
            comboBox_quality.Items.Add(new ComboboxItem("Default Quality", 0));
            comboBox_quality.SelectedIndex = 0;
            SettingsManager manager = new SettingsManager(SETTINGS_FILE_ADDRESS);
            bool login = false;
            if (manager.serverIP != null)
            {
                SERVER_IP = manager.serverIP;
            }
            else
                login = true;
            if (manager.serverPort != null)
            {
                SERVER_PORT = (int)manager.serverPort;
            }
            else
                login = true;
            if (manager.encUsername != null)
            {
                Crypt cr = new Crypt();
                SERVER_USERNAME = cr.Decrypt(manager.encUsername, "1i2dpMdSp1npd?!_1wi-1dijw1");
            }
            else
                login = true;
            if (manager.encPassword != null)
            {
                Crypt cr = new Crypt();
                SERVER_PASSWORD = cr.Decrypt(manager.encPassword, "!@a0s0kdasdASKF424GG*Rergl)");
            }
            else
                login = true;
            if (login)
            {
                Login(SERVER_USERNAME, SERVER_PASSWORD, SERVER_IP, SERVER_PORT);
            }
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                textBox_link.Text = args[1];
                Update();
            }
        }

        private class ComboboxItem
        {
            public string Name;
            public int Value;
            public ComboboxItem(string name, int value)
            {
                Name = name; Value = value;
            }
            public override string ToString()
            {
                // Generates the text shown in the combo box
                return Name;
            }
        }

        private void button_download_Click(object sender, EventArgs e)
        {
            linkLabel_downloadlink.Visible = false;
            toolStripStatusLabel1.Text = "Connecting ...";
            Cursor = Cursors.WaitCursor;
            backgroundWorker1.RunWorkerAsync(comboBox_quality.SelectedItem);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                using (var sshClient = new SshClient(SERVER_IP, SERVER_PORT, SERVER_USERNAME, SERVER_PASSWORD))
                {
                    sshClient.Connect();
                    toolStripStatusLabel1.Text = "Connected";
                    SshCommand cmd;
                    ComboboxItem selectedItem = (ComboboxItem)e.Argument;
                    if (selectedItem.Name == "Default Quality")
                    {
                        cmd = sshClient.CreateCommand(string.Format("youtube-dl --no-mtime --output '/var/www/html/%(title)s-%(id)s.%(ext)s' {0}", textBox_link.Text));
                    }
                    else
                    {
                        cmd = sshClient.CreateCommand(string.Format("youtube-dl -f {0} --output '/var/www/html/%(title)s-%(id)s.%(ext)s' {1}", selectedItem.Value, textBox_link.Text));
                    }
                    toolStripStatusLabel1.Text = "Preparing to download";
                    var async = cmd.BeginExecute(null, null);
                    var reader = new StreamReader(cmd.OutputStream);
                    while (!async.IsCompleted)
                    {
                        Thread.Sleep(100);
                        var result = reader.ReadLine();
                        if (string.IsNullOrEmpty(result))
                        {
                            continue;
                        }
                        toolStripStatusLabel1.Text = result;
                        if (result.Contains("Destination"))
                        {
                            Video = (string)((string)result.Split(':').GetValue(1)).Split('/').GetValue(4);
                        }
                        if (result.Contains("has already been downloaded"))
                        {
                            Video = result;
                            int a = result.IndexOf("has already been downloaded");
                            Video = (string)result.Substring(12, result.IndexOf("has already been downloaded") - 12).Split('/').GetValue(3);
                        }
                    }
                    cmd.EndExecute(async);
                    sshClient.Disconnect();
                    toolStripStatusLabel1.Text = "Transfer to server completed.";
                }
            }
            catch (Exception)
            {
                toolStripStatusLabel1.Text = "Error occurred!";
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Cursor = Cursors.Default;
            linkLabel_downloadlink.Visible = true;
            linkLabel_downloadlink.Text = Video;
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo(string.Format("http://{0}/{1}", SERVER_IP, Video));
            Process.Start(sInfo);
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            Update();
        }

        void Update()
        {
            linkLabel_downloadlink.Visible = false;
            Cursor = Cursors.WaitCursor;
            backgroundWorker2.RunWorkerAsync();
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                using (var sshClient = new SshClient(SERVER_IP, SERVER_PORT, SERVER_USERNAME, SERVER_PASSWORD))
                {
                    toolStripStatusLabel1.Text = "Connecting ...";
                    sshClient.Connect();
                    toolStripStatusLabel1.Text = "Connected";
                    var cmd = sshClient.CreateCommand(string.Format("youtube-dl -F {0}", textBox_link.Text));
                    toolStripStatusLabel1.Text = "Querying available video qualities";
                    cmd.Execute();
                    var result = cmd.Result;
                    string[] items = result.Split('\n');
                    bool here = false;
                    qualities.Clear();
                    for (int i = 0; i < items.Length; i++)
                    {
                        if (here)
                        {
                            qualities.Add(items[i].Replace("\t", ""));
                        }
                        else if (items[i].Contains("Available formats:"))
                        {
                            here = true;
                        }
                    }
                    if (here == false)
                    {
                        throw new Exception("Could not query available qualities(video not found).");
                    }
                }
                toolStripStatusLabel1.Text = "";
                backgroundWorker2.ReportProgress(100);
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = ex.Message;
                backgroundWorker2.ReportProgress(0);
            }
        }

        private void UpdateQualities()
        {
            comboBox_quality.Items.Clear();

            foreach (string item in qualities)
            {
                if (item != string.Empty)
                {
                    comboBox_quality.Items.Add(new ComboboxItem((string)item.Split(':').GetValue(1), int.Parse((string)item.Split(':').GetValue(0))));
                }
            }
            comboBox_quality.SelectedIndex = 0;
            Cursor = Cursors.Default;
        }

        public delegate void UpdateQualitiesCallback();

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 0)
            {
                Cursor = Cursors.Default;   
            }
            else if (e.ProgressPercentage == 100)
            {
                if (comboBox_quality.InvokeRequired)
                {
                    comboBox_quality.Invoke(new UpdateQualitiesCallback(this.UpdateQualities));
                }
                else
                {
                    UpdateQualities();
                }
            }
        }

        private void textBox_link_TextChanged(object sender, EventArgs e)
        {
            comboBox_quality.Items.Clear();
            comboBox_quality.Items.Add(new ComboboxItem("Default Quality", 0));
            comboBox_quality.SelectedIndex = 0;
        }

        private void Login(string username, string password, string serverip, int serverport)
        {
            //if settings file does not contain user/pass
            Logon logon = new Logon(username, password, serverip, serverport);
            logon.ShowDialog();
        }

        private void button_settings_Click(object sender, EventArgs e)
        {
                Login(SERVER_USERNAME, SERVER_PASSWORD, SERVER_IP, SERVER_PORT);
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            textBox_link.Text = e.Data.ToString();
        }
    }
}
