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

namespace Login {
    public partial class Interview : Form {
        public Interview() {
            InitializeComponent();
            this.Location = new Point(0, 0);
            //label2.Text = Globals.interview_page.ToString();
            //Dynamically create the circular picture boxes
            createCirclePB(bottomLeftPB);
            createCirclePB(bottomRightPB);
            createCirclePB(bottomMidPB);
            createCirclePB(topLeftPB);
            createCirclePB(topRightPB);
            createCirclePB(topMidPB);

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
                interviewPage2();
            }
            else if (Globals.interview_page == 3) {
                interviewPage3();
            }
            else if (Globals.interview_page == 4) {
                interviewPage4();
            }
            else if (Globals.interview_page == 5) {
                interviewPage5();
            } else if (Globals.interview_page == 6) {
                sightInterviewPage1();
            } else if (Globals.interview_page == 7) {
                sightInterviewPage2();
            } else if (Globals.interview_page == 8) {
                sightInterviewPage3();
            } else if (Globals.interview_page == 9) {
                touchInterviewPage1();
            } else if (Globals.interview_page == 10) {
                touchInterviewPage1p2();
            } else if (Globals.interview_page == 11) {
                touchInterviewPage2();
            } else if (Globals.interview_page == 12) {
                touchInterviewPage3();
            } else if (Globals.interview_page == 13) {
                smellInterviewPage1();
            } else if (Globals.interview_page == 14) {
                smellInterviewPage2();
            } else if (Globals.interview_page == 15) {
                tasteInterviewPage1();
            } else if (Globals.interview_page == 16) {
                tasteInterviewPage1p2();
            }
        }

        //Pen variables to draw
        private Pen aLittle = new Pen(Color.Black, 15);
        private Pen aLot = new Pen(Color.Black, 30);
          //Extra variables
          //Extra variables
        private int nextCounter = 0;

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
            if (page1Selections[index] == 1) {
                DrawCircle(aLittle, e, x, y, width, height);
            } else if (page1Selections[index] == 2) {
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
        int[] page1Selections = new int[6] {0,0,0,0,0,0};
        //Instaniate new summary objects
        Summary summary = new Summary();
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////// BUTTON CLICKS FOR A LITT AND A LOT ////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void topLeftPBALittleBtn_Click(object sender, EventArgs e) {
            //This will refresh the picture box
            topLeftPB.Invalidate();
            page1Selections[0] = 1;
            //this is just to show the array being updated -- can remove after testing
            label1.Text = string.Join(", ", page1Selections);
            //Update label
            summary.LabelText = "Top Left A Little";
            summary.Show();
        }

        private void topLeftPBALotBtn_Click(object sender, EventArgs e) {
            //This will refresh the picture box
            topLeftPB.Invalidate();
            page1Selections[0] = 2;
            label1.Text = string.Join(", ", page1Selections);
            summary.LabelText = "Top Left A Lot";
        }

        private void topMidALittleBtn_Click(object sender, EventArgs e) {
            //This will refresh the picture box
            topMidPB.Invalidate();
            page1Selections[1] = 1;
            label1.Text = string.Join(", ", page1Selections);
        }

        private void topMidALotBtn_Click(object sender, EventArgs e) {
            //This will refresh the picture box
            topMidPB.Invalidate();
            page1Selections[1] = 2;
            label1.Text = string.Join(", ", page1Selections);
        }

        private void topRightALittleBtn_Click(object sender, EventArgs e) {
            //This will refresh the picture box
            topRightPB.Invalidate();
            page1Selections[2] = 1;
            label1.Text = string.Join(", ", page1Selections);
        }

        private void topRightPBALotBtn_Click(object sender, EventArgs e) {
            //This will refresh the picturebox
            topRightPB.Invalidate();
            page1Selections[2] = 2;
            label1.Text = string.Join(", ", page1Selections);
        }

