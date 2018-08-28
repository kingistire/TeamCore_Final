﻿using System;
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
    public partial class EditUser2 : Form {
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;

        public EditUser2(string idValue) {
            InitializeComponent();
            label9.Text = idValue;
            this.Location = new Point(0, 0);
        }

        private void btnSave_Click_1(object sender, EventArgs e) {
            string genderSelection = "";
            //if gender is not chosen, program crashes
            genderSelection = cbGender.Items[cbGender.SelectedIndex].ToString();
            //con = new SqlConnection("Data Source=DESKTOP-G8RH1E3\\SQLEXPRESS;Initial Catalog=CapstoneDB;Integrated Security=True");
            //string query = "UPDATE testUser SET Id='" + this.label9.Text + "',firstName='" + this.tbFname.Text + "',lastName='" + this.tbLname.Text + "',gender='" + this.cbGender.Text + "',age='" + this.tbAge.Text + "',phone='" + this.tbPhone.Text + "',email='" + this.tbEmail.Text + "' WHERE Id='" + this.label9.Text + "'; ";
            //string query = "update testUser set name'" + tbFname.Text + "' where Id='" + label9.Text + "'";
            //using (SqlCommand cmd = new SqlCommand("UPDATE testUser SET firstName = @newFname, lastName = @newLname" + " WHERE Id=@Id", con) {
            //    cmd.Parameters.AddWithValue("@firstName", tbFname.Text);
            //    cmd.Parameters.AddWithValue("@lastName", tbLname.Text);
            //}
            string conString = "Data Source=DESKTOP-G8RH1E3\\SQLEXPRESS;Initial Catalog=CapstoneDB;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(conString)) {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE testUser SET firstName=@NewFirstName, lastName=@NewLastName, gender=@NewGender, age=@NewAge, phone=@NewPhone, email=@NewEmail" +
                        " WHERE Id=@Id", conn)) {
                    cmd.Parameters.AddWithValue("@Id", label9.Text);
                    cmd.Parameters.AddWithValue("@NewFirstName", tbFname.Text);
                    cmd.Parameters.AddWithValue("@NewLastName", tbLname.Text);
                    cmd.Parameters.AddWithValue("@NewGender", genderSelection);
                    cmd.Parameters.AddWithValue("@NewAge", tbAge.Text);
                    cmd.Parameters.AddWithValue("@NewPhone", tbPhone.Text);
                    cmd.Parameters.AddWithValue("@NewEmail", tbEmail.Text);
                    int rows = cmd.ExecuteNonQuery();

                    try {
                        MessageBox.Show("User has been updated successfully.");
                        this.Close();
                    }
                    catch (Exception ex) { }
                }
            }
        }

        private void EditUser2_Load_1(object sender, EventArgs e) {
            string constring = "Data Source=DESKTOP-G8RH1E3\\SQLEXPRESS;Initial Catalog=CapstoneDB;Integrated Security=True";
            SqlConnection conDatabase = new SqlConnection(constring);
            SqlCommand cmdDatabase = new SqlCommand(" select * from testUser where Id='" + label9.Text + "';", conDatabase);
            try {
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmdDatabase;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = dbdataset;
                dataGridView1.DataSource = bSource;
                sda.Update(dbdataset);
                tbFname.Text = dataGridView1.Rows[0].Cells[1].Value.ToString().Trim();
                tbLname.Text = dataGridView1.Rows[0].Cells[2].Value.ToString().Trim();
                cbGender.Text = dataGridView1.Rows[0].Cells[3].Value.ToString().Trim();
                tbAge.Text = dataGridView1.Rows[0].Cells[4].Value.ToString().Trim();
                tbPhone.Text = dataGridView1.Rows[0].Cells[5].Value.ToString().Trim();
                tbEmail.Text = dataGridView1.Rows[0].Cells[6].Value.ToString().Trim();
                //was: tbEmail.Text = dataGridView1.Rows[0].Cells[6].Value as string;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}