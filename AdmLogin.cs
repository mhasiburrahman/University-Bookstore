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
    public partial class AdmLogin : Form
    {
        string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
        public AdmLogin()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AdmLogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                SqlConnection Sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\KAKON\Desktop\University-Bookstore\AdminDB\AdminloginDB.mdf;Integrated Security=True;Connect Timeout=30");
                string query = "select * from ADLOGIN_TBL where username = '" + textBox1.Text.Trim() + "'and pass = '" + textBox2.Text.Trim() + "'";
                SqlDataAdapter sd = new SqlDataAdapter(query, Sqlcon);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    AddBooks ds = new AddBooks();
                    this.Hide();
                    ds.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Email or Password!");
                }



            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, " Email can't be empty ");
            }
            else
            {
                errorProvider1.Clear();
            }

            if (Regex.IsMatch(textBox1.Text, pattern) == false)
            {
                textBox1.Focus();
                errorProvider3.SetError(this.textBox1, " Invalid email ");
            }
            else
            {
                errorProvider3.Clear();
            }
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

        private void label5_Click(object sender, EventArgs e)
        {
            StdLogin stdLogin = new StdLogin();
            stdLogin.Tag = this;
            stdLogin.Show();
            Hide();
        }
    }
}
