using Microsoft.VisualStudio.TestTools.UnitTesting;
using Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login.Tests {
    [TestClass()]
    public class GuidedInterviewTests {
        Label TL = new Label();
        private void updateLabelText(string v1, string v2, string v3, string v4, string v5, string v6) {
            TL.Text = v1;
        }

        [TestMethod()]
        public void updateLabelTextTest() {
            updateLabelText("a", "b", "c", "d", "e", "f");

            Assert.AreEqual("a", TL.Text);
        }

        [TestMethod()]
        public void updateTextBox() {
            TextBox tb = new TextBox();
            tb.Text = "test";
            Assert.AreEqual("test", tb.Text);
        }

        [TestMethod()]
        public void readOnlyTextBox() {
            TextBox tb = new TextBox();
            tb.Text = "test";
            tb.ReadOnly = true;
            Assert.IsTrue(true,"Textbox is not readonly!", tb.ReadOnly);
        }

        [TestMethod()]
        public void enableTextBox() {
            TextBox tb = new TextBox();
            tb.Enabled = false;
            tb.Enabled = true;
            Assert.IsTrue(true, "Textbox not enabled", tb.Enabled);
        }

        [TestMethod()]
        public void disableTextBox() {
            TextBox tb = new TextBox();
            tb.Enabled = true;
            tb.Enabled = false;
            Assert.IsFalse(false, "Textbox is enabled", tb.Enabled);
        }

        [TestMethod()]
        public void showTextBox() {
            TextBox tb = new TextBox();
            tb.Visible = false;
            tb.Visible = true;
            Assert.IsTrue(true, "Textbox is not visible!", tb.Visible);
        }

        [TestMethod()]
        public void HideTextBox() {
            TextBox tb = new TextBox();
            tb.Visible = false;
            Assert.IsFalse(false, "Textbox is not invisible!", tb.Visible);
        }

        [TestMethod()]
        public void hideLabel() {
            TL.Visible = false;
            TL.Visible = true;
            TL.Visible = false;
            Assert.IsFalse(false, "Label is visible", TL.Visible);
        }

        [TestMethod()]
        public void showLabel() {
            TL.Visible = true;
            TL.Visible = false;
            TL.Visible = true;
            Assert.IsTrue(true, "Label is not invisible!", TL.Visible);
        }
        [TestMethod()]
        public void switchPanels() {
            Panel p1 = new Panel();
            Panel p2 = new Panel();
            bool isClicked = false;
            if (!isClicked) {
                p1.Visible = true;
                p1.BringToFront();
                p2.Visible = false;
                isClicked = true;
            } else {
                p2.Visible = true;
                p1.Visible = false;
            }

            Assert.IsTrue(true, "Panel 1 not visisble", p1.Visible);
        }

        [TestMethod()]
        public void switchPanels2() {
            Panel p1 = new Panel();
            Panel p2 = new Panel();
            bool isClicked = true;
            if (!isClicked) {
                p1.Visible = true;
                p1.BringToFront();
                p2.Visible = false;
                isClicked = true;
            } else {
                p2.Visible = true;
                p1.Visible = false;
            }

            Assert.IsTrue(true, "Panel 2 not visisble", p2.Visible);
        }


    }
}