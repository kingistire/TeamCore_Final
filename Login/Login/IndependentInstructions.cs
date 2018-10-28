using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login {
    public partial class IndependentInstructions : Form {
        private System.Media.SoundPlayer instructionsPlayer = new System.Media.SoundPlayer();
        private void SetPlayerPath(string path)
        {
            try
            {
                instructionsPlayer.SoundLocation = path;
                instructionsPlayer.Load();
            }
            catch { }
        }

        public IndependentInstructions() {
            InitializeComponent();
            SetPlayerPath(@"..\..\resources\0. System\SelfInterview.wav");
        }

        private void btnSave_Click(object sender, EventArgs e) {
            IndependentInterview indInterview = new IndependentInterview();
            indInterview.Show();
            this.Close();
        }

        private void readOutLoudToggleBtn_Click(object sender, EventArgs e)
        {

        }

        private void loadReadOutLoudToggleBtn()
        {
            if (Globals.toggleReadOutLoad)
            {
                readOutLoudToggleBtn.Text = "ReadOutLoud: ON";
            }
            else
            {
                readOutLoudToggleBtn.Text = "ReadOutLoud: OFF";
            }
        }
            private void readOutLoudToggleBtn_Click_1(object sender, EventArgs e)
        {
            Globals.toggleReadOutLoad = !Globals.toggleReadOutLoad;
            loadReadOutLoudToggleBtn();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (Globals.toggleReadOutLoad)
            {
                instructionsPlayer.Play();
            }
        }
    }
}
