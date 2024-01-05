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
    public partial class launchupdated : Form
    {
        public launchupdated()
        {
            InitializeComponent();
        }

        MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;database=launch");

        private void launchupdated_Load(object sender, EventArgs e)
        {
            string selectquery = "SELECT * FROM launch_time";
            DataTable t = new DataTable();
            MySqlDataAdapter d = new MySqlDataAdapter(selectquery, con);
            d.Fill(t);
            dataGridView1.DataSource = t;
        }

       

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form4 fh = new Form4();
            fh.Show();
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Update fh = new Update();
            fh.Show();
            this.Close();
        }
    }
}
