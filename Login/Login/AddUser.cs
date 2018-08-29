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
        SqlDataAdapter da;

        public static AddUser staticVar = null;

        public AddUser() {
            InitializeComponent();
            this.Location = new Point(0,0);
            staticVar = this;
        }

        void AddUser_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing) {
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
            //if gender is not chosen, program crashes
            genderSelection = cbGender.Items[cbGender.SelectedIndex].ToString().Trim();
            con = new SqlConnection("Data Source=DESKTOP-G8RH1E3\\SQLEXPRESS;Initial Catalog=CapstoneDB;Integrated Security=True");
            con.Open();
            cmd = new SqlCommand("INSERT INTO testUser (firstName, lastName, gender, age, phone, email) VALUES (@firstName, @lastName, @gender, @age, @phone, @email)", con);
            cmd.Parameters.AddWithValue("@firstName", tbFname.Text.Trim());
            cmd.Parameters.AddWithValue("@lastName", tbLname.Text.Trim());
            cmd.Parameters.AddWithValue("@gender", genderSelection);
            cmd.Parameters.AddWithValue("@age", tbAge.Text.Trim());
            cmd.Parameters.AddWithValue("@phone", tbPhone.Text.Trim());
            cmd.Parameters.AddWithValue("@email", tbEmail.Text.Trim());
            cmd.ExecuteNonQuery();
            MessageBox.Show("New user has been added successfully.");
            this.Close();
        }
    }
    }
