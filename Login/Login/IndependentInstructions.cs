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
        public IndependentInstructions() {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e) {
            IndependentInterview indInterview = new IndependentInterview();
            indInterview.Show();
            this.Close();
        }
    }
}
