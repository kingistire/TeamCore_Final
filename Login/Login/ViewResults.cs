using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login {
    public partial class ViewResults : Form {
        public ViewResults() {
            InitializeComponent();
        }

        private void btnSave_Click_1(object sender, EventArgs e) {
            string constring = @"Data Source =(LocalDB)\MSSQLLocalDB;" +
                @"AttachDbFilename = |DataDirectory|\CapstoneDB\CapstoneDB.mdf; Integrated Security = True";
            SqlConnection conDatabase = new SqlConnection(constring);
            SqlCommand cmdDatabase = new SqlCommand(" SELECT * FROM Summary WHERE Id='" + tbID.Text + "';", conDatabase);
            Summary sum = new Summary();
            try {

                Console.WriteLine("Success");
                sum.Show();
            } catch (Exception ex) {
                MessageBox.Show("An error has occurred: " + ex);
            }

        }
    }
}
