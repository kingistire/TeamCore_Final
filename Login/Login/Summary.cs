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
    public partial class Summary : Form {
        public Summary() {
            InitializeComponent();
        }

        private const int MAXCATERGORIES = 23;
        private const int MAXIMAGES = 117;
        private const int MAXTABLECOLUMNS = 2;

        private void createTable(int numRows, int numImagesInSection) {
            Label[] labels = new Label[numImagesInSection];
            TableLayoutPanel tlp = new TableLayoutPanel();
            tlp.ColumnCount = MAXTABLECOLUMNS;
            tlp.RowCount = numImagesInSection;
            //Loop through and create a new label for the array
            //
            for(int i = 0; i < numImagesInSection; i++) {
                labels[i].Dock = DockStyle.Fill;
            }
        }

        private void Summary_Load(object sender, EventArgs e) {
            string constring = @"Data Source =(LocalDB)\MSSQLLocalDB;" +
                @"AttachDbFilename = |DataDirectory|\CapstoneDB\CapstoneDB.mdf; Integrated Security = True";
            SqlConnection conDatabase = new SqlConnection(constring);
            SqlCommand cmdDatabase = new SqlCommand("SELECT * FROM Summary;", conDatabase);
            try {
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmdDatabase;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = dbdataset;
                summaryDataGrid.DataSource = bSource;
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
