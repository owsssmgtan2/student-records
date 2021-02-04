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
    public partial class viewclient : Form
    {

        MySqlConnection conn;
        //MySqlDataAdapter adapter;
        public string pass;

        MySqlCommand cmd;

        public viewclient()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

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
            string pfname = textBox10.Text;
            string pmname = textBox9.Text;
            string plname = textBox8.Text;
            string prelationship = comboBox2.Text;
            string pcontact = textBox11.Text;
            string address = RichTextBox1.Text;

            d = MessageBox.Show("Are you sure you want to update " + fname +" "+ mname +" "+ lname + " Student Information?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (d.ToString() == "Yes")
            {
                TextBox1.ReadOnly = false;
                TextBox2.ReadOnly = false;
                TextBox3.ReadOnly = false;
                TextBox4.ReadOnly = false;
                TextBox5.ReadOnly = false;
                textBox6.ReadOnly = false;
                textBox7.ReadOnly = false;
                textBox8.ReadOnly = false;
                textBox9.ReadOnly = false;
                textBox10.ReadOnly = false;
                textBox11.ReadOnly = false;
                textBox12.ReadOnly = false;
                TextBox13.ReadOnly = false;
                // textBox14.ReadOnly = false;
                ComboBox1.Enabled = true;
                comboBox2.Enabled = true;
                comboBox3.Enabled = true;
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
            string pfname = textBox10.Text;
            string pmname = textBox9.Text;
            string plname = textBox8.Text;
            string prelationship = comboBox2.Text;
            string pcontact = textBox11.Text;
            string address = RichTextBox1.Text;

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
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            conn.Close();
            conn.Dispose();
    


            if ((string.IsNullOrEmpty(fname) || string.IsNullOrWhiteSpace(mname)) || (string.IsNullOrEmpty(lname) || string.IsNullOrWhiteSpace(lname)) || (string.IsNullOrEmpty(placeofbirth) || string.IsNullOrWhiteSpace(placeofbirth)) || (string.IsNullOrEmpty(contact) || string.IsNullOrWhiteSpace(contact)) || (string.IsNullOrEmpty(email) || string.IsNullOrWhiteSpace(email)) || (string.IsNullOrEmpty(pfname) || string.IsNullOrWhiteSpace(pfname)) || (string.IsNullOrEmpty(plname) || string.IsNullOrWhiteSpace(plname)) || (string.IsNullOrEmpty(pcontact) || string.IsNullOrWhiteSpace(pcontact)) || (string.IsNullOrEmpty(address) || string.IsNullOrWhiteSpace(address)))
                {
                    MessageBox.Show("Please fill in all fields!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (ComboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1 || comboBox3.SelectedIndex == -1 || comboBox4.SelectedIndex == -1)
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



                                       
                                        string s3;

                                        try
                                        {


                                            conn.Open();
                                            s3 = "UPDATE student_registration SET stud_yearofentry = '"+ textBox12.Text +"', stud_fname = '" + fname + "', stud_mname = '" + mname + "', stud_lname = '" + lname + "', stud_sex = '" + sex + "', stud_dateofbirth = '" + dateofbirth + "', stud_placeofbirth = '" + placeofbirth + "', stud_citizenship = '" + citizenship + "',stud_civilstatus = '" + civilstatus + "',stud_age = '" + TextBox13.Text + "',stud_contact = '" + contact + "', stud_email = '" + email + "',stud_pfname = '" + pfname + "',stud_pmname = '" + pmname + "',stud_plname = '" + plname + "',stud_prelationship = '" + prelationship + "',stud_pcontact = '" + pcontact + "',stud_address = '" + address + "',stud_department = '"+ comboBox3.Text +"',stud_program = '"+ comboBox4.Text +"'";
                                            cmd = new MySqlCommand(s3, conn);
                                            cmd.ExecuteNonQuery();
                                            MessageBox.Show("Student "+ fname + " " + mname + " " +lname +  ". Successfully Registered!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        public void cleartext()
        {
            TextBox1.Clear();
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
            string pfname = textBox10.Text;
            string pmname = textBox9.Text;
            string plname = textBox8.Text;
            string prelationship = comboBox2.Text;
            string pcontact = textBox11.Text;
            string address = RichTextBox1.Text;
            
            d = MessageBox.Show("Are you sure you want to delete " + fname + " " + mname + " " + lname + " Student Information?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (d.ToString() == "Yes")
            {
                deleteKey ddd = new deleteKey(panel2);
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
            addViewSubject r = new addViewSubject();
            r.TextBox1.Text = TextBox1.Text;
            r.TextBox2.Text = TextBox2.Text;
            r.TextBox3.Text = TextBox3.Text;
            r.textBox4.Text = comboBox3.Text;
            r.textBox5.Text = comboBox4.Text;
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
    

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Enabled = true;
            comboBox4.Text = "";

            comboBox4.Items.Clear();
            if (comboBox3.Text == "CTET")
            {
                comboBox4.Items.Add("BEED");
                comboBox4.Items.Add("BSED-ENG");
                comboBox4.Items.Add("BSED-MATH");
                comboBox4.Items.Add("BSIT");

            }
            else if (comboBox3.Text == "CARS")
            {
                comboBox4.Items.Add("BSAE");
                comboBox4.Items.Add("BSF");
                comboBox4.Items.Add("BSA-EM");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TextBox1.ReadOnly = true;
            TextBox2.ReadOnly = true;
            TextBox3.ReadOnly = true;
            TextBox4.ReadOnly = true;
            TextBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox7.ReadOnly = true;
            textBox8.ReadOnly = true;
            textBox9.ReadOnly = true;
            textBox10.ReadOnly = true;
            textBox11.ReadOnly = true;
            textBox12.ReadOnly = true;
            TextBox13.ReadOnly = true;
            // textBox14.ReadOnly = false;
            ComboBox1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            DateTimePicker1.Enabled = false;
            button1.Visible = false;
            button2.Visible = false;

        }



        }
    }

