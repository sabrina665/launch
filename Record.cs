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
    public partial class Record : Form
    {
        public Record()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;database=launch");


        private void Record_Load(object sender, EventArgs e)
        {


            try
            {

                string selectQuery = "SELECT * FROM launch.launch_time";
                con.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, con);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox2.Items.Add(reader.GetString("Launch_name"));
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



            try
            {

                string selectQuery = "SELECT * FROM launch.cabin_list";
                con.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, con);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox3.Items.Add(reader.GetString("Cabin_class"));
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 fh = new Form4();
            fh.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Search
            if(comboBox2.Text=="" && comboBox3.Text=="")
            {
                string selectquery = "SELECT * FROM record WHERE Date='" + this.dateTimePicker1.Text + "'";
                DataTable t1 = new DataTable();
                MySqlDataAdapter d1 = new MySqlDataAdapter(selectquery, con);
                d1.Fill(t1);
                dataGridView1.DataSource = t1;

            }
            else if(comboBox3.Text=="")
            {
                string selectquery = "SELECT * FROM record WHERE Date='" + this.dateTimePicker1.Text + "' && Launch='" + comboBox2.Text + "'";
                DataTable t2 = new DataTable();
                MySqlDataAdapter d2 = new MySqlDataAdapter(selectquery, con);
                d2.Fill(t2);
                dataGridView1.DataSource = t2;
            }
            else
            {
                string selectquery1 = "SELECT * FROM record WHERE Date='" + this.dateTimePicker1.Text + "' && Launch='" + comboBox2.Text + "' && Cabin='" + comboBox3.Text + "'";
                DataTable t3 = new DataTable();
                MySqlDataAdapter d3 = new MySqlDataAdapter(selectquery1, con);
                d3.Fill(t3);
                dataGridView1.DataSource = t3;
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
