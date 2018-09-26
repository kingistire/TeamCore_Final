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
    public partial class NewOTAccount : Form {
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;

        public event System.Windows.Forms.FormClosingEventHandler FormClosing;

        public NewOTAccount() {
            InitializeComponent();
            this.Location = new Point(0, 0);
            tbPass1.PasswordChar = '*';
            tbPass2.PasswordChar = '*';

        }

        private void NewAccount_FormClosing(Object sender, FormClosingEventArgs e) {
            System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
            messageBoxCS.AppendFormat("{0} = {1}", "CloseReason", e.CloseReason);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("{0} = {1}", "Cancel", e.Cancel);
            messageBoxCS.AppendLine();
            MessageBox.Show(messageBoxCS.ToString(), "FormClosing Event");
        }
        /*MessageBox.Show("Are you sure you want to close this window?");
            DialogResult result = MessageBox.Show("Are you sure you want to close this window?", "Confirmation", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes) {
                this.Close();
                Login loginForm = new Login();
                loginForm.Show();
            }*/
    
            private void btnSave_Click_1(object sender, EventArgs e) {
                con = new SqlConnection(@"Data Source =(LocalDB)\MSSQLLocalDB;" + 
                    @"AttachDbFilename = |DataDirectory|\CapstoneDB\CapstoneDB.mdf; Integrated Security = True");
                con.Open();
                cmd = new SqlCommand("INSERT INTO UserInformation (firstName, lastName, gender, age, phone, email) VALUES (@firstName, @lastName, @gender, @age, @phone, @email)", con);
                cmd.Parameters.AddWithValue("@firstName", tbEmail.Text);
                cmd.Parameters.AddWithValue("@lastName", tbFname.Text);
                cmd.Parameters.AddWithValue("@age", tbPass1.Text);
                cmd.Parameters.AddWithValue("@email", tbEmail.Text);
                //cmd.Parameters.AddWithValue("@gender", tbGender.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("New user has been added successfully.");
                
                this.Close();
            }
        }
    }
