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
    public partial class StdForm : Form
    {
        public int sl;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\prott\Desktop\University-Bookstore\AdminDB\AdminloginDB.mdf;Integrated Security=True;Connect Timeout=30");
       // SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MAHIM SARKAR\Desktop\University-Bookstore\AdminDB\AdminloginDB.mdf;Integrated Security=True;Connect Timeout=30");
        public StdForm()
        {
            InitializeComponent();
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

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            displayData();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

       // int sl = 0;
        public void reset()
        {
            sl = 0;
            //textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            //comboBox1.Text = "Select Category";
            //textBox1.Focus();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            reset();
        }

        int prodid, prodqty, prodprice, tottal, pos = 60;
       
        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            sl = Convert.ToInt32(dataGridView4.SelectedRows[0].Cells[0].Value);
            textBox2.Text = dataGridView4.SelectedRows[0].Cells[1].Value.ToString();
        }

        string podname;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            /*e.Graphics.DrawString("Book Shop", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Red, new Point(80));
            e.Graphics.DrawString("Id product price quantity total", new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Red, new Point(26, 40));
            foreach (DataGridViewRow row in BillDGV.Rows)
            {
                prodid = Convert.ToInt32(row.Cells["Column1"].Value);
                prodname = "" + row.Cells["Column 2"].Value;
                prodprice = Convert.ToInt32(row.Cells["Column3"].Value);
                prodqty = Convert.ToInt32(row.Cells["Column4"].Value);
                tottal = Convert.ToInt32(row.Cells["Column5"].Value);
                e.Graphics.DrawString("" + prodid, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(26, pos));
                e.Graphics.DrawString("" + prodname, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(45, pos));
                e.Graphics.DrawString("" + prodprice, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(120, pos));
                e.Graphics.DrawString("" + prodqty, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(170, pos));
                e.Graphics.DrawString("" + tottal, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(235, pos));
                pos += 20;
            }
            e.Graphics.DrawString("Grand Total : " + Grdtotal + " Đồng", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Crimson, new Point(26, pos + 50));
            e.Graphics.DrawString("***********Book Store***********", new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Crimson, new Point(40, pos + 85));
            BillDGV.Rows.Clear();
            BillDGV.Refresh();
            pos = 100;
            Grdtotal = 0;*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
            printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 285, 600);
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }
    }
}
