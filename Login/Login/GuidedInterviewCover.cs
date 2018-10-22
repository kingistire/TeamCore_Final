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
            label2.Text = Globals.usersName;
            label4.Text = Globals.adminID;
            label6.Text = DateTime.Now.ToString("d/M/yyyy");
        }

        private void button2_Click(object sender, EventArgs e) {
            GuidedInstructions guidedInt = new GuidedInstructions();
            guidedInt.Show();
            this.Close();
            
        }
    }
}
