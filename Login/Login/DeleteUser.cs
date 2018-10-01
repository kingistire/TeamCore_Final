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
    public partial class DeleteUser : Form {
        SqlCommand cmd;
        SqlConnection con;
        String profileId;

        public DeleteUser(String toDeleteId) {
            profileId = toDeleteId;
            InitializeComponent();
            this.Location = new Point(0, 0);
            tbID.Text = toDeleteId;
        }

        private void btnSave_Click_1(object sender, EventArgs e) {
            con = new SqlConnection(@"Data Source =(LocalDB)\MSSQLLocalDB;" + 
                @"AttachDbFilename = |DataDirectory|\CapstoneDB\CapstoneDB.mdf; Integrated Security = True");
            string query = "DELETE FROM UserInformation WHERE Id='" + profileId + "';";
            cmd = new SqlCommand(query, con);
            SqlDataReader myReader;
            try {
                con.Open();
                myReader = cmd.ExecuteReader();
                MessageBox.Show("User has been deleted successfully.");
                this.Close();
                while (myReader.Read()){ }
            } catch (Exception ex) {
                MessageBox.Show("An error has occurred: " + ex);
            }
            }
        }
    }
