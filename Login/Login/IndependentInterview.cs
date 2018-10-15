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
    public partial class IndependentInterview : Form {

        private System.Media.SoundPlayer topLeftPBPlayer = new System.Media.SoundPlayer();
        private string topLeftReadOutLoudPath;
        private string topMiddleReadOutLoudPath;
        private string topRightReadOutLoudPath;
        private string bottomLeftReadOutLoudPath;
        private string bottomMiddleReadOutLoudPath;
        private string bottomrightReadOutLoudPath;
        private void openQuestionPanel()
        {
            questionPanel.BringToFront();
            readOutLoudPanel.BringToFront();
        }

        private void openPicturePanel()
        {
            picturePanel.BringToFront();
            readOutLoudPanel.BringToFront();
        }

        public IndependentInterview() {
            
            InitializeComponent();
            Globals.shortResponse = true;
            this.Location = new Point(0, 0);
            btnPreviousInterview.Click += previousInterviewSlideBtn_Click;
            //Dynamically create the circular picture boxes
            createCirclePB(bottomLeftPB);
            createCirclePB(bottomLeftPB2);

            createCirclePB(bottomRightPB);
            createCirclePB(bottomRightPB2);

            createCirclePB(bottomMidPB);
            createCirclePB(bottomMidPB2);

            createCirclePB(topLeftPB);
            createCirclePB(topLeftPB2);

            createCirclePB(topRightPB);
            createCirclePB(topRightPB2);

            createCirclePB(topMidPB);
            createCirclePB(topMidPB2);

            Globals.shortResponse = true;
            openPicturePanel();

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
                interviewPage1p3();
                openQuestionPanel();
            }
            else if (Globals.interview_page == 4) {
                interviewPage2();
                openQuestionPanel();
            }
            else if (Globals.interview_page == 5) {
                interviewPage3();
            }
            else if (Globals.interview_page == 6) {
                interviewPage3p2();
                openQuestionPanel();
            }
            else if (Globals.interview_page == 7) {
                interviewPage4();
            }
            else if (Globals.interview_page == 8) {
                interviewPage4p2();
                openQuestionPanel();
            }
            else if (Globals.interview_page == 9) {
                interviewPage5and6();
                openQuestionPanel();
            }
            else if (Globals.interview_page == 10) {
                interviewPage7();
            }
            else if (Globals.interview_page == 11) {
                interviewPage7p2();
                openQuestionPanel();
            }
            else if (Globals.interview_page == 12) {
                interviewPage8();
                openQuestionPanel();
            }
            else if (Globals.interview_page == 13) {
                interviewPage9();
            }
            else if (Globals.interview_page == 14) {
                interviewPage9p2();
                openQuestionPanel();
            }
            else if (Globals.interview_page == 15) {
                interviewPage10();
                openQuestionPanel();
            }
            else if (Globals.interview_page == 16) {
                sightInterviewPage1();
                SightColours();
            }
            else if (Globals.interview_page == 17) {
                sightInterviewPage1p2();
                openQuestionPanel();
                SightColours();
            }
            else if (Globals.interview_page == 18) {
                sightInterviewPage2();
                openQuestionPanel();
                SightColours();
            }
            else if (Globals.interview_page == 19) {
                sightInterviewPage3();
                SightColours();
            }
            else if (Globals.interview_page == 20) {
                sightInterviewPage3p2();
                openQuestionPanel();
                SightColours();
            }
            else if (Globals.interview_page == 21) {
                sightInterviewPage4();
                SightColours();
            }
            else if (Globals.interview_page == 22) {
                sightInterviewPage4p2();
                openQuestionPanel();
                SightColours();
            }
            else if (Globals.interview_page == 23) {
                sightInterviewPage5();
                openQuestionPanel();
                SightColours();
            }
            else if (Globals.interview_page == 24) {
                touchInterviewPage1();
                TouchColours();
            }
            else if (Globals.interview_page == 25) {
                touchInterviewPage1p2();
                TouchColours();
            }
            else if (Globals.interview_page == 26) {
                touchInterviewPage1p3();
                openQuestionPanel();
                TouchColours();
            }
            else if (Globals.interview_page == 27) {
                touchInterviewPage2();
                openQuestionPanel();
                TouchColours();
            }
            else if (Globals.interview_page == 28) {
                touchInterviewPage3();
                TouchColours();
            }
            else if (Globals.interview_page == 29) {
                touchInterviewPage3p2();
                TouchColours();
            }
            else if (Globals.interview_page == 30) {
                touchInterviewPage3p3();
                openQuestionPanel();
                TouchColours();
            }
            else if (Globals.interview_page == 31) {
                touchInterviewPage4();
                openQuestionPanel();
                TouchColours();
            }
            else if (Globals.interview_page == 32) {
                touchInterviewPage5();
                TouchColours();
            }
            else if (Globals.interview_page == 33) {
                touchInterviewPage5p2();
                openQuestionPanel();
                TouchColours();
            }
            else if (Globals.interview_page == 34) {
                touchInterviewPage6();
                openQuestionPanel();
                TouchColours();
            }
            else if (Globals.interview_page == 35) {
                smellInterviewPage1();
                TouchColours();
            }
            else if (Globals.interview_page == 36) {
                smellInterviewPage1p2();
                openQuestionPanel();
                SmellColours();
            }
            else if (Globals.interview_page == 37) {
                smellInterviewPage2();
                openQuestionPanel();
                SmellColours();
            }
            else if (Globals.interview_page == 38) {
                smellInterviewPage3();
                SmellColours();
            }
            else if (Globals.interview_page == 39) {
                smellInterviewPage3p2();
                openQuestionPanel();
                SmellColours();
            }
            else if (Globals.interview_page == 40) {
                smellInterviewPage4();
                openQuestionPanel();
                SmellColours();
            }
            else if (Globals.interview_page == 41) {
                tasteInterviewPage1();
                TasteColours();
            }
            else if (Globals.interview_page == 42) {
                tasteInterviewPage1p2();
                TasteColours();
            }
            else if (Globals.interview_page == 43) {
                tasteInterviewPage1p3();
                openQuestionPanel();
                TasteColours();
            }
            else if (Globals.interview_page == 44) {
                tasteInterviewPage2();
                TasteColours();
            }
            else if (Globals.interview_page == 45) {
                tasteInterviewPage2p2();
                TasteColours();
            }
            else if (Globals.interview_page == 46) {
                tasteInterviewPage2p3();
                openQuestionPanel();
                TasteColours();
            }
            else if (Globals.interview_page == 47) {
                tasteInterviewPage3();
                openQuestionPanel();
                TasteColours();
            }
            else if (Globals.interview_page == 48) {
                tasteInterviewPage4();
                TasteColours();
            }
            else if (Globals.interview_page == 49) {
                tasteInterviewPage4p2();
                openQuestionPanel();
                TasteColours();
            }
            else if (Globals.interview_page == 50) {
                tasteInterviewPage5();
                openQuestionPanel();
                TasteColours();
            }
            else if (Globals.interview_page == 51) {
                tasteInterviewPage6();
                TasteColours();
            }
            else if (Globals.interview_page == 52) {
                tasteInterviewPage6p2();
                openQuestionPanel();
                TasteColours();
            }
            else if (Globals.interview_page == 53) {
                tasteInterviewPage7();
                openQuestionPanel();
                TasteColours();
            }
            else if (Globals.interview_page == 54) {
                mvmtInterviewPage1();
                MovementColours();
            }
            else if (Globals.interview_page == 55) {
                mvmtInterviewPage1p2();
                openQuestionPanel();
                MovementColours();
            }
            else if (Globals.interview_page == 56) {
                mvmtInterviewPage2();
                openQuestionPanel();
                MovementColours();
            }
            else if (Globals.interview_page == 57) {
                mvmtInterviewPage3();
                MovementColours();
            }
            else if (Globals.interview_page == 58) {
                mvmtInterviewPage3p2();
                openQuestionPanel();
                MovementColours();
            }
            else if (Globals.interview_page == 59) {
                mvmtInterviewPage4();
                MovementColours();
            }
            else if (Globals.interview_page == 60) {
                mvmtInterviewPage4p2();
                openQuestionPanel();
                MovementColours();
            }
            else if (Globals.interview_page == 61) {
                mvmtInterviewPage5();
                MovementColours();
            }
            else if (Globals.interview_page == 62) {
                mvmtInterviewPage5p2();
                openQuestionPanel();
                MovementColours();
            }
            else if (Globals.interview_page == 63) {
                mvmtInterviewPage6();
                openQuestionPanel();
                MovementColours();
            }
            else if (Globals.interview_page == 64) {
                environmentPage1();
                EnvironmentColours();
            }
            else if (Globals.interview_page == 65) {
                environmentPage1p2();
                openQuestionPanel();
                EnvironmentColours();
            }
            else if (Globals.interview_page == 66) {
                environmentPage2();
                openQuestionPanel();
                EnvironmentColours();
            }
            else if (Globals.interview_page == 67) {
                otherInterviewPage1();
                OtherColours();
            }
            else if (Globals.interview_page == 68) {
                otherInterviewPage1p2();
                openQuestionPanel();
                OtherColours();
            }
            else if (Globals.interview_page == 69) {
                otherInterviewPage2();
                openQuestionPanel();
                OtherColours();
            }
            else if (Globals.interview_page == 70) {
                additionalNotesPanel.BringToFront();
            }
        }
        
        /// <summary>
        /// Sound
        /// </summary>
        private void interviewPage1() {
            //axWindowsMediaPlayer1.URL = @"..\..\resources\0testsound.mp3";
            lblQuestion.Text = "Are there some sounds that you don't like?";
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

        private void interviewPage1p2() {
            lblQuestion.Text = "Are there some sounds that you don't like?";
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

        private void interviewPage1p3() {
            panel2lblQuestion.Text = "Are there some sounds that you don't like?";
            lblQuestion1.Text = "Other sounds that you don't like?";
            lblQuestion2.Text = "Examples in your daily life?";
        }

        private void interviewPage2() {
            panel2lblQuestion.Text = "Are there some sounds that you don't like?";
            lblQuestion1.Text = "Do you do anything to avoid these sounds (e.g., cover your ears, avoid noisy places?";
            lblQuestion2.Text = "";
            tbAnswer2.Visible = false;
        }

        private void interviewPage3() {
            lblQuestion.Text = "Are there times when it is hard for you to listen?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\1. Hearing\2. Are there times when it is hard to listen_\1 If I am concentrating on something, I don't notice people talking to me.png");
            topLeftReadOutLoudPath = @"..\..\resources\1. Hearing\2. Are there times when it is hard to listen_\1.2.1Concentration.wav";

            topMidPB.Image = new Bitmap(@"..\..\resources\1. Hearing\2. Are there times when it is hard to listen_\2 I find it hard to listen in noisy classrooms (self-report version).jpg");
            topMiddleReadOutLoudPath = @"..\..\resources\1. Hearing\2. Are there times when it is hard to listen_\1.2.2NoisyClassroom.wav";

            topRightPB.Image = new Bitmap(@"..\..\resources\1. Hearing\2. Are there times when it is hard to listen_\3 I find it hard to listen to someone talking to me when I'm in a group.jpg");
            topRightReadOutLoudPath = @"..\..\resources\1. Hearing\2. Are there times when it is hard to listen_\1.2.3ListenToSomone.wav";
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

        private void interviewPage3p2() {
            panel2lblQuestion.Text = "Are there times when it is hard for you to listen?";
            lblQuestion1.Text = "Other times when it is hard to listen?";
            lblQuestion2.Text = "Examples in your daily life?";
        }

        private void interviewPage4() {
            lblQuestion.Text = "Are there some sounds that make it hard for you to concentrate?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\1. Hearing\3. Are there some sounds that make it hard for you to concentrate_\1 Radio on.jpg");
            topLeftReadOutLoudPath = @"..\..\resources\1. Hearing\3. Are there some sounds that make it hard for you to concentrate_\1.3.1Radio.wav";

            topMidPB.Image = new Bitmap(@"..\..\resources\1. Hearing\3. Are there some sounds that make it hard for you to concentrate_\2 Clock ticking.jpg");
            topMiddleReadOutLoudPath = @"..\..\resources\1. Hearing\3. Are there some sounds that make it hard for you to concentrate_\1.3.2ClockTicking.wav";

            topRightPB.Image = new Bitmap(@"..\..\resources\1. Hearing\3. Are there some sounds that make it hard for you to concentrate_\3 People talking.png");
            topRightReadOutLoudPath = @"..\..\resources\1. Hearing\3. Are there some sounds that make it hard for you to concentrate_\1.3.3PeopleTalking.wav";
            //bottomLeftPB.Image = new Bitmap(@"../../resources/");
            //bottomMidPB.Image = new Bitmap(@"../../resources/");
            //bottomRightPB.Image = new Bitmap(@"../../resources/");
            updateLabelText("Radio on", "Clock ticking", "People talking", "", "", "");
        }

        private void interviewPage4p2() {
            panel2lblQuestion.Text = "Are there some sounds that make it hard for you to concentrate?";
            lblQuestion1.Text = "Other sounds that make it hard to concentrate?";
            lblQuestion2.Text = "Examples in your daily life?";
        }

        private void interviewPage5and6() {
            panel2lblQuestion.Text = "Are there some sounds that make it hard for you to concentrate?";
            lblQuestion1.Text = "Are there noises that you find very distracting when you have a job to do?";
            lblQuestion2.Text = "Does noise ever make it hard for you to do things (e.g., work in an office, go to shopping centres)?";
        }

        private void interviewPage7() {
            lblQuestion.Text = "Are there some sounds that you like to listen to?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\1. Hearing\4. Are there sounds that you like to listen to_\1 Computer sounds.jpg");
            topLeftReadOutLoudPath = @"..\..\resources\1. Hearing\4. Are there sounds that you like to listen to_\1.4.1ComputerSounds.wav";

            topMidPB.Image = new Bitmap(@"..\..\resources\1. Hearing\4. Are there sounds that you like to listen to_\2 Live Music.jpg");
            topMiddleReadOutLoudPath = @"..\..\resources\1. Hearing\4. Are there sounds that you like to listen to_\1.4.2LiveMusic.wav";

            topRightPB.Image = new Bitmap(@"..\..\resources\1. Hearing\4. Are there sounds that you like to listen to_\3 Fans.PNG");
            topRightReadOutLoudPath = @"..\..\resources\1. Hearing\4. Are there sounds that you like to listen to_\1.4.3Fans.wav";

            bottomLeftPB.Image = new Bitmap(@"..\..\resources\1. Hearing\4. Are there sounds that you like to listen to_\4 Music through my phone (cropped).jpg");
            bottomLeftReadOutLoudPath = @"..\..\resources\1. Hearing\24. Are there sounds that you like to listen to_\1.4.4MusicPhone.wav";

            bottomMidPB.Image = new Bitmap(@"..\..\resources\1. Hearing\4. Are there sounds that you like to listen to_\5 Rhythms.jpg");
            bottomLeftReadOutLoudPath = @"..\..\resources\1. Hearing\4. Are there sounds that you like to listen to_\1.4.5Rythms.wav";

            //bottomRightPB.Image = new Bitmap(@"../../resources/");
            updateLabelText("Computer sounds", "Live music", "Fans", "Music through my phone", "Rhythms", "");
        }

        private void interviewPage7p2() {
            panel2lblQuestion.Text = "Are there some sounds that you like to listen to?";
            lblQuestion1.Text = "Other sounds that you like?";
            lblQuestion2.Text = "Examples in your daily life?";
        }

        private void interviewPage8() {
            panel2lblQuestion.Text = "Are there some sounds that you like to listen to?";
            lblQuestion1.Text = "Are there sounds that you like to listen to often or for long periods?";
            lblQuestion2.Text = "";
            tbAnswer2.Visible = false;
        }

        private void interviewPage9() {
            lblQuestion.Text = "Are there some sounds that you make a lot?";
            //topLeftPB.Image = new Bitmap(@"");
            topMidPB.Image = new Bitmap(@"..\..\resources\1. Hearing\5. Are there some sounds that you make a lot_\2 Tapping feet.PNG");
            topMiddleReadOutLoudPath = @"..\..\resources\1. Hearing\2. Are there times when it is hard to listen_\1.5.1Feet.wav";

            topRightPB.Image = new Bitmap(@"..\..\resources\1. Hearing\5. Are there some sounds that you make a lot_\3 Tapping fingers.jpg");
            topRightReadOutLoudPath = @"..\..\resources\1. Hearing\5. Are there some sounds that you make a lot_\1.5.3Finger.wav";

            bottomLeftPB.Image = new Bitmap(@"..\..\resources\1. Hearing\5. Are there some sounds that you make a lot_\4 Clicking pen.jpg");
            bottomLeftReadOutLoudPath = @"..\..\resources\1. Hearing\5. Are there some sounds that you make a lot_\1.5.4Pen.wav";

            //bottomMidPB.Image = new Bitmap(@"");
            //bottomRightPB.Image = new Bitmap(@"../../resources/");
            updateLabelText("Humming or whistling to myself", "Tapping feet", "Tapping fingers", "Clicking pen",
                "", "");
        }

        private void interviewPage9p2() {
            panel2lblQuestion.Text = "Are there some sounds that you make a lot?";
            lblQuestion1.Text = "Other sounds that you make:";
            lblQuestion2.Text = "Examples in your daily life:";
        }

        private void interviewPage10() {
            panel2lblQuestion.Text = "Are there some sounds that you make a lot?";
            lblQuestion1.Text = "Do the sounds you make seem to bother other people?";
            lblQuestion2.Text = "";
            tbAnswer2.Visible = false;
        }

        /// <summary>
        /// Sight
        /// </summary>
        private void sightInterviewPage1() {
            lblQuestion.Text = "Are there some things that you don't like to look at?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\2. Sight\1. Are there some things that you don't like to look at_\1 Sunlight.jpg");
            topLeftReadOutLoudPath = @"..\..\resources\2. Sight\1. Are there some things that you don't like to look at_\2.1.1Sunlight.wav";

            topMidPB.Image = new Bitmap(@"..\..\resources\2. Sight\1. Are there some things that you don't like to look at_\2 Fluorescent light.png");
            topMiddleReadOutLoudPath = @"..\..\resources\2. Sight\1. Are there some things that you don't like to look at_\2.1.2Fluorescent.wav";

            topRightPB.Image = new Bitmap(@"..\..\resources\2. Sight\1. Are there some things that you don't like to look at_\3 Light and Shadow.jpg");
            topRightReadOutLoudPath = @"..\..\resources\2. Sight\1. Are there some things that you don't like to look at_\2.1.3LightShadow.wav";

            bottomLeftPB.Image = new Bitmap(@"..\..\resources\2. Sight\1. Are there some things that you don't like to look at_\4 Busy Patterns.jpg");
            bottomLeftReadOutLoudPath = @"..\..\resources\2. Sight\1. Are there some things that you don't like to look at_\2.1.4BusyPatterms.wav";

            bottomMidPB.Image = new Bitmap(@"..\..\resources\2. Sight\1. Are there some things that you don't like to look at_\5 Lecture room light (self version) (cropped).jpg");
            bottomMiddleReadOutLoudPath = @"..\..\resources\2. Sight\1. Are there some things that you don't like to look at_\2.1.5Lecture.wav";


            updateLabelText("Sunlight", "Fluorescent light", "Light and shadow", "Busy patterns",
                "Lecture room light", "");
        }

        private void sightInterviewPage1p2() {
            panel2lblQuestion.Text = "Are there some things that you don't like to look at?";
            lblQuestion1.Text = "Other things that you don’t like to look at?";
            lblQuestion2.Text = "Examples in your daily life?";
        }

        private void sightInterviewPage2() {
            panel2lblQuestion.Text = "Are there some things that you don't like to look at?";
            lblQuestion1.Text = "Do you do anything to avoid these things (e.g., shade your eyes, wear sunglasses, avoid fluorescent light)?";
            lblQuestion2.Text = "";
            tbAnswer2.Visible = false;
        }

        private void sightInterviewPage3() {
            lblQuestion.Text = "Are there some things you see that make it hard to concentrate?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\2. Sight\2. Are there some things you see that make it hard to concentrate_\1 Lots of things in a messy drawer.jpg");
            topLeftReadOutLoudPath = @"..\..\resources\2. Sight\2. Are there some things you see that make it hard to concentrate_\2.2.1MessyDrawer.wav";

            topMidPB.Image = new Bitmap(@"..\..\resources\2. Sight\2. Are there some things you see that make it hard to concentrate_\2 People running around me.jpg");
            topMiddleReadOutLoudPath = @"..\..\resources\2. Sight\2. Are there some things you see that make it hard to concentrate_\2.2.2RunningAroundMe.wav";

            topRightPB.Image = new Bitmap(@"..\..\resources\2. Sight\2. Are there some things you see that make it hard to concentrate_\3 Lots of clutter in an office space (self report).jpg");
            topRightReadOutLoudPath = @"..\..\resources\2. Sight\2. Are there some things you see that make it hard to concentrate_\2.2.3ClutterOffice.wav";

            // bottomLeftPB.Image = new Bitmap(@"..\..\resources\2. Sight\1. Are there some things that you don't like to look at_\");
            //bottomMidPB.Image = new Bitmap(@"..\..\resources\2. Sight\1. Are there some things that you don't like to look at_\");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\2. Sight\1. Are there some things that you don't like to look at_\");
            updateLabelText("Lots of things in a messy drawer", "People running around me", "Lots of clutter in an office or work space", "", "", "");
        }

        private void sightInterviewPage3p2() {
            panel2lblQuestion.Text = "Are there some things you see that make it hard to concentrate?";
            lblQuestion1.Text = "Other things you see that make it hard to concentrate?";
            lblQuestion2.Text = "Examples in your daily life?";
        }

        private void sightInterviewPage4() {
            lblQuestion.Text = "Are there some things that you like to look at?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\2. Sight\3. Are there some things that you like to look at_\1 Moving lights.jpg");
            topLeftReadOutLoudPath = @"..\..\resources\2. Sight\3. Are there some things that you like to look at_\2.3.1MovingLights.wav";

            topMidPB.Image = new Bitmap(@"..\..\resources\2. Sight\3. Are there some things that you like to look at_\2 Things that sparkle.png");
            topMiddleReadOutLoudPath = @"..\..\resources\2. Sight\3. Are there some things that you like to look at_\2.3.2ThingsSparkle.wav";

            topRightPB.Image = new Bitmap(@"..\..\resources\2. Sight\3. Are there some things that you like to look at_\3 Geometric patterns.jpg");
            topRightReadOutLoudPath = @"..\..\resources\2. Sight\3. Are there some things that you like to look at_\2.3.3Geometric.wav";

            bottomLeftPB.Image = new Bitmap(@"..\..\resources\2. Sight\3. Are there some things that you like to look at_\4 Spinning fans.png");
            bottomLeftReadOutLoudPath = @"..\..\resources\2. Sight\3. Are there some things that you like to look at_\2.3.4Fans.wav";

            bottomMidPB.Image = new Bitmap(@"..\..\resources\2. Sight\3. Are there some things that you like to look at_\5 Spinning objects1 (use this one) (cropped).jpg");
            bottomMiddleReadOutLoudPath = @"..\..\resources\2. Sight\3. Are there some things that you like to look at_\2.3.5Spinning.wav";
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\2. Sight\3. Are there some things that you don't like to look at_\");
            updateLabelText("Moving lights", "Things that sparkle", "Geometric patterns", "Spinning fans", "Spinning objects", "");
        }

        private void sightInterviewPage4p2() {
            panel2lblQuestion.Text = "Are there some things that you like to look at?";
            lblQuestion1.Text = "Other things that you like to look at?";
            lblQuestion2.Text = "Examples in your daily life?";
        }

        private void sightInterviewPage5() {
            panel2lblQuestion.Text = "Are there some things that you like to look at?";
            lblQuestion1.Text = "Are there things you look at often or for long periods?";
            lblQuestion2.Text = "";
            tbAnswer2.Visible = false;
        }

        /// <summary>
        /// Touch
        /// </summary>
        private void touchInterviewPage1() {
            lblQuestion.Text = "Are there some things that you don't like the feeling of?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\1 Sandy.jpg");
            topLeftReadOutLoudPath = @"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\3.1.1Sandy.wav";

            topMidPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\2 Sticky.jpg");
            topMiddleReadOutLoudPath = @"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\3.1.2Sticky.wav";

            topRightPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\3 Grassy.jpg");
            topRightReadOutLoudPath = @"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\3.1.3Grassy.wav";

            bottomLeftPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\4 Wool clothes.jpg");
            bottomLeftReadOutLoudPath = @"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\3.1.4Wool.wav";

            bottomMidPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\5 Tight clothes.jpg");
            bottomMiddleReadOutLoudPath = @"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\3.1.5Tight.wav";

            bottomRightPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\6 Stiff clothes.jpg");
            bottomrightReadOutLoudPath = @"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\3.1.6Stiff.wav";

            updateLabelText("Sandy", "Sticky", "Grassy", "Wool clothes",
                "Tight clothes", "Stiff clothes");
        }

        private void touchInterviewPage1p2() {
            lblQuestion.Text = "Are there some things that you don't like the feeling of?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\7 Shoes.jpg");
            topLeftReadOutLoudPath = @"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\3.1.7Shoes.wav";

            topMidPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\8 Splashing Water (cropped).jpg");
            topMiddleReadOutLoudPath = @"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\3.1.8SplashingWater.wav";

            //topRightPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\Geometric patterns.jpg");
            //bottomLeftPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\.jpg");
            //bottomMidPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\Spinning objects.jpg");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there some things that you don't like the feeling of_\");
            updateLabelText("Shoes", "Splashing water (e.g. rain, shower, pool)", "", "",
                "", "");
        }

        private void touchInterviewPage1p3() {
            panel2lblQuestion.Text = "Are there some things that you don't like the feeling of?";
            lblQuestion1.Text = "Other things you don’t like the feeling of";
            lblQuestion2.Text = "Examples in your daily life?";
        }

        private void touchInterviewPage2() {
            panel2lblQuestion.Text = "Are there some things that you don't like the feeling of?";
            lblQuestion1.Text = "Do touch sensations ever make it hard for you to do things (e.g., wear some types of clothing or walk on the grass)?";
            lblQuestion2.Text = "Does you do anything to avoid these things (e.g., avoid certain clothes or textures)?";
        }

        private void touchInterviewPage3() {
            lblQuestion.Text = "Are there some ways that people touch you that you don't like?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\3. Touch\2. Are there ways that people touch you that you don't like_\1 Being hugged or kissed (cropped).jpg");
            topLeftReadOutLoudPath = @"..\..\resources\3. Touch\2. Are there ways that people touch you that you don't like_\3.2.1Hugged.wav";

            topMidPB.Image = new Bitmap(@"..\..\resources\3. Touch\2. Are there ways that people touch you that you don't like_\2 Being crowded (cropped).jpg");
            topMiddleReadOutLoudPath = @"..\..\resources\3. Touch\2. Are there ways that people touch you that you don't like_\3.2.2Crowded.wav";

            topRightPB.Image = new Bitmap(@"..\..\resources\3. Touch\2. Are there ways that people touch you that you don't like_\3 Being tapped on the shoulder (self-report version).jpg");
            topRightReadOutLoudPath = @"..\..\resources\3. Touch\2. Are there ways that people touch you that you don't like_\3.2.3Tapped.wav";

            bottomLeftPB.Image = new Bitmap(@"..\..\resources\3. Touch\2. Are there ways that people touch you that you don't like_\4 Having sunscreen put on.jpg");
            bottomLeftReadOutLoudPath = @"..\..\resources\3. Touch\2. Are there ways that people touch you that you don't like_\3.2.4Sunscreen.wav";

            bottomMidPB.Image = new Bitmap(@"..\..\resources\3. Touch\2. Are there ways that people touch you that you don't like_\5 Being bumped.jpg");
            bottomMiddleReadOutLoudPath = @"..\..\resources\3. Touch\2. Are there ways that people touch you that you don't like_\3.2.5Bumped.wav";

            bottomRightPB.Image = new Bitmap(@"..\..\resources\3. Touch\2. Are there ways that people touch you that you don't like_\6 Having a haircut (cropped).jpg");
            bottomrightReadOutLoudPath = @"..\..\resources\3. Touch\2. Are there ways that people touch you that you don't like_\3.2.6Haircut.wav";

            updateLabelText("Being hugged or kissed", "Being crowded", "Being tapped on the shoulder", "Having sunscreen put on",
                "Being bumped", "Having a haircut");
        }

        private void touchInterviewPage3p2() {
            lblQuestion.Text = "Are there some ways that people touch you that you don't like?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\3. Touch\2. Are there ways that people touch you that you don't like_\7 Doctor touching me.jpg");
            topLeftReadOutLoudPath = @"..\..\resources\3. Touch\2. Are there ways that people touch you that you don't like_\3.2.7Doctor.wav";

            topMidPB.Image = new Bitmap(@"..\..\resources\3. Touch\2. Are there ways that people touch you that you don't like_\8 Dentist touching me (cropped).jpg");
            topMiddleReadOutLoudPath = @"..\..\resources\3. Touch\2. Are there ways that people touch you that you don't like_\3.2.8Dentist.wav";

            //topRightPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there things that you don't like the feeling of_\Geometric patterns.jpg");
            //bottomLeftPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there things that you don't like the feeling of_\.jpg");
            //bottomMidPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there things that you don't like the feeling of_\Spinning objects.jpg");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\3. Touch\1. Are there things that you don't like the feeling of_\");
            updateLabelText("Doctor touching me", "Dentist touch me", "", "",
                "", "");
        }

        private void touchInterviewPage3p3() {
            panel2lblQuestion.Text = "Are there some ways that people touch you that you don't like?";
            lblQuestion1.Text = "Other ways people touch you that you don’t like?";
            lblQuestion2.Text = "Examples in your daily life?";
        }

        private void touchInterviewPage4() {
            panel2lblQuestion.Text = "Are there some ways that people touch you that you don't like?";
            lblQuestion1.Text = "Does difficulty coping with being touched make it hard for you to do things (e.g., visit the doctor or the dentist)?";
            lblQuestion2.Text = "Do you do anything to avoid being touched (e.g., avoid crowded places)?";
        }

        private void touchInterviewPage5() {
            lblQuestion.Text = "Are there some things that you like the feeling of?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\3. Touch\3. Are there some things that you like the feeling of_\1 Soft.jpg");
            topLeftReadOutLoudPath = @"..\..\resources\3. Touch\3. Are there some things that you like the feeling of_\3.3.1Soft.wav";

            topMidPB.Image = new Bitmap(@"..\..\resources\3. Touch\3. Are there some things that you like the feeling of_\2 Rubbery.jpg");
            topMiddleReadOutLoudPath = @"..\..\resources\3. Touch\3. Are there some things that you like the feeling of_\3.3.2Rubbery.wav";

            topRightPB.Image = new Bitmap(@"..\..\resources\3. Touch\3. Are there some things that you like the feeling of_\3 Furry.jpg");
            topRightReadOutLoudPath = @"..\..\resources\3. Touch\3. Are there some things that you like the feeling of_\3.3.3Fury.wav";

            bottomLeftPB.Image = new Bitmap(@"..\..\resources\3. Touch\3. Are there some things that you like the feeling of_\4 Hugging people.jpg");
            bottomLeftReadOutLoudPath = @"..\..\resources\3. Touch\3. Are there some things that you like the feeling of_\3.3.4HuggingPeople.wav";

            bottomMidPB.Image = new Bitmap(@"..\..\resources\3. Touch\3. Are there some things that you like the feeling of_\5 Touching people.jpg");
            bottomMiddleReadOutLoudPath = @"..\..\resources\3. Touch\3. Are there some things that you like the feeling of_\3.3.5TouchingPeople.wav";

            bottomRightPB.Image = new Bitmap(@"..\..\resources\3. Touch\3. Are there some things that you like the feeling of_\6 Being squashed with a pillow.jpg");
            bottomrightReadOutLoudPath = @"..\..\resources\3. Touch\3. Are there some things that you like the feeling of_\3.3.6SquashedPillow.wav";
            updateLabelText("Soft", "Rubbery", "Furry", "Hugging people",
                "Touching people", "Being squashed with a pillow");
        }

        private void touchInterviewPage5p2() {
            panel2lblQuestion.Text = "Are there some things that you like the feeling of?";
            lblQuestion1.Text = "Other things that you like the feeling of?";
            lblQuestion2.Text = "Examples in your daily life?";
        }

        private void touchInterviewPage6() {
            panel2lblQuestion.Text = "Are there some things that you like the feeling of?";
            lblQuestion1.Text = "Are there things that you like to touch often or for long periods?";
            lblQuestion2.Text = "";
            tbAnswer2.Visible = false;
        }

        /// <summary>
        /// Smell
        /// </summary>
        private void smellInterviewPage1() {
            lblQuestion.Text = "Are there some smells that you don't like?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\4. Smells\1. Are there some smells that you don't like_\1 Cooking smells (cropped).jpg");
            topLeftReadOutLoudPath = @"..\..\resources\4. Smells\1. Are there some smells that you don't like_\4.1.1CookingSmells.wav";

            topMidPB.Image = new Bitmap(@"..\..\resources\4. Smells\1. Are there some smells that you don't like_\2 Food Smells.jpg");
            topMiddleReadOutLoudPath = @"..\..\resources\4. Smells\1. Are there some smells that you don't like_\4.1.2FoodSmells.wav";

            topRightPB.Image = new Bitmap(@"..\..\resources\4. Smells\1. Are there some smells that you don't like_\3 Cleaning products.jpg");
            topRightReadOutLoudPath = @"..\..\resources\4. Smells\1. Are there some smells that you don't like_\4.1.3CleaningProducts.wav";

            bottomLeftPB.Image = new Bitmap(@"..\..\resources\4. Smells\1. Are there some smells that you don't like_\4 Toilet Smells.jpg");
            bottomLeftReadOutLoudPath = @"..\..\resources\4. Smells\1. Are there some smells that you don't like_\4.1.4ToiletSmells.wav";

            bottomMidPB.Image = new Bitmap(@"..\..\resources\4. Smells\1. Are there some smells that you don't like_\5 Perfumes.jpg");
            bottomLeftReadOutLoudPath = @"..\..\resources\4. Smells\1. Are there some smells that you don't like_\4.1.5Perfumes.wav";

            bottomRightPB.Image = new Bitmap(@"..\..\resources\4. Smells\1. Are there some smells that you don't like_\6 Body smells (cropped).jpg");
            bottomrightReadOutLoudPath = @"..\..\resources\4. Smells\1. Are there some smells that you don't like_\4.1.6BodySmells.wav";

            updateLabelText("Cooking smells", "Food smells", "Cleaning products",
                "Toilet smells", "Perfumes", "Body smells");
        }

        private void smellInterviewPage1p2() {
            panel2lblQuestion.Text = "Are there some smells that you don't like?";
            lblQuestion1.Text = "Other smells that you don’t like?";
            lblQuestion2.Text = "Examples in your daily life?";
        }

        private void smellInterviewPage2() {
            panel2lblQuestion.Text = "Are there some smells that you don't like?";
            lblQuestion1.Text = "Do you do anything to avoid these smells (e.g., avoid public toilets or cleaning products aisles at the supermarket)?";
            lblQuestion2.Text = "";
            tbAnswer2.Visible = false;
        }

        private void smellInterviewPage3() {
            lblQuestion.Text = "Are there some things that you like to smell?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\4. Smells\2. Are there some things that you like to smell_\1 Smelling foods (cropped).jpg");
            topLeftReadOutLoudPath = @"..\..\resources\4. Smells\2. Are there some things that you like to smell_\4.2.1SmellingFoods.wav";

            topMidPB.Image = new Bitmap(@"..\..\resources\4. Smells\2. Are there some things that you like to smell_\2 Smelling plants.jpg");
            topMiddleReadOutLoudPath = @"..\..\resources\4. Smells\2. Are there some things that you like to smell_\4.2.2SmellingPlants.wav";

            topRightPB.Image = new Bitmap(@"..\..\resources\4. Smells\2. Are there some things that you like to smell_\3 Smelling perfume.jpg");
            topRightReadOutLoudPath = @"..\..\resources\4. Smells\2. Are there some things that you like to smell_\4.2.3SmellingPerfumes.wav";

            bottomLeftPB.Image = new Bitmap(@"..\..\resources\4. Smells\2. Are there some things that you like to smell_\4 Smelling soap.jpg");
            bottomLeftReadOutLoudPath = @"..\..\resources\4. Smells\2. Are there some things that you like to smell_\4.2.4SmellSoup.wav";

            bottomMidPB.Image = new Bitmap(@"..\..\resources\4. Smells\2. Are there some things that you like to smell_\5 Smelling people.jpg");
            bottomMiddleReadOutLoudPath = @"..\..\resources\4. Smells\2. Are there some things that you like to smell_\4.2.6SmellingPeople.wav";

            //bottomRightPB.Image = new Bitmap(@"..\..\resources\4. Smells\1. Are there some that you don't like_\Body smells.jpg");
            updateLabelText("Smelling foods", "Smelling plants", "Smelling perfume",
                "Smelling soap", "Smelling people", "");
        }

        private void smellInterviewPage3p2() {
            panel2lblQuestion.Text = "Are there some things that you like to smell?";
            lblQuestion1.Text = "Other things you like to smell?";
            lblQuestion2.Text = "Examples in your daily life?";
        }

        private void smellInterviewPage4() {
            panel2lblQuestion.Text = "Are there some things that you like to smell?";
            lblQuestion1.Text = "Are there things that you like to smell often or for long periods?";
            lblQuestion2.Text = "";
            tbAnswer2.Visible = false;
        }

        /// <summary>
        /// taste
        /// </summary>
        private void tasteInterviewPage1() {
            lblQuestion.Text = "Are there some food groups that you don't like eating?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\1 Vegetables.png");
            topLeftReadOutLoudPath = @"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\5.1.1Vegetables.wav";

            topMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\2 Fruit.png");
            topMiddleReadOutLoudPath = @"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\5.1.2Fruits.wav";

            topRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\3 Meat.jpg");
            topRightReadOutLoudPath = @"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\5.1.3Meat.wav";

            bottomLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\4 Fish.jpg");
            bottomLeftReadOutLoudPath = @"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\5.1.4Fish.wav";

            bottomMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\5 Eggs.jpg");
            bottomMiddleReadOutLoudPath = @"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\5.1.5Eggs.wav";

            bottomRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\6 Dairy.png");
            bottomrightReadOutLoudPath = @"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\5.1.6Dairy.wav";
            updateLabelText("Vegetables", "Fruit", "Meat", "Fish", "Eggs", "Dairy");
        }

        private void tasteInterviewPage1p2() {
            lblQuestion.Text = "Are there some food groups that you don't like eating?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\7 Bread.jpg");
            topLeftReadOutLoudPath = @"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\5.1.7Bread.wav";

            topMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\8 Pasta.jpg");
            topMiddleReadOutLoudPath = @"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\5.1.8Pasta.wav";

            //topRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some that you don't like_\Geometric patterns.jpg");
            //bottomLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Fish.jpg");
            //bottomMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some that you don't like_\Spinning objects.jpg");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Dairy.jpg");
            updateLabelText("Bread", "Pasta", "", "", "", "");
        }

        private void tasteInterviewPage1p3() {
            panel2lblQuestion.Text = "Are there some food groups that you don't like eating?";
            lblQuestion1.Text = "Other types of food that you don’t like?";
            lblQuestion2.Text = "Examples in your daily life?";
        }

        private void tasteInterviewPage2() {
            lblQuestion.Text = "Are there some ways that food tastes or feels in your mouth that you don't like?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\2. Are there some ways that food tastes or feels in your mouth that you don't like_\1 Lumpy.jpg");
            topLeftReadOutLoudPath = @"..\..\resources\5. Taste\2. Are there some ways that food tastes or feels in your mouth that you don't like_\5.2.1Lumpy.wav";

            topMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\2. Are there some ways that food tastes or feels in your mouth that you don't like_\2 Chewy.jpg");
            topMiddleReadOutLoudPath = @"..\..\resources\5. Taste\2. Are there some ways that food tastes or feels in your mouth that you don't like_\5.2.2Chewy.wav";

            topRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\2. Are there some ways that food tastes or feels in your mouth that you don't like_\3 Runny slippery (cropped).jpg");
            topRightReadOutLoudPath = @"..\..\resources\5. Taste\2. Are there some ways that food tastes or feels in your mouth that you don't like_\5.2.3RunnySlippery.wav";

            bottomLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\2. Are there some ways that food tastes or feels in your mouth that you don't like_\4 Mixed.JPG");
            bottomLeftReadOutLoudPath = @"..\..\resources\5. Taste\2. Are there some ways that food tastes or feels in your mouth that you don't like_\5.2.4Mixed.wav";

            bottomMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\2. Are there some ways that food tastes or feels in your mouth that you don't like_\5 Sweet.jpg");
            bottomMiddleReadOutLoudPath = @"..\..\resources\5. Taste\2. Are there some ways that food tastes or feels in your mouth that you don't like_\5.2.5Sweet.wav";

            bottomRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\2. Are there some ways that food tastes or feels in your mouth that you don't like_\6 Sour.png");
            bottomrightReadOutLoudPath = @"..\..\resources\5. Taste\2. Are there some ways that food tastes or feels in your mouth that you don't like_\5.2.6Sour.wav";

            updateLabelText("Lumpy", "Chewy", "Runny/Slippery", "Mixed", "Sweet", "Sour");
        }
        private void tasteInterviewPage2p2() {
            lblQuestion.Text = "Are there some ways that food tastes or feels in your mouth that you don't like?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\2. Are there some ways that food tastes or feels in your mouth that you don't like_\7 Salty (cropped).jpg");
            topLeftReadOutLoudPath = @"..\..\resources\5. Taste\2. Are there some ways that food tastes or feels in your mouth that you don't like_\5.2.7Salty.wav";

            topMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\2. Are there some ways that food tastes or feels in your mouth that you don't like_\8 Spicy.jpg");
            topMiddleReadOutLoudPath = @"..\..\resources\5. Taste\2. Are there some ways that food tastes or feels in your mouth that you don't like_\5.2.8Spicy.wav";

            //topRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some that you don't like_\Geometric patterns.jpg");
            //bottomLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Fish.jpg");
            //bottomMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some that you don't like_\Spinning objects.jpg");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Dairy.jpg");
            updateLabelText("Salty", "Spicy", "", "", "", "");
        }

        private void tasteInterviewPage2p3() {
            panel2lblQuestion.Text = "Are there some ways that food tastes or feels in your mouth that you don’t like?";
            lblQuestion1.Text = "Other ways food tastes or feels that you don’t like?";
            lblQuestion2.Text = "Examples in your daily life?";
        }

        private void tasteInterviewPage3() {
            panel2lblQuestion.Text = "Are there some ways that food tastes or feels in your mouth that you don’t like?";
            lblQuestion1.Text = "Do you do anything to avoid eating certain foods (e.g., avoid eating in restaurants or at other people’s homes)?";
            lblQuestion2.Text = "";
            tbAnswer2.Visible = false;
        }

        private void tasteInterviewPage4() {
            lblQuestion.Text = "Are there some things that you really like to eat?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\3. Are there some things you really like to eat_\1 Familiar foods, only a few types of foods (i.e, I don’t like trying new foods)1 (cropped).jpg");
            topLeftReadOutLoudPath = @"..\..\resources\5. Taste\3. Are there some things you really like to eat_\5.3.1FamiliarFoods.wav";

            topMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\3. Are there some things you really like to eat_\2 Unfamiliar foods, lots of different types of foods (i.e., I like trying new foods)1.jpg");
            topMiddleReadOutLoudPath = @"..\..\resources\5. Taste\3. Are there some things you really like to eat_\5.3.2UnfamiliarFoods.wav";


            //topRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some that you don't like_\Geometric patterns.jpg");
            //bottomLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Fish.jpg");
            //bottomMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some that you don't like_\Spinning objects.jpg");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Dairy.jpg");
            updateLabelText("", "Familiar foods, only a few types of foods (e.g., I don’t like trying new foods)", "", "", 
                "Unfamiliar foods, lots of different types of foods (e.g., I like trying new foods)", "");
        }

        private void tasteInterviewPage4p2() {
            panel2lblQuestion.Text = "Are there some things that you really like to eat?";
            lblQuestion1.Text = "Examples in your daily life?";
            lblQuestion2.Text = "Are there certain types of foods that you crave and want to eat repeatedly?";
        }

        private void tasteInterviewPage5() {
            panel2lblQuestion.Text = "Are there some things that you really like to eat?";
            lblQuestion1.Text = "Are there certain types of foods that you crave and want to eat repeatedly?";
            lblQuestion2.Text = "";
            tbAnswer2.Visible = false;
        }

        private void tasteInterviewPage6() {
            lblQuestion.Text = "Are there some things that you put in your mouth a lot?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\4. Are there some things that you put in your mouth a lot_\1 Shirt.jpg");
            topLeftReadOutLoudPath = @"..\..\resources\5. Taste\4. Are there some things that you put in your mouth a lot_\5.4.1Shirt.wav";

            topMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\4. Are there some things that you put in your mouth a lot_\2 Hair.jpg");
            topMiddleReadOutLoudPath = @"..\..\resources\5. Taste\4. Are there some things that you put in your mouth a lot_\5.4.2Hair.wav";

            topRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\4. Are there some things that you put in your mouth a lot_\3 Objects.jpg");

            topRightReadOutLoudPath = @"..\..\resources\5. Taste\4. Are there some things that you put in your mouth a lot_\5.4.3Objects.wav";
            
            //bottomLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Fish.jpg");
            //bottomMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some that you don't like_\Spinning objects.jpg");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Dairy.jpg");
            updateLabelText("Shirt", "Hair", "Objects", "", "", "");
        }

        private void tasteInterviewPage6p2() {
            panel2lblQuestion.Text = "Are there some things that you put in your mouth a lot?";
            lblQuestion1.Text = "Other ways food tastes or feels that you don’t like?";
            lblQuestion2.Text = "Examples in your daily life?";
        }

        private void tasteInterviewPage7() {
            panel2lblQuestion.Text = "Are there some things that you put in your mouth a lot?";
            lblQuestion1.Text = "Are there things that you often put in your mouth? Are any of them dangerous or unhygienic?";
            lblQuestion2.Text = "";
            tbAnswer2.Visible = false;
        }

        /// <summary>
        /// Movement
        /// </summary>
        private void mvmtInterviewPage1() {
            lblQuestion.Text = "Are there some ways of moving that you don't like?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\6. Movement\1. Are there some ways of moving that you don’t like_\1 Being jumped on_tackled.jpg");
            topLeftReadOutLoudPath = @"..\..\resources\6. Movement\1. Are there some ways of moving that you don’t like_\6.1.1BeingJumpedOn.wav";

            topMidPB.Image = new Bitmap(@"..\..\resources\6. Movement\1. Are there some ways of moving that you don’t like_\2 Moving when I can't see where I am going (self-report) (cropped).jpg");
            topMiddleReadOutLoudPath = @"..\..\resources\6. Movement\1. Are there some ways of moving that you don’t like_\6.1.2MovingWhenICantSee.wav";

            topRightPB.Image = new Bitmap(@"..\..\resources\6. Movement\1. Are there some ways of moving that you don’t like_\3 Balancing (self-report) (cropped).jpg");
            topRightReadOutLoudPath = @"..\..\resources\6. Movement\1. Are there some ways of moving that you don’t like_\6.1.3Balancing.wav";


            bottomLeftPB.Image = new Bitmap(@"..\..\resources\6. Movement\1. Are there some ways of moving that you don’t like_\4 Being upside down (cropped).jpg");
            bottomLeftReadOutLoudPath = @"..\..\resources\6. Movement\1. Are there some ways of moving that you don’t like_\6.1.4BeingUpsideDown.wav";

            bottomMidPB.Image = new Bitmap(@"..\..\resources\6. Movement\1. Are there some ways of moving that you don’t like_\5 Climbing up high (cropped).jpg");
            bottomMiddleReadOutLoudPath = @"..\..\resources\6. Movement\1. Are there some ways of moving that you don’t like_\6.1.5ClimbingUpHigh.wav";

            //bottomRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Dairy.jpg");
            updateLabelText("Being jumped on/tackled", "Moving when I can't see where I am going", "Balancing", "Being upside down", "Climbing up high", "");
        }

        private void mvmtInterviewPage1p2() {
            panel2lblQuestion.Text = "Are there some ways of moving that you don’t like?";
            lblQuestion1.Text = "Other ways of moving that you don’t like?";
            lblQuestion2.Text = "Examples in your daily life?";
        }

        private void mvmtInterviewPage2() {
            panel2lblQuestion.Text = "Are there some ways of moving that you don’t like?";
            lblQuestion1.Text = "Are there movement experiences that you find scary or unpleasant?";
            lblQuestion2.Text = "Do you do anything to avoid these movements?";
        }

        private void mvmtInterviewPage3() {
            lblQuestion.Text = "Are there times when it is hard for you to stay still?";
            //topLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\lumpy.jpg");
            topMidPB.Image = new Bitmap(@"..\..\resources\6. Movement\2. Are there times when it is hard for you to stay still_\1 Sitting Still (self report)(cropped).jpg");
            topMiddleReadOutLoudPath = @"..\..\resources\6. Movement\2. Are there times when it is hard for you to stay still_\6.2.1SittingStill.wav";

            //topRightPB.Image = new Bitmap(@"..\..\");
            //bottomLeftPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Fish.jpg");
            bottomMidPB.Image = new Bitmap(@"..\..\resources\6. Movement\2. Are there times when it is hard for you to stay still_\2 Standing Still (self-report).jpg");
            bottomMiddleReadOutLoudPath = @"..\..\resources\6. Movement\2. Are there times when it is hard for you to stay still_\6.2.2StandStill.wav";


            //bottomRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Dairy.jpg");
            updateLabelText("", "Sitting Still", "", "", "Standing still", "");
        }

        private void mvmtInterviewPage3p2() {
            panel2lblQuestion.Text = "Are there times when it is hard for you to stay still?";
            lblQuestion1.Text = "Examples in your daily life?";
            lblQuestion2.Text = "";
            tbAnswer2.Visible = false;
        }

        private void mvmtInterviewPage4() {
            lblQuestion.Text = "Are there some ways of moving that you like?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\6. Movement\3. Are there ways of moving that you like_\1 Moving in Water.jpg");
            topLeftReadOutLoudPath = @"..\..\resources\6. Movement\3. Are there ways of moving that you like_\6.3.1MovingInWater.wav";

            topMidPB.Image = new Bitmap(@"..\..\resources\6. Movement\3. Are there ways of moving that you like_\2 Swinging (cropped).jpg");
            topMiddleReadOutLoudPath = @"..\..\resources\6. Movement\3. Are there ways of moving that you like_\6.3.2Swinging.wav";

            topRightPB.Image = new Bitmap(@"..\..\resources\6. Movement\3. Are there ways of moving that you like_\3 Spinning (guided).jpg");
            topRightReadOutLoudPath = @"..\..\resources\6. Movement\3. Are there ways of moving that you like_\6.3.3Spinning.wav";

            bottomLeftPB.Image = new Bitmap(@"..\..\resources\6. Movement\3. Are there ways of moving that you like_\4 Jumping on the Trampoline (guided and self report) (cropped).jpg");
            bottomLeftReadOutLoudPath = @"..\..\resources\6. Movement\3. Are there ways of moving that you like_\6.3.4JumpingOnTrampoline.wav";

            bottomMidPB.Image = new Bitmap(@"..\..\resources\6. Movement\3. Are there ways of moving that you like_\5 Running (self-report) (cropped).jpg");
            bottomrightReadOutLoudPath = @"..\..\resources\6. Movement\3. Are there ways of moving that you like_\6.3.5Running.wav";

            //bottomRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Dairy.jpg");
            updateLabelText("Moving in water", "Swinging", "Spinning", "Jumping on the trampoline", "Running", "");
        }

        private void mvmtInterviewPage4p2() {
            panel2lblQuestion.Text = "Are there some ways of moving that you like?";
            lblQuestion1.Text = "Other ways of moving that you like?";
            lblQuestion2.Text = "Examples in your daily life?";
        }

        private void mvmtInterviewPage5() {
            lblQuestion.Text = "Are there some ways that you move over and over again?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\6. Movement\4. Are there some ways that you move over and over again_\1 Rocking.png");
            topLeftReadOutLoudPath = @"..\..\resources\6. Movement\4. Are there some ways that you move over and over again_\6.4.1Rocking.wav";

            topMidPB.Image = new Bitmap(@"..\..\resources\6. Movement\4. Are there some ways that you move over and over again_\2 Moving hands.jpg");
            topMiddleReadOutLoudPath = @"..\..\resources\6. Movement\4. Are there some ways that you move over and over again_\6.4.2MovingHands.wav";

            topRightPB.Image = new Bitmap(@"..\..\resources\6. Movement\4. Are there some ways that you move over and over again_\3 Clapping.jpg");
            topRightReadOutLoudPath = @"..\..\resources\6. Movement\4. Are there some ways that you move over and over again_\6.4.3Clapping.wav";

            bottomLeftPB.Image = new Bitmap(@"..\..\resources\6. Movement\4. Are there some ways that you move over and over again_\4 Pacing.PNG");
            bottomLeftReadOutLoudPath = @"..\..\resources\6. Movement\4. Are there some ways that you move over and over again_\6.4.4Pacing.wav";

            //bottomMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some that you don't like_\Spinning objects.jpg");
            //bottomRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Dairy.jpg");
            updateLabelText("Rocking", "Moving hands", "Clapping", "Pacing", "", "");
        }

        private void mvmtInterviewPage5p2() {
            panel2lblQuestion.Text = "Are there some ways that you move over and over again?";
            lblQuestion1.Text = "Other ways of moving that you like?";
            lblQuestion2.Text = "Examples in your daily life?";
        }

        private void mvmtInterviewPage6() {
            panel2lblQuestion.Text = "Are there some ways that you move over and over again?";
            lblQuestion1.Text = "Are there movements that you make repeatedly when you are anxious?";
            lblQuestion2.Text = "Are there movements that you make repeatedly when you are excited?";
        }

        /// <summary>
        /// Environment
        /// </summary>
        private void environmentPage1() {
            lblQuestion.Text = "Are there some places with lots of things happening at once that you don't like?";
            topLeftPB.Image = new Bitmap(@"..\..\resources\7. Environment\1. Are there some places with lots of things happening at once that you don’t like_ (e.g. places with lots of noise, bright lights and people)\1 Supermarket.png");
            topLeftReadOutLoudPath = @"..\..\resources\7. Environment\1. Are there some places with lots of things happening at once that you don’t like_ (e.g. places with lots of noise, bright lights and people)\7.1.1Supermarket.wav";

            //topMidPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Pasta.jpg");
            topRightPB.Image = new Bitmap(@"..\..\resources\7. Environment\1. Are there some places with lots of things happening at once that you don’t like_ (e.g. places with lots of noise, bright lights and people)\3 Food Hall.jpg");
            topRightReadOutLoudPath = @"..\..\resources\7. Environment\1. Are there some places with lots of things happening at once that you don’t like_ (e.g. places with lots of noise, bright lights and people)\7.1.2Party.wav";

            bottomLeftPB.Image = new Bitmap(@"..\..\resources\7. Environment\1. Are there some places with lots of things happening at once that you don’t like_ (e.g. places with lots of noise, bright lights and people)\4 Show (cropped).jpg");
            bottomLeftReadOutLoudPath = @"..\..\resources\7. Environment\1. Are there some places with lots of things happening at once that you don’t like_ (e.g. places with lots of noise, bright lights and people)\7.1.3FoodHall.wav";

            bottomMidPB.Image = new Bitmap(@"..\..\resources\7. Environment\1. Are there some places with lots of things happening at once that you don’t like_ (e.g. places with lots of noise, bright lights and people)\5 Shopping mall.png");
            bottomMiddleReadOutLoudPath = @"..\..\resources\7. Environment\1. Are there some places with lots of things happening at once that you don’t like_ (e.g. places with lots of noise, bright lights and people)\7.1.4Show.wav";

            //bottomRightPB.Image = new Bitmap(@"..\..\resources\5. Taste\1. Are there some food groups that you don't like eating_\Dairy.jpg");
            updateLabelText("Supermarket", "Party", "Food hall", "Show", "Shopping mall", "");
        }

        private void environmentPage1p2() {
            panel2lblQuestion.Text = "Are there some places with lots of things happening at once that you don’t like? (e.g., places with lots of noise, bright lights and people)";
            lblQuestion1.Text = "Other places with lots of things happening at once that you don’t like?";
            lblQuestion2.Text = "Examples in your daily life?";
        }

        private void environmentPage2() {
            panel2lblQuestion.Text = "Are there some places with lots of things happening at once that you don’t like? (e.g., places with lots of noise, bright lights and people)";
            lblQuestion1.Text = "How do you react to places with lots of things happening at once?";
            lblQuestion2.Text = "Do you do anything to avoid places with lots of things happening at once?";
        }

        /// <summary>
        /// Other
        /// </summary>
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

        private void otherInterviewPage1p2() {
            panel2lblQuestion.Text = "Are there any other sensations that you feel strongly about?";
            lblQuestion1.Text = "Other sounds, smells, sights, tastes, feelings, or movements?";
            lblQuestion2.Text = "Examples in your daily life?";
        }

        private void otherInterviewPage2() {
            panel2lblQuestion.Text = "Are there any other sensations that you feel strongly about?";
            lblQuestion1.Text = "How do you react to these other things??";
            lblQuestion2.Text = "Do you do anything to avoid these other things?";
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
            
            determineDrawing(e, 0, 0, topLeftPB2.Width, topLeftPB2.Height, 0);
        }
        private void topMidPB_Paint(object sender, PaintEventArgs e) {
            determineDrawing(e, 0, 0, topMidPB2.Width, topMidPB2.Height, 1);
        }
        private void topRightPB_Paint(object sender, PaintEventArgs e) {
            determineDrawing(e, 0, 0, topRightPB2.Width, topRightPB2.Height, 2);
        }
        private void bottomLeftPB_Paint(object sender, PaintEventArgs e) {
            determineDrawing(e, 0, 0, bottomLeftPB2.Width, bottomLeftPB2.Height, 3);
        }
        private void bottomMidPB_Paint(object sender, PaintEventArgs e) {
            determineDrawing(e, 0, 0, bottomMidPB2.Width, bottomMidPB2.Height, 4);
        }
        private void bottomRightPB_Paint(object sender, PaintEventArgs e) {
            determineDrawing(e, 0, 0, bottomRightPB2.Width, bottomRightPB2.Height, 5);
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
            }catch(Exception ex) {
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
                    +TRImageName + "=@tr, "
                    +BLImageName + "=@bl, "
                    +BMImageName + "=@bm, "
                    +BRImageName + "=@br, ID = @userID WHERE interviewNumber = (SELECT MAX(interviewNumber) FROM dbo.other);";
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
        private void writeToDB5( string TLImageName, string TMImageName, string TRImageName, string BLImageName, string BMImageName, string dbTableName) {

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

        private void saveWrittenAnswerToDB(string tableName, string columnName, string comment) {
            SqlCommand cmdDatabase;
            const string constring = @"Data Source =(LocalDB)\MSSQLLocalDB;" +
                                    @"AttachDbFilename = |DataDirectory|\CapstoneDB\CapstoneDB.mdf; Integrated Security = True";
            SqlConnection conDatabase = new SqlConnection(constring);
            string query;
            //Determine if a little or a lot
            try {
                query = string.Format("UPDATE dbo.{0} SET " + columnName + " = @additionalCommentText, ID = @userID WHERE interviewNumber = (SELECT MAX(interviewNumber) FROM dbo.{0}) ;", tableName);
                conDatabase.Open();
                cmdDatabase = new SqlCommand(query, conDatabase);
                //cmdDatabase = new SqlCommand("INSERT INTO dbo." + tableName + "(" + columnName + ") VALUES(@text);" , conDatabase);
                cmdDatabase.Parameters.AddWithValue("@additionalCommentText", comment);
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
            topLeftPB2.Invalidate();
            page1Selections[0] = "A Little";
            //this is just to show the array being updated -- can remove after testing
            //Update label
            //summary.LabelText = "Top Left A Little";
            //summary.Show();
        }
        private void topLeftPBALotBtn_Click(object sender, EventArgs e) {
            //This will refresh the picture box
            topLeftPB2.Invalidate();
            page1Selections[0] = "A Lot";
            //summary.LabelText = "Top Left A Lot";
        }
        private void topMidALittleBtn_Click(object sender, EventArgs e) {
            //This will refresh the picture box
            topMidPB2.Invalidate();
            page1Selections[1] = "A Little";
        }
        private void topMidALotBtn_Click(object sender, EventArgs e) {
            //This will refresh the picture box
            topMidPB2.Invalidate();
            page1Selections[1] = "A Lot";
        }
        private void topRightALittleBtn_Click(object sender, EventArgs e) {
            //This will refresh the picture box
            topRightPB2.Invalidate();
            page1Selections[2] = "A Little";
        }
        private void topRightPBALotBtn_Click(object sender, EventArgs e) {
            //This will refresh the picturebox
            topRightPB2.Invalidate();
            page1Selections[2] = "A Lot";
        }
        private void bottomLeftALittleBtn_Click(object sender, EventArgs e) {
            //This will refresh the picture box
            bottomLeftPB2.Invalidate();
            page1Selections[3] = "A Little";
        }
        private void bottomLeftALotBtn_Click(object sender, EventArgs e) {
            //This will refresh the picture box
            bottomLeftPB2.Invalidate();
            page1Selections[3] = "A Lot";
        }
        private void bottomMidALittleBtn_Click(object sender, EventArgs e) {
            //This will refresh the picture box
            bottomMidPB2.Invalidate();
            page1Selections[4] = "A Little";
        }
        private void bottomMidALotBtn_Click(object sender, EventArgs e) {
            //This will refresh the picture box
            bottomMidPB2.Invalidate();
            page1Selections[4] = "A Lot";
        }
        private void bottomRightALittleBtn_Click(object sender, EventArgs e) {
            //This will refresh the picture box
            bottomRightPB2.Invalidate();
            page1Selections[5] = "A Little";
        }
        private void bottomRightALotBtn_Click(object sender, EventArgs e) {
            //This will refresh the picture box
            bottomRightPB2.Invalidate();
            page1Selections[5] = "A Lot";
        }

        private void SightColours() {
            //picturePanel
            picBackground.BackColor = Color.SandyBrown;
            lblQuestion.BackColor = Color.SandyBrown;            
            picturePanel.BackColor = Color.Bisque;
            //questionPanel
            pictureBox3.BackColor = Color.SandyBrown;
            panel2lblQuestion.BackColor = Color.SandyBrown;
            label9.BackColor = Color.SandyBrown;
            label7.BackColor = Color.SandyBrown;
            questionPanel.BackColor = Color.Bisque;
            topLeftPB2.BackColor = Color.Bisque;
            topMidPB2.BackColor = Color.Bisque;
            topRightPB2.BackColor = Color.Bisque;
            bottomLeftPB2.BackColor = Color.Bisque;
            bottomMidPB2.BackColor = Color.Bisque;
            bottomRightPB2.BackColor = Color.Bisque;
        }

        private void TouchColours() {
            //picturePanel
            picBackground.BackColor = Color.FromArgb(255, 255, 128);
            lblQuestion.BackColor = Color.FromArgb(255, 255, 128);
            picturePanel.BackColor = Color.LightYellow;
            //questionPanel
            pictureBox3.BackColor = Color.FromArgb(255, 255, 128);
            panel2lblQuestion.BackColor = Color.FromArgb(255, 255, 128);
            label9.BackColor = Color.FromArgb(255, 255, 128);
            label7.BackColor = Color.FromArgb(255, 255, 128);
            questionPanel.BackColor = Color.LightYellow;
            topLeftPB2.BackColor = Color.LightYellow;
            topMidPB2.BackColor = Color.LightYellow;
            topRightPB2.BackColor = Color.LightYellow;
            bottomLeftPB2.BackColor = Color.LightYellow;
            bottomMidPB2.BackColor = Color.LightYellow;
            bottomRightPB2.BackColor = Color.LightYellow;
        }

        private void SmellColours() {
            //picturePanel
            picBackground.BackColor = Color.FromArgb(143, 188, 139);
            lblQuestion.BackColor = Color.FromArgb(143, 188, 139);
            picturePanel.BackColor = Color.Honeydew;
            //questionPanel
            pictureBox3.BackColor = Color.FromArgb(143, 188, 139);
            panel2lblQuestion.BackColor = Color.FromArgb(143, 188, 139);
            label9.BackColor = Color.FromArgb(143, 188, 139);
            label7.BackColor = Color.FromArgb(143, 188, 139);
            questionPanel.BackColor = Color.Honeydew;
            topLeftPB2.BackColor = Color.Honeydew;
            topMidPB2.BackColor = Color.Honeydew;
            topRightPB2.BackColor = Color.Honeydew;
            bottomLeftPB2.BackColor = Color.Honeydew;
            bottomMidPB2.BackColor = Color.Honeydew;
            bottomRightPB2.BackColor = Color.Honeydew;
        }

        private void TasteColours() {
            System.Drawing.Color tasteHeader = System.Drawing.ColorTranslator.FromHtml("#C2B4E2");
            System.Drawing.Color tasteBg = System.Drawing.ColorTranslator.FromHtml("#E6E6FA");
            //picturePanel
            picBackground.BackColor = tasteHeader;
            lblQuestion.BackColor = tasteHeader;
            picturePanel.BackColor = tasteBg;
            //questionPanel
            pictureBox3.BackColor = tasteHeader;
            panel2lblQuestion.BackColor = tasteHeader;
            label9.BackColor = tasteHeader;
            label7.BackColor = tasteHeader;
            questionPanel.BackColor = tasteBg;
            topLeftPB2.BackColor = tasteBg;
            topMidPB2.BackColor = tasteBg;
            topRightPB2.BackColor = tasteBg;
            bottomLeftPB2.BackColor = tasteBg;
            bottomMidPB2.BackColor = tasteBg;
            bottomRightPB2.BackColor = tasteBg;
        }

        private void MovementColours() {
            //picturePanel
            picBackground.BackColor = Color.PaleVioletRed;
            lblQuestion.BackColor = Color.PaleVioletRed;
            picturePanel.BackColor = Color.Pink;
            //questionPanel
            pictureBox3.BackColor = Color.PaleVioletRed;
            panel2lblQuestion.BackColor = Color.PaleVioletRed;
            label9.BackColor = Color.PaleVioletRed;
            label7.BackColor = Color.PaleVioletRed;
            questionPanel.BackColor = Color.Pink;
            topLeftPB2.BackColor = Color.Pink;
            topMidPB2.BackColor = Color.Pink;
            topRightPB2.BackColor = Color.Pink;
            bottomLeftPB2.BackColor = Color.Pink;
            bottomMidPB2.BackColor = Color.Pink;
            bottomRightPB2.BackColor = Color.Pink;
        }
        
        
        private void EnvironmentColours() {
            //picturePanel
            picBackground.BackColor = Color.LightBlue;
            lblQuestion.BackColor = Color.LightBlue;
            picturePanel.BackColor = Color.AliceBlue;
            //questionPanel
            pictureBox3.BackColor = Color.LightBlue;
            panel2lblQuestion.BackColor = Color.LightBlue;
            label9.BackColor = Color.LightBlue;
            label7.BackColor = Color.LightBlue;
            questionPanel.BackColor = Color.AliceBlue;
            topLeftPB2.BackColor = Color.AliceBlue;
            topMidPB2.BackColor = Color.AliceBlue;
            topRightPB2.BackColor = Color.AliceBlue;
            bottomLeftPB2.BackColor = Color.AliceBlue;
            bottomMidPB2.BackColor = Color.AliceBlue;
            bottomRightPB2.BackColor = Color.AliceBlue;
        }

        private void OtherColours() {
            //picturePanel
            picBackground.BackColor = Color.Tan;
            lblQuestion.BackColor = Color.Tan;
            picturePanel.BackColor = Color.AntiqueWhite;
            //questionPanel
            pictureBox3.BackColor = Color.Tan;
            panel2lblQuestion.BackColor = Color.Tan;
            label9.BackColor = Color.Tan;
            label7.BackColor = Color.Tan;
            questionPanel.BackColor = Color.AntiqueWhite;
            topLeftPB2.BackColor = Color.AntiqueWhite;
            topMidPB2.BackColor = Color.AntiqueWhite;
            topRightPB2.BackColor = Color.AntiqueWhite;
            bottomLeftPB2.BackColor = Color.AntiqueWhite;
            bottomMidPB2.BackColor = Color.AntiqueWhite;
            bottomRightPB2.BackColor = Color.AntiqueWhite;
        }

        string textboxAnswer1;
        string textboxAnswer2;

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
                if (m_InstanceRef != null) {
                    InstanceRef.Show();
                }
                else {
                    this.Hide();
                    IndependentInterview soundPage1 = new IndependentInterview();
                    soundPage1.InstanceRef = this;
                    soundPage1.Location = new Point(0, 0);
                    soundPage1.Show();
                }
            }
            else if (Globals.interview_page == 3) {
                updateDB("sirens", "suddenLoudNoises", "dislikeSounds");
                IndependentInterview soundPage1p3 = new IndependentInterview();
                soundPage1p3.InstanceRef2 = this;
                soundPage1p3.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 4) {
                string textboxAnswer1 = this.tbAnswer1.Text;
                string textboxAnswer2 = this.tbAnswer2.Text;
                saveWrittenAnswerToDB("dislikeSounds", "comment1", textboxAnswer1);
                saveWrittenAnswerToDB("dislikeSounds", "comment2", textboxAnswer2);
                IndependentInterview soundPage2 = new IndependentInterview();
                soundPage2.InstanceRef3 = this;
                soundPage2.Location = new Point(0, 0);
                soundPage2.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 5) {
                saveWrittenAnswerToDB("dislikeSounds", "comment3", tbAnswer1.Text.ToString());
                IndependentInterview soundPage3 = new IndependentInterview();
                soundPage3.InstanceRef4 = this;
                soundPage3.Location = new Point(0, 0);
                soundPage3.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 6) {
                if (!Globals.previousClicked) {
                    previousUpdate3("concentrating", "hardToListenInClassroom", "hardToListenInGroup", "hardToListen");
                } else {
                    writeToDBTop3( "concentrating", "hardToListenInClassroom", "hardToListenInGroup", "hardToListen");
                    Globals.previousClicked = false;
                }
                IndependentInterview soundPage3p2 = new IndependentInterview();
                soundPage3p2.InstanceRef5 = this;
                soundPage3p2.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 7) {
                saveWrittenAnswerToDB("hardToListen", "comment1", tbAnswer1.Text.ToString());
                saveWrittenAnswerToDB("hardToListen", "comment2", tbAnswer2.Text.ToString());
                IndependentInterview soundPage4 = new IndependentInterview();
                soundPage4.InstanceRef6 = this;
                soundPage4.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 8) {
                if (!Globals.previousClicked) {
                    previousUpdate3("radioOn", "clockTicking", "peopleTalking", "hardToConcentrate");
                } else {
                    writeToDBTop3("radioOn", "clockTicking", "peopleTalking", "hardToConcentrate");
                    Globals.previousClicked = false;
                }
                IndependentInterview soundPage4p2 = new IndependentInterview();
                soundPage4p2.InstanceRef7 = this;
                soundPage4p2.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 9) {
                saveWrittenAnswerToDB("hardToConcentrate", "comment1", tbAnswer1.Text.ToString());
                saveWrittenAnswerToDB("hardToConcentrate", "comment2", tbAnswer2.Text.ToString());
                IndependentInterview soundPage5and6 = new IndependentInterview();
                soundPage5and6.InstanceRef8 = this;
                soundPage5and6.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 10) {
                saveWrittenAnswerToDB("hardToConcentrate", "comment3", tbAnswer1.Text.ToString());
                saveWrittenAnswerToDB("hardToConcentrate", "comment4", tbAnswer2.Text.ToString());
                IndependentInterview soundPage7 = new IndependentInterview();
                soundPage7.InstanceRef9 = this;
                soundPage7.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 11) {
                if (!Globals.previousClicked) {
                    previousUpdate5("computerSounds", "liveMusic", "fans", "musicThroughMyPhone", "rhythms", "likeSounds");
                } else {
                    writeToDB5("computerSounds", "liveMusic", "fans", "musicThroughMyPhone", "rhythms", "likeSounds");
                    Globals.previousClicked = false;
                }
                IndependentInterview soundPage7p2 = new IndependentInterview();
                soundPage7p2.InstanceRef10 = this;
                soundPage7p2.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 12) {
                saveWrittenAnswerToDB("likeSounds", "comment1", tbAnswer1.Text.ToString());
                saveWrittenAnswerToDB("likeSounds", "comment2", tbAnswer2.Text.ToString());
                IndependentInterview soundPage8 = new IndependentInterview();
                soundPage8.InstanceRef11 = this;
                soundPage8.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 13) {
                saveWrittenAnswerToDB("likeSounds", "comment3", tbAnswer1.Text.ToString());
                IndependentInterview soundPage9 = new IndependentInterview();
                soundPage9.InstanceRef12 = this;
                soundPage9.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 14) {
                if (!Globals.previousClicked) {
                    previousUpdate4("hummingOrWhistling", "tappingFeet", "tappingFingers", "clickingPen", "makeALotSounds");
                } else {
                    writeToDB4("hummingOrWhistling", "tappingFeet", "tappingFingers", "clickingPen", "makeALotSounds");
                    Globals.previousClicked = false;
                }
                IndependentInterview soundPage9p2 = new IndependentInterview();
                soundPage9p2.InstanceRef13 = this;
                soundPage9p2.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 15) {
                saveWrittenAnswerToDB("makeALotSounds", "comment1", tbAnswer1.Text.ToString());
                saveWrittenAnswerToDB("makeALotSounds", "comment2", tbAnswer2.Text.ToString());
                IndependentInterview soundPage10 = new IndependentInterview();
                soundPage10.InstanceRef14 = this;
                soundPage10.Show();
                this.Hide();
            }
            //-------------
            //SIGHT SECTION
            //-------------
            else if (Globals.interview_page == 16) {
                saveWrittenAnswerToDB("makeALotSounds", "comment3", tbAnswer1.Text.ToString());

                IndependentInterview sightPage1 = new IndependentInterview();
                sightPage1.InstanceRef15 = this;
                sightPage1.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 17) {
                if (!Globals.previousClicked) {
                    previousUpdate5("sunlight", "fluorescentLight", "lightAndShadow", "busyPatterns", "classroomLight", "dontLikeToLookAt");
                } else {
                writeToDB5("sunlight", "fluorescentLight", "lightAndShadow", "busyPatterns", "classroomLight", "dontLikeToLookAt");
                    Globals.previousClicked = false;
                }
                IndependentInterview sightPage1p2 = new IndependentInterview();
                sightPage1p2.InstanceRef16 = this;
                sightPage1p2.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 18) {
                saveWrittenAnswerToDB("dontLikeToLookAt", "comment1", tbAnswer1.Text.ToString());
                saveWrittenAnswerToDB("dontLikeToLookAt", "comment2", tbAnswer2.Text.ToString());
                IndependentInterview sightPage2 = new IndependentInterview();
                sightPage2.InstanceRef17 = this;
                sightPage2.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 19) {
                saveWrittenAnswerToDB("dontLikeToLookAt", "comment3", tbAnswer1.Text.ToString());
                IndependentInterview sightPage3 = new IndependentInterview();
                sightPage3.InstanceRef18 = this;
                sightPage3.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 20) {
                if (!Globals.previousClicked) {
                    previousUpdate3("lotsOfThingsInAMessyDrawer", "peopleRunningAroundMe", "lotsOfThingsHangingUpInTheClassroom", "sightHardToConcentrate");
                } else {
                    writeToDBTop3("lotsOfThingsInAMessyDrawer", "peopleRunningAroundMe", "lotsOfThingsHangingUpInTheClassroom", "sightHardToConcentrate");
                    Globals.previousClicked = false;
                }

                IndependentInterview sightPage3p2 = new IndependentInterview();
                sightPage3p2.InstanceRef19 = this;
                sightPage3p2.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 21) {
                saveWrittenAnswerToDB("sightHardToConcentrate", "comment1", tbAnswer1.Text.ToString());
                saveWrittenAnswerToDB("sightHardToConcentrate", "comment2", tbAnswer2.Text.ToString());
                IndependentInterview sightPage4 = new IndependentInterview();
                sightPage4.InstanceRef20 = this;
                sightPage4.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 22) {
                if (!Globals.previousClicked) {
                    previousUpdate5("movingLights", "thingsThatSparkle", "geometricPatterns", "spinningFans", "spinningObjects", "likeToLookAt");
                } else {
                    writeToDB5( "movingLights", "thingsThatSparkle", "geometricPatterns", "spinningFans", "spinningObjects", "likeToLookAt");
                    Globals.previousClicked = false;
                }
                IndependentInterview sightPage4p2 = new IndependentInterview();
                sightPage4p2.InstanceRef21 = this;
                sightPage4p2.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 23) {
                saveWrittenAnswerToDB("likeToLookAt", "comment1", tbAnswer1.Text.ToString());
                saveWrittenAnswerToDB("likeToLookAt", "comment2", tbAnswer2.Text.ToString());
                IndependentInterview sightPage5 = new IndependentInterview();
                sightPage5.InstanceRef22 = this;
                sightPage5.Show();
                this.Hide();
            }
            //-------------
            //TOUCH SECTION
            //-------------
            else if (Globals.interview_page == 24) {
                saveWrittenAnswerToDB("likeToLookAt", "comment3", tbAnswer1.Text.ToString());
                IndependentInterview touchPage1 = new IndependentInterview();
                touchPage1.InstanceRef23 = this;
                touchPage1.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 25) {
                if (!Globals.previousClicked) {
                    updateOnPreviousClicked("sandy", "sticky", "grassy", "woolClothes", "tightClothes", "stiffClothes", "dontLikeFeelingOf");
                } else {
                    writeToDB("sandy", "sticky", "grassy", "woolClothes", "tightClothes", "stiffClothes", "dontLikeFeelingOf");
                    Globals.previousClicked = false;
                }
                IndependentInterview touchPage1p2 = new IndependentInterview();
                touchPage1p2.InstanceRef24 = this;
                touchPage1p2.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 26) {
                updateDBdontLikeFeelingOf( "shoes", "splashingWater", "dontLikeFeelingOf");
                IndependentInterview touchPage1p3 = new IndependentInterview();
                touchPage1p3.InstanceRef25 = this;
                touchPage1p3.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 27) {
                saveWrittenAnswerToDB("dontLikeFeelingOf", "comment1", tbAnswer1.Text.ToString());
                saveWrittenAnswerToDB("dontLikeFeelingOf", "comment2", tbAnswer2.Text.ToString());
                IndependentInterview touchPage2 = new IndependentInterview();
                touchPage2.InstanceRef26 = this;
                touchPage2.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 28) {

                saveWrittenAnswerToDB("dontLikeFeelingOf", "comment3", tbAnswer1.Text.ToString());
                saveWrittenAnswerToDB("dontLikeFeelingOf", "comment4", tbAnswer2.Text.ToString());
                IndependentInterview touchPage3 = new IndependentInterview();
                touchPage3.InstanceRef27 = this;
                touchPage3.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 29) {
                if (!Globals.previousClicked) {
                    updateOnPreviousClicked("beingHuggedOrKissed", "beingCrowded", "beingTappedOnTheShoulder", "havingSunscreenPutOn", "beingBumped", "havingAHaircut", "peopleTouchDontLike");
                } else {
                    writeToDB("beingHuggedOrKissed", "beingCrowded", "beingTappedOnTheShoulder", "havingSunscreenPutOn", "beingBumped", "havingAHaircut", "peopleTouchDontLike");
                    Globals.previousClicked = false;
                }
                IndependentInterview touchPage3p2 = new IndependentInterview();
                touchPage3p2.InstanceRef28 = this;
                touchPage3p2.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 30) {
                updateDBpeopleTouchDontLike("doctorTouchingMe", "dentistTouchingMe", "peopleTouchDontLike");
                IndependentInterview touchPage3p3 = new IndependentInterview();
                touchPage3p3.InstanceRef29 = this;
                touchPage3p3.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 31) {
                saveWrittenAnswerToDB("peopleTouchDontLike", "comment1", tbAnswer1.Text.ToString());
                saveWrittenAnswerToDB("peopleTouchDontLike", "comment2", tbAnswer2.Text.ToString());
                IndependentInterview touchPage4 = new IndependentInterview();
                touchPage4.InstanceRef30 = this;
                touchPage4.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 32) {
                saveWrittenAnswerToDB("peopleTouchDontLike", "comment3", tbAnswer1.Text.ToString());
                saveWrittenAnswerToDB("peopleTouchDontLike", "comment4", tbAnswer2.Text.ToString());
                IndependentInterview touchPage5 = new IndependentInterview();
                touchPage5.InstanceRef31 = this;
                touchPage5.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 33) {
                if (!Globals.previousClicked) {
                    updateOnPreviousClicked("soft", "rubbery", "furry", "huggingPeople", "touchingPeople", "beingSquashedWithAPillow", "likeTheFeelingOf");
                } else {
                    writeToDB( "soft", "rubbery", "furry", "huggingPeople", "touchingPeople", "beingSquashedWithAPillow", "likeTheFeelingOf");
                    Globals.previousClicked = false;
                }
                IndependentInterview touchPage5p2 = new IndependentInterview();
                touchPage5p2.InstanceRef32 = this;
                touchPage5p2.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 34) {
                saveWrittenAnswerToDB("likeTheFeelingOf", "comment1", tbAnswer1.Text.ToString());
                saveWrittenAnswerToDB("likeTheFeelingOf", "comment2", tbAnswer2.Text.ToString());
                IndependentInterview touchPage6 = new IndependentInterview();
                touchPage6.InstanceRef33 = this;
                touchPage6.Show();
                this.Hide();
            }
            //-------------
            //SMELL SECTION
            //-------------
            else if (Globals.interview_page == 35) {
                saveWrittenAnswerToDB("likeTheFeelingOf", "comment3", tbAnswer1.Text.ToString());
                IndependentInterview smellPage1 = new IndependentInterview();
                smellPage1.InstanceRef34 = this;
                smellPage1.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 36) {
                if (!Globals.previousClicked) {
                    updateOnPreviousClicked("cookingSmells", "foodSmells", "cleaningProducts", "toiletSmells", "perfumes", "bodySmells", "smellDontLike"));
                } else {
                    writeToDB("cookingSmells", "foodSmells", "cleaningProducts", "toiletSmells", "perfumes", "bodySmells", "smellDontLike");
                    Globals.previousClicked = false;
                }
                IndependentInterview smellPage1p2 = new IndependentInterview();
                smellPage1p2.InstanceRef35 = this;
                smellPage1p2.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 37) {
                saveWrittenAnswerToDB("smellDontLike", "comment1", tbAnswer1.Text.ToString());
                saveWrittenAnswerToDB("smellDontLike", "comment2", tbAnswer2.Text.ToString());
                IndependentInterview smellPage2 = new IndependentInterview();
                smellPage2.InstanceRef36 = this;
                smellPage2.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 38) {
                saveWrittenAnswerToDB("smellDontLike", "comment3", tbAnswer1.Text.ToString());
                IndependentInterview smellPage3 = new IndependentInterview();
                smellPage3.InstanceRef37 = this;
                smellPage3.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 39) {
                if (!Globals.previousClicked) {
                    previousUpdate5("smellingFoods", "smellingPlants", "smellingPerfume", "smellingSoap", "smellingPeople", "likeToSmell");
                } else {
                    writeToDB5("smellingFoods", "smellingPlants", "smellingPerfume", "smellingSoap", "smellingPeople", "likeToSmell");
                    Globals.previousClicked = false;
                }
                IndependentInterview smellPage3p2 = new IndependentInterview();
                smellPage3p2.InstanceRef38 = this;
                smellPage3p2.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 40) {
                saveWrittenAnswerToDB("likeToSmell", "comment1", tbAnswer1.Text.ToString());
                saveWrittenAnswerToDB("likeToSmell", "comment2", tbAnswer2.Text.ToString());
                IndependentInterview smellPage4 = new IndependentInterview();
                smellPage4.InstanceRef39 = this;
                smellPage4.Show();
                this.Hide();
            }
            //-------------
            //TASTE SECTION
            //-------------
            else if (Globals.interview_page == 41) {
                saveWrittenAnswerToDB("likeToSmell", "comment3", tbAnswer1.Text.ToString());
                IndependentInterview tastePage1 = new IndependentInterview();
                tastePage1.InstanceRef40 = this;
                tastePage1.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 42) {
                if (!Globals.previousClicked) {
                    updateOnPreviousClicked("vegetables", "fruit", "meat", "fish", "eggs", "dairy", "foodGroupsDontLike");
                } else {
                    writeToDB("vegetables", "fruit", "meat", "fish", "eggs", "dairy", "foodGroupsDontLike");
                    Globals.previousClicked = false;
                }
                IndependentInterview tastePage1p2 = new IndependentInterview();
                tastePage1p2.InstanceRef41 = this;
                tastePage1p2.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 43) {
                updateDBfoodGroupsDontLike("bread", "pasta", "foodGroupsDontLike");
                IndependentInterview tastePage1p3 = new IndependentInterview();
                tastePage1p3.InstanceRef42 = this;
                tastePage1p3.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 44) {
                saveWrittenAnswerToDB("foodGroupsDontLike", "comment1", tbAnswer1.Text.ToString());
                saveWrittenAnswerToDB("foodGroupsDontLike", "comment2", tbAnswer2.Text.ToString());

                IndependentInterview tastePage2 = new IndependentInterview();
                tastePage2.InstanceRef43 = this;
                tastePage2.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 45) {
                if (!Globals.previousClicked) {
                    updateOnPreviousClicked("lumpy", "chewy", "runnyOrSlippery", "mixed", "sweet", "sour", "tastesOrFeelsInMouthDontLike");
                } else {
                    writeToDB("lumpy", "chewy", "runnyOrSlippery", "mixed", "sweet", "sour", "tastesOrFeelsInMouthDontLike");
                    Globals.previousClicked = false;
                }
                IndependentInterview tastePage2p2 = new IndependentInterview();
                tastePage2p2.InstanceRef44 = this;
                tastePage2p2.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 46) {
                updateDBtastesOrFeelsInMouthDontLike("salty", "spicy", "tastesOrFeelsInMouthDontLike" );
                IndependentInterview tastePage2p3 = new IndependentInterview();
                tastePage2p3.InstanceRef45 = this;
                tastePage2p3.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 47) {
                saveWrittenAnswerToDB("tastesOrFeelsInMouthDontLike", "comment1", tbAnswer1.Text.ToString());
                saveWrittenAnswerToDB("tastesOrFeelsInMouthDontLike", "comment2", tbAnswer2.Text.ToString());
                IndependentInterview tastePage3 = new IndependentInterview();
                tastePage3.InstanceRef46 = this;
                tastePage3.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 48) {
                saveWrittenAnswerToDB("tastesOrFeelsInMouthDontLike", "comment3", tbAnswer1.Text.ToString());
                IndependentInterview tastePage4 = new IndependentInterview();
                tastePage4.InstanceRef47 = this;
                tastePage4.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 49) {
                if (!Globals.previousClicked) {
                    previousUpdate2("familiarFoods", "unfamiliarFoods", "foodReallyLikeToEat");
                } else {
                    writeToDBTop2("familiarFoods", "unfamiliarFoods", "foodReallyLikeToEat");
                    Globals.previousClicked = false;
                }
                IndependentInterview tastePage4p2 = new IndependentInterview();
                tastePage4p2.InstanceRef48 = this;
                tastePage4p2.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 50) {
                saveWrittenAnswerToDB("foodReallyLikeToEat", "comment1", tbAnswer1.Text.ToString());
                saveWrittenAnswerToDB("foodReallyLikeToEat", "comment2", tbAnswer2.Text.ToString());
                IndependentInterview tastePage5 = new IndependentInterview();
                tastePage5.InstanceRef49 = this;
                tastePage5.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 51) {
                saveWrittenAnswerToDB("foodReallyLikeToEat", "comment3", tbAnswer1.Text.ToString());
                IndependentInterview tastePage6 = new IndependentInterview();
                tastePage6.InstanceRef50 = this;
                tastePage6.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 52) {
                if (!Globals.previousClicked) {
                    previousUpdate3("shirt", "hair", "objects", "thingsPutInMouthALot");
                } else {
                writeToDBTop3("shirt", "hair", "objects", "thingsPutInMouthALot");
                    Globals.previousClicked = false;
                }

                IndependentInterview tastePage6p2 = new IndependentInterview();
                tastePage6p2.InstanceRef51 = this;
                tastePage6p2.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 53) {
                saveWrittenAnswerToDB("thingsPutInMouthALot", "comment1", tbAnswer1.Text.ToString());
                saveWrittenAnswerToDB("thingsPutInMouthALot", "comment2", tbAnswer2.Text.ToString());
                IndependentInterview tastePage7 = new IndependentInterview();
                tastePage7.InstanceRef52 = this;
                tastePage7.Show();
                this.Hide();
            }
            //----------------
            //Movement SECTION
            //----------------
            else if (Globals.interview_page == 54) {
                saveWrittenAnswerToDB("thingsPutInMouthALot", "comment3", tbAnswer1.Text.ToString());
                this.Hide();
                IndependentInterview mvmtPage1 = new IndependentInterview();
                mvmtPage1.InstanceRef53 = this;
                mvmtPage1.Show();
            }
            else if (Globals.interview_page == 55) {
                if (!Globals.previousClicked) {
                    previousUpdate5("beingJumpedOnOrTackled", "movingWhenICantSeeWhereIAmGoing", "balancing", "beingUpsideDown", "climbingUpHigh", "movingDontLike"):
                } else {
                writeToDB5("beingJumpedOnOrTackled", "movingWhenICantSeeWhereIAmGoing", "balancing", "beingUpsideDown", "climbingUpHigh", "movingDontLike");
                    Globals.previousClicked = false;
                }
                this.Hide();
                IndependentInterview mvmtPage1p2 = new IndependentInterview();
                mvmtPage1p2.InstanceRef54 = this;
                mvmtPage1p2.Show();
            }
            else if (Globals.interview_page == 56) {
                saveWrittenAnswerToDB("movingDontLike", "comment1", tbAnswer1.Text.ToString());
                saveWrittenAnswerToDB("movingDontLike", "comment2", tbAnswer2.Text.ToString());
                this.Hide();
                IndependentInterview mvmtPage2 = new IndependentInterview();
                mvmtPage2.InstanceRef55 = this;
                mvmtPage2.Show();
            }
            else if (Globals.interview_page == 57) {

                saveWrittenAnswerToDB("movingDontLike", "comment3", tbAnswer1.Text.ToString());
                saveWrittenAnswerToDB("movingDontLike", "comment4", tbAnswer2.Text.ToString());
                this.Hide();
                IndependentInterview mvmtPage3 = new IndependentInterview();
                mvmtPage3.InstanceRef56 = this;
                mvmtPage3.Show();
            }
            else if (Globals.interview_page == 58) {
                if (!Globals.previousClicked) {
                    previousUpdate2("standingStill", "sittingStill", "hardToStayStill");
                } else {
                    writeToDBTop2("standingStill", "sittingStill", "hardToStayStill");
                    Globals.previousClicked = false;
                }
                this.Hide();
                IndependentInterview mvmtPage3p2 = new IndependentInterview();
                mvmtPage3p2.InstanceRef57 = this;
                mvmtPage3p2.Show();
            }
            else if (Globals.interview_page == 59) {

                saveWrittenAnswerToDB("hardToStayStill", "comment1", tbAnswer1.Text.ToString());
                IndependentInterview mvmtPage4 = new IndependentInterview();
                mvmtPage4.InstanceRef58 = this;
                mvmtPage4.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 60) {
                if (!Globals.previousClicked) {
                    previousUpdate5("movingInWater", "swinging", "spinning", "jumpingOnTheTrampoline", "running", "movingThatYouLike");
                } else {
                writeToDB5("movingInWater", "swinging", "spinning", "jumpingOnTheTrampoline", "running", "movingThatYouLike");
                    Globals.previousClicked = false;
                }
                this.Hide();
                IndependentInterview mvmtPage4p2 = new IndependentInterview();
                mvmtPage4p2.InstanceRef59 = this;
                mvmtPage4p2.Show();
            }
            else if (Globals.interview_page == 61) {
                saveWrittenAnswerToDB("movingThatYouLike", "comment1", tbAnswer1.Text.ToString());
                saveWrittenAnswerToDB("movingThatYouLike", "comment2", tbAnswer2.Text.ToString());
                IndependentInterview mvmtPage5 = new IndependentInterview();
                mvmtPage5.InstanceRef60 = this;
                mvmtPage5.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 62) {
                if (!Globals.previousClicked) {
                    previousUpdate4("rocking", "movingHands", "clapping", "pacing", "moveOverAndOverAgain");
                } else {
                writeToDB4( "rocking", "movingHands", "clapping", "pacing", "moveOverAndOverAgain");
                    Globals.previousClicked = false;
                }
                this.Hide();
                IndependentInterview mvmtPage5p2 = new IndependentInterview();
                mvmtPage5p2.InstanceRef61 = this;
                mvmtPage5p2.Show();
            }
            else if (Globals.interview_page == 63) {
                saveWrittenAnswerToDB("moveOverAndOverAgain", "comment1", tbAnswer1.Text.ToString());
                saveWrittenAnswerToDB("moveOverAndOverAgain", "comment2", tbAnswer2.Text.ToString());
                this.Hide();
                IndependentInterview mvmtPage6 = new IndependentInterview();
                mvmtPage6.InstanceRef62 = this;
                mvmtPage6.Show();
            }
            //-------------------
            //ENVIRONMENT SECTION
            //-------------------
            else if (Globals.interview_page == 64) {
                saveWrittenAnswerToDB("moveOverAndOverAgain", "comment3", tbAnswer1.Text.ToString());
                saveWrittenAnswerToDB("moveOverAndOverAgain", "comment4", tbAnswer2.Text.ToString());
                IndependentInterview environmentPage1 = new IndependentInterview();
                environmentPage1.InstanceRef63 = this;
                environmentPage1.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 65) {
                if (!Globals.previousClicked) {
                    previousUpdate5("supermarket", "party", "foodHall", "show", "shoppingMall", "other");
                } else {
                writeToDB5("supermarket", "party", "foodHall", "show", "shoppingMall", "other");
                    Globals.previousClicked = false;
                }
                IndependentInterview environmentPage1p2 = new IndependentInterview();
                environmentPage1p2.InstanceRef64 = this;
                environmentPage1p2.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 66) {
                saveWrittenAnswerToDB("other", "comment1", tbAnswer1.Text.ToString());
                saveWrittenAnswerToDB("other", "comment2", tbAnswer2.Text.ToString());
                IndependentInterview environmentPage2 = new IndependentInterview();
                environmentPage2.InstanceRef65 = this;
                environmentPage2.Show();
                this.Hide();
            }
            //-------------
            //OTHER SECTION
            //-------------
            else if (Globals.interview_page == 67) {
                saveWrittenAnswerToDB("other", "comment3", tbAnswer1.Text.ToString());
                saveWrittenAnswerToDB("other", "comment4", tbAnswer2.Text.ToString());
                IndependentInterview otherPage1 = new IndependentInterview();
                otherPage1.InstanceRef66 = this;
                otherPage1.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 68) {
                updateDBother("sounds", "smells", "sights", "tastes", "feelings", "movements", "other");
                IndependentInterview otherPage1p2 = new IndependentInterview();
                otherPage1p2.InstanceRef67 = this;
                otherPage1p2.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 69) {
                saveWrittenAnswerToDB("other", "comment5", tbAnswer1.Text.ToString());
                saveWrittenAnswerToDB("other", "comment6", tbAnswer2.Text.ToString());
                IndependentInterview otherPage2 = new IndependentInterview();
                otherPage2.InstanceRef68 = this;
                otherPage2.Show();
                this.Hide();
            }
            else if (Globals.interview_page == 70) {
                saveWrittenAnswerToDB("other", "comment7", tbAnswer1.Text.ToString());
                saveWrittenAnswerToDB("other", "comment8", tbAnswer2.Text.ToString());
                IndependentInterview additionalNotes = new IndependentInterview();
                additionalNotesPanel.BringToFront();
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            saveWrittenAnswerToDB("otComments", "OTComments", textBox1.Text.ToString());
            Summary sum = new Summary();
            sum.Show();
        }
        /// <summary>
        /// Previous button functionality
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void previousInterviewSlideBtn_Click(object sender, EventArgs e) {
            Globals.previousClicked = true;
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
            else if (Globals.interview_page == 52) {
                this.Hide();
                InstanceRef52.Show();
            }
            else if (Globals.interview_page == 53) {
                this.Hide();
                InstanceRef53.Show();
            }
            else if (Globals.interview_page == 54) {
                this.Hide();
                InstanceRef54.Show();
            }
            else if (Globals.interview_page == 55) {
                this.Hide();
                InstanceRef55.Show();
            }
            else if (Globals.interview_page == 56) {
                this.Hide();
                InstanceRef56.Show();
            }
            else if (Globals.interview_page == 57) {
                this.Hide();
                InstanceRef57.Show();
            }
            else if (Globals.interview_page == 58) {
                this.Hide();
                InstanceRef58.Show();
            }
            else if (Globals.interview_page == 59) {
                this.Hide();
                InstanceRef59.Show();
            }
            else if (Globals.interview_page == 60) {
                this.Hide();
                InstanceRef60.Show();
            }
            else if (Globals.interview_page == 61) {
                this.Hide();
                InstanceRef61.Show();
            }
            else if (Globals.interview_page == 62) {
                this.Hide();
                InstanceRef62.Show();
            }
            else if (Globals.interview_page == 63) {
                this.Hide();
                InstanceRef63.Show();
            }
            else if (Globals.interview_page == 64) {
                this.Hide();
                InstanceRef64.Show();
            }
            else if (Globals.interview_page == 65) {
                this.Hide();
                InstanceRef65.Show();
            }
            else if (Globals.interview_page == 66) {
                this.Hide();
                InstanceRef66.Show();
            }
            else if (Globals.interview_page == 67) {
                this.Hide();
                InstanceRef67.Show();
            }
            else if (Globals.interview_page == 68) {
                this.Hide();
                InstanceRef68.Show();
            }
            else if (Globals.interview_page == 69) {
                this.Hide();
                InstanceRef69.Show();
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
            playReadOutLoud();

            hideButtons();
            displayButtons(topLeftPBALittleBtn, topLeftPBALotBtn);
        }
        private void topMidPB_Click(object sender, EventArgs e) {
            topLeftPBPlayer.SoundLocation = topMiddleReadOutLoudPath;
            playReadOutLoud();
            hideButtons();
            displayButtons(topMidALittleBtn, topMidALotBtn);
        }
        private void topRightPB_Click(object sender, EventArgs e) {
            topLeftPBPlayer.SoundLocation = topRightReadOutLoudPath;
            playReadOutLoud();
            hideButtons();
            displayButtons(topRightALittleBtn, topRightALotBtn);
        }
        private void bottomLeftPB_Click(object sender, EventArgs e) {
            topLeftPBPlayer.SoundLocation = bottomLeftReadOutLoudPath;
            playReadOutLoud();
            hideButtons();
            displayButtons(bottomLeftALittleBtn, bottomLeftALotBtn);
        }
        private void bottomMidPB_Click(object sender, EventArgs e) {
            topLeftPBPlayer.SoundLocation = bottomMiddleReadOutLoudPath;
            playReadOutLoud();
            hideButtons();
            displayButtons(bottomMidALittleBtn, bottomMidALotBtn);
        }
        private void bottomRightPB_Click(object sender, EventArgs e) {
            topLeftPBPlayer.SoundLocation = bottomrightReadOutLoudPath;
            playReadOutLoud();

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
        private Form m_InstanceRef52 = null;
        public Form InstanceRef52 {
            get { return m_InstanceRef52; }
            set { m_InstanceRef52 = value; }
        }
        private Form m_InstanceRef53 = null;
        public Form InstanceRef53 {
            get { return m_InstanceRef53; }
            set { m_InstanceRef53 = value; }
        }
        private Form m_InstanceRef54 = null;
        public Form InstanceRef54 {
            get { return m_InstanceRef54; }
            set { m_InstanceRef54 = value; }
        }
        private Form m_InstanceRef55 = null;
        public Form InstanceRef55 {
            get { return m_InstanceRef55; }
            set { m_InstanceRef55 = value; }
        }
        private Form m_InstanceRef56 = null;
        public Form InstanceRef56 {
            get { return m_InstanceRef56; }
            set { m_InstanceRef56 = value; }
        }
        private Form m_InstanceRef57 = null;
        public Form InstanceRef57 {
            get { return m_InstanceRef57; }
            set { m_InstanceRef57 = value; }
        }
        private Form m_InstanceRef58 = null;
        public Form InstanceRef58 {
            get { return m_InstanceRef58; }
            set { m_InstanceRef58 = value; }
        }
        private Form m_InstanceRef59 = null;
        public Form InstanceRef59 {
            get { return m_InstanceRef59; }
            set { m_InstanceRef59 = value; }
        }
        private Form m_InstanceRef60 = null;
        public Form InstanceRef60 {
            get { return m_InstanceRef60; }
            set { m_InstanceRef60 = value; }
        }
        private Form m_InstanceRef61 = null;
        public Form InstanceRef61 {
            get { return m_InstanceRef61; }
            set { m_InstanceRef61 = value; }
        }
        private Form m_InstanceRef62 = null;
        public Form InstanceRef62 {
            get { return m_InstanceRef62; }
            set { m_InstanceRef62 = value; }
        }
        private Form m_InstanceRef63 = null;
        public Form InstanceRef63 {
            get { return m_InstanceRef63; }
            set { m_InstanceRef63 = value; }
        }
        private Form m_InstanceRef64 = null;
        public Form InstanceRef64 {
            get { return m_InstanceRef64; }
            set { m_InstanceRef64 = value; }
        }
        private Form m_InstanceRef65 = null;
        public Form InstanceRef65 {
            get { return m_InstanceRef65; }
            set { m_InstanceRef65 = value; }
        }
        private Form m_InstanceRef66 = null;
        public Form InstanceRef66 {
            get { return m_InstanceRef66; }
            set { m_InstanceRef66 = value; }
        }
        private Form m_InstanceRef67 = null;
        public Form InstanceRef67 {
            get { return m_InstanceRef67; }
            set { m_InstanceRef67 = value; }
        }
        private Form m_InstanceRef68 = null;
        public Form InstanceRef68 {
            get { return m_InstanceRef68; }
            set { m_InstanceRef68 = value; }
        }
        private Form m_InstanceRef69 = null;
        public Form InstanceRef69 {
            get { return m_InstanceRef69; }
            set { m_InstanceRef69 = value; }
        }

        private void bottomMidPB2_Click(object sender, EventArgs e)
        {

        }

        private void picturePanel_Paint(object sender, PaintEventArgs e)
        {

        }


        /// <summary>
        /// Read Out Loud toggles 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        private bool toggleReadOutLoad = false; 

        private void loadReadOutLoudToggleBtn()
        {
            if (toggleReadOutLoad)
            {
                readOutLoudToggleBtn.Text = "ReadOutLoud: ON";
            } else
            {
                readOutLoudToggleBtn.Text = "ReadOutLoud: OFF";
            }
        }

        private void playReadOutLoud()
        {
            if (toggleReadOutLoad)
            {
                topLeftPBPlayer.Play();
            } 
        }

        private void readOutLoudToggleBtn_Click(object sender, EventArgs e)
        {
            toggleReadOutLoad = !toggleReadOutLoad;
            loadReadOutLoudToggleBtn();
        }
    }
}

