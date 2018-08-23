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
            originalImages();
        }

        private Pen aLittle = new Pen(Color.Blue, 5);
        private Pen aLot = new Pen(Color.Red, 10);
        private bool aLittleBool = false;
        private bool aLotBool = false;
        private bool isLittleSelected = false;
        private bool isLotSelected = false;
        private int _buttonClicked = 0;
        private bool prevButtonClick = false;

        private bool[] boolArrayForSelectionInterview1 = new bool[12]; //Set to false by default. Bool array goes a little, a lot, a little a lot starting from top left to top right, then bottom left to bottom right
        private bool[] backUpBoolArrayInterview1 = new bool[12];

        private int[] intArray = new int[6] { 0, 0, 0, 0, 0, 0, };

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
            } else if (nextCounter == 0) {
                originalImages();
            }
        }

        /// <summary>
        /// Initial Images when user clicks on back button on second interview slide (when nextCounter === 0)
        /// </summary>
        private void originalImages() {
            topLeftPB.Image = new Bitmap(@"../../resources/_a_band-maid_start_over__1.jpg");
            topMidPB.Image = new Bitmap(@"../../resources/81-kix8WGmL._SL1500_.jpg");
            topRightPB.Image = new Bitmap(@"../../resources/band-maid-daydreaming-mv.jpg");
            bottomLeftPB.Image = new Bitmap(@"../../resources/band-maid-domination-750x400.png");
            bottomMidPB.Image = new Bitmap(@"../../resources/BAND-MAID-start-over-1130x565.jpg");
            bottomRightPB.Image = new Bitmap(@"../../resources/maxresdefault.jpg");
        }

        /// <summary>
        /// Draws the circle border on selected picturebox
        /// </summary>
        /// <param name="pictureBoxName">Picturebox name</param>
        /// <param name="e"></param>
        private void DeterminePenSizeDrawing(Object sender, PictureBox pictureBoxName, PaintEventArgs e) {
            //Determine if position is even or not
            //for (int i = 0; i < intArray.Length; i++) {
            //Console.WriteLine(intArray[i].ToString());
            //  if(intArray[i] == 1) {
            //DrawCircle(aLittle, e, 0, 0, pictureBoxName.Size.Width, pictureBoxName.Size.Height);
            //} else if (intArray[i] == 2) {
            //  DrawCircle(aLot, e, 0, 0, pictureBoxName.Size.Width, pictureBoxName.Size.Height);
            //}
            int index = 0;
            //Determine if position is even or not
            for (int i = 0; i < boolArrayForSelectionInterview1.Length; i++) {
                if (boolArrayForSelectionInterview1[i]) {
                    //Get index value of the array where true
                    index = Array.IndexOf(boolArrayForSelectionInterview1, true);
                    Console.WriteLine(index);
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

        //}


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
        private int[] changeBoolALittle(object sender) {
            if (sender.Equals(topLeftPBALittleBtn)) {
                changeBoolArray(0, 1);
                Console.WriteLine("Bottom Mid Set To: " + intArray[0].ToString());
            } else if (sender.Equals(topMidALittleBtn)) {
                changeBoolArray(2, 3);
                Console.WriteLine("Bottom Mid Set To: " + intArray[1].ToString());
            } else if (sender.Equals(topRightALittleBtn)) {
                changeBoolArray(4, 5);
                Console.WriteLine("Bottom Mid Set To: " + intArray[2].ToString());
            } else if (sender.Equals(bottomLeftALittleBtn)) {
                changeBoolArray(6, 7);
                Console.WriteLine("Bottom Mid Set To: " + intArray[3].ToString());
            } else if (sender.Equals(bottomMidALittleBtn)) {
                changeBoolArray(8, 9);
                Console.WriteLine("Bottom Mid Set To: " + intArray[4].ToString());
            } else if (sender.Equals(bottomRightALittleBtn)) {
                changeBoolArray(10, 11);
                Console.WriteLine("Bottom Mid Set To: " + intArray[5].ToString());
            }

            return intArray;

        }
        /// <summary>
        /// Call this function when user is going to click A Lot
        /// </summary>
        private int[] changeBoolALot(object sender) {
            if (sender.Equals(topLeftPBALotBtn)) {
                changeBoolArray(1, 0);
                Console.WriteLine("Bottom Mid Set to " + intArray[0].ToString());
            } else if (sender.Equals(topMidALotBtn)) {
                changeBoolArray(3, 2);
                Console.WriteLine("Bottom Mid Set to " + intArray[1].ToString());
            } else if (sender.Equals(topRightALotBtn)) {
                changeBoolArray(5, 4);
                Console.WriteLine("Bottom Mid Set to " + intArray[2].ToString());
            } else if (sender.Equals(bottomLeftALotBtn)) {
                changeBoolArray(7, 6);
                Console.WriteLine("Bottom Mid Set to " + intArray[3].ToString());
            } else if (sender.Equals(bottomMidALotBtn)) {
                changeBoolArray(9, 8);
                Console.WriteLine("Bottom Mid Set to " + intArray[4].ToString());
            } else if (sender.Equals(bottomRightALotBtn)) {
                changeBoolArray(11, 10);
                Console.WriteLine("Bottom Mid Set to " + intArray[5].ToString());
            }
            return intArray;
        }

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
            _buttonClicked++;
        }

        private void topLeftPBALittleBtn_Click(object sender, EventArgs e) {
            changeBoolALittle(sender);
            //This will refresh the picture box
            topLeftPB.Invalidate();
            _buttonClicked++;
        }

        private void topMidALittleBtn_Click(object sender, EventArgs e) {
            changeBoolALittle(sender);
            //This will refresh the picture box
            topMidPB.Invalidate();
            _buttonClicked++;
        }

        private void topMidALotBtn_Click(object sender, EventArgs e) {
            changeBoolALot(sender);
            //This will refresh the picture box
            topMidPB.Invalidate();
            _buttonClicked++;
        }

        private void topRightALittleBtn_Click(object sender, EventArgs e) {
            changeBoolALittle(sender);
            //This will refresh the picture box
            topRightPB.Invalidate();
            _buttonClicked++;
        }

        private void bottomLeftALittleBtn_Click(object sender, EventArgs e) {
            changeBoolALittle(sender);
            //This will refresh the picture box
            bottomLeftPB.Invalidate();
            _buttonClicked++;
        }

        private void bottomLeftALotBtn_Click(object sender, EventArgs e) {
            changeBoolALot(sender);
            //This will refresh the picture box
            bottomLeftPB.Invalidate();
            _buttonClicked++;
        }

        private void bottomMidALittleBtn_Click(object sender, EventArgs e) {
            changeBoolALittle(sender);
            //This will refresh the picture box
            bottomMidPB.Invalidate();
            _buttonClicked++;
        }

        private void bottomMidALotBtn_Click(object sender, EventArgs e) {
            changeBoolALot(sender);
            //This will refresh the picture box
            bottomMidPB.Invalidate();
            _buttonClicked++;
        }

        private void bottomRightALittleBtn_Click(object sender, EventArgs e) {
            changeBoolALittle(sender);
            //This will refresh the picture box
            bottomRightPB.Invalidate();
            _buttonClicked++;
        }

        private void bottomRightALotBtn_Click(object sender, EventArgs e) {
            changeBoolALot(sender);
            //This will refresh the picture box
            bottomRightPB.Invalidate();
            _buttonClicked++;
        }

        /// <summary>
        /// Change a little and a lot to false when the next button is pressed, effectively erasing the drawings.
        /// Increase next counter to replace image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nextInterviewSlideBTN_Click(object sender, EventArgs e) {
            //changeButtonBoolsOnNext();
            //nextCounter++;
            panel2.BringToFront();

            //Call changePictureBoxImage method here
            //changePictureBoxImage(topLeftPB, "../../resources/_a_band-maid_start_over__1.jpg", 5);
            //changePictureBoxImage(topMidPB, "../../resources/81-kix8WGmL._SL1500_.jpg", 5);
            //changePictureBoxImage(topRightPB, "../../resources/band-maid-daydreaming-mv.jpg", 5);
            //changePictureBoxImage(bottomLeftPB, "../../resources/band-maid-domination-750x400.png", 5);
            //changePictureBoxImage(bottomMidPB, "../../resources/BAND-MAID-start-over-1130x565.jpg", 5);
            //changePictureBoxImage(bottomRightPB, "../../resources/BAND-MAID_banner.jpg", 5);

        }

        /// <summary>
        /// Function to determine if the next button has been clicked, and change the a Little and a Lot button to false to erase the drawing
        /// </summary>
        private void changeButtonBoolsOnNext() {
            nextBtnClick = true;
            aLittleBool = false;
            aLotBool = false;
        }

        private void changeButtonBoolsOnPrevious() {
            nextBtnClick = false;
            aLittleBool = true;
            aLotBool = true;
        }

        private void previousInterviewSlideBtn_Click(object sender, EventArgs e) {
            List<PictureBox> pbList = new List<PictureBox>();
            prevButtonClick = true;
            //nextCounter--;
            interviewPanel.BringToFront();
            foreach (var pb in this.Controls.OfType<PictureBox>()) {
                pbList.Add(pb);
            }

            for (int i = 0; i < pbList.Count; i++) {
                pbList[i].Invalidate();
            }

            //changeButtonBoolsOnPrevious();
            //if(nextCounter == 0) {
            //    this.previousInterviewSlideBtn.Visible = false;
            //}

        }

        private void topLeftPBALotBtn_Click(object sender, EventArgs e) {
            changeBoolALot(sender);
            //This will refresh the picture box
            topLeftPB.Invalidate();
        }
    }
}
