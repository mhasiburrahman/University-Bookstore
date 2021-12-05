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
    public partial class AddStd : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\KAKON\Desktop\University-Bookstore\AdminDB\AdminloginDB.mdf;Integrated Security=True;Connect Timeout=30");
        public int sl;
        public AddStd()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Dashboard dash = new Dashboard();
            dash.Tag = this;
            dash.Show();
            Hide();
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

        private void label3_Click(object sender, EventArgs e)
        {
            AddBooks addBooks = new AddBooks();
            addBooks.Tag = this;
            addBooks.Show();
            Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {

                SqlCommand cmd = new SqlCommand("INSERT INTO addSTUDENT VALUES (@username, @pass, @id, @department)", conn);
                cmd.CommandType = CommandType.Text;
              
                cmd.Parameters.AddWithValue("@username", textBox1.Text);
                cmd.Parameters.AddWithValue("@pass", textBox2.Text);
                cmd.Parameters.AddWithValue("@id", textBox5.Text);
                cmd.Parameters.AddWithValue("@department", textBox3.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox5.Text = "";
                textBox3.Text = "";
                MessageBox.Show("Insertion Successful", "Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                displayData();
                ResetformControls();
            }
        }

        private bool IsValid()
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("UserName is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public void displayData()
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM addSTUDENT";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            displayData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ResetformControls();
        }

        private void ResetformControls()
        {
            sl = 0;
            textBox1.Clear();
            textBox2.Clear();
            textBox5.Clear();
            textBox3.Clear();

            textBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (sl > 0)
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM addSTUDENT Where SL = @sl", conn);
                cmd.CommandType = CommandType.Text;
               
                
                cmd.Parameters.AddWithValue("@sl", this.sl);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox5.Text = "";
                textBox3.Text = "";
                MessageBox.Show("Student is deleted from the system", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                displayData();
                ResetformControls();
            }
            else
            {
                MessageBox.Show("Please select a student to delete", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
       
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            sl = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(sl > 0)
            {
                SqlCommand cmd = new SqlCommand("UPDATE addSTUDENT SET USERNAME = @username, PASS = @pass, ID = @id, DEPARTMENT = @department Where SL = @sl", conn);
                cmd.CommandType = CommandType.Text;
             
                cmd.Parameters.AddWithValue("@username", textBox1.Text);
                cmd.Parameters.AddWithValue("@pass", textBox2.Text);
                cmd.Parameters.AddWithValue("@id", textBox5.Text);
                cmd.Parameters.AddWithValue("@department", textBox3.Text);
                cmd.Parameters.AddWithValue("@sl", this.sl);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox5.Text = "";
                textBox3.Text = "";
                MessageBox.Show("Updation Successful", "updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                displayData();
                ResetformControls();
            }
            else
            {
                MessageBox.Show("Please select a student to update","Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 
            }
        }

        private void AddStd_Load(object sender, EventArgs e)
        {

        }
    }
}
