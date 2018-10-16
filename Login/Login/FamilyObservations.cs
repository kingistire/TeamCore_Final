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
using System.Data.SqlClient;

using WMPLib; 

namespace Login {
    public partial class FamilyObservations : Form {

        private System.Media.SoundPlayer topLeftPBPlayer = new System.Media.SoundPlayer();
        private string topLeftReadOutLoudPath;
        private string topMiddleReadOutLoudPath;
        private string topRightReadOutLoudPath;
        private string bottomLeftReadOutLoudPath;
        private string bottomMiddleReadOutLoudPath;
        private string bottomrightReadOutLoudPath;

        public FamilyObservations() {
            Globals.shortResponse = true;
            InitializeComponent();
            picturePanel.BringToFront();
            btnPreviousInterview.Click += previousInterviewSlideBtn_Click;
            button1.Click += btnNext1_Click_1;

            //Dynamically create the circular picture boxes
            createCirclePB(bottomLeftPB);
            createCirclePB(bottomRightPB);
            createCirclePB(bottomMidPB);
            createCirclePB(topLeftPB);
            createCirclePB(topRightPB);
            createCirclePB(topMidPB);
                  
            if (Globals.interview_page >= 2) {
                previousInterviewSlideBtn.Visible = true;
                btnPreviousInterview.Visible = true;
            } else {
                previousInterviewSlideBtn.Visible = false;
                btnPreviousInterview.Visible = false;
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
                questionPanel.BringToFront();
            }
            else if (Globals.interview_page == 4) {
                interviewPage3();
            }
            else if (Globals.interview_page == 5) {
                interviewPage4();
                questionPanel.BringToFront();
            }
            else if (Globals.interview_page == 6) {
                interviewPage5();
            }
            else if (Globals.interview_page == 7) {
                interviewPage6();
                questionPanel.BringToFront();
            }
            else if (Globals.interview_page == 8) {
                interviewPage7();
            }
            else if (Globals.interview_page == 9) {
                interviewPage8();
                questionPanel.BringToFront();
            }
            else if (Globals.interview_page == 10) {
                interviewPage9();
            }
            else if (Globals.interview_page == 11) {
                interviewPage10();
                questionPanel.BringToFront();
            }
            else if (Globals.interview_page == 12) {
                sightInterviewPage1();
                SightColours();
            }
            else if (Globals.interview_page == 13) {
                sightInterviewPage2();
                questionPanel.BringToFront();
                SightColours();
            }
            else if (Globals.interview_page == 14) {
                sightInterviewPage3();
                SightColours();
            }
            else if (Globals.interview_page == 15) {
                sightInterviewPage4();
                questionPanel.BringToFront();
                SightColours();
            }
            else if (Globals.interview_page == 16) {
                sightInterviewPage5();
                SightColours();
            }
            else if (Globals.interview_page == 17) {
                sightInterviewPage6();
                questionPanel.BringToFront();
                SightColours();
            }
            else if (Globals.interview_page == 18) {
                touchInterviewPage1();
                TouchColours();
            }
            else if (Globals.interview_page == 19) {
                touchInterviewPage1p2();
                TouchColours();
            }
            else if (Globals.interview_page == 20) {
                touchInterviewPage2();
                TouchColours();
                questionPanel.BringToFront();
            }
            else if (Globals.interview_page == 21) {
                touchInterviewPage3();
                TouchColours();
            }
            else if (Globals.interview_page == 22) {
                touchInterviewPage3p2();
                TouchColours();
            }
            else if (Globals.interview_page == 23) {
                touchInterviewPage4();
                TouchColours();
                questionPanel.BringToFront();
            }
            else if (Globals.interview_page == 24) {
                touchInterviewPage5();
                TouchColours();
            }
            else if (Globals.interview_page == 25) {
                touchInterviewPage6();
                TouchColours();
                questionPanel.BringToFront();
            }
            else if (Globals.interview_page == 26) {
                smellInterviewPage1();
                SmellColours();
            }
            else if (Globals.interview_page == 27) {
                smellInterviewPage2();
                questionPanel.BringToFront();
                SmellColours();
            }
            else if (Globals.interview_page == 28) {
                smellInterviewPage3();
                SmellColours();
            }
            else if (Globals.interview_page == 29) {
                smellInterviewPage4();
                questionPanel.BringToFront();
                SmellColours();
            }
            else if (Globals.interview_page == 30) {
                tasteInterviewPage1();
                TasteColours();
            }
            else if (Globals.interview_page == 31) {
                tasteInterviewPage1p2();
                TasteColours();
            }
            else if (Globals.interview_page == 32) {
                tasteInterviewPage2();
                questionPanel.BringToFront();
                TasteColours();
            }
            else if (Globals.interview_page == 33) {
                tasteInterviewPage3();
                TasteColours();
            }
            else if (Globals.interview_page == 34) {
                tasteInterviewPage3p2();
                TasteColours();
            }
            else if (Globals.interview_page == 35) {
                tasteInterviewPage4();
                questionPanel.BringToFront();
                TasteColours();
            }
            else if (Globals.interview_page == 36) {
                tasteInterviewPage5();
                TasteColours();
            }
            else if (Globals.interview_page == 37) {
                tasteInterviewPage6();
                questionPanel.BringToFront();
                TasteColours();
            }
            else if (Globals.interview_page == 38) {
                tasteInterviewPage7();
                TasteColours();
            }
            else if (Globals.interview_page == 39) {
                tasteInterviewPage8();
                questionPanel.BringToFront();
                TasteColours();
            }
            else if (Globals.interview_page == 40) {
                mvmtInterviewPage1();
                MovementColours();
            }
            else if (Globals.interview_page == 41) {
                mvmtInterviewPage2();
                questionPanel.BringToFront();
                MovementColours();
            }
            else if (Globals.interview_page == 42) {
                mvmtInterviewPage3();
                MovementColours();
            }
            else if (Globals.interview_page == 43) {
                mvmtInterviewPage4();
                questionPanel.BringToFront();
                MovementColours();
            }
            else if (Globals.interview_page == 44) {
                mvmtInterviewPage5();;
                MovementColours();
            }
            else if (Globals.interview_page == 45) {
                mvmtInterviewPage6();
                questionPanel.BringToFront();
                MovementColours();
            }
            else if (Globals.interview_page == 46) {
                mvmtInterviewPage7();
                MovementColours();
            }
            else if (Globals.interview_page == 47) {
                mvmtInterviewPage8();
                questionPanel.BringToFront();
                MovementColours();
            }
            else if (Globals.interview_page == 48) {
                environmentPage1();
                EnvironmentColours();
            }
            else if (Globals.interview_page == 49) {
                environmentPage2();
                EnvironmentColours();
                questionPanel.BringToFront();
            }
            else if (Globals.interview_page == 50) {
                otherInterviewPage1();
                OtherColours();
            }
            else if (Globals.interview_page == 51) {
                otherInterviewPage2();
                OtherColours();
                questionPanel.BringToFront();        
            }
            else if (Globals.interview_page == 52) {
                additionalNotesPanel.BringToFront();
            }
        }

        /// <summary>
        /// Sound
        /// </summary>
        private void interviewPage1()
        {
            //axWindowsMediaPlayer1.URL = @"..\..\resources\0testsound.mp3";
            lblQuestion.Text = "Are there some sounds that s/he doesn't like?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\1. Hearing\1. Are there some sounds that you don't like_\1 Other People Talking (cropped).png");
            topLeftReadOutLoudPath = @"..\..\resources\1. Hearing\1. Are there some sounds that you don't like_\1.1.1OtherPeopleTalking.wav";

            topMidPB.Image = new Bitmap(@"..\..\resources\1. Hearing\1. Are there some sounds that you don't like_\2 Fireworks.jpg");
            topMiddleReadOutLoudPath = @"..\..\resources\1. Hearing\1. Are there some sounds that you don't like_\1.1.2Fireworks.wav";

            topRightPB.Image = new Bitmap(@"..\..\resources\1. Hearing\1. Are there some sounds that you don't like_\3 Loud voices.PNG");
            topRightReadOutLoudPath = @"..\..\resources\1. Hearing\1. Are there some sounds that you don't like_\1.1.3LoudVoices.wav";

            bottomLeftPB.Image = new Bitmap(@"..\..\resources\1. Hearing\1. Are there some sounds that you don't like_\4 Household appliances (e.g., blenders, vacuum).png");
            bottomLeftReadOutLoudPath = @"..\..\resources\1. Hearing\1. Are there some sounds that you don't like_\1.1.4HouseholdAppliances.wav";

            bottomMidPB.Image = new Bitmap(@"..\..\resources\1. Hearing\1. Are there some sounds that you don't like_\5 Vehicles (e.g., trucks, motorbikes) (cropped).jpg");
            bottomMiddleReadOutLoudPath = @"..\..\resources\1. Hearing\1. Are there some sounds that you don't like_\1.1.5Vehicles.wav";

            bottomRightPB.Image = new Bitmap(@"..\..\resources\1. Hearing\1. Are there some sounds that you don't like_\6 Bathroom appliances (e.g., hand dryers, hair dryers) (photoshopped).jpg");
            bottomrightReadOutLoudPath = @"..\..\resources\1. Hearing\1. Are there some sounds that you don't like_\1.1.6BathroomAppliances.wav";

            updateLabelText("Other people talking", " Fireworks", "Loud voices",
                "Household appliances (e.g. blenders, vacuum)", "Vehicles (e.g. trucks, motorbikes)",
                "Bathroom appliances (e.g. hair dryers, hand dryers)");
        }

        private void interviewPage1p2()
        {
            lblQuestion.Text = "Are there some sounds that s/he doesn't like?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\1. Hearing\1. Are there some sounds that you don't like_\7 Sirens, alarms, school bells.jpg");
            topLeftReadOutLoudPath = @"..\..\resources\1. Hearing\1. Are there some sounds that you don't like_\1.1.7Sirens.Wav";

            topMidPB.Image = new Bitmap(@"..\..\resources\1. Hearing\1. Are there some sounds that you don't like_\8 Sudden loud noises (e.g., balloons popping).jpg");
            topMiddleReadOutLoudPath = @"..\..\resources\1. Hearing\1. Are there some sounds that you don't like_\1.1.8SuddenLoudNoises.wav";

