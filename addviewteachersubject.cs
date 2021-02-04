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
    public partial class addviewteachersubject : Form
    {

        MySqlConnection conn;
        //MySqlDataAdapter adapter;
        MySqlCommand cmd;
        public int rownum;

        public addviewteachersubject()
        {
            InitializeComponent();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string t1 = ComboBox1.Text;


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
                MySqlCommand m = new MySqlCommand("SELECT * from student_record.subject_information where subject_code = '" + t1 + "'", conn);
                dr2 = m.ExecuteReader();
                if (dr2.Read())
                {
                    textBox6.Text = dr2.GetString("subject_desc");
                    textBox7.Text = dr2.GetInt32("subject_unit").ToString();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            conn.Close();
            conn.Dispose();

        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (ComboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose a subject code!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {

                string subj_code = ComboBox1.Text;
                string subj_desc = textBox6.Text;
                int subj_unit = int.Parse(textBox7.Text);
                Boolean naana = false;

                int i = 0;
                while (i < dataGridView1.RowCount)
                {
                    if (subj_code == dataGridView1.Rows[i].Cells[0].Value.ToString())
                    {
                        naana = true;
                    }
                    i++;
                }

                if (naana == true)
                {
                    MessageBox.Show("Subject Already Added!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    dataGridView1.Rows.Add(subj_code, subj_desc, subj_unit);
                    
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
                string connStr3 = "server=localhost;database=student_record;user=root;password=;";
                conn = new MySqlConnection(connStr3);
                string s3;

                try
                {


                    conn.Open();



                    s3 = "DELETE from adding_teachersubj where t_id = '" + textBox8.Text + "'";
                    cmd = new MySqlCommand(s3, conn);
                    cmd.ExecuteNonQuery();
                  
                    conn.Close();
                    conn.Dispose();
                }
                catch (Exception ex)
                {
                    //textBox14.Clear();
                    MessageBox.Show(ex.Message);
                }

                conn.Close();
                conn.Dispose();


                DialogResult d = new DialogResult();
                d = MessageBox.Show("Are you sure you want to save the following changes to teacher "  + TextBox1.Text + " " + TextBox2.Text + " " + TextBox3.Text + "?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (d.ToString() == "Yes")
                {

                    int j = 0;

                    while (j < dataGridView1.RowCount)
                    {


                        string s4;

                        try
                        {
                            conn.Open();
                            s4 = "INSERT INTO adding_teachersubj VALUES('" + textBox8.Text + "','" + dataGridView1.Rows[j].Cells[0].Value.ToString() + "','" + dataGridView1.Rows[j].Cells[1].Value.ToString() + "','" + dataGridView1.Rows[j].Cells[2].Value.ToString() + "')";
                            cmd = new MySqlCommand(s4, conn);
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            conn.Dispose();
                        }
                        catch (Exception ex)
                        {
                        }

                        conn.Close();
                        conn.Dispose();

                        j++;
                    }

                    MessageBox.Show("Subjects Successfully Assigned!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ComboBox1.SelectedIndex = -1;
                    textBox6.Clear();
                    textBox7.Clear();
                    
                }

                else
                {

                }
                    



            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Boolean nibasa = false;
            foreach (DataGridViewRow dgvr in dataGridView1.Rows)
            {
                if (dgvr.Selected == true)
                {
                    dataGridView1.Rows.Remove(dgvr);
                    nibasa = true;
                }
              
            }
            if (nibasa == false)
            {
                MessageBox.Show("Please choose a subject to remove!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Subject successfully remove!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            }
        }

        private void addviewteachersubject_Load(object sender, EventArgs e)
        {
            rownum = dataGridView1.RowCount;
        }
    }
}
