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

namespace Login {
    public partial class Interview : Form {
        public Interview() {
            InitializeComponent();
            //Dynamically create the circular picture boxes
            createCirclePB(bottomLeftPB);
            createCirclePB(bottomRightPB);
            createCirclePB(bottomMidPB);
            createCirclePB(topLeftPB);
            createCirclePB(topRightPB);
            createCirclePB(topMidPB);
            //Assign images to pictureboxes
            originalImages();
        }

        //Pen variables to draw
        private Pen aLittle = new Pen(Color.Blue, 5);
        private Pen aLot = new Pen(Color.Red, 10);

        //Determine if the previous button was clicked
        private bool prevButtonClick = false;

        //Bool array to draw circles
        private bool[] boolArrayForSelectionInterview1 = new bool[12]; //Set to false by default. Bool array goes a little, a lot, a little a lot starting from top left to top right, then bottom left to bottom right

        //Extra variables
        private bool nextBtnClick = false;
        private int nextCounter = 0;
        private int interview2Counter = 0;


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
        }

        /// <summary>
        /// Initial Images when user clicks on back button on second interview slide (when nextCounter === 0)
        /// </summary>
        private void originalImages() {
            topLeftPB.Image = new Bitmap(@"../../resources/");
            topMidPB.Image = new Bitmap(@"../../resources/");
            topRightPB.Image = new Bitmap(@"../../resources/");
            bottomLeftPB.Image = new Bitmap(@"../../resources/");
            bottomMidPB.Image = new Bitmap(@"../../resources/");
            bottomRightPB.Image = new Bitmap(@"../../resources/");
        }

        /// <summary>
        /// Draws the circle border on selected picturebox
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

        //Code from here will update the pictureboxes when the user has clicked on a button
        private void topLeftPB_Paint(object sender, PaintEventArgs e) {
            DeterminePenSizeDrawing(sender, topLeftPB, e);
        }

        private void topMidPB_Paint(object sender, PaintEventArgs e) {
            DeterminePenSizeDrawing(sender, topMidPB, e);
        }

        private void topRightPB_Paint(object sender, PaintEventArgs e) {
            DeterminePenSizeDrawing(sender, topRightPB, e);
        }

        private void bottomLeftPB_Paint(object sender, PaintEventArgs e) {
            DeterminePenSizeDrawing(sender, bottomLeftPB, e);
        }

        private void bottomMidPB_Paint(object sender, PaintEventArgs e) {
            DeterminePenSizeDrawing(sender, bottomMidPB, e);
        }

        private void bottomRightPB_Paint(object sender, PaintEventArgs e) {
            DeterminePenSizeDrawing(sender, bottomRightPB, e);
        }

        /// <summary>
        /// Call this function when user is going to click on A Little
        /// </summary>
        private void changeBoolALittle(object sender) {
            if (sender.Equals(topLeftPBALittleBtn)) {
                changeBoolArray(0, 1);
            } else if (sender.Equals(topMidALittleBtn)) {
                changeBoolArray(2, 3);
            } else if (sender.Equals(topRightALittleBtn)) {
                changeBoolArray(4, 5);
            } else if (sender.Equals(bottomLeftALittleBtn)) {
                changeBoolArray(6, 7);
            } else if (sender.Equals(bottomMidALittleBtn)) {
                changeBoolArray(8, 9);
            } else if (sender.Equals(bottomRightALittleBtn)) {
                changeBoolArray(10, 11);
            }

        }
        /// <summary>
        /// Call this function when user is going to click A Lot
        /// </summary>
        private void changeBoolALot(object sender) {
            if (sender.Equals(topLeftPBALotBtn)) {
                changeBoolArray(1, 0);
            } else if (sender.Equals(topMidALotBtn)) {
                changeBoolArray(3, 2);
            } else if (sender.Equals(topRightALotBtn)) {
                changeBoolArray(5, 4);
            } else if (sender.Equals(bottomLeftALotBtn)) {
                changeBoolArray(7, 6);
            } else if (sender.Equals(bottomMidALotBtn)) {
                changeBoolArray(9, 8);
            } else if (sender.Equals(bottomRightALotBtn)) {
                changeBoolArray(11, 10);
            }
        }

        /// <summary>
        /// Changes array position from true to false and vice versa
        /// </summary>
        /// <param name="positionSettingTrue">Set the index position to true in array</param>
        /// <param name="positionSettingFalse">Set the index position to false in array</param>
        private void changeBoolArray(int positionSettingTrue, int positionSettingFalse) {
            boolArrayForSelectionInterview1[positionSettingTrue] = true;
            boolArrayForSelectionInterview1[positionSettingFalse] = false;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////// BUTTON CLICKS FOR A LITT AND A LOT ////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void topRightPBALotBtn_Click(object sender, EventArgs e) {
            changeBoolALot(sender);
            //This will refresh the picturebox
            topRightPB.Invalidate();
             
        }

