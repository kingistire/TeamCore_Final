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
    public partial class IndependentCover : Form {
        public IndependentCover() {
            InitializeComponent();
            this.Location = new Point(0, 0);
            label2.Text = Globals.userID;
            label4.Text = Globals.adminID;
            label6.Text = DateTime.Now.ToString("d/M/yyyy");
        }

        private void button2_Click(object sender, EventArgs e) {
            IndependentInstructions independentInt = new IndependentInstructions();
            independentInt.Show();
            this.Close();          
        }
    }
}
