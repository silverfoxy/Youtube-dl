using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Renci.SshNet;

namespace Youtube_dl
{
    public partial class Logon : Form
    {
        public Logon(string username, string password, string serverip, int serverport)
        {
            InitializeComponent();
            textBox_username.Text = username;
            textBox_password.Text = password;
            textBox_ip.Text = serverip;
            if (serverport != 0)
                textBox_port.Text = serverport.ToString();
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            Crypt cr = new Crypt();
            string encUsername = cr.Encrypt(textBox_username.Text, "1i2dpMdSp1npd?!_1wi-1dijw1");
            string encPassword = cr.Encrypt(textBox_password.Text, "!@a0s0kdasdASKF424GG*Rergl)");
            string serverip = textBox_ip.Text;
            int serverport = int.Parse(textBox_port.Text);
            //save to file
            SettingsManager manager = new SettingsManager(encUsername, encPassword, serverip, serverport, Properties.Resources.SETTINGS_FILE_ADDRESS);
            int port = 0;
            try
            {
                port = int.Parse(textBox_port.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Port", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            Cursor = Cursors.WaitCursor;
            if (ValidateCredentials(textBox_username.Text, textBox_password.Text, textBox_ip.Text, port))
            {
                Cursor = Cursors.Default;
                this.Close();   
            }
            else
                Cursor = Cursors.Default;
        }

        private bool ValidateCredentials(string username, string password, string serverip, int serverport)
        {
            if (username != null && password != null && serverip != null && serverport != 0)
            {
                try
                {
                    using (var sshClient = new SshClient(serverip, serverport, username, password))
                    {
                        sshClient.Connect();
                        sshClient.Disconnect();
                    }
                    return true;
                }
                catch (Exception)
                {
                    MessageBox.Show("The information was not valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            return false;
        }
    }
}
