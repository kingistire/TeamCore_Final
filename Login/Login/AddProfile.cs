using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Login {
    public partial class AddUser : Form {
        SqlCommand cmd;
        SqlConnection con;

        public static AddUser staticVar = null;

        public AddUser() {
            InitializeComponent();
            this.Location = new Point(0,0);
            staticVar = this;
            cbGender.SelectedIndex = 2; // make default selection so it won't crash
        }

        private bool AreRequiredFieldsIncomplete()
        {
            if (tbFname.Text.Trim().Length == 0 || tbLname.Text.Trim().Length == 0
                || cbGender.SelectedIndex == -1)
            {
                return true;
            }
            return false;
        }

        //doesnt work
        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            if (string.Equals((sender as Button).Name, @"CloseButton")) {
                MessageBox.Show("Are you sure you want to close this window?");
            }
            // Do something proper to CloseButton.
            else {
                Globals.addUserExists = false;
            }
}
        private void AddUser_Resize(object sender, EventArgs e) {
            //RestoreBounds Property contains the original shape
            this.SetBounds(this.RestoreBounds.X, this.RestoreBounds.Y, this.RestoreBounds.Width, this.RestoreBounds.Height);
            this.Refresh();
        }

    
        private void btnSave_Click_1(object sender, EventArgs e) {
            string genderSelection = "";

            if (AreRequiredFieldsIncomplete())
            {
                requiredFieldsWarningLabel.Visible = true;
                requiredFieldsWarningLabel.Text = "Please fill out the *Required* fields";

            } else
            {
                genderSelection = cbGender.Items[cbGender.SelectedIndex].ToString().Trim();


                con = new SqlConnection(@"Data Source =(LocalDB)\MSSQLLocalDB;" +
                    @"AttachDbFilename = |DataDirectory|\CapstoneDB\CapstoneDB.mdf; Integrated Security = True");
                con.Open();
                cmd = new SqlCommand("INSERT INTO UserInformation (firstName, lastName, dob, gender, phone, email) VALUES (@firstName, @lastName, @dob, @gender, @phone, @email)", con);
                cmd.Parameters.AddWithValue("@firstName", tbFname.Text.Trim());
                cmd.Parameters.AddWithValue("@lastName", tbLname.Text.Trim());
                cmd.Parameters.AddWithValue("@gender", genderSelection.Trim());
                
                cmd.Parameters.AddWithValue("@phone", tbPhone.Text.Trim());
                cmd.Parameters.AddWithValue("@email", tbEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", dateTimePicker1.Value);
                cmd.ExecuteNonQuery();
                MessageBox.Show(tbFname.Text.Trim() + " " + tbLname.Text.Trim() + " has been added successfully.");
                this.Close();
                con.Close();
            }
            
        }
    }
    }
