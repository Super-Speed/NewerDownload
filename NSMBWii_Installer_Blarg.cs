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
        }
        int count;

        private void button1_Click(object sender, EventArgs e)
        {
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

                button1.Text = "Download In Process";
                button1.Enabled = false;
            
        }
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

            button1.Text = "Download!";
            button1.Enabled = true;

            using (ZipFile zip = ZipFile.Read("NewerNSMBW.zip"))
            {
                foreach (ZipEntry h in zip)
                {
                    h.Extract("");
                    //This forwards us to the next section of code.
                    Blarginator();
                }
            }
        }
        void Blarginator()
        {
            Directory.Move("NewerSMBW", comboBox1.Text);
            Directory.Move("riivolution", comboBox1.Text);
            File.Delete("NewerNSMBW.zip");
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