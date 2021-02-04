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
using MySql.Data.MySqlClient;
using MySql.Data;

namespace Student_Record_System
{
    public partial class viewsubject : Form
    {

        MySqlConnection conn;
        //MySqlDataAdapter adapter;
        MySqlCommand cmd;

        public viewsubject()
        {
            InitializeComponent();
        }

        private void viewsubject_Load(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string subj_code = TextBox1.Text;
            string subj_desc = TextBox2.Text;
            if (string.IsNullOrEmpty(subj_code) || string.IsNullOrWhiteSpace(subj_code) || string.IsNullOrEmpty(subj_desc) || string.IsNullOrWhiteSpace(subj_desc))
            {
                MessageBox.Show("Please fill in all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {


                string connStr3 = "server=localhost;database=student_record;user=root;password=;";
                conn = new MySqlConnection(connStr3);
                string s3;
           

                try
                {
                    int subj_unit = int.Parse(TextBox3.Text);
           

                    conn.Open();
                    s3 = "INSERT INTO subject_information VALUES('" + subj_code + "','" + subj_desc + "','" + subj_unit + "')";
                    cmd = new MySqlCommand(s3, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Subject " + subj_desc + ". Successfully Added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    TextBox1.Clear();
                    TextBox2.Clear();
                    TextBox3.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please enter number of units","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }

                conn.Close();
                conn.Dispose();

            }


           

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
                ComboBox1.Items.Clear();
                while (dr2.Read())
                {
                 ComboBox1.Items.Add(dr2.GetString("subject_code"));
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            conn.Close();
            conn.Dispose();
    
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult d = new DialogResult();


            string subj_code = TextBox1.Text;
            string subj_desc = TextBox2.Text;
            int subj_unit = int.Parse(TextBox3.Text);
            
            d = MessageBox.Show("Are you sure you want to update " + subj_desc +". Subject Information?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (d.ToString() == "Yes")
            {
                button1.Visible = true;
                button2.Visible = true;
                TextBox2.ReadOnly = false;
                TextBox3.ReadOnly = false;
                TextBox1.ReadOnly = false;
            }

            else
            {

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button6.Visible = true;
            button7.Visible = true;

            button4.Visible = false;
            button5.Visible = false;

            TextBox1.Clear();
            TextBox2.Clear();
            TextBox3.Clear();
            TextBox1.ReadOnly = false;
            TextBox2.ReadOnly = false;
            TextBox3.ReadOnly = false;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button6.Visible = false;
            button7.Visible = false;
            button4.Visible = true;
            button5.Visible = true;


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
                MySqlCommand m = new MySqlCommand("SELECT * from student_record.subject_information where subject_code = '"+ t1 +"'", conn);
                dr2 = m.ExecuteReader();
                if (dr2.Read())
                {
                    TextBox1.Text = dr2.GetString("subject_code");
                    TextBox2.Text = dr2.GetString("subject_desc");
                    TextBox3.Text = dr2.GetInt32("subject_unit").ToString();

                    TextBox1.ReadOnly = true;
                    TextBox2.ReadOnly = true;
                    TextBox3.ReadOnly = true;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            conn.Close();
            conn.Dispose();
    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string subj_code = TextBox1.Text;
            string subj_desc = TextBox2.Text;
            int subj_unit = int.Parse(TextBox3.Text);
            string t1 = ComboBox1.Text;


            if ((string.IsNullOrEmpty(subj_code) || string.IsNullOrWhiteSpace(subj_code)) || (string.IsNullOrEmpty(subj_desc)) || string.IsNullOrWhiteSpace(subj_desc))
            {
                MessageBox.Show("Please fill in all fields!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                


                                    string connStr3 = "server=localhost;database=student_record;user=root;password=;";
                                    conn = new MySqlConnection(connStr3);
                                    string s3;

                                    try
                                    {


                                        conn.Open();
                                        s3 = "UPDATE subject_information SET subject_desc = '" + subj_desc + "', subject_unit = '" + subj_unit + "' where subject_code = '"+ t1 +"'";
                                        cmd = new MySqlCommand(s3, conn);
                                        cmd.ExecuteNonQuery();
                                        MessageBox.Show("Student " + subj_desc + ". Successfully Updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);




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

        private void button5_Click(object sender, EventArgs e)
        {

            DialogResult d = new DialogResult();


            string subj_code = TextBox1.Text;
            string subj_desc = TextBox2.Text;
            int subj_unit = int.Parse(TextBox3.Text);
           

            d = MessageBox.Show("Are you sure you want to delete " + subj_desc + " Subject Information?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (d.ToString() == "Yes")
            {
                deleteKey3 ddd = new deleteKey3(ComboBox1,TextBox1,TextBox3,TextBox2);
                ddd.textBox2.Text = subj_code;
                ddd.textBox3.Text = subj_desc;
               
                ddd.ShowDialog();

            }


            else
            {

            }

         
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
            button6.Visible = false;
            button7.Visible = false;
            TextBox1.Clear();
            TextBox2.Clear();
            TextBox3.Clear();
            TextBox1.ReadOnly = true;
            TextBox2.ReadOnly = true;
            TextBox3.ReadOnly = true;
            ComboBox1.SelectedIndex = -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            TextBox1.ReadOnly = true;
            TextBox2.ReadOnly = true;
            TextBox3.ReadOnly = true;
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
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

        private void TextBox2_Leave(object sender, EventArgs e)
        {
            string myText = TextBox2.Text;



            TextBox2.Text = new string(CharsToTitleCase(myText).ToArray());
        }

        private void TextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void TextBox1_Leave(object sender, EventArgs e)
        {
            TextBox1.Text = TextBox1.Text.ToUpper();
        }
    
        }
    }
