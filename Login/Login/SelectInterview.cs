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
using System.IO;

namespace Login {

    public partial class SelectInterview : Form {

        public SelectInterview() {
            InitializeComponent();
            
        }

        private void btnStart_Click(object sender, EventArgs e) {
            if (radioGuided.Checked==true) {
                GuidedInterview newGuidedInt = new GuidedInterview();
                newGuidedInt.Show();
                this.Hide();
            }
            else if (radioIndependent.Checked==true) {
                IndependentInterview newIndependentInt = new IndependentInterview();
                newIndependentInt.Show();
                this.Hide();
            }
        }

        //won't work until the database is configured properly
        /*private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            string constring = @"Data Source =(LocalDB)\MSSQLLocalDB;" +
                @"AttachDbFilename = |DataDirectory|\CapstoneDB\CapstoneDB.mdf; Integrated Security = True";
            SqlConnection conDatabase = new SqlConnection(constring);
            SqlCommand cmdDatabase = new SqlCommand(" select * from UserInformation ;", conDatabase);
            try {
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmdDatabase;
                DataTable profileNames = new DataTable();
                sda.Fill(profileNames);
                foreach (DataRow dr in profileNames.Rows) {
                    comboBox1.Items.Add(dr["firstName"].ToString());
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }*/
    }
}
