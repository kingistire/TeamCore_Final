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
using System.IO;

namespace Login {

    public partial class Login : Form {

        public Login() {
            InitializeComponent();
            
        }

        private void btnNewAcc_Click(object sender, EventArgs e) {
            this.Hide();
            NewOTAccount newAcc = new NewOTAccount();
            newAcc.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e) {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source =(LocalDB)\MSSQLLocalDB;" + @"AttachDbFilename = |DataDirectory|\CapstoneDB\CapstoneDB.mdf; Integrated Security = True";
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select fName, lName from Login Where email='" + tbEmail.Text + "' and Password='" + tbPassword.Text + "'",con);
            DataTable dt = new System.Data.DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 1) {
                this.Hide();
                MDIParent1 ss = new MDIParent1();
                ss.Show();
                Globals.adminID = dt.Rows[0][0].ToString() + " " + dt.Rows[0][1].ToString();
            }
            else {
                MessageBox.Show("Incorrect Username or Password.\nPlease try again.");
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            NewOTAccount newAcc = new NewOTAccount();          
            newAcc.Show();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
