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
    public partial class Form4 : Form
    {
        int x = 255, y = 1;

        public Form4()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;database=launch");
        private void button3_Click(object sender, EventArgs e)
        {
            endstep j = new endstep();
            j.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Record f = new Record();
            f.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
            this.Hide();

        }

        

        private void button5_Click(object sender, EventArgs e)
        {
            Update f = new Update();
            f.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.SetBounds(x, y, 1, 1);
            x++;
            if (x > 800)
            {
                x = 1;
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {

            label1.Text = "Welcome To Launch Management System";
            //label1.Font = new Font(" ", 25,  FontStyle.Underline );

            timer1.Interval = 1;
            timer1.Start();
        }
    }
}