        private void topLeftPBALittleBtn_Click(object sender, EventArgs e) {
            changeBoolALittle(sender);
            //This will refresh the picture box
            topLeftPB.Invalidate();
             
        }

        private void topLeftPBALotBtn_Click(object sender, EventArgs e) {
            changeBoolALot(sender);
            //This will refresh the picture box
            topLeftPB.Invalidate();
             
        }

        private void topMidALittleBtn_Click(object sender, EventArgs e) {
            changeBoolALittle(sender);
            //This will refresh the picture box
            topMidPB.Invalidate();
             
        }

        private void topMidALotBtn_Click(object sender, EventArgs e) {
            changeBoolALot(sender);
            //This will refresh the picture box
            topMidPB.Invalidate();
             
        }

        private void topRightALittleBtn_Click(object sender, EventArgs e) {
            changeBoolALittle(sender);
            //This will refresh the picture box
            topRightPB.Invalidate();
             
        }

        private void bottomLeftALittleBtn_Click(object sender, EventArgs e) {
            changeBoolALittle(sender);
            //This will refresh the picture box
            bottomLeftPB.Invalidate();
             
        }

        private void bottomLeftALotBtn_Click(object sender, EventArgs e) {
            changeBoolALot(sender);
            //This will refresh the picture box
            bottomLeftPB.Invalidate();
             
        }

        private void bottomMidALittleBtn_Click(object sender, EventArgs e) {
            changeBoolALittle(sender);
            //This will refresh the picture box
            bottomMidPB.Invalidate();
             
        }

        private void bottomMidALotBtn_Click(object sender, EventArgs e) {
            changeBoolALot(sender);
            //This will refresh the picture box
            bottomMidPB.Invalidate();
             
        }

        private void bottomRightALittleBtn_Click(object sender, EventArgs e) {
            changeBoolALittle(sender);
            //This will refresh the picture box
            bottomRightPB.Invalidate();
             
        }

        private void bottomRightALotBtn_Click(object sender, EventArgs e) {
            changeBoolALot(sender);
            //This will refresh the picture box
            bottomRightPB.Invalidate();
             
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////// CHANGING INTERVIEW PAGE FUNCATIONALITY ////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// Change a little and a lot to false when the next button is pressed, effectively erasing the drawings.
        /// Increase next counter to replace image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nextInterviewSlideBTN_Click(object sender, EventArgs e) {
            //changeButtonBoolsOnNext();
            nextCounter++;

            previousInterviewSlideBtn.Visible = true;
            interview2NextBtn.Visible = true;

            //Call changePictureBoxImage method here
            changePictureBoxImage(topLeftPB, "../../resources/", 5);
            changePictureBoxImage(topMidPB, "../../resources/", 5);
            changePictureBoxImage(topRightPB, "../../resources/", 5);
            changePictureBoxImage(bottomLeftPB, "../../resources/", 5);
            changePictureBoxImage(bottomMidPB, "../../resources/", 5);
            changePictureBoxImage(bottomRightPB, "../../resources/", 5);
            nextInterviewSlideBTN.Visible = false;
        }

        /// <summary>
        /// Previous button functionality
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void previousInterviewSlideBtn_Click(object sender, EventArgs e) {
            List<PictureBox> pbList = new List<PictureBox>();
            prevButtonClick = true;
            nextCounter--;
            //Depending on nextCounter, change picturebox image
            if(nextCounter == 0) {
                this.previousInterviewSlideBtn.Visible = false;
                originalImages();
            } else if (nextCounter == 1) {
                interviewSlide2();
            }

        }

        /// <summary>
        /// Call this when going to the second Interview Slide
        /// </summary>
        private void interviewSlide2() {
            changePictureBoxImage(topLeftPB, "../../resources/", 5);
            changePictureBoxImage(topMidPB, "../../resources/", 5);
            changePictureBoxImage(topRightPB, "../../resources/", 5);
            changePictureBoxImage(bottomLeftPB, "../../resources/", 5);
            changePictureBoxImage(bottomMidPB, "../../resources/", 5);
            changePictureBoxImage(bottomRightPB, "../../resources/", 5);
            interview2NextBtn.Visible = false;
            nextInterviewSlideBTN.Visible = true;
        }

        /// <summary>
        /// When user clicks on the initial next button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void interview2NextBtn_Click(object sender, EventArgs e) {
            nextCounter++;

            //Make interview button visible.
            previousInterviewSlideBtn.Visible = true;

            //Call changePictureBoxImage method here
            changePictureBoxImage(topLeftPB, "../../resources/", 5);
            changePictureBoxImage(topMidPB, "../../resources/", 5);
            changePictureBoxImage(topRightPB, "../../resources/", 5);
            changePictureBoxImage(bottomLeftPB, "../../resources/", 5);
            changePictureBoxImage(bottomMidPB, "../../resources/", 5);
            changePictureBoxImage(bottomRightPB, "../../resources/", 5);
        }
    }
}
