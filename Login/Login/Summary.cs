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
        private const string ALITTLE = "A Little";
        private const string ALOT = "A Lot";

        private void getDBResults() {

        }

       /* private void Summary_Load(object sender, EventArgs e) {
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
        } */

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

        private void button1_Click(object sender, EventArgs e) {
            hidePanels();
            topic1ResultPanel.Visible = true;
            topic2ResultPanel.Visible = true;
            topic3ResultPanel.Visible = true;
            topic4ResultPanel.Visible = true;
            topic5ResultPanel.Visible = true;
            updateTopicLabel("Are there some sounds that you don't like?",
                "Are there times when it is hard for you to listen?",
                "Are there some sounds that make it hard for you to concentrate?",
                "Are there some sounds that you like to listen to?",
                "Are there some sounds that you make a lot?");
        }

        private void updateTopicLabel(string topic1, string topic2, string topic3, string topic4, string topic5) {
            topic1Label.Text = topic1;
            topic2Label.Text = topic2;
            topic3Label.Text = topic3;
            topic4Label.Text = topic4;
            topic5Label.Text = topic5;
        }

        private void button2_Click(object sender, EventArgs e) {
            hidePanels();
            updateTopicLabel("Are there some things that you don't \n like to look at?",
                "Are there some things you see that make it \n hard to concentrate?",
                "Are there some things that you like \n to look at?",
                "", "");
            topic1ResultPanel.Visible = true;
            topic2ResultPanel.Visible = true;
            topic3ResultPanel.Visible = true;
        }
        
        //This is for movement
        private void hearingBtn_Click(object sender, EventArgs e) {
            updateTopicLabel("Are there some ways of moving \n that you don't like?",
                "Are there times when it is hard for \n you to stay still?",
                "Are there some ways of moving that \n you don't like?",
                "Are there some ways that you move over \n and over again?", "");
        }

        //This is for Smell
        private void smellBtn_Click(object sender, EventArgs e) {
            updateTopicLabel("Are there some smells that you don't like?",
                "Are there some things that you like to smell?",
                "", "", "");
            hidePanels();
            topic1ResultPanel.Visible = true;
            topic2ResultPanel.Visible = true;
        }

        private void touchBtn_Click(object sender, EventArgs e) {
            updateTopicLabel("Are there some things that you don't \n like the feeling of?",
                "Are there ways that people touch you that \n you don't like?",
                "Are there some things that you \n like the feeling of?",
                "", "");
            hidePanels();
            topic1ResultPanel.Visible = true;
            topic2ResultPanel.Visible = true;
            topic3ResultPanel.Visible = true;
        }

        private void additionalCommentsBtn_Click(object sender, EventArgs e) {
            updateTopicLabel("Are there some places with lots of things \n happening at once that you don't like?",
                "Are there other sensations that you \n feel strongly about?",
                "", "", "");
            hidePanels();
            topic1ResultPanel.Visible = true;
            topic2ResultPanel.Visible = true;
        }

        private void tasteBtn_Click(object sender, EventArgs e) {
            updateTopicLabel("Are there some food groups that you don't like eating?",
                "Are there some ways that food tastes or feels \n in your mouth that you don't like?",
                "Are there some things you really like to eat?",
                "Are there some things that you put in \n your mouth a lot?",
                "");
            hidePanels();
            topic1ResultPanel.Visible = true;
            topic2ResultPanel.Visible = true;
            topic3ResultPanel.Visible = true;
            topic4ResultPanel.Visible = true;
        }
    }
}
