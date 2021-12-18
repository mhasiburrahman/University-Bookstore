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
using System.Text.RegularExpressions;

namespace University_Bookstore
{
    public partial class StdLogin : Form

    {
        private bool showpass = false;
        /*string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\)+[a-zA-Z]{2,9})$";*/
        public StdLogin()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void StdLogin_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            AdmLogin admLogin = new AdmLogin();
            admLogin.Tag = this;
            admLogin.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection Sqlcon = new SqlConnection(St.connection);
            
            string query = "select * from addSTUDENT where username = '" + textBox1.Text.Trim() + "'and pass = '" + textBox2.Text.Trim() + "'";
            SqlDataAdapter std = new SqlDataAdapter(query, Sqlcon);
            DataTable dlt = new DataTable();
            std.Fill(dlt);
            if (dlt.Rows.Count == 1)
            {
                StdForm sd = new StdForm();
                this.Hide();
                sd.Show();
            }
            else
            {
                MessageBox.Show("Invalid Email or Password!");
            }



        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            AdmLogin admLogin = new AdmLogin();
            admLogin.Tag = this;
            admLogin.Show();
            Hide();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, " Username can't be empty ");
            }
            else
            {
                errorProvider1.Clear();
            }

            /*if (Regex.IsMatch(textBox1.Text, pattern) == false)
            {
                textBox1.Focus();
                errorProvider3.SetError(this.textBox1, " Invalid Username ");
            }
            else
            {
                errorProvider3.Clear();
            }*/
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text) == true)
            {
                textBox2.Focus();
                errorProvider2.SetError(this.textBox2, " Password can't be empty ");
            }
            else
            {
                errorProvider2.Clear();
            }

        }

        private void showpassBTN_Click(object sender, EventArgs e)
        {
            if (showpass == false)
            {
                textBox2.UseSystemPasswordChar = false;
                showpass = true;
                showpassBTN.Image = Properties.Resources.show;

            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
                showpass = false;
                showpassBTN.Image = Properties.Resources.hidden;
            }

        }
    }
}
