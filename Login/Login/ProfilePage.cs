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

namespace Login
{
    public partial class ProfilePage : Form
    {
        DataGridViewRow thisUser;


        public ProfilePage(DataGridViewRow dataValue)
        {
            thisUser = dataValue;
            InitializeComponent();

            load_data();
            
        }

        private void load_data()
        {
            string constring = @"Data Source =(LocalDB)\MSSQLLocalDB;" +
                @"AttachDbFilename = |DataDirectory|\CapstoneDB\CapstoneDB.mdf; Integrated Security = True";
            SqlConnection conDatabase = new SqlConnection(constring);
            SqlCommand cmdDatabase = new SqlCommand(" select * from UserInformation ;", conDatabase);
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmdDatabase;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = dbdataset;
                interviewDataGrid.DataSource = bSource;
                sda.Update(dbdataset);
                //need to write a for loop to iteratively set the column width for each column
                //DataGridViewColumn column = dataGridView.Columns[0];
                //column.Width = 60;

                nameLabel.Text = thisUser.Cells[3].Value.ToString().Trim() + ' ' + thisUser.Cells[4].Value.ToString().Trim();
                genderLabel.Text = thisUser.Cells[5].Value.ToString().Trim();
                dobLabel.Text = thisUser.Cells[6].Value.ToString().Trim();
                phLabel.Text = thisUser.Cells[7].Value.ToString().Trim();
                mailLabel.Text = thisUser.Cells[8].Value.ToString().Trim();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void editUserDataBtn_Click(object sender, EventArgs e)
        {
            EditProfile editprofile = new EditProfile(thisUser);
            editprofile.MdiParent = this.MdiParent;
            editprofile.Show();
        }

        private void ProfilePage_Enter(object sender, EventArgs e)
        {
            load_data();
        }
    }
}
