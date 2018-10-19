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
    public partial class GuidedInstructions : Form {
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

        public GuidedInstructions() {
            InitializeComponent();
            SetPlayerPath(@"..\..\resources\1. Hearing\1. Are there some sounds that you don't like_\1.1.0soundDontLikePath.wav");//MISSINGFILE
        }

        private void btnSave_Click(object sender, EventArgs e) {
            GuidedInterview guidedInt = new GuidedInterview();
            guidedInt.Show();
            this.Close();
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
        private void readOutLoudToggleBtn_Click(object sender, EventArgs e)
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
