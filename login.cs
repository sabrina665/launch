using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Launch_Management
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            string pass = textBox2.Text;
            MySqlConnection connection = new MySqlConnection(@"server=localhost;user id=root;database=launch");
            MySqlDataAdapter sda = new MySqlDataAdapter("select count(*) from user_info where User_Name = '" + textBox1.Text + "' and Password = '" + textBox2.Text + "'", connection);
            DataTable t = new DataTable();
            sda.Fill(t);

            if (t.Rows[0][0].ToString() == "1")
            {
                Form4 f100 = new Form4();
                f100.Show();
                this.Hide();
                ;
            }
            else
            {
                MessageBox.Show("Wrong User Name & Password.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
