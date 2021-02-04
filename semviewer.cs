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
using MySql.Data;


namespace Student_Record_System
{
    public partial class semviewer : Form
    {

        MySqlConnection conn;
        //MySqlDataAdapter adapter;
        MySqlCommand cmd;

        public semviewer()
        {
            InitializeComponent();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox8.Text = (int.Parse(ComboBox1.Text) + 1).ToString();
 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string t1 = ComboBox1.Text;
            Boolean naa = false;

            if (ComboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose a semester to search", "Warning", MessageBoxButtons.OK, MessageBoxIcon.None);

            }

            else
            {
                label4.Visible = true;
                button2.Visible = true;
                string connStr3 = "server=localhost;database=student_record;user=root;password=;";
                conn = new MySqlConnection(connStr3);


                MySqlDataReader dr2;

                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();

                }

                try
                {

                    conn.Open();
                    MySqlCommand m = new MySqlCommand("SELECT * from student_registration,adding_subject where addsubj_fromyear = '" + t1 + "' and addsubj_toyear = '" + textBox8.Text + "' GROUP BY student_registration.stud_id", conn);
                    dr2 = m.ExecuteReader();
                    dataGridView1.Rows.Clear();
                    while (dr2.Read())
                    {
                        naa = true;
                        dataGridView1.Rows.Add(dr2.GetString("stud_id"), dr2.GetString("stud_lname"), dr2.GetString("stud_fname"), dr2.GetString("stud_mname"), dr2.GetString("stud_sex"), dr2.GetString("stud_department"), dr2.GetString("stud_program"));
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                conn.Close();
                conn.Dispose();

                if (naa == false)
                {
                    MessageBox.Show("No record for this semester!", "No Result", MessageBoxButtons.OK, MessageBoxIcon.None);

                }


            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string t1 = comboBox2.Text;
            Boolean naa = false;

            if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose a semester to search", "Warning", MessageBoxButtons.OK, MessageBoxIcon.None);

            }

            else
            {

                string connStr3 = "server=localhost;database=student_record;user=root;password=;";
                conn = new MySqlConnection(connStr3);


                MySqlDataReader dr2;

                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();

                }

                try
                {

                    conn.Open();
                    MySqlCommand m = new MySqlCommand("SELECT * from student_registration,adding_subject where addsubj_fromyear = '" + ComboBox1.Text + "' and addsubj_toyear = '" + textBox8.Text + "' and addsubj_code = '" + t1 + "' and student_registration.stud_id = adding_subject.stud_id GROUP BY student_registration.stud_id", conn);
                    dr2 = m.ExecuteReader();
                    dataGridView1.Rows.Clear();
                    while (dr2.Read())
                    {
                      
                        naa = true;
                        dataGridView1.Rows.Add(dr2.GetString("stud_id"), dr2.GetString("stud_lname"), dr2.GetString("stud_fname"), dr2.GetString("stud_mname"), dr2.GetString("stud_sex"), dr2.GetString("stud_department"), dr2.GetString("stud_program"));
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                conn.Close();
                conn.Dispose();

                if (naa == false)
                {
                    MessageBox.Show("No record for this semester!", "No Result", MessageBoxButtons.OK, MessageBoxIcon.None);

                }


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            comboBox2.Visible = true;
            button1.Visible = true;
            button2.Visible = false;
            button4.Visible = true;

            button5.Enabled = false;
            textBox8.ReadOnly = true;
            ComboBox1.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label3.Visible = false;
            comboBox2.Visible = false;
            button1.Visible = false;
            button2.Visible = true;
            button4.Visible = false;

            button5.Enabled = true;
            textBox8.ReadOnly = false;
            ComboBox1.Enabled = true;
        }
    }
}
