﻿using System;
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
        public IndependentInstructions() {
            InitializeComponent();
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
    }
}
