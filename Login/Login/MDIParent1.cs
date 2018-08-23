using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Login {
    public partial class MDIParent1 : Form {

        public MDIParent1() {
            InitializeComponent();
            //Interview newInterview = new Interview();
            //newInterview.MdiParent = this;
            //newInterview.Show();
        }

        private void interviewToolStripMenuItem_Click(object sender, EventArgs e) {
            Interview newInterview = new Interview();
            newInterview.MdiParent = this;
            newInterview.Show();
        }

        private void label1_Click(object sender, EventArgs e) {
            //label1.Text = ((Form)this.MdiParent).Controls.["label1"]
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e) {
            AddUser newUser = new AddUser();
            newUser.MdiParent = this;
            newUser.Show();
        }

        private void viewUserProfilesToolStripMenuItem_Click(object sender, EventArgs e) {
            ViewUsers viewUserProfiles = new ViewUsers();
            viewUserProfiles.MdiParent = this;
            viewUserProfiles.Show();
        }

        private void deleteUserToolStripMenuItem1_Click(object sender, EventArgs e) {
            DeleteUser deleteUserProfile = new DeleteUser();
            deleteUserProfile.MdiParent = this;
            deleteUserProfile.Show();
        }

        private void editExistingUserToolStripMenuItem_Click(object sender, EventArgs e) {
            EditUser1 editUserProfile1 = new EditUser1();
            editUserProfile1.MdiParent = this;
            editUserProfile1.Show();
        }
    }
}