        private void bottomLeftALittleBtn_Click(object sender, EventArgs e) {
            //This will refresh the picture box
            bottomLeftPB.Invalidate();
            page1Selections[3] = 1;
            label1.Text = string.Join(", ", page1Selections);
        }

        private void bottomLeftALotBtn_Click(object sender, EventArgs e) {
            //This will refresh the picture box
            bottomLeftPB.Invalidate();
            page1Selections[3] = 2;
            label1.Text = string.Join(", ", page1Selections);
        }

        private void bottomMidALittleBtn_Click(object sender, EventArgs e) {
            //This will refresh the picture box
            bottomMidPB.Invalidate();
            page1Selections[4] = 1;
            label1.Text = string.Join(", ", page1Selections);
        }

        private void bottomMidALotBtn_Click(object sender, EventArgs e) {
            //This will refresh the picture box
            bottomMidPB.Invalidate();
            page1Selections[4] = 2;
            label1.Text = string.Join(", ", page1Selections);
        }

        private void bottomRightALittleBtn_Click(object sender, EventArgs e) {
            //This will refresh the picture box
            bottomRightPB.Invalidate();
            page1Selections[5] = 1;
            label1.Text = string.Join(", ", page1Selections);
        }

        private void bottomRightALotBtn_Click(object sender, EventArgs e) {
            //This will refresh the picture box
            bottomRightPB.Invalidate();
            page1Selections[5] = 2;
            label1.Text = string.Join(", ", page1Selections);
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
            //appends label to file on a new line
            File.AppendAllText(@"c:\test\test.txt", label1.Text + Environment.NewLine);
            Globals.interview_page++;
            if (Globals.interview_page == 2) {
                if (m_InstanceRef2 != null) {
                    InstanceRef2.Show();
                }
                else {
                    this.Hide();
                    Interview interviewForm2 = new Interview();
                    interviewForm2.InstanceRef = this;
                    interviewForm2.Location = new Point(0, 0);
                    interviewForm2.Show();
                }
            }
            else if (Globals.interview_page == 3) {
                this.Hide();
                Interview interviewForm3 = new Interview();
                interviewForm3.InstanceRef2 = this;
                interviewForm3.Location = new Point(0, 0);
                interviewForm3.Show();
            }
            else if (Globals.interview_page == 4) {
                this.Hide();
                Interview interviewForm4 = new Interview();
                interviewForm4.InstanceRef3 = this;
                interviewForm4.Location = new Point(0, 0);
                interviewForm4.Show();
            }
            else if (Globals.interview_page == 5) {
                this.Hide();
                Interview interviewForm5 = new Interview();
                interviewForm5.InstanceRef4 = this;
                interviewForm5.Location = new Point(0, 0);
                interviewForm5.Show();
            } else if (Globals.interview_page == 6) {
                this.Hide();
                Interview sightInterview1 = new Interview();
                sightInterview1.InstanceRef5 = this;
                sightInterview1.Location = new Point(0, 0);
                sightInterview1.picBackground.BackColor = Color.Tomato;
                sightInterview1.panel1.BackColor = Color.LightSalmon;
                sightInterview1.Show();
            } else if (Globals.interview_page == 7) {
                this.Hide();
                Interview sightInterview2 = new Interview();
                sightInterview2.InstanceRef6 = this;
                sightInterview2.Location = new Point(0, 0);
                sightInterview2.picBackground.BackColor = Color.Tomato;
                sightInterview2.panel1.BackColor = Color.LightSalmon;
                sightInterview2.Show();
            } else if (Globals.interview_page == 8) {
                this.Hide();
                Interview sightInterview3 = new Interview();
                sightInterview3.InstanceRef7 = this;
                sightInterview3.Location = new Point(0, 0);
                sightInterview3.picBackground.BackColor = Color.Tomato;
                sightInterview3.panel1.BackColor = Color.LightSalmon;
                sightInterview3.Show();
            } else if (Globals.interview_page == 9) {
                this.Hide();
                Interview touchInterview1 = new Interview();
                touchInterview1.InstanceRef8 = this;
                touchInterview1.Location = new Point(0, 0);
                touchInterview1.picBackground.BackColor = Color.Yellow;
                touchInterview1.panel1.BackColor = Color.LightYellow;
                touchInterview1.Show();
            } else if (Globals.interview_page == 10) {
                this.Hide();
                Interview touchInterview1p2 = new Interview();
                touchInterview1p2.InstanceRef9 = this;
                touchInterview1p2.Location = new Point(0, 0);
                touchInterview1p2.picBackground.BackColor = Color.Yellow;
                touchInterview1p2.panel1.BackColor = Color.LightYellow;
                touchInterview1p2.Show();
            } else if (Globals.interview_page == 11) {
                this.Hide();
                Interview touchInterview2 = new Interview();
                touchInterview2.InstanceRef10 = this;
                touchInterview2.Location = new Point(0, 0);
                touchInterview2.picBackground.BackColor = Color.Yellow;
                touchInterview2.panel1.BackColor = Color.LightYellow;
                touchInterview2.Show();
            } else if (Globals.interview_page == 12) {
                this.Hide();
                Interview touchInterview3 = new Interview();
                touchInterview3.InstanceRef11 = this;
                touchInterview3.Location = new Point(0, 0);
                touchInterview3.picBackground.BackColor = Color.Yellow;
                touchInterview3.panel1.BackColor = Color.LightYellow;
                touchInterview3.Show();
            } else if (Globals.interview_page == 13) {
                this.Hide();
                Interview smellInterview1 = new Interview();
                smellInterview1.InstanceRef12 = this;
                smellInterview1.Location = new Point(0, 0);
                smellInterview1.picBackground.BackColor = Color.OliveDrab;
                smellInterview1.panel1.BackColor = Color.PaleGreen;
                smellInterview1.Show();
            } else if (Globals.interview_page == 14) {
                this.Hide();
                Interview smellInterview2 = new Interview();
                smellInterview2.InstanceRef13 = this;
                smellInterview2.Location = new Point(0, 0);
                smellInterview2.picBackground.BackColor = Color.OliveDrab;
                smellInterview2.panel1.BackColor = Color.PaleGreen;
                smellInterview2.Show();
            } else if (Globals.interview_page == 15) {
                this.Hide();
                Interview tasteInterview1 = new Interview();
                tasteInterview1.InstanceRef14 = this;
                tasteInterview1.Location = new Point(0, 0);
                tasteInterview1.picBackground.BackColor = Color.OliveDrab;
                tasteInterview1.panel1.BackColor = Color.PaleGreen;
                tasteInterview1.Show();
            } else if (Globals.interview_page == 16) {
                this.Hide();
                Interview tasteInterview2 = new Interview();
                tasteInterview2.InstanceRef15 = this;
                tasteInterview2.Location = new Point(0, 0);
                tasteInterview2.picBackground.BackColor = Color.OliveDrab;
                tasteInterview2.panel1.BackColor = Color.PaleGreen;
                tasteInterview2.Show();
            }




        }

