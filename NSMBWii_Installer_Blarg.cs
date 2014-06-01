using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Data;
using Ionic.Zip;
using System.Net;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace NewerDownload
{
    public partial class NSMBWii_Installer_Blarg : Form
    {
        public NSMBWii_Installer_Blarg()
        {
            InitializeComponent();
            //I'll clean up the code later in dev.
        }

        //All of our strings will go here.
        int count;
        string fileName;
        string destFile;
        string fileName2;
        string destFile2;
        //No string should pass this comment. >.<

        private void button1_Click(object sender, EventArgs e)
        {
            //If the user hasn't selected a drive, just set it to C:\, the default drive.
            if (comboBox1.Text == "")
            {
                MessageBox.Show("ERROR! Drive has not been selected!", "NewerInstall");
                comboBox1.Text = @"C:\";
            }
                WebClient client = new WebClient();
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);

                // Starts the download
                client.DownloadFileAsync(new Uri("http://newerteam.com/getNewerFile.php"), "NewerNSMBW.zip");

                //We want to disable the controls, as users shouldn't press the button more than once, it'll overload the program and destroy the world.
                button1.Text = "Download In Process";
                button1.Enabled = false;
            
        }

        //This code is to record the progress of the download in the ProgressBar.
        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = bytesIn / totalBytes * 100;

            progressBar1.Value = int.Parse(Math.Truncate(percentage).ToString());
        }

        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            //Display a messagebox once the download is complete.
            MessageBox.Show("Download Completed! Now extracting NewerNSMBWii!","NewerInstaller");

            //We can now renable the Button, and change the text.
            button1.Text = "Download!";
            button1.Enabled = true;

            //Using Ionic.dll, extract the downloaded NewerNSMBW.zip
            using (ZipFile zip = ZipFile.Read("NewerNSMBW.zip"))
            {
                zip.ExtractAll("NSMB", ExtractExistingFileAction.DoNotOverwrite);
                //This forwards us to the next code block, Blarginator.
                Blarginator();
            }
        }

        //This code is to copy the extracted folders to the SD Card\USB Drive. Then it deletes the Newer.zip.
        void Blarginator()
        {
                string[] files = System.IO.Directory.GetFiles("NSMB\\NewerSMBW");
                string[] files2 = System.IO.Directory.GetFiles("NSMB\\riivolution");
                // Copy the files and overwrite destination files if they already exist.
                foreach (string s in files)
                {

                    fileName = System.IO.Path.GetFileName(s);
                    destFile = System.IO.Path.Combine(comboBox1.Text, fileName);
                    System.IO.File.Copy(s, destFile, true);
                }

                foreach (string sr in files2)
                {

                    fileName2 = System.IO.Path.GetFileName(sr);
                    destFile2 = System.IO.Path.Combine(comboBox1.Text, fileName2);
                    System.IO.File.Copy(sr, destFile2, true);
                }

        }

        //Using System.Media, we are able to play .WAV files, if they are named 1.wav, 2.wav, etc.
        //Each click increases the integer count by 1.
        private void button2_Click(object sender, EventArgs e)
        {
            count++;
                switch (count)
                {
                    case 1:
                        SoundPlayer sound = new SoundPlayer(@"Music\1.wav");
                        sound.Play();
                        break;

                    case 2:
                        SoundPlayer sound2 = new SoundPlayer(@"Music\2.wav");
                        sound2.Play();
                        break;
                    case 3:
                        SoundPlayer sound3 = new SoundPlayer(@"Music\3.wav");
                        sound3.Play();
                        break;

                    case 4:
                        SoundPlayer sound4 = new SoundPlayer(@"Music\4.wav");
                        sound4.Play();
                        break;
                    case 5:
                        SoundPlayer sound5 = new SoundPlayer(@"Music\5.wav");
                        sound5.Play();
                        break;

                    case 6:
                        SoundPlayer sound6 = new SoundPlayer(@"Music\6.wav");
                        sound6.Play();
                        break;
                    case 7:
                        SoundPlayer sound7 = new SoundPlayer(@"Music\7.wav");
                        sound7.Play();
                        break;
                    case 8:
                        SoundPlayer sound8 = new SoundPlayer(@"Music\8.wav");
                        sound8.Play();
                        break;
                    case 9:
                        SoundPlayer sound9 = new SoundPlayer(@"Music\9.wav");
                        sound9.Play();
                        break;
                    case 10:
                        SoundPlayer sound10 = new SoundPlayer(@"Music\810.wav");
                        sound10.Play();
                        break;
            }
        }
    }
}