            //topRightPB.Image = new Bitmap(@"..\..\resources\1. Hearing\1. Are there some sounds that you don't like_\loud_voices.PNG");
            //bottomLeftPB.Image = new Bitmap(@"..\..\resources\1. Hearing\1. Are there some sounds that you don't like_\household_ appliances.PNG");
            // bottomMidPB.Image = new Bitmap(@"..\..\resources\");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\");
            updateLabelText("Sirens, alarms, school bells", "Sudden loud noises (e.g., balloons popping)", "", "", "", "");
        }

        private void interviewPage2()
        {
            panel2lblQuestion.Text = "Are there some sounds that s/he doesn't like?";
            lblQuestion1.Text = "Are there sounds that bother him/her more than most people?";
            lblQuestion2.Text = "Does s/he do anything to avoid these sounds (e.g., covers his/her ears, avoids noisy places)?";
        }

        private void interviewPage3()
        {
            lblQuestion.Text = "Are there times when it is hard for him/her to listen?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\1. Hearing\2. Are there times when it is hard to listen_\1 If I am concentrating on something, I don't notice people talking to me.png");
            topMidPB.Image = new Bitmap(@"..\..\resources\1. Hearing\2. Are there times when it is hard to listen_\2 I find it hard to listen in noisy classrooms (self-report version).jpg");
            topRightPB.Image = new Bitmap(@"..\..\resources\1. Hearing\2. Are there times when it is hard to listen_\3 I find it hard to listen to someone talking to me when I'm in a group.jpg");
            //bottomLeftPB.Image = new Bitmap(@"../../resources/");
            //bottomMidPB.Image = new Bitmap(@"../../resources/");
            //bottomRightPB.Image = new Bitmap(@"../../resources/");
            updateLabelText("If s/he is concentrating on something, s/he doesn't notice people talking to him/her",
                "S/he finds it hard to listen to the teacher in noisy classrooms",
                "S/he finds it hard to listen to someone talking to him/her when s/he is in a group",
                "",
                "",
                "");
        }

        private void interviewPage4()
        {
            panel2lblQuestion.Text = "Are there times when it is hard for him/her to listen?";
            lblQuestion1.Text = "Does s/he have more difficulty listening than most people (e.g., listening to people talking to him/her)?";
            lblQuestion2.Text = "";
            tbAnswer2.Visible = false;
        }

        private void interviewPage5()
        {
            lblQuestion.Text = "Are there some sounds that make it hard for him/her to concentrate?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\1. Hearing\3. Are there some sounds that make it hard for you to concentrate_\1 Radio on.jpg");
            topMidPB.Image = new Bitmap(@"..\..\resources\1. Hearing\3. Are there some sounds that make it hard for you to concentrate_\2 Clock ticking.jpg");
            topRightPB.Image = new Bitmap(@"..\..\resources\1. Hearing\3. Are there some sounds that make it hard for you to concentrate_\3 People talking.png");
            //bottomLeftPB.Image = new Bitmap(@"../../resources/");
            //bottomMidPB.Image = new Bitmap(@"../../resources/");
            //bottomRightPB.Image = new Bitmap(@"../../resources/");
            updateLabelText("Radio on", "Clock ticking", "People talking", "", "", "");
        }

        private void interviewPage6()
        {
            panel2lblQuestion.Text = "Are there some sounds that make it hard for him/her to concentrate?";
            lblQuestion1.Text = "Are there noises that s/he finds very distracting when s/he has a job to do?";
            lblQuestion2.Text = "Does noise ever make it hard for him/her to do things (e.g., work in the classroom, go to shopping centres)?";
        }

        private void interviewPage7()
        {
            lblQuestion.Text = "Are there some sounds that s/he likes to listen to?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\1. Hearing\4. Are there sounds that you like to listen to_\1 Computer sounds.jpg");
            topMidPB.Image = new Bitmap(@"..\..\resources\1. Hearing\4. Are there sounds that you like to listen to_\2 Live Music.jpg");
            topRightPB.Image = new Bitmap(@"..\..\resources\1. Hearing\4. Are there sounds that you like to listen to_\3 Fans.PNG");
            bottomLeftPB.Image = new Bitmap(@"..\..\resources\1. Hearing\4. Are there sounds that you like to listen to_\4 Music through my phone (cropped).jpg");
            bottomMidPB.Image = new Bitmap(@"..\..\resources\1. Hearing\4. Are there sounds that you like to listen to_\5 Rhythms.jpg");
            //bottomRightPB.Image = new Bitmap(@"../../resources/");
            updateLabelText("Computer sounds", "Live music", "Fans", "Music through his/her phone", "Rhythms", "");
        }

        private void interviewPage8()
        {
            panel2lblQuestion.Text = "Are there some sounds that s/he likes to listen to?";
            lblQuestion1.Text = "Are there sounds that s/he likes to listen to often or for long periods?";
            lblQuestion2.Text = "";
            tbAnswer2.Visible = false;
        }

        private void interviewPage9()
        {
            lblQuestion.Text = "Are there some sounds that s/he makes a lot?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\1. Hearing\5. Are there some sounds that you make a lot_\1 Humming or Whistling to myself.jpg");
            topMidPB.Image = new Bitmap(@"..\..\resources\1. Hearing\5. Are there some sounds that you make a lot_\2 Tapping feet.PNG");
            topRightPB.Image = new Bitmap(@"..\..\resources\1. Hearing\5. Are there some sounds that you make a lot_\3 Tapping fingers.jpg");
            bottomLeftPB.Image = new Bitmap(@"..\..\resources\1. Hearing\5. Are there some sounds that you make a lot_\4 Clicking pen.jpg");
            //bottomMidPB.Image = new Bitmap(@"");
            //bottomRightPB.Image = new Bitmap(@"../../resources/");
            updateLabelText("Humming or whistling to himself/herself", "Tapping feet", "Tapping fingers", "Clicking pen",
                "", "");
        }

        private void interviewPage10()
        {
            panel2lblQuestion.Text = "Are there some sounds that you make a lot?";
            lblQuestion1.Text = "Does s/he make these sounds more often than most people?";
            lblQuestion2.Text = "Do the sounds s/he makes bother other people?";
        }

        /// <summary>
        /// Sight
        /// </summary>
        private void sightInterviewPage1()
        {
            lblQuestion.Text = "Are there some things that s/he doesn't like to look at?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\2. Sight\1. Are there some things that you don't like to look at_\1 Sunlight.jpg");
            topMidPB.Image = new Bitmap(@"..\..\resources\2. Sight\1. Are there some things that you don't like to look at_\2 Fluorescent light.png");
            topRightPB.Image = new Bitmap(@"..\..\resources\2. Sight\1. Are there some things that you don't like to look at_\3 Light and Shadow.jpg");
            bottomLeftPB.Image = new Bitmap(@"..\..\resources\2. Sight\1. Are there some things that you don't like to look at_\4 Busy Patterns.jpg");
            bottomMidPB.Image = new Bitmap(@"..\..\resources\2. Sight\1. Are there some things that you don't like to look at_\5 Lecture room light (self version) (cropped).jpg");
            updateLabelText("Sunlight", "Fluorescent light", "Light and shadow", "Busy patterns",
                "Lecture room light", "");
        }

        private void sightInterviewPage2()
        {
            panel2lblQuestion.Text = "Are there some things that s/he doesn't like to look at?";
            lblQuestion1.Text = "Are there things s/he sees that bother him/her more than most people?";
            lblQuestion2.Text = "Does s/he do anything to avoid these things (e.g., shades his/her eyes, wears sunglasses, avoids fluorescent light)?";
        }

        private void sightInterviewPage3()
        {
            lblQuestion.Text = "Are there some things s/he sees that make it hard to concentrate?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\2. Sight\2. Are there some things you see that make it hard to concentrate_\1 Lots of things in a messy drawer.jpg");
            topMidPB.Image = new Bitmap(@"..\..\resources\2. Sight\2. Are there some things you see that make it hard to concentrate_\2 People running around me.jpg");
            topRightPB.Image = new Bitmap(@"..\..\resources\2. Sight\2. Are there some things you see that make it hard to concentrate_\3 Lots of clutter in an office space (self report).jpg");
            // bottomLeftPB.Image = new Bitmap(@"..\..\resources\2. Sight\1. Are there some things that you don't like to look at_\");
            //bottomMidPB.Image = new Bitmap(@"..\..\resources\2. Sight\1. Are there some things that you don't like to look at_\");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\2. Sight\1. Are there some things that you don't like to look at_\");
            updateLabelText("Lots of things in a messy drawer", "People running around him/her", "Lots of clutter in an office or work space", "", "", "");
        }

        private void sightInterviewPage4()
        {
            panel2lblQuestion.Text = "Are there some things s/he sees that make it hard to concentrate?";
            lblQuestion1.Text = "Does s/he seem to get distracted by things s/he sees more than most people ? ";
            lblQuestion2.Text = "";
            tbAnswer2.Visible = false;
        }

        private void sightInterviewPage5()
        {
            lblQuestion.Text = "Are there some things that s/he likes to look at?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\2. Sight\3. Are there some things that you like to look at_\1 Moving lights.jpg");
            topMidPB.Image = new Bitmap(@"..\..\resources\2. Sight\3. Are there some things that you like to look at_\2 Things that sparkle.png");
            topRightPB.Image = new Bitmap(@"..\..\resources\2. Sight\3. Are there some things that you like to look at_\3 Geometric patterns.jpg");
            bottomLeftPB.Image = new Bitmap(@"..\..\resources\2. Sight\3. Are there some things that you like to look at_\4 Spinning fans.png");
            bottomMidPB.Image = new Bitmap(@"..\..\resources\2. Sight\3. Are there some things that you like to look at_\5 Spinning objects1 (use this one) (cropped).jpg");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\2. Sight\3. Are there some things that you don't like to look at_\");
            updateLabelText("Moving lights", "Things that sparkle", "Geometric patterns", "Spinning fans", "Spinning objects", "");
        }

        private void sightInterviewPage6()
        {
            panel2lblQuestion.Text = "Are there some things that s/he likes to look at?";
            lblQuestion1.Text = "Are there things s/he looks at often or for long periods?";
            lblQuestion2.Text = "";
            tbAnswer2.Visible = false;
        }

        /// <summary>
        /// Touch
        /// </summary>
        private void touchInterviewPage1()
        {
            lblQuestion.Text = "Are there some things that s/he doesn't like the feeling of?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\1 Sandy.jpg");
            topMidPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\2 Sticky.jpg");
            topRightPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\3 Grassy.jpg");
            bottomLeftPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\4 Wool clothes.jpg");
            bottomMidPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\5 Tight clothes.jpg");
            bottomRightPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\6 Stiff clothes.jpg");
            updateLabelText("Sandy", "Sticky", "Grassy", "Wool clothes",
                "Tight clothes", "Stiff clothes");
        }

        private void touchInterviewPage1p2()
        {
            lblQuestion.Text = "Are there some things that s/he doesn't like the feeling of?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\7 Shoes.jpg");
            topMidPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\8 Splashing Water (cropped).jpg");
            //topRightPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\Geometric patterns.jpg");
            //bottomLeftPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\.jpg");
            //bottomMidPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\Spinning objects.jpg");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\");
            updateLabelText("Shoes", "Splashing water (e.g. rain, shower, pool)", "", "",
                "", "");
        }

        /// <summary>
        /// make sure this page formats correctly on load
        /// </summary>
        private void touchInterviewPage2()
        {
            panel2lblQuestion.Text = "Are there some things that s/he doesn't like the feeling of?";
            lblQuestion1.Text = "Are there touch sensations that bother him/her more than most people?";
            lblQuestion2.Text = "Do touch sensations ever make it hard for him/her to do things (e.g., wear school uniform or walk on the grass)?";

            lblQuestion1.Location = new Point(328, 194);
            tbAnswer1.Location = new Point(304, 285);
            lblQuestion2.Location = new Point(328, 416);
            tbAnswer2.Location = new Point(304, 513);

            Label lblQuestion3 = new Label();
            lblQuestion3.Location = new Point(328, 649);
            lblQuestion3.Text = "Does s/he do anything to avoid these things (e.g., avoids certain clothes or textures)?";
            Label lblAnswer3 = new Label();
            lblAnswer3.Location = new Point(304, 738);
            lblAnswer3.Size = new Size(693, 120);
        }

        private void touchInterviewPage3()
        {
            lblQuestion.Text = "Are there some ways that people touch him/her that h/she doesn't like?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\3. Touch\2. Are there ways that people touch you that you don't like_\1 Being hugged or kissed (cropped).jpg");
            topMidPB.Image = new Bitmap(@"..\..\resources\3. Touch\2. Are there ways that people touch you that you don't like_\2 Being crowded (cropped).jpg");
            topRightPB.Image = new Bitmap(@"..\..\resources\3. Touch\2. Are there ways that people touch you that you don't like_\3 Being tapped on the shoulder (self-report version).jpg");
            bottomLeftPB.Image = new Bitmap(@"..\..\resources\3. Touch\2. Are there ways that people touch you that you don't like_\4 Having sunscreen put on.jpg");
            bottomMidPB.Image = new Bitmap(@"..\..\resources\3. Touch\2. Are there ways that people touch you that you don't like_\5 Being bumped.jpg");
            bottomRightPB.Image = new Bitmap(@"..\..\resources\3. Touch\2. Are there ways that people touch you that you don't like_\6 Having a haircut (cropped).jpg");
            updateLabelText("Being hugged or kissed", "Being crowded", "Being tapped on the shoulder", "Having sunscreen put on",
                "Being bumped", "Having a haircut");
        }

        private void touchInterviewPage3p2()
        {
            lblQuestion.Text = "Are there some ways that people touch him/her that s/he doesn't like?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\3. Touch\2. Are there ways that people touch you that you don't like_\7 Doctor touching me.jpg");
            topMidPB.Image = new Bitmap(@"..\..\resources\3. Touch\2. Are there ways that people touch you that you don't like_\8 Dentist touching me (cropped).jpg");
            //topRightPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there things that you don't like the feeling of_\Geometric patterns.jpg");
            //bottomLeftPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there things that you don't like the feeling of_\.jpg");
            //bottomMidPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there things that you don't like the feeling of_\Spinning objects.jpg");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there things that you don't like the feeling of_\");
            updateLabelText("Doctor touching him/her", "Dentist touch him/her", "", "",
                "", "");
        }

        /// <summary>
        /// make sure this page formats correctly on load
        /// </summary>
        private void touchInterviewPage4()
        {
            panel2lblQuestion.Text = "Are there some ways that people touch him/her that s/he doesn't like?";
            lblQuestion1.Text = "Are there times when being touched bothers him/her more than most people?";
            lblQuestion2.Text = "Does difficulty coping with being touched make it hard for him/her to do things(e.g., visit the doctor or the dentist)?";

            lblQuestion1.Location = new Point(328, 194);
            tbAnswer1.Location = new Point(304, 285);
            lblQuestion2.Location = new Point(328, 416);
            tbAnswer2.Location = new Point(304, 513);

            Label lblQuestion3 = new Label();
            lblQuestion3.Location = new Point(328, 649);
            lblQuestion3.Text = "Does s/he do anything to avoid being touched (e.g., avoids crowded places)?";
            Label lblAnswer3 = new Label();
            lblAnswer3.Location = new Point(304, 738);
            lblAnswer3.Size = new Size(693, 120);
        }

        private void touchInterviewPage5()
        {
            lblQuestion.Text = "Are there some things that s/he likes the feeling of?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\3. Touch\3. Are there some things that you like the feeling of_\1 Soft.jpg");
            topMidPB.Image = new Bitmap(@"..\..\resources\3. Touch\3. Are there some things that you like the feeling of_\2 Rubbery.jpg");
            topRightPB.Image = new Bitmap(@"..\..\resources\3. Touch\3. Are there some things that you like the feeling of_\3 Furry.jpg");
            bottomLeftPB.Image = new Bitmap(@"..\..\resources\3. Touch\3. Are there some things that you like the feeling of_\4 Hugging people.jpg");
            bottomMidPB.Image = new Bitmap(@"..\..\resources\3. Touch\3. Are there some things that you like the feeling of_\5 Touching people.jpg");
            bottomRightPB.Image = new Bitmap(@"..\..\resources\3. Touch\3. Are there some things that you like the feeling of_\6 Being squashed with a pillow.jpg");
            updateLabelText("Soft", "Rubbery", "Furry", "Hugging people",
                "Touching people", "Being squashed with a pillow");
        }

        private void touchInterviewPage6()
        {
            panel2lblQuestion.Text = "Are there some things that s/he likes the feeling of?";
            lblQuestion1.Text = "Are there things that h/she likes to touch often or for long periods?";
            lblQuestion2.Text = "";
            tbAnswer2.Visible = false;
        }

        /// <summary>
        /// Smell
        /// </summary>
        private void smellInterviewPage1()
        {
            lblQuestion.Text = "Are there some smells that s/he don't like?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\4. Smells\1. Are there some smells that you don't like_\1 Cooking smells (cropped).jpg");
            topMidPB.Image = new Bitmap(@"..\..\resources\4. Smells\1. Are there some smells that you don't like_\2 Food Smells.jpg");
            topRightPB.Image = new Bitmap(@"..\..\resources\4. Smells\1. Are there some smells that you don't like_\3 Cleaning products.jpg");
            bottomLeftPB.Image = new Bitmap(@"..\..\resources\4. Smells\1. Are there some smells that you don't like_\4 Toilet Smells.jpg");
            bottomMidPB.Image = new Bitmap(@"..\..\resources\4. Smells\1. Are there some smells that you don't like_\5 Perfumes.jpg");
            bottomRightPB.Image = new Bitmap(@"..\..\resources\4. Smells\1. Are there some smells that you don't like_\6 Body smells (cropped).jpg");
            updateLabelText("Cooking smells", "Food smells", "Cleaning products",
                "Toilet smells", "Perfumes", "Body smells");
        }

        private void smellInterviewPage2()
        {
            panel2lblQuestion.Text = "Are there some smells that s/he don't like?";
            lblQuestion1.Text = "Are there smells that bother him/her more than most people?";
            lblQuestion2.Text = "Does s/he do anything to avoid these smells (e.g., avoids public toilets or cleaning products aisles at the supermarket)?";
        }

        private void smellInterviewPage3()
        {
            lblQuestion.Text = "Are there some things that s/he likes to smell?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\4. Smells\2. Are there some things that you like to smell_\1 Smelling foods (cropped).jpg");
            topMidPB.Image = new Bitmap(@"..\..\resources\4. Smells\2. Are there some things that you like to smell_\2 Smelling plants.jpg");
            topRightPB.Image = new Bitmap(@"..\..\resources\4. Smells\2. Are there some things that you like to smell_\3 Smelling perfume.jpg");
            bottomLeftPB.Image = new Bitmap(@"..\..\resources\4. Smells\2. Are there some things that you like to smell_\4 Smelling soap.jpg");
            bottomMidPB.Image = new Bitmap(@"..\..\resources\4. Smells\2. Are there some things that you like to smell_\5 Smelling people.jpg");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\4. Smells\1. Are there some that you don't like_\Body smells.jpg");
            updateLabelText("Smelling foods", "Smelling plants", "Smelling perfume",
                "Smelling soap", "Smelling people", "");
        }

        private void smellInterviewPage4()
        {
            panel2lblQuestion.Text = "Are there some things that s/he like to smell?";
            lblQuestion1.Text = "Are there things that s/he likes to smell often or for long periods?";
            lblQuestion2.Text = "";
            tbAnswer2.Visible = false;
        }

        /// <summary>
        /// taste
        /// </summary>
        private void tasteInterviewPage1()
        {
            lblQuestion.Text = "Are there some food groups that s/he doesn't like eating?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\1 Vegetables.png");
            topMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\2 Fruit.png");
            topRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\3 Meat.jpg");
            bottomLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\4 Fish.jpg");
            bottomMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\5 Eggs.jpg");
            bottomRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\6 Dairy.png");
            updateLabelText("Vegetables", "Fruit", "Meat", "Fish", "Eggs", "Dairy");
        }

        private void tasteInterviewPage1p2()
        {
            lblQuestion.Text = "Are there some food groups that s/he doesn't like eating?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\7 Bread.jpg");
            topMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\8 Pasta.jpg");
            //topRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some that you don't like_\Geometric patterns.jpg");
            //bottomLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Fish.jpg");
            //bottomMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some that you don't like_\Spinning objects.jpg");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Dairy.jpg");
            updateLabelText("Bread", "Pasta", "", "", "", "");
        }

        private void tasteInterviewPage2()
        {
            panel2lblQuestion.Text = "Are there some food groups that s/he doesn't like eating?";
            lblQuestion1.Text = "Are there food groups that most people eat that s/he hates?";
            lblQuestion2.Text = "Does s/he eat a smaller variety of food groups than most people?";
        }

        private void tasteInterviewPage3()
        {
            lblQuestion.Text = "Are there some ways that food tastes or feels in his/her mouth that s/he doesn't like?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\2. Are there some ways that food tastes or feels in your mouth that you don't like_\1 Lumpy.jpg");
            topMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\2. Are there some ways that food tastes or feels in your mouth that you don't like_\2 Chewy.jpg");
            topRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\2. Are there some ways that food tastes or feels in your mouth that you don't like_\3 Runny slippery (cropped).jpg");
            bottomLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\2. Are there some ways that food tastes or feels in your mouth that you don't like_\4 Mixed.JPG");
            bottomMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\2. Are there some ways that food tastes or feels in your mouth that you don't like_\5 Sweet.jpg");
            bottomRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\2. Are there some ways that food tastes or feels in your mouth that you don't like_\6 Sour.png");
            updateLabelText("Lumpy", "Chewy", "Runny/Slippery", "Mixed", "Sweet", "Sour");
        }
        private void tasteInterviewPage3p2()
        {
            lblQuestion.Text = "Are there some ways that food tastes or feels in his/her mouth that s/he doesn't like?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\2. Are there some ways that food tastes or feels in your mouth that you don't like_\7 Salty (cropped).jpg");
            topMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\2. Are there some ways that food tastes or feels in your mouth that you don't like_\8 Spicy.jpg");
            //topRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some that you don't like_\Geometric patterns.jpg");
            //bottomLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Fish.jpg");
            //bottomMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some that you don't like_\Spinning objects.jpg");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Dairy.jpg");
            updateLabelText("Salty", "Spicy", "", "", "", "");
        }

        private void tasteInterviewPage4()
        {
            panel2lblQuestion.Text = "Are there some ways that food tastes or feels in his/her mouth that s/he doesn't like?";
            lblQuestion1.Text = "Are there tastes and textures of food that most people eat that s/he hates?";
            lblQuestion2.Text = "Does s/he eat a smaller variety of tastes and textures than most people?";

            lblQuestion1.Location = new Point(328, 194);
            tbAnswer1.Location = new Point(304, 285);
            lblQuestion2.Location = new Point(328, 416);
            tbAnswer2.Location = new Point(304, 513);

            Label lblQuestion3 = new Label();
            lblQuestion3.Location = new Point(328, 649);
            lblQuestion3.Text = "Does s/he do anything to avoid eating certain foods (e.g., avoids eating in restaurants or at other people’s homes)?";
            Label lblAnswer3 = new Label();
            lblAnswer3.Location = new Point(304, 738);
            lblAnswer3.Size = new Size(693, 120);
        }

        private void tasteInterviewPage5()
        {
            lblQuestion.Text = "Are there some things that you really like to eat?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\3. Are there some things you really like to eat_\1 Familiar foods, only a few types of foods (i.e, I don’t like trying new foods)1 (cropped).jpg");
            topMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\3. Are there some things you really like to eat_\1 Familiar foods, only a few types of foods (i.e, I don’t like trying new foods)2.jpg");
            //topRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some that you don't like_\Geometric patterns.jpg");
            bottomLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\3. Are there some things you really like to eat_\2 Unfamiliar foods, lots of different types of foods (i.e., I like trying new foods)1.jpg");
            bottomMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\3. Are there some things you really like to eat_\2 Unfamiliar foods, lots of different types of foods (i.e., I like trying new foods)2.jpg");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Dairy.jpg");
            updateLabelText("", "Familiar foods, only a few types of foods (e.g., I don’t like trying new foods)", "", "",
                "Unfamiliar foods, lots of different types of foods (e.g., I like trying new foods)", "");
        }

        private void tasteInterviewPage6()
        {
            panel2lblQuestion.Text = "Are there some things that s/he really likes to eat?";
            lblQuestion1.Text = "Are there certain types of foods that s/he craves and wants to eat repeatedly?";
            lblQuestion2.Text = "";
            tbAnswer2.Visible = false;
        }

        private void tasteInterviewPage7()
        {
            lblQuestion.Text = "Are there some things that s/he puts in his/her mouth a lot?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\4. Are there some things that you put in your mouth a lot_\1 Shirt.jpg");
            topMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\4. Are there some things that you put in your mouth a lot_\2 Hair.jpg");
            topRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\4. Are there some things that you put in your mouth a lot_\3 Objects.jpg");
            //bottomLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Fish.jpg");
            //bottomMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some that you don't like_\Spinning objects.jpg");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Dairy.jpg");
            updateLabelText("Shirt", "Hair", "Objects", "", "", "");
        }

        private void tasteInterviewPage8()
        {
            panel2lblQuestion.Text = "Are there some things that s/he puts in his/her mouth a lot?";
            lblQuestion1.Text = "Are there things that s/he often puts in his/her mouth? Are any of them dangerous or unhygienic?";
            lblQuestion2.Text = "Does s/he put things in his/her mouth more than most people?";
        }

        /// <summary>
        /// Movement
        /// </summary>
        private void mvmtInterviewPage1()
        {
            lblQuestion.Text = "Are there some ways of moving that s/he doesn't like?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\6. Movement\1. Are there some ways of moving that you don’t like_\1 Being jumped on_tackled.jpg");
            topMidPB.Image = new Bitmap(@"..\..\resources\6. Movement\1. Are there some ways of moving that you don’t like_\2 Moving when I can't see where I am going (self-report) (cropped).jpg");
            topRightPB.Image = new Bitmap(@"..\..\resources\6. Movement\1. Are there some ways of moving that you don’t like_\3 Balancing (self-report) (cropped).jpg");
            bottomLeftPB.Image = new Bitmap(@"..\..\resources\6. Movement\1. Are there some ways of moving that you don’t like_\4 Being upside down (cropped).jpg");
            bottomMidPB.Image = new Bitmap(@"..\..\resources\6. Movement\1. Are there some ways of moving that you don’t like_\5 Climbing up high (cropped).jpg");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Dairy.jpg");
            updateLabelText("Being jumped on/tackled", "Moving when s/he can't see where s/he is going", "Balancing", "Being upside down", "Climbing up high", "");
        }

        private void mvmtInterviewPage2()
        {
            panel2lblQuestion.Text = "Are there some ways of moving that s/he doesn’t like?";
            lblQuestion1.Text = "Are there movement experiences that s/he finds scary or unpleasant?";
            lblQuestion2.Text = "Do s/he do anything to avoid these movements?";
        }

        private void mvmtInterviewPage3()
        {
            lblQuestion.Text = "Are there times when it is hard for s/he to stay still?";
            //topLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\lumpy.jpg");
            topMidPB.Image = new Bitmap(@"..\..\resources\6. Movement\2. Are there times when it is hard for you to stay still_\1 Sitting Still (self report)(cropped).jpg");
            //topRightPB.Image = new Bitmap(@"..\..\");
            //bottomLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Fish.jpg");
            bottomMidPB.Image = new Bitmap(@"..\..\resources\6. Movement\2. Are there times when it is hard for you to stay still_\2 Standing Still (self-report).jpg");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Dairy.jpg");
            updateLabelText("", "Sitting Still", "", "", "Standing still", "");
        }

        private void mvmtInterviewPage4()
        {
            panel2lblQuestion.Text = "Are there times when it is hard for s/he to stay still?";
            lblQuestion1.Text = "Does s/he find it harder to stay still than most people?";
            lblQuestion2.Text = "";
            tbAnswer2.Visible = false;
        }

        private void mvmtInterviewPage5()
        {
            lblQuestion.Text = "Are there some ways of moving that s/he likes?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\6. Movement\3. Are there ways of moving that you like_\1 Moving in Water.jpg");
            topMidPB.Image = new Bitmap(@"..\..\resources\6. Movement\3. Are there ways of moving that you like_\2 Swinging (cropped).jpg");
            topRightPB.Image = new Bitmap(@"..\..\resources\6. Movement\3. Are there ways of moving that you like_\3 Spinning (self report) (uncropped).jpeg");
            bottomLeftPB.Image = new Bitmap(@"..\..\resources\6. Movement\3. Are there ways of moving that you like_\4 Jumping on the Trampoline (guided and self report) (cropped).jpg");
            bottomMidPB.Image = new Bitmap(@"..\..\resources\6. Movement\3. Are there ways of moving that you like_\5 Running (self-report) (cropped).jpg");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Dairy.jpg");
            updateLabelText("Moving in water", "Swinging", "Spinning", "Jumping on the trampoline", "Running", "");
        }

        private void mvmtInterviewPage6()
        {
            panel2lblQuestion.Text = "Are there some ways of moving that s/he likes?";
            lblQuestion1.Text = "Are there ways of moving that s/he does more than most people?";
            lblQuestion2.Text = "";
            tbAnswer2.Visible = false;
        }

        private void mvmtInterviewPage7()
        {
            lblQuestion.Text = "Are there some ways that s/he moves over and over again?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\6. Movement\4. Are there some ways that you move over and over again_\1 Rocking.png");
            topMidPB.Image = new Bitmap(@"..\..\resources\6. Movement\4. Are there some ways that you move over and over again_\2 Moving hands.jpg");
            topRightPB.Image = new Bitmap(@"..\..\resources\6. Movement\4. Are there some ways that you move over and over again_\3 Clapping.jpg");
            bottomLeftPB.Image = new Bitmap(@"..\..\resources\6. Movement\4. Are there some ways that you move over and over again_\4 Pacing.PNG");
            //bottomMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some that you don't like_\Spinning objects.jpg");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Dairy.jpg");
            updateLabelText("Rocking", "Moving hands", "Clapping", "Pacing", "", "");
        }

        private void mvmtInterviewPage8()
        {
            panel2lblQuestion.Text = "Are there some ways that s/he moves over and over again?";
            lblQuestion1.Text = "Are there movements that s/he makes repeatedly when s/he is anxious?";
            lblQuestion2.Text = "Are there movements that s/he makes repeatedly when s/he is excited?";
        }

        /// <summary>
        /// Environment
        /// </summary>
        private void environmentPage1()
        {
            lblQuestion.Text = "Are there some places with lots of things happening at once that s/he doesn't like?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\7. Environment\1. Are there some places\1 Supermarket.png");
            topMidPB.Image = new Bitmap(@"..\..\resources\7. Environment\1. Are there some places\2 Party (self report)(cropped).jpg");
            topRightPB.Image = new Bitmap(@"..\..\resources\7. Environment\1. Are there some places\3 Food Hall.jpg");
            bottomLeftPB.Image = new Bitmap(@"..\..\resources\7. Environment\1. Are there some places\4 Show (cropped).jpg");
            bottomMidPB.Image = new Bitmap(@"..\..\resources\7. Environment\1. Are there some places\5 Shopping mall.png");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Dairy.jpg");
            updateLabelText("Supermarket", "Party", "Food hall", "Show", "Shopping mall", "");
        }

        private void environmentPage2()
        {
            panel2lblQuestion.Text = "Are there some places with lots of things happening at once that s/he doesn’t like? (e.g., places with lots of noise, bright lights and people)";
            lblQuestion1.Text = "How does s/he react to places with lots of things happening at once?";
            lblQuestion2.Text = "Does s/he do anything to avoid places with lots of things happening at once?";
        }

        /// <summary>
        /// Other
        /// </summary>
        private void otherInterviewPage1()
        {
            lblQuestion.Text = "Are there any other sensations that s/he feels strongly about?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\8. Other\1 Sounds.png");
            topMidPB.Image = new Bitmap(@"..\..\resources\8. Other\2 Smells.PNG");
            topRightPB.Image = new Bitmap(@"..\..\resources\8. Other\3 Sights.png");
            bottomLeftPB.Image = new Bitmap(@"..\..\resources\8. Other\4 Tastes.png");
            bottomMidPB.Image = new Bitmap(@"..\..\resources\8. Other\5 Feelings.jpg");
            bottomRightPB.Image = new Bitmap(@"..\..\resources\8. Other\6 Movements (cropped).jpg");
            updateLabelText("Sounds", "Smells", "Sights", "Tastes", "Feelings", "Movements");
        }

        private void otherInterviewPage2()
        {
            panel2lblQuestion.Text = "Are there any other sensations that s/he feels strongly about?";
            lblQuestion1.Text = "How does s/he react to these other things??";
            lblQuestion2.Text = "Does s/he do anything to avoid these other things?";
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
            } else if (page1Selections[index] == "A Lot") {
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
        string userID = Globals.userID;
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
        private void writeToDB(string TLImageName, string TMImageName, string TRImageName, string BLImageName, string BMImageName, string BRImageName, string tableDBName) {

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
                       BMImageName + "," + BRImageName + ", ID) VALUES (@tl, @tm, @tr, @bl, @bm, @br, @userID);";

                cmdDatabase = new SqlCommand(query, conDatabase);
                cmdDatabase.Parameters.AddWithValue("@tl", page1Selections[0]);
                cmdDatabase.Parameters.AddWithValue("@tm", page1Selections[1]);
                cmdDatabase.Parameters.AddWithValue("@tr", page1Selections[2]);
                cmdDatabase.Parameters.AddWithValue("@bl", page1Selections[3]);
                cmdDatabase.Parameters.AddWithValue("@bm", page1Selections[4]);
                cmdDatabase.Parameters.AddWithValue("@br", page1Selections[5]);
                cmdDatabase.Parameters.AddWithValue("@userID", userID);
                cmdDatabase.ExecuteNonQuery();
            } catch (Exception err) {
                MessageBox.Show("An Error has occurred while writing to the database: " + err.Message);
            }

        }

        private void writeToDBTop3(string TLImageName, string TMImageName, string TRImageName, string dbTableName) {

            const string constring = @"Data Source =(LocalDB)\MSSQLLocalDB;" +
                        @"AttachDbFilename = |DataDirectory|\CapstoneDB\CapstoneDB.mdf; Integrated Security = True";
            SqlConnection conDatabase = new SqlConnection(constring);

            SqlCommand cmdDatabase;
            //Determine if a little or a lot
            try {
                conDatabase.Open();
                string query = "INSERT INTO dbo." + dbTableName + "(" + TLImageName + "," + TMImageName + "," +
                         TRImageName + ", ID) VALUES (@tl, @tm, @tr, @userID);";

                //"UPDATE dbo" + dbTableName + "SET " + TLImageName + "=@tl," + TMImageName +"=@tm," + TRImageName + "=@tr;";
                cmdDatabase = new SqlCommand(query, conDatabase);
                cmdDatabase.Parameters.AddWithValue("@tl", page1Selections[0]);
                cmdDatabase.Parameters.AddWithValue("@tm", page1Selections[1]);
                cmdDatabase.Parameters.AddWithValue("@tr", page1Selections[2]);
                cmdDatabase.Parameters.AddWithValue("@userID", userID);
                cmdDatabase.ExecuteNonQuery();
            } catch (Exception err) {
                MessageBox.Show("An Error has occurred while writing to the database: " + err.Message);
            }
        }

        private void writeToDBTop2(string TLImageName, string TMImageName, string dbTableName) {

            const string constring = @"Data Source =(LocalDB)\MSSQLLocalDB;" +
                        @"AttachDbFilename = |DataDirectory|\CapstoneDB\CapstoneDB.mdf; Integrated Security = True";
            SqlConnection conDatabase = new SqlConnection(constring);

            SqlCommand cmdDatabase;
            //Determine if a little or a lot
            try {
                conDatabase.Open();
                string query = "INSERT INTO dbo." + dbTableName + "(" + TLImageName + "," + TMImageName + ", ID) VALUES (@tl, @tm, @userID);";
                cmdDatabase = new SqlCommand(query, conDatabase);
                cmdDatabase.Parameters.AddWithValue("@tl", page1Selections[0]);
                cmdDatabase.Parameters.AddWithValue("@tm", page1Selections[1]);
                cmdDatabase.Parameters.AddWithValue("@userID", userID);
                cmdDatabase.ExecuteNonQuery();
            } catch (Exception err) {
                MessageBox.Show("An Error has occurred while writing to the database: " + err.Message);

            }
        }

        /// <summary>
        /// Updates database if the question has more than 6 images, but max 8
        /// </summary>
        /// <param name="TLImageName"></param>
        /// <param name="TMImageName"></param>
        /// <param name="dbTableName"></param>
        private void updateDB(string TLImageName, string TMImageName, string dbTableName) {
            const string constring = @"Data Source =(LocalDB)\MSSQLLocalDB;" +
                        @"AttachDbFilename = |DataDirectory|\CapstoneDB\CapstoneDB.mdf; Integrated Security = True";
            SqlConnection conDatabase = new SqlConnection(constring);
            SqlCommand cmdDatabase;
            try {
                conDatabase.Open();
                string query = @"UPDATE dbo.dislikeSounds SET " + TLImageName + "=@tl, "
                    + TMImageName + "=@tm, ID = @userID WHERE interviewNumber = (SELECT MAX(interviewNumber) FROM dbo.dislikeSounds);";
                cmdDatabase = new SqlCommand(query, conDatabase);
                cmdDatabase.Parameters.AddWithValue("@tl", page1Selections[0]);
                cmdDatabase.Parameters.AddWithValue("@tm", page1Selections[1]);
                cmdDatabase.Parameters.AddWithValue("@userID", userID);
                cmdDatabase.ExecuteNonQuery();
                conDatabase.Close();
            } catch (Exception ex) {
                MessageBox.Show("An Error has occurred while writing to the database: " + ex.Message);
            }
        }

        private void updateDBdontLikeFeelingOf(string TLImageName, string TMImageName, string dbTableName) {
            const string constring = @"Data Source =(LocalDB)\MSSQLLocalDB;" +
                        @"AttachDbFilename = |DataDirectory|\CapstoneDB\CapstoneDB.mdf; Integrated Security = True";
            SqlConnection conDatabase = new SqlConnection(constring);
            SqlCommand cmdDatabase;
            try {
                conDatabase.Open();
                string query = @"UPDATE dbo.dontLikeFeelingOf SET " + TLImageName + "=@tl, "
                    + TMImageName + "=@tm, ID = @userID WHERE interviewNumber = (SELECT MAX(interviewNumber) FROM dbo.dontLikeFeelingOf);";
                cmdDatabase = new SqlCommand(query, conDatabase);
                cmdDatabase.Parameters.AddWithValue("@tl", page1Selections[0]);
                cmdDatabase.Parameters.AddWithValue("@tm", page1Selections[1]);
                cmdDatabase.Parameters.AddWithValue("@userID", userID);
                cmdDatabase.ExecuteNonQuery();
            } catch (Exception ex) {
                MessageBox.Show("An Error has occurred while writing to the database: " + ex.Message);
            }
        }

        private void updateDBpeopleTouchDontLike(string TLImageName, string TMImageName, string dbTableName) {
            const string constring = @"Data Source =(LocalDB)\MSSQLLocalDB;" +
                        @"AttachDbFilename = |DataDirectory|\CapstoneDB\CapstoneDB.mdf; Integrated Security = True";
            SqlConnection conDatabase = new SqlConnection(constring);
            SqlCommand cmdDatabase;
            try {
                conDatabase.Open();
                string query = @"UPDATE dbo.peopleTouchDontLike SET " + TLImageName + "=@tl, "
                    + TMImageName + "=@tm, ID = @userID WHERE interviewNumber = (SELECT MAX(interviewNumber) FROM dbo.peopleTouchDontLike);";
                cmdDatabase = new SqlCommand(query, conDatabase);
                cmdDatabase.Parameters.AddWithValue("@tl", page1Selections[0]);
                cmdDatabase.Parameters.AddWithValue("@tm", page1Selections[1]);
                cmdDatabase.Parameters.AddWithValue("@userID", userID);
                cmdDatabase.ExecuteNonQuery();
            } catch (Exception ex) {
                MessageBox.Show("An Error has occurred while writing to the database: " + ex.Message);
            }
        }

        private void updateDBfoodGroupsDontLike(string TLImageName, string TMImageName, string dbTableName) {
            const string constring = @"Data Source =(LocalDB)\MSSQLLocalDB;" +
                        @"AttachDbFilename = |DataDirectory|\CapstoneDB\CapstoneDB.mdf; Integrated Security = True";
            SqlConnection conDatabase = new SqlConnection(constring);
            SqlCommand cmdDatabase;
            try {
                conDatabase.Open();
                string query = @"UPDATE dbo.foodGroupsDontLike SET " + TLImageName + "=@tl, "
                    + TMImageName + "=@tm, ID = @userID WHERE interviewNumber = (SELECT MAX(interviewNumber) FROM dbo.foodGroupsDontLike);";
                cmdDatabase = new SqlCommand(query, conDatabase);
                cmdDatabase.Parameters.AddWithValue("@tl", page1Selections[0]);
                cmdDatabase.Parameters.AddWithValue("@tm", page1Selections[1]);
                cmdDatabase.Parameters.AddWithValue("@userID", userID);
                cmdDatabase.ExecuteNonQuery();
            } catch (Exception ex) {
                MessageBox.Show("An Error has occurred while writing to the database: " + ex.Message);
            }
        }

        private void updateDBtastesOrFeelsInMouthDontLike(string TLImageName, string TMImageName, string dbTableName) {
            const string constring = @"Data Source =(LocalDB)\MSSQLLocalDB;" +
                        @"AttachDbFilename = |DataDirectory|\CapstoneDB\CapstoneDB.mdf; Integrated Security = True";
            SqlConnection conDatabase = new SqlConnection(constring);
            SqlCommand cmdDatabase;
            try {
                conDatabase.Open();
                string query = @"UPDATE dbo.tastesOrFeelsInMouthDontLike SET " + TLImageName + "=@tl, "
                    + TMImageName + "=@tm, ID = @userID WHERE interviewNumber = (SELECT MAX(interviewNumber) FROM dbo.tastesOrFeelsInMouthDontLike);";
                cmdDatabase = new SqlCommand(query, conDatabase);
                cmdDatabase.Parameters.AddWithValue("@tl", page1Selections[0]);
                cmdDatabase.Parameters.AddWithValue("@tm", page1Selections[1]);
                cmdDatabase.Parameters.AddWithValue("@userID", userID);
                cmdDatabase.ExecuteNonQuery();
            } catch (Exception ex) {
                MessageBox.Show("An Error has occurred while writing to the database: " + ex.Message);
            }
        }

        private void updateDBother(string TLImageName, string TMImageName, string TRImageName, string BLImageName, string BMImageName, string BRImageName, string dbTableName) {
            const string constring = @"Data Source =(LocalDB)\MSSQLLocalDB;" +
                        @"AttachDbFilename = |DataDirectory|\CapstoneDB\CapstoneDB.mdf; Integrated Security = True";
            SqlConnection conDatabase = new SqlConnection(constring);
            SqlCommand cmdDatabase;
            try {
                conDatabase.Open();
                string query = @"UPDATE dbo.other SET " + TLImageName + "=@tl, "
                    + TMImageName + "=@tm, "
                    + TRImageName + "=@tr, "
                    + BLImageName + "=@bl, "
                    + BMImageName + "=@bm, "
                    + BRImageName + "=@br, ID = @userID WHERE interviewNumber = (SELECT MAX(interviewNumber) FROM dbo.other);";
                cmdDatabase = new SqlCommand(query, conDatabase);
                cmdDatabase.Parameters.AddWithValue("@tl", page1Selections[0]);
                cmdDatabase.Parameters.AddWithValue("@tm", page1Selections[1]);
                cmdDatabase.Parameters.AddWithValue("@tr", page1Selections[2]);
                cmdDatabase.Parameters.AddWithValue("@bl", page1Selections[3]);
                cmdDatabase.Parameters.AddWithValue("@bm", page1Selections[4]);
                cmdDatabase.Parameters.AddWithValue("@br", page1Selections[5]);
                cmdDatabase.Parameters.AddWithValue("@userID", userID);
                cmdDatabase.ExecuteNonQuery();
            } catch (Exception ex) {
                MessageBox.Show("An Error has occurred while writing to the database: " + ex.Message);
            }
        }

        // WHERE interviewNumber = (SELECT TOP 1 * FROM dbo.dislikeSounds ORDER BY interviewNumber DESC)

        /// <summary>
        /// Write to DB for 5 picture boxes
        /// </summary>
        /// <param name="array"></param>
        /// <param name="TLImageName"></param>
        /// <param name="TMImageName"></param>
        /// <param name="TRImageName"></param>
        /// <param name="BLImageName"></param>
        /// <param name="BMImageName"></param>
        private void writeToDB5(string TLImageName, string TMImageName, string TRImageName, string BLImageName, string BMImageName, string dbTableName) {

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
                           BMImageName + ", ID) VALUES (@tl, @tm, @tr, @bl, @bm, @userID);";

                cmdDatabase = new SqlCommand(query, conDatabase);
                cmdDatabase.Parameters.AddWithValue("@tl", page1Selections[0]);
                cmdDatabase.Parameters.AddWithValue("@tm", page1Selections[1]);
                cmdDatabase.Parameters.AddWithValue("@tr", page1Selections[2]);
                cmdDatabase.Parameters.AddWithValue("@bl", page1Selections[3]);
                cmdDatabase.Parameters.AddWithValue("@bm", page1Selections[4]);
                cmdDatabase.Parameters.AddWithValue("@userID", userID);

                cmdDatabase.ExecuteNonQuery();
            } catch (Exception err) {
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
        private void writeToDB4(string TLImageName, string TMImageName, string TRImageName, string BLImageName, string dbTableName) {

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
                          BLImageName + ", ID) VALUES (@tl, @tm, @tr, @bl,@userID);";

                cmdDatabase = new SqlCommand(query, conDatabase);
                cmdDatabase.Parameters.AddWithValue("@tl", page1Selections[0]);
                cmdDatabase.Parameters.AddWithValue("@tm", page1Selections[1]);
                cmdDatabase.Parameters.AddWithValue("@tr", page1Selections[2]);
                cmdDatabase.Parameters.AddWithValue("@bl", page1Selections[3]);
                cmdDatabase.Parameters.AddWithValue("@userID", userID);

                cmdDatabase.ExecuteNonQuery();
            } catch (Exception err) {
                MessageBox.Show("An Error has occurred while writing to the database: " + err.Message);
            }
        }

        private void updateOnPreviousClicked(string TLImageName, string TMImageName, string TRImageName, string BLImageName, string BMImageName, string BRImageName, string tableDBName) {
            SqlCommand cmdDatabase;
            const string constring = @"Data Source =(LocalDB)\MSSQLLocalDB;" +
                                    @"AttachDbFilename = |DataDirectory|\CapstoneDB\CapstoneDB.mdf; Integrated Security = True";
            SqlConnection conDatabase = new SqlConnection(constring);
            try {
                string query1 = string.Format("UPDATE dbo.{0} SET " + TLImageName + "=@tl, " + TMImageName + "=@tm, " +
                         TRImageName + "=@tr, " +
                          BLImageName + "=@bl, " +
                           BMImageName + "=@bm, " + BRImageName + " =@br, ID = @userID WHERE interviewNumber = (SELECT MAX(interviewNumber) FROM dbo.{0});", tableDBName);
                conDatabase.Open();
                cmdDatabase = new SqlCommand(query1, conDatabase);
                //cmdDatabase = new SqlCommand("INSERT INTO dbo." + tableName + "(" + columnName + ") VALUES(@text);" , conDatabase);
                cmdDatabase.Parameters.AddWithValue("@tl", page1Selections[0]);
                cmdDatabase.Parameters.AddWithValue("@tm", page1Selections[1]);
                cmdDatabase.Parameters.AddWithValue("@tr", page1Selections[2]);
                cmdDatabase.Parameters.AddWithValue("@bl", page1Selections[3]);
                cmdDatabase.Parameters.AddWithValue("@bm", page1Selections[4]);
                cmdDatabase.Parameters.AddWithValue("@br", page1Selections[5]);
                cmdDatabase.Parameters.AddWithValue("@userID", userID);

                cmdDatabase.ExecuteNonQuery();
                conDatabase.Close();
            } catch (Exception ex) {
                MessageBox.Show("An error has occurred: " + ex.Message);
            }
        }
        private void previousUpdate3(string TLImageName, string TMImageName, string TRImageName, string dbTableName) {
            SqlCommand cmdDatabase;
            const string constring = @"Data Source =(LocalDB)\MSSQLLocalDB;" +
                                    @"AttachDbFilename = |DataDirectory|\CapstoneDB\CapstoneDB.mdf; Integrated Security = True";
            SqlConnection conDatabase = new SqlConnection(constring);
            try {
                string query1 = string.Format("UPDATE dbo.{0} SET " + TLImageName + "=@tl, " + TMImageName + "=@tm, " +
                         TRImageName + "=@tr, ID = @userID WHERE interviewNumber = (SELECT MAX(interviewNumber) FROM dbo.{0});", dbTableName);
                conDatabase.Open();
                cmdDatabase = new SqlCommand(query1, conDatabase);
                //cmdDatabase = new SqlCommand("INSERT INTO dbo." + tableName + "(" + columnName + ") VALUES(@text);" , conDatabase);
                cmdDatabase.Parameters.AddWithValue("@tl", page1Selections[0]);
                cmdDatabase.Parameters.AddWithValue("@tm", page1Selections[1]);
                cmdDatabase.Parameters.AddWithValue("@tr", page1Selections[2]);
                cmdDatabase.Parameters.AddWithValue("@userID", userID);

                cmdDatabase.ExecuteNonQuery();
                conDatabase.Close();
            } catch (Exception ex) {
                MessageBox.Show("An error has occurred: " + ex.Message);
            }
        }
        private void previousUpdate2(string TLImageName, string TMImageName, string dbTableName) {
            SqlCommand cmdDatabase;
            const string constring = @"Data Source =(LocalDB)\MSSQLLocalDB;" +
                                    @"AttachDbFilename = |DataDirectory|\CapstoneDB\CapstoneDB.mdf; Integrated Security = True";
            SqlConnection conDatabase = new SqlConnection(constring);
            try {
                string query1 = string.Format("UPDATE dbo.{0} SET " + TLImageName + "=@tl, " + TMImageName +
                    "=@tm, ID = @userID WHERE interviewNumber = (SELECT MAX(interviewNumber) FROM dbo.{0});", dbTableName);
                conDatabase.Open();
                cmdDatabase = new SqlCommand(query1, conDatabase);
                //cmdDatabase = new SqlCommand("INSERT INTO dbo." + tableName + "(" + columnName + ") VALUES(@text);" , conDatabase);
                cmdDatabase.Parameters.AddWithValue("@tl", page1Selections[0]);
                cmdDatabase.Parameters.AddWithValue("@tm", page1Selections[1]);
                cmdDatabase.Parameters.AddWithValue("@userID", userID);

                cmdDatabase.ExecuteNonQuery();
                conDatabase.Close();
            } catch (Exception ex) {
                MessageBox.Show("An error has occurred: " + ex.Message);
            }
        }
        private void previousUpdate5(string TLImageName, string TMImageName, string TRImageName, string BLImageName, string BMImageName, string dbTableName) {
            SqlCommand cmdDatabase;
            const string constring = @"Data Source =(LocalDB)\MSSQLLocalDB;" +
                                    @"AttachDbFilename = |DataDirectory|\CapstoneDB\CapstoneDB.mdf; Integrated Security = True";
            SqlConnection conDatabase = new SqlConnection(constring);
            try {
                string query1 = string.Format("UPDATE dbo.{0} SET " + TLImageName + "=@tl, " + TMImageName + "=@tm, " +
                         TRImageName + "=@tr, " +
                          BLImageName + "=@bl, " +
                           BMImageName + "=@bm, ID = @userID WHERE interviewNumber = (SELECT MAX(interviewNumber) FROM dbo.{0});", dbTableName);
                conDatabase.Open();
                cmdDatabase = new SqlCommand(query1, conDatabase);
                //cmdDatabase = new SqlCommand("INSERT INTO dbo." + tableName + "(" + columnName + ") VALUES(@text);" , conDatabase);
                cmdDatabase.Parameters.AddWithValue("@tl", page1Selections[0]);
                cmdDatabase.Parameters.AddWithValue("@tm", page1Selections[1]);
                cmdDatabase.Parameters.AddWithValue("@tr", page1Selections[2]);
                cmdDatabase.Parameters.AddWithValue("@bl", page1Selections[3]);
                cmdDatabase.Parameters.AddWithValue("@bm", page1Selections[4]);
                cmdDatabase.Parameters.AddWithValue("@userID", userID);

                cmdDatabase.ExecuteNonQuery();
                conDatabase.Close();
            } catch (Exception ex) {
                MessageBox.Show("An error has occurred: " + ex.Message);
            }
        }
        private void previousUpdate4(string TLImageName, string TMImageName, string TRImageName, string BLImageName, string dbTableName) {
            SqlCommand cmdDatabase;
            const string constring = @"Data Source =(LocalDB)\MSSQLLocalDB;" +
                                    @"AttachDbFilename = |DataDirectory|\CapstoneDB\CapstoneDB.mdf; Integrated Security = True";
            SqlConnection conDatabase = new SqlConnection(constring);
            try {
                string query1 = string.Format("UPDATE dbo.{0} SET " + TLImageName + "=@tl, " + TMImageName + "=@tm, " +
                         TRImageName + "=@tr, " +
                          BLImageName + "=@bl, ID = @userID WHERE interviewNumber = (SELECT MAX(interviewNumber) FROM dbo.{0});", dbTableName);
                conDatabase.Open();
                cmdDatabase = new SqlCommand(query1, conDatabase);
                //cmdDatabase = new SqlCommand("INSERT INTO dbo." + tableName + "(" + columnName + ") VALUES(@text);" , conDatabase);
                cmdDatabase.Parameters.AddWithValue("@tl", page1Selections[0]);
                cmdDatabase.Parameters.AddWithValue("@tm", page1Selections[1]);
                cmdDatabase.Parameters.AddWithValue("@tr", page1Selections[2]);
                cmdDatabase.Parameters.AddWithValue("@bl", page1Selections[3]);

                cmdDatabase.Parameters.AddWithValue("@userID", userID);

                cmdDatabase.ExecuteNonQuery();
                conDatabase.Close();
            } catch (Exception ex) {
                MessageBox.Show("An error has occurred: " + ex.Message);
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////// BUTTON CLICKS FOR A LITT AND A LOT ////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void topLeftPBALittleBtn_Click(object sender, EventArgs e) {
            //This will refresh the picture box
            topLeftPB.Invalidate();
            page1Selections[0] = "A Little";
            //this is just to show the array being updated -- can remove after testing
            //Update label
            //summary.LabelText = "Top Left A Little";
            //summary.Show();
        }
        private void topLeftPBALotBtn_Click(object sender, EventArgs e) {
            //This will refresh the picture box
            topLeftPB.Invalidate();
            page1Selections[0] = "A Lot";
            //summary.LabelText = "Top Left A Lot";
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
            picSense.Image = new Bitmap(@"..\..\resources\TopLeftInterviewImage(sense)\sight.PNG");
            pictureBox2.Image = new Bitmap(@"..\..\resources\TopLeftInterviewImage(sense)\sight.PNG");
            //picturePanel
            picBackground.BackColor = Color.SandyBrown;
            lblQuestion.BackColor = Color.SandyBrown;            
            picturePanel.BackColor = Color.Bisque;
            //questionPanel
            pictureBox3.BackColor = Color.SandyBrown;
            panel2lblQuestion.BackColor = Color.SandyBrown;
            questionPanel.BackColor = Color.Bisque;     
        }

        private void TouchColours() {
            picSense.Image = new Bitmap(@"..\..\resources\TopLeftInterviewImage(sense)\touch.PNG");
            pictureBox2.Image = new Bitmap(@"..\..\resources\TopLeftInterviewImage(sense)\touch.PNG");
            //picturePanel
            picBackground.BackColor = Color.FromArgb(255, 255, 128);
            lblQuestion.BackColor = Color.FromArgb(255, 255, 128);
            picturePanel.BackColor = Color.LightYellow;
            //questionPanel
            pictureBox3.BackColor = Color.FromArgb(255, 255, 128);
            panel2lblQuestion.BackColor = Color.FromArgb(255, 255, 128);
            questionPanel.BackColor = Color.LightYellow;
        }

        private void SmellColours() {
            picSense.Image = new Bitmap(@"..\..\resources\TopLeftInterviewImage(sense)\smell.PNG");
            pictureBox2.Image = new Bitmap(@"..\..\resources\TopLeftInterviewImage(sense)\smell.PNG");
            //picturePanel
            picBackground.BackColor = Color.FromArgb(143, 188, 139);
            lblQuestion.BackColor = Color.FromArgb(143, 188, 139);
            picturePanel.BackColor = Color.Honeydew;
            //questionPanel
            pictureBox3.BackColor = Color.FromArgb(143, 188, 139);
            panel2lblQuestion.BackColor = Color.FromArgb(143, 188, 139);
            questionPanel.BackColor = Color.Honeydew;
        }

        private void TasteColours() {
            picSense.Image = new Bitmap(@"..\..\resources\TopLeftInterviewImage(sense)\taste.PNG");
            pictureBox2.Image = new Bitmap(@"..\..\resources\TopLeftInterviewImage(sense)\taste.PNG");
            System.Drawing.Color tasteHeader = System.Drawing.ColorTranslator.FromHtml("#C2B4E2");
            System.Drawing.Color tasteBg = System.Drawing.ColorTranslator.FromHtml("#E6E6FA");
            //picturePanel
            picBackground.BackColor = tasteHeader;
            lblQuestion.BackColor = tasteHeader;
            picturePanel.BackColor = tasteBg;
            //questionPanel
            pictureBox3.BackColor = tasteHeader;
            panel2lblQuestion.BackColor = tasteHeader;
            questionPanel.BackColor = tasteBg;
        }

        private void MovementColours() {
            picSense.Image = new Bitmap(@"..\..\resources\TopLeftInterviewImage(sense)\movement.PNG");
            pictureBox2.Image = new Bitmap(@"..\..\resources\TopLeftInterviewImage(sense)\movement.PNG");
            //picturePanel
            picBackground.BackColor = Color.PaleVioletRed;
            lblQuestion.BackColor = Color.PaleVioletRed;
            picturePanel.BackColor = Color.Pink;
            //questionPanel
            pictureBox3.BackColor = Color.PaleVioletRed;
            panel2lblQuestion.BackColor = Color.PaleVioletRed;
            questionPanel.BackColor = Color.Pink;
        }
        
        
        private void EnvironmentColours() {
            //picturePanel
            picBackground.BackColor = Color.LightBlue;
            lblQuestion.BackColor = Color.LightBlue;
            picturePanel.BackColor = Color.AliceBlue;
            //questionPanel
            pictureBox3.BackColor = Color.LightBlue;
            panel2lblQuestion.BackColor = Color.LightBlue;
            questionPanel.BackColor = Color.AliceBlue;
        }

        private void OtherColours() {
            //picturePanel
            picBackground.BackColor = Color.Tan;
            lblQuestion.BackColor = Color.Tan;
            picturePanel.BackColor = Color.AntiqueWhite;
            //questionPanel
            pictureBox3.BackColor = Color.Tan;
            panel2lblQuestion.BackColor = Color.Tan;
            questionPanel.BackColor = Color.AntiqueWhite;
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
            //-------------
            //SOUND SECTION
            //-------------
            if (Globals.interview_page == 2) {
                if (!Globals.previousClicked) {
                    writeToDB("otherPeopleTalking", "fireworks", "loudVoices",
                              "householdAppliances", "vehicles", "bathroomAppliances", "dislikeSounds");

                } else {
                    updateOnPreviousClicked("otherPeopleTalking", "fireworks", "loudVoices",
                              "householdAppliances", "vehicles", "bathroomAppliances", "dislikeSounds");
                    Globals.previousClicked = false;
                }
                if (m_InstanceRef2 != null) {
                    InstanceRef2.Show();
                } else {
                    this.Hide();
                    FamilyObservations soundPage1 = new FamilyObservations();
                    soundPage1.InstanceRef = this;
                    soundPage1.Show();
                }
            } else if (Globals.interview_page == 3) {
                updateDB("sirens", "suddenLoudNoises", "dislikeSounds");
                FamilyObservations soundPage1p2 = new FamilyObservations();
                soundPage1p2.InstanceRef2 = this;
                soundPage1p2.Show();
                this.Hide();
            } else if (Globals.interview_page == 4) {
                saveWrittenAnswerToDB("dislikeSounds", "comment1", tbAnswer1.Text.ToString());
                saveWrittenAnswerToDB("dislikeSounds", "comment2", tbAnswer2.Text.ToString());
                FamilyObservations soundPage2 = new FamilyObservations();
                soundPage2.InstanceRef3 = this;
                soundPage2.Show();
                this.Hide();
            } else if (Globals.interview_page == 5) {
                if (!Globals.previousClicked) {
                    previousUpdate3("concentrating", "hardToListenInClassroom", "hardToListenInGroup", "hardToListen");
                } else {
                    writeToDBTop3("concentrating", "hardToListenInClassroom", "hardToListenInGroup", "hardToListen");
                    Globals.previousClicked = false;
                }
                FamilyObservations soundPage3 = new FamilyObservations();
                soundPage3.InstanceRef4 = this;
                soundPage3.Show();
                this.Hide();
            } else if (Globals.interview_page == 6) {
                saveWrittenAnswerToDB("hardToListen", "comment1", tbAnswer1.Text.ToString());
                FamilyObservations soundPage4 = new FamilyObservations();
                soundPage4.InstanceRef5 = this;
                soundPage4.Show();
                this.Hide();
            } else if (Globals.interview_page == 7) {
                if (!Globals.previousClicked) {
                    previousUpdate3("radioOn", "clockTicking", "peopleTalking", "hardToConcentrate");
                } else {
                    writeToDBTop3("radioOn", "clockTicking", "peopleTalking", "hardToConcentrate");
                    Globals.previousClicked = false;
                }
                FamilyObservations soundPage5 = new FamilyObservations();
                soundPage5.InstanceRef6 = this;
                soundPage5.Show();
                this.Hide();
            } else if (Globals.interview_page == 8) {
                saveWrittenAnswerToDB("hardToConcentrate", "comment1", tbAnswer1.Text.ToString());
                saveWrittenAnswerToDB("hardToConcentrate", "comment2", tbAnswer2.Text.ToString());
                FamilyObservations soundPage6 = new FamilyObservations();
                soundPage6.InstanceRef7 = this;
                soundPage6.Show();
                this.Hide();
            } else if (Globals.interview_page == 9) {
                if (!Globals.previousClicked) {
                    previousUpdate5("computerSounds", "liveMusic", "fans", "musicThroughMyPhone", "rhythms", "likeSounds");
                } else {
                    writeToDB5("computerSounds", "liveMusic", "fans", "musicThroughMyPhone", "rhythms", "likeSounds");
                    Globals.previousClicked = false;
                }
                FamilyObservations soundPage7 = new FamilyObservations();
                soundPage7.InstanceRef8 = this;
                soundPage7.Show();
                this.Hide();
            } else if (Globals.interview_page == 10) {
                saveWrittenAnswerToDB("likeSounds", "comment1", tbAnswer1.Text.ToString());
                FamilyObservations soundPage8 = new FamilyObservations();
                soundPage8.InstanceRef9 = this;
                soundPage8.Show();
                this.Hide();
            } else if (Globals.interview_page == 11) {
                if (!Globals.previousClicked) {
                    previousUpdate4("hummingOrWhistling", "tappingFeet", "tappingFingers", "clickingPen", "makeALotSounds");
                } else {
                    writeToDB4("hummingOrWhistling", "tappingFeet", "tappingFingers", "clickingPen", "makeALotSounds");
                    Globals.previousClicked = false;
                }
                FamilyObservations soundPage9 = new FamilyObservations();
                soundPage9.InstanceRef10 = this;
                soundPage9.Show();
                this.Hide();
            } else if (Globals.interview_page == 12) {
                saveWrittenAnswerToDB("makeALotSounds", "comment1", tbAnswer1.Text.ToString());
                saveWrittenAnswerToDB("makeALotSounds", "comment2", tbAnswer2.Text.ToString());
                FamilyObservations soundPage10 = new FamilyObservations();
                soundPage10.InstanceRef11 = this;
                soundPage10.Show();
                this.Hide();
            }
              //-------------
              //SIGHT SECTION
              //-------------
              else if (Globals.interview_page == 13) {
                if (!Globals.previousClicked) {
                    previousUpdate5("sunlight", "fluorescentLight", "lightAndShadow", "busyPatterns", "classroomLight", "dontLikeToLookAt");
                } else {
                    writeToDB5("sunlight", "fluorescentLight", "lightAndShadow", "busyPatterns", "classroomLight", "dontLikeToLookAt");
                    Globals.previousClicked = false;
                }
                FamilyObservations sightPage1 = new FamilyObservations();
                sightPage1.InstanceRef12 = this;
                sightPage1.Show();
                this.Hide();
            } else if (Globals.interview_page == 14) {
                saveWrittenAnswerToDB("dontLikeToLookAt", "comment1", tbAnswer1.Text.ToString());
                saveWrittenAnswerToDB("dontLikeToLookAt", "comment2", tbAnswer2.Text.ToString());
                FamilyObservations sightPage2 = new FamilyObservations();
                sightPage2.InstanceRef13 = this;
                sightPage2.Show();
                this.Hide();
            } else if (Globals.interview_page == 15) {
                if (!Globals.previousClicked) {
                    previousUpdate3("lotsOfThingsInAMessyDrawer", "peopleRunningAroundMe", "lotsOfThingsHangingUpInTheClassroom", "sightHardToConcentrate");
                } else {
                    writeToDBTop3("lotsOfThingsInAMessyDrawer", "peopleRunningAroundMe", "lotsOfThingsHangingUpInTheClassroom", "sightHardToConcentrate");
                    Globals.previousClicked = false;
                }
                FamilyObservations sightPage3 = new FamilyObservations();
                sightPage3.InstanceRef14 = this;
                sightPage3.Show();
                this.Hide();
            } else if (Globals.interview_page == 16) {
                saveWrittenAnswerToDB("sightHardToConcentrate", "comment1", tbAnswer1.Text.ToString());
                FamilyObservations sightPage4 = new FamilyObservations();
                sightPage4.InstanceRef15 = this;
                sightPage4.Show();
                this.Hide();
            } else if (Globals.interview_page == 17) {
                if (!Globals.previousClicked) {
                    previousUpdate5("movingLights", "thingsThatSparkle", "geometricPatterns", "spinningFans", "spinningObjects", "likeToLookAt");
                } else {
                    writeToDB5("movingLights", "thingsThatSparkle", "geometricPatterns", "spinningFans", "spinningObjects", "likeToLookAt");
                    Globals.previousClicked = false;
                }
                FamilyObservations sightPage5 = new FamilyObservations();
                sightPage5.InstanceRef16 = this;
                sightPage5.Show();
                this.Hide();
            } else if (Globals.interview_page == 18) {
                saveWrittenAnswerToDB("likeToLookAt", "comment1", tbAnswer1.Text.ToString());

                FamilyObservations sightPage6 = new FamilyObservations();
                sightPage6.InstanceRef17 = this;
                sightPage6.Show();
                this.Hide();
            }
              //-------------
              //TOUCH SECTION
              //-------------
              else if (Globals.interview_page == 19) {
                if (!Globals.previousClicked) {
                    updateOnPreviousClicked("sandy", "sticky", "grassy", "woolClothes", "tightClothes", "stiffClothes", "dontLikeFeelingOf");
                } else {
                    writeToDB("sandy", "sticky", "grassy", "woolClothes", "tightClothes", "stiffClothes", "dontLikeFeelingOf");
                    Globals.previousClicked = false;
                }
                FamilyObservations touchPage1 = new FamilyObservations();
                touchPage1.InstanceRef18 = this;
                touchPage1.Show();
                this.Hide();
            } else if (Globals.interview_page == 20) {
                updateDBdontLikeFeelingOf("shoes", "splashingWater", "dontLikeFeelingOf");
                FamilyObservations touchPage1p2 = new FamilyObservations();
                touchPage1p2.InstanceRef19 = this;
                touchPage1p2.Show();
                this.Hide();
            } else if (Globals.interview_page == 21) {
                saveWrittenAnswerToDB("dontLikeToLookAt", "comment1", tbAnswer1.Text.ToString());
                saveWrittenAnswerToDB("dontLikeToLookAt", "comment2", tbAnswer2.Text.ToString());
                FamilyObservations touchPage2 = new FamilyObservations();
                touchPage2.InstanceRef20 = this;
                touchPage2.Show();
                this.Hide();
            } /*else if (Globals.interview_page == 22) {
                FamilyObservations touchPageQuestion3 = new FamilyObservations();
                touchPageQuestion3.InstanceRef21 = this;
                touchPageQuestion3.Show();
                this.Hide();
            } *///Add missing question here
            else if (Globals.interview_page == 22) {
                if (!Globals.previousClicked) {
                    updateOnPreviousClicked("beingHuggedOrKissed", "beingCrowded", "beingTappedOnTheShoulder", "havingSunscreenPutOn", "beingBumped", "havingAHaircut", "peopleTouchDontLike");
                } else {
                    writeToDB("beingHuggedOrKissed", "beingCrowded", "beingTappedOnTheShoulder", "havingSunscreenPutOn", "beingBumped", "havingAHaircut", "peopleTouchDontLike");
                    Globals.previousClicked = false;
                }
                FamilyObservations touchPage3 = new FamilyObservations();
                touchPage3.InstanceRef21 = this;
                touchPage3.Show();
                this.Hide();
            } else if (Globals.interview_page == 23) {
                updateDBpeopleTouchDontLike("doctorTouchingMe", "dentistTouchingMe", "peopleTouchDontLike");
                FamilyObservations touchPage3p2 = new FamilyObservations();
                touchPage3p2.InstanceRef21 = this;
                touchPage3p2.Show();
                this.Hide();
            } else if (Globals.interview_page == 24) {
                saveWrittenAnswerToDB("peopleTouchDontLike", "comment1", tbAnswer1.Text.ToString());
                saveWrittenAnswerToDB("peopleTouchDontLike", "comment2", tbAnswer2.Text.ToString());
                FamilyObservations touchPage4 = new FamilyObservations();
                touchPage4.InstanceRef23 = this;
                touchPage4.Show();
                this.Hide();
            } //Add missing question here
              else if (Globals.interview_page == 25) {
                if (!Globals.previousClicked) {
                    updateOnPreviousClicked("soft", "rubbery", "furry", "huggingPeople", "touchingPeople", "beingSquashedWithAPillow", "likeTheFeelingOf");
                } else {
                    writeToDB("soft", "rubbery", "furry", "huggingPeople", "touchingPeople", "beingSquashedWithAPillow", "likeTheFeelingOf");
                    Globals.previousClicked = false;
                }
                FamilyObservations touchPage5 = new FamilyObservations();
                touchPage5.InstanceRef24 = this;
                touchPage5.Show();
                this.Hide();
            } else if (Globals.interview_page == 26) {
                saveWrittenAnswerToDB("likeTheFeelingOf", "comment1", tbAnswer1.Text.ToString());

                FamilyObservations touchPage6 = new FamilyObservations();
                touchPage6.InstanceRef25 = this;
                touchPage6.Show();
                this.Hide();
            }
              //-------------
              //SMELL SECTION
              //-------------
              else if (Globals.interview_page == 27) {
                if (!Globals.previousClicked) {
                    updateOnPreviousClicked("cookingSmells", "foodSmells", "cleaningProducts", "toiletSmells", "perfumes", "bodySmells", "smellDontLike");
                } else {
                    writeToDB("cookingSmells", "foodSmells", "cleaningProducts", "toiletSmells", "perfumes", "bodySmells", "smellDontLike");
                    Globals.previousClicked = false;
                }
                FamilyObservations smellPage1 = new FamilyObservations();
                smellPage1.InstanceRef26 = this;
                smellPage1.Show();
                this.Hide();
            } else if (Globals.interview_page == 28) {
                saveWrittenAnswerToDB("smellDontLike", "comment1", tbAnswer1.Text.ToString());
                saveWrittenAnswerToDB("smellDontLike", "comment2", tbAnswer2.Text.ToString());
                FamilyObservations smellPage2 = new FamilyObservations();
                smellPage2.InstanceRef27 = this;
                smellPage2.Show();
                this.Hide();
            } else if (Globals.interview_page == 29) {
                if (!Globals.previousClicked) {
                    previousUpdate5("smellingFoods", "smellingPlants", "smellingPerfume", "smellingSoap", "smellingPeople", "likeToSmell");
                } else {
                    writeToDB5("smellingFoods", "smellingPlants", "smellingPerfume", "smellingSoap", "smellingPeople", "likeToSmell");
                    Globals.previousClicked = false;
                }
                FamilyObservations smellPage3 = new FamilyObservations();
                smellPage3.InstanceRef28 = this;
                smellPage3.Show();
                this.Hide();
            } else if (Globals.interview_page == 30) {

                saveWrittenAnswerToDB("likeToSmell", "comment1", tbAnswer1.Text.ToString());
                FamilyObservations smellPage4 = new FamilyObservations();
                smellPage4.InstanceRef29 = this;
                smellPage4.Show();
                this.Hide();
            }
              //-------------
              //TASTE SECTION
              //-------------
              else if (Globals.interview_page == 31) {

                if (!Globals.previousClicked) {
                    updateOnPreviousClicked("vegetables", "fruit", "meat", "fish", "eggs", "dairy", "foodGroupsDontLike");
                } else {
                    writeToDB("vegetables", "fruit", "meat", "fish", "eggs", "dairy", "foodGroupsDontLike");
                    Globals.previousClicked = false;
                }
                FamilyObservations tastePage1 = new FamilyObservations();
                tastePage1.InstanceRef30 = this;
                tastePage1.Show();
                this.Hide();
            } else if (Globals.interview_page == 32) {
                updateDBfoodGroupsDontLike("bread", "pasta", "foodGroupsDontLike");
                FamilyObservations tastePage1p2 = new FamilyObservations();
                tastePage1p2.InstanceRef31 = this;
                tastePage1p2.Show();
                this.Hide();
            } else if (Globals.interview_page == 33) {
                saveWrittenAnswerToDB("foodGroupsDontLike", "comment1", tbAnswer1.Text.ToString());
                saveWrittenAnswerToDB("foodGroupsDontLike", "comment2", tbAnswer2.Text.ToString());
                FamilyObservations tastePage2 = new FamilyObservations();
                tastePage2.InstanceRef32 = this;
                tastePage2.Show();
                this.Hide();
            } else if (Globals.interview_page == 34) {
                if (!Globals.previousClicked) {
                    updateOnPreviousClicked("lumpy", "chewy", "runnyOrSlippery", "mixed", "sweet", "sour", "tastesOrFeelsInMouthDontLike");
                } else {
                    writeToDB("lumpy", "chewy", "runnyOrSlippery", "mixed", "sweet", "sour", "tastesOrFeelsInMouthDontLike");
                    Globals.previousClicked = false;
                }
                FamilyObservations tastePage3 = new FamilyObservations();
                tastePage3.InstanceRef33 = this;
                tastePage3.Show();
                this.Hide();
            } else if (Globals.interview_page == 35) {
                updateDBtastesOrFeelsInMouthDontLike("salty", "spicy", "tastesOrFeelsInMouthDontLike");
                FamilyObservations tastePage3p2 = new FamilyObservations();
                tastePage3p2.InstanceRef34 = this;
                tastePage3p2.Show();
                this.Hide();
            } else if (Globals.interview_page == 36) {
                saveWrittenAnswerToDB("tastesOrFeelsInMouthDontLike", "comment1", tbAnswer1.Text.ToString());
                saveWrittenAnswerToDB("tastesOrFeelsInMouthDontLike", "comment2", tbAnswer2.Text.ToString());
                FamilyObservations tastePage4 = new FamilyObservations();
                tastePage4.InstanceRef35 = this;
                tastePage4.Show();
                this.Hide();
            } //Add missing question here
              else if (Globals.interview_page == 37) {
                if (!Globals.previousClicked) {
                    previousUpdate2("familiarFoods", "unfamiliarFoods", "foodReallyLikeToEat");
                } else {
                    writeToDBTop2("familiarFoods", "unfamiliarFoods", "foodReallyLikeToEat");
                    Globals.previousClicked = false;
                }
                FamilyObservations tastePage5 = new FamilyObservations();
                tastePage5.InstanceRef36 = this;
                tastePage5.Show();
                this.Hide();
            } else if (Globals.interview_page == 38) {
                saveWrittenAnswerToDB("foodReallyLikeToEat", "comment1", tbAnswer1.Text.ToString());
                FamilyObservations tastePage6 = new FamilyObservations();
                tastePage6.InstanceRef37 = this;
                tastePage6.Show();
                this.Hide();
            } else if (Globals.interview_page == 39) {
                if (!Globals.previousClicked) {
                    previousUpdate3("shirt", "hair", "objects", "thingsPutInMouthALot");
                } else {
                    writeToDBTop3("shirt", "hair", "objects", "thingsPutInMouthALot");
                    Globals.previousClicked = false;
                }
                FamilyObservations tastePage7 = new FamilyObservations();
                tastePage7.InstanceRef38 = this;
                tastePage7.Show();
                this.Hide();
            } else if (Globals.interview_page == 40) {
                saveWrittenAnswerToDB("thingsPutInMouthALot", "comment1", tbAnswer1.Text.ToString());
                saveWrittenAnswerToDB("thingsPutInMouthALot", "comment2", tbAnswer2.Text.ToString());
                FamilyObservations tastePage8 = new FamilyObservations();
                tastePage8.InstanceRef39 = this;
                tastePage8.Show();
                this.Hide();
            }
              //----------------
              //Movement SECTION
              //----------------
              else if (Globals.interview_page == 41) {
                if (!Globals.previousClicked) {
                    previousUpdate5("beingJumpedOnOrTackled", "movingWhenICantSeeWhereIAmGoing", "balancing", "beingUpsideDown", "climbingUpHigh", "movingDontLike");
                } else {
                    writeToDB5("beingJumpedOnOrTackled", "movingWhenICantSeeWhereIAmGoing", "balancing", "beingUpsideDown", "climbingUpHigh", "movingDontLike");
                    Globals.previousClicked = false;
                }
                this.Hide();
                FamilyObservations mvmtPage1 = new FamilyObservations();
                mvmtPage1.InstanceRef40 = this;
                mvmtPage1.Show();
            } else if (Globals.interview_page == 42) {
                saveWrittenAnswerToDB("movingDontLike", "comment1", tbAnswer1.Text.ToString());
                saveWrittenAnswerToDB("movingDontLike", "comment2", tbAnswer2.Text.ToString());
                this.Hide();
                FamilyObservations mvmtPage2 = new FamilyObservations();
                mvmtPage2.InstanceRef41 = this;
                mvmtPage2.Show();
            } else if (Globals.interview_page == 43) {
                if (!Globals.previousClicked) {
                    previousUpdate2("standingStill", "sittingStill", "hardToStayStill");
                } else {
                    writeToDBTop2("standingStill", "sittingStill", "hardToStayStill");
                    Globals.previousClicked = false;
                }
                this.Hide();
                FamilyObservations mvmtPage3 = new FamilyObservations();
                mvmtPage3.InstanceRef42 = this;
                mvmtPage3.Show();
            } else if (Globals.interview_page == 44) {
                saveWrittenAnswerToDB("hardToStayStill", "comment1", tbAnswer1.Text.ToString());
                this.Hide();
                FamilyObservations mvmtPage4 = new FamilyObservations();
                mvmtPage4.InstanceRef43 = this;
                mvmtPage4.Show();
            } else if (Globals.interview_page == 45) {
                if (!Globals.previousClicked) {
                    previousUpdate5("movingInWater", "swinging", "spinning", "jumpingOnTheTrampoline", "running", "movingThatYouLike");
                } else {
                    writeToDB5("movingInWater", "swinging", "spinning", "jumpingOnTheTrampoline", "running", "movingThatYouLike");
                    Globals.previousClicked = false;
                }
                FamilyObservations mvmtPage5 = new FamilyObservations();
                mvmtPage5.InstanceRef44 = this;
                mvmtPage5.Show();
                this.Hide();
            } else if (Globals.interview_page == 46) {
                saveWrittenAnswerToDB("movingThatYouLike", "comment1", tbAnswer1.Text.ToString());
                this.Hide();
                FamilyObservations mvmtPage6 = new FamilyObservations();
                mvmtPage6.InstanceRef45 = this;
                mvmtPage6.Show();
            } else if (Globals.interview_page == 47) {
                if (!Globals.previousClicked) {
                    previousUpdate4("rocking", "movingHands", "clapping", "pacing", "moveOverAndOverAgain");
                } else {
                    writeToDB4("rocking", "movingHands", "clapping", "pacing", "moveOverAndOverAgain");
                    Globals.previousClicked = false;
                }
                FamilyObservations mvmtPage7 = new FamilyObservations();
                mvmtPage7.InstanceRef46 = this;
                mvmtPage7.Show();
                this.Hide();
            } else if (Globals.interview_page == 48) {
                saveWrittenAnswerToDB("moveOverAndOverAgain", "comment1", tbAnswer1.Text.ToString());
                saveWrittenAnswerToDB("moveOverAndOverAgain", "comment2", tbAnswer2.Text.ToString());
                this.Hide();
                FamilyObservations mvmtPage8 = new FamilyObservations();
                mvmtPage8.InstanceRef47 = this;
                mvmtPage8.Show();
            }
              //-------------------
              //ENVIRONMENT SECTION
              //-------------------
              else if (Globals.interview_page == 49) {
                if (!Globals.previousClicked) {
                    previousUpdate5("supermarket", "party", "foodHall", "show", "shoppingMall", "other");
                } else {
                    writeToDB5("supermarket", "party", "foodHall", "show", "shoppingMall", "other");
                    Globals.previousClicked = false;
                }
                FamilyObservations environmentPage1 = new FamilyObservations();
                environmentPage1.InstanceRef48 = this;
                environmentPage1.Show();
                this.Hide();
            } else if (Globals.interview_page == 50) {
                saveWrittenAnswerToDB("other", "comment1", tbAnswer1.Text.ToString());
                saveWrittenAnswerToDB("other", "comment2", tbAnswer2.Text.ToString());
                FamilyObservations environmentPage2 = new FamilyObservations();
                environmentPage2.InstanceRef49 = this;
                environmentPage2.Show();
                this.Hide();
            }
              //-------------
              //OTHER SECTION
              //-------------
              else if (Globals.interview_page == 51) {
                updateDBother("sounds", "smells", "sights", "tastes", "feelings", "movements", "other");
                FamilyObservations otherPage1 = new FamilyObservations();
                otherPage1.InstanceRef50 = this;
                otherPage1.Show();
                this.Hide();
            } else if (Globals.interview_page == 52) {
                saveWrittenAnswerToDB("other", "comment3", tbAnswer1.Text.ToString());
                saveWrittenAnswerToDB("other", "comment4", tbAnswer2.Text.ToString());
                FamilyObservations otherPage2 = new FamilyObservations();
                otherPage2.InstanceRef51 = this;
                otherPage2.Show();
                this.Hide();
            } else if (Globals.interview_page == 53) {
                FamilyObservations additionalNotes = new FamilyObservations();
                additionalNotesPanel.BringToFront();
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            saveWrittenAnswerToDB("otComments", "OTComments", textBox1.Text.ToString());
            Summary sum = new Summary();
            sum.Show();
        }

        private void saveWrittenAnswerToDB(string tableName, string columnName, string comment) {
            SqlCommand cmdDatabase;
            const string constring = @"Data Source =(LocalDB)\MSSQLLocalDB;" +
                                    @"AttachDbFilename = |DataDirectory|\CapstoneDB\CapstoneDB.mdf; Integrated Security = True";
            SqlConnection conDatabase = new SqlConnection(constring);
            string query;
            //Determine if a little or a lot
            try {
                query = string.Format("UPDATE dbo.{0} SET " + columnName + " = @additionalCommentText WHERE interviewNumber = (SELECT MAX(interviewNumber) FROM dbo.{0}) ;", tableName);
                conDatabase.Open();
                cmdDatabase = new SqlCommand(query, conDatabase);
                //cmdDatabase = new SqlCommand("INSERT INTO dbo." + tableName + "(" + columnName + ") VALUES(@text);" , conDatabase);
                cmdDatabase.Parameters.AddWithValue("@additionalCommentText", comment);
                cmdDatabase.ExecuteNonQuery();
                conDatabase.Close();
            } catch (Exception ex) {
                MessageBox.Show("An error has occurred: " + ex.Message);
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
            else if (Globals.interview_page == 26) {
                this.Hide();
                InstanceRef26.Show();
            }
            else if (Globals.interview_page == 27) {
                this.Hide();
                InstanceRef27.Show();
            }
            else if (Globals.interview_page == 28) {
                this.Hide();
                InstanceRef28.Show();
            }
            else if (Globals.interview_page == 29) {
                this.Hide();
                InstanceRef29.Show();
            }
            else if (Globals.interview_page == 30) {
                this.Hide();
                InstanceRef30.Show();
            }
            else if (Globals.interview_page == 31) {
                this.Hide();
                InstanceRef31.Show();
            }
            else if (Globals.interview_page == 32) {
                this.Hide();
                InstanceRef32.Show();
            }
            else if (Globals.interview_page == 33) {
                this.Hide();
                InstanceRef33.Show();
            }
            else if (Globals.interview_page == 34) {
                this.Hide();
                InstanceRef34.Show();
            }
            else if (Globals.interview_page == 35) {
                this.Hide();
                InstanceRef35.Show();
            }
            else if (Globals.interview_page == 36) {
                this.Hide();
                InstanceRef36.Show();
            }
            else if (Globals.interview_page == 37) {
                this.Hide();
                InstanceRef37.Show();
            }
            else if (Globals.interview_page == 38) {
                this.Hide();
                InstanceRef38.Show();
            }
            else if (Globals.interview_page == 39) {
                this.Hide();
                InstanceRef39.Show();
            }
            else if (Globals.interview_page == 40) {
                this.Hide();
                InstanceRef40.Show();
            }
            else if (Globals.interview_page == 41) {
                this.Hide();
                InstanceRef41.Show();
            }
            else if (Globals.interview_page == 42) {
                this.Hide();
                InstanceRef42.Show();
            }
            else if (Globals.interview_page == 43) {
                this.Hide();
                InstanceRef43.Show();
            }
            else if (Globals.interview_page == 44) {
                this.Hide();
                InstanceRef44.Show();
            }
            else if (Globals.interview_page == 45) {
                this.Hide();
                InstanceRef45.Show();
            }
            else if (Globals.interview_page == 46) {
                this.Hide();
                InstanceRef46.Show();
            }
            else if (Globals.interview_page == 47) {
                this.Hide();
                InstanceRef47.Show();
            }
            else if (Globals.interview_page == 48) {
                this.Hide();
                InstanceRef48.Show();
            }
            else if (Globals.interview_page == 49) {
                this.Hide();
                InstanceRef49.Show();
            }
            else if (Globals.interview_page == 50) {
                this.Hide();
                InstanceRef50.Show();
            }
            else if (Globals.interview_page == 51) {
                this.Hide();
                InstanceRef51.Show();
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

        private void disablePBs () {
            topLeftPB.Enabled = false;
            topMidPB.Enabled = false;
            topRightPB.Enabled = false;
            bottomLeftPB.Enabled = false;
            bottomMidPB.Enabled = false;
            bottomRightPB.Enabled = false;
        }
        /// <summary>
        /// Initial Images when user clicks on back button on second interview slide (when nextCounter === 0)
        /// </summary>

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

            topLeftPBPlayer.SoundLocation = topLeftReadOutLoudPath;
            topLeftPBPlayer.Play();

            hideButtons();
            displayButtons(topLeftPBALittleBtn, topLeftPBALotBtn);
        }
        private void topMidPB_Click(object sender, EventArgs e) {
            topLeftPBPlayer.SoundLocation = topMiddleReadOutLoudPath;
            topLeftPBPlayer.Play();
            hideButtons();
            displayButtons(topMidALittleBtn, topMidALotBtn);
        }
        private void topRightPB_Click(object sender, EventArgs e) {
            topLeftPBPlayer.SoundLocation = topRightReadOutLoudPath;
            topLeftPBPlayer.Play();
            hideButtons();
            displayButtons(topRightALittleBtn, topRightALotBtn);
        }
        private void bottomLeftPB_Click(object sender, EventArgs e) {
            topLeftPBPlayer.SoundLocation = bottomLeftReadOutLoudPath;
            topLeftPBPlayer.Play();
            hideButtons();
            displayButtons(bottomLeftALittleBtn, bottomLeftALotBtn);
        }
        private void bottomMidPB_Click(object sender, EventArgs e) {
            topLeftPBPlayer.SoundLocation = bottomMiddleReadOutLoudPath;
            topLeftPBPlayer.Play();
            hideButtons();
            displayButtons(bottomMidALittleBtn, bottomMidALotBtn);
        }
        private void bottomRightPB_Click(object sender, EventArgs e) {
            topLeftPBPlayer.SoundLocation = bottomrightReadOutLoudPath;
            topLeftPBPlayer.Play();

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

        private Form m_InstanceRef26 = null;
        public Form InstanceRef26 {
            get { return m_InstanceRef26; }
            set { m_InstanceRef26 = value; }
        }
        private Form m_InstanceRef27 = null;
        public Form InstanceRef27 {
            get { return m_InstanceRef27; }
            set { m_InstanceRef27 = value; }
        }
        private Form m_InstanceRef28 = null;
        public Form InstanceRef28 {
            get { return m_InstanceRef28; }
            set { m_InstanceRef28 = value; }
        }
        private Form m_InstanceRef29 = null;
        public Form InstanceRef29 {
            get { return m_InstanceRef29; }
            set { m_InstanceRef29 = value; }
        }
        private Form m_InstanceRef30 = null;
        public Form InstanceRef30 {
            get { return m_InstanceRef30; }
            set { m_InstanceRef30 = value; }
        }

        private Form m_InstanceRef31 = null;
        public Form InstanceRef31 {
            get { return m_InstanceRef31; }
            set { m_InstanceRef31 = value; }
        }
        private Form m_InstanceRef32 = null;
        public Form InstanceRef32 {
            get { return m_InstanceRef32; }
            set { m_InstanceRef32 = value; }
        }
        private Form m_InstanceRef33 = null;
        public Form InstanceRef33 {
            get { return m_InstanceRef33; }
            set { m_InstanceRef33 = value; }
        }
        private Form m_InstanceRef34 = null;
        public Form InstanceRef34 {
            get { return m_InstanceRef34; }
            set { m_InstanceRef34 = value; }
        }
        private Form m_InstanceRef35 = null;
        public Form InstanceRef35 {
            get { return m_InstanceRef35; }
            set { m_InstanceRef35 = value; }
        }
        private Form m_InstanceRef36 = null;
        public Form InstanceRef36 {
            get { return m_InstanceRef36; }
            set { m_InstanceRef36 = value; }
        }

        private Form m_InstanceRef37 = null;
        public Form InstanceRef37 {
            get { return m_InstanceRef37; }
            set { m_InstanceRef37 = value; }
        }
        private Form m_InstanceRef38 = null;
        public Form InstanceRef38 {
            get { return m_InstanceRef38; }
            set { m_InstanceRef38 = value; }
        }
        private Form m_InstanceRef39 = null;
        public Form InstanceRef39 {
            get { return m_InstanceRef39; }
            set { m_InstanceRef39 = value; }
        }
        private Form m_InstanceRef40 = null;
        public Form InstanceRef40 {
            get { return m_InstanceRef40; }
            set { m_InstanceRef40 = value; }
        }
        private Form m_InstanceRef41 = null;
        public Form InstanceRef41 {
            get { return m_InstanceRef41; }
            set { m_InstanceRef41 = value; }
        }
        private Form m_InstanceRef42 = null;
        public Form InstanceRef42 {
            get { return m_InstanceRef42; }
            set { m_InstanceRef42 = value; }
        }
        private Form m_InstanceRef43 = null;
        public Form InstanceRef43 {
            get { return m_InstanceRef43; }
            set { m_InstanceRef43 = value; }
        }
        private Form m_InstanceRef44 = null;
        public Form InstanceRef44 {
            get { return m_InstanceRef44; }
            set { m_InstanceRef44 = value; }
        }
        private Form m_InstanceRef45 = null;
        public Form InstanceRef45 {
            get { return m_InstanceRef45; }
            set { m_InstanceRef45 = value; }
        }
        private Form m_InstanceRef46 = null;
        public Form InstanceRef46 {
            get { return m_InstanceRef46; }
            set { m_InstanceRef46 = value; }
        }
        private Form m_InstanceRef47 = null;
        public Form InstanceRef47 {
            get { return m_InstanceRef47; }
            set { m_InstanceRef47 = value; }
        }
        private Form m_InstanceRef48 = null;
        public Form InstanceRef48 {
            get { return m_InstanceRef48; }
            set { m_InstanceRef48 = value; }
        }
        private Form m_InstanceRef49 = null;
        public Form InstanceRef49 {
            get { return m_InstanceRef49; }
            set { m_InstanceRef49 = value; }
        }
        private Form m_InstanceRef50 = null;
        public Form InstanceRef50 {
            get { return m_InstanceRef50; }
            set { m_InstanceRef50 = value; }
        }
        private Form m_InstanceRef51 = null;
        public Form InstanceRef51 {
            get { return m_InstanceRef51; }
            set { m_InstanceRef51 = value; }
        }
    }
}

