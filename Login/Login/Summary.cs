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
        //TODO -> Store each sense into different table. Get results from topic table and store into array

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
            string constring = @"Data Source =(LocalDB)\MSSQLLocalDB;" +
                @"AttachDbFilename = |DataDirectory|\CapstoneDB\CapstoneDB.mdf; Integrated Security = True";
            SqlConnection conDatabase = new SqlConnection(constring);
            //Replace summary in string with variable for db table name
            SqlCommand command = new SqlCommand("SELECT * FROM " + tableNameParam + ";", conDatabase);
            conDatabase.Open();
            SqlDataReader dr = command.ExecuteReader();
            List<string> list = new List<string>();
            while (dr.Read()) {
                //Iterate through loop and add to list
                for(int i = 0; i < totalImages; i++) {
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

        private void button1_Click(object sender, EventArgs e) {
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

            getDBAnser("dislikeSounds", 8, topic1Results1, topic1Results2, topic1Results3, topic1Results4, topic1Results5, topic1Results6, topic1Results7, topic1Results8);
            getDBAnser("hardToListen", 3, topic2Results1, topic2Results2, topic2Results3, null, null, null, null, null);
            getDBAnser("hardToConcentrate", 3, topic3Results1, topic3Results2, topic3Results3, null, null, null, null, null);
            getDBAnser("likeSounds", 5, topic4Results1, topic4Results2, topic4Results3, topic4Results4, topic4Results5, null, null, null);
            getDBAnser("makeALotSounds", 4, topic5Results1, topic5Results2, topic5Results3, topic5Results4, null, null, null, null);

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

        private void updateTopicLabel(string topic1, string topic2, string topic3, string topic4, string topic5) {
            topic1Label.Text = topic1;
            topic2Label.Text = topic2;
            topic3Label.Text = topic3;
            topic4Label.Text = topic4;
            topic5Label.Text = topic5;
        }

        private void button2_Click(object sender, EventArgs e) {
            try {
                clearTable(resultsTable, 5);
                clearTable(topic2Table, 3);
                clearTable(topic3Table, 5);
                hidePanels();
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

                getDBAnser("dontLikeToLookAt", 5, topic1Results1, topic1Results2, topic1Results3, topic1Results4, topic1Results5, null, null, null);
                getDBAnser("sightHardToConcentrate", 3, topic2Results1, topic2Results2, topic2Results3, null, null, null, null, null);
                getDBAnser("likeToLookAt", 5, topic3Results1, topic3Results2, topic3Results3, topic3Results4, topic3Results5, null, null, null);

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
            } catch (Exception error) {
                MessageBox.Show("An interview has not been completed!");
            }
        }
        
        //This is for movement
        private void hearingBtn_Click(object sender, EventArgs e) {
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

            getDBAnser("movingDontLike", 5, topic1Results1, topic1Results2, topic1Results3, topic1Results4, topic1Results5, null, null, null);
            getDBAnser("hardToStayStill", 2, topic2Results1, topic2Results2, null, null, null, null, null, null);
            getDBAnser("movingThatYouLike", 5, topic3Results1, topic3Results2, topic3Results3, topic3Results4, topic3Results5, null, null, null);
            getDBAnser("moveOverAndOverAgain", 4, topic4Results1, topic4Results2, topic4Results3, topic4Results4, null, null, null, null);

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

        //This is for Smell
        private void smellBtn_Click(object sender, EventArgs e) {
            clearTable(resultsTable, 6);
            clearTable(topic2Table, 5);
            updateTopicLabel("Are there some smells that you don't like?",
                "Are there some things that you like to smell?",
                "", "", "");
            updateTopic1ResultLabel(6, "Cooking Smells", "Food Smells", "Cleaning Products",
                "Toilet Smells", "Perfumes", "Body Smells", "", "");
            updateTopic2ResultLabel(5, "Smelling Foods", "Smelling Plants",
                "Smelling Perfume", "Smelling Soap", "Smelling People", "", "", "");

            getDBAnser("smellDontLike", 6, topic1Results1, topic1Results2, topic1Results3, topic1Results4, topic1Results5, topic1Results6, null, null);
            getDBAnser("likeToSmell", 5, topic2Results1, topic2Results2, topic2Results3, topic2Results4, topic2Results5, null, null, null);

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

        private void touchBtn_Click(object sender, EventArgs e) {
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

            getDBAnser("dontLikeFeelingOf", 8, topic1Results1, topic1Results2, topic1Results3, topic1Results4, topic1Results5, topic1Results6, topic1Results7, topic1Results8);
            getDBAnser("peopleTouchDontLike", 8, topic2Results1, topic2Results2, topic2Results3, topic2Results4, topic2Results5, topic2Results6, topic2Results7, topic2Results8);
            getDBAnser("likeTheFeelingOf", 6, topic3Results1, topic3Results2, topic3Results3, topic3Results4, topic3Results5, topic3Results6, null, null);

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

        private void additionalCommentsBtn_Click(object sender, EventArgs e) {
            clearTable(resultsTable, 5);
            clearTable(topic2Table, 6);
            updateTopicLabel("Are there some places with lots of things \n happening at once that you don't like?",
                "Are there other sensations that you \n feel strongly about?",
                "", "", "");
            updateTopic1ResultLabel(5, "Supermarket", "Party", "Food Hall", "Show", "Shopping Mall", "", "", "");
            updateTopic2ResultLabel(6, "Sound", "Smells", "Sights", "Tastes", "Feelings", "Movements", "", "");

            getDBAnser("other", 5, topic1Results1, topic1Results2, topic1Results3, topic1Results4, topic1Results5, null, null, null);
            getDBAnser("other", 6, topic2Results1, topic2Results2, topic2Results3, topic2Results4, topic2Results5, topic2Results6, null, null);

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

        private void tasteBtn_Click(object sender, EventArgs e) {
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

            getDBAnser("foodGroupsDontLike", 8, topic1Results1, topic1Results2, topic1Results3, topic1Results4, topic1Results5, topic1Results6, topic1Results7, topic1Results8);
            getDBAnser("tastesOrFeelsInMouthDontLike", 8, topic2Results1, topic2Results2, topic2Results3, topic2Results4, topic2Results5, topic2Results6, topic2Results7, topic2Results8);
            getDBAnser("foodReallyLikeToEat", 2, topic3Results1, topic3Results2, null, null, null, null, null, null);
            getDBAnser("thingsPutInMouthALot", 3, topic4Results1, topic4Results2, topic4Results3, null, null, null, null, null);

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
}
