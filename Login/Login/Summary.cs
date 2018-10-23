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
        private const int MAXROWS = 8;

        /// <summary>
        /// Call when not all 5 panels will be displayed
        /// </summary>
        private void hidePanels() {
            topic1ResultPanel.Visible = false;
            topic2ResultPanel.Visible = false;
            topic3ResultPanel.Visible = false;
            topic4ResultPanel.Visible = false;
            topic5ResultPanel.Visible = false;
        }

        private void shortResponseButton() {
            if (Globals.shortResponse) {
                changeSummaryPanelType.Visible = true;
                changeSummaryPanelType.Enabled = true;
            } else {
                changeSummaryPanelType.Visible = false;
                changeSummaryPanelType.Enabled = false;
            }
        }
        string id = Globals.userID;

        /// <summary>
        /// Get the additional comments from the database
        /// </summary>
        private void getAdditionalCommentAnswer(int numOfSRQuestions, string tableNameParam, int columnNumberInSummary) {
            string constring = @"Data Source =(LocalDB)\MSSQLLocalDB;" +
                                @"AttachDbFilename = |DataDirectory|\CapstoneDB\CapstoneDB.mdf; Integrated Security = True";
            SqlConnection conDatabase = new SqlConnection(constring);
            string query;
            //Switch to determine number of comment in Database
            switch (numOfSRQuestions) {
                case 1:
                    query = "SELECT comment1 FROM " + tableNameParam +
                " WHERE interviewNumber = (SELECT MAX(interviewNumber) FROM dbo." + tableNameParam + ") AND ID = @id ;";
                    SqlCommand command = new SqlCommand(query, conDatabase);
                    command.Parameters.AddWithValue("@id", id);
                    conDatabase.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    List<string> list = new List<string>();
                    while (dr.Read()) {
                        //Iterate through loop and add to list
                        for (int i = 0; i < 1; i++) {
                            list.Add(dr[i].ToString());
                        }
                    }
                    //If statement for appropriate display of label and textbox
                    if(columnNumberInSummary == 1) {
                        srAnswer1.Clear();
                        srAnswer2.Clear();
                        srAnswer3.Clear();
                        srAnswer4.Clear();
                        srAnswer1.AppendText(list[0]);
                        srAnswer1.ReadOnly = true;
                        srAnswer2.Visible = false;
                        srAnswer2.Enabled = false;
                        srAnswer3.Visible = false;
                        srAnswer3.Enabled = false;
                        srAnswer4.Visible = false;
                        srAnswer4.Enabled = false;
                    } else if (columnNumberInSummary == 2) {
                        srAnswer5.Clear();
                        srAnswer6.Clear();
                        srAnswer7.Clear();
                        srAnswer8.Clear();
                        srAnswer5.AppendText(list[0]);
                        srAnswer5.ReadOnly = true;
                        srAnswer6.Visible = false;
                        srAnswer6.Enabled = false;
                        srAnswer7.Visible = false;
                        srAnswer7.Enabled = false;
                        srAnswer8.Visible = false;
                        srAnswer8.Enabled = false;
                    } else if (columnNumberInSummary == 3) {
                        srAnswer9.Clear();
                        srAnswer10.Clear();
                        srAnswer11.Clear();
                        srAnswer12.Clear();
                        srAnswer9.AppendText(list[0]);
                        srAnswer9.ReadOnly = true;
                        srAnswer10.Visible = false;
                        srAnswer10.Enabled = false;
                        srAnswer11.Visible = false;
                        srAnswer11.Enabled = false;
                        srAnswer12.Visible = false;
                        srAnswer12.Enabled = false;
                    } else if (columnNumberInSummary == 4) {
                        srAnswer13.Clear();
                        srAnswer14.Clear();
                        srAnswer15.Clear();
                        srAnswer16.Clear();
                        srAnswer13.AppendText(list[0]);
                        srAnswer13.ReadOnly = true;
                        srAnswer14.Visible = false;
                        srAnswer14.Enabled = false;
                        srAnswer15.Visible = false;
                        srAnswer15.Enabled = false;
                        srAnswer16.Visible = false;
                        srAnswer16.Enabled = false;
                    } else if (columnNumberInSummary == 5) {
                        srAnswer17.Clear();
                        srAnswer18.Clear();
                        srAnswer19.Clear();
                        srAnswer20.Clear();
                        srAnswer17.AppendText(list[0]);
                        srAnswer17.ReadOnly = true;
                        srAnswer18.Visible = false;
                        srAnswer18.Enabled = false;
                        srAnswer19.Visible = false;
                        srAnswer19.Enabled = false;
                        srAnswer20.Visible = false;
                        srAnswer20.Enabled = false;
                    }
                    
                    break;
                case 2:
                    query = "SELECT comment1, comment2 FROM " + tableNameParam +
                " WHERE interviewNumber = (SELECT MAX(interviewNumber) FROM dbo." + tableNameParam + ") AND ID = @id ;";
                    SqlCommand command1 = new SqlCommand(query, conDatabase);
                    command1.Parameters.AddWithValue("@id", id);
                    conDatabase.Open();
                    SqlDataReader dr1 = command1.ExecuteReader();
                    List<string> list1 = new List<string>();
                    while (dr1.Read()) {
                        //Iterate through loop and add to list
                        for (int i = 0; i < 2; i++) {
                            list1.Add(dr1[i].ToString());
                        }
                    }
                    //If statement for appropriate display of label and textbox
                    if (columnNumberInSummary == 1) {
                        srAnswer1.Clear();
                        srAnswer2.Clear();
                        srAnswer3.Clear();
                        srAnswer4.Clear();
                        srAnswer1.AppendText(list1[0]);
                        srAnswer1.ReadOnly = true;
                        srAnswer2.AppendText(list1[1]);
                        srAnswer2.ReadOnly = true;
                        srAnswer3.Visible = false;
                        srAnswer3.Enabled = false;
                        srAnswer4.Visible = false;
                        srAnswer4.Enabled = false;
                    } else if (columnNumberInSummary == 2) {
                        srAnswer5.Clear();
                        srAnswer6.Clear();
                        srAnswer7.Clear();
                        srAnswer8.Clear();
                        srAnswer5.AppendText(list1[0]);
                        srAnswer5.ReadOnly = true;
                        srAnswer6.AppendText(list1[1]);
                        srAnswer6.ReadOnly = true;
                        srAnswer7.Visible = false;
                        srAnswer7.Enabled = false;
                        srAnswer8.Visible = false;
                        srAnswer8.Enabled = false;
                    } else if (columnNumberInSummary == 3) {
                        srAnswer9.Clear();
                        srAnswer10.Clear();
                        srAnswer11.Clear();
                        srAnswer12.Clear();
                        srAnswer9.AppendText(list1[0]);
                        srAnswer9.ReadOnly = true;
                        srAnswer10.AppendText(list1[1]);
                        srAnswer10.ReadOnly = true;
                        srAnswer11.Visible = false;
                        srAnswer11.Enabled = false;
                        srAnswer12.Visible = false;
                        srAnswer12.Enabled = false;
                    } else if (columnNumberInSummary == 4) {
                        srAnswer13.Clear();
                        srAnswer14.Clear();
                        srAnswer15.Clear();
                        srAnswer16.Clear();
                        srAnswer13.AppendText(list1[0]);
                        srAnswer13.ReadOnly = true;
                        srAnswer14.AppendText(list1[1]);
                        srAnswer14.ReadOnly = true;
                        srAnswer15.Visible = false;
                        srAnswer15.Enabled = false;
                        srAnswer16.Visible = false;
                        srAnswer16.Enabled = false;
                    } else if (columnNumberInSummary == 5) {
                        srAnswer17.Clear();
                        srAnswer18.Clear();
                        srAnswer19.Clear();
                        srAnswer20.Clear();
                        srAnswer17.AppendText(list1[0]);
                        srAnswer17.ReadOnly = true;
                        srAnswer18.AppendText(list1[1]);
                        srAnswer18.ReadOnly = true;
                        srAnswer19.Visible = false;
                        srAnswer19.Enabled = false;
                        srAnswer20.Visible = false;
                        srAnswer20.Enabled = false;
                    }
                    break;
                case 3:
                    query = "SELECT comment1, comment2, comment3 FROM " + tableNameParam +
                " WHERE interviewNumber = (SELECT MAX(interviewNumber) FROM dbo." + tableNameParam + ") AND ID = @id ;";
                    SqlCommand command2 = new SqlCommand(query, conDatabase);
                    command2.Parameters.AddWithValue("@id", id);
                    conDatabase.Open();
                    SqlDataReader dr2 = command2.ExecuteReader();
                    List<string> list2 = new List<string>();
                    list2.Clear();
                    try {
                        while (dr2.Read()) {
                            //Iterate through loop and add to list
                            for (int i = 0; i < 3; i++) {
                                list2.Add(dr2[i].ToString());
                            }
                        }
                    } catch (Exception ex) {
                        MessageBox.Show(ex.Message);
                    }
                    //If statement for appropriate display of label and textbox
                        if (columnNumberInSummary == 1) {
                        srAnswer1.Clear();
                        srAnswer2.Clear();
                        srAnswer3.Clear();
                        srAnswer4.Clear();
                        srAnswer1.AppendText(list2[0]);
                            srAnswer1.ReadOnly = true;
                            srAnswer2.AppendText(list2[1]);
                            srAnswer2.ReadOnly = true;
                            srAnswer3.AppendText(list2[2]);
                            srAnswer3.ReadOnly = true;
                            srAnswer4.Visible = false;
                            srAnswer4.Enabled = false;
                        } else if (columnNumberInSummary == 2) {
                        srAnswer5.Clear();
                        srAnswer6.Clear();
                        srAnswer7.Clear();
                        srAnswer8.Clear();
                        srAnswer5.AppendText(list2[0]);
                            srAnswer5.ReadOnly = true;
                            srAnswer6.AppendText(list2[1]);
                            srAnswer6.ReadOnly = true;
                            srAnswer7.AppendText(list2[2]);
                            srAnswer7.ReadOnly = true;
                            srAnswer8.Visible = false;
                            srAnswer8.Enabled = false;
                        } else if (columnNumberInSummary == 3) {
                        srAnswer9.Clear();
                        srAnswer10.Clear();
                        srAnswer11.Clear();
                        srAnswer12.Clear();
                        srAnswer9.AppendText(list2[0]);
                            srAnswer9.ReadOnly = true;
                            srAnswer10.AppendText(list2[1]);
                            srAnswer10.ReadOnly = true;
                            srAnswer11.AppendText(list2[2]);
                            srAnswer11.ReadOnly = true;
                            srAnswer12.Visible = false;
                            srAnswer12.Enabled = false;
                        } else if (columnNumberInSummary == 4) {
                        srAnswer13.Clear();
                        srAnswer14.Clear();
                        srAnswer15.Clear();
                        srAnswer16.Clear();
                        srAnswer13.AppendText(list2[0]);
                            srAnswer13.ReadOnly = true;
                            srAnswer14.AppendText(list2[1]);
                            srAnswer14.ReadOnly = true;
                            srAnswer15.AppendText(list2[2]);
                            srAnswer15.ReadOnly = true;
                            srAnswer16.Visible = false;
                            srAnswer16.Enabled = false;
                        } else if (columnNumberInSummary == 5) {
                        srAnswer17.Clear();
                        srAnswer18.Clear();
                        srAnswer19.Clear();
                        srAnswer20.Clear();
                        srAnswer17.AppendText(list2[0]);
                            srAnswer17.ReadOnly = true;
                            srAnswer18.AppendText(list2[1]);
                            srAnswer18.ReadOnly = true;
                            srAnswer19.AppendText(list2[2]);
                            srAnswer19.ReadOnly = true;
                            srAnswer20.Visible = false;
                            srAnswer20.Enabled = false;
                        }
                    break;
                case 4:
                    query = "SELECT comment1, comment2, comment3, comment4 FROM " + tableNameParam +
                " WHERE interviewNumber = (SELECT MAX(interviewNumber) FROM dbo." + tableNameParam + ") AND ID = @id ;";
                    SqlCommand command3 = new SqlCommand(query, conDatabase);
                    command3.Parameters.AddWithValue("@id", id);
                    conDatabase.Open();
                    SqlDataReader dr3 = command3.ExecuteReader();
                    List<string> list3 = new List<string>();
                    while (dr3.Read()) {
                        //Iterate through loop and add to list
                        for (int i = 0; i < 4; i++) {
                            list3.Add(dr3[i].ToString());
                        }
                    }
                    if (columnNumberInSummary == 1) {
                        srAnswer1.Clear();
                        srAnswer2.Clear();
                        srAnswer3.Clear();
                        srAnswer4.Clear();
                        srAnswer1.AppendText(list3[0]);
                        srAnswer1.ReadOnly = true;
                        srAnswer2.AppendText(list3[1]);
                        srAnswer2.ReadOnly = true;
                        srAnswer3.AppendText(list3[2]);
                        srAnswer3.ReadOnly = true;
                        srAnswer4.AppendText(list3[3]);
                        srAnswer4.ReadOnly = true;
                    } else if (columnNumberInSummary == 2) {
                        srAnswer5.Clear();
                        srAnswer6.Clear();
                        srAnswer7.Clear();
                        srAnswer8.Clear();
                        srAnswer5.AppendText(list3[0]);
                        srAnswer5.ReadOnly = true;
                        srAnswer6.AppendText(list3[1]);
                        srAnswer6.ReadOnly = true;
                        srAnswer7.AppendText(list3[2]);
                        srAnswer7.ReadOnly = true;
                        srAnswer8.AppendText(list3[3]);
                        srAnswer8.ReadOnly = true;
                    } else if (columnNumberInSummary == 3) {
                        srAnswer9.Clear();
                        srAnswer10.Clear();
                        srAnswer11.Clear();
                        srAnswer12.Clear();
                        srAnswer9.AppendText(list3[0]);
                        srAnswer9.ReadOnly = true;
                        srAnswer10.AppendText(list3[1]);
                        srAnswer10.ReadOnly = true;
                        srAnswer11.AppendText(list3[2]);
                        srAnswer11.ReadOnly = true;
                        srAnswer12.AppendText(list3[3]);
                        srAnswer12.ReadOnly = true;
                    } else if (columnNumberInSummary == 4) {
                        srAnswer13.Clear();
                        srAnswer14.Clear();
                        srAnswer15.Clear();
                        srAnswer16.Clear();
                        srAnswer13.AppendText(list3[0]);
                        srAnswer13.ReadOnly = true;
                        srAnswer14.AppendText(list3[1]);
                        srAnswer14.ReadOnly = true;
                        srAnswer15.AppendText(list3[2]);
                        srAnswer15.ReadOnly = true;
                        srAnswer16.AppendText(list3[3]);
                        srAnswer16.ReadOnly = true;
                    } else if (columnNumberInSummary == 5) {
                        srAnswer17.Clear();
                        srAnswer18.Clear();
                        srAnswer19.Clear();
                        srAnswer20.Clear();
                        srAnswer17.AppendText(list3[0]);
                        srAnswer17.ReadOnly = true;
                        srAnswer18.AppendText(list3[1]);
                        srAnswer18.ReadOnly = true;
                        srAnswer19.AppendText(list3[2]);
                        srAnswer19.ReadOnly = true;
                        srAnswer20.AppendText(list3[3]);
                        srAnswer20.ReadOnly = true;
                    }
                    break;
            }
        }

        private void updateSRLabels(Label labelName, Label labelName2, Label labelName3, Label labelName4, string q1, string q2, string q3, string q4) {
            labelName.Text = q1;
            labelName2.Text = q2;
            labelName3.Text = q3;
            labelName4.Text = q4;
        }

        private void getHistorySRAnswer(int numOfSRQuestions, string tableNameParam, int columnNumberInSummary) {
            string constring = @"Data Source =(LocalDB)\MSSQLLocalDB;" +
                                @"AttachDbFilename = |DataDirectory|\CapstoneDB\CapstoneDB.mdf; Integrated Security = True";
            SqlConnection conDatabase = new SqlConnection(constring);
            //Get Max interview number
            string getMaxInterviewID = "SELECT interviewNumber FROM " + tableNameParam +
                " WHERE interviewNumber = (SELECT MAX(interviewNumber) FROM dbo." + tableNameParam + ");";
            SqlCommand maxInterviewCmd = new SqlCommand(getMaxInterviewID, conDatabase);
            maxInterviewCmd.Parameters.AddWithValue("@id", id);
            maxInterviewCmd.Parameters.Add("@interviewRow", SqlDbType.Int).Value = Globals.interviewRow;
            conDatabase.Open();
            SqlDataReader DataReaderMaxInterview = maxInterviewCmd.ExecuteReader();
            int maxInterviewList = 0;
            while (DataReaderMaxInterview.Read()) {
                    maxInterviewList = int.Parse(DataReaderMaxInterview["interviewNumber"].ToString());
            }
            conDatabase.Close();
            string query;
            //Switch to determine number of comment in Database
            switch (numOfSRQuestions) {
                case 1:
                    //If there are more interviews that comments
                    if(maxInterviewList < Globals.interviewRow) {
                        query = "SELECT comment1 FROM " + tableNameParam +
                        " WHERE interviewNumber = (SELECT MAX(interviewNumber) FROM dbo." + tableNameParam + ") AND ID = @id;";
                    } else {
                        query = "SELECT comment1 FROM " + tableNameParam +
                    " WHERE interviewNumber = @interviewRow ;";
                    }
                    SqlCommand command = new SqlCommand(query, conDatabase);
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.Add("@interviewRow", SqlDbType.Int).Value = Globals.interviewRow;
                    conDatabase.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    List<string> list = new List<string>();
                    while (dr.Read()) {
                        //Iterate through loop and add to list
                        for (int i = 0; i < 1; i++) {
                            list.Add(dr[i].ToString());
                        }
                    }
                    //If statement for appropriate display of label and textbox
                    if (columnNumberInSummary == 1) {
                        srAnswer1.Clear();
                        srAnswer2.Clear();
                        srAnswer3.Clear();
                        srAnswer4.Clear();
                        srAnswer1.AppendText(list[0]);
                        srAnswer1.ReadOnly = true;
                        srAnswer2.Visible = false;
                        srAnswer2.Enabled = false;
                        srAnswer3.Visible = false;
                        srAnswer3.Enabled = false;
                        srAnswer4.Visible = false;
                        srAnswer4.Enabled = false;
                    } else if (columnNumberInSummary == 2) {
                        srAnswer5.Clear();
                        srAnswer6.Clear();
                        srAnswer7.Clear();
                        srAnswer8.Clear();
                        srAnswer5.AppendText(list[0]);
                        srAnswer5.ReadOnly = true;
                        srAnswer6.Visible = false;
                        srAnswer6.Enabled = false;
                        srAnswer7.Visible = false;
                        srAnswer7.Enabled = false;
                        srAnswer8.Visible = false;
                        srAnswer8.Enabled = false;
                    } else if (columnNumberInSummary == 3) {
                        srAnswer9.Clear();
                        srAnswer10.Clear();
                        srAnswer11.Clear();
                        srAnswer12.Clear();
                        srAnswer9.AppendText(list[0]);
                        srAnswer9.ReadOnly = true;
                        srAnswer10.Visible = false;
                        srAnswer10.Enabled = false;
                        srAnswer11.Visible = false;
                        srAnswer11.Enabled = false;
                        srAnswer12.Visible = false;
                        srAnswer12.Enabled = false;
                    } else if (columnNumberInSummary == 4) {
                        srAnswer13.Clear();
                        srAnswer14.Clear();
                        srAnswer15.Clear();
                        srAnswer16.Clear();
                        srAnswer13.AppendText(list[0]);
                        srAnswer13.ReadOnly = true;
                        srAnswer14.Visible = false;
                        srAnswer14.Enabled = false;
                        srAnswer15.Visible = false;
                        srAnswer15.Enabled = false;
                        srAnswer16.Visible = false;
                        srAnswer16.Enabled = false;
                    } else if (columnNumberInSummary == 5) {
                        srAnswer17.Clear();
                        srAnswer18.Clear();
                        srAnswer19.Clear();
                        srAnswer20.Clear();
                        srAnswer17.AppendText(list[0]);
                        srAnswer17.ReadOnly = true;
                        srAnswer18.Visible = false;
                        srAnswer18.Enabled = false;
                        srAnswer19.Visible = false;
                        srAnswer19.Enabled = false;
                        srAnswer20.Visible = false;
                        srAnswer20.Enabled = false;
                    }

                    break;
                case 2:
                    if (maxInterviewList < Globals.interviewRow) {
                        query = "SELECT comment1 , comment2 FROM " + tableNameParam +
                        " WHERE interviewNumber = (SELECT MAX(interviewNumber) FROM dbo." + tableNameParam + ") AND ID = @id;";
                    } else {
                        query = "SELECT comment1, comment2 FROM " + tableNameParam +
                    " WHERE interviewNumber = @interviewRow;";
                    }

                    SqlCommand command1 = new SqlCommand(query, conDatabase);
                    command1.Parameters.AddWithValue("@id", id);
                    command1.Parameters.Add("@interviewRow", SqlDbType.Int).Value = Globals.interviewRow;

                    conDatabase.Open();
                    SqlDataReader dr1 = command1.ExecuteReader();
                    List<string> list1 = new List<string>();
                    while (dr1.Read()) {
                        //Iterate through loop and add to list
                        for (int i = 0; i < 2; i++) {
                            list1.Add(dr1[i].ToString());
                        }
                    }
                    //If statement for appropriate display of label and textbox
                    if (columnNumberInSummary == 1) {
                        srAnswer1.Clear();
                        srAnswer2.Clear();
                        srAnswer3.Clear();
                        srAnswer4.Clear();
                        srAnswer1.AppendText(list1[0]);
                        srAnswer1.ReadOnly = true;
                        srAnswer2.AppendText(list1[1]);
                        srAnswer2.ReadOnly = true;
                        srAnswer3.Visible = false;
                        srAnswer3.Enabled = false;
                        srAnswer4.Visible = false;
                        srAnswer4.Enabled = false;
                    } else if (columnNumberInSummary == 2) {
                        srAnswer5.Clear();
                        srAnswer6.Clear();
                        srAnswer7.Clear();
                        srAnswer8.Clear();
                        srAnswer5.AppendText(list1[0]);
                        srAnswer5.ReadOnly = true;
                        srAnswer6.AppendText(list1[1]);
                        srAnswer6.ReadOnly = true;
                        srAnswer7.Visible = false;
                        srAnswer7.Enabled = false;
                        srAnswer8.Visible = false;
                        srAnswer8.Enabled = false;
                    } else if (columnNumberInSummary == 3) {
                        srAnswer9.Clear();
                        srAnswer10.Clear();
                        srAnswer11.Clear();
                        srAnswer12.Clear();
                        srAnswer9.AppendText(list1[0]);
                        srAnswer9.ReadOnly = true;
                        srAnswer10.AppendText(list1[1]);
                        srAnswer10.ReadOnly = true;
                        srAnswer11.Visible = false;
                        srAnswer11.Enabled = false;
                        srAnswer12.Visible = false;
                        srAnswer12.Enabled = false;
                    } else if (columnNumberInSummary == 4) {
                        srAnswer13.Clear();
                        srAnswer14.Clear();
                        srAnswer15.Clear();
                        srAnswer16.Clear();
                        srAnswer13.AppendText(list1[0]);
                        srAnswer13.ReadOnly = true;
                        srAnswer14.AppendText(list1[1]);
                        srAnswer14.ReadOnly = true;
                        srAnswer15.Visible = false;
                        srAnswer15.Enabled = false;
                        srAnswer16.Visible = false;
                        srAnswer16.Enabled = false;
                    } else if (columnNumberInSummary == 5) {
                        srAnswer17.Clear();
                        srAnswer18.Clear();
                        srAnswer19.Clear();
                        srAnswer20.Clear();
                        srAnswer17.AppendText(list1[0]);
                        srAnswer17.ReadOnly = true;
                        srAnswer18.AppendText(list1[1]);
                        srAnswer18.ReadOnly = true;
                        srAnswer19.Visible = false;
                        srAnswer19.Enabled = false;
                        srAnswer20.Visible = false;
                        srAnswer20.Enabled = false;
                    }
                    break;
                case 3:
                    if (maxInterviewList < Globals.interviewRow) {
                        query = "SELECT comment1 , comment2, comment3 FROM " + tableNameParam +
                        " WHERE interviewNumber = (SELECT MAX(interviewNumber) FROM dbo." + tableNameParam + ")AND ID = @id;";
                    } else {
                        query = "SELECT comment1, comment2, comment3 FROM " + tableNameParam +
                    " WHERE interviewNumber = @interviewRow;";

                    }
                    SqlCommand command2 = new SqlCommand(query, conDatabase);
                    command2.Parameters.AddWithValue("@id", id);
                    command2.Parameters.Add("@interviewRow", SqlDbType.Int).Value = Globals.interviewRow;

                    conDatabase.Open();
                    SqlDataReader dr2 = command2.ExecuteReader();
                    List<string> list2 = new List<string>();
                    list2.Clear();
                    try {
                        while (dr2.Read()) {
                            //Iterate through loop and add to list
                            for (int i = 0; i < 3; i++) {
                                list2.Add(dr2[i].ToString());
                            }
                        }
                    } catch (Exception ex) {
                        MessageBox.Show(ex.Message);
                    }
                    //If statement for appropriate display of label and textbox
                    if (columnNumberInSummary == 1) {
                        srAnswer1.Clear();
                        srAnswer2.Clear();
                        srAnswer3.Clear();
                        srAnswer4.Clear();
                        srAnswer1.AppendText(list2[0]);
                        srAnswer1.ReadOnly = true;
                        srAnswer2.AppendText(list2[1]);
                        srAnswer2.ReadOnly = true;
                        srAnswer3.AppendText(list2[2]);
                        srAnswer3.ReadOnly = true;
                        srAnswer4.Visible = false;
                        srAnswer4.Enabled = false;
                    } else if (columnNumberInSummary == 2) {
                        srAnswer5.Clear();
                        srAnswer6.Clear();
                        srAnswer7.Clear();
                        srAnswer8.Clear();
                        srAnswer5.AppendText(list2[0]);
                        srAnswer5.ReadOnly = true;
                        srAnswer6.AppendText(list2[1]);
                        srAnswer6.ReadOnly = true;
                        srAnswer7.AppendText(list2[2]);
                        srAnswer7.ReadOnly = true;
                        srAnswer8.Visible = false;
                        srAnswer8.Enabled = false;
                    } else if (columnNumberInSummary == 3) {
                        srAnswer9.Clear();
                        srAnswer10.Clear();
                        srAnswer11.Clear();
                        srAnswer12.Clear();
                        srAnswer9.AppendText(list2[0]);
                        srAnswer9.ReadOnly = true;
                        srAnswer10.AppendText(list2[1]);
                        srAnswer10.ReadOnly = true;
                        srAnswer11.AppendText(list2[2]);
                        srAnswer11.ReadOnly = true;
                        srAnswer12.Visible = false;
                        srAnswer12.Enabled = false;
                    } else if (columnNumberInSummary == 4) {
                        srAnswer13.Clear();
                        srAnswer14.Clear();
                        srAnswer15.Clear();
                        srAnswer16.Clear();
                        srAnswer13.AppendText(list2[0]);
                        srAnswer13.ReadOnly = true;
                        srAnswer14.AppendText(list2[1]);
                        srAnswer14.ReadOnly = true;
                        srAnswer15.AppendText(list2[2]);
                        srAnswer15.ReadOnly = true;
                        srAnswer16.Visible = false;
                        srAnswer16.Enabled = false;
                    } else if (columnNumberInSummary == 5) {
                        srAnswer17.Clear();
                        srAnswer18.Clear();
                        srAnswer19.Clear();
                        srAnswer20.Clear();
                        srAnswer17.AppendText(list2[0]);
                        srAnswer17.ReadOnly = true;
                        srAnswer18.AppendText(list2[1]);
                        srAnswer18.ReadOnly = true;
                        srAnswer19.AppendText(list2[2]);
                        srAnswer19.ReadOnly = true;
                        srAnswer20.Visible = false;
                        srAnswer20.Enabled = false;
                    }
                    break;
                case 4:
                    if (maxInterviewList < Globals.interviewRow) {
                        query = "SELECT comment1 , comment2, comment3, comment4 FROM " + tableNameParam +
                        " WHERE interviewNumber = (SELECT MAX(interviewNumber) FROM dbo." + tableNameParam + ")AND ID = @id;";
                    } else {
                            query = "SELECT comment1, comment2, comment3, comment4 FROM " + tableNameParam +
                        " WHERE interviewNumber = @interviewRow;";
                     
                    }
                    SqlCommand command3 = new SqlCommand(query, conDatabase);
                    command3.Parameters.AddWithValue("@id", id);
                    command3.Parameters.Add("@interviewRow", SqlDbType.Int).Value = Globals.interviewRow;

                    conDatabase.Open();
                    SqlDataReader dr3 = command3.ExecuteReader();
                    List<string> list3 = new List<string>();
                    while (dr3.Read()) {
                        //Iterate through loop and add to list
                        for (int i = 0; i < 4; i++) {
                            list3.Add(dr3[i].ToString());
                        }
                    }
                    if (columnNumberInSummary == 1) {
                        srAnswer1.Clear();
                        srAnswer2.Clear();
                        srAnswer3.Clear();
                        srAnswer4.Clear();
                        srAnswer1.AppendText(list3[0]);
                        srAnswer1.ReadOnly = true;
                        srAnswer2.AppendText(list3[1]);
                        srAnswer2.ReadOnly = true;
                        srAnswer3.AppendText(list3[2]);
                        srAnswer3.ReadOnly = true;
                        srAnswer4.AppendText(list3[3]);
                        srAnswer4.ReadOnly = true;
                    } else if (columnNumberInSummary == 2) {
                        srAnswer5.Clear();
                        srAnswer6.Clear();
                        srAnswer7.Clear();
                        srAnswer8.Clear();
                        srAnswer5.AppendText(list3[0]);
                        srAnswer5.ReadOnly = true;
                        srAnswer6.AppendText(list3[1]);
                        srAnswer6.ReadOnly = true;
                        srAnswer7.AppendText(list3[2]);
                        srAnswer7.ReadOnly = true;
                        srAnswer8.AppendText(list3[3]);
                        srAnswer8.ReadOnly = true;
                    } else if (columnNumberInSummary == 3) {
                        srAnswer9.Clear();
                        srAnswer10.Clear();
                        srAnswer11.Clear();
                        srAnswer12.Clear();
                        srAnswer9.AppendText(list3[0]);
                        srAnswer9.ReadOnly = true;
                        srAnswer10.AppendText(list3[1]);
                        srAnswer10.ReadOnly = true;
                        srAnswer11.AppendText(list3[2]);
                        srAnswer11.ReadOnly = true;
                        srAnswer12.AppendText(list3[3]);
                        srAnswer12.ReadOnly = true;
                    } else if (columnNumberInSummary == 4) {
                        srAnswer13.Clear();
                        srAnswer14.Clear();
                        srAnswer15.Clear();
                        srAnswer16.Clear();
                        srAnswer13.AppendText(list3[0]);
                        srAnswer13.ReadOnly = true;
                        srAnswer14.AppendText(list3[1]);
                        srAnswer14.ReadOnly = true;
                        srAnswer15.AppendText(list3[2]);
                        srAnswer15.ReadOnly = true;
                        srAnswer16.AppendText(list3[3]);
                        srAnswer16.ReadOnly = true;
                    } else if (columnNumberInSummary == 5) {
                        srAnswer17.Clear();
                        srAnswer18.Clear();
                        srAnswer19.Clear();
                        srAnswer20.Clear();
                        srAnswer17.AppendText(list3[0]);
                        srAnswer17.ReadOnly = true;
                        srAnswer18.AppendText(list3[1]);
                        srAnswer18.ReadOnly = true;
                        srAnswer19.AppendText(list3[2]);
                        srAnswer19.ReadOnly = true;
                        srAnswer20.AppendText(list3[3]);
                        srAnswer20.ReadOnly = true;
                    }
                    break;
            }
        }

        /// <summary>
        /// WHen the user clicks on a previous interview in the history panel in profile page
        /// </summary>
        /// <param name="tableNameParam"></param>
        /// <param name="totalImages"></param>
        /// <param name="labelResultName1"></param>
        /// <param name="labelResultName2"></param>
        /// <param name="labelResultName3"></param>
        /// <param name="labelResultName4"></param>
        /// <param name="labelResultName5"></param>
        /// <param name="labelResultName6"></param>
        /// <param name="labelResultName7"></param>
        /// <param name="labelResultName8"></param>
        private void getPreviousInterview(string tableNameParam, int totalImages, Label labelResultName1, Label labelResultName2, Label labelResultName3, Label labelResultName4, Label labelResultName5,
            Label labelResultName6, Label labelResultName7, Label labelResultName8) {
            List<string> list = new List<string>();
            string constring = @"Data Source =(LocalDB)\MSSQLLocalDB;" +
                    @"AttachDbFilename = |DataDirectory|\CapstoneDB\CapstoneDB.mdf; Integrated Security = True";
            SqlConnection conDatabase = new SqlConnection(constring);
            //Replace summary in string with variable for db table name
            SqlCommand command = new SqlCommand("SELECT * FROM " + tableNameParam + " WHERE interviewNumber = @interviewRow;", conDatabase);
            command.Parameters.Add("@interviewRow", SqlDbType.Int).Value = Globals.interviewRow;
            conDatabase.Open();
            SqlDataReader dr = command.ExecuteReader();
            list.Clear();
            while (dr.Read()) {
                //Iterate through loop and add to list
                for (int i = 0; i < totalImages; i++) {
                    list.Add(dr[i].ToString());
                }
            }
            switch (totalImages) {
                case 2:
                    labelResultName1.Text = list[0];
                    labelResultName2.Text = list[1];
                    break;
                case 3:
                    labelResultName1.Text = list[0];
                    labelResultName2.Text = list[1];
                    labelResultName3.Text = list[2];
                    break;
                case 4:
                    labelResultName1.Text = list[0];
                    labelResultName2.Text = list[1];
                    labelResultName3.Text = list[2];
                    labelResultName4.Text = list[3];
                    break;
                case 5:
                    labelResultName1.Text = list[0];
                    labelResultName2.Text = list[1];
                    labelResultName3.Text = list[2];
                    labelResultName4.Text = list[3];
                    labelResultName5.Text = list[4];
                    break;
                case 6:
                    labelResultName1.Text = list[0];
                    labelResultName2.Text = list[1];
                    labelResultName3.Text = list[2];
                    labelResultName4.Text = list[3];
                    labelResultName5.Text = list[4];
                    labelResultName6.Text = list[5];
                    break;
                case 7:
                    labelResultName1.Text = list[0];
                    labelResultName2.Text = list[1];
                    labelResultName3.Text = list[2];
                    labelResultName4.Text = list[3];
                    labelResultName5.Text = list[4];
                    labelResultName6.Text = list[5];
                    labelResultName7.Text = list[6];
                    break;
                case 8:
                    labelResultName1.Text = list[0];
                    labelResultName2.Text = list[1];
                    labelResultName3.Text = list[2];
                    labelResultName4.Text = list[3];
                    labelResultName5.Text = list[4];
                    labelResultName6.Text = list[5];
                    labelResultName7.Text = list[6];
                    labelResultName8.Text = list[7];
                    break;

            }
            conDatabase.Close();
        }

        /// <summary>
        /// Get data from data base and store into list
        /// </summary>
        /// <param name="tableNameParam">table name in database</param>
        /// <param name="totalImages">Number of total images in the topic</param>
        /// <param name="labelResultName1">Label name of result to be displayed</param>
        /// <param name="labelResultName2">Label name of result to be displayed</param>
        /// <param name="labelResultName3">Label name of result to be displayed</param>
        /// <param name="labelResultName4">Label name of result to be displayed</param>
        /// <param name="labelResultName5">Label name of result to be displayed</param>
        /// <param name="labelResultName6">Label name of result to be displayed</param>
        /// <param name="labelResultName7">Label name of result to be displayed</param>
        /// <param name="labelResultName8">Label name of result to be displayed</param>
        private void getDBAnser(string tableNameParam, int totalImages, Label labelResultName1, Label labelResultName2, Label labelResultName3, Label labelResultName4, Label labelResultName5,
            Label labelResultName6, Label labelResultName7, Label labelResultName8) {

            //Strings
            //List<string> array = new List<string>();
            DataTable dt = new DataTable();
            string constring;
            SqlConnection conDatabase;
            SqlCommand command;
            List<string> list = new List<string>();
                constring = @"Data Source =(LocalDB)\MSSQLLocalDB;" +
                                    @"AttachDbFilename = |DataDirectory|\CapstoneDB\CapstoneDB.mdf; Integrated Security = True";
                 conDatabase = new SqlConnection(constring);
                //Replace summary in string with variable for db table name
                command = new SqlCommand("SELECT * FROM " + tableNameParam + " WHERE interviewNumber = (SELECT MAX(interviewNumber) FROM dbo." + tableNameParam + ");", conDatabase);
                conDatabase.Open();
                SqlDataReader dr = command.ExecuteReader();
                list.Clear();
                while (dr.Read()) {
                    //Iterate through loop and add to list
                    for (int i = 0; i < totalImages; i++) {
                        list.Add(dr[i].ToString());
                    }
                }

            //Update label text according to list index
                switch (totalImages) {
                    case 2:
                        labelResultName1.Text = list[0];
                        labelResultName2.Text = list[1];
                        break;
                    case 3:
                        labelResultName1.Text = list[0];
                        labelResultName2.Text = list[1];
                        labelResultName3.Text = list[2];
                        break;
                    case 4:
                        labelResultName1.Text = list[0];
                        labelResultName2.Text = list[1];
                        labelResultName3.Text = list[2];
                        labelResultName4.Text = list[3];
                        break;
                    case 5:
                        labelResultName1.Text = list[0];
                        labelResultName2.Text = list[1];
                        labelResultName3.Text = list[2];
                        labelResultName4.Text = list[3];
                        labelResultName5.Text = list[4];
                        break;
                    case 6:
                        labelResultName1.Text = list[0];
                        labelResultName2.Text = list[1];
                        labelResultName3.Text = list[2];
                        labelResultName4.Text = list[3];
                        labelResultName5.Text = list[4];
                        labelResultName6.Text = list[5];
                        break;
                    case 7:
                        labelResultName1.Text = list[0];
                        labelResultName2.Text = list[1];
                        labelResultName3.Text = list[2];
                        labelResultName4.Text = list[3];
                        labelResultName5.Text = list[4];
                        labelResultName6.Text = list[5];
                        labelResultName7.Text = list[6];
                        break;
                    case 8:
                        labelResultName1.Text = list[0];
                        labelResultName2.Text = list[1];
                        labelResultName3.Text = list[2];
                        labelResultName4.Text = list[3];
                        labelResultName5.Text = list[4];
                        labelResultName6.Text = list[5];
                        labelResultName7.Text = list[6];
                        labelResultName8.Text = list[7];
                        break;

                }
            conDatabase.Close();
        }

        private void updateTopic1ResultLabel(int numOfImagesOnBooklet, string text1, string text2,
            string text3, string text4, string text5, string text6, string text7, string text8) {
            switch (numOfImagesOnBooklet) {
                case 1:
                    topic1Image1.Text = text1;
                    break;
                case 2:
                    topic1Image1.Text = text1;
                    topic1Image2.Text = text2;
                    break;
                case 3:
                    topic1Image1.Text = text1;
                    topic1Image2.Text = text2;
                    topic1Image3.Text = text3;
                    break;
                case 4:
                    topic1Image1.Text = text1;
                    topic1Image2.Text = text2;
                    topic1Image3.Text = text3;
                    topic1Image4.Text = text4;
                    break;
                case 5:
                    topic1Image1.Text = text1;
                    topic1Image2.Text = text2;
                    topic1Image3.Text = text3;
                    topic1Image4.Text = text4;
                    topic1Image5.Text = text5;
                    break;
                case 6:
                    topic1Image1.Text = text1;
                    topic1Image2.Text = text2;
                    topic1Image3.Text = text3;
                    topic1Image4.Text = text4;
                    topic1Image5.Text = text5;
                    topic1Image6.Text = text6;
                    break;
                case 7:
                    topic1Image1.Text = text1;
                    topic1Image2.Text = text2;
                    topic1Image3.Text = text3;
                    topic1Image4.Text = text4;
                    topic1Image5.Text = text5;
                    topic1Image6.Text = text6;
                    topic1Image7.Text = text7;
                    break;
                case 8:
                    topic1Image1.Text = text1;
                    topic1Image2.Text = text2;
                    topic1Image3.Text = text3;
                    topic1Image4.Text = text4;
                    topic1Image5.Text = text5;
                    topic1Image6.Text = text6;
                    topic1Image7.Text = text7;
                    topic1Image8.Text = text8;
                    break;
            }
        }

        private void updateTopic2ResultLabel(int numOfImagesOnBooklet, string text1, string text2,
            string text3, string text4, string text5, string text6, string text7, string text8) {
            switch (numOfImagesOnBooklet) {
                case 1:
                    topic2Image1.Text = text1;
                    break;
                case 2:
                    topic2Image1.Text = text1;
                    topic2Image2.Text = text2;
                    break;
                case 3:
                    topic2Image1.Text = text1;
                    topic2Image2.Text = text2;
                    topic2Image3.Text = text3;
                    break;
                case 4:
                    topic2Image1.Text = text1;
                    topic2Image2.Text = text2;
                    topic2Image3.Text = text3;
                    topic2Image4.Text = text4;
                    break;
                case 5:
                    topic2Image1.Text = text1;
                    topic2Image2.Text = text2;
                    topic2Image3.Text = text3;
                    topic2Image4.Text = text4;
                    topic2Image5.Text = text5;
                    break;
                case 6:
                    topic2Image1.Text = text1;
                    topic2Image2.Text = text2;
                    topic2Image2.Text = text3;
                    topic2Image3.Text = text4;
                    topic2Image5.Text = text5;
                    topic2Image6.Text = text6;
                    break;
                case 7:
                    topic2Image1.Text = text1;
                    topic2Image2.Text = text2;
                    topic2Image3.Text = text3;
                    topic2Image4.Text = text4;
                    topic2Image5.Text = text5;
                    topic2Image6.Text = text6;
                    topic2Image7.Text = text7;
                    break;
                case 8:
                    topic2Image1.Text = text1;
                    topic2Image2.Text = text2;
                    topic2Image3.Text = text3;
                    topic2Image4.Text = text4;
                    topic2Image5.Text = text5;
                    topic2Image6.Text = text6;
                    topic2Image7.Text = text7;
                    topic2Image8.Text = text8;
                    break;
            }
        }

        private void updateTopic3ResultLabel(int numOfImagesOnBooklet, string text1, string text2,
    string text3, string text4, string text5, string text6) {
            switch (numOfImagesOnBooklet) {
                case 1:
                    topic3Image1.Text = text1;
                    break;
                case 2:
                    topic3Image1.Text = text1;
                    topic3Image2.Text = text2;
                    break;
                case 3:
                    topic3Image1.Text = text1;
                    topic3Image2.Text = text2;
                    topic3Image3.Text = text3;
                    break;
                case 4:
                    topic3Image1.Text = text1;
                    topic3Image2.Text = text2;
                    topic3Image3.Text = text3;
                    topic3Image4.Text = text4;
                    break;
                case 5:
                    topic3Image1.Text = text1;
                    topic3Image2.Text = text2;
                    topic3Image3.Text = text3;
                    topic3Image4.Text = text4;
                    topic3Image5.Text = text5;
                    break;
                case 6:
                    topic3Image1.Text = text1;
                    topic3Image2.Text = text2;
                    topic3Image3.Text = text3;
                    topic3Image4.Text = text4;
                    topic3Image5.Text = text5;
                    topic3Image6.Text = text6;
                    break;
            }
        }

        private void updateTopic4ResultLabel(int numOfImagesOnBooklet, string text1, string text2,
string text3, string text4, string text5, string text6) {
            switch (numOfImagesOnBooklet) {
                case 1:
                    topic4Image1.Text = text1;
                    break;
                case 2:
                    topic4Image1.Text = text1;
                    topic4Image2.Text = text2;
                    break;
                case 3:
                    topic4Image1.Text = text1;
                    topic4Image2.Text = text2;
                    topic4Image3.Text = text3;
                    break;
                case 4:
                    topic4Image1.Text = text1;
                    topic4Image2.Text = text2;
                    topic4Image3.Text = text3;
                    topic4Image4.Text = text4;
                    break;
                case 5:
                    topic4Image1.Text = text1;
                    topic4Image2.Text = text2;
                    topic4Image3.Text = text3;
                    topic4Image4.Text = text4;
                    topic4Image5.Text = text5;
                    break;
                case 6:
                    topic4Image1.Text = text1;
                    topic4Image2.Text = text2;
                    topic4Image3.Text = text3;
                    topic4Image4.Text = text4;
                    topic4Image5.Text = text5;
                    break;
            }
        }

        private void updateTopic5ResultLabel(int numOfImagesOnBooklet, string text1, string text2,
string text3, string text4, string text5, string text6) {
            switch (numOfImagesOnBooklet) {
                case 1:
                    topic5Image1.Text = text1;
                    break;
                case 2:
                    topic5Image1.Text = text1;
                    topic5Image2.Text = text2;
                    break;
                case 3:
                    topic5Image1.Text = text1;
                    topic5Image2.Text = text2;
                    topic5Image3.Text = text3;
                    break;
                case 4:
                    topic5Image1.Text = text1;
                    topic5Image2.Text = text2;
                    topic5Image3.Text = text3;
                    topic5Image4.Text = text4;
                    break;
                case 5:
                    topic5Image1.Text = text1;
                    topic5Image2.Text = text2;
                    topic5Image3.Text = text3;
                    topic5Image4.Text = text4;
                    break;
                case 6:
                    topic5Image1.Text = text1;
                    topic5Image2.Text = text2;
                    topic5Image3.Text = text3;
                    topic5Image4.Text = text4;
                    break;
            }
        }

        private void clearTable(TableLayoutPanel tablename, int rowCount) {
            tablename.Controls.Clear();
            tablename.RowCount = rowCount;
        }
        /// <summary>
        /// Update short response topic labels. Use empty string if not shown
        /// </summary>
        /// <param name="topic1"></param>
        /// <param name="topic2"></param>
        /// <param name="topic3"></param>
        /// <param name="topic4"></param>
        private void updateSRTopicLabel(string topic1, string topic2,string topic3, string topic4,string topic5) {
            srTopicLabel1.Text = topic1;
            srTopic2.Text = topic2;
            srTopic3.Text = topic3;
            srTopic4.Text = topic4;
            srTopic5.Text = topic5;
        }

        /// <summary>
        /// Call this to reset all labels if exception gets called.
        /// </summary>
        private void resetAnswerLabels() {
            topic1Results1.Text = "N/A";
            topic1Results2.Text = "N/A";
            topic1Results3.Text = "N/A";
            topic1Results4.Text = "N/A";
            topic1Results5.Text = "N/A";
            topic1Results6.Text = "N/A";
            topic1Results7.Text = "N/A";
            topic1Results8.Text = "N/A";

            topic2Results1.Text = "N/A";
            topic2Results2.Text = "N/A";
            topic2Results3.Text = "N/A";
            topic2Results4.Text = "N/A";
            topic2Results5.Text = "N/A";
            topic2Results6.Text = "N/A";
            topic2Results7.Text = "N/A";
            topic2Results8.Text = "N/A";

            topic3Results1.Text = "N/A";
            topic3Results2.Text = "N/A";
            topic3Results3.Text = "N/A";
            topic3Results4.Text = "N/A";
            topic3Results5.Text = "N/A";
            topic3Results6.Text = "N/A";

            topic4Results1.Text = "N/A";
            topic4Results2.Text = "N/A";
            topic4Results3.Text = "N/A";
            topic4Results4.Text = "N/A";
            topic4Results5.Text = "N/A";

            topic5Results1.Text = "N/A";
            topic5Results2.Text = "N/A";
            topic5Results3.Text = "N/A";
            topic5Results4.Text = "N/A";

        }

        private void button1_Click(object sender, EventArgs e) {
            resetAnswerLabels();
            if (displayShortResponse) {
                    shortResponseContainerPanel.Visible = true;
                    shortResponseContainerPanel.Enabled = true;
               try {
                        if (!Globals.previousInterview) {
                            getAdditionalCommentAnswer(3, "dislikeSounds", 1);
                            getAdditionalCommentAnswer(2, "hardToListen", 2);
                            getAdditionalCommentAnswer(4, "hardToConcentrate", 3);
                            getAdditionalCommentAnswer(3, "likeSounds", 4);
                            getAdditionalCommentAnswer(3, "makeALotSounds", 5);
                        updateSRLabels(q1labelc1, q2labelc1, q3labelc1, q4labelc1,
                            "Other sounds that you don't like?",
                            "Examples in your daily life?",
                            "Do you do anything to avoid \n these sounds (e.g., cover your ears, \n avoid noisy places?)",
                            "");
                        updateSRLabels(q1labelc2, q2labelc2, q3labelc2, q4labelc2,
                            "Other times when it is hard to listen?",
                            "Examples in your daily life?",
                            "",
                            "");
                        updateSRLabels(q1labelc2, q2labelc2, q3labelc2, q4labelc2,
                            "Other times when it is hard to listen?",
                            "Examples in your daily life?",
                            "",
                            "");
                        updateSRLabels(q1labelc2, q2labelc2, q3labelc2, q4labelc2,
                            "Other times when it is hard to listen?",
                            "Examples in your daily life?",
                            "",
                            "");


                                
                        } else {
                            getHistorySRAnswer(3, "dislikeSounds", 1);
                            getHistorySRAnswer(2, "hardToListen", 2);
                            getHistorySRAnswer(4, "hardToConcentrate", 3);
                            getHistorySRAnswer(3, "likeSounds", 4);
                            getHistorySRAnswer(3, "makeALotSounds", 5);
                    }
                        updateSRTopicLabel("Are there some sounds that you don't like?",
                            "Are there times when it is hard for you to listen?",
                            "Are there some sounds that make it hard for you to concentrate?",
                            "Are there some sounds that you like to listen to?",
                            "Are there some sounds that you make a lot?");
                    } catch (Exception) {
                    resetAnswerLabels();
                        MessageBox.Show("This interview section has not been fully completed yet! The selected answers will be displayed");
                    }
                } else {

                    hidePanels();
                    topic1ResultPanel.Visible = true;
                    topic2ResultPanel.Visible = true;
                    topic3ResultPanel.Visible = true;
                    topic4ResultPanel.Visible = true;
                    topic5ResultPanel.Visible = true;
                    clearTable(resultsTable, 8);
                    clearTable(topic2Table, 3);
                    clearTable(topic3Table, 3);
                    clearTable(topic4Table, 5);
                    clearTable(topic5Table, 4);
                    updateTopicLabel("Are there some sounds that you don't like?",
                        "Are there times when it is hard for you to listen?",
                        "Are there some sounds that make it hard for you to concentrate?",
                        "Are there some sounds that you like to listen to?",
                        "Are there some sounds that you make a lot?");
                    updateTopic1ResultLabel(8, "Other People Talking", "Fireworks", "Loud Voices", "Household Appliances", "Vehicles",
                        "Bathroom Appliances", "Sirens/Alarms/School Bells", "Sudden Loud Noises");
                    updateTopic2ResultLabel(3, "If I am concentrating on something, \n I don't notice people talking to me",
                        "I find it hard to listen to the teacher \n in noisy classrooms",
                        "I find it hard to listen to someone \n talking to me when I'm in a group", "", "", "", "", "");
                    updateTopic3ResultLabel(3, "Radio On", "Clock Ticking", "People Talking", "", "", "");
                    updateTopic5ResultLabel(4, "Humming or whistling to myself", "Tapping Feet", "Tapping Fingers", "Clicking Pen", "", "");
                    updateTopic4ResultLabel(5, "Computer Sounds", "Live Music", "Fans", "Music Through My Phone", "Rhythsm", "");
                try {
                    if (!Globals.previousInterview) {
                        getDBAnser("dislikeSounds", 8, topic1Results1, topic1Results2, topic1Results3, topic1Results4, topic1Results5, topic1Results6, topic1Results7, topic1Results8);
                        getDBAnser("hardToListen", 3, topic2Results1, topic2Results2, topic2Results3, null, null, null, null, null);
                        getDBAnser("hardToConcentrate", 3, topic3Results1, topic3Results2, topic3Results3, null, null, null, null, null);
                        getDBAnser("likeSounds", 5, topic4Results1, topic4Results2, topic4Results3, topic4Results4, topic4Results5, null, null, null);
                        getDBAnser("makeALotSounds", 4, topic5Results1, topic5Results2, topic5Results3, topic5Results4, null, null, null, null);
                    } else {
                        getPreviousInterview("dislikeSounds", 8, topic1Results1, topic1Results2, topic1Results3, topic1Results4, topic1Results5, topic1Results6, topic1Results7, topic1Results8);
                        getPreviousInterview("hardToListen", 3, topic2Results1, topic2Results2, topic2Results3, null, null, null, null, null);
                        getPreviousInterview("hardToConcentrate", 3, topic3Results1, topic3Results2, topic3Results3, null, null, null, null, null);
                        getPreviousInterview("likeSounds", 5, topic4Results1, topic4Results2, topic4Results3, topic4Results4, topic4Results5, null, null, null);
                        getPreviousInterview("makeALotSounds", 4, topic5Results1, topic5Results2, topic5Results3, topic5Results4, null, null, null, null);
                    }
                } catch (Exception ex) {
                    MessageBox.Show("This interview section has not been fully completed yet! The selected answers will be displayed");
                }
                //Re-Add the labels
                this.resultsTable.Controls.Add(this.topic1Image1, 0, 0);
                    this.resultsTable.Controls.Add(this.topic1Image2, 0, 1);
                    this.resultsTable.Controls.Add(this.topic1Image3, 0, 2);
                    this.resultsTable.Controls.Add(this.topic1Image4, 0, 3);
                    this.resultsTable.Controls.Add(this.topic1Image5, 0, 4);
                    this.resultsTable.Controls.Add(this.topic1Image6, 0, 5);
                    this.resultsTable.Controls.Add(this.topic1Image7, 0, 6);
                    this.resultsTable.Controls.Add(this.topic1Image8, 0, 7);
                    this.resultsTable.Controls.Add(this.topic1Results1, 1, 0);
                    this.resultsTable.Controls.Add(this.topic1Results2, 1, 1);
                    this.resultsTable.Controls.Add(this.topic1Results3, 1, 2);
                    this.resultsTable.Controls.Add(this.topic1Results4, 1, 3);
                    this.resultsTable.Controls.Add(this.topic1Results5, 1, 4);
                    this.resultsTable.Controls.Add(this.topic1Results6, 1, 5);
                    this.resultsTable.Controls.Add(this.topic1Results7, 1, 6);
                    this.resultsTable.Controls.Add(this.topic1Results8, 1, 7);
                    this.topic2Table.Controls.Add(this.topic2Image1, 0, 0);
                    this.topic2Table.Controls.Add(this.topic2Image2, 0, 1);
                    this.topic2Table.Controls.Add(this.topic2Image3, 0, 2);
                    this.topic2Table.Controls.Add(this.topic2Results1, 1, 0);
                    this.topic2Table.Controls.Add(this.topic2Results2, 1, 1);
                    this.topic2Table.Controls.Add(this.topic2Results3, 1, 2);
                    this.topic3Table.Controls.Add(this.topic3Image1, 0, 0);
                    this.topic3Table.Controls.Add(this.topic3Image2, 0, 1);
                    this.topic3Table.Controls.Add(this.topic3Image3, 0, 2);
                    this.topic3Table.Controls.Add(this.topic3Results1, 1, 0);
                    this.topic3Table.Controls.Add(this.topic3Results2, 1, 1);
                    this.topic3Table.Controls.Add(this.topic3Results3, 1, 2);
                    this.topic4Table.Controls.Add(this.topic4Image1, 0, 0);
                    this.topic4Table.Controls.Add(this.topic4Image2, 0, 1);
                    this.topic4Table.Controls.Add(this.topic4Image3, 0, 2);
                    this.topic4Table.Controls.Add(this.topic4Results1, 1, 0);
                    this.topic4Table.Controls.Add(this.topic4Results2, 1, 1);
                    this.topic4Table.Controls.Add(this.topic4Results3, 1, 2);
                    this.topic4Table.Controls.Add(this.topic4Image4, 0, 3);
                    this.topic4Table.Controls.Add(this.topic4Results4, 1, 3);
                    this.topic4Table.Controls.Add(this.topic4Image5, 0, 4);
                    this.topic4Table.Controls.Add(this.topic4Results5, 1, 4);
                    this.topic5Table.Controls.Add(this.topic5Image1, 0, 0);
                    this.topic5Table.Controls.Add(this.topic5Image2, 0, 1);
                    this.topic5Table.Controls.Add(this.topic5Image3, 0, 2);
                    this.topic5Table.Controls.Add(this.topic5Results1, 1, 0);
                    this.topic5Table.Controls.Add(this.topic5Results2, 1, 1);
                    this.topic5Table.Controls.Add(this.topic5Results3, 1, 2);
                    this.topic5Table.Controls.Add(this.topic5Image4, 0, 3);
                    this.topic5Table.Controls.Add(this.topic5Results4, 1, 3);
                }
            

        }

        private void updateTopicLabel(string topic1, string topic2, string topic3, string topic4, string topic5) {
            topic1Label.Text = topic1;
            topic2Label.Text = topic2;
            topic3Label.Text = topic3;
            topic4Label.Text = topic4;
            topic5Label.Text = topic5;
        }

        /// <summary>
        /// Call this to hide all columns from 3,4,5 for short response
        /// </summary>
        private void hideColumn3SR() {
            srAnswer9.Visible = false;
            srAnswer10.Visible = false;
            srAnswer11.Visible = false;
            srAnswer12.Visible = false;
            q1labelc3.Visible = false;
            q2labelc3.Visible = false;
            q3labelc3.Visible = false;
            q4labelc3.Visible = false;
            hideColumn4SR();
            hideColumn5SR();
        }
        /// <summary>
        /// Call this to hide columns 4 and 5
        /// </summary>
        private void hideColumn4SR() {
            srAnswer13.Visible = false;
            srAnswer14.Visible = false;
            srAnswer15.Visible = false;
            srAnswer16.Visible = false;
            q1labelc4.Visible = false;
            q2labelc4.Visible = false;
            q3labelc4.Visible = false;
            q4labelc4.Visible = false;
            hideColumn5SR();
        }

        /// <summary>
        /// Call this to hide column 5
        /// </summary>
        private void hideColumn5SR() {
            srAnswer17.Visible = false;
            srAnswer18.Visible = false;
            srAnswer19.Visible = false;
            srAnswer20.Visible = false;
            q1labelc5.Visible = false;
            q2labelc5.Visible = false;
            q3labelc5.Visible = false;
            q4labelc5.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e) {
            resetAnswerLabels();
            clearTable(resultsTable, 5);
                clearTable(topic2Table, 3);
                clearTable(topic3Table, 5);
                hidePanels();
                shortResponseContainerPanel.Visible = false;
                shortResponseContainerPanel.Enabled = false;
                if (displayShortResponse) {
                    hideColumn4SR();
                    shortResponseContainerPanel.Visible = true;
                    shortResponseContainerPanel.Enabled = true;
                    try {
                    if (!Globals.previousInterview) {
                        getAdditionalCommentAnswer(3, "dontLikeToLookAt", 1);
                        getAdditionalCommentAnswer(2, "sightHardToConcentrate", 2);
                        getAdditionalCommentAnswer(3, "likeToLookAt", 3);

                    } else {
                        getHistorySRAnswer(3, "dontLikeToLookAt", 1);
                        getHistorySRAnswer(2, "sightHardToConcentrate", 2);
                        getHistorySRAnswer(3, "likeToLookAt", 3);
                    }
                } catch(Exception ex) {
                        MessageBox.Show("This interview section has not been fully completed yet! The selected answers will be displayed");
                    }
                    updateSRTopicLabel("Are there some things that you don't \n like to look at?",
                    "Are there some things you see that make it \n hard to concentrate?",
                    "Are there some things that you like \n to look at?",
                    "", "");
                } else {
                    updateTopicLabel("Are there some things that you don't \n like to look at?",
                        "Are there some things you see that make it \n hard to concentrate?",
                        "Are there some things that you like \n to look at?",
                        "", "");
                    topic1ResultPanel.Visible = true;
                    topic2ResultPanel.Visible = true;
                    topic3ResultPanel.Visible = true;
                    updateTopic1ResultLabel(5, "Sunlight", "Fluorescent Light", "Light and Shadow", 
                        "Busy Patterns", "Classroom Light", "", "", "");
                    updateTopic2ResultLabel(3, "Lots of Things in a Messy Drawer", "People Running Around Me", "Lots of Things Hanging up in \n the classroom", "", "", "", "", "");
                    updateTopic3ResultLabel(5, "Moving Lights", "Things That Sparkle", "Geometric Patterns", "Spinning Fans", "Spinning Objects", "");
                        try {
                        if (!Globals.previousInterview) {
                                getDBAnser("dontLikeToLookAt", 5, topic1Results1, topic1Results2, topic1Results3, topic1Results4, topic1Results5, null, null, null);
                                getDBAnser("sightHardToConcentrate", 3, topic2Results1, topic2Results2, topic2Results3, null, null, null, null, null);
                                getDBAnser("likeToLookAt", 5, topic3Results1, topic3Results2, topic3Results3, topic3Results4, topic3Results5, null, null, null);
                        } else {
                        getPreviousInterview("dontLikeToLookAt", 5, topic1Results1, topic1Results2, topic1Results3, topic1Results4, topic1Results5, null, null, null);
                        getPreviousInterview("sightHardToConcentrate", 3, topic2Results1, topic2Results2, topic2Results3, null, null, null, null, null);
                        getPreviousInterview("likeToLookAt", 5, topic3Results1, topic3Results2, topic3Results3, topic3Results4, topic3Results5, null, null, null);
                            }
                        } catch (Exception error) {
                            MessageBox.Show("This interview section has not been fully completed yet! The selected answers will be displayed");
                        }
                    //Re-Add labels
                    this.resultsTable.Controls.Add(this.topic1Image1, 0, 0);
                    this.resultsTable.Controls.Add(this.topic1Image2, 0, 1);
                    this.resultsTable.Controls.Add(this.topic1Image3, 0, 2);
                    this.resultsTable.Controls.Add(this.topic1Image4, 0, 3);
                    this.resultsTable.Controls.Add(this.topic1Image5, 0, 4);
                    this.resultsTable.Controls.Add(this.topic1Results1, 1, 0);
                    this.resultsTable.Controls.Add(this.topic1Results2, 1, 1);
                    this.resultsTable.Controls.Add(this.topic1Results3, 1, 2);
                    this.resultsTable.Controls.Add(this.topic1Results4, 1, 3);
                    this.resultsTable.Controls.Add(this.topic1Results5, 1, 4);
                    this.topic2Table.Controls.Add(this.topic2Image1, 0, 0);
                    this.topic2Table.Controls.Add(this.topic2Image2, 0, 1);
                    this.topic2Table.Controls.Add(this.topic2Image3, 0, 2);
                    this.topic2Table.Controls.Add(this.topic2Results1, 1, 0);
                    this.topic2Table.Controls.Add(this.topic2Results2, 1, 1);
                    this.topic2Table.Controls.Add(this.topic2Results3, 1, 2);
                    this.topic3Table.Controls.Add(this.topic3Image1, 0, 0);
                    this.topic3Table.Controls.Add(this.topic3Image2, 0, 1);
                    this.topic3Table.Controls.Add(this.topic3Image3, 0, 2);
                    this.topic3Table.Controls.Add(this.topic3Image4, 0, 3);
                    this.topic3Table.Controls.Add(this.topic3Image5, 0, 4);
                    this.topic3Table.Controls.Add(this.topic3Results1, 1, 0);
                    this.topic3Table.Controls.Add(this.topic3Results2, 1, 1);
                    this.topic3Table.Controls.Add(this.topic3Results3, 1, 2);
                    this.topic3Table.Controls.Add(this.topic3Results4, 1, 3);
                    this.topic3Table.Controls.Add(this.topic3Results5, 1, 4);
                }
        }

        /// <summary>
        /// Use to hide individual label and textbox
        /// </summary>
        private void hideIndividual(Label labelName, TextBox tbName) {
            labelName.Visible = false;
            tbName.Visible = false;
            tbName.Enabled = false;
        }
        
        //This is for movement
        private void hearingBtn_Click(object sender, EventArgs e) {
            resetAnswerLabels();
            if (displayShortResponse) {
                    hideColumn5SR();
                    shortResponseContainerPanel.Visible = true;
                    shortResponseContainerPanel.Enabled = true;
                    try {
                    if (!Globals.previousInterview) {
                        getAdditionalCommentAnswer(4, "movingDontLike", 1);
                        getAdditionalCommentAnswer(1, "hardToStayStill", 2);
                        getAdditionalCommentAnswer(2, "movingThatYouLike", 3);
                        getAdditionalCommentAnswer(4, "moveOverAndOverAgain", 4);
                    } else {
                        getHistorySRAnswer(4, "movingDontLike", 1);
                        getHistorySRAnswer(1, "hardToStayStill", 2);
                        getHistorySRAnswer(2, "movingThatYouLike", 3);
                        getHistorySRAnswer(4, "moveOverAndOverAgain", 4);
                    }
                    } catch (Exception ex) {
                        MessageBox.Show("This interview section has not been fully completed yet! The selected answers will be displayed");
                    }
                    hideIndividual(q2labelc2, srAnswer10);
                    hideIndividual(q3labelc2, srAnswer11);
                    hideIndividual(q4labelc2, srAnswer12);
                    hideIndividual(q3labelc3, srAnswer15);
                    hideIndividual(q4labelc3, srAnswer16);
                    updateSRTopicLabel("Are there some ways of moving \n that you don't like?",
                    "Are there times when it is hard for \n you to stay still?",
                    "Are there some ways of moving that \n you don't like?",
                    "Are there some ways that you move over \n and over again?", "");

                } else {
                    
                    clearTable(resultsTable, 5);
                    clearTable(topic2Table, 2);
                    clearTable(topic3Table, 5);
                    clearTable(topic4Table, 4);
                    updateTopicLabel("Are there some ways of moving \n that you don't like?",
                        "Are there times when it is hard for \n you to stay still?",
                        "Are there some ways of moving that \n you don't like?",
                        "Are there some ways that you move over \n and over again?", "");
                    updateTopic1ResultLabel(5, "Being Jumped on/Tackled", "Moving when I can't see \n where I am going", "Balancing", "Being Upside Down", "Climbing Up High", "", "", "");
                    updateTopic2ResultLabel(2, "Standing Still", "Sitting Still", "", "", "", "", "", "");
                    updateTopic3ResultLabel(5, "Moving in Water", "Swinging", "Spinning", "Jumping on The Trampoline", "Running", "");
                    updateTopic4ResultLabel(4, "Rocking", "Moving Hands", "Clapping", "Pacing", "", "");
                try {
                    if (!Globals.previousInterview) {
                        getDBAnser("movingDontLike", 5, topic1Results1, topic1Results2, topic1Results3, topic1Results4, topic1Results5, null, null, null);
                        getDBAnser("hardToStayStill", 2, topic2Results1, topic2Results2, null, null, null, null, null, null);
                        getDBAnser("movingThatYouLike", 5, topic3Results1, topic3Results2, topic3Results3, topic3Results4, topic3Results5, null, null, null);
                        getDBAnser("moveOverAndOverAgain", 4, topic4Results1, topic4Results2, topic4Results3, topic4Results4, null, null, null, null);
                    } else {
                        getPreviousInterview("movingDontLike", 5, topic1Results1, topic1Results2, topic1Results3, topic1Results4, topic1Results5, null, null, null);
                        getPreviousInterview("hardToStayStill", 2, topic2Results1, topic2Results2, null, null, null, null, null, null);
                        getPreviousInterview("movingThatYouLike", 5, topic3Results1, topic3Results2, topic3Results3, topic3Results4, topic3Results5, null, null, null);
                        getPreviousInterview("moveOverAndOverAgain", 4, topic4Results1, topic4Results2, topic4Results3, topic4Results4, null, null, null, null);
                    }
                } catch (Exception ex) {
                        MessageBox.Show("This interview section has not been fully completed yet! The selected answers will be displayed");
                }

                    topic1ResultPanel.Visible = true;
                    topic2ResultPanel.Visible = true;
                    topic3ResultPanel.Visible = true;
                    topic4ResultPanel.Visible = true;

                    //Re-Add the labels
                    this.resultsTable.Controls.Add(this.topic1Image1, 0, 0);
                    this.resultsTable.Controls.Add(this.topic1Image2, 0, 1);
                    this.resultsTable.Controls.Add(this.topic1Image3, 0, 2);
                    this.resultsTable.Controls.Add(this.topic1Image4, 0, 3);
                    this.resultsTable.Controls.Add(this.topic1Image5, 0, 4);
                    this.resultsTable.Controls.Add(this.topic1Results1, 1, 0);
                    this.resultsTable.Controls.Add(this.topic1Results2, 1, 1);
                    this.resultsTable.Controls.Add(this.topic1Results3, 1, 2);
                    this.resultsTable.Controls.Add(this.topic1Results4, 1, 3);
                    this.resultsTable.Controls.Add(this.topic1Results5, 1, 4);

                    this.topic2Table.Controls.Add(this.topic2Image1, 0, 0);
                    this.topic2Table.Controls.Add(this.topic2Image2, 0, 1);
                    this.topic2Table.Controls.Add(this.topic2Results1, 1, 0);
                    this.topic2Table.Controls.Add(this.topic2Results2, 1, 1);

                    this.topic3Table.Controls.Add(this.topic3Image1, 0, 0);
                    this.topic3Table.Controls.Add(this.topic3Image2, 0, 1);
                    this.topic3Table.Controls.Add(this.topic3Image3, 0, 2);
                    this.topic3Table.Controls.Add(this.topic3Image4, 0, 3);
                    this.topic3Table.Controls.Add(this.topic3Image5, 0, 4);
                    this.topic3Table.Controls.Add(this.topic3Results1, 1, 0);
                    this.topic3Table.Controls.Add(this.topic3Results2, 1, 1);
                    this.topic3Table.Controls.Add(this.topic3Results3, 1, 2);
                    this.topic3Table.Controls.Add(this.topic3Results4, 1, 3);
                    this.topic3Table.Controls.Add(this.topic3Results5, 1, 4);


                    this.topic4Table.Controls.Add(this.topic4Image1, 0, 0);
                    this.topic4Table.Controls.Add(this.topic4Image2, 0, 1);
                    this.topic4Table.Controls.Add(this.topic4Image3, 0, 2);
                    this.topic4Table.Controls.Add(this.topic4Image4, 0, 3);
                    this.topic4Table.Controls.Add(this.topic4Results1, 1, 0);
                    this.topic4Table.Controls.Add(this.topic4Results2, 1, 1);
                    this.topic4Table.Controls.Add(this.topic4Results3, 1, 2);
                    this.topic4Table.Controls.Add(this.topic4Results4, 1, 3);
                }
        }

        //This is for Smell
        private void smellBtn_Click(object sender, EventArgs e) {


            resetAnswerLabels();

            if (displayShortResponse) {
                hideColumn3SR();
                shortResponseContainerPanel.Visible = true;
                shortResponseContainerPanel.Enabled = true;
                try {
                    if (!Globals.previousInterview) {
                        getAdditionalCommentAnswer(3, "smellDontLike", 1);
                        getAdditionalCommentAnswer(3, "likeToSmell", 2);
                    } else {
                        getHistorySRAnswer(3, "smellDontLike", 1);
                        getHistorySRAnswer(3, "likeToSmell", 2);
                    }
                } catch (Exception ex) {
                    MessageBox.Show("This interview section has not been fully completed yet! The selected answers will be displayed");
                }
                hideIndividual(q4labelc1, srAnswer4);
                hideIndividual(q4labelc2, srAnswer8);
                updateSRTopicLabel("Are there some smells that you don't like?",
                "Are there some things that you like to smell?",
                "", "", "");
            } else {

                clearTable(resultsTable, 6);
                clearTable(topic2Table, 5);
                updateTopicLabel("Are there some smells that you don't like?",
                    "Are there some things that you like to smell?",
                    "", "", "");
                updateTopic1ResultLabel(6, "Cooking Smells", "Food Smells", "Cleaning Products",
                    "Toilet Smells", "Perfumes", "Body Smells", "", "");
                updateTopic2ResultLabel(5, "Smelling Foods", "Smelling Plants",
                    "Smelling Perfume", "Smelling Soap", "Smelling People", "", "", "");
                try {
                    if (!Globals.previousInterview) {
                        getDBAnser("smellDontLike", 6, topic1Results1, topic1Results2, topic1Results3, topic1Results4, topic1Results5, topic1Results6, null, null);
                        getDBAnser("likeToSmell", 5, topic2Results1, topic2Results2, topic2Results3, topic2Results4, topic2Results5, null, null, null);
                    } else {
                        getPreviousInterview("smellDontLike", 6, topic1Results1, topic1Results2, topic1Results3, topic1Results4, topic1Results5, topic1Results6, null, null);
                        getPreviousInterview("likeToSmell", 5, topic2Results1, topic2Results2, topic2Results3, topic2Results4, topic2Results5, null, null, null);
                    }

                } catch (Exception ex) {
                    MessageBox.Show("This interview section has not been fully completed yet! The selected answers will be displayed");
                }

                hidePanels();
                topic1ResultPanel.Visible = true;
                topic2ResultPanel.Visible = true;

                //Re-Add the labels
                this.resultsTable.Controls.Add(this.topic1Image1, 0, 0);
                this.resultsTable.Controls.Add(this.topic1Image2, 0, 1);
                this.resultsTable.Controls.Add(this.topic1Image3, 0, 2);
                this.resultsTable.Controls.Add(this.topic1Image4, 0, 3);
                this.resultsTable.Controls.Add(this.topic1Image5, 0, 4);
                this.resultsTable.Controls.Add(this.topic1Image6, 0, 5);
                this.resultsTable.Controls.Add(this.topic1Results1, 1, 0);
                this.resultsTable.Controls.Add(this.topic1Results2, 1, 1);
                this.resultsTable.Controls.Add(this.topic1Results3, 1, 2);
                this.resultsTable.Controls.Add(this.topic1Results4, 1, 3);
                this.resultsTable.Controls.Add(this.topic1Results5, 1, 4);
                this.resultsTable.Controls.Add(this.topic1Results6, 1, 5);

                this.topic2Table.Controls.Add(this.topic2Results5, 1, 4);
                this.topic2Table.Controls.Add(this.topic2Results4, 1, 3);
                this.topic2Table.Controls.Add(this.topic2Image1, 0, 0);
                this.topic2Table.Controls.Add(this.topic2Image2, 0, 1);
                this.topic2Table.Controls.Add(this.topic2Image3, 0, 2);
                this.topic2Table.Controls.Add(this.topic2Results1, 1, 0);
                this.topic2Table.Controls.Add(this.topic2Results2, 1, 1);
                this.topic2Table.Controls.Add(this.topic2Results3, 1, 2);
                this.topic2Table.Controls.Add(this.topic2Image4, 0, 3);
                this.topic2Table.Controls.Add(this.topic2Image5, 0, 4);
            }
        }

        private void touchBtn_Click(object sender, EventArgs e) {
            resetAnswerLabels();
            if (displayShortResponse) {
                hideColumn4SR();
                shortResponseContainerPanel.Visible = true;
                shortResponseContainerPanel.Enabled = true;
                try {
                    if (!Globals.previousInterview) {
                        getAdditionalCommentAnswer(4, "dontLikeFeelingOf", 1);
                        getAdditionalCommentAnswer(4, "peopleTouchDontLike", 2);
                        getAdditionalCommentAnswer(3, "likeTheFeelingOf", 3);
                    } else {
                        getHistorySRAnswer(4, "dontLikeFeelingOf", 1);
                        getHistorySRAnswer(4, "peopleTouchDontLike", 2);
                        getHistorySRAnswer(3, "likeTheFeelingOf", 3);
                    }
                } catch (Exception ex) {
                    MessageBox.Show("This interview section has not been fully completed yet! The selected answers will be displayed");
                }
                hideIndividual(q4labelc3, srAnswer12);
                updateSRTopicLabel("Are there some things that you don't \n like the feeling of?",
                "Are there ways that people touch you that \n you don't like?",
                "Are there some things that you \n like the feeling of?",
                "", "");
            } else {
                clearTable(resultsTable, 8);
                clearTable(topic2Table, 8);
                clearTable(topic3Table, 6);
                updateTopicLabel("Are there some things that you don't \n like the feeling of?",
                    "Are there ways that people touch you that \n you don't like?",
                    "Are there some things that you \n like the feeling of?",
                    "", "");
                updateTopic1ResultLabel(8, "Sandy", "Sticky", "Grassy", "Wool Clothes", "Tight Clothes", "Stiff Clothes", "Shoes", "Splashing Water");
                updateTopic2ResultLabel(8, "Being Hugged or Kissed", "Being Crowded", "Being Tapped on The Shoulder", "Having Sunscreen Put on",
                    "Being Bumped", "Having a Haircut", "Doctor Touching me", "Dentist Touching me");
                updateTopic3ResultLabel(6, "Soft", "Rubbery", "Furry", "Hugging People", "Touching People", "Being Squashed With a Pillow");
                try {
                    if (!Globals.previousInterview) {

                        getDBAnser("dontLikeFeelingOf", 8, topic1Results1, topic1Results2, topic1Results3, topic1Results4, topic1Results5, topic1Results6, topic1Results7, topic1Results8);
                        getDBAnser("peopleTouchDontLike", 8, topic2Results1, topic2Results2, topic2Results3, topic2Results4, topic2Results5, topic2Results6, topic2Results7, topic2Results8);
                        getDBAnser("likeTheFeelingOf", 6, topic3Results1, topic3Results2, topic3Results3, topic3Results4, topic3Results5, topic3Results6, null, null);
                    } else {
                        getPreviousInterview("dontLikeFeelingOf", 8, topic1Results1, topic1Results2, topic1Results3, topic1Results4, topic1Results5, topic1Results6, topic1Results7, topic1Results8);
                        getPreviousInterview("peopleTouchDontLike", 8, topic2Results1, topic2Results2, topic2Results3, topic2Results4, topic2Results5, topic2Results6, topic2Results7, topic2Results8);
                        getPreviousInterview("likeTheFeelingOf", 6, topic3Results1, topic3Results2, topic3Results3, topic3Results4, topic3Results5, topic3Results6, null, null);
                    }
                } catch (Exception ex) {
                    MessageBox.Show("This interview section has not been fully completed yet! The selected answers will be displayed");
                }

                hidePanels();
                topic1ResultPanel.Visible = true;
                topic2ResultPanel.Visible = true;
                topic3ResultPanel.Visible = true;

                //Re-Add the labels
                this.resultsTable.Controls.Add(this.topic1Image1, 0, 0);
                this.resultsTable.Controls.Add(this.topic1Image2, 0, 1);
                this.resultsTable.Controls.Add(this.topic1Image3, 0, 2);
                this.resultsTable.Controls.Add(this.topic1Image4, 0, 3);
                this.resultsTable.Controls.Add(this.topic1Image5, 0, 4);
                this.resultsTable.Controls.Add(this.topic1Image6, 0, 5);
                this.resultsTable.Controls.Add(this.topic1Image7, 0, 6);
                this.resultsTable.Controls.Add(this.topic1Image8, 0, 7);
                this.resultsTable.Controls.Add(this.topic1Results1, 1, 0);
                this.resultsTable.Controls.Add(this.topic1Results2, 1, 1);
                this.resultsTable.Controls.Add(this.topic1Results3, 1, 2);
                this.resultsTable.Controls.Add(this.topic1Results4, 1, 3);
                this.resultsTable.Controls.Add(this.topic1Results5, 1, 4);
                this.resultsTable.Controls.Add(this.topic1Results6, 1, 5);
                this.resultsTable.Controls.Add(this.topic1Results7, 1, 6);
                this.resultsTable.Controls.Add(this.topic1Results8, 1, 7);

                this.topic2Table.Controls.Add(this.topic2Results8, 1, 7);
                this.topic2Table.Controls.Add(this.topic2Image8, 0, 7);
                this.topic2Table.Controls.Add(this.topic2Results7, 1, 6);
                this.topic2Table.Controls.Add(this.topic2Image7, 0, 6);
                this.topic2Table.Controls.Add(this.topic2Results6, 1, 5);
                this.topic2Table.Controls.Add(this.topic2Image6, 0, 5);
                this.topic2Table.Controls.Add(this.topic2Results5, 1, 4);
                this.topic2Table.Controls.Add(this.topic2Results4, 1, 3);
                this.topic2Table.Controls.Add(this.topic2Image1, 0, 0);
                this.topic2Table.Controls.Add(this.topic2Image2, 0, 1);
                this.topic2Table.Controls.Add(this.topic2Image3, 0, 2);
                this.topic2Table.Controls.Add(this.topic2Results1, 1, 0);
                this.topic2Table.Controls.Add(this.topic2Results2, 1, 1);
                this.topic2Table.Controls.Add(this.topic2Results3, 1, 2);
                this.topic2Table.Controls.Add(this.topic2Image4, 0, 3);
                this.topic2Table.Controls.Add(this.topic2Image5, 0, 4);

                this.topic3Table.Controls.Add(this.topic3Image1, 0, 0);
                this.topic3Table.Controls.Add(this.topic3Image2, 0, 1);
                this.topic3Table.Controls.Add(this.topic3Image3, 0, 2);
                this.topic3Table.Controls.Add(this.topic3Image4, 0, 3);
                this.topic3Table.Controls.Add(this.topic3Image5, 0, 4);
                this.topic3Table.Controls.Add(this.topic3Image6, 0, 5);
                this.topic3Table.Controls.Add(this.topic3Results1, 1, 0);
                this.topic3Table.Controls.Add(this.topic3Results2, 1, 1);
                this.topic3Table.Controls.Add(this.topic3Results3, 1, 2);
                this.topic3Table.Controls.Add(this.topic3Results4, 1, 3);
                this.topic3Table.Controls.Add(this.topic3Results5, 1, 4);
                this.topic3Table.Controls.Add(this.topic3Results6, 1, 5);
            }

        }

        public void getOTCommentsFromDB(string tableNameParam, int columnNumberInSummary) {
            //Get maxInterview Number from selected table in database
            string constring = @"Data Source =(LocalDB)\MSSQLLocalDB;" +
                                @"AttachDbFilename = |DataDirectory|\CapstoneDB\CapstoneDB.mdf; Integrated Security = True";
            SqlConnection conDatabase = new SqlConnection(constring);
            //Get Max interview number
            string getMaxInterviewID = "SELECT interviewNumber FROM " + tableNameParam +
                " WHERE interviewNumber = (SELECT MAX(interviewNumber) FROM dbo." + tableNameParam + ");";
            SqlCommand maxInterviewCmd = new SqlCommand(getMaxInterviewID, conDatabase);
            maxInterviewCmd.Parameters.AddWithValue("@id", id);
            maxInterviewCmd.Parameters.Add("@interviewRow", SqlDbType.Int).Value = Globals.interviewRow;
            conDatabase.Open();
            SqlDataReader DataReaderMaxInterview = maxInterviewCmd.ExecuteReader();
            int maxInterviewList = 0;
            //Update maxInterList
            while (DataReaderMaxInterview.Read()) {
                maxInterviewList = int.Parse(DataReaderMaxInterview["interviewNumber"].ToString());
            }
            conDatabase.Close();
            string query;
            //Determines if OT Comment interviewNumber is less than the total interview number. If so, select most recent one, else, select the interviewRow number
            if (maxInterviewList < Globals.interviewRow) {
                query = "SELECT OTComments FROM otComments WHERE interviewNumber = (SELECT MAX(interviewNumber) FROM dbo.otComments) AND ID = @id;";
            } else {
                query = "SELECT OTComments FROM otComments WHERE interviewNumber = @interviewRow ;";
            }
            SqlCommand command = new SqlCommand(query, conDatabase);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.Add("@interviewRow", SqlDbType.Int).Value = Globals.interviewRow;
            conDatabase.Open();
            SqlDataReader dr = command.ExecuteReader();
            List<string> list = new List<string>();
            while (dr.Read()) {
                //Iterate through loop and add to list
                for (int i = 0; i < 1; i++) {
                    list.Add(dr[i].ToString());
                }
            }

            //Update comment box and disable it.
            commentsTxtBox.Clear();
            commentsTxtBox.Text = list[0];
            commentsTxtBox.Enabled = false;
        }

        private void additionalCommentsBtn_Click(object sender, EventArgs e) {
            resetAnswerLabels();
            if (displayShortResponse) {
                hideColumn3SR();
                shortResponseContainerPanel.Visible = true;
                shortResponseContainerPanel.Enabled = true;
                try {
                    if (!Globals.previousInterview) {
                        getAdditionalCommentAnswer(4, "other", 1);
                        getAdditionalCommentAnswer(4, "other", 2);
                    } else {
                        getHistorySRAnswer(4, "other", 1);
                        getHistorySRAnswer(4, "other", 2);
                    }
                } catch (Exception ex) {
                    MessageBox.Show("This interview section has not been fully completed yet! The selected answers will be displayed");
                }
                updateSRTopicLabel("Are there some places with lots of things \n happening at once that you don't like?",
                "Are there other sensations that you \n feel strongly about?",
                "", "", "");
            } else {
                clearTable(resultsTable, 5);
                clearTable(topic2Table, 6);
                updateTopicLabel("Are there some places with lots of things \n happening at once that you don't like?",
                    "Are there other sensations that you \n feel strongly about?",
                    "", "", "");
                updateTopic1ResultLabel(5, "Supermarket", "Party", "Food Hall", "Show", "Shopping Mall", "", "", "");
                updateTopic2ResultLabel(6, "Sound", "Smells", "Sights", "Tastes", "Feelings", "Movements", "", "");
                try {
                    if (!Globals.previousInterview) {
                        getDBAnser("other", 5, topic1Results1, topic1Results2, topic1Results3, topic1Results4, topic1Results5, null, null, null);
                        getDBAnser("other", 6, topic2Results1, topic2Results2, topic2Results3, topic2Results4, topic2Results5, topic2Results6, null, null);
                    } else {
                        getPreviousInterview("other", 5, topic1Results1, topic1Results2, topic1Results3, topic1Results4, topic1Results5, null, null, null);
                        getPreviousInterview("other", 6, topic2Results1, topic2Results2, topic2Results3, topic2Results4, topic2Results5, topic2Results6, null, null);
                    }

                } catch (Exception ex) {
                    MessageBox.Show("This interview section has not been fully completed yet! The selected answers will be displayed");
                }

                hidePanels();
                topic1ResultPanel.Visible = true;
                topic2ResultPanel.Visible = true;

                this.resultsTable.Controls.Add(this.topic1Image1, 0, 0);
                this.resultsTable.Controls.Add(this.topic1Image2, 0, 1);
                this.resultsTable.Controls.Add(this.topic1Image3, 0, 2);
                this.resultsTable.Controls.Add(this.topic1Image4, 0, 3);
                this.resultsTable.Controls.Add(this.topic1Image5, 0, 4);
                this.resultsTable.Controls.Add(this.topic1Results1, 1, 0);
                this.resultsTable.Controls.Add(this.topic1Results2, 1, 1);
                this.resultsTable.Controls.Add(this.topic1Results3, 1, 2);
                this.resultsTable.Controls.Add(this.topic1Results4, 1, 3);
                this.resultsTable.Controls.Add(this.topic1Results5, 1, 4);

                this.topic2Table.Controls.Add(this.topic2Image1, 0, 0);
                this.topic2Table.Controls.Add(this.topic2Image2, 0, 1);
                this.topic2Table.Controls.Add(this.topic2Image3, 0, 2);
                this.topic2Table.Controls.Add(this.topic2Image4, 0, 3);
                this.topic2Table.Controls.Add(this.topic2Image5, 0, 4);
                this.topic2Table.Controls.Add(this.topic2Image6, 0, 5);
                this.topic2Table.Controls.Add(this.topic2Results1, 1, 0);
                this.topic2Table.Controls.Add(this.topic2Results2, 1, 1);
                this.topic2Table.Controls.Add(this.topic2Results3, 1, 2);
                this.topic2Table.Controls.Add(this.topic2Results4, 1, 3);
                this.topic2Table.Controls.Add(this.topic2Results5, 1, 4);
                this.topic2Table.Controls.Add(this.topic2Results6, 1, 5);

            } 
        }

        private void tasteBtn_Click(object sender, EventArgs e) {

            resetAnswerLabels();
            if (displayShortResponse) {
                hideColumn5SR();
                shortResponseContainerPanel.Visible = true;
                shortResponseContainerPanel.Enabled = true;
                try {
                    if (!Globals.previousInterview) {
                        getAdditionalCommentAnswer(2, "foodGroupsDontLike", 1);
                        getAdditionalCommentAnswer(3, "tastesOrFeelsInMouthDontLike", 2);
                        getAdditionalCommentAnswer(2, "foodReallyLikeToEat", 3);
                        getAdditionalCommentAnswer(3, "thingsPutInMouthALot", 4);
                    } else {
                        getHistorySRAnswer(2, "foodGroupsDontLike", 1);
                        getHistorySRAnswer(3, "tastesOrFeelsInMouthDontLike", 2);
                        getHistorySRAnswer(2, "foodReallyLikeToEat", 3);
                        getHistorySRAnswer(3, "thingsPutInMouthALot", 4);
                    }
                } catch (Exception ex) {
                    MessageBox.Show("This interview section has not been fully completed yet! The selected answers will be displayed");
                }
                hideIndividual(q3labelc1, srAnswer3);
                hideIndividual(q4labelc1, srAnswer4);
                hideIndividual(q4labelc2, srAnswer8);
                hideIndividual(q3labelc3, srAnswer11);
                hideIndividual(q4labelc3, srAnswer12);
                hideIndividual(q4labelc4, srAnswer16);
            }
            if (!displayShortResponse) {
                clearTable(resultsTable, 8);
                clearTable(topic2Table, 8);
                clearTable(topic3Table, 2);
                clearTable(topic4Table, 3);
                updateTopicLabel("Are there some food groups that you don't like eating?",
                    "Are there some ways that food tastes or feels \n in your mouth that you don't like?",
                    "Are there some things you really like to eat?",
                    "Are there some things that you put in \n your mouth a lot?",
                    "");
                updateTopic1ResultLabel(8, "Vegetables", "Fruit", "Meat", "Fish", "Eggs",
                    "Dairy", "Bread", "Pasta");
                updateTopic2ResultLabel(8, "Lumpy", "Chewy", "Runny/Slippery", "Mixed", "Sweet", "Sour", "Salty", "Spicy");
                updateTopic3ResultLabel(2, "Familiar Foods, only a few types of foods \n i.e. I Don't Like Trying New Foods",
                    "Unfamiliar Foods, lots of different types of foods \n i.e. I Like Trying New Foods", "", "", "", "");
                updateTopic4ResultLabel(3, "Shirt", "Hair", "Objects", "", "", "");
                try {
                    if (!Globals.previousInterview) {
                        getDBAnser("foodGroupsDontLike", 8, topic1Results1, topic1Results2, topic1Results3, topic1Results4, topic1Results5, topic1Results6, topic1Results7, topic1Results8);
                        getDBAnser("tastesOrFeelsInMouthDontLike", 8, topic2Results1, topic2Results2, topic2Results3, topic2Results4, topic2Results5, topic2Results6, topic2Results7, topic2Results8);
                        getDBAnser("foodReallyLikeToEat", 2, topic3Results1, topic3Results2, null, null, null, null, null, null);
                        getDBAnser("thingsPutInMouthALot", 3, topic4Results1, topic4Results2, topic4Results3, null, null, null, null, null);
                    } else {
                        getPreviousInterview("foodGroupsDontLike", 8, topic1Results1, topic1Results2, topic1Results3, topic1Results4, topic1Results5, topic1Results6, topic1Results7, topic1Results8);
                        getPreviousInterview("tastesOrFeelsInMouthDontLike", 8, topic2Results1, topic2Results2, topic2Results3, topic2Results4, topic2Results5, topic2Results6, topic2Results7, topic2Results8);
                        getPreviousInterview("foodReallyLikeToEat", 2, topic3Results1, topic3Results2, null, null, null, null, null, null);
                        getPreviousInterview("thingsPutInMouthALot", 3, topic4Results1, topic4Results2, topic4Results3, null, null, null, null, null);
                    }
                } catch (Exception ex) {
                    MessageBox.Show("This interview section has not been fully completed yet! The selected answers will be displayed");
                }

                hidePanels();
                topic1ResultPanel.Visible = true;
                topic2ResultPanel.Visible = true;
                topic3ResultPanel.Visible = true;
                topic4ResultPanel.Visible = true;

                //Re-Add the labels
                this.resultsTable.Controls.Add(this.topic1Image1, 0, 0);
                this.resultsTable.Controls.Add(this.topic1Image2, 0, 1);
                this.resultsTable.Controls.Add(this.topic1Image3, 0, 2);
                this.resultsTable.Controls.Add(this.topic1Image4, 0, 3);
                this.resultsTable.Controls.Add(this.topic1Image5, 0, 4);
                this.resultsTable.Controls.Add(this.topic1Image6, 0, 5);
                this.resultsTable.Controls.Add(this.topic1Image7, 0, 6);
                this.resultsTable.Controls.Add(this.topic1Image8, 0, 7);
                this.resultsTable.Controls.Add(this.topic1Results1, 1, 0);
                this.resultsTable.Controls.Add(this.topic1Results2, 1, 1);
                this.resultsTable.Controls.Add(this.topic1Results3, 1, 2);
                this.resultsTable.Controls.Add(this.topic1Results4, 1, 3);
                this.resultsTable.Controls.Add(this.topic1Results5, 1, 4);
                this.resultsTable.Controls.Add(this.topic1Results6, 1, 5);
                this.resultsTable.Controls.Add(this.topic1Results7, 1, 6);
                this.resultsTable.Controls.Add(this.topic1Results8, 1, 7);

                this.topic2Table.Controls.Add(this.topic2Results8, 1, 7);
                this.topic2Table.Controls.Add(this.topic2Image8, 0, 7);
                this.topic2Table.Controls.Add(this.topic2Results7, 1, 6);
                this.topic2Table.Controls.Add(this.topic2Image7, 0, 6);
                this.topic2Table.Controls.Add(this.topic2Results6, 1, 5);
                this.topic2Table.Controls.Add(this.topic2Image6, 0, 5);
                this.topic2Table.Controls.Add(this.topic2Results5, 1, 4);
                this.topic2Table.Controls.Add(this.topic2Results4, 1, 3);
                this.topic2Table.Controls.Add(this.topic2Image1, 0, 0);
                this.topic2Table.Controls.Add(this.topic2Image2, 0, 1);
                this.topic2Table.Controls.Add(this.topic2Image3, 0, 2);
                this.topic2Table.Controls.Add(this.topic2Results1, 1, 0);
                this.topic2Table.Controls.Add(this.topic2Results2, 1, 1);
                this.topic2Table.Controls.Add(this.topic2Results3, 1, 2);
                this.topic2Table.Controls.Add(this.topic2Image4, 0, 3);
                this.topic2Table.Controls.Add(this.topic2Image5, 0, 4);

                this.topic3Table.Controls.Add(this.topic3Image1, 0, 0);
                this.topic3Table.Controls.Add(this.topic3Image2, 0, 1);
                this.topic3Table.Controls.Add(this.topic3Results1, 1, 0);
                this.topic3Table.Controls.Add(this.topic3Results2, 1, 1);

                this.topic4Table.Controls.Add(this.topic4Image1, 0, 0);
                this.topic4Table.Controls.Add(this.topic4Image2, 0, 1);
                this.topic4Table.Controls.Add(this.topic4Image3, 0, 2);
                this.topic4Table.Controls.Add(this.topic4Results1, 1, 0);
                this.topic4Table.Controls.Add(this.topic4Results2, 1, 1);
                this.topic4Table.Controls.Add(this.topic4Results3, 1, 2);
            }
        }

        private void Summary_Load(object sender, EventArgs e) {
            shortResponseButton();
            //getInterviewType();
        }

        bool displayShortResponse = false;
        string interviewType; //2 = Independent, 3 = family, 1 = guided
        private void changeSummaryPanelType_Click(object sender, EventArgs e) {
            hidePanels();
            shortResponseContainerPanel.Visible = false;
            if (!displayShortResponse) { //Non SR Panel
                shortResponseContainerPanel.Visible = false;
                shortResponseContainerPanel.Enabled = false;
                changeSummaryPanelType.Text = "View Image Answers";
                Globals.shortResponse = true;
                displayShortResponse = true;
            } else if(displayShortResponse){ //Sr Panel
                displayShortResponse = false;
                Globals.shortResponse = false;
                changeSummaryPanelType.Text = "View Short Response Answers";
                hidePanels();
            }
        }

        /// <summary>
        /// Call this when reaching the end of the interview. Not for viewing past interviews
        /// </summary>
        private void getInterviewType() {
            string constring = @"Data Source =(LocalDB)\MSSQLLocalDB;" +
                                @"AttachDbFilename = |DataDirectory|\CapstoneDB\CapstoneDB.mdf; Integrated Security = True";
            SqlConnection conDatabase = new SqlConnection(constring);
            //Replace summary in string with variable for db table name
            SqlCommand command = new SqlCommand("SELECT InterviewType FROM linkProfileInterview WHERE InterviewID = (SELECT MAX(InterviewID) FROM dbo.linkProfileInterview );", conDatabase);
            conDatabase.Open();
            SqlDataReader dr = command.ExecuteReader();
            List<string> list = new List<string>();
            while (dr.Read()) {
                list.Add(dr["InterviewType"].ToString());
            }
            interviewType = list[0];
        }
    }
}
