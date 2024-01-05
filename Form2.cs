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
    public partial class Form2 : Form
    {
        MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;database=launch");
        public Form2()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
           

            Form2 f = new Form2();
            f.Show();
            f.Refresh();
            this.Hide();
            
         

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string selectquery = "SELECT * FROM view_pass";
            DataTable t = new DataTable();
            MySqlDataAdapter d = new MySqlDataAdapter(selectquery, con);
            d.Fill(t);
            dataGridView1.DataSource = t;
            con.Close();



            try
            {

                string selectQuery = "SELECT * FROM launch.launch_time";
                con.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, con);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox3.Items.Add(reader.GetString("Launch_name"));
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
                    comboBox1.Items.Add(reader.GetString("Cabin_class"));
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }





        }

        private void button6_Click(object sender, EventArgs e)
        {
            con.Open();
            string cmd = "delete from view_pass where Ticket_ID = '" + textBox3.Text + "'";
            MySqlDataAdapter md = new MySqlDataAdapter(cmd , con);
            md.SelectCommand.ExecuteNonQuery();
            con.Close();

           


            MessageBox.Show("Delete Successfully");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 fh= new Form4();
            fh.Show();
           this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            // Delete ticket
            con.Open();
            string cmd = "delete from view_pass where Ticket_ID = '" + textBox3.Text + "'";
            MySqlDataAdapter md = new MySqlDataAdapter(cmd, con);
            md.SelectCommand.ExecuteNonQuery();
            con.Close();

            // Update Available Seat
            con.Open();
            string query = "UPDATE cabin_list SET Available_seat= Available_seat + '" + comboBox2.Text + "' WHERE Cabin_class='" + comboBox1.Text + "'";
            MySqlDataAdapter d = new MySqlDataAdapter(query, con);
            d.SelectCommand.ExecuteNonQuery();
            con.Close();

            //Update Record
           
            con.Open();
           
            string que = "UPDATE record SET Total_seat= Total_seat-'" + comboBox2.Text + "',Total_taka=Total_taka-'" + textBox1.Text + "'   WHERE Date='" + this.dateTimePicker1.Text + "' && Launch='" + comboBox3.Text + "' && Cabin= '" + comboBox1.Text + "'";
            MySqlDataAdapter d1 = new MySqlDataAdapter(que, con);
            d1.SelectCommand.ExecuteNonQuery();
            con.Close();




            MessageBox.Show("Delete Successfully");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form4 fh = new Form4();
            fh.Show();
            this.Close();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
            f.Refresh();
            this.Hide();
        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
