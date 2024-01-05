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
    public partial class endstep : Form
    {
        public endstep()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;database=launch");
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void endstep_Load(object sender, EventArgs e)
        {

         
            if(textBox1.Text == "")
            {

                string selectquery = "SELECT * FROM view_pass";

                DataTable t = new DataTable();
                MySqlDataAdapter d = new MySqlDataAdapter(selectquery, con);
                d.Fill(t);
                dataGridView1.DataSource = t;

            }

            else
            {
                string select = "SELECT * FROM view_pass Where Ticket_ID='" + textBox1.Text + "'";

                DataTable tt = new DataTable();
                MySqlDataAdapter dd = new MySqlDataAdapter(select, con);
                dd.Fill(tt);
                dataGridView1.DataSource = tt;


            }

         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            f.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
