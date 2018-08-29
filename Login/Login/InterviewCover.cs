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
    public partial class InterviewCover : Form {
        public InterviewCover() {
            InitializeComponent();
            this.Location = new Point(0, 0);
        }

        private void button2_Click(object sender, EventArgs e) {
            
            Interview interviewForm1 = new Interview();
            interviewForm1.MdiParent = MdiParent;
            interviewForm1.Show();
            this.Close();
            
        }
    }
}
