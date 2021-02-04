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

        

    public partial class viewclient2 : Form
    {

        MySqlConnection conn;
        //MySqlDataAdapter adapter;
        MySqlCommand cmd;

        public viewclient2()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult d = new DialogResult();


            string fname = TextBox1.Text;
            string mname = TextBox2.Text;
            string lname = TextBox3.Text;
            string sex;
            string yearofentry = DateTime.Today.ToString("yyyy");
            string dateofbirth = DateTimePicker1.Value.ToString("yyyy-MM-dd");
            string placeofbirth = TextBox4.Text;
            string citizenship = TextBox5.Text;
            string civilstatus = ComboBox1.Text;
            string contact = textBox6.Text;
            string email = textBox7.Text;
            string address = RichTextBox1.Text;

            d = MessageBox.Show("Are you sure you want to update " + fname + " " + mname + " " + lname + " Student Information?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (d.ToString() == "Yes")
            {
                TextBox1.ReadOnly = false;
                TextBox2.ReadOnly = false;
                TextBox3.ReadOnly = false;
                TextBox4.ReadOnly = false;
                TextBox5.ReadOnly = false;
                textBox6.ReadOnly = false;
                textBox7.ReadOnly = false;
                textBox12.ReadOnly = false;
                TextBox13.ReadOnly = false;
                textBox14.ReadOnly = false;
                ComboBox1.Enabled = true;
                DateTimePicker1.Enabled = true;
                button1.Visible = true;
                button2.Visible = true;

            }


            else
            {

            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fname = TextBox1.Text;
            string mname = TextBox2.Text;
            string lname = TextBox3.Text;
            string sex;
            string yearofentry = DateTime.Today.ToString("yyyy");
            string dateofbirth = DateTimePicker1.Value.ToString("yyyy-MM-dd");
            string placeofbirth = TextBox4.Text;
            string citizenship = TextBox5.Text;
            string civilstatus = ComboBox1.Text;
            string contact = textBox6.Text;
            string email = textBox7.Text;
            string address = RichTextBox1.Text;


            if ((string.IsNullOrEmpty(fname) || string.IsNullOrWhiteSpace(mname)) || (string.IsNullOrEmpty(lname) || string.IsNullOrWhiteSpace(lname)) || (string.IsNullOrEmpty(placeofbirth) || string.IsNullOrWhiteSpace(placeofbirth)) || (string.IsNullOrEmpty(contact) || string.IsNullOrWhiteSpace(contact)) || (string.IsNullOrEmpty(email) || string.IsNullOrWhiteSpace(email)) || (string.IsNullOrEmpty(address) || string.IsNullOrWhiteSpace(address)))
            {
                MessageBox.Show("Please fill in all fields!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (ComboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Please fill in all fields!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    if (RadioButton1.Checked == false && RadioButton2.Checked == false)
                    {
                        MessageBox.Show("Please choose a sex!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else
                    {
                        if (dateofbirth == DateTime.Today.ToString("yyyy-MM-dd"))
                        {
                            MessageBox.Show("Invalid date of birth!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                        else
                        {
                            if (email.Contains("@") == false)
                            {
                                MessageBox.Show("Email must contain @!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            }

                            else
                            {
                                if (textBox14.Text == "2016")
                                {
                                    MessageBox.Show("Please choose student number!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                }

                                else
                                {

                                    if (RadioButton1.Checked == true)
                                    {
                                        sex = "Male";
                                    }

                                    else
                                    {
                                        sex = "Female";
                                    }



                                    string connStr3 = "server=localhost;database=student_record;user=root;password=;";
                                    conn = new MySqlConnection(connStr3);
                                    string s3;

                                    try
                                    {


                                        conn.Open();
                                        s3 = "UPDATE teacher_registration SET t_yearofentry = '" + textBox12.Text + "', t_fname = '" + fname + "', t_mname = '" + mname + "', t_lname = '" + lname + "', t_sex = '" + sex + "', t_dateofbirth = '" + dateofbirth + "', t_placeofbirth = '" + placeofbirth + "', t_citizenship = '" + citizenship + "',t_status = '" + civilstatus + "',t_age = '" + TextBox13.Text + "',t_contact = '" + contact + "', t_email = '" + email + "',t_add = '" + address + "'";
                                        cmd = new MySqlCommand(s3, conn);
                                        cmd.ExecuteNonQuery();
                                        MessageBox.Show("Student " + fname + " " + mname + " " + lname + ". Successfully Registered!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);




                                        conn.Close();
                                        conn.Dispose();
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Sa pag update!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        //textBox14.Clear();
                                        MessageBox.Show(ex.Message);
                                    }

                                    conn.Close();
                                    conn.Dispose();



                                }



                            }
                        }
                    }
                }
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {

            DialogResult d = new DialogResult();


            string fname = TextBox1.Text;
            string mname = TextBox2.Text;
            string lname = TextBox3.Text;
            string sex;
            string yearofentry = DateTime.Today.ToString("yyyy");
            string dateofbirth = DateTimePicker1.Value.ToString("yyyy-MM-dd");
            string placeofbirth = TextBox4.Text;
            string citizenship = TextBox5.Text;
            string civilstatus = ComboBox1.Text;
            string contact = textBox6.Text;
            string email = textBox7.Text;
            string address = RichTextBox1.Text;

            d = MessageBox.Show("Are you sure you want to delete " + fname + " " + mname + " " + lname + " Teacher Information?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (d.ToString() == "Yes")
            {
                deleteKey2 ddd = new deleteKey2(panel2);
                ddd.textBox2.Text = textBox14.Text;
                ddd.textBox3.Text = fname;
                ddd.textBox4.Text = mname;
                ddd.textBox5.Text = lname;
                ddd.ShowDialog();

            }


            else
            {

            }

         
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Panel newaddviewsubjectpanel = new Panel();
            panel2.Controls.Clear();
            addviewteachersubject r = new addviewteachersubject();
            r.TextBox1.Text = TextBox1.Text;
            r.TextBox2.Text = TextBox2.Text;
            r.TextBox3.Text = TextBox3.Text;
            r.textBox8.Text = textBox14.Text;
            newaddviewsubjectpanel = r.panel2;
            panel2.Controls.Add(newaddviewsubjectpanel);

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
                MySqlCommand m = new MySqlCommand("SELECT subject_code from student_record.subject_information", conn);
                dr2 = m.ExecuteReader();
                r.ComboBox1.Items.Clear();
                while (dr2.Read())
                {
                    r.ComboBox1.Items.Add(dr2.GetString("subject_code"));
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
                MySqlCommand m = new MySqlCommand("SELECT * from student_record.adding_teachersubj where t_id = '"+ textBox14.Text +"'", conn);
                dr2 = m.ExecuteReader();
                r.dataGridView1.Rows.Clear();
                while (dr2.Read())
                {
                    r.dataGridView1.Rows.Add(dr2.GetString("adding_ts_subj_code"), dr2.GetString("adding_ts_subj_desc"), dr2.GetString("adding_ts_subj_unit"));
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            conn.Close();
            conn.Dispose();



        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            TextBox1.ReadOnly = true;
            TextBox2.ReadOnly = true;
            TextBox3.ReadOnly = true;
            TextBox4.ReadOnly = true;
            TextBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox7.ReadOnly = true;
            textBox12.ReadOnly = true;
            TextBox13.ReadOnly = true;
            textBox14.ReadOnly = true;
            ComboBox1.Enabled = false;
            DateTimePicker1.Enabled = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.panel1.Controls.Clear();

        }
    }
}
