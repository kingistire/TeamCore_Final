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
        public GuidedInstructions() {
            InitializeComponent();
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
    }
}
