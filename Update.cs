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
    public partial class Update : Form
    {
        public Update()
        {
            InitializeComponent();

        }

        MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;database=launch");

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 fh = new Form4();
            fh.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "UPDATE launch_time SET Dep_time='" + textBox1.Text + "', Arr_time =  '" + textBox2.Text + "', Fare_range='" + textBox3.Text + "' WHERE Launch_name='" + comboBox1.Text + "'";
            MySqlDataAdapter cmd = new MySqlDataAdapter(query, con);
            cmd.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Updated Successfully");


            comboBox1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            MySqlCommand c = new MySqlCommand("INSERT INTO launch_time(Launch_name,Dep_time,Arr_time,Fare_range) VALUES ('" + comboBox1.Text + "','" + textBox1.Text+ "','" + textBox2.Text + "','" + textBox3.Text + "')", con);

            c.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Added Successfully");

            comboBox1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            string cmd = "delete from launch_time where Launch_name ='" + comboBox1.Text + "'";
            MySqlDataAdapter md = new MySqlDataAdapter(cmd, con);
            md.SelectCommand.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Delete Successfully");

            comboBox1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            updateseat f = new updateseat();
            f.Show();
            this.Hide();
        }

        private void Update_Load(object sender, EventArgs e)
        {
            try
            {

                string selectQuery = "SELECT * FROM launch.launch_time";
                con.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, con);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader.GetString("Launch_name"));
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
           launchupdated f = new launchupdated();
            f.Show();
            this.Hide();
        }
    }
}
