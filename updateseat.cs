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
    public partial class updateseat : Form
    {
        public updateseat()
        {
            InitializeComponent();
        }

        MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;database=launch");

        private void button6_Click(object sender, EventArgs e)
        {
            con.Open();
          
            string query = "UPDATE cabin_list SET Cabin_fare='"+ textBox1.Text +"', Available_seat =  '" + textBox2.Text + "' WHERE Cabin_class='" + comboBox1.Text + "'";
            MySqlDataAdapter cmd = new MySqlDataAdapter(query, con);
            cmd.SelectCommand.ExecuteNonQuery();
            con.Close();


            MessageBox.Show("Updated Successfully");

            comboBox1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            MySqlCommand c = new MySqlCommand("INSERT INTO cabin_list(Cabin_class,Cabin_fare,Available_seat) VALUES ('" +comboBox1.Text+ "','" + textBox1.Text + "','" + textBox2.Text + "')", con);

            c.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Added Successfully");

            comboBox1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            string cmd = "delete from cabin_list where Cabin_class ='" + comboBox1.Text + "'";
            MySqlDataAdapter md = new MySqlDataAdapter(cmd, con);
            md.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Delete Successfully");

            comboBox1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 fh = new Form4();
            fh.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Update f = new Update();
            f.Show();
            this.Hide();
        }

        private void updateseat_Load(object sender, EventArgs e)
        {
            try
            {

                string selectQuery = "SELECT * FROM launch.cabin_list";
                con.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, con);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader.GetString("Cabin_class"));
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cabinupdated f = new cabinupdated();
            f.Show();
            this.Hide();
        }
    }
}
