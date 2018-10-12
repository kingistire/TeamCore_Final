﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace Login {
    public partial class GuidedInterview : Form {
        public GuidedInterview() {
            InitializeComponent();
            this.Hide();
            panel1.BringToFront();
            //Dynamically create the circular picture boxes
            createCirclePB(bottomLeftPB);
            createCirclePB(bottomRightPB);
            createCirclePB(bottomMidPB);
            createCirclePB(topLeftPB);
            createCirclePB(topRightPB);
            createCirclePB(topMidPB);
            Globals.independentInterview = false;

            if (Globals.interview_page >= 2) {
                previousInterviewSlideBtn.Visible = true;
            }
            else {
                previousInterviewSlideBtn.Visible = false;
            }
            //determines which page to display when the interview form is loaded
            //resets to one when the user starts a new interview
            if (Globals.interview_page == 1) {
                interviewPage1();
            }
            else if (Globals.interview_page == 2) {
                interviewPage1p2();
            }
            else if (Globals.interview_page == 3) {
                interviewPage2();
            }
            else if (Globals.interview_page == 4) {
                interviewPage3();
            }
            else if (Globals.interview_page == 5) {
                interviewPage4();
            }
            else if (Globals.interview_page == 6) {
                interviewPage5();
            }
            else if (Globals.interview_page == 7) {
                sightInterviewPage1();
                SightColours();
            }
            else if (Globals.interview_page == 8) {
                sightInterviewPage2();
                SightColours();
            }
            else if (Globals.interview_page == 9) {
                sightInterviewPage3();
                SightColours();
            }
            else if (Globals.interview_page == 10) {
                touchInterviewPage1();
                TouchColours();
            }
            else if (Globals.interview_page == 11) {
                touchInterviewPage1p2();
                TouchColours();
            }
            else if (Globals.interview_page == 12) {
                touchInterviewPage2();
                TouchColours();
            }
            else if (Globals.interview_page == 13) {
                touchInterviewPage2p2();
                TouchColours();
            }
            else if (Globals.interview_page == 14) {
                touchInterviewPage3();
                TouchColours();
            }
            else if (Globals.interview_page == 15) {
                smellInterviewPage1();
                SmellColours();
            }
            else if (Globals.interview_page == 16) {
                smellInterviewPage2();
                SmellColours();
            }
            else if (Globals.interview_page == 17) {
                tasteInterviewPage1();
                TasteColours();
            }
            else if (Globals.interview_page == 18) {
                tasteInterviewPage1p2();
                TasteColours();
            }
            else if (Globals.interview_page == 19) {
                tasteInterviewPage2();
                TasteColours();
             }
            else if (Globals.interview_page == 20) {
                tasteInterviewPage2p2();
                TasteColours();
            }
            else if (Globals.interview_page == 21) {
                tasteInterviewPage3();
                TasteColours();
            }
            else if (Globals.interview_page == 22) {
                tasteInterviewPage4();
                TasteColours();
            }
            else if (Globals.interview_page == 23) {
                mvmtInterviewPage1();
                MovementColours();
            }
            else if (Globals.interview_page == 24) {
                mvmtInterviewPage2();
                MovementColours();
            }
            else if (Globals.interview_page == 25) {
                mvmtInterviewPage3();
                MovementColours();
            }
            else if (Globals.interview_page == 26) {
                mvmtInterviewPage4();
                MovementColours();
            }
            else if (Globals.interview_page == 27) {
                environmentInterviewPage1();
                EnvironmentColours();
            }
            else if (Globals.interview_page == 28) {
                otherInterviewPage1();
                OtherColours();
            }
        }

        //Pen variables to draw
        private Pen aLittle = new Pen(Color.Black, 15);
        private Pen aLot = new Pen(Color.Black, 30);

        /// <summary>
        /// Dynamically create circular pictureboxes
        /// </summary>
        /// <param name="pictureBox">picturebox name</param>
        private void createCirclePB(PictureBox pictureBox) {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, pictureBox.Width, pictureBox.Height);
            pictureBox.Region = new Region(path);
        }

        /// <summary>
        /// Draw a circle
        /// </summary>
        /// <param name="pen"></param>
        /// <param name="pictureBox"></param>
        /// <param name="e"></param>
        /// <param name="x">Boundary of the x value</param>
        /// <param name="y">Boundary of the y value</param>
        /// <param name="width">Must be an int of the picture box i.e. nameOfPictureBox.Size.Width</param>
        /// <param name="height">Same with height but with nameOfPictureBox.Size.Height</param>
        private void DrawCircle(Pen pen, PaintEventArgs e, int x, int y, int width, int height) {
            Graphics g = e.Graphics;
            g.DrawEllipse(pen, x, y, width, height);
        }

        /// <summary>
        /// Call this funcation to draw circle. Will determine what to draw
        /// </summary>
        /// <param name="e"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width">picturebox.Width</param>
        /// <param name="height">picturebox.Height</param>
        /// <param name="index">index of array</param>
        private void determineDrawing(PaintEventArgs e, int x, int y, int width, int height, int index) {
            if (page1Selections[index] == "A Little") {
                DrawCircle(aLittle, e, x, y, width, height);
            }
            else if (page1Selections[index] == "A Lot") {
                DrawCircle(aLot, e, x, y, width, height);
            }
        }

        //Code from here will update the pictureboxes when the user has clicked on a button
        private void topLeftPB_Paint(object sender, PaintEventArgs e) {
            //DeterminePenSizeDrawing(sender, topLeftPB, e);
            determineDrawing(e, 0, 0, topLeftPB.Width, topRightPB.Height, 0);
        }
        private void topMidPB_Paint(object sender, PaintEventArgs e) {
            determineDrawing(e, 0, 0, topMidPB.Width, topMidPB.Height, 1);
        }
        private void topRightPB_Paint(object sender, PaintEventArgs e) {
            determineDrawing(e, 0, 0, topRightPB.Width, topRightPB.Height, 2);
        }
        private void bottomLeftPB_Paint(object sender, PaintEventArgs e) {
            determineDrawing(e, 0, 0, bottomLeftPB.Width, bottomLeftPB.Height, 3);
        }
        private void bottomMidPB_Paint(object sender, PaintEventArgs e) {
            determineDrawing(e, 0, 0, bottomMidPB.Width, bottomMidPB.Height, 4);
        }
        private void bottomRightPB_Paint(object sender, PaintEventArgs e) {
            determineDrawing(e, 0, 0, bottomRightPB.Width, bottomRightPB.Height, 5);
        }

        //I would simply create an array of size 6, and when they select 'a little' for picture1 (top left)
        //change the first value in the array to 1, 'a lot' would be set to 2.
        //if they make no selection it remains as 0
        string[] page1Selections = new string[6] { "", "", "", "", "", "" };
        bool updateDBBool = false;
        /// <summary>
        /// Insert to database if 6 images are there
        /// </summary>
        /// <param name="array"></param>
        /// <param name="TLImageName"></param>
        /// <param name="TMImageName"></param>
        /// <param name="TRImageName"></param>
        /// <param name="BLImageName"></param>
        /// <param name="BMImageName"></param>
        /// <param name="BRImageName"></param>
        private void writeToDB(string[] array, string TLImageName, string TMImageName, string TRImageName, string BLImageName, string BMImageName, string BRImageName, string tableDBName) {

            SqlCommand cmdDatabase;
            const string constring = @"Data Source =(LocalDB)\MSSQLLocalDB;" +
                                    @"AttachDbFilename = |DataDirectory|\CapstoneDB\CapstoneDB.mdf; Integrated Security = True";
            SqlConnection conDatabase = new SqlConnection(constring);
            //Determine if a little or a lot
            try {
                string query;
                conDatabase.Open();
                //Change interview_page to see if previous button has been clicked
                query = "INSERT INTO dbo." + tableDBName + "(" + TLImageName + "," + TMImageName + "," +
                     TRImageName + "," +
                      BLImageName + "," +
                       BMImageName + "," + BRImageName + ") VALUES (@tl, @tm, @tr, @bl, @bm, @br);";
                /*               if (updateDBBool == true) {
                                   query = "UPDATE dbo.Summary set " + TLImageName + "=@tl," + TMImageName + "=@tm," +
                                       TRImageName + "=@tr," +
                                       BLImageName + "=@bl," +
                                       BMImageName + "=@bm," + BRImageName + "=@br;";
                               } */

                cmdDatabase = new SqlCommand(query, conDatabase);
                cmdDatabase.Parameters.AddWithValue("@tl", page1Selections[0]);
                cmdDatabase.Parameters.AddWithValue("@tm", page1Selections[1]);
                cmdDatabase.Parameters.AddWithValue("@tr", page1Selections[2]);
                cmdDatabase.Parameters.AddWithValue("@bl", page1Selections[3]);
                cmdDatabase.Parameters.AddWithValue("@bm", page1Selections[4]);
                cmdDatabase.Parameters.AddWithValue("@br", page1Selections[5]);
                cmdDatabase.ExecuteNonQuery();
            }
            catch (Exception err) {
                MessageBox.Show("An Error has occurred while writing to the database: " + err.Message);
            }
        }

        private void writeToDBTop3(string[] array, string TLImageName, string TMImageName, string TRImageName, string dbTableName) {

            const string constring = @"Data Source =(LocalDB)\MSSQLLocalDB;" +
                        @"AttachDbFilename = |DataDirectory|\CapstoneDB\CapstoneDB.mdf; Integrated Security = True";
            SqlConnection conDatabase = new SqlConnection(constring);

            SqlCommand cmdDatabase;
            //Determine if a little or a lot
            try {
                conDatabase.Open();
                string query = "INSERT INTO dbo." + dbTableName + "(" + TLImageName + "," + TMImageName + "," +
                         TRImageName + ") VALUES (@tl, @tm, @tr);";

                //"UPDATE dbo" + dbTableName + "SET " + TLImageName + "=@tl," + TMImageName +"=@tm," + TRImageName + "=@tr;";
                cmdDatabase = new SqlCommand(query, conDatabase);
                cmdDatabase.Parameters.AddWithValue("@tl", page1Selections[0]);
                cmdDatabase.Parameters.AddWithValue("@tm", page1Selections[1]);
                cmdDatabase.Parameters.AddWithValue("@tr", page1Selections[2]);
                cmdDatabase.ExecuteNonQuery();
            }
            catch (Exception err) {
                MessageBox.Show("An Error has occurred while writing to the database: " + err.Message);
            }
        }

        private void writeToDBTop2(string[] array, string TLImageName, string TMImageName, string dbTableName) {

            const string constring = @"Data Source =(LocalDB)\MSSQLLocalDB;" +
                        @"AttachDbFilename = |DataDirectory|\CapstoneDB\CapstoneDB.mdf; Integrated Security = True";
            SqlConnection conDatabase = new SqlConnection(constring);

            SqlCommand cmdDatabase;
            //Determine if a little or a lot
            try {
                conDatabase.Open();
                string query = "INSERT INTO dbo." + dbTableName + "(" + TLImageName + "," + TMImageName + ") VALUES (@tl, @tm);";
                cmdDatabase = new SqlCommand(query, conDatabase);
                cmdDatabase.Parameters.AddWithValue("@tl", page1Selections[0]);
                cmdDatabase.Parameters.AddWithValue("@tm", page1Selections[1]);
                cmdDatabase.ExecuteNonQuery();
            }
            catch (Exception err) {
                MessageBox.Show("An Error has occurred while writing to the database: " + err.Message);
            }
        }

        /// <summary>
        /// Write to DB for 5 picture boxes
        /// </summary>
        /// <param name="array"></param>
        /// <param name="TLImageName"></param>
        /// <param name="TMImageName"></param>
        /// <param name="TRImageName"></param>
        /// <param name="BLImageName"></param>
        /// <param name="BMImageName"></param>
        private void writeToDB5(string[] array, string TLImageName, string TMImageName, string TRImageName, string BLImageName, string BMImageName, string dbTableName) {

            SqlCommand cmdDatabase;
            const string constring = @"Data Source =(LocalDB)\MSSQLLocalDB;" +
                                    @"AttachDbFilename = |DataDirectory|\CapstoneDB\CapstoneDB.mdf; Integrated Security = True";
            SqlConnection conDatabase = new SqlConnection(constring);
            string query;
            //Determine if a little or a lot
            try {
                conDatabase.Open();
                query = "INSERT INTO dbo." + dbTableName + "(" + TLImageName + "," + TMImageName + "," +
                         TRImageName + "," +
                          BLImageName + "," +
                           BMImageName + ") VALUES (@tl, @tm, @tr, @bl, @bm);";

                cmdDatabase = new SqlCommand(query, conDatabase);
                cmdDatabase.Parameters.AddWithValue("@tl", page1Selections[0]);
                cmdDatabase.Parameters.AddWithValue("@tm", page1Selections[1]);
                cmdDatabase.Parameters.AddWithValue("@tr", page1Selections[2]);
                cmdDatabase.Parameters.AddWithValue("@bl", page1Selections[3]);
                cmdDatabase.Parameters.AddWithValue("@bm", page1Selections[4]);
                cmdDatabase.ExecuteNonQuery();
            }
            catch (Exception err) {
                MessageBox.Show("An Error has occurred while writing to the database: " + err.Message);
            }
        }


        /// <summary>
        /// For 4 images
        /// </summary>
        /// <param name="array"></param>
        /// <param name="TLImageName"></param>
        /// <param name="TMImageName"></param>
        /// <param name="TRImageName"></param>
        /// <param name="BLImageName"></param>
        /// <param name="BMImageName"></param>
        private void writeToDB4(string[] array, string TLImageName, string TMImageName, string TRImageName, string BLImageName, string dbTableName) {

            SqlCommand cmdDatabase;
            const string constring = @"Data Source =(LocalDB)\MSSQLLocalDB;" +
                                    @"AttachDbFilename = |DataDirectory|\CapstoneDB\CapstoneDB.mdf; Integrated Security = True";
            SqlConnection conDatabase = new SqlConnection(constring);
            string query;
            //Determine if a little or a lot
            try {
                conDatabase.Open();
                query = "INSERT INTO dbo." + dbTableName + "(" + TLImageName + "," + TMImageName + "," +
                         TRImageName + "," +
                          BLImageName + ") VALUES (@tl, @tm, @tr, @bl);";

                cmdDatabase = new SqlCommand(query, conDatabase);
                cmdDatabase.Parameters.AddWithValue("@tl", page1Selections[0]);
                cmdDatabase.Parameters.AddWithValue("@tm", page1Selections[1]);
                cmdDatabase.Parameters.AddWithValue("@tr", page1Selections[2]);
                cmdDatabase.Parameters.AddWithValue("@bl", page1Selections[3]);
                cmdDatabase.ExecuteNonQuery();
            }
            catch (Exception err) {
                MessageBox.Show("An Error has occurred while writing to the database: " + err.Message);
            }
        }



        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////// BUTTON CLICKS FOR A LITT AND A LOT ////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void topLeftPBALittleBtn_Click(object sender, EventArgs e) {
            //This will refresh the picture box
            topLeftPB.Invalidate();
            page1Selections[0] = "A Little";

        }
        private void topLeftPBALotBtn_Click(object sender, EventArgs e) {
            //This will refresh the picture box
            topLeftPB.Invalidate();
            page1Selections[0] = "A Lot";
        }
        private void topMidALittleBtn_Click(object sender, EventArgs e) {
            //This will refresh the picture box
            topMidPB.Invalidate();
            page1Selections[1] = "A Little";
        }
        private void topMidALotBtn_Click(object sender, EventArgs e) {
            //This will refresh the picture box
            topMidPB.Invalidate();
            page1Selections[1] = "A Lot";
        }
        private void topRightALittleBtn_Click(object sender, EventArgs e) {
            //This will refresh the picture box
            topRightPB.Invalidate();
            page1Selections[2] = "A Little";
        }
        private void topRightPBALotBtn_Click(object sender, EventArgs e) {
            //This will refresh the picturebox
            topRightPB.Invalidate();
            page1Selections[2] = "A Lot";
        }
        private void bottomLeftALittleBtn_Click(object sender, EventArgs e) {
            //This will refresh the picture box
            bottomLeftPB.Invalidate();
            page1Selections[3] = "A Little";
        }
        private void bottomLeftALotBtn_Click(object sender, EventArgs e) {
            //This will refresh the picture box
            bottomLeftPB.Invalidate();
            page1Selections[3] = "A Lot";
        }
        private void bottomMidALittleBtn_Click(object sender, EventArgs e) {
            //This will refresh the picture box
            bottomMidPB.Invalidate();
            page1Selections[4] = "A Little";
        }
        private void bottomMidALotBtn_Click(object sender, EventArgs e) {
            //This will refresh the picture box
            bottomMidPB.Invalidate();
            page1Selections[4] = "A Lot";
        }
        private void bottomRightALittleBtn_Click(object sender, EventArgs e) {
            //This will refresh the picture box
            bottomRightPB.Invalidate();
            page1Selections[5] = "A Little";
        }
        private void bottomRightALotBtn_Click(object sender, EventArgs e) {
            //This will refresh the picture box
            bottomRightPB.Invalidate();
            page1Selections[5] = "A Lot";
        }

        private void SightColours() {
            picBackground.BackColor = Color.SandyBrown;
            lblQuestion.BackColor = Color.SandyBrown;
            panel1.BackColor = Color.Bisque;
            picSense.Image = new Bitmap(@"..\..\resources\TopLeftInterviewImage(sense)\sight.PNG");
        }

        private void TouchColours() {
            //picturePanel
            picBackground.BackColor = Color.FromArgb(255, 255, 128);
            lblQuestion.BackColor = Color.FromArgb(255, 255, 128);
            panel1.BackColor = Color.LightYellow;
            picSense.Image = new Bitmap(@"..\..\resources\TopLeftInterviewImage(sense)\touch.PNG");
        }

        private void SmellColours() {
            //picturePanel
            picBackground.BackColor = Color.FromArgb(143, 188, 139);
            lblQuestion.BackColor = Color.FromArgb(143, 188, 139);
            panel1.BackColor = Color.Honeydew;
            picSense.Image = new Bitmap(@"..\..\resources\TopLeftInterviewImage(sense)\smell.PNG");

        }

        private void TasteColours() {
            System.Drawing.Color tasteHeader = System.Drawing.ColorTranslator.FromHtml("#C2B4E2");
            System.Drawing.Color tasteBg = System.Drawing.ColorTranslator.FromHtml("#E6E6FA");
            //picturePanel
            picBackground.BackColor = tasteHeader;
            lblQuestion.BackColor = tasteHeader;
            panel1.BackColor = tasteBg;
            picSense.Image = new Bitmap(@"..\..\resources\TopLeftInterviewImage(sense)\taste.PNG");

        }

        private void MovementColours() {
            //picturePanel
            picBackground.BackColor = Color.PaleVioletRed;
            lblQuestion.BackColor = Color.PaleVioletRed;
            panel1.BackColor = Color.Pink;
            picSense.Image = new Bitmap(@"..\..\resources\TopLeftInterviewImage(sense)\movement.PNG");
        }


        private void EnvironmentColours() {
            //picturePanel
            picBackground.BackColor = Color.LightBlue;
            lblQuestion.BackColor = Color.LightBlue;
            panel1.BackColor = Color.AliceBlue;
            //picSense.Image = new Bitmap(@"");

        }

        private void OtherColours() {
            //picturePanel
            picBackground.BackColor = Color.Tan;
            lblQuestion.BackColor = Color.Tan;
            panel1.BackColor = Color.AntiqueWhite;
            //picSense.Image = new Bitmap(@"");
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////// CHANGING INTERVIEW PAGE FUNCATIONALITY ////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// When user clicks on the initial next button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext1_Click_1(object sender, EventArgs e) {
            System.Drawing.Color tasteHeader = System.Drawing.ColorTranslator.FromHtml("#C2B4E2");
            System.Drawing.Color tasteBg = System.Drawing.ColorTranslator.FromHtml("#E6E6FA");
            //appends label to file on a new line
            Globals.interview_page++;
            if (Globals.interview_page == 2) {
                writeToDB(page1Selections, "otherPeopleTalking", "fireworks", "loudVoices",
                                            "householdAppliances", "vehicles", "bathroomAppliances", "dislikeSounds");
                if (m_InstanceRef2 != null) {
                    InstanceRef2.Show();
                }
                else {
                    this.Hide();
                    GuidedInterview interviewForm2 = new GuidedInterview();
                    interviewForm2.InstanceRef = this;
                    interviewForm2.Location = new Point(0, 0);
                    interviewForm2.Show();
                }
            }
            //-------------
            //SOUND SECTION
            //-------------
            else if (Globals.interview_page == 3) {
                //writeToDBTop2(page1Selections, "sirens", "suddenLoudNoises");
                GuidedInterview interviewForm2p2 = new GuidedInterview();
                interviewForm2p2.InstanceRef2 = this;
                interviewForm2p2.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 4) {
                writeToDBTop3(page1Selections, "concentrating", "hardToListenInClassroom", "hardToListenInGroup", "hardToListen");
                GuidedInterview interviewForm3 = new GuidedInterview();
                interviewForm3.InstanceRef3 = this;
                interviewForm3.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 5) {
                writeToDBTop3(page1Selections, "radioOn", "clockTicking", "peopleTalking", "hardToConcentrate");
                GuidedInterview interviewForm4 = new GuidedInterview();
                interviewForm4.InstanceRef4 = this;
                interviewForm4.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 6) {
                writeToDB5(page1Selections, "computerSounds", "liveMusic", "fans", "musicThroughMyPhone", "rhythms", "likeSounds");
                GuidedInterview interviewForm5 = new GuidedInterview();
                interviewForm5.InstanceRef5 = this;
                interviewForm5.Show();
                this.Hide();
            }
            //-------------
            //SIGHT SECTION
            //-------------
            else if (Globals.interview_page == 7) {
                writeToDB4(page1Selections, "hummingOrWhistling", "tappingFeet", "tappingFingers", "clickingPen", "makeALotSounds");
                GuidedInterview sightInterview1 = new GuidedInterview();
                sightInterview1.InstanceRef6 = this;
                sightInterview1.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 8) {
                writeToDB5(page1Selections, "sunlight", "fluorescentLight", "lightAndShadow", "busyPatterns", "classroomLight", "dontLikeToLookAt");
                GuidedInterview sightInterview2 = new GuidedInterview();
                sightInterview2.InstanceRef7 = this;
                sightInterview2.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 9) {
                writeToDBTop3(page1Selections, "lotsOfThingsInAMessyDrawer", "peopleRunningAroundMe", "lotsOfThingsHangingUpInTheClassroom", "sightHardToConcentrate");
                GuidedInterview sightInterview3 = new GuidedInterview();
                sightInterview3.InstanceRef8 = this;
                sightInterview3.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 10) {
                writeToDB5(page1Selections, "movingLights", "thingsThatSparkle", "geometricPatterns", "spinningFans", "spinningObjects", "likeToLookAt");
                GuidedInterview sightInterview4 = new GuidedInterview();
                sightInterview4.InstanceRef9 = this;
                sightInterview4.Show();
                this.Hide();
            }
            //-------------
            //TOUCH SECTION
            //-------------
            else if (Globals.interview_page == 11) {
                writeToDB(page1Selections, "sandy", "sticky", "grassy", "woolClothes", "tightClothes", "stiffClothes", "dontLikeFeelingOf");
                GuidedInterview touchInterview2 = new GuidedInterview();
                touchInterview2.InstanceRef10 = this;
                touchInterview2.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 12) {
                writeToDBTop2(page1Selections, "shoes", "splashingWater", "dontLikeFeelingOf");
                GuidedInterview touchInterview3 = new GuidedInterview();
                touchInterview3.InstanceRef11 = this;
                touchInterview3.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 13) {
                writeToDB(page1Selections, "beingHuggedOrKissed", "beingCrowded", "beingTappedOnTheShoulder", "havingSunscreenPutOn", "beingBumped", "havingAHaircut", "peopleTouchDontLike");
                GuidedInterview touchInterview4 = new GuidedInterview();
                touchInterview4.InstanceRef12 = this;
                touchInterview4.Show();
                this.Hide();
            }
            //-------------
            //SMELL SECTION
            //-------------
            else if (Globals.interview_page == 14) {
                writeToDBTop2(page1Selections, "doctorTouchingMe", "dentistTouchingMe", "peopleTouchDontLike");
                GuidedInterview smellInterview1 = new GuidedInterview();
                smellInterview1.InstanceRef13 = this;
                smellInterview1.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 15) {
                writeToDB(page1Selections, "soft", "rubbery", "furry", "huggingPeople", "touchingPeople", "beingSquashedWithAPillow", "likeTheFeelingOf");
                GuidedInterview smellInterview2 = new GuidedInterview();
                smellInterview2.InstanceRef14 = this;
                smellInterview2.Show();
                this.Hide();
            }
            //-------------
            //TASTE SECTION
            //-------------
            else if (Globals.interview_page == 16) {
                writeToDB5(page1Selections, "smellingFoods", "smellingPlants", "smellingPerfume", "smellingSoap", "smellingPeople", "likeToSmell");
                GuidedInterview tasteInterview1 = new GuidedInterview();
                tasteInterview1.InstanceRef15 = this;
                tasteInterview1.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 17) {
                writeToDB(page1Selections, "vegetables", "fruit", "meat", "fish", "eggs", "dairy", "foodGroupsDontLike");
                GuidedInterview tasteInterview1p2 = new GuidedInterview();
                tasteInterview1p2.InstanceRef16 = this;
                tasteInterview1p2.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 18) {
                writeToDBTop2(page1Selections, "bread", "pasta", "foodGroupsDontLike");
                GuidedInterview tasteInterview2 = new GuidedInterview();
                tasteInterview2.InstanceRef17 = this;
                tasteInterview2.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 19) {
                writeToDB(page1Selections, "lumpy", "chewy", "runnyOrSlippery", "mixed", "sweet", "sour", "tastesOrFeelsInMouthDontLike");
                GuidedInterview tasteInterview3 = new GuidedInterview();
                tasteInterview3.InstanceRef18 = this;
                tasteInterview3.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 20) {

                GuidedInterview tasteInterview4 = new GuidedInterview();
                tasteInterview4.InstanceRef19 = this;
                tasteInterview4.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 21) {
                writeToDBTop3(page1Selections, "shirt", "hair", "objects", "thingsPutInMouthALot");

                GuidedInterview mvmtInterview1 = new GuidedInterview();
                mvmtInterview1.InstanceRef20 = this;
                mvmtInterview1.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 22) {
                writeToDB5(page1Selections, "beingJumpedOnOrTackled", "movingWhenICantSeeWhereIAmGoing", "balancing", "beingUpsideDown", "climbingUpHigh", "movingDontLike");

                GuidedInterview mvmtInterview2 = new GuidedInterview();
                mvmtInterview2.InstanceRef21 = this;
                mvmtInterview2.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 23) {
                writeToDBTop2(page1Selections, "standingStill", "sittingStill", "hardToStayStill");
                this.Hide();
                GuidedInterview mvmtInterview3 = new GuidedInterview();
                mvmtInterview3.InstanceRef22 = this;
                mvmtInterview3.Show();
            }
            else if (Globals.interview_page == 24) {
                writeToDB5(page1Selections, "movingInWater", "swinging", "spinning", "jumpingOnTheTrampoline", "running", "movingThatYouLike");
                GuidedInterview mvmtInterview4 = new GuidedInterview();
                mvmtInterview4.InstanceRef23 = this;
                mvmtInterview4.Show();
                this.Hide();
            }
            //-------------------
            //ENVIRONMENT SECTION
            //-------------------
            else if (Globals.interview_page == 25) {
                writeToDB4(page1Selections, "rocking", "movingHands", "clapping", "pacing", "moveOverAndOverAgain");
                GuidedInterview environmentInterview1 = new GuidedInterview();
                environmentInterview1.InstanceRef24 = this;
                environmentInterview1.Show();
                this.Hide();
            }
            //-------------
            //OTHER SECTION
            //-------------
            else if (Globals.interview_page == 26) {
                writeToDB5(page1Selections, "supermarket", "party", "foodHall", "show", "shoppingMall", "other");
                GuidedInterview otherInterview1 = new GuidedInterview();
                otherInterview1.InstanceRef25 = this;
                otherInterview1.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 27) {
                writeToDB(page1Selections, "sounds", "smells", "sights", "tastes", "feelings", "movements", "other");
                Summary sum = new Summary();
                sum.Show();
            }
        }

        /// <summary>
        /// Previous button functionality
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void previousInterviewSlideBtn_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Your answers for this page will not be saved. Are you sure you want to go back?", "Go to previous page",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes) {
            }
            else {
                return;
            }
            Globals.interview_page--;
            if (Globals.interview_page == 1) {
                this.Hide();
                InstanceRef.Show();
            }
            else if (Globals.interview_page == 2) {
                this.Hide();
                InstanceRef2.Show();
            }
            else if (Globals.interview_page == 3) {
                this.Hide();
                InstanceRef3.Show();
            }
            else if (Globals.interview_page == 4) {
                this.Hide();
                InstanceRef4.Show();
            }
            else if (Globals.interview_page == 5) {
                this.Hide();
                InstanceRef5.Show();
            }
            else if (Globals.interview_page == 6) {
                this.Hide();
                InstanceRef6.Show();
            }
            else if (Globals.interview_page == 7) {
                this.Hide();
                InstanceRef7.Show();
            }
            else if (Globals.interview_page == 8) {
                this.Hide();
                InstanceRef8.Show();
            }
            else if (Globals.interview_page == 9) {
                this.Hide();
                InstanceRef9.Show();
            }
            else if (Globals.interview_page == 10) {
                this.Hide();
                InstanceRef10.Show();
            }
            else if (Globals.interview_page == 11) {
                this.Hide();
                InstanceRef11.Show();
            }
            else if (Globals.interview_page == 12) {
                this.Hide();
                InstanceRef12.Show();
            }
            else if (Globals.interview_page == 13) {
                this.Hide();
                InstanceRef13.Show();
            }
            else if (Globals.interview_page == 14) {
                this.Hide();
                InstanceRef14.Show();
            }
            else if (Globals.interview_page == 15) {
                this.Hide();
                InstanceRef15.Show();
            }
            else if (Globals.interview_page == 16) {
                this.Hide();
                InstanceRef16.Show();
            }
            else if (Globals.interview_page == 17) {
                this.Hide();
                InstanceRef17.Show();
            }
            else if (Globals.interview_page == 18) {
                this.Hide();
                InstanceRef18.Show();
            }
            else if (Globals.interview_page == 19) {
                this.Hide();
                InstanceRef19.Show();
            }
            else if (Globals.interview_page == 20) {
                this.Hide();
                InstanceRef20.Show();
            }
            else if (Globals.interview_page == 21) {
                this.Hide();
                InstanceRef21.Show();
            }
            else if (Globals.interview_page == 22) {
                this.Hide();
                InstanceRef22.Show();
            }
            else if (Globals.interview_page == 23) {
                this.Hide();
                InstanceRef23.Show();
            }
            else if (Globals.interview_page == 24) {
                this.Hide();
                InstanceRef24.Show();
            }
            else if (Globals.interview_page == 25) {
                this.Hide();
                InstanceRef25.Show();
            }
        }

        private void updateLabelText(string TL, string TM, string TR, string BL, string BM, string BR) {
            lblTL.Text = TL;
            lblTM.Text = TM;
            lblTR.Text = TR;
            lblBL.Text = BL;
            lblBM.Text = BM;
            lblBR.Text = BR;
        }

        /// <summary>
        /// Initial Images when user clicks on back button on second interview slide (when nextCounter === 0)
        /// </summary>
        private void interviewPage1() {
            lblQuestion.Text = "Are there some sounds that you don't like?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\1. Hearing\1. Are there some sounds that you don't like_\1 Other People Talking (cropped).png");
            topMidPB.Image = new Bitmap(@"..\..\resources\1. Hearing\1. Are there some sounds that you don't like_\2 Fireworks.jpg");
            topRightPB.Image = new Bitmap(@"..\..\resources\1. Hearing\1. Are there some sounds that you don't like_\3 Loud voices.PNG");
            bottomLeftPB.Image = new Bitmap(@"..\..\resources\1. Hearing\1. Are there some sounds that you don't like_\4 Household appliances (e.g., blenders, vacuum).png");
            bottomMidPB.Image = new Bitmap(@"..\..\resources\1. Hearing\1. Are there some sounds that you don't like_\5 Vehicles (e.g., trucks, motorbikes) (cropped).jpg");
            bottomRightPB.Image = new Bitmap(@"..\..\resources\1. Hearing\1. Are there some sounds that you don't like_\6 Bathroom appliances (e.g., hand dryers, hair dryers) (photoshopped).jpg");
            updateLabelText("Other people talking", " Fireworks", "Loud voices",
                "Household appliances (e.g. blenders, vacuum)", "Vehicles (e.g. trucks, motorbikes)",
                "Bathroom appliances (e.g. hair dryers, hand dryers)");
        }

        private void interviewPage1p2() {
            lblQuestion.Text = "Are there some sounds that you don't like?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\1. Hearing\1. Are there some sounds that you don't like_\7 Sirens, alarms, school bells.jpg");
            topMidPB.Image = new Bitmap(@"..\..\resources\1. Hearing\1. Are there some sounds that you don't like_\8 Sudden loud noises (e.g., balloons popping).jpg");
            //topRightPB.Image = new Bitmap(@"..\..\resources\1. Hearing\1. Are there some sounds that you don't like_\loud_voices.PNG");
            //bottomLeftPB.Image = new Bitmap(@"..\..\resources\1. Hearing\1. Are there some sounds that you don't like_\household_ appliances.PNG");
            // bottomMidPB.Image = new Bitmap(@"..\..\resources\");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\");
            updateLabelText("Sirens, alarms, school bells", "Sudden loud noises (e.g., balloons popping)", "", "", "", "");
        }

        private void interviewPage2() {
            lblQuestion.Text = "Are there times when it is hard for you to listen?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\1. Hearing\2. Are there times when it is hard to listen_\1 If I am concentrating on something, I don't notice people talking to me.png");
            //topMidPB.Image = new Bitmap(@"..\..\resources\1. Hearing\2. Are there times when it is hard to listen_\2 I find it hard to listen in noisy classrooms (self-report version).jpg"); need guided version
            topRightPB.Image = new Bitmap(@"..\..\resources\1. Hearing\2. Are there times when it is hard to listen_\3 I find it hard to listen to someone talking to me when I'm in a group.jpg");
            //bottomLeftPB.Image = new Bitmap(@"..\..\resources\");
            //bottomMidPB.Image = new Bitmap(@"..\..\resources\");
            //bottomRightPB.Image = new Bitmap(@..\..\resources\");
            updateLabelText("If I am concentrating on something, I don't notice people talking to me",
                "I find it hard to listen to the teacher in noisy classrooms",
                "I find it hard to listen to someone talking to me when I'm in a group",
                "",
                "",
                "");
        }

        private void interviewPage3() {
            lblQuestion.Text = "Are there some sounds that make it hard for you to concentrate?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\1. Hearing\3. Are there some sounds that make it hard for you to concentrate_\1 Radio on.jpg");
            topMidPB.Image = new Bitmap(@"..\..\resources\1. Hearing\3. Are there some sounds that make it hard for you to concentrate_\2 Clock ticking.jpg");
            topRightPB.Image = new Bitmap(@"..\..\resources\1. Hearing\3. Are there some sounds that make it hard for you to concentrate_\3 People talking.png");
            //bottomLeftPB.Image = new Bitmap(@"../../resources/");
            //bottomMidPB.Image = new Bitmap(@"../../resources/");
            //bottomRightPB.Image = new Bitmap(@"../../resources/");
            updateLabelText("Radio on", "Clock ticking", "People talking", "", "", "");
        }

        private void interviewPage4() {
            lblQuestion.Text = "Are there some sounds that you like to listen to?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\1. Hearing\4. Are there sounds that you like to listen to_\1 Computer sounds.jpg");
            topMidPB.Image = new Bitmap(@"..\..\resources\1. Hearing\4. Are there sounds that you like to listen to_\2 Live Music.jpg");
            topRightPB.Image = new Bitmap(@"..\..\resources\1. Hearing\4. Are there sounds that you like to listen to_\3 Fans.PNG");
            bottomLeftPB.Image = new Bitmap(@"..\..\resources\1. Hearing\4. Are there sounds that you like to listen to_\4 Music through my phone (cropped).jpg");
            bottomMidPB.Image = new Bitmap(@"..\..\resources\1. Hearing\4. Are there sounds that you like to listen to_\5 Rhythms.jpg");
            //bottomRightPB.Image = new Bitmap(@"../../resources/");
            updateLabelText("Computer sounds", "Live music", "Fans", "Music through my phone", "Rhythms", "");
        }

        private void interviewPage5() {
            lblQuestion.Text = "Are there some sounds that you make a lot?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\1. Hearing\5. Are there some sounds that you make a lot_\1 Humming or Whistling to myself.jpg"); 
            topMidPB.Image = new Bitmap(@"..\..\resources\1. Hearing\5. Are there some sounds that you make a lot_\2 Tapping feet.PNG");
            topRightPB.Image = new Bitmap(@"..\..\resources\1. Hearing\5. Are there some sounds that you make a lot_\3 Tapping fingers.jpg");
            bottomLeftPB.Image = new Bitmap(@"..\..\resources\1. Hearing\5. Are there some sounds that you make a lot_\4 Clicking pen.jpg");
            //bottomMidPB.Image = new Bitmap(@""); 
            //bottomRightPB.Image = new Bitmap(@"../../resources/");
            updateLabelText("Humming or whistling to myself", "Tapping feet", "Tapping fingers", "Clicking pen",
                "", "");
        }

        //Sight Panels

        private void sightInterviewPage1() {
            lblQuestion.Text = "Are there some things that you don't like to look at?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\2. Sight\1. Are there some things that you don't like to look at_\1 Sunlight.jpg");
            topMidPB.Image = new Bitmap(@"..\..\resources\2. Sight\1. Are there some things that you don't like to look at_\2 Fluorescent light.png");
            topRightPB.Image = new Bitmap(@"..\..\resources\2. Sight\1. Are there some things that you don't like to look at_\3 Light and Shadow.jpg");
            bottomLeftPB.Image = new Bitmap(@"..\..\resources\2. Sight\1. Are there some things that you don't like to look at_\4 Busy Patterns.jpg");
            bottomMidPB.Image = new Bitmap(@"..\..\resources\2. Sight\1. Are there some things that you don't like to look at_\5 Classroom light (guided version).jpg");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\2. Sight\1. Are there some things that you don't like to look at_\");
            updateLabelText("Sunlight", "Fluorescent light", "Light and shadow", "Busy patterns",
                "Classroom Light", "");
        }

        private void sightInterviewPage2() {
            lblQuestion.Text = "Are there some things you see that make it hard to concentrate?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\2. Sight\2. Are there some things you see that make it hard to concentrate_\1 Lots of things in a messy drawer.jpg");
            topMidPB.Image = new Bitmap(@"..\..\resources\2. Sight\2. Are there some things you see that make it hard to concentrate_\2 People running around me.jpg");
            topRightPB.Image = new Bitmap(@"..\..\resources\2. Sight\2. Are there some things you see that make it hard to concentrate_\3 Lots of things hanging up in the classroom (guided).png");
            // bottomLeftPB.Image = new Bitmap(@"..\..\resources\2. Sight\1. Are there some things that you don't like to look at_\");
            //bottomMidPB.Image = new Bitmap(@"..\..\resources\2. Sight\1. Are there some things that you don't like to look at_\");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\2. Sight\1. Are there some things that you don't like to look at_\");
            updateLabelText("Lots of things in a messy drawer", "People running around me", "Lots of things hanging up in the classroom", "",
                "", "");
        }

        private void sightInterviewPage3() {
            lblQuestion.Text = "Are there some things that you like to look at?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\2. Sight\3. Are there some things that you like to look at_\1 Moving lights.jpg");
            topMidPB.Image = new Bitmap(@"..\..\resources\2. Sight\3. Are there some things that you like to look at_\2 Things that sparkle.png");
            topRightPB.Image = new Bitmap(@"..\..\resources\2. Sight\3. Are there some things that you like to look at_\3 Geometric patterns.jpg");
            bottomLeftPB.Image = new Bitmap(@"..\..\resources\2. Sight\3. Are there some things that you like to look at_\4 Spinning fans.png");
            bottomMidPB.Image = new Bitmap(@"..\..\resources\2. Sight\3. Are there some things that you like to look at_\5 Spinning objects1 (use this one) (cropped).jpg");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\2. Sight\3. Are there some things that you don't like to look at_\");
            updateLabelText("Moving lights", "Things that sparkle", "Geometric patterns", "Spinning fans",
                "Spinning objects", "");
        }

        //Touch Panels
        private void touchInterviewPage1() {
            lblQuestion.Text = "Are there some things that you don't like the feeling of?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\1 Sandy.jpg");
            topMidPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\2 Sticky.jpg");
            topRightPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\3 Grassy.jpg");
            bottomLeftPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\4 Wool clothes.jpg");
            bottomMidPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\5 Tight clothes.jpg");
            bottomRightPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\6 Stiff clothes.jpg");
            updateLabelText("Sandy", "Sticky", "Grassy", "Wool clothes",
                "Tight clothes", "Stiff clothes");
        }

        private void touchInterviewPage1p2() {
            lblQuestion.Text = "Are there some things that you don't like the feeling of?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\7 Shoes.jpg");
            topMidPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\8 Splashing Water (cropped).jpg");
            //topRightPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\Geometric patterns.jpg");
            //bottomLeftPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\.jpg");
            //bottomMidPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\Spinning objects.jpg");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\");
            updateLabelText("Shoes", "Splashing water (e.g. rain, shower, pool)", "", "",
                "", "");
        }

        private void touchInterviewPage2() {
            lblQuestion.Text = "Are there some ways that people touch you that you don't like?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\3. Touch\2. Are there ways that people touch you that you don't like_\1 Being hugged or kissed (cropped).jpg");
            topMidPB.Image = new Bitmap(@"..\..\resources\3. Touch\2. Are there ways that people touch you that you don't like_\2 Being crowded (cropped).jpg");
            topRightPB.Image = new Bitmap(@"..\..\resources\3. Touch\2. Are there ways that people touch you that you don't like_\3 Being tapped on the shoulder (guided).jpg");
            bottomLeftPB.Image = new Bitmap(@"..\..\resources\3. Touch\2. Are there ways that people touch you that you don't like_\4 Having sunscreen put on.jpg");
            bottomMidPB.Image = new Bitmap(@"..\..\resources\3. Touch\2. Are there ways that people touch you that you don't like_\5 Being bumped.jpg");
            bottomRightPB.Image = new Bitmap(@"..\..\resources\3. Touch\2. Are there ways that people touch you that you don't like_\6 Having a haircut (cropped).jpg");
            updateLabelText("Being hugged or kissed", "Being crowded", "Being tapped on the shoulder", "Having sunscreen put on",
                "Being bumped", "Having a haircut");
        }

        private void touchInterviewPage2p2() {
            lblQuestion.Text = "Are there some ways that people touch you that you don't like?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\3. Touch\2. Are there ways that people touch you that you don't like_\7 Doctor touching me.jpg");
            topMidPB.Image = new Bitmap(@"..\..\resources\3. Touch\2. Are there ways that people touch you that you don't like_\8 Dentist touching me (cropped).jpg");
            //topRightPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there things that you don't like the feeling of_\Geometric patterns.jpg");
            //bottomLeftPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there things that you don't like the feeling of_\.jpg");
            //bottomMidPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there things that you don't like the feeling of_\Spinning objects.jpg");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there things that you don't like the feeling of_\");
            updateLabelText("Doctor touching me", "Dentist touch me", "", "",
                "", "");
        }

        private void touchInterviewPage3() {
            lblQuestion.Text = "Are there some things that you like the feeling of?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\3. Touch\3. Are there some things that you like the feeling of_\1 Soft.jpg");
            topMidPB.Image = new Bitmap(@"..\..\resources\3. Touch\3. Are there some things that you like the feeling of_\2 Rubbery.jpg");
            topRightPB.Image = new Bitmap(@"..\..\resources\3. Touch\3. Are there some things that you like the feeling of_\3 Furry.jpg");
            bottomLeftPB.Image = new Bitmap(@"..\..\resources\3. Touch\3. Are there some things that you like the feeling of_\4 Hugging people.jpg");
            bottomMidPB.Image = new Bitmap(@"..\..\resources\3. Touch\3. Are there some things that you like the feeling of_\5 Touching people.jpg");
            bottomRightPB.Image = new Bitmap(@"..\..\resources\3. Touch\3. Are there some things that you like the feeling of_\6 Being squashed with a pillow.jpg");
            updateLabelText("Soft", "Rubbery", "Furry", "Hugging people",
                "Touching people", "Being squashed with a pillow");
        }

        //TODO - Smells
        private void smellInterviewPage1() {
            lblQuestion.Text = "Are there some smells that you don't like?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\4. Smells\1. Are there some smells that you don't like_\1 Cooking smells (cropped).jpg");
            topMidPB.Image = new Bitmap(@"..\..\resources\4. Smells\1. Are there some smells that you don't like_\2 Food Smells.jpg");
            topRightPB.Image = new Bitmap(@"..\..\resources\4. Smells\1. Are there some smells that you don't like_\3 Cleaning products.jpg");
            bottomLeftPB.Image = new Bitmap(@"..\..\resources\4. Smells\1. Are there some smells that you don't like_\4 Toilet Smells.jpg");
            bottomMidPB.Image = new Bitmap(@"..\..\resources\4. Smells\1. Are there some smells that you don't like_\5 Perfumes.jpg");
            bottomRightPB.Image = new Bitmap(@"..\..\resources\4. Smells\1. Are there some smells that you don't like_\6 Body smells (cropped).jpg");
            updateLabelText("Cooking smells", "Food smells", "Cleaning products",
                "Toilet smells", "Perfumes", "Body smells");
        }

        private void smellInterviewPage2() {
            lblQuestion.Text = "Are there some things that you like to smell?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\4. Smells\2. Are there some things that you like to smell_\1 Smelling foods (cropped).jpg");
            topMidPB.Image = new Bitmap(@"..\..\resources\4. Smells\2. Are there some things that you like to smell_\2 Smelling plants.jpg");
            topRightPB.Image = new Bitmap(@"..\..\resources\4. Smells\2. Are there some things that you like to smell_\3 Smelling perfume.jpg");
            bottomLeftPB.Image = new Bitmap(@"..\..\resources\4. Smells\2. Are there some things that you like to smell_\4 Smelling soap.jpg");
            bottomMidPB.Image = new Bitmap(@"..\..\resources\4. Smells\2. Are there some things that you like to smell_\5 Smelling people.jpg");
            //bottomRightPB.Image = new Bitmap(@"..\..resources\4. Smells\2. Are there some things that you like to smell_\5 Smelling people.jpg");
            updateLabelText("Smelling foods", "Smelling plants", "Smelling perfume",
                "Smelling soap", "Smelling people", "");
        }
        //TODO - Taste
        private void tasteInterviewPage1() {
            lblQuestion.Text = "Are there some food groups that you don't like eating?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\1 Vegetables.png");
            topMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\2 Fruit.png");
            topRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\3 Meat.jpg");
            bottomLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\4 Fish.jpg");
            bottomMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\5 Eggs.jpg");
            bottomRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\6 Dairy.png");
            updateLabelText("Vegetables", "Fruit", "Meat", "Fish", "Eggs", "Dairy");
        }

        private void tasteInterviewPage1p2() {
            lblQuestion.Text = "Are there some food groups that you don't like eating?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\7 Bread.jpg");
            topMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\8 Pasta.jpg");
            //topRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some that you don't like_\Geometric patterns.jpg");
            //bottomLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Fish.jpg");
            //bottomMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some that you don't like_\Spinning objects.jpg");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Dairy.jpg");
            updateLabelText("Bread", "Pasta", "", "", "", "");
        }
        private void tasteInterviewPage2() {
            lblQuestion.Text = "Are there some ways that food tastes or feels in your mouth that you don't like?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\2. Are there some ways that food tastes or feels in your mouth that you don't like_\1 Lumpy.jpg");
            topMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\2. Are there some ways that food tastes or feels in your mouth that you don't like_\2 Chewy.jpg");
            topRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\2. Are there some ways that food tastes or feels in your mouth that you don't like_\3 Runny slippery (cropped).jpg");
            bottomLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\2. Are there some ways that food tastes or feels in your mouth that you don't like_\4 Mixed.JPG");
            bottomMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\2. Are there some ways that food tastes or feels in your mouth that you don't like_\5 Sweet.jpg");
            bottomRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\2. Are there some ways that food tastes or feels in your mouth that you don't like_\6 Sour.png");
            updateLabelText("Lumpy", "Chewy", "Runny/Slippery", "Mixed", "Sweet", "Sour");
        }
        private void tasteInterviewPage2p2() {
            lblQuestion.Text = "Are there some ways that food tastes or feels in your mouth that you don't like?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\2. Are there some ways that food tastes or feels in your mouth that you don't like_\7 Salty (cropped).jpg");
            topMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\2. Are there some ways that food tastes or feels in your mouth that you don't like_\8 Spicy.jpg");
            //topRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some that you don't like_\Geometric patterns.jpg");
            //bottomLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Fish.jpg");
            //bottomMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some that you don't like_\Spinning objects.jpg");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Dairy.jpg");
            updateLabelText("Salty", "Spicy", "", "", "", "");
        }
        private void tasteInterviewPage3() {
            lblQuestion.Text = "Are there some things that you really like to eat?";
            //topLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\lumpy.jpg");
            //topMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Pasta.jpg");
            //topRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some that you don't like_\Geometric patterns.jpg");
            //bottomLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Fish.jpg");
            //bottomMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some that you don't like_\Spinning objects.jpg");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Dairy.jpg");
            updateLabelText("This form is structured", "different to other forms", "", "", "", "");
        }
        private void tasteInterviewPage4() {
            lblQuestion.Text = "Are there some things that you put in your mouth a lot?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\4. Are there some things that you put in your mouth a lot_\1 Shirt.jpg");
            topMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\4. Are there some things that you put in your mouth a lot_\2 Hair.jpg");
            topRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\4. Are there some things that you put in your mouth a lot_\3 Objects.jpg");
            //bottomLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Fish.jpg");
            //bottomMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some that you don't like_\Spinning objects.jpg");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Dairy.jpg");
            updateLabelText("Shirt", "Hair", "Objects", "", "", "");
        }
        private void mvmtInterviewPage1() {
            lblQuestion.Text = "Are there some ways of moving that you don't like?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\6. Movement\1. Are there some ways of moving that you don’t like_\1 Being jumped on_tackled.jpg");
            topMidPB.Image = new Bitmap(@"..\..\resources\6. Movement\1. Are there some ways of moving that you don’t like_\2 Moving when I can't see where I am going (guided).jpg");
            topRightPB.Image = new Bitmap(@"..\..\resources\6. Movement\1. Are there some ways of moving that you don’t like_\3 Balancing (guided).jpg");
            bottomLeftPB.Image = new Bitmap(@"..\..\resources\6. Movement\1. Are there some ways of moving that you don’t like_\4 Being upside down (cropped).jpg");
            bottomMidPB.Image = new Bitmap(@"..\..\resources\6. Movement\1. Are there some ways of moving that you don’t like_\5 Climbing up high (cropped).jpg");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Dairy.jpg");
            updateLabelText("Being jumped on/tackled", "Moving when I can't see where I am going", "Balancing", "Being upside down", "Climbing up high", "");
        }
        private void mvmtInterviewPage2() {
            lblQuestion.Text = "Are there times when it is hard for you to stay still?";
            //topLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\lumpy.jpg");
            topMidPB.Image = new Bitmap(@"..\..\resources\6. Movement\2. Are there times when it is hard for you to stay still_\1 Sitting Still (guided).jpg");
            //topRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some that you don't like_\Geometric patterns.jpg");
            //bottomLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Fish.jpg");
            bottomMidPB.Image = new Bitmap(@"..\..\resources\6. Movement\2. Are there times when it is hard for you to stay still_\2 Standing still (guided).jpg");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Dairy.jpg");
            updateLabelText("", "Sitting Still", "", "", "Standing still", "");
        }
        private void mvmtInterviewPage3() {
            lblQuestion.Text = "Are there some ways of moving that you like?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\6. Movement\3. Are there ways of moving that you like_\1 Moving in Water.jpg");
            topMidPB.Image = new Bitmap(@"..\..\resources\6. Movement\3. Are there ways of moving that you like_\2 Swinging (cropped).jpg");
            topRightPB.Image = new Bitmap(@"..\..\resources\6. Movement\3. Are there ways of moving that you like_\3 Spinning (guided).jpg");
            bottomLeftPB.Image = new Bitmap(@"..\..\resources\6. Movement\3. Are there ways of moving that you like_\4 Jumping on the Trampoline (guided and self report) (cropped).jpg");
            bottomMidPB.Image = new Bitmap(@"..\..\resources\6. Movement\3. Are there ways of moving that you like_\5 Running (guided) (cropped).jpg");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Dairy.jpg");
            updateLabelText("Moving in water", "Swinging", "Spinning", "Jumping on the trampoline", "Running", "");
        }
        private void mvmtInterviewPage4() {
            lblQuestion.Text = "Are there some ways that you move over and over again?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\6. Movement\4. Are there some ways that you move over and over again_\1 Rocking.png");
            topMidPB.Image = new Bitmap(@"..\..\resources\6. Movement\4. Are there some ways that you move over and over again_\2 Moving hands.jpg");
            topRightPB.Image = new Bitmap(@"..\..\resources\6. Movement\4. Are there some ways that you move over and over again_\3 Clapping.jpg");
            bottomLeftPB.Image = new Bitmap(@"..\..\resources\6. Movement\4. Are there some ways that you move over and over again_\4 Pacing.PNG");
            //bottomMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some that you don't like_\Spinning objects.jpg");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Dairy.jpg");
            updateLabelText("Rocking", "Moving hands", "Clapping", "Pacing", "", "");
        }
        private void environmentInterviewPage1() {
            lblQuestion.Text = "Are there some places with lots of things happening at once that you don't like?";
            //----------File path too long-----------
            topLeftPB.Image = new Bitmap(@"..\..\resources\7. Environment\1. Are there\1 Supermarket.png");
            //topMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Pasta.jpg");
            topRightPB.Image = new Bitmap(@"..\..\resources\7. Environment\1. Are there\3 Food Hall.jpg");
            bottomLeftPB.Image = new Bitmap(@"..\..\resources\7. Environment\1. Are there\4 Show (cropped).jpg");
            bottomMidPB.Image = new Bitmap(@"..\..\resources\7. Environment\1. Are there\5 Shopping mall.png");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Dairy.jpg");
            updateLabelText("Supermarket", "Party", "Food hall", "Show", "Shopping mall", "");
        }
        private void otherInterviewPage1() {
            lblQuestion.Text = "Are there any other sensations that you feel strongly about?";
            //topLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\lumpy.jpg");
            //topMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Pasta.jpg");
            //topRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some that you don't like_\Geometric patterns.jpg");
            //bottomLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Fish.jpg");
            //bottomMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some that you don't like_\Spinning objects.jpg");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Dairy.jpg");
            updateLabelText("Sounds", "Smells", "Sights", "Tastes", "Feelings", "Movements");
        }


        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////// Panel Clicking ////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void hideButtons() {
            topLeftPBALittleBtn.Visible = false;
            topLeftPBALotBtn.Visible = false;
            topMidALittleBtn.Visible = false;
            topMidALotBtn.Visible = false;
            topRightALittleBtn.Visible = false;
            topRightALotBtn.Visible = false;
            bottomLeftALittleBtn.Visible = false;
            bottomLeftALotBtn.Visible = false;
            bottomMidALittleBtn.Visible = false;
            bottomMidALotBtn.Visible = false;
            bottomRightALittleBtn.Visible = false;
            bottomRightALotBtn.Visible = false;

            /*foreach(var pb in this.Controls.OfType<Button>()) {
                pb.Visible = false;
            }*/
            btnNext1.Visible = true;

        }

        private void displayButtons(Button buttonName, Button buttonName2) {
            buttonName.Visible = true;
            buttonName2.Visible = true;
        }

        private void topLeftPB_Click(object sender, EventArgs e) {
            hideButtons();
            displayButtons(topLeftPBALittleBtn, topLeftPBALotBtn);
        }
        private void topMidPB_Click(object sender, EventArgs e) {
            hideButtons();
            displayButtons(topMidALittleBtn, topMidALotBtn);
        }
        private void topRightPB_Click(object sender, EventArgs e) {
            hideButtons();
            displayButtons(topRightALittleBtn, topRightALotBtn);
        }
        private void bottomLeftPB_Click(object sender, EventArgs e) {
            hideButtons();
            displayButtons(bottomLeftALittleBtn, bottomLeftALotBtn);
        }
        private void bottomMidPB_Click(object sender, EventArgs e) {
            hideButtons();
            displayButtons(bottomMidALittleBtn, bottomMidALotBtn);
        }
        private void bottomRightPB_Click(object sender, EventArgs e) {
            hideButtons();
            displayButtons(bottomRightALittleBtn, bottomRightALotBtn);
        }

        private Form m_InstanceRef = null;
        public Form InstanceRef {
            get { return m_InstanceRef; }
            set { m_InstanceRef = value; }
        }

        private Form m_InstanceRef2 = null;
        public Form InstanceRef2 {
            get { return m_InstanceRef2; }
            set { m_InstanceRef2 = value; }
        }

        private Form m_InstanceRef3 = null;
        public Form InstanceRef3 {
            get { return m_InstanceRef3; }
            set { m_InstanceRef3 = value; }
        }

        private Form m_InstanceRef4 = null;
        public Form InstanceRef4 {
            get { return m_InstanceRef4; }
            set { m_InstanceRef4 = value; }
        }

        private Form m_InstanceRef5 = null;
        public Form InstanceRef5 {
            get { return m_InstanceRef5; }
            set { m_InstanceRef5 = value; }
        }

        private Form m_InstanceRef6 = null;
        public Form InstanceRef6 {
            get { return m_InstanceRef6; }
            set { m_InstanceRef6 = value; }
        }

        private Form m_InstanceRef7 = null;
        public Form InstanceRef7 {
            get { return m_InstanceRef7; }
            set { m_InstanceRef7 = value; }
        }

        private Form m_InstanceRef8 = null;
        public Form InstanceRef8 {
            get { return m_InstanceRef8; }
            set { m_InstanceRef8 = value; }
        }

        private Form m_InstanceRef9 = null;
        public Form InstanceRef9 {
            get { return m_InstanceRef9; }
            set { m_InstanceRef9 = value; }
        }

        private Form m_InstanceRef10 = null;
        public Form InstanceRef10 {
            get { return m_InstanceRef10; }
            set { m_InstanceRef10 = value; }
        }

        private Form m_InstanceRef11 = null;
        public Form InstanceRef11 {
            get { return m_InstanceRef11; }
            set { m_InstanceRef11 = value; }
        }

        private Form m_InstanceRef12 = null;
        public Form InstanceRef12 {
            get { return m_InstanceRef12; }
            set { m_InstanceRef12 = value; }
        }

        private Form m_InstanceRef13 = null;
        public Form InstanceRef13 {
            get { return m_InstanceRef13; }
            set { m_InstanceRef13 = value; }
        }

        private Form m_InstanceRef14 = null;
        public Form InstanceRef14 {
            get { return m_InstanceRef14; }
            set { m_InstanceRef14 = value; }
        }

        private Form m_InstanceRef15 = null;
        public Form InstanceRef15 {
            get { return m_InstanceRef15; }
            set { m_InstanceRef15 = value; }
        }

        private Form m_InstanceRef16 = null;
        public Form InstanceRef16 {
            get { return m_InstanceRef16; }
            set { m_InstanceRef16 = value; }
        }
        private Form m_InstanceRef17 = null;
        public Form InstanceRef17 {
            get { return m_InstanceRef17; }
            set { m_InstanceRef17 = value; }
        }
        private Form m_InstanceRef18 = null;
        public Form InstanceRef18 {
            get { return m_InstanceRef18; }
            set { m_InstanceRef18 = value; }
        }
        private Form m_InstanceRef19 = null;
        public Form InstanceRef19 {
            get { return m_InstanceRef19; }
            set { m_InstanceRef19 = value; }
        }
        private Form m_InstanceRef20 = null;
        public Form InstanceRef20 {
            get { return m_InstanceRef20; }
            set { m_InstanceRef20 = value; }
        }
        private Form m_InstanceRef21 = null;
        public Form InstanceRef21 {
            get { return m_InstanceRef21; }
            set { m_InstanceRef21 = value; }
        }
        private Form m_InstanceRef22 = null;
        public Form InstanceRef22 {
            get { return m_InstanceRef22; }
            set { m_InstanceRef22 = value; }
        }
        private Form m_InstanceRef23 = null;
        public Form InstanceRef23 {
            get { return m_InstanceRef23; }
            set { m_InstanceRef23 = value; }
        }
        private Form m_InstanceRef24 = null;
        public Form InstanceRef24 {
            get { return m_InstanceRef24; }
            set { m_InstanceRef24 = value; }
        }
        private Form m_InstanceRef25 = null;
        public Form InstanceRef25 {
            get { return m_InstanceRef25; }
            set { m_InstanceRef25 = value; }
        }
    }
}
