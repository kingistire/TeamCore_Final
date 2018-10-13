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

namespace Login {

    public partial class SelectInterview : Form {

        public SelectInterview() {
            InitializeComponent();


        }

        private void btnStart_Click(object sender, EventArgs e) {
            //InterviewType
            Globals.interview_page = 1;
            string InterviewType="0";
            if (radioGuided.Checked == true) {
                InterviewType = "1";
            }
            else if (radioIndependent.Checked == true) {
                InterviewType = "2";
            }
            else if (radioFamily.Checked) {
                InterviewType = "3";
            }

            //Date
            string Date = DateTime.Now.ToString("d/M/yyyy");

            //ID
            string ProfileID = label2.Text;


            SqlCommand cmdDatabase;
            const string constring = @"Data Source =(LocalDB)\MSSQLLocalDB;" +
                                    @"AttachDbFilename = |DataDirectory|\CapstoneDB\CapstoneDB.mdf; Integrated Security = True";
            SqlConnection conDatabase = new SqlConnection(constring);
            try {
                string query;
                conDatabase.Open();
                //Change interview_page to see if previous button has been clicked
                query = "INSERT INTO dbo.linkProfileInterview(ProfileID, InterviewType, Date) VALUES (@profileID, @intType, @date);";
                cmdDatabase = new SqlCommand(query, conDatabase);
                cmdDatabase.Parameters.AddWithValue("@profileID", ProfileID);
                cmdDatabase.Parameters.AddWithValue("@intType", InterviewType);
                cmdDatabase.Parameters.AddWithValue("@date", Date);
                cmdDatabase.ExecuteNonQuery();
            }
            catch (Exception err) {
                MessageBox.Show("An Error has occurred while writing to the database: " + err.Message);
            }

            if (radioGuided.Checked == true) {
                GuidedInterviewCover newGuidedInt = new GuidedInterviewCover();
                newGuidedInt.Show();
                this.Hide();
            }
            else if (radioIndependent.Checked == true) {
                IndependentCover newIndependentInt = new IndependentCover();
                newIndependentInt.Show();
                this.Hide();
            }
            else if (radioFamily.Checked) {
                FamilyInterviewCover famCover = new FamilyInterviewCover();
                famCover.Show();
                this.Hide();
            }
        }

        private void SelectInterview_Load(object sender, EventArgs e) {
            try {
                SqlConnection conn = new SqlConnection(@"Data Source =(LocalDB)\MSSQLLocalDB;" +
                @"AttachDbFilename = |DataDirectory|\CapstoneDB\CapstoneDB.mdf; Integrated Security = True");
                conn.Open();
                SqlCommand sc = new SqlCommand("select Id,firstName from dbo.UserInformation", conn);
                SqlDataReader reader;
                reader = sc.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("firstName", typeof(string));
                dt.Load(reader);
                comboBox1.ValueMember = "Id";
                comboBox1.DisplayMember = "firstName";
                comboBox1.DataSource = dt;

                conn.Close();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private DataTable dbdataset = new DataTable();

        private void writeToDB(string ProfileID, string InterviewType, string Date) {

            
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e) {
            string comboBoxID = comboBox1.SelectedValue.ToString();
            label2.Text = comboBox1.SelectedValue.ToString();
            
        }
    }
}

