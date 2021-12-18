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
using System.Net.Mail;
using System.Net;
using System.IO;

namespace University_Bookstore
{
    public partial class StdForm : Form
    {
        string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
        public int sl;
        public int p;
        SqlConnection con = new SqlConnection(St.connection);
        public StdForm()
        {
            InitializeComponent();
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "BOOK-NAME";
            dataGridView1.Columns[1].Name = "QUANTITY";
            dataGridView1.Columns[2].Name = "PRICE";

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

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
            dataGridView4.DataSource = dt;
            con.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            StdLogin stdLogin = new StdLogin();
            stdLogin.Tag = this;
            stdLogin.Show();
            Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            StdLogin stdLogin = new StdLogin();
            stdLogin.Tag = this;
            stdLogin.Show();
            Hide();
        }

        private void StdForm_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            /*if (textBox1.Text == "")
            {
                button3.Enabled = false;
            }
            else
            {
                button3.Enabled = true;
            }*/

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            //textBox1.Enabled = false;
            displayData();
            if (textBox1.Text == "")
            {
                button3.Enabled = false;
            }
            else
            {
                button3.Enabled = true;

            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private bool qCheck()
        {

          
            if (int.Parse(textBox3.Text) < int.Parse(textBox5.Text) || int.Parse(textBox5.Text) == 0)
            {


                MessageBox.Show("Out of stock");
                return false;
            }
            return true;
        }
        private bool Isvalid()
        {
            if ( textBox2.Text == String.Empty ||  textBox5.Text == String.Empty || textBox4.Text == String.Empty)
            {
                MessageBox.Show("Select all the information", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        int mul;
        int dif;

        private void button2_Click(object sender, EventArgs e)
        {
          string email = textBox1.Text;
        textBox1.Enabled = false;

            if (Isvalid() && qCheck())
            {
                mul = int.Parse(textBox5.Text) * int.Parse(textBox4.Text);
                dataGridView1.Rows.Add(textBox2.Text, textBox5.Text, this.mul);
               
                MessageBox.Show("Added to cart", "Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Enabled = true;
                dif = int.Parse(textBox3.Text) - int.Parse(textBox5.Text);
                if (sl > 0)
                {
                    if (dif > 0)
                    {
                        SqlCommand cmd = new SqlCommand("UPDATE addBook SET QUANTITY= @quantity where BOOK_SL =@bSl", con);
                        cmd.Parameters.AddWithValue("@quantity", this.dif);
                        cmd.Parameters.AddWithValue("@bSl", this.sl);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        displayData();
                        reset();
                    }
                    else if (dif == 0)
                    {
                        SqlCommand cmd = new SqlCommand("DELETE from addBook  where BOOK_SL =@bSl", con);
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("@bSl", this.sl);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        displayData();
                        reset();
                    }



                }
                int sum = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);
                }
                label5.Text = sum.ToString();

            }
            else
            {
                textBox1.Enabled = false;
            }
            
        }

       // int sl = 0;
        public void reset()
        {
           
            sl = 0;
            //textBox1.Clear();
            textBox2.Clear();
            textBox5.Clear();
            textBox4.Clear();
            textBox3.Clear();
            //comboBox1.Text = "Select Category";
            //textBox1.Focus();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            reset();
        }


     

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
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
                errorProvider2.SetError(this.textBox1, " Invalid email ");
            }
            else
            {
                errorProvider2.Clear();
            }
        }
        
         public static void Email(string email)
         {
            try
            {

                MailMessage message = new MailMessage();

                message.From = new MailAddress("ubookstore21@gmail.com");
                message.To.Add(email);
                message.Subject = "Book Purchase Confirmation";
                //message.IsBodyHtml = true; //to make message body as html


                message.Body = "Dear Student, We are pleased to share that the book(s) you purchased has been confirmed. Thank you for ordering from us!"; //Email Body
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com"; //for gmail host
                System.Net.NetworkCredential xyz = new NetworkCredential();
                xyz.UserName = "ubookstore21@gmail.com";
                xyz.Password = "ProjectC#";
                //smtp.Credentials = new NetworkCredential("ubookstore21@gmail.com", "ProjectC#");
                //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = xyz;
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.Send(message);
                MessageBox.Show("Please check your email");
                

            }
            catch (Exception)
            {
                MessageBox.Show("invalid email");
            }
            
                

            
            
          
          }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                sl = Convert.ToInt32(dataGridView4.SelectedRows[0].Cells[0].Value);
                textBox2.Text = dataGridView4.SelectedRows[0].Cells[1].Value.ToString();
                textBox4.Text = dataGridView4.SelectedRows[0].Cells[5].Value.ToString();
                textBox3.Text = dataGridView4.SelectedRows[0].Cells[4].Value.ToString();
            }
           
            catch
            {
                MessageBox.Show("Select properly", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
                reset();
            }
        }
        
        int  prodqty, prodprice,  pos = 60;

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;


            }
        }

        string podname;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("UNIVERSITY BOOKSTORE", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Red, new Point(50));
            e.Graphics.DrawString("PRODUCT  PRICE  QUANTITY ", new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Red, new Point(26, 40));
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // prodid = Convert.ToInt32(row.Cells["Column1"].Value);
                podname = "" + row.Cells["BOOK-NAME"].Value;
                prodprice = Convert.ToInt32(row.Cells["PRICE"].Value);
                prodqty = Convert.ToInt32(row.Cells["QUANTITY"].Value);
                // tottal = Convert.ToInt32(row.Cells["Column5"].Value);
                //e.Graphics.DrawString("" + prodid, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(26, pos));
                e.Graphics.DrawString("" + podname, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(45, pos));
                e.Graphics.DrawString("" + prodprice, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(110, pos));
                e.Graphics.DrawString("" + prodqty, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(160, pos));
                //e.Graphics.DrawString("" + tottal, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(235, pos));
                pos += 20;
            }
            e.Graphics.DrawString("Grand Total : " + label5.Text + " " + " Tk", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Crimson, new Point(26, pos + 50));
            e.Graphics.DrawString("***********THANK YOU***********", new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Crimson, new Point(40, pos + 85));
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            pos = 100;
            //Grdtotal = 0;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            


                string email = textBox1.Text;
                Email(email);
                printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 285, 600);
                if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
                {
                    

                    printDocument1.Print();
                }

            
            
        }
    }
}
