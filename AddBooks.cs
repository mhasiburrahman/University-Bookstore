using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace University_Bookstore
{
    public partial class AddBooks : Form
    {
        public AddBooks()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            AddStd addStd = new AddStd();
            addStd.Tag = this;
            addStd.Show();
            Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Dashboard dash = new Dashboard();
            dash.Tag = this;
            dash.Show();
            Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Dashboard dash = new Dashboard();
            dash.Tag = this;
            dash.Show();
            Hide();
        }
    }
}
