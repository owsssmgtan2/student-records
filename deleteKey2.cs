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
    public partial class deleteKey2 : Form
    {

        MySqlConnection conn;
        //MySqlDataAdapter adapter;
        MySqlCommand cmd;

        Panel p2;


        public deleteKey2(Panel p)

        {
            p2 = p;
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

                        s3 = "DELETE from teacher_registration where t_id = '" + textBox2.Text + "'";
                        cmd = new MySqlCommand(s3, conn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Teacher " + textBox3.Text + " " + textBox4.Text + " " + textBox5.Text + ". Successfully Deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();

                        p2.Controls.Clear();

                        Panel newviewsubjectpanel = new Panel();
                        p2.Controls.Clear();
                        menu r = new menu();
                        newviewsubjectpanel = r.panel1;
                        p2.Controls.Add(newviewsubjectpanel);
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

                }
                else
                {
                    MessageBox.Show("You entered a wrong password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TextBox1.Clear();
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
