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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;database=launch");
        private void Form3_Load(object sender, EventArgs e)
        {
            string selectquery = "SELECT * FROM launch_time";
            DataTable t = new DataTable();
            MySqlDataAdapter d = new MySqlDataAdapter(selectquery, con);
            d.Fill(t);
            dataGridView1.DataSource = t;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            


        }

        

        private void button1_Click_1(object sender, EventArgs e)
        {
            cabin f = new cabin();
            f.Show();
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            f.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
