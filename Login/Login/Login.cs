﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Login {
    public partial class Login : Form {

        public Login() {
            InitializeComponent();
        }

        private void btnNewAcc_Click(object sender, EventArgs e) {
            this.Hide();
            NewAccount newAcc = new NewAccount();
            newAcc.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e) {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-G8RH1E3\\SQLEXPRESS;Initial Catalog=CapstoneDB;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("Select Role from Login Where Username='" + tbUsername.Text + "' and Password='" + tbPassword.Text + "'",con);
            DataTable dt = new System.Data.DataTable();
            sda.Fill(dt);
            //change it to == 1 for proper login functionality
            //matches row to info stored in db
            if (dt.Rows.Count == 0) {
                this.Hide();
                MDIParent1 ss = new MDIParent1();
                ss.Show();
                //((Form)ss).Controls["label1"].Text = "You're logged in as: " + dt.Rows[0][0].ToString();
            }
            else {
                MessageBox.Show("Incorrect Username or Password.\nPlease try again.");
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            this.Hide();
            NewAccount newAcc = new NewAccount();
            newAcc.Show();
        }
    }
}