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
        SqlConnection conn= new SqlConnection(St.connection);
        
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
           
          if (Isvalid())
           {
               conn.Open();
               SqlDataAdapter da = new SqlDataAdapter("Select ID from addSTUDENT where ID ='" + textBox5.Text + "'", conn);
               DataTable dt = new DataTable();
               da.Fill(dt);
               conn.Close();
               if (dt.Rows.Count >= 1)
               {
                   MessageBox.Show("Same Student ID Exists");


               }
               else
               {
                   conn.Open();
                   SqlCommand cmd = conn.CreateCommand();
                   cmd.CommandType = CommandType.Text;
                   cmd.CommandText = "INSERT INTO addSTUDENT VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox5.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "')";
                   cmd.ExecuteNonQuery();
                   conn.Close();
                   displayData();
                   ResetformControls();
                   MessageBox.Show("Insertion Successful", "Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
               }

           }

           
        }

        private bool IsValid()
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("UserName is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (textBox2.Text == string.Empty)
            {
                MessageBox.Show("Password is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (textBox5.Text == string.Empty)
            {
                MessageBox.Show("ID is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (comboBox1.Text == string.Empty)
            {
                MessageBox.Show("Department is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (comboBox2.Text == string.Empty)
            {
                MessageBox.Show("Gender is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            search();
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
            textBox3.Clear();
            textBox5.Clear();
            comboBox1.Text = "Select Department";
            comboBox2.Text = "Select Gender";

            textBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Isvalid())
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
                    comboBox1.Text = "";
                    comboBox2.Text = "";
                    MessageBox.Show("Student is deleted from the system", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    displayData();
                    ResetformControls();
                }
                else
                {
                    MessageBox.Show("Please select a student to delete", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
       
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                sl = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox5.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                comboBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                comboBox2.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            }
          
            catch
            {
                MessageBox.Show("Select properly", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetformControls();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (Isvalid())
            {
                if (sl > 0)
                {
                    SqlCommand cmd = new SqlCommand("UPDATE addSTUDENT SET USERNAME = @username, PASS = @pass, ID = @id, DEPARTMENT = @department, GENDER = @gender Where SL = @sl", conn);
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@username", textBox1.Text);
                    cmd.Parameters.AddWithValue("@pass", textBox2.Text);
                    cmd.Parameters.AddWithValue("@id", textBox5.Text);
                    cmd.Parameters.AddWithValue("@department", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@gender", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@sl", this.sl);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox5.Text = "";
                    comboBox1.Text = "";
                    comboBox2.Text = "";
                    MessageBox.Show("Updation Successful", "updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    displayData();
                    ResetformControls();
                }
                else
                {
                    MessageBox.Show("Please select a student to update", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private bool Isvalid()
        {
            if (textBox1.Text == String.Empty || textBox2.Text == String.Empty  || textBox5.Text == String.Empty || comboBox1.Text == "Select Department" || comboBox2.Text == "Select Gender")
            {
                MessageBox.Show("Fill all the information", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void AddStd_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void search()
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from addSTUDENT where ID like'" + this.textBox3.Text + "%'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            search();
        }
        
    }
}
