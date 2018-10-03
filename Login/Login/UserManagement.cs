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
    public partial class UserManagment : Form
    {
        public UserManagment()
        {
            InitializeComponent();
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
                userProfileManagmentGrid.DataSource = bSource;
                sda.Update(dbdataset);
                //need to write a for loop to iteratively set the column width for each column
                //DataGridViewColumn column = dataGridView.Columns[0];
                //column.Width = 60;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            load_data();
        }

        private void UserManagment_GotFocus(Object sender, EventArgs e)
        {
            load_data();

        }
        private void createProfileBtn_Click(object sender, EventArgs e)
        {

            //if (Globals.addUserExists == false)
            //{
                AddUser newUser = new AddUser();
                newUser.MdiParent = this.MdiParent;
                newUser.Show();
                //Globals.addUserExists = true;
            //}
            //    else
            //    { 
            //    AddUser.staticVar.BringToFront();
            //    }

            //
        }

        private void userProfileManagmentGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedProfile = userProfileManagmentGrid.Rows[e.RowIndex];
            if (e.RowIndex >= 0 && e.ColumnIndex == 0) // IF EDIT
            {
                
                EditProfile editprofile = new EditProfile(selectedProfile);
                editprofile.MdiParent = this.MdiParent;
                editprofile.Show();

                //...
            } else if (e.RowIndex >= 0 && e.ColumnIndex == 1)
            {
                


                ProfilePage profilePage = new ProfilePage(selectedProfile);
                profilePage.MdiParent = this.MdiParent;
                profilePage.Show();
            }
        }

        private void importProfilesBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature has not been developed yet!");
        }

        private void exportAllProfilesBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature has not been developed yet!");
        }
    }
}
