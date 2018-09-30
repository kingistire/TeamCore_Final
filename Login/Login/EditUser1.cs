using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Login {
    public partial class EditUser1 : Form {

        public EditUser1() {
            InitializeComponent();
            this.Location = new Point(0, 0);
        }

        private void btnSave_Click_1(object sender, EventArgs e) {
            string idValue = tbID.Text;
            //EditProfile editUserProfile2 = new EditProfile(idValue);
            //editUserProfile2.MdiParent = MDIParent1.ActiveForm;
            //editUserProfile2.Show();     
        }
    }
}
