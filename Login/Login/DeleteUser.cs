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
        SqlDataAdapter da;

        public DeleteUser() {
            InitializeComponent();
        }

        private void btnSave_Click_1(object sender, EventArgs e) {
            con = new SqlConnection("Data Source=DESKTOP-G8RH1E3\\SQLEXPRESS;Initial Catalog=CapstoneDB;Integrated Security=True");
            string query = "DELETE FROM testUser WHERE Id='" + tbID.Text + "';";
            cmd = new SqlCommand(query, con);
            SqlDataReader myReader;
            try {
                con.Open();
                myReader = cmd.ExecuteReader();
                MessageBox.Show("User has been deleted successfully.");
                this.Close();
                while (myReader.Read()){ }
            } catch (Exception ex) {
            }
            }
        }
    }
