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
    }
}
