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
    public partial class ViewResultsTable : Form {
        public ViewResultsTable() {
            InitializeComponent();
        }

        private void ViewResultsTable_Load(object sender, EventArgs e) {
            string constring = @"Data Source =(LocalDB)\MSSQLLocalDB;" +
            @"AttachDbFilename = |DataDirectory|\CapstoneDB\CapstoneDB.mdf; Integrated Security = True";
            SqlConnection conDatabase = new SqlConnection(constring);
            SqlCommand cmdDatabase = new SqlCommand(" select * from Summary ;", conDatabase);
            try {
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmdDatabase;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = dbdataset;
                dataGridView1.DataSource = bSource;
                sda.Update(dbdataset);
                //need to write a for loop to iteratively set the column width for each column
                //DataGridViewColumn column = dataGridView.Columns[0];
                //column.Width = 60;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
