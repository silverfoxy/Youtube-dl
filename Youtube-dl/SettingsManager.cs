using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Youtube_dl
{
    class SettingsManager
    {
        StreamReader reader;
        public string encUsername = null;
        public string encPassword = null;
        public string serverIP = null;
        public int? serverPort = null;

        static string USERNAME = "USERNAME";
        static string PASSWORD = "PASSWORD";
        static string SERVER_IP = "SERVER_IP";
        static string SERVER_PORT = "SERVER_PORT";

        /// <summary>
        /// Reads settings from settings file
        /// </summary>
        /// <param name="SettingsFileAddress"></param>
        public SettingsManager(string SettingsFileAddress)
        {
            try
            {
                if (File.Exists(SettingsFileAddress))
                {
                    using (reader = new StreamReader(SettingsFileAddress))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line.Contains(SERVER_IP))
                            {
                                serverIP = (string)line.Split('=').GetValue(1);
                            }
                            else if (line.Contains(SERVER_PORT))
                            {
                                serverPort = int.Parse((string)line.Split('=').GetValue(1));
                            }
                            else if (line.Contains(USERNAME))
                            {
                                encUsername = line.Remove(0, USERNAME.Length + 1);
                            }
                            else if (line.Contains(PASSWORD))
                            {
                                encPassword = line.Remove(0, PASSWORD.Length + 1);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Writes the settings to settings file
        /// </summary>
        /// <param name="encryptedUsername"></param>
        /// <param name="encryptedPassword"></param>
        /// <param name="serverIP"></param>
        /// <param name="serverPort"></param>
        public SettingsManager(string encryptedUsername, string encryptedPassword, string serverIP, int? serverPort, string settingsFileAddress)
        {
            try
            {
                if (File.Exists(settingsFileAddress))
                {
                    File.Delete(settingsFileAddress);
                }
                using (StreamWriter writer = new StreamWriter(settingsFileAddress, false))
                {
                    if (serverIP != null)
                    {
                        writer.WriteLine(SERVER_IP + "=" + serverIP);
                    }
                    if (serverPort != null)
                    {
                        writer.WriteLine(SERVER_PORT + "=" + serverPort.ToString());
                    }
                    if (encryptedUsername != null)
                    {
                        writer.WriteLine(USERNAME + "=" + encryptedUsername);
                    }
                    if (encryptedPassword != null)
                    {
                        writer.WriteLine(PASSWORD + "=" + encryptedPassword);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
