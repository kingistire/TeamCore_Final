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
    public partial class GuidedInterviewCover : Form {
        public GuidedInterviewCover() {
            InitializeComponent();
            this.Location = new Point(0, 0);
        }

        private void button2_Click(object sender, EventArgs e) {
            GuidedInterview guidedInt = new GuidedInterview();
            guidedInt.Show();
            this.Close();
            
        }
    }
}
