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
    public partial class deleteKey3 : Form
    {

        MySqlConnection conn;
        //MySqlDataAdapter adapter;
        MySqlCommand cmd;

        ComboBox c1;
        TextBox t1;
        TextBox t2;
        TextBox t3;

        public deleteKey3(ComboBox cc1, TextBox tt1, TextBox tt2, TextBox tt3)
        {
            c1 = cc1;
            t1 = tt1;
            t2 = tt2;
            t3 = tt3;
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
                Global g = new Global();


                if (pass == "pass")
                {
                    string connStr3 = "server=localhost;database=student_record;user=root;password=;";
                    conn = new MySqlConnection(connStr3);
                    string s3;

                    try
                    {


                        conn.Open();

                        s3 = "DELETE from subject_information where subject_code = '" + textBox2.Text + "'";
                        cmd = new MySqlCommand(s3, conn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Subject " + textBox3.Text + ". Successfully Deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        c1.Items.Clear();
                        t1.Clear();
                        t2.Clear();
                        t3.Clear();
                        

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
