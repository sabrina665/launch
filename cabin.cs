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
    public partial class cabin : Form
    {
        public cabin()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;database=launch");
        private void groupBox2_Enter(object sender, EventArgs e)
        {
            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void r_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Form6 f = new Form6();
            f.Show();
            this.Hide();

           
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void cabin_Load(object sender, EventArgs e)
        {
            string selectquery = "SELECT * FROM cabin_list";
            DataTable t = new DataTable();
            MySqlDataAdapter d = new MySqlDataAdapter(selectquery, con);
            d.Fill(t);
            dataGridView1.DataSource = t;

         
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            


        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           

            
           
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

      
      
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
           



          
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Show();
            this.Close();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
