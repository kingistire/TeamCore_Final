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
        private ProfileManagementFunctions profileManagementFunctionsClassObject = new ProfileManagementFunctions();

        int thisProfileId;
        DataGridViewRow thisProfileData;
        private ProfileData intervieweeProfile = new ProfileData();
        string interviewNumber;
        

        public ProfilePage(DataGridViewRow dataValue)
        {
            thisProfileData = dataValue;
            thisProfileId = Convert.ToInt32(dataValue.Cells[2].Value);
            InitializeComponent();

            profileManagementFunctionsClassObject.GetProfileData(thisProfileId, intervieweeProfile);   
        }

        private void editUserDataBtn_Click(object sender, EventArgs e)
        {
            EditProfile editprofile = new EditProfile(thisProfileData);
            editprofile.MdiParent = this.MdiParent;
            editprofile.Show();
        }
        private void ProfilePage_Enter(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            dataTable = profileManagementFunctionsClassObject.GetProfileData(thisProfileId, intervieweeProfile);
            foreach (DataRow row in dataTable.Rows)
            {
                intervieweeProfile.FirstName = Convert.ToString(row["firstName"]);
                intervieweeProfile.LastName = Convert.ToString(row["lastName"]);
                intervieweeProfile.Dob = Convert.ToDateTime(row["dob"]);
                intervieweeProfile.Gender = Convert.ToString(row["gender"]);
                intervieweeProfile.PhNumber = Convert.ToString(row["phone"]);
                intervieweeProfile.EmailAddress = Convert.ToString(row["email"]);
            }
            nameLabel.Text = intervieweeProfile.FirstName.Trim() + " " + intervieweeProfile.LastName.Trim();
            genderLabel.Text = intervieweeProfile.LastName.Trim();
            dobLabel.Text = intervieweeProfile.Dob.ToString().Substring(0, 10);
            phLabel.Text = intervieweeProfile.PhNumber.Trim();
            mailLabel.Text = intervieweeProfile.EmailAddress.Trim();
        }

        private void deleteUserBtn_Click(object sender, EventArgs e)
        {
            DeleteUser deleteUserProfile = new DeleteUser(thisProfileId);
            deleteUserProfile.MdiParent = this.MdiParent;
            deleteUserProfile.Show();
        }

        private void viewFamilyObservationBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature has not been developed yet!");
        }

        private void exportProfileBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature has not been BUG TESTED yet!");
            List<ProfileData> toExport = new List<ProfileData>();
            toExport.Add(intervieweeProfile);
            profileManagementFunctionsClassObject.ExportProfileData(folderBrowserDialog1, toExport, thisProfileId);
            
        }

        private void InterviewHistoryDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0){ // IF EDIT
                Globals.interviewRow = (int) InterviewHistoryDataGrid.Rows[e.RowIndex].Cells[1].Value;
                Globals.userID = InterviewHistoryDataGrid.Rows[e.RowIndex].Cells[2].Value.ToString();
                Globals.previousInterviewType = (int)InterviewHistoryDataGrid.Rows[e.RowIndex].Cells[3].Value;
                Console.WriteLine(Globals.interviewRow);
                Globals.previousInterview = true;
                Summary sum = new Summary();
                sum.Show();
            }
        }

        private void ProfilePage_Load(object sender, EventArgs e) {
            //InterviewHistoryDataGrid.Rows[0].Cells[0].Selected = false;
            string constring = @"Data Source =(LocalDB)\MSSQLLocalDB;" +
                        @"AttachDbFilename = |DataDirectory|\CapstoneDB\CapstoneDB.mdf; Integrated Security = True";
            SqlConnection conDatabase = new SqlConnection(constring);
            SqlCommand cmdDatabase = new SqlCommand(" select * from linkProfileInterview WHERE ProfileID = @id;", conDatabase);
            //SqlCommand cmdDatabase = new SqlCommand("Select * From dislikeSounds WHERE ID = @id;", conDatabase);
            cmdDatabase.Parameters.AddWithValue("@id", thisProfileId);
            try {
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmdDatabase;
                DataTable dbdataset = new DataTable();
                //For each row, add row to data table


                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = dbdataset;
                InterviewHistoryDataGrid.DataSource = bSource;
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
