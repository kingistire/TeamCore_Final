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
        }

        private Pen aLittle = new Pen(Color.Blue, 5);
        private Pen aLot = new Pen(Color.DarkBlue, 10);
        private bool aLittleBool = false;
        private bool aLotBool = false;
        private bool isLittleSelected = false;
        private bool isLotSelected = false;

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
        private void changePictureBoxImage(PictureBox pictureBox, string imageURL, int numberOfSlidesForInterview) {
            //pictureBox.Image = new Bitmap (@imageURL);

            //Change Image
            if (nextBtnClick && nextCounter == 1) {
                pictureBox.Image = new Bitmap(@imageURL);
            } else if (nextCounter == 2) {
                pictureBox.Image = new Bitmap(@imageURL);
            } else if (nextCounter == numberOfSlidesForInterview) {
                if (MessageBox.Show("You have completed the visual interview. The next interview is XXXX.", "Ok", MessageBoxButtons.OK) == DialogResult.OK) {
                    pictureBox.Image = new Bitmap(@imageURL);
                    nextCounter = 0;
                    nextInterviewSlideBTN.Visible = false;
                    nextInterviewSlideBTN.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Draws the circle border on selected picturebox
        /// </summary>
        /// <param name="pictureBoxName">Picturebox name</param>
        /// <param name="e"></param>
        private void DeterminePenSizeDrawing(PictureBox pictureBoxName, PaintEventArgs e) {
          //If aLittle Button is clicked
            if (aLittleBool) {
                DrawCircle(aLittle, e, 0, 0, pictureBoxName.Size.Width, pictureBoxName.Size.Height);
                Console.WriteLine("A Little Button was push" + "\n");
                //If aLot button is clicked
            } else if (aLotBool) {
                DrawCircle(aLot, e, 0, 0, pictureBoxName.Size.Width, pictureBoxName.Size.Height);
                Console.WriteLine("A Lot Button was push" + "\n");
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
            DeterminePenSizeDrawing(topLeftPB, e);

        }

        private void topMidPB_Paint(object sender, PaintEventArgs e) {
            DeterminePenSizeDrawing(topMidPB, e);
        }

        private void topRightPB_Paint(object sender, PaintEventArgs e) {
            DeterminePenSizeDrawing(topRightPB, e);
        }

        private void bottomLeftPB_Paint(object sender, PaintEventArgs e) {
            DeterminePenSizeDrawing(bottomLeftPB, e);
        }

        private void bottomMidPB_Paint(object sender, PaintEventArgs e) {
            DeterminePenSizeDrawing(bottomMidPB, e);
        }

        private void bottomRightPB_Paint(object sender, PaintEventArgs e) {
            DeterminePenSizeDrawing(bottomRightPB, e);
        }

        /// <summary>
        /// Call this function when user is going to click on A Little
        /// </summary>
        private void changeBoolALittle() {
            aLittleBool = true;
            aLotBool = false;
            isLittleSelected = true;
            isLotSelected = false;
        }
        /// <summary>
        /// Call this function when user is going to click A Lot
        /// </summary>
        private void changeBoolALot() {
            aLittleBool = false;
            aLotBool = true;
            isLittleSelected = false;
            isLotSelected = true;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////// BUTTON CLICKS FOR A LITT AND A LOT ////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void topRightPBALotBtn_Click(object sender, EventArgs e) {
            changeBoolALot();
            //This will refresh the picturebox
            topLeftPB.Invalidate();
        }

        private void topLeftPBALittleBtn_Click(object sender, EventArgs e) {
            changeBoolALittle();
            //This will refresh the picture box
            topLeftPB.Invalidate();
        }

        private void topMidALittleBtn_Click(object sender, EventArgs e) {
            changeBoolALittle();
            //This will refresh the picture box
            topMidPB.Invalidate();
        }

        private void topMidALotBtn_Click(object sender, EventArgs e) {
            changeBoolALot();
            //This will refresh the picture box
            topMidPB.Invalidate();
        }

        private void topRightALittleBtn_Click(object sender, EventArgs e) {
            changeBoolALittle();
            //This will refresh the picture box
            topRightPB.Invalidate();
        }

        private void topRightALotBtn_Click(object sender, EventArgs e) {
            changeBoolALot();
            //This will refresh the picture box
            topRightPB.Invalidate();
        }

        private void bottomLeftALittleBtn_Click(object sender, EventArgs e) {
            changeBoolALittle();
            //This will refresh the picture box
            bottomLeftPB.Invalidate();
        }

        private void bottomLeftALotBtn_Click(object sender, EventArgs e) {
            changeBoolALot();
            //This will refresh the picture box
            bottomLeftPB.Invalidate();
        }

        private void bottomMidALittleBtn_Click(object sender, EventArgs e) {
            changeBoolALittle();
            //This will refresh the picture box
            bottomMidPB.Invalidate();
        }

        private void bottomMidALotBtn_Click(object sender, EventArgs e) {
            changeBoolALot();
            //This will refresh the picture box
            bottomMidPB.Invalidate();
        }

        private void bottomRightALittleBtn_Click(object sender, EventArgs e) {
            changeBoolALittle();
            //This will refresh the picture box
            bottomRightPB.Invalidate();
        }

        private void bottomRightALotBtn_Click(object sender, EventArgs e) {
            changeBoolALot();
            //This will refresh the picture box
            bottomRightPB.Invalidate();
        }

        /// <summary>
        /// Change a little and a lot to false when the next button is pressed, effectively erasing the drawings.
        /// Increase next counter to replace image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nextInterviewSlideBTN_Click(object sender, EventArgs e) {
            changeButtonBoolsOnNext();
            nextCounter++;
            //Call changePictureBoxImage method here

        }

        /// <summary>
        /// Function to determine if the next button has been clicked, and change the a Little and a Lot button to false to erase the drawing
        /// </summary>
        private void changeButtonBoolsOnNext() {
            nextBtnClick = true;
            aLittleBool = false;
            aLotBool = false;
        }
    }
}