        /// <summary>
        /// Previous button functionality
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void previousInterviewSlideBtn_Click(object sender, EventArgs e) {
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
            } else if (Globals.interview_page == 6) {
                this.Hide();
                InstanceRef6.Show();
            } else if (Globals.interview_page == 7) {
                this.Hide();
                InstanceRef7.Show();
            } else if (Globals.interview_page == 8) {
                this.Hide();
                InstanceRef8.Show();
            } else if (Globals.interview_page == 9) {
                this.Hide();
                InstanceRef9.Show();
            } else if (Globals.interview_page == 10) {
                this.Hide();
                InstanceRef10.Show();
            } else if (Globals.interview_page == 11) {
                this.Hide();
                InstanceRef11.Show();
            } else if (Globals.interview_page == 12) {
                this.Hide();
                InstanceRef12.Show();
            } else if (Globals.interview_page == 13) {
                this.Hide();
                InstanceRef13.Show();
            } else if (Globals.interview_page == 14) {
                this.Hide();
                InstanceRef14.Show();
            } else if (Globals.interview_page == 15) {
                this.Hide();
                InstanceRef15.Show();
            } else if (Globals.interview_page == 16) {
                this.Hide();
                InstanceRef16.Show();
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
            //topLeftPB.Image = new Bitmap(@"..\..\resources\");
            topMidPB.Image = new Bitmap(@"..\..\resources\1. Hearing\1. Are there some sounds that you don't like_\fireworks.jpg");
            topRightPB.Image = new Bitmap(@"..\..\resources\1. Hearing\1. Are there some sounds that you don't like_\loud_voices.PNG");
            bottomLeftPB.Image = new Bitmap(@"..\..\resources\1. Hearing\1. Are there some sounds that you don't like_\household_ appliances.PNG");
           // bottomMidPB.Image = new Bitmap(@"..\..\resources\");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\");
            updateLabelText("Other People Talking", " Fireworks", "Loud Voices",
                "Household Appliances (e.g. blenders, vacuum)", "Vehicles (e.g. trucks, motorbikes)",
                "Bathroom Appliances (e.g. hair dryers, hand dryers");
        }

