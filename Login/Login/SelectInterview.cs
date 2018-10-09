using System;
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
            SelectInterview_Load();
        }

        private void btnStart_Click(object sender, EventArgs e) {
            if (radioGuided.Checked==true) {
                GuidedInterviewCover newGuidedInt = new GuidedInterviewCover();
                newGuidedInt.Show();
                this.Hide();
            }
            else if (radioIndependent.Checked==true) {
                IndependentCover newIndependentInt = new IndependentCover();
                newIndependentInt.Show();
                this.Hide();
            }
            else if (radioFamily.Checked == true) {
                FamilyInterviewCover newFamilyInt = new FamilyInterviewCover();
                newFamilyInt.Show();
                this.Hide();
            }
        }
        private void SelectInterview_Load() {
            try {
                SqlConnection conn = new SqlConnection(@"Data Source =(LocalDB)\MSSQLLocalDB;" +
                @"AttachDbFilename = |DataDirectory|\CapstoneDB\CapstoneDB.mdf; Integrated Security = True");
                conn.Open();
                SqlCommand sc = new SqlCommand("select Id,firstName from dbo.UserInformation", conn);
                SqlDataReader reader;
                reader = sc.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("firstName", typeof(string));
                dt.Load(reader);
                comboBox1.ValueMember = "Id";
                comboBox1.DisplayMember = "firstName";
                comboBox1.DataSource = dt;

                conn.Close();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private DataTable dbdataset = new DataTable();

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            string ID = comboBox1.SelectedValue.ToString();
        }
    }
}
