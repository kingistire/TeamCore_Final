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
using System.Text.RegularExpressions;


namespace Login
{
    public partial class UserManagment : Form
    {
        SqlCommand cmd;
        SqlConnection con;
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
            
            if (e.RowIndex >= 0 && e.ColumnIndex == 0) // IF EDIT
            {
                DataGridViewRow selectedProfile = userProfileManagmentGrid.Rows[e.RowIndex];
                EditProfile editprofile = new EditProfile(selectedProfile);
                editprofile.MdiParent = this.MdiParent;
                editprofile.Show();

                //...
            } else if (e.RowIndex >= 0 && e.ColumnIndex == 1)
            {

                DataGridViewRow selectedProfile = userProfileManagmentGrid.Rows[e.RowIndex];

                ProfilePage profilePage = new ProfilePage(selectedProfile);
                profilePage.MdiParent = this.MdiParent;
                profilePage.Show();
            }
        }

        private void importProfilesBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature has not been bug tested yet!");
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                using (System.IO.StreamReader reader = new System.IO.StreamReader(openFileDialog1.FileName))
                {
                    string line;


                    while ((line = reader.ReadLine()) != null)
                    {
                        
                        //Define pattern
                        Regex CSVParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");

                        //Separating columns to array
                        string[] userData = CSVParser.Split(line);

                        /* Do something with X */
                        con = new SqlConnection(@"Data Source =(LocalDB)\MSSQLLocalDB;" +
                    @"AttachDbFilename = |DataDirectory|\CapstoneDB\CapstoneDB.mdf; Integrated Security = True");
                        con.Open();
                        cmd = new SqlCommand("INSERT INTO UserInformation (firstName, lastName, dob, gender, phone, email) VALUES (@firstName, @lastName, @dob, @gender, @phone, @email)", con);
                        cmd.Parameters.AddWithValue("@firstName", userData[1]);
                        cmd.Parameters.AddWithValue("@lastName", userData[2]);
                        cmd.Parameters.AddWithValue("@gender", userData[4]);

                        cmd.Parameters.AddWithValue("@phone", userData[5]);
                        cmd.Parameters.AddWithValue("@email", userData[6]);
                        cmd.Parameters.AddWithValue("@dob", Convert.ToDateTime(userData[3]));
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("New user has been added successfully.");
                        
                        con.Close();
                    }
                }
                    
            }
        }

        private void exportAllProfilesBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature has not been developed yet!");
        }
    }
}
