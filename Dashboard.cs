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

namespace University_Bookstore
{
   
    public partial class Dashboard : Form
    {
        SqlConnection con = new SqlConnection(St.connection);
        
        public Dashboard()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            AddBooks addBooks = new AddBooks();
            addBooks.Tag = this;
            addBooks.Show();
            Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            AddStd addStd = new AddStd();
            addStd.Tag = this;
            addStd.Show();
            Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            AdmLogin admLogin = new AdmLogin();
            admLogin.Tag = this;
            admLogin.Show();
            Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            AdmLogin admLogin = new AdmLogin();
            admLogin.Tag = this;
            admLogin.Show();
            Hide();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            con.Open();
            string q = "SELECT SUM(QUANTITY) FROM addBook";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                label13.Text = dr.GetValue(0).ToString();
            }
            con.Close();

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            con.Open();
            string s = "SELECT COUNT(SL) FROM addStudent";
            SqlCommand cmd2 = new SqlCommand(s, con);
            SqlDataReader sdr = cmd2.ExecuteReader();
            while (sdr.Read())
            {
                label15.Text = sdr.GetValue(0).ToString();
            }
            con.Close();
        }
    }
}
