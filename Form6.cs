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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }


        MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;database=launch");
      

        private void button6_Click(object sender, EventArgs e)
        {

            con.Open();

            int a = int.Parse(comboBox2.Text);

            string Query = "SELECT Available_seat FROM cabin_list WHERE Cabin_class='" + comboBox1.Text + "'";
            MySqlCommand MyCommand2 = new MySqlCommand(Query, con);
            MyCommand2.ExecuteNonQuery();

            Query = MyCommand2.ExecuteScalar().ToString();
            int d = int.Parse(Query);

            con.Close();


            if (a <= d )
            {
                con.Open();
                MySqlCommand c = new MySqlCommand("INSERT INTO view_pass(Ticket_ID, Name, Age, Contact, Sell_Date, launche_Name,From_place,To_place,Travel_Date, Boarding_time, Cabin_class, Seat_NO, TAKA ) VALUES ('" + textBox3.Text + "','" + textBox7.Text + "','" + textBox6.Text + "','" + textBox5.Text + "','" + this.dateTimePicker1.Text + "','" + comboBox4.Text + "','" + comboBox5.Text + "','" + comboBox6.Text + "','" + this.dateTimePicker2.Text + "','" + comboBox3.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + textBox2.Text + "')", con);
                c.ExecuteNonQuery();
                con.Close();

                con.Open();
                string query = "UPDATE cabin_list SET Available_seat= Available_seat - '" + comboBox2.Text + "' WHERE Cabin_class='" + comboBox1.Text + "'";
                MySqlDataAdapter cmdd = new MySqlDataAdapter(query, con);
                cmdd.SelectCommand.ExecuteNonQuery();
                con.Close();


                //Record

                MySqlConnection connection = new MySqlConnection(@"server=localhost;user id=root;database=launch");
                MySqlDataAdapter sda = new MySqlDataAdapter("select count(*) from record where Date = '" + this.dateTimePicker1.Text + "' and Launch = '" + comboBox4.Text + "' and Cabin= '" + comboBox1.Text + "' ", connection);
                DataTable t = new DataTable();
                sda.Fill(t);

                if (t.Rows[0][0].ToString() == "1")
                {
                    con.Open();
                    string query1 = "UPDATE record SET Date='" + this.dateTimePicker1.Text + "',Launch= '" + comboBox4.Text + "',Cabin= '" + comboBox1.Text + "',Total_seat= Total_seat+'" + comboBox2.Text + "',Total_taka=Total_taka+'" + textBox2.Text + "' WHERE Date='" + this.dateTimePicker1.Text + "' && Launch='" + comboBox4.Text + "' && Cabin= '" + comboBox1.Text + "'";
                    MySqlDataAdapter cmd = new MySqlDataAdapter(query1, con);
                    cmd.SelectCommand.ExecuteNonQuery();
                    con.Close();
                }
                else
                {
                    con.Open();
                    MySqlCommand cdd = new MySqlCommand("INSERT INTO record(Date,Launch,Cabin,Total_seat,Total_taka) VALUES ('" + this.dateTimePicker1.Text + "','" + comboBox4.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + textBox2.Text + "')", con);
                    cdd.ExecuteNonQuery();
                    con.Close();
                }

                MessageBox.Show("Succesful", "Message", MessageBoxButtons.OK);

                this.Show();
            }

            else
            {

                MessageBox.Show("Required Seat Not Available", "Message", MessageBoxButtons.OK);
            }


        }




        private void button5_Click(object sender, EventArgs e)
        {
            endstep fh = new endstep();
            fh.Show();
            this.Close();
        }

       

        private void button4_Click(object sender, EventArgs e)
        {
            cabin f = new cabin();
            f.Show();
            this.Hide();
        }
        private void Form6_Load(object sender, EventArgs e)
        {
            MySqlDataAdapter md = new MySqlDataAdapter("SELECT max(cast(Ticket_ID as int))+1 FROM view_pass", con);
            DataTable dt = new DataTable();
            md.Fill(dt);
            textBox3.Text = dt.Rows[0][0].ToString();

            try
            {
               
                string selectQuery = "SELECT * FROM launch.launch_time";
                con.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, con);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox4.Items.Add(reader.GetString("Launch_name"));
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


            try
            {

                string selectQuery = "SELECT * FROM launch.launch_time";
                con.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, con);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox3.Items.Add(reader.GetString("Dep_time"));
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }




    

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal total = Convert.ToInt32(comboBox2.Text) * Convert.ToInt32(textBox1.Text);

            textBox2.Text = total.ToString();

               

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            f.Show();
            this.Close();
        }

        private void printPreview_Load(object sender, EventArgs e)
        {

        }

        private void print_Click(object sender, EventArgs e)
        {
            printPreview.Document = printDocument;
            printPreview.ShowDialog();
        }

        

        private void print_Click_1(object sender, EventArgs e)
        {
            printPreview.Document = printDocument;
            printPreview.ShowDialog();
        }

        private void printDocument_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Launch Management System", new Font("Arial", 42, FontStyle.Regular), Brushes.Black, new Point(25, 25));
            e.Graphics.DrawString("Sadar Ghat Launch Terminal", new Font("Arial", 30, FontStyle.Regular), Brushes.Black, new Point(120, 100));
            e.Graphics.DrawString("Phone : 01900000000,01700000000", new Font("Arial", 25, FontStyle.Regular), Brushes.Black, new Point(110, 150));


           
            e.Graphics.DrawString("Ticket ID           :        " + textBox3.Text, new Font("Arial", 25, FontStyle.Regular), Brushes.Black, new Point(40, 250));
            e.Graphics.DrawString("Passenger Name      :        " + textBox7.Text, new Font("Arial", 25, FontStyle.Regular), Brushes.Black, new Point(40, 300));
            e.Graphics.DrawString("Contact Number      :        " + textBox5.Text, new Font("Arial", 25, FontStyle.Regular), Brushes.Black, new Point(40, 400));

            e.Graphics.DrawString("Launches Name         :       " + comboBox4.Text, new Font("Arial", 25, FontStyle.Regular), Brushes.Black, new Point(40, 450));
           
            e.Graphics.DrawString("Boarding Time       :       " + comboBox3.Text, new Font("Arial", 25, FontStyle.Regular), Brushes.Black, new Point(40, 500));
            e.Graphics.DrawString("Cabin Class         :       " + comboBox1.Text, new Font("Arial", 25, FontStyle.Regular), Brushes.Black, new Point(40, 550));
            e.Graphics.DrawString("Seat NO             :       " + comboBox2.Text, new Font("Arial", 25, FontStyle.Regular), Brushes.Black, new Point(40, 600));
            e.Graphics.DrawString("Taka                :       " + textBox2.Text, new Font("Arial", 25, FontStyle.Regular), Brushes.Black, new Point(40, 650));
            e.Graphics.DrawString("Travel Date                : " + dateTimePicker2.Text, new Font("Arial", 25, FontStyle.Regular), Brushes.Black, new Point(40, 700));
         

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
           

            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}

