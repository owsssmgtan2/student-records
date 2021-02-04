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
    public partial class deleteKey : Form
    {
        private Panel _dgv;

        MySqlConnection conn;
        //MySqlDataAdapter adapter;
        MySqlCommand cmd;


        public deleteKey(Panel dgv)
        {
            _dgv = dgv;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pass = TextBox1.Text;
            viewclient v = new viewclient();
            Form1 f = new Form1();
                         
            if (string.IsNullOrEmpty(pass) || string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("Please enter a password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                       
            }
            else
            {
                

                    if (pass == "pass")
                    {
                        string connStr3 = "server=localhost;database=student_record;user=root;password=;";
                        conn = new MySqlConnection(connStr3);
                        string s3;

                        try
                        {
                            

                            conn.Open();

                         
                            
                            s3 = "DELETE from student_registration where stud_id = '" + textBox2.Text + "'";
                            cmd = new MySqlCommand(s3, conn);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Student " + textBox3.Text + " " + textBox4.Text + " " + textBox5.Text + ". Successfully Deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                           
                            conn.Close();
                            conn.Dispose();

                            viewclient vc = new viewclient();
                            _dgv.Controls.Clear();
                            this.Hide();

                            Panel newviewsubjectpanel = new Panel();
                            _dgv.Controls.Clear();
                            menu r = new menu();
                            newviewsubjectpanel = r.panel1;
                            _dgv.Controls.Add(newviewsubjectpanel);
                            
                        }
                        catch (Exception ex)
                        {
                            //textBox14.Clear();
                            MessageBox.Show(ex.Message);
                        }

                        conn.Close();
                        conn.Dispose();

                    }
                    else
                    {
                        MessageBox.Show("You entered a wrong password!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        TextBox1.Clear();
                    }
            }
            
        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
