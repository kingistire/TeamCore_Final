using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImagesTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //this.AutoScaleMode = AutoScaleMode.Dpi;
            circlePB();
        }

        private int getPicBoxLocationX (PictureBox picBoxNumber) {
            return picBoxNumber.Location.X;
        }

        private int getPicBoxLocationY(PictureBox picBoxNumber) {
            return picBoxNumber.Location.Y;
        }

        private int getPicBoxLocationWidth(PictureBox picBoxNumber) {
            return picBoxNumber.Image.Width;
        }

        private int getPicBoxLocationHeight(PictureBox picBoxNumber) {
            return picBoxNumber.Image.Height;
        }

        Pen SmallBluePen = new Pen(Color.Blue, 5);
        Pen BigBluePen = new Pen(Color.Pink, 10);
        Pen clearPen = new Pen(Color.Transparent, 10);
        private bool aLittle = false;
        private bool aLot = false;

        private bool aLittleP = false;
        private bool aLotP = false;

        private bool isLittleSelected = false;
        private bool isLotSelected = false;

        private bool nextBtnClick = false;
        private int nextCounter = 0;

        //Click Button to change Circle

        /**
         * From button2_Click to pictureBox3_Paint, clicking on a button will change the circle size and colour
         * 
         * */
        private void button2_Click(object sender, EventArgs e) {

            changeBoolALittle();
            pictureBox6.Invalidate();
        }

        private void button3_Click(object sender, EventArgs e) {
            changeBoolALot();
            pictureBox6.Invalidate();
        }

        private void changeBoolALittle() {
            aLittle = true;
            aLot = false;
            isLittleSelected = true;
            isLotSelected = false;
        }

        private void changeBoolALot() {
            aLittle = false;
            aLot = true;
            isLittleSelected = false;
            isLotSelected = true;
        }

        /// <summary>
        /// Paint the picturebox, to draw on top of the picture box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox3_Paint(object sender, PaintEventArgs e) {
            //If aLittle Button is clicked
            if (aLittle) {
                DrawCircle(SmallBluePen, e, 0, 0, pictureBox6.Size.Width - 5, pictureBox6.Size.Height -5);
            //If aLot button is clicked
            } else if (aLot) {
                DrawCircle(BigBluePen, e, 0, 0, pictureBox6.Size.Width - 5, pictureBox6.Size.Height - 5);
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


        
        /**
         * Create a circular picture box
         * */
        private void circlePB() {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, pictureBox6.Width, pictureBox6.Height);
            pictureBox6.Region = new Region(path);
        }

        /**
         * Paint the circular picturebox
         * */
        private void pictureBox6_Paint(object sender, PaintEventArgs e) {
            //If aLittle Button is clicked
            if (aLittle) {
                DrawCircle(SmallBluePen, e, 0, 0, pictureBox6.Size.Width, pictureBox6.Size.Height);
                //If aLot button is clicked
            } else if (aLot) {
                DrawCircle(BigBluePen, e, 0, 0, pictureBox6.Size.Width, pictureBox6.Size.Height);
            }
            //Change Image
            if (nextBtnClick && nextCounter == 1) {
                pictureBox6.Image = new Bitmap(@"..\..\resources1\10689985_375007842650011_6464618090116212130_n.jpg");
            } else if (nextCounter == 2) {
                pictureBox6.Image = new Bitmap(@"..\..\resources1\22883230_1666426686758964_241905968_n.png");
            }

        }


        //Paint on Panel

        private void panel1_Paint(object sender, PaintEventArgs e) {
            if (aLittle) {
                Graphics graphics = e.Graphics;
                this.Invalidate();
                graphics.DrawEllipse(SmallBluePen, pictureBox3.Location.X - 5, pictureBox3.Location.Y - 5, pictureBox3.Size.Width + 10, pictureBox3.Size.Height + 10);
            } else if (aLot) {
                Graphics graphics = e.Graphics;
                this.Invalidate();
                graphics.DrawEllipse(BigBluePen, 0, 0, pictureBox3.Size.Width - 5, pictureBox3.Size.Height - 5);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e) {
            int pbX = getPicBoxLocationX(pictureBox7);
            int pbY = getPicBoxLocationY(pictureBox7);
            if (aLittleP) {
                Graphics graphics = e.Graphics;
                graphics.DrawEllipse(SmallBluePen, pictureBox7.Location.X, pictureBox7.Location.Y, pictureBox7.Size.Width + 20, pictureBox7.Size.Height + 20);

            } else if (aLotP) {
                Graphics graphics = e.Graphics;
                graphics.DrawEllipse(BigBluePen, pictureBox7.Location.X, pictureBox7.Location.Y, pictureBox7.Size.Width + 20, pictureBox7.Size.Height + 20);
            }
        }

        private void button5_Click(object sender, EventArgs e) {
            aLittleP = true;
            aLotP = false;
            panel2.BringToFront();
            panel2.Invalidate();
        }

        private void button4_Click(object sender, EventArgs e) {
            aLotP = true;
            aLittleP = false;
            panel2.BringToFront();
            panel2.Invalidate();
        }


        /// <summary>
        /// When the next button is clicked, erases drawing and changes picture
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nextBtn_Click(object sender, EventArgs e) {
            nextBtnClick = true;
            aLittle = false;
            aLot = false;
            nextCounter++;

            //Put code above here to write to database on what user has selected.
            pictureBox6.Invalidate();
            Console.WriteLine("Counter: " + nextCounter.ToString() + "\n" + "A Little Selected: " + isLittleSelected.ToString() + 
                "\n" + "A Lot Selected: " + isLotSelected.ToString());
        }

    }

}
