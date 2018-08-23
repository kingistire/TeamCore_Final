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
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;

        public EditUser1() {
            InitializeComponent();
        }

        private void btnSave_Click_1(object sender, EventArgs e) {
            string idValue = tbID.Text;
            EditUser2 editUserProfile2 = new EditUser2(idValue);
            editUserProfile2.MdiParent = MDIParent1.ActiveForm;
            editUserProfile2.Show();     
        }
    }
}
