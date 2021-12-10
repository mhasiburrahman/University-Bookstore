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

    

    public partial class AddBooks : Form
    {
        //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\KAKON\Desktop\University-Bookstore\AdminDB\AdminloginDB.mdf;Integrated Security=True;Connect Timeout=30");
        //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\KAKON\Desktop\University-Bookstore\AdminDB\AdminloginDB.mdf;Integrated Security=True;Connect Timeout=30");
        //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\prott\Desktop\University-Bookstore\AdminDB\AdminloginDB.mdf;Integrated Security=True;Connect Timeout=30");
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MAHIM SARKAR\Desktop\University-Bookstore\AdminDB\AdminloginDB.mdf;Integrated Security=True;Connect Timeout=30");
        public int sl;
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
            if (sl > 0)
            {
                SqlCommand cmd = new SqlCommand("DELETE from addBook  where BOOK_SL =@bSl", con);
                cmd.CommandType = CommandType.Text;
          
                cmd.Parameters.AddWithValue("@bSl", this.sl);
                //cmd.CommandText = "Update  addBook set BOOKNAME='" + textBox1.Text + ",WRITER='"+textBox2.Text+ ",CATEGORY='"+comboBox1.Text+ ",QUANTITY='" + textBox4.Text + "',PRICE='" + textBox3.Text + "' where ID='"+this.sl+"'";
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("infomartion Deleted", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                displayData();
                reset();

            }
            else
            {
                MessageBox.Show("Select to Delete", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
       public void displayData()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM addBook";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
       private bool Isvalid()
        {
            if (textBox1.Text == String.Empty || textBox2.Text == String.Empty || comboBox1.Text == "Select Category" || textBox3.Text == String.Empty || textBox4.Text == String.Empty)
            {
                MessageBox.Show("Fill all the information", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (Isvalid())
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO addBook VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "','" + textBox4.Text + "','" + textBox3.Text + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                displayData();
                reset();
                MessageBox.Show("BOOK ADDED");
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            displayData();
        }
        public void reset()
        {
            sl = 0;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.Text = "Select Category";
            textBox1.Focus();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            reset();
        }

       
        

        private void button1_Click(object sender, EventArgs e)
        {
            if (sl > 0)
            {
               
                SqlCommand cmd = new SqlCommand("UPDATE addBook SET BOOKNAME = @bookname,WRITER = @writer,CATEGORY=@category,QUANTITY= @quantity, PRICE = @price where BOOK_SL =@bSl", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@bookname", textBox1.Text);
                cmd.Parameters.AddWithValue("@writer", textBox2.Text);
                cmd.Parameters.AddWithValue("@category", comboBox1.Text);
                cmd.Parameters.AddWithValue("@quantity", textBox4.Text);
                cmd.Parameters.AddWithValue("@price", textBox3.Text);
                cmd.Parameters.AddWithValue("@bSl", this.sl);
                //cmd.CommandText = "Update  addBook set BOOKNAME='" + textBox1.Text + ",WRITER='"+textBox2.Text+ ",CATEGORY='"+comboBox1.Text+ ",QUANTITY='" + textBox4.Text + "',PRICE='" + textBox3.Text + "' where ID='"+this.sl+"'";
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Information Updated", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                displayData();
                reset();
            }
            else
            {
                MessageBox.Show("Select to updated", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

     

  

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            sl = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void AddBooks_Load(object sender, EventArgs e)
        {
            displayData();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
