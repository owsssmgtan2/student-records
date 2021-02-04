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
    public partial class addViewSubject : Form
    {

        MySqlConnection conn;
        //MySqlDataAdapter adapter;
        MySqlCommand cmd;

        public addViewSubject()
        {
            InitializeComponent();
        }

        private void addViewSubject_Load(object sender, EventArgs e)
        {

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


            if (conn.State == ConnectionState.Open)
            {
                conn.Close();

            }

            try
            {

                conn.Open();
                MySqlCommand m = new MySqlCommand("SELECT * from student_record.adding_teachersubj,student_record.teacher_registration where adding_ts_subj_code = '" + t1 + "' and teacher_registration.t_id = adding_teachersubj.t_id", conn);
                dr2 = m.ExecuteReader();
                comboBox5.Items.Clear();
                comboBox5.Text = "";
                while (dr2.Read())
                {
                    comboBox5.Items.Add(dr2.GetString("t_fname") + " " + dr2.GetString("t_lname"));
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
            string subj_code = ComboBox1.Text;
            string subj_desc = textBox6.Text;
            int subj_unit = int.Parse(textBox7.Text);
            string subj_teacher = comboBox5.Text;
            Boolean naana = false;

            int z = 0;
            int sum = 0;
            while (z < dataGridView1.Rows.Count)
            {
                sum = sum + int.Parse(dataGridView1.Rows[z].Cells[2].Value.ToString());
                z++;
            }

            
                int i = 0;
                while (i < dataGridView1.RowCount )
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

                    if (sum + int.Parse(textBox7.Text) > 24)
                    {
                        MessageBox.Show("No. of units must not be greater than 24", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                    {
                    dataGridView1.Rows.Add(subj_code, subj_desc, subj_unit, subj_teacher);
                    }
                }
        }


        private void button1_Click(object sender, EventArgs e)
        {

            string sem_code = comboBox2.Text + comboBox4.Text + comboBox3.Text;
            
            string connStr3 = "server=localhost;database=student_record;user=root;password=;";
            conn = new MySqlConnection(connStr3);


            MySqlDataReader dr2;
                        if (dataGridView1.RowCount == 0)
                        {
                            MessageBox.Show("Please choose a subject to enrol!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }

                        else
                        {

                            if (comboBox2.Text == comboBox4.Text || (int.Parse(comboBox4.Text) - int.Parse(comboBox2.Text) != 1))
                            {
                                MessageBox.Show("Invalid School Year!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }

                            else
                            {
                                int i = 0;
                                int sum = 0;
                                while (i < dataGridView1.Rows.Count)
                                {
                                    sum = sum + int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                                    i++;
                                }


                                DialogResult d = new DialogResult();
                                d = MessageBox.Show("The total number of units of student " + TextBox1.Text + " " + TextBox2.Text + " " + TextBox3.Text + " is " + sum, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                                if (d.ToString() == "Yes")
                                {


                                    string s3;

                                    try
                                    {


                                        conn.Open();



                                        s3 = "DELETE from adding_subject where sem_code = '" + sem_code + "'";
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







                                    int j = 0;

                                    while (j < dataGridView1.RowCount)
                                    {


                                        string s9;

                                        try
                                        {
                                            conn.Open();
                                            s9 = "INSERT INTO adding_subject VALUES('" + textBox8.Text + "','" + sem_code  + "','" + dataGridView1.Rows[j].Cells[0].Value.ToString() + "','" + dataGridView1.Rows[j].Cells[1].Value.ToString() + "','" + dataGridView1.Rows[j].Cells[2].Value.ToString() + "','" + comboBox2.Text + "','" + comboBox4.Text + "','" + comboBox3.Text + "','" + dataGridView1.Rows[j].Cells[3].Value.ToString() + "')";
                                            cmd = new MySqlCommand(s9, conn);
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

                                    MessageBox.Show("Subjects Successfully Added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    ComboBox1.SelectedIndex = -1;
                                    comboBox2.SelectedIndex = -1;
                                    comboBox3.SelectedIndex = -1;
                                    comboBox4.SelectedIndex = -1;
                                    comboBox5.SelectedIndex = -1;
                                    textBox6.Clear();
                                    textBox7.Clear();
                                //    dataGridView1.Rows.Clear();

                                }

                                else
                                {

                                }
                            }
                        }
             
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Boolean nibasa = false;

            if (dataGridView1.RowCount == 0)
            {
                MessageBox.Show("There is no subject added!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

            else
            {

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
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            Boolean naana = false;
            
            
            if (comboBox3.SelectedIndex == -1 || comboBox2.SelectedIndex == -1 || comboBox4.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose a subject to remove!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
            }
            else
            {


                if (comboBox2.Text == comboBox4.Text || (int.Parse(comboBox4.Text) - int.Parse(comboBox2.Text) != 1))
                {
                    MessageBox.Show("Invalid School Year!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                        MySqlCommand m = new MySqlCommand("SELECT * from student_record.adding_subject where addsubj_fromyear = '" + comboBox2.Text + "' and addsubj_toyear = '" + comboBox4.Text + "' and addsubj_sem = '" + comboBox3.Text + "' and stud_id = '"+ textBox8.Text +"'", conn);
                        dr2 = m.ExecuteReader();
                        dataGridView1.Rows.Clear();
                        while (dr2.Read())
                        {
                            naana = true;
                            dataGridView1.Rows.Add(dr2.GetString("addsubj_code"), dr2.GetString("addsubj_desc"), dr2.GetInt32("addsubj_unit"),dr2.GetString("addsubj_teacher"));
                        }


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    conn.Close();
                    conn.Dispose();

                    if (naana == false)
                    {
                        MessageBox.Show("There is no existing record for this specific school year and semester.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }

                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex != -1 && comboBox3.SelectedIndex != -1)
            {
                ComboBox1.Enabled = true;
                comboBox5.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;

            }
            else
            {
                ComboBox1.Enabled = false;
                comboBox5.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
            }
            try
            {
                int y = int.Parse(comboBox2.Text);
                comboBox4.Text = (y + 1).ToString();
            }
            catch
            { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
    
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex != -1 && comboBox3.SelectedIndex != -1)
            {
                ComboBox1.Enabled = true;
                comboBox5.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;

            }
            else
            {
                ComboBox1.Enabled = false;
                comboBox5.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
            }
        }

    }
}