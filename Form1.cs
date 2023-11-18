using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace kamera
{
    public partial class Form1 : Form
    {
        WebCam camera;
        public Form1()
        {
            InitializeComponent();
        }

        private void form1_load(object sender, EventArgs e)
        {
            // inicjalizacja kamery
            camera = new WebCam();
            camera.Container = pictureBoxCam;

            pictureBoxCam.Image = new Bitmap(pictureBoxCam.Width, pictureBoxCam.Height);

        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            camera.OpenConnection();
            activateButtons();

           // Task.Run(() => ProcessFrames());
        }

        private void activateButtons()
        {
            // aktywacja przycisków (po wykryciu kamery)
            buttonStart.Enabled = true;
            buttonSnapshot.Enabled = true;
            buttonChangeParameters.Enabled = true;
            buttonChangeResolution.Enabled = true;
            buttonDisconnect.Enabled = true;
            buttonConnect.Enabled = false;
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            camera.Dispose();
            disableButtons();
        }

        private void disableButtons()
        {
            // dezaktywacja przyciskow po rozlaczeniu sie z kamera
            buttonStart.Enabled = false;
            buttonStop.Enabled = false;
            buttonSnapshot.Enabled = false;
            buttonChangeParameters.Enabled = false;
            buttonChangeResolution.Enabled = false;
            buttonDisconnect.Enabled = false;
            buttonConnect.Enabled = true;
        }

        private void buttonSnapshot_Click(object sender, EventArgs e)
        {
            camera.SaveImage();
        }

        private void form1_Closed(object sender, FormClosedEventArgs e)
        {
            // rozlaczenie sie z kamerą
            camera.Dispose();
        }

        private void buttonChangeResolution_Click(object sender, EventArgs e)
        {
            camera.ChangeResolution();
        }

        private void buttonChangeParameters_Click(object sender, EventArgs e)
        {
            camera.ChangeParameters();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            camera.StartRecord();
            buttonStop.Enabled = true;
            buttonStart.Enabled = false;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            camera.StopRecord();
            buttonStop.Enabled = false;
            buttonStart.Enabled = true;
        }

        private void ProcessFrames()
        {
            while (true)
            {
                if (pictureBoxCam.Image != null)
                {
                    Bitmap currentFrame = new Bitmap(pictureBoxCam.Image);
                    camera.ProcessFrame(currentFrame); // Przetwórz klatkę
                    
                    if (camera.MotionDetected())
                    {
                        ShowMotionNotification(); // Wyświetl powiadomienie o detekcji ruchu
                    }
                    
                }

                // Ustaw czas oczekiwania na kolejne przetwarzanie (w milisekundach)
                System.Threading.Thread.Sleep(1000);
            }
        }

        private void ShowMotionNotification()
        {
            MessageBox.Show("Wykryto ruch!");
        }
    }
}
