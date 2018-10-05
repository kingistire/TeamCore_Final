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
using System.IO;


namespace Login
{
    public partial class ProfilePage : Form
    {
        
        DataGridViewRow thisUser;

        private ProfileData intervieweeProfile = new ProfileData();
        class ProfileData
        {
            private string firstName;
            private string lastName;
            private DateTime dob;
            private string gender;
            private string phNumber;
            private string emailAddress;

            public string FirstName { get { return firstName; } set { firstName = value; } }
            public string LastName { get { return lastName; } set { lastName = value; } }
            public DateTime Dob { get { return dob; } set { dob = value; } }
            public string Gender { get { return gender; } set { gender = value; } }
            public string PhNumber { get { return phNumber; } set { phNumber = value; } }
            public string EmailAddress { get { return emailAddress; } set { emailAddress = value; } }

        }

        public ProfilePage(DataGridViewRow dataValue)
        {
            thisUser = dataValue;
            InitializeComponent();

            
            GetProfileData(Convert.ToInt32(thisUser.Cells[2].Value), intervieweeProfile);

            
            
        }

        private void GetProfileData(int ProfileId, ProfileData profileData)
        {
            try
            {
                string constring = @"Data Source =(LocalDB)\MSSQLLocalDB;" +
                @"AttachDbFilename = |DataDirectory|\CapstoneDB\CapstoneDB.mdf; Integrated Security = True";
                SqlConnection conDatabase = new SqlConnection(constring);

                string sql = "SELECT firstName, lastName, dob, gender, phone, email FROM UserInformation where Id=" + ProfileId.ToString() + "";
                DataTable dt = new DataTable();


                conDatabase.Open();

                SqlDataAdapter da = new SqlDataAdapter(sql, conDatabase);
                da.Fill(dt);

                conDatabase.Close();

                foreach (DataRow row in dt.Rows)
                {
                    profileData.FirstName = Convert.ToString(row["firstName"]);
                    profileData.LastName = Convert.ToString(row["lastName"]);
                    profileData.Dob = Convert.ToDateTime(row["dob"]);
                    profileData.Gender = Convert.ToString(row["gender"]);
                    profileData.PhNumber = Convert.ToString(row["phone"]);
                    profileData.EmailAddress = Convert.ToString(row["email"]);
                }
                nameLabel.Text = profileData.FirstName.Trim() + " " + profileData.LastName.Trim();
                genderLabel.Text = profileData.LastName.Trim();
                dobLabel.Text = profileData.Dob.ToString().Substring(0, 10);
                phLabel.Text = profileData.PhNumber.Trim();
                mailLabel.Text = profileData.EmailAddress.Trim();
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
            GetProfileData(Convert.ToInt32(thisUser.Cells[2].Value), intervieweeProfile);
        }

        private void deleteUserBtn_Click(object sender, EventArgs e)
        {
            DeleteUser deleteUserProfile = new DeleteUser(thisUser.Cells[2].Value.ToString().Trim());
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

            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //dummy path: C:\Users\Jamie-admin\Documents\TeamCore_Final\Testing Documents
                string strFilePath = folderBrowserDialog1.SelectedPath + "\\SensoryExperience" + thisUser.Cells[2].Value.ToString().Trim() +
                    intervieweeProfile.FirstName.Trim() + intervieweeProfile.LastName.Trim() +
                    ".csv";

                string strSeparator = ",";

                StringBuilder sbOutput = new StringBuilder();

                string[][] inaOutput = new string[][]
                {
                new string [] {thisUser.Cells[2].Value.ToString().Trim(), intervieweeProfile.FirstName.Trim(),
                    intervieweeProfile.LastName.Trim(), intervieweeProfile.Dob.ToString().Trim(),
                    intervieweeProfile.Gender.Trim(), intervieweeProfile.PhNumber.Trim(),
                    intervieweeProfile.EmailAddress.Trim()}

                };

                int iLength = inaOutput.GetLength(0);
                for (int i = 0; i < iLength; i++)
                {
                    sbOutput.AppendLine(string.Join(strSeparator, inaOutput[i]));

                }

                
                 File.WriteAllText(strFilePath, sbOutput.ToString());
                 MessageBox.Show("Export Successful!");
                
                
            }

            

        }
    }
}
