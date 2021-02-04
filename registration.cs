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
    public partial class registration : Form
    {

        MySqlConnection conn;
        //MySqlDataAdapter adapter;
        MySqlCommand cmd;

     
        public registration()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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
            string department = comboBox3.Text;
            string program = comboBox4.Text;
            string id;
            string id2 = "";


            if ((string.IsNullOrEmpty(fname) || string.IsNullOrWhiteSpace(mname)) || (string.IsNullOrEmpty(lname) || string.IsNullOrWhiteSpace(lname)) || (string.IsNullOrEmpty(placeofbirth) || string.IsNullOrWhiteSpace(placeofbirth)) || (string.IsNullOrEmpty(contact) || string.IsNullOrWhiteSpace(contact)) || (string.IsNullOrEmpty(email) || string.IsNullOrWhiteSpace(email)) || (string.IsNullOrEmpty(pfname) || string.IsNullOrWhiteSpace(pfname)) || (string.IsNullOrEmpty(plname) || string.IsNullOrWhiteSpace(plname)) || (string.IsNullOrEmpty(pcontact) || string.IsNullOrWhiteSpace(pcontact)) || (string.IsNullOrEmpty(address) || string.IsNullOrWhiteSpace(address)))
            {
                MessageBox.Show("Please fill in all fields!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (ComboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1 || comboBox3.SelectedIndex == -1 || comboBox4.SelectedIndex == -1 )
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
                                        s3 = "INSERT INTO student_registration VALUES('" + textBox12.Text + "','" + fname + "','" + mname + "','" + lname + "','" + textBox14.Text + "','" + sex + "','" + dateofbirth + "','" + placeofbirth + "','" + citizenship + "','" + civilstatus + "','" + TextBox13.Text + "','" + contact + "','" + email + "','" + pfname + "','" + pmname + "','" + plname + "','" + prelationship + "','" + pcontact + "','" + address + "','Student','"+ department +"','"+ program +"')";
                                        cmd = new MySqlCommand(s3, conn);
                                        cmd.ExecuteNonQuery();
                                        MessageBox.Show("Student " + fname + " " + mname + " " + lname + ". Successfully Registered!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                                        TextBox1.Clear();
                                        TextBox2.Clear();
                                        TextBox3.Clear();
                                        TextBox4.Clear();
                                        TextBox5.Clear();
                                        textBox6.Clear();
                                        textBox7.Clear();
                                        textBox8.Clear();
                                        textBox9.Clear();
                                        textBox10.Clear();
                                        textBox11.Clear();
                                        textBox12.Clear();
                                        TextBox13.Clear();
                                        textBox14.Clear();
                                        ComboBox1.SelectedIndex = -1;
                                        comboBox2.SelectedIndex = -1;
                                        comboBox3.SelectedIndex = -1;
                                        comboBox4.SelectedIndex = -1;
                                        DateTimePicker1.Value = DateTime.Today;
                                        RichTextBox1.Clear();

                                        conn.Close();
                                        conn.Dispose();
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Student number already exist! Please choose another one.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        textBox14.Clear();
                                    }

                                    conn.Close();
                                    conn.Dispose();
                                    
                                    MySqlDataReader dr2;



                                    if (conn.State == ConnectionState.Open)
                                    {
                                        conn.Close();

                                    }


                                    try
                                    {
                                        conn.Open();
                                        MySqlCommand m = new MySqlCommand("SELECT max(stud_id) as l from student_registration", conn);
                                        dr2 = m.ExecuteReader();
                                        if (dr2.Read())
                                        {

                                            if (Convert.IsDBNull(dr2.GetString("l")) == true)
                                            {
                                                id2 = "10000";
                                            }

                                            else
                                            {
                                                id = dr2.GetString("l");
                                                id2 = id.Substring(5);
                                                id2 = (int.Parse(id2) + 1).ToString();
                                            }
                                        }
                                        else
                                        {

                                            id2 = "10000";
                                        }
                                        conn.Close();
                                        conn.Dispose();

                                    }
                                    catch (Exception ex)
                                    {
                                        id2 = "10000";
                                        MessageBox.Show(ex.Message);
                                    }

                                    conn.Close();
                                    conn.Dispose();

                                    textBox14.Text = DateTime.Today.ToString("yyyy") + "-" + id2;
          
            
         



                                }



                            }
                        }
                    }
                }
            }

            }

        private void button2_Click(object sender, EventArgs e)
        {
            TextBox1.Clear();
            TextBox2.Clear();
            TextBox3.Clear();
            TextBox4.Clear();
            TextBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            TextBox13.Clear();
            textBox14.Clear();
            ComboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            DateTimePicker1.Value = DateTime.Today;
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Enabled = true;

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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        IEnumerable<char> CharsToTitleCase(string s)
        {
            bool newWord = true;
            foreach (char c in s)
            {
                if (newWord) { yield return Char.ToUpper(c); newWord = false; }
                else yield return Char.ToLower(c);
                if (c == ' ') newWord = true;
            }
        }

        private void TextBox1_Leave(object sender, EventArgs e)
        {
            string myText = TextBox1.Text;



            TextBox1.Text = new string(CharsToTitleCase(myText).ToArray());
        }

        private void TextBox2_Leave(object sender, EventArgs e)
        {
            string myText = TextBox2.Text;



            TextBox2.Text = new string(CharsToTitleCase(myText).ToArray());
        }

        private void TextBox3_Leave(object sender, EventArgs e)
        {
            string myText = TextBox3.Text;



            TextBox3.Text = new string(CharsToTitleCase(myText).ToArray());
        }

        private void TextBox4_Leave(object sender, EventArgs e)
        {
            string myText = TextBox4.Text;



            TextBox4.Text = new string(CharsToTitleCase(myText).ToArray());
        }

        private void TextBox5_Leave(object sender, EventArgs e)
        {
            string myText = TextBox5.Text;



            TextBox5.Text = new string(CharsToTitleCase(myText).ToArray());
        }

        private void textBox10_Leave(object sender, EventArgs e)
        {
            string myText = textBox10.Text;



            textBox10.Text = new string(CharsToTitleCase(myText).ToArray());
        }

        private void textBox9_Leave(object sender, EventArgs e)
        {
            string myText = textBox9.Text;



            textBox9.Text = new string(CharsToTitleCase(myText).ToArray());
        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            string myText = textBox8.Text;



            textBox8.Text = new string(CharsToTitleCase(myText).ToArray());
        }

        private void lineShape3_Leave(object sender, EventArgs e)
        {

        }

        private void RichTextBox1_Leave(object sender, EventArgs e)
        {
            string myText = RichTextBox1.Text;



            RichTextBox1.Text = new string(CharsToTitleCase(myText).ToArray());
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            int age = int.Parse(DateTime.Today.ToString("yyyy")) - int.Parse(DateTimePicker1.Value.ToString("yyyy"));
            
            TextBox13.Text = age.ToString();
        }


        }

    

   
    }

