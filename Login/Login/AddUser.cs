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

        public AddUser() {
            InitializeComponent();
        }

        private void btnSave_Click_1(object sender, EventArgs e) {
            string genderSelection = "";
            //if gender is not chosen, program crashes
            genderSelection = cbGender.Items[cbGender.SelectedIndex].ToString();
            con = new SqlConnection("Data Source=DESKTOP-G8RH1E3\\SQLEXPRESS;Initial Catalog=CapstoneDB;Integrated Security=True");
            con.Open();
            cmd = new SqlCommand("INSERT INTO testUser (firstName, lastName, gender, age, phone, email) VALUES (@firstName, @lastName, @gender, @age, @phone, @email)", con);
            cmd.Parameters.Add("@firstName", tbFname.Text);
            cmd.Parameters.Add("@lastName", tbLname.Text);
            cmd.Parameters.Add("@gender", genderSelection);
            cmd.Parameters.Add("@age", tbAge.Text);
            cmd.Parameters.Add("@phone", tbPhone.Text);
            cmd.Parameters.Add("@email", tbEmail.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("New user has been added successfully.");
            this.Close();
        }
    }
    }
