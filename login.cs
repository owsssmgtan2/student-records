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
    public partial class login : Form
    {
        MySqlConnection conn;
        MySqlDataAdapter adapter;
        MySqlCommand cmd;
        DataTable table = new DataTable();
        public login()
        {
            InitializeComponent();
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

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            signup sign = new signup();
            sign.Show();
        }

        private void button1_Click(object sender, EventArgs e)
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
                    MySqlCommand m = new MySqlCommand("SELECT * from student_record.users where user_uname = '" + TextBox1.Text + "' and user_pass = '"+ textBox2.Text +"'", conn);
                    dr2 = m.ExecuteReader();
                    if (dr2.Read())
                    {
                        MessageBox.Show("Welcome " + dr2.GetString("user_fname") + " " + dr2.GetString("user_lname"), "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Form1 f = new Form1();
                        

                        f.label12.Text = dr2.GetString("user_fname");
                        f.label13.Text = dr2.GetString("user_mname");
                        f.label14.Text = dr2.GetString("user_lname");
                        f.label16.Text = dr2.GetString("user_type");
                        Global g = new Global();
                        g.passtanan = dr2.GetString("user_pass");
                        TextBox1.Clear();
                        textBox2.Clear();

                        if (dr2.GetString("user_type") == "Admin")
                        {
          
                        }
                        else {
                            f.button9.Enabled = true;
                            f.button8.Enabled = false;
                            f.button5.Enabled = false;
                            f.button4.Enabled = false;
                            f.linkLabel1.Enabled = false;
                        }

                        f.Show();
                        this.Hide();

                        
                    }
                    else
                    {
                        MessageBox.Show("Account Not Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox2.Clear();
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                conn.Close();
                conn.Dispose();

       }
    }
  
}