        private void interviewPage2() {
            lblQuestion.Text = "Are there times when it is hard for you to listen?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\1. Hearing\2. Are there times when it is hard for you to listen\pg2img1.PNG");
            //topMidPB.Image = new Bitmap(@"");
            //topRightPB.Image = new Bitmap(@"");
            //bottomLeftPB.Image = new Bitmap(@"../../resources/");
            //bottomMidPB.Image = new Bitmap(@"../../resources/");
            //bottomRightPB.Image = new Bitmap(@"../../resources/");
            updateLabelText("If I am concentrating on something, I don't notice people talking to me",
                "I find it hard to listen to the teacher in noisy classrooms",
                "I find it hard to listen to someone talking to me when I'm in a group", 
                "", 
                "", 
                "");
        }

        private void interviewPage3() {
            lblQuestion.Text = "Are there some sounds that make it hard for you to concentrate?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\1. Hearing\3. Are there some sounds that make it hard for you to concentrate_\Radio on.jpg");
            topMidPB.Image = new Bitmap(@"..\..\resources\1. Hearing\3. Are there some sounds that make it hard for you to concentrate_\clock ticking.PNG");
            topRightPB.Image = new Bitmap(@"..\..\resources\1. Hearing\3. Are there some sounds that make it hard for you to concentrate_\people_talking.PNG");
            //bottomLeftPB.Image = new Bitmap(@"../../resources/");
            //bottomMidPB.Image = new Bitmap(@"../../resources/");
            //bottomRightPB.Image = new Bitmap(@"../../resources/");
            updateLabelText("Radio On", "Clock Ticking", "People Talking", "", "", "");
        }

        private void interviewPage4() {
            lblQuestion.Text = "Are there some sounds that you like to listen to?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\1. Hearing\4. Are there sounds that you like to listen to_\Computer sounds.jpg");
            //topMidPB.Image = new Bitmap(@"");
            topRightPB.Image = new Bitmap(@"..\..\resources\1. Hearing\4. Are there sounds that you like to listen to_\fans.PNG");
            //bottomLeftPB.Image = new Bitmap(@"../../resources/");
            bottomMidPB.Image = new Bitmap(@"..\..\resources\1. Hearing\4. Are there sounds that you like to listen to_\Rhythms.jpg");
            //bottomRightPB.Image = new Bitmap(@"../../resources/");
            updateLabelText("Computer Sounds", "Live Music", "Fans", "Music Through My Phone", "Rhythms", "");
        }

        private void interviewPage5() {
            lblQuestion.Text = "Are there some sounds that you make a lot?";
            //topLeftPB.Image = new Bitmap(@"");
            topMidPB.Image = new Bitmap(@"..\..\resources\1. Hearing\5. Are there some sounds that you make a lot_\tapping_feet.PNG");
            topRightPB.Image = new Bitmap(@"..\..\resources\1. Hearing\5. Are there some sounds that you make a lot_\Tapping fingers.jpg");
            bottomLeftPB.Image = new Bitmap(@"..\..\resources\1. Hearing\5. Are there some sounds that you make a lot_\clicking_pen.PNG");
            //bottomMidPB.Image = new Bitmap(@"");
            //bottomRightPB.Image = new Bitmap(@"../../resources/");
            updateLabelText("Humming of Whistling to Myself","Tapping Feet", "Tapping Fingers", "Clicken Pen",
                "", "");
        }

        //Sight Panels

        private void sightInterviewPage1() {
            lblQuestion.Text = "Are there some things that you don't like to look at?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\2. Sight\1. Are there some things that you don't like to look at_\Sunlight.jpg");
            //topMidPB.Image = new Bitmap(@"..\..\resources\2. Sight\1. Are there some things that you don't like to look at_\");
            topRightPB.Image = new Bitmap(@"..\..\resources\2. Sight\1. Are there some things that you don't like to look at_\Light and Shadow.jpg");
            bottomLeftPB.Image = new Bitmap(@"..\..\resources\2. Sight\1. Are there some things that you don't like to look at_\Busy Patterns.jpg");
            //bottomMidPB.Image = new Bitmap(@"..\..\resources\2. Sight\1. Are there some things that you don't like to look at_\");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\2. Sight\1. Are there some things that you don't like to look at_\");
            updateLabelText("Sunlight", "Fluorescent Light", "Light and Shadow", "Busy Patters",
                "Classroom Light", "");
        }

        private void sightInterviewPage2() {
            lblQuestion.Text = "Are there some things you see that make it hard to concentrate?";
            //topLeftPB.Image = new Bitmap(@"..\..\resources\2. Sight\1. Are there some things that you don't like to look at_\");
            //topMidPB.Image = new Bitmap(@"..\..\resources\2. Sight\1. Are there some things that you don't like to look at_\");
            // topRightPB.Image = new Bitmap(@"..\..\resources\2. Sight\1. Are there some things that you don't like to look at_\");
            // bottomLeftPB.Image = new Bitmap(@"..\..\resources\2. Sight\1. Are there some things that you don't like to look at_\");
            //bottomMidPB.Image = new Bitmap(@"..\..\resources\2. Sight\1. Are there some things that you don't like to look at_\");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\2. Sight\1. Are there some things that you don't like to look at_\");
            updateLabelText("Lots of things in a messy drawer", "People running around me", "Lots of things hanging up in the classroom", "",
                "", "");
        }

        private void sightInterviewPage3() {
            lblQuestion.Text = "Are there some things that you like to look at?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\2. Sight\3. Are there some things that you like to look at_\Moving lights.jpg");
            //topMidPB.Image = new Bitmap(@"..\..\resources\2. Sight\3. Are there some things that you don't like to look at_\");
            topRightPB.Image = new Bitmap(@"..\..\resources\2. Sight\3. Are there some things that you like to look at_\Geometric patterns.jpg");
            //bottomLeftPB.Image = new Bitmap(@"..\..\resources\2. Sight\3. Are there some things that you don't like to look at_\.jpg");
            bottomMidPB.Image = new Bitmap(@"..\..\resources\2. Sight\3. Are there some things that you like to look at_\Spinning objects.jpg");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\2. Sight\3. Are there some things that you don't like to look at_\");
            updateLabelText("Moving Lights", "Things that sparkle", "Geometric Patterns", "Spinning Fans",
                "Spinning Objects", "");
        }

        //Touch Panels
        private void touchInterviewPage1() {
            lblQuestion.Text = "Are there some things that you don't like the feeling of?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\Sandy.jpg");
            topMidPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\Sticky.jpg");
            topRightPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\Grassy.jpg");
            bottomLeftPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\Wool clothes.jpg");
            bottomMidPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\Tight clothes.jpg");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\");
            updateLabelText("Sandy", "Sticky", "Grassy", "Wool Clothes",
                "Tight Clothes", "Stiff Clothes");
        }

        private void touchInterviewPage1p2() {
            lblQuestion.Text = "Are there some things that you don't like the feeling of?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\Shoes.jpg");
            topMidPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\Splashing Water.jpg");
            //topRightPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\Geometric patterns.jpg");
            //bottomLeftPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\.jpg");
            //bottomMidPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\Spinning objects.jpg");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\");
            updateLabelText("Shoes", "Splashing Water e.g. rain, shower, pool", "", "",
                "", "");
        }

        private void touchInterviewPage2() {
            lblQuestion.Text = "Are there some ways that people touch you that you don't like?";
            //topLeftPB.Image = new Bitmap(@"..\..\resources\3. Touch\2. Are there ways that people touch you that you don't like_\Moving lights.jpg");
            topMidPB.Image = new Bitmap(@"..\..\resources\3. Touch\2. Are there ways that people touch you that you don't like_\Being crowded.jpg");
            //topRightPB.Image = new Bitmap(@"..\..\resources\3. Touch\2. Are there ways that people touch you that you don't like_\Geometric patterns.jpg");
            //bottomLeftPB.Image = new Bitmap(@"..\..\resources\3. Touch\2. Are there ways that people touch you that you don't like_\.jpg");
            //bottomMidPB.Image = new Bitmap(@"..\..\resources\3. Touch\2. Are there ways that people touch you that you don't like_\Spinning objects.jpg");
            bottomRightPB.Image = new Bitmap(@"..\..\resources\3. Touch\2. Are there ways that people touch you that you don't like_\Having a haircut.jpg");
            updateLabelText("Being hugged or kissed", "Being crowded", "Being tapped on the shoulder", "Having sunscreen put on",
                "Being bumped", "Having a haircut");
        }

        private void touchInterviewPage2p2() {
            lblQuestion.Text = "Are there some ways that people touch you that you don't like?";
            //topLeftPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there things that you don't like the feeling of_\Doctor touching me.jpg");
            //topMidPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there things that you don't like the feeling of_\Dentist touching me.jpg");
            //topRightPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there things that you don't like the feeling of_\Geometric patterns.jpg");
            //bottomLeftPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there things that you don't like the feeling of_\.jpg");
            //bottomMidPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there things that you don't like the feeling of_\Spinning objects.jpg");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there things that you don't like the feeling of_\");
            updateLabelText("Doctor touching me", "Dentist touch me", "", "",
                "", "");
        }

        private void touchInterviewPage3() {
            lblQuestion.Text = "Are there some things that you like the feeling of?";
            //topLeftPB.Image = new Bitmap(@"..\..\resources\3. Touch\3. Are there some things that you like to look at_\Moving lights.jpg");
            //topMidPB.Image = new Bitmap(@"..\..\resources\3. Touch\3. Are there some things that you don't like to look at_\");
            //topRightPB.Image = new Bitmap(@"..\..\resources\3. Touch\3. Are there some things that you like to look at_\Geometric patterns.jpg");
            bottomLeftPB.Image = new Bitmap(@"..\..\resources\3. Touch\3. Are there some things that you like the feeling of_\Hugging people.jpg");
            //bottomMidPB.Image = new Bitmap(@"..\..\resources\3. Touch\3. Are there some things that you like to look at_\Spinning objects.jpg");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\3. Touch\3. Are there some things that you don't like to look at_\");
            updateLabelText("Soft", "Rubbery", "Furry", "Hugging People",
                "Touching people", "Being squashed with a pillow");
        }

        //TODO - Smells
        private void smellInterviewPage1() {
            lblQuestion.Text = "Are there some smells that you don't like?";
            //topLeftPB.Image = new Bitmap(@"..\..\resources\4. Smells\1. Are there some smells that you don't like_\Moving lights.jpg");
            //topMidPB.Image = new Bitmap(@"..\..\resources\4. Smells\1. Are there some smells that you don't like_\");
            //topRightPB.Image = new Bitmap(@"..\..\resources\4. Smells\1. Are there some that you don't like_\Geometric patterns.jpg");
            bottomLeftPB.Image = new Bitmap(@"..\..\resources\4. Smells\1. Are there some smells that you don't like_\Toilet smells.jpg");
            //bottomMidPB.Image = new Bitmap(@"..\..\resources\4. Smells\1. Are there some smells that you don't like_\Spinning objects.jpg");
            bottomRightPB.Image = new Bitmap(@"..\..\resources\4. Smells\1. Are there some smells that you don't like_\Body smells.jpg");
            updateLabelText("Cooking smells", "Food smells", "Cleaning products",
                "Toilet smells", "Perfumes", "Body Smells");
        }

        private void smellInterviewPage2() {
            lblQuestion.Text = "Are there things that you like the smell?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\4. Smells\2. Are there some things that you like to smell_\Smelling foods.jpg");
            //topMidPB.Image = new Bitmap(@"..\..\resources\4. Smells\1. Are there some that you don't like_\");
            //topRightPB.Image = new Bitmap(@"..\..\resources\4. Smells\1. Are there some that you don't like_\Geometric patterns.jpg");
            //bottomLeftPB.Image = new Bitmap(@"..\..\resources\4. Smells\1. Are there some that you don't like_\Toilet Smells.jpg");
            //bottomMidPB.Image = new Bitmap(@"..\..\resources\4. Smells\1. Are there some that you don't like_\Spinning objects.jpg");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\4. Smells\1. Are there some that you don't like_\Body smells.jpg");
            updateLabelText("Smelling foods", "Smelling plants", "Smelling perfume",
                "Smelling soap", "Smelling people", "Body Smells");
        }
        //TODO - Taste
        private void tasteInterviewPage1() {
            lblQuestion.Text = "Are there some food groups that you don't like eating?";
            //topLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Smelling foods.jpg");
            //topMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some that you don't like_\");
            //topRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some that you don't like_\Geometric patterns.jpg");
            bottomLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Fish.jpg");
            //bottomMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some that you don't like_\Spinning objects.jpg");
            bottomRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Dairy.jpg");
            updateLabelText("Vegetables", "Fruit", "Meat", "Fish", "Eggs", "Dairy");
        }

        private void tasteInterviewPage1p2() {
            lblQuestion.Text = "Are there some food groups that you don't like eating?";
            //topLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Smelling foods.jpg");
            topMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Pasta.jpg");
            //topRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some that you don't like_\Geometric patterns.jpg");
            //bottomLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Fish.jpg");
            //bottomMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some that you don't like_\Spinning objects.jpg");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Dairy.jpg");
            updateLabelText("Bread", "Pasta", "", "", "", "");
        }


        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////// Panel Clicking ////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void hideButtons() {
            /*topLeftPBALittleBtn.Visible = false;
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
            bottomRightALotBtn.Visible = false;*/

            foreach(var pb in this.Controls.OfType<Button>()) {
                pb.Visible = false;
            }
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
    }
}
/*
Empty template to set images and labels
private void setImagesAndLabels() {
    lblQuestion.Text = "";
    topLeftPB.Image = new Bitmap(@"../../resources/");
    topMidPB.Image = new Bitmap(@"../../resources/");
    topRightPB.Image = new Bitmap(@"../../resources/");
    bottomLeftPB.Image = new Bitmap(@"../../resources/");
    bottomMidPB.Image = new Bitmap(@"../../resources/");
    bottomRightPB.Image = new Bitmap(@"../../resources/");
    lblTL.Text = "";
    lblTM.Text = "";
    lblTR.Text = "";
    lblBL.Text = "";
    lblBM.Text = "";
    lblBR.Text = "";
}
*/
