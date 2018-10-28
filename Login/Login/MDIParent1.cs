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

            UserManagement userMngment = new UserManagement();
            userMngment.MdiParent = this;
            userMngment.Show();

        }

        //this code is supposed to check if form exists when you try to open it
        //if it does exist, bring it to front, otherwise create new instance
        /*public bool IsFormOpen(Type formType) {
            foreach (Form form in Application.OpenForms)
                if (form.GetType().Name == form.Name)
                    return true;
            return false;
        }
        //Then to check and instantiate form1
        if(!IsFormOpen(typeof (form1))
        form1 is not open*/

        private void label1_Click(object sender, EventArgs e) {
            //label1.Text = ((Form)this.MdiParent).Controls.["label1"]
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e) {
            SelectInterview selectInterview = new SelectInterview();
            selectInterview.Show();
        }

        private void userManagementToolStripMenuItem_Click(object sender, EventArgs e) {
            UserManagement viewUserManagment = new UserManagement();
            viewUserManagment.MdiParent = this;
            viewUserManagment.Show();
        }
    }
}
