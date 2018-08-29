using Microsoft.Win32;
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
            label2.Text = Globals.interview_page.ToString();
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
        }

        public static Interview pg1State = null;
        public static Interview pg2State = null;

        //Pen variables to draw
        private Pen aLittle = new Pen(Color.Blue, 5);
        private Pen aLot = new Pen(Color.Red, 10);

        //Bool array to draw circles
        private bool[] boolArrayForSelectionInterview1 = new bool[12]; //Set to false by default. Bool array goes a little, a lot, a little a lot starting from top left to top right, then bottom left to bottom right

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
        /// Dynamically change picturebox image
        /// </summary>
        /// <param name="pictureBox">Name of PictureBox</param>
        /// <param name="imageURL">Path to the image as a string</param>
        private void changePictureBoxImage(PictureBox pictureBoxName, string imageURL, int numberOfSlidesForInterview) {
            //pictureBox.Image = new Bitmap (@imageURL);

            //Change Image depending on number of button click
            /*
            if (nextCounter == 1) {
                pictureBoxName.Image = new Bitmap(@imageURL);
            } else if (nextCounter == 2) {
                pictureBoxName.Image = new Bitmap(@imageURL);
            } else if (nextCounter == 3) {
                pictureBoxName.Image = new Bitmap(@imageURL);
            } else if (nextCounter == 4) {
                pictureBoxName.Image = new Bitmap(@imageURL);
            } else if (nextCounter == numberOfSlidesForInterview) {
                if (MessageBox.Show("You have completed the visual interview. The next interview is XXXX.", "Ok", MessageBoxButtons.OK) == DialogResult.OK) {
                    pictureBoxName.Image = new Bitmap(@imageURL);
                    nextCounter = 0;
                    nextInterviewSlideBTN.Visible = false;
                    nextInterviewSlideBTN.Enabled = false;
                }
            }
            */
        }

        /// <summary>
        /// Draws the circle border on selected picturebox. DO NOT USE. TWAS FOR PREVIOUS BUTTON FUNCTIONALITY
        /// USE determineDrawing() instead
        /// </summary>
        /// <param name="pictureBoxName">Picturebox name</param>
        /// <param name="e"></param>
        private void DeterminePenSizeDrawing(Object sender, PictureBox pictureBoxName, PaintEventArgs e) {
            int index = 0;
            //Determine if position is even or not
            for (int i = 0; i < boolArrayForSelectionInterview1.Length; i++) {
                if (boolArrayForSelectionInterview1[i]) {
                    //Get index value of the array where true
                    index = Array.IndexOf(boolArrayForSelectionInterview1, true);
                    if (index % 2 == 0 || index == 0) {
                        DrawCircle(aLittle, e, 0, 0, pictureBoxName.Size.Width, pictureBoxName.Size.Height);
                        boolArrayForSelectionInterview1[i] = false;
                    } else {
                        DrawCircle(aLot, e, 0, 0, pictureBoxName.Size.Width, pictureBoxName.Size.Height);
                        boolArrayForSelectionInterview1[i] = false;
                    }
                }
            }
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

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////// BUTTON CLICKS FOR A LITT AND A LOT ////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void topLeftPBALittleBtn_Click(object sender, EventArgs e) {
            //This will refresh the picture box
            topLeftPB.Invalidate();
            page1Selections[0] = 1;
            //this is just to show the array being updated -- can remove after testing
            label1.Text = string.Join(", ", page1Selections);
        }

        private void topLeftPBALotBtn_Click(object sender, EventArgs e) {
            //This will refresh the picture box
            topLeftPB.Invalidate();
            page1Selections[0] = 2;
            label1.Text = string.Join(", ", page1Selections);
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

        }

        private Form m_InstanceRef = null;
        public Form InstanceRef {
            get {return m_InstanceRef;}
            set {m_InstanceRef = value;}
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
        }

        /// <summary>
        /// Initial Images when user clicks on back button on second interview slide (when nextCounter === 0)
        /// </summary>
        private void interviewPage1() {
            //topLeftPB.Image = new Bitmap(@"../../resources/");
            topMidPB.Image = new Bitmap(@"C:\Users\bryce\Documents\capstoneProject\TeamCore_Final\Login\Login\resources\1. Hearing\1. Are there some sounds that you don't like_\fireworks.jpg");
            topRightPB.Image = new Bitmap(@"C:\Users\bryce\Documents\capstoneProject\TeamCore_Final\Login\Login\resources\1. Hearing\1. Are there some sounds that you don't like_\loud_voices.PNG");
            //bottomLeftPB.Image = new Bitmap(@"../../resources/");
            //bottomMidPB.Image = new Bitmap(@"../../resources/");
            //bottomRightPB.Image = new Bitmap(@"../../resources/");
            lblTL.Text = "Other people talking";
            lblTM.Text = "Fireworks";
            lblTR.Text = "Loud voices";
            lblBL.Text = "Household appliances (e.g., blenders, vacuum)";
            lblBM.Text = "Vehicles (e.g.,trucks, motorbikes)";
            lblBR.Text = "Bathroom appliances (e.g., hand dryers, hair dryers)";
        }

        private void interviewPage2() {
            lblQuestion.Text = "Are there times when it is hard for you to listen?";
            topLeftPB.Image = new Bitmap(@"C:\Users\bryce\Documents\capstoneProject\TeamCore_Final\Login\Login\resources\1. Hearing\2. Are there times when it is hard for you to listen\pg2img1.PNG");
            //topMidPB.Image = new Bitmap(@"");
            //topRightPB.Image = new Bitmap(@"");
            //bottomLeftPB.Image = new Bitmap(@"../../resources/");
            //bottomMidPB.Image = new Bitmap(@"../../resources/");
            //bottomRightPB.Image = new Bitmap(@"../../resources/");
            lblTL.Text = "If I am concentrating on something, I don't notice people talking to me";
            lblTM.Text = "I find it hard to listen to the teacher in noisy classrooms";
            lblTR.Text = "I find it hard to listen to someone talking to me when I'm in a group";
            lblBL.Text = "Other times when it is hard for you to listen?";
            lblBM.Text = "";
            lblBR.Text = "";
        }

        private void interviewPage3() {
            lblQuestion.Text = "Are there some sounds that make it hard for you to concentrate?";
            topLeftPB.Image = new Bitmap(@"C:\Users\bryce\Documents\capstoneProject\TeamCore_Final\Login\Login\resources\1. Hearing\3. Are there some sounds that make it hard for you to concentrate_\Radio on.jpg");
            topMidPB.Image = new Bitmap(@"C:\Users\bryce\Documents\capstoneProject\TeamCore_Final\Login\Login\resources\1. Hearing\3. Are there some sounds that make it hard for you to concentrate_\clock ticking.PNG");
            //topRightPB.Image = new Bitmap(@"");
            //bottomLeftPB.Image = new Bitmap(@"../../resources/");
            //bottomMidPB.Image = new Bitmap(@"../../resources/");
            //bottomRightPB.Image = new Bitmap(@"../../resources/");
            lblTL.Text = "Radio on";
            lblTM.Text = "Clock ticking";
            lblTR.Text = "People talking";
            lblBL.Text = "Other sounds that make it hard to concentrate??";
            lblBM.Text = "";
            lblBR.Text = "";
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
