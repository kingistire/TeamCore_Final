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
            } else if (Globals.interview_page == 17) {
                tasteInterviewPage2();
            } else if (Globals.interview_page == 18) {
                tasteInterviewPage3();
            } else if (Globals.interview_page == 19) {
                tasteInterviewPage4();
            } else if (Globals.interview_page == 20) {
                mvmtInterviewPage1();
            }
            else if (Globals.interview_page == 21) {
                mvmtInterviewPage2();
            }
            else if (Globals.interview_page == 22) {
                mvmtInterviewPage3();
            }
            else if (Globals.interview_page == 23) {
                mvmtInterviewPage4();
            }
            else if (Globals.interview_page == 24) {
                environmentInterviewPage1();
            }
            else if (Globals.interview_page == 25) {
                otherInterviewPage1();
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
        //Summary summary = new Summary();
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
            //summary.LabelText = "Top Left A Little";
            //summary.Show();
        }
        private void topLeftPBALotBtn_Click(object sender, EventArgs e) {
            //This will refresh the picture box
            topLeftPB.Invalidate();
            page1Selections[0] = 2;
            label1.Text = string.Join(", ", page1Selections);
            //summary.LabelText = "Top Left A Lot";
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
            System.Drawing.Color tasteHeader = System.Drawing.ColorTranslator.FromHtml("#C2B4E2");
            System.Drawing.Color tasteBg = System.Drawing.ColorTranslator.FromHtml("#E6E6FA");
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
            //-------------
            //SOUND SECTION
            //-------------
            else if (Globals.interview_page == 3) {            
                Interview interviewForm3 = new Interview();
                interviewForm3.InstanceRef2 = this;
                interviewForm3.Location = new Point(0, 0);
                interviewForm3.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 4) {                
                Interview interviewForm4 = new Interview();
                interviewForm4.InstanceRef3 = this;
                interviewForm4.Location = new Point(0, 0);
                interviewForm4.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 5) {
                Interview interviewForm5 = new Interview();
                interviewForm5.InstanceRef4 = this;
                interviewForm5.Location = new Point(0, 0);
                interviewForm5.Show();
                this.Hide();
            }
            //-------------
            //SIGHT SECTION
            //-------------
            else if (Globals.interview_page == 6) {
                Interview sightInterview1 = new Interview();
                sightInterview1.InstanceRef5 = this;
                sightInterview1.Location = new Point(0, 0);
                sightInterview1.picBackground.BackColor = Color.SandyBrown;
                sightInterview1.lblQuestion.BackColor = Color.SandyBrown;
                sightInterview1.label3.BackColor = Color.SandyBrown;
                sightInterview1.label5.BackColor = Color.SandyBrown;
                sightInterview1.panel1.BackColor = Color.Bisque;      
                sightInterview1.Show();
                this.Hide();
            } else if (Globals.interview_page == 7) {
                Interview sightInterview2 = new Interview();
                sightInterview2.InstanceRef6 = this;
                sightInterview2.Location = new Point(0, 0);
                sightInterview2.picBackground.BackColor = Color.SandyBrown;
                sightInterview2.label3.BackColor = Color.SandyBrown;
                sightInterview2.label5.BackColor = Color.SandyBrown;
                sightInterview2.lblQuestion.BackColor = Color.SandyBrown;
                sightInterview2.panel1.BackColor = Color.Bisque;
                sightInterview2.Show();
                this.Hide();
            } else if (Globals.interview_page == 8) {
                Interview sightInterview3 = new Interview();
                sightInterview3.InstanceRef7 = this;
                sightInterview3.Location = new Point(0, 0);
                sightInterview3.picBackground.BackColor = Color.SandyBrown;
                sightInterview3.lblQuestion.BackColor = Color.SandyBrown;
                sightInterview3.label3.BackColor = Color.SandyBrown;
                sightInterview3.label5.BackColor = Color.SandyBrown;
                sightInterview3.panel1.BackColor = Color.Bisque;
                sightInterview3.Show();
                this.Hide();
            }
            //-------------
            //TOUCH SECTION
            //-------------
            else if (Globals.interview_page == 9) {
                Interview touchInterview1 = new Interview();
                touchInterview1.InstanceRef8 = this;
                touchInterview1.Location = new Point(0, 0);
                touchInterview1.picBackground.BackColor = Color.FromArgb(255, 255, 128);
                touchInterview1.lblQuestion.BackColor = Color.FromArgb(255, 255, 128);
                touchInterview1.label3.BackColor = Color.FromArgb(255, 255, 128);
                touchInterview1.label5.BackColor = Color.FromArgb(255, 255, 128);
                touchInterview1.panel1.BackColor = Color.LightYellow;
                touchInterview1.Show();
                this.Hide();
            } else if (Globals.interview_page == 10) {
                Interview touchInterview2 = new Interview();
                touchInterview2.InstanceRef9 = this;
                touchInterview2.Location = new Point(0, 0);
                touchInterview2.picBackground.BackColor = Color.FromArgb(255, 255, 128);
                touchInterview2.lblQuestion.BackColor = Color.FromArgb(255, 255, 128);
                touchInterview2.label3.BackColor = Color.FromArgb(255, 255, 128);
                touchInterview2.label5.BackColor = Color.FromArgb(255, 255, 128);
                touchInterview2.panel1.BackColor = Color.LightYellow;
                touchInterview2.Show();
                this.Hide();
            } else if (Globals.interview_page == 11) {
                Interview touchInterview3 = new Interview();
                touchInterview3.InstanceRef10 = this;
                touchInterview3.Location = new Point(0, 0);
                touchInterview3.picBackground.BackColor = Color.Yellow;
                touchInterview3.picBackground.BackColor = Color.FromArgb(255, 255, 128);
                touchInterview3.lblQuestion.BackColor = Color.FromArgb(255, 255, 128);
                touchInterview3.label3.BackColor = Color.FromArgb(255, 255, 128);
                touchInterview3.label5.BackColor = Color.FromArgb(255, 255, 128);
                touchInterview3.panel1.BackColor = Color.LightYellow;
                touchInterview3.Show();
                this.Hide();
            } else if (Globals.interview_page == 12) {
                Interview touchInterview4 = new Interview();
                touchInterview4.InstanceRef11 = this;
                touchInterview4.Location = new Point(0, 0);
                touchInterview4.picBackground.BackColor = Color.Yellow;
                touchInterview4.picBackground.BackColor = Color.FromArgb(255, 255, 128);
                touchInterview4.lblQuestion.BackColor = Color.FromArgb(255, 255, 128);
                touchInterview4.label3.BackColor = Color.FromArgb(255, 255, 128);
                touchInterview4.label5.BackColor = Color.FromArgb(255, 255, 128);
                touchInterview4.panel1.BackColor = Color.LightYellow;
                touchInterview4.Show();
                this.Hide();
            }
            //-------------
            //SMELL SECTION
            //-------------
            else if (Globals.interview_page == 13) {
                Interview smellInterview1 = new Interview();
                smellInterview1.InstanceRef12 = this;
                smellInterview1.Location = new Point(0, 0);
                smellInterview1.picBackground.BackColor = Color.FromArgb(143, 188, 139);
                smellInterview1.lblQuestion.BackColor = Color.FromArgb(143, 188, 139);
                smellInterview1.label3.BackColor = Color.FromArgb(143, 188, 139);
                smellInterview1.label5.BackColor = Color.FromArgb(143, 188, 139);
                smellInterview1.panel1.BackColor = Color.Honeydew;
                smellInterview1.Show();
                this.Hide();
            } else if (Globals.interview_page == 14) {
                Interview smellInterview2 = new Interview();
                smellInterview2.InstanceRef13 = this;
                smellInterview2.Location = new Point(0, 0);
                smellInterview2.picBackground.BackColor = Color.FromArgb(143, 188, 139);
                smellInterview2.lblQuestion.BackColor = Color.FromArgb(143, 188, 139);
                smellInterview2.label3.BackColor = Color.FromArgb(143, 188, 139);
                smellInterview2.label5.BackColor = Color.FromArgb(143, 188, 139);
                smellInterview2.panel1.BackColor = Color.Honeydew;
                smellInterview2.Show();
                this.Hide();
            }
            //-------------
            //TASTE SECTION
            //-------------
            else if (Globals.interview_page == 15) {               
                Interview tasteInterview1 = new Interview();
                tasteInterview1.InstanceRef14 = this;
                tasteInterview1.Location = new Point(0, 0);
                tasteInterview1.picBackground.BackColor = tasteHeader;
                tasteInterview1.panel1.BackColor = tasteBg;
                tasteInterview1.lblQuestion.BackColor = tasteHeader;
                tasteInterview1.label3.BackColor = tasteHeader;
                tasteInterview1.label5.BackColor = tasteHeader;
                tasteInterview1.Show();
                this.Hide();
            } else if (Globals.interview_page == 16) {
                Interview tasteInterview1p2 = new Interview();
                tasteInterview1p2.InstanceRef15 = this;
                tasteInterview1p2.Location = new Point(0, 0);
                tasteInterview1p2.picBackground.BackColor = tasteHeader;
                tasteInterview1p2.panel1.BackColor = tasteBg;
                tasteInterview1p2.lblQuestion.BackColor = tasteHeader;
                tasteInterview1p2.label3.BackColor = tasteHeader;
                tasteInterview1p2.label5.BackColor = tasteHeader;
                tasteInterview1p2.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 17) {
                Interview tasteInterview2 = new Interview();
                tasteInterview2.InstanceRef17 = this;
                tasteInterview2.Location = new Point(0, 0);
                tasteInterview2.picBackground.BackColor = tasteHeader;
                tasteInterview2.panel1.BackColor = tasteBg;
                tasteInterview2.lblQuestion.BackColor = tasteHeader;
                tasteInterview2.label3.BackColor = tasteHeader;
                tasteInterview2.label5.BackColor = tasteHeader;
                tasteInterview2.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 18) {
                Interview tasteInterview3 = new Interview();
                tasteInterview3.InstanceRef18 = this;
                tasteInterview3.Location = new Point(0, 0);
                tasteInterview3.picBackground.BackColor = tasteHeader;
                tasteInterview3.panel1.BackColor = tasteBg;
                tasteInterview3.lblQuestion.BackColor = tasteHeader;
                tasteInterview3.label3.BackColor = tasteHeader;
                tasteInterview3.label5.BackColor = tasteHeader;
                tasteInterview3.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 19) {
                Interview tasteInterview4 = new Interview();
                tasteInterview4.InstanceRef19 = this;
                tasteInterview4.Location = new Point(0, 0);
                tasteInterview4.picBackground.BackColor = tasteHeader;
                tasteInterview4.panel1.BackColor = tasteBg;
                tasteInterview4.lblQuestion.BackColor = tasteHeader;
                tasteInterview4.label3.BackColor = tasteHeader;
                tasteInterview4.label5.BackColor = tasteHeader;
                tasteInterview4.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 20) {
                Interview mvmtInterview1 = new Interview();
                mvmtInterview1.InstanceRef20 = this;
                mvmtInterview1.Location = new Point(0, 0);
                mvmtInterview1.picBackground.BackColor = Color.PaleVioletRed;
                mvmtInterview1.panel1.BackColor = Color.Pink;
                mvmtInterview1.lblQuestion.BackColor = Color.PaleVioletRed;
                mvmtInterview1.label3.BackColor = Color.PaleVioletRed;
                mvmtInterview1.label5.BackColor = Color.PaleVioletRed;
                mvmtInterview1.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 21) {
                Interview mvmtInterview2 = new Interview();
                mvmtInterview2.InstanceRef21 = this;
                mvmtInterview2.Location = new Point(0, 0);
                mvmtInterview2.picBackground.BackColor = Color.PaleVioletRed;
                mvmtInterview2.panel1.BackColor = Color.Pink;
                mvmtInterview2.lblQuestion.BackColor = Color.PaleVioletRed;
                mvmtInterview2.label3.BackColor = Color.PaleVioletRed;
                mvmtInterview2.label5.BackColor = Color.PaleVioletRed;
                mvmtInterview2.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 22) {
                this.Hide();
                Interview mvmtInterview3 = new Interview();
                mvmtInterview3.InstanceRef22 = this;
                mvmtInterview3.Location = new Point(0, 0);
                mvmtInterview3.picBackground.BackColor = Color.PaleVioletRed;
                mvmtInterview3.panel1.BackColor = Color.Pink;
                mvmtInterview3.lblQuestion.BackColor = Color.PaleVioletRed;
                mvmtInterview3.label3.BackColor = Color.PaleVioletRed;
                mvmtInterview3.label5.BackColor = Color.PaleVioletRed;
                mvmtInterview3.Show();
            }
            else if (Globals.interview_page == 23) {
                Interview mvmtInterview4 = new Interview();
                mvmtInterview4.InstanceRef23 = this;
                mvmtInterview4.Location = new Point(0, 0);
                mvmtInterview4.picBackground.BackColor = Color.PaleVioletRed;
                mvmtInterview4.panel1.BackColor = Color.Pink;
                mvmtInterview4.lblQuestion.BackColor = Color.PaleVioletRed;
                mvmtInterview4.label3.BackColor = Color.PaleVioletRed;
                mvmtInterview4.label5.BackColor = Color.PaleVioletRed;
                mvmtInterview4.Show();
                this.Hide();
            }
            //-------------------
            //ENVIRONMENT SECTION
            //-------------------
            else if (Globals.interview_page == 24) {
                Interview environmentInterview1 = new Interview();
                environmentInterview1.InstanceRef23 = this;
                environmentInterview1.Location = new Point(0, 0);
                environmentInterview1.picBackground.BackColor = Color.LightBlue;
                environmentInterview1.panel1.BackColor = Color.AliceBlue;
                environmentInterview1.lblQuestion.BackColor = Color.LightBlue;
                environmentInterview1.label3.BackColor = Color.LightBlue;
                environmentInterview1.label5.BackColor = Color.LightBlue;
                environmentInterview1.Show();
                this.Hide();
            }
            //-------------
            //OTHER SECTION
            //-------------
            else if (Globals.interview_page == 25) {
                Interview otherInterview1 = new Interview();
                otherInterview1.InstanceRef23 = this;
                otherInterview1.Location = new Point(0, 0);
                otherInterview1.picBackground.BackColor = Color.Tan;
                otherInterview1.panel1.BackColor = Color.AntiqueWhite;
                otherInterview1.lblQuestion.BackColor = Color.Tan;
                otherInterview1.label3.BackColor = Color.Tan;
                otherInterview1.label5.BackColor = Color.Tan;
                otherInterview1.Show();
                this.Hide();
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
            } else if (Globals.interview_page == 2) {
                this.Hide();
                InstanceRef2.Show();
            } else if (Globals.interview_page == 3) {
                this.Hide();
                InstanceRef3.Show();
            } else if (Globals.interview_page == 4) {
                this.Hide();
                InstanceRef4.Show();
            } else if (Globals.interview_page == 5) {
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
            } else if (Globals.interview_page == 17) {
                this.Hide();
                InstanceRef17.Show();
            } else if (Globals.interview_page == 18) {
                this.Hide();
                InstanceRef18.Show();
            } else if (Globals.interview_page == 19) {
                this.Hide();
                InstanceRef19.Show();
            } else if (Globals.interview_page == 20) {
                this.Hide();
                InstanceRef20.Show();
            } else if (Globals.interview_page == 21) {
                this.Hide();
                InstanceRef21.Show();
            } else if (Globals.interview_page == 22) {
                this.Hide();
                InstanceRef22.Show();
            } else if (Globals.interview_page == 23) {
                this.Hide();
                InstanceRef23.Show();
            } else if (Globals.interview_page == 24) {
                this.Hide();
                InstanceRef24.Show();
            } else if (Globals.interview_page == 25) {
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
            //topLeftPB.Image = new Bitmap(@"..\..\resources\");
            topMidPB.Image = new Bitmap(@"..\..\resources\1. Hearing\1. Are there some sounds that you don't like_\fireworks.jpg");
            topRightPB.Image = new Bitmap(@"..\..\resources\1. Hearing\1. Are there some sounds that you don't like_\loud_voices.PNG");
            bottomLeftPB.Image = new Bitmap(@"..\..\resources\1. Hearing\1. Are there some sounds that you don't like_\household_ appliances.PNG");
            // bottomMidPB.Image = new Bitmap(@"..\..\resources\");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\");
            lblBR.Size = new Size(200, 60);
            updateLabelText("Other people talking", " Fireworks", "Loud voices",
                "Household appliances (e.g. blenders, vacuum)", "Vehicles (e.g. trucks, motorbikes)",
                "Bathroom appliances (e.g. hair dryers, hand dryers)");
        }

        private void interviewPage2() {
            lblQuestion.Text = "Are there times when it is hard for you to listen?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\1. Hearing\2. Are there times when it is hard for you to listen\pg2img1.PNG");
            //topMidPB.Image = new Bitmap(@"");
            //topRightPB.Image = new Bitmap(@"");
            //bottomLeftPB.Image = new Bitmap(@"../../resources/");
            //bottomMidPB.Image = new Bitmap(@"../../resources/");
            //bottomRightPB.Image = new Bitmap(@"../../resources/");
            lblTL.Size = new Size(200, 60);
            lblTM.Size = new Size(200, 60);
            lblTR.Size = new Size(200, 60);
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
            updateLabelText("Radio on", "Clock ticking", "People talking", "", "", "");
        }

        private void interviewPage4() {
            lblQuestion.Text = "Are there some sounds that you like to listen to?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\1. Hearing\4. Are there sounds that you like to listen to_\Computer sounds.jpg");
            //topMidPB.Image = new Bitmap(@"");
            topRightPB.Image = new Bitmap(@"..\..\resources\1. Hearing\4. Are there sounds that you like to listen to_\fans.PNG");
            //bottomLeftPB.Image = new Bitmap(@"../../resources/");
            bottomMidPB.Image = new Bitmap(@"..\..\resources\1. Hearing\4. Are there sounds that you like to listen to_\Rhythms.jpg");
            //bottomRightPB.Image = new Bitmap(@"../../resources/");
            updateLabelText("Computer sounds", "Live music", "Fans", "Music through my phone", "Rhythms", "");
        }

        private void interviewPage5() {
            lblQuestion.Text = "Are there some sounds that you make a lot?";
            //topLeftPB.Image = new Bitmap(@"");
            topMidPB.Image = new Bitmap(@"..\..\resources\1. Hearing\5. Are there some sounds that you make a lot_\tapping_feet.PNG");
            topRightPB.Image = new Bitmap(@"..\..\resources\1. Hearing\5. Are there some sounds that you make a lot_\Tapping fingers.jpg");
            bottomLeftPB.Image = new Bitmap(@"..\..\resources\1. Hearing\5. Are there some sounds that you make a lot_\clicking_pen.PNG");
            //bottomMidPB.Image = new Bitmap(@"");
            //bottomRightPB.Image = new Bitmap(@"../../resources/");
            updateLabelText("Humming or whistling to myself","Tapping feet", "Tapping fingers", "Clicking pen",
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
            updateLabelText("Sunlight", "Fluorescent light", "Light and shadow", "Busy patterns",
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
            updateLabelText("Moving lights", "Things that sparkle", "Geometric patterns", "Spinning fans",
                "Spinning objects", "");
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
            updateLabelText("Sandy", "Sticky", "Grassy", "Wool clothes",
                "Tight clothes", "Stiff clothes");
        }

        private void touchInterviewPage1p2() {
            lblQuestion.Text = "Are there some things that you don't like the feeling of?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\Shoes.jpg");
            topMidPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\Splashing Water.jpg");
            //topRightPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\Geometric patterns.jpg");
            //bottomLeftPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\.jpg");
            //bottomMidPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\Spinning objects.jpg");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\");
            updateLabelText("Shoes", "Splashing water (e.g. rain, shower, pool)", "", "",
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
            updateLabelText("Soft", "Rubbery", "Furry", "Hugging people",
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
                "Toilet smells", "Perfumes", "Body smells");
        }

        private void smellInterviewPage2() {
            lblQuestion.Text = "Are there some things that you like to smell?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\4. Smells\2. Are there some things that you like to smell_\Smelling foods.jpg");
            //topMidPB.Image = new Bitmap(@"..\..\resources\4. Smells\1. Are there some that you don't like_\");
            //topRightPB.Image = new Bitmap(@"..\..\resources\4. Smells\1. Are there some that you don't like_\Geometric patterns.jpg");
            //bottomLeftPB.Image = new Bitmap(@"..\..\resources\4. Smells\1. Are there some that you don't like_\Toilet Smells.jpg");
            //bottomMidPB.Image = new Bitmap(@"..\..\resources\4. Smells\1. Are there some that you don't like_\Spinning objects.jpg");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\4. Smells\1. Are there some that you don't like_\Body smells.jpg");
            updateLabelText("Smelling foods", "Smelling plants", "Smelling perfume",
                "Smelling soap", "Smelling people", "Body smells");
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
        private void tasteInterviewPage2() {
            lblQuestion.Text = "Are there some ways that food tastes or feels in your mouth that you don't like?";
            //topLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\lumpy.jpg");
            //topMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Pasta.jpg");
            //topRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some that you don't like_\Geometric patterns.jpg");
            //bottomLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Fish.jpg");
            //bottomMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some that you don't like_\Spinning objects.jpg");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Dairy.jpg");
            updateLabelText("Lumpy", "Chewy", "Runny/Slippery", "Mixed", "Sweet", "Sour");
        }
        private void tasteInterviewPage2p2() {
            lblQuestion.Text = "Are there some ways that food tastes or feels in your mouth that you don't like?";
            //topLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\lumpy.jpg");
            //topMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Pasta.jpg");
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
            //topLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\lumpy.jpg");
            //topMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Pasta.jpg");
            //topRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some that you don't like_\Geometric patterns.jpg");
            //bottomLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Fish.jpg");
            //bottomMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some that you don't like_\Spinning objects.jpg");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Dairy.jpg");
            updateLabelText("Shirt", "Hair", "Objects", "", "", "");
        }
        private void mvmtInterviewPage1() {
            lblQuestion.Text = "Are there some ways of moving that you don't like?";
            //topLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\lumpy.jpg");
            //topMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Pasta.jpg");
            //topRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some that you don't like_\Geometric patterns.jpg");
            //bottomLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Fish.jpg");
            //bottomMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some that you don't like_\Spinning objects.jpg");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Dairy.jpg");
            updateLabelText("Being jumped on/tackled", "Moving when I can't see where I am going", "Balancing", "Being upside down", "Climbing up high", "");
        }
        private void mvmtInterviewPage2() {
            lblQuestion.Text = "Are there times when it is hard for you to stay still?";
            //topLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\lumpy.jpg");
            //topMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Pasta.jpg");
            //topRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some that you don't like_\Geometric patterns.jpg");
            //bottomLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Fish.jpg");
            //bottomMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some that you don't like_\Spinning objects.jpg");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Dairy.jpg");
            updateLabelText("", "Standing still", "", "", "Sitting still", "");
        }
        private void mvmtInterviewPage3() {
            lblQuestion.Text = "Are there some ways of moving that you like?";
            //topLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\lumpy.jpg");
            //topMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Pasta.jpg");
            //topRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some that you don't like_\Geometric patterns.jpg");
            //bottomLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Fish.jpg");
            //bottomMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some that you don't like_\Spinning objects.jpg");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Dairy.jpg");
            updateLabelText("Moving in water", "Swinging", "Spinning", "Jumping on the trampoline", "Running", "");
        }
        private void mvmtInterviewPage4() {
            lblQuestion.Text = "Are there some ways that you move over and over again?";
            //topLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\lumpy.jpg");
            //topMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Pasta.jpg");
            //topRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some that you don't like_\Geometric patterns.jpg");
            //bottomLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Fish.jpg");
            //bottomMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some that you don't like_\Spinning objects.jpg");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Dairy.jpg");
            updateLabelText("Rocking", "Moving hands", "Clapping", "Pacing", "", "");
        }
        private void environmentInterviewPage1() {
            lblQuestion.Text = "Are there some places with lots of things happening at once that you don't like?";
            //topLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\lumpy.jpg");
            //topMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Pasta.jpg");
            //topRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some that you don't like_\Geometric patterns.jpg");
            //bottomLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Fish.jpg");
            //bottomMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some that you don't like_\Spinning objects.jpg");
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
