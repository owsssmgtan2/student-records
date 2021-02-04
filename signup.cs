using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Student_Record_System
{
    public partial class signup : Form
    {
        MySqlConnection conn;
        MySqlDataAdapter adapter;
        MySqlCommand cmd;
        public signup()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            if (textBox6.Text == "First Name")
            {
                textBox6.ForeColor = Color.FromArgb(45, 45, 48);
                textBox6.Text = "";
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if ((String.IsNullOrEmpty(textBox6.Text) || string.IsNullOrWhiteSpace(textBox6.Text)))
            {
                textBox6.ForeColor = Color.Silver;
                textBox6.Text = "First Name";
            }

            string myText = textBox6.Text;

            textBox6.Text = new string(CharsToTitleCase(myText).ToArray());
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (textBox5.Text == "Middle Name")
            {
                textBox5.ForeColor = Color.FromArgb(45, 45, 48);
                textBox5.Text = "";
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if ((String.IsNullOrEmpty(textBox5.Text) || string.IsNullOrWhiteSpace(textBox5.Text)))
            {
                textBox5.ForeColor = Color.Silver;
                textBox5.Text = "Middle Name";
            }

            string myText = textBox5.Text;



            textBox5.Text = new string(CharsToTitleCase(myText).ToArray());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox4_Enter_1(object sender, EventArgs e)
        {
            if (textBox4.Text == "Last Name")
            {
                textBox4.ForeColor = Color.FromArgb(45, 45, 48);
                textBox4.Text = "";
            }
        }

        private void textBox4_Leave_1(object sender, EventArgs e)
        {
            if ((String.IsNullOrEmpty(textBox4.Text) || string.IsNullOrWhiteSpace(textBox4.Text)))
            {
                textBox4.ForeColor = Color.Silver;
                textBox4.Text = "Last Name";
            }

            string myText = textBox4.Text;



            textBox4.Text = new string(CharsToTitleCase(myText).ToArray());
        }

        private void TextBox1_Enter(object sender, EventArgs e)
        {
            if (TextBox1.Text == "Username")
            {
                TextBox1.ForeColor = Color.FromArgb(45, 45, 48);
                TextBox1.Text = "";
            }
        }

        private void TextBox1_Leave(object sender, EventArgs e)
        {
            if ((String.IsNullOrEmpty(TextBox1.Text) || string.IsNullOrWhiteSpace(TextBox1.Text)))
            {
                TextBox1.ForeColor = Color.Silver;
                TextBox1.Text = "Username";
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Password")
            {
                textBox2.ForeColor = Color.FromArgb(45, 45, 48);
                textBox2.Text = "";
                textBox2.PasswordChar = '•';
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if ((String.IsNullOrEmpty(textBox2.Text) || string.IsNullOrWhiteSpace(textBox2.Text)))
            {
                textBox2.ForeColor = Color.Silver;

                textBox2.Text = "Password";
                textBox2.PasswordChar = '\0';
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Re-type Password")
            {
                textBox3.ForeColor = Color.FromArgb(45, 45, 48);
                textBox3.Text = "";
                textBox3.PasswordChar = '•';
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if ((String.IsNullOrEmpty(textBox3.Text) || string.IsNullOrWhiteSpace(textBox3.Text)))
            {
                textBox3.ForeColor = Color.Silver;

                textBox3.Text = "Re-type Password";
                textBox3.PasswordChar = '\0';
            }
        }

        private void signup_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string fname = textBox6.Text;
            string mname = textBox5.Text;
            string lname = textBox4.Text;
            string uname = TextBox1.Text;
            string pass = textBox2.Text;
            string rpass = textBox3.Text;

            string connStr3 = "server=localhost;database=student_record;user=root;password=;";
            conn = new MySqlConnection(connStr3);
            string s3;

             if ((string.IsNullOrEmpty(fname) || string.IsNullOrWhiteSpace(fname)) || ((string.IsNullOrEmpty(mname) || string.IsNullOrWhiteSpace(mname)) || (string.IsNullOrEmpty(lname) || string.IsNullOrWhiteSpace(lname)) || (string.IsNullOrEmpty(uname) || string.IsNullOrWhiteSpace(uname)) || (string.IsNullOrEmpty(pass) || string.IsNullOrWhiteSpace(pass)) || (string.IsNullOrEmpty(rpass) || string.IsNullOrWhiteSpace(rpass)))) {
                MessageBox.Show("Please fill in all fields!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (pass == rpass)
                {
                    try
                    {


                        conn.Open();
                        s3 = "INSERT INTO users VALUES('" + fname + "','" + mname + "','" + lname + "', '" + uname + "', '" + pass + "', '" + comboBox3.Text + "')";
                        cmd = new MySqlCommand(s3, conn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Student " + fname + " " + mname + " " + lname + "Successfully Registered!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        textBox6.Clear();
                        textBox5.Clear();
                        textBox4.Clear();
                        TextBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        comboBox3.SelectedIndex = -1;

                        conn.Close();
                        conn.Dispose();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("User already exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    conn.Close();
                    conn.Dispose();
                }
                else
                {
                    MessageBox.Show("Password not match!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox3.Clear();
                }
            }
           

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

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
