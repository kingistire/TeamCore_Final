using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.IO;
using System.Data;


namespace Login
{

    class ProfileManagementFunctions

    {
        SqlCommand cmd;
        SqlConnection con;

        public void ImportProfiles(OpenFileDialog openFileDialog1)
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
                        

                        con.Close();
                    }
                    MessageBox.Show("New profile/s has been added successfully.");
                }

            }
        } // END ImportProfiles

        public DataTable GetProfileData(int ProfileId, ProfileData profileData)
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
                return dt;

        } // end get Data


        public void ExportProfileData(FolderBrowserDialog folderBrowserDialog1, List<ProfileData> intervieweeProfile, int thisProfileLocalId)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //dummy path: C:\Users\Jamie-admin\Documents\TeamCore_Final\Testing Documents
                string fileName;
                if(intervieweeProfile.Count > 0)
                {
                    fileName = "SensoryExperienceBackup.csv";
                } else
                {
                    fileName = intervieweeProfile[0].LastName.Trim() +
                    ".csv";
                }
                string strFilePath = folderBrowserDialog1.SelectedPath + "\\SensoryExperience" + thisProfileLocalId +
                    intervieweeProfile[0].FirstName.Trim() + fileName;

                string strSeparator = ",";

                StringBuilder sbOutput = new StringBuilder();

                string[][] inaOutput = new string[][]
                {
                new string [] {thisProfileLocalId.ToString(), intervieweeProfile[0].FirstName.Trim(),
                    intervieweeProfile[0].LastName.Trim(), intervieweeProfile[0].Dob.ToString().Trim(),
                    intervieweeProfile[0].Gender.Trim(), intervieweeProfile[0].PhNumber.Trim(),
                    intervieweeProfile[0].EmailAddress.Trim()}
                };

                List<String[]> toExportData = new List<String[]>();
                for (int i = 0; i < intervieweeProfile.Count(); i++)
                {
                    toExportData.Add(new string[] {thisProfileLocalId.ToString(), intervieweeProfile[0].FirstName.Trim(),
                    intervieweeProfile[0].LastName.Trim(), intervieweeProfile[0].Dob.ToString().Trim(),
                    intervieweeProfile[0].Gender.Trim(), intervieweeProfile[0].PhNumber.Trim(),
                    intervieweeProfile[0].EmailAddress.Trim()});
                }

                int iLength = inaOutput.GetLength(0);
                int iLengthNew = toExportData.Count();
                for (int i = 0; i < iLengthNew; i++)
                {
                    sbOutput.AppendLine(string.Join(strSeparator, toExportData[i]));

                }

                File.WriteAllText(strFilePath, sbOutput.ToString());
                MessageBox.Show("Export Successful!");

            }
        } // end Export
    }
}
