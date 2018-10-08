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
    public partial class EditProfile : Form {
        DataGridViewRow profileDataRow;

        public EditProfile(DataGridViewRow dataValue) {
            InitializeComponent();
            profileDataRow = dataValue;


            nameTitle.Text = dataValue.Cells[3].Value.ToString().Trim() + ' ' + dataValue.Cells[4].Value.ToString().Trim();
            tbFname.Text = dataValue.Cells[3].Value.ToString().Trim();
            tbLname.Text = dataValue.Cells[4].Value.ToString().Trim();
            cbGender.SelectedItem = dataValue.Cells[5].Value.ToString().Trim();
            
            tbPhone.Text = dataValue.Cells[7].Value.ToString().Trim();
            tbEmail.Text = dataValue.Cells[8].Value.ToString().Trim();
            this.Location = new Point(0, 0);
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


        private void btnSave_Click_1(object sender, EventArgs e) {


            if (AreRequiredFieldsIncomplete())
            {
                requiredFieldsWarningLabel.Visible = true;
                requiredFieldsWarningLabel.Text = "Please fill out the *Required* fields";

            }
            else
            {
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
                string conString = @"Data Source =(LocalDB)\MSSQLLocalDB;" + @"AttachDbFilename = |DataDirectory|\CapstoneDB\CapstoneDB.mdf; Integrated Security = True";
                using (SqlConnection conn = new SqlConnection(conString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("UPDATE UserInformation SET firstName=@NewFirstName, lastName=@NewLastName, gender=@NewGender, phone=@NewPhone, email=@NewEmail, dob=@NewDob" +
                            " WHERE Id=@Id", conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", profileDataRow.Cells[2].Value.ToString());
                        cmd.Parameters.AddWithValue("@NewFirstName", tbFname.Text);
                        cmd.Parameters.AddWithValue("@NewLastName", tbLname.Text);
                        cmd.Parameters.AddWithValue("@NewGender", genderSelection);

                        cmd.Parameters.AddWithValue("@NewPhone", tbPhone.Text);
                        cmd.Parameters.AddWithValue("@NewEmail", tbEmail.Text);
                        cmd.Parameters.AddWithValue("NewDob", dateTimePicker1.Value);
                        int rows = cmd.ExecuteNonQuery();

                        try
                        {
                            MessageBox.Show("User has been updated successfully.");
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error has occurred: " + ex);
                        }
                    }
                }
            }


            
        }

        

        private void editProfile_Load(object sender, EventArgs e)
        {

        }

       

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.tbFname.Enabled = true;
        }

        private void tbFname_Leave(object sender, EventArgs e)
        {
            TextBox clicked = (TextBox)sender;
            clicked.ReadOnly = true;
        }

        private void tbFname_Click(object sender, EventArgs e)
        {
            TextBox clicked = (TextBox)sender;
            clicked.ReadOnly = false;
        }
    }
}
