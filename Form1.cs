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
    public partial class Form1 : Form
    {
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataReader dr;
        public bool siga,siga1, wala;

        Global g = new Global();

        public Form1()
        {
            InitializeComponent();
        }


        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(239, 239, 242);
            button3.FlatAppearance.BorderColor = Color.FromArgb(239, 239, 242);
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.White;
            button3.FlatAppearance.BorderColor = Color.White;
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            lineShape3.BorderColor = Color.FromArgb(21, 161, 255);
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {

        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            lineShape2.BorderColor = Color.FromArgb(21, 161, 255);
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {

        }

      
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void panel3_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Search") {
                textBox1.ForeColor = Color.FromArgb(45, 45, 48);
                textBox1.Text = "";
            }

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if ((String.IsNullOrEmpty(textBox1.Text) || string.IsNullOrWhiteSpace(textBox1.Text)))
            {
                textBox1.ForeColor = Color.Silver;
                textBox1.Text = "Search";
                panel5.Visible = false;
                DataGridView1.Visible = false;
            }

  //          panel5.Visible = false;
    //        DataGridView1.Visible = false;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            lineShape1.BorderColor = Color.Gray;
            lineShape2.BorderColor = Color.Gray;
            lineShape3.BorderColor = Color.FromArgb(21, 161, 255);
            lineShape4.BorderColor = Color.Gray;
            lineShape5.BorderColor = Color.Gray;

            string id;
            string id2 = "";


            string connStr3 = "server=localhost;database=student_record;user=root;password=;";
            conn = new MySqlConnection(connStr3);
            string s3;

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
            }

            conn.Close();
            conn.Dispose();
            
            
            
            siga = true;
             g.naana = true;
             lineShape2.BorderColor = Color.DimGray;
             lineShape3.BorderColor = Color.FromArgb(21, 161, 255);
             Panel newregistrationpanel = new Panel();
             panel1.Controls.Clear();
             registration r = new registration();
             r.textBox12.Text = DateTime.Today.ToString("yyyy");
             r.textBox14.Text = DateTime.Today.ToString("yyyy") + "-" + id2;
             newregistrationpanel = r.panel2;
             panel1.Controls.Add(newregistrationpanel);
        
        }

        private void button5_Click(object sender, EventArgs e)
        {
            lineShape1.BorderColor = Color.Gray;
            lineShape2.BorderColor = Color.FromArgb(21, 161, 255);
            lineShape3.BorderColor = Color.Gray;
            lineShape4.BorderColor = Color.Gray;
            lineShape5.BorderColor = Color.Gray;
            
            string id;
            string id2 = "";


            string connStr3 = "server=localhost;database=student_record;user=root;password=;";
            conn = new MySqlConnection(connStr3);
            string s3;

            MySqlDataReader dr2;

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();

            }


            try
            {
                conn.Open();
                MySqlCommand m = new MySqlCommand("SELECT max(t_id) as l from teacher_registration", conn);
                dr2 = m.ExecuteReader();
                if (dr2.Read())
                {

                    if (Convert.IsDBNull(dr2.GetString("l")) == true)
                    {
                        id2 = "70000";
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

                    id2 = "70000";
                }
                conn.Close();
                conn.Dispose();

            }
            catch (Exception ex)
            {
                id2 = "70000";
               
            }

            conn.Close();
            conn.Dispose();
            
            
            
            
            g.naana2 = true;
            lineShape3.BorderColor = Color.DimGray;
            lineShape2.BorderColor = Color.FromArgb(21, 161, 255);
            Panel newtregistrationpanel = new Panel();
            panel1.Controls.Clear();
            registration_teacher r = new registration_teacher();
            r.textBox8.Text = DateTime.Today.ToString("yyyy");
            r.textBox14.Text = DateTime.Today.ToString("yyyy") + "-" + id2;
            newtregistrationpanel = r.panel1;
            panel1.Controls.Add(newtregistrationpanel);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            string t1 = textBox1.Text;


             if (string.IsNullOrEmpty(t1) || string.IsNullOrWhiteSpace(t1))
            {
            textBox1.Text = "";
            panel5.Visible = false;
            DataGridView1.Visible = false;
            DataGridView1.Rows.Clear();
            }
            else
            {
            panel5.Visible = true;
            DataGridView1.Visible = true;
            }





            string connStr3 = "server=localhost;database=student_record;user=root;password=;";
            conn = new MySqlConnection(connStr3);
            string s3;

            MySqlDataReader dr2;

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();

            }
            
            try
            {
                conn.Open();
                MySqlCommand m = new MySqlCommand("SELECT stud_fname,stud_mname,stud_lname from student_registration where stud_lname like '"+ t1 +"%'", conn);
                dr2 = m.ExecuteReader();
                DataGridView1.Rows.Clear();
                while (dr2.Read())
                {
                    
                    if(String.IsNullOrEmpty(t1) || String.IsNullOrWhiteSpace(t1))
                    {
                        break;
                    }


                    DataGridView1.Rows.Add(dr2.GetString("stud_lname"), dr2.GetString("stud_fname"), dr2.GetString("stud_mname"));
      
                }
                conn.Close();
                conn.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            conn.Close();
            conn.Dispose();

        }

        private void button3_Click(object sender, EventArgs e)
        {

            string t1 = textBox1.Text;
            textBox1.Text = "Search";
            textBox1.ForeColor = Color.Silver;

            if (t1 == "Search")
            {
                MessageBox.Show("Please choose a student to search!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                textBox1.Clear();

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
                    MySqlCommand m = new MySqlCommand("SELECT * from student_record.student_registration where CONCAT(stud_lname,' ',stud_fname,' ',stud_mname) = '" + t1 + "'", conn);
                    dr2 = m.ExecuteReader();
                    if (dr2.Read())
                    {

                        Panel newviewpanel = new Panel();
                        panel1.Controls.Clear();
                        viewclient r = new viewclient();
                        newviewpanel = r.panel2;
                        panel1.Controls.Add(newviewpanel);

                        
                        r.TextBox1.Text = dr2.GetString("stud_fname");
                        r.TextBox2.Text = dr2.GetString("stud_mname");
                        r.TextBox3.Text = dr2.GetString("stud_lname");
                        r.textBox14.Text = dr2.GetString("stud_id");
                        r.DateTimePicker1.Value = dr2.GetDateTime("stud_dateofbirth");
                        r.TextBox4.Text = dr2.GetString("stud_placeofbirth");
                        r.TextBox5.Text = dr2.GetString("stud_citizenship");
                        r.ComboBox1.Text = dr2.GetString("stud_civilstatus");
                        r.TextBox13.Text = dr2.GetString("stud_age");
                        r.textBox6.Text = dr2.GetString("stud_contact");
                        r.textBox7.Text = dr2.GetString("stud_email");
                        r.textBox10.Text = dr2.GetString("stud_pfname");
                        r.textBox9.Text = dr2.GetString("stud_pmname");
                        r.textBox8.Text = dr2.GetString("stud_plname");
                        r.comboBox2.Text = dr2.GetString("stud_prelationship");
                        r.textBox11.Text = dr2.GetString("stud_pcontact");
                        r.RichTextBox1.Text = dr2.GetString("stud_address");
                        r.textBox12.Text = dr2.GetString("stud_yearofentry");
                        r.comboBox3.Text = dr2.GetString("stud_department");
                        r.comboBox4.Text = dr2.GetString("stud_program");

                        if (dr2.GetString("stud_sex") == "Male")
                        {
                            r.RadioButton1.Checked = true;
                            r.RadioButton2.Checked = false;
                        }
                        else 
                        {
                            r.RadioButton1.Checked = false;
                            r.RadioButton2.Checked = true;
                        }

                        conn.Close();
                        conn.Dispose();
                    }

                    else
                    {
                        MessageBox.Show("Student Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        string fname = DataGridView1.CurrentRow.Cells[1].Value.ToString();
        string mname = DataGridView1.CurrentRow.Cells[2].Value.ToString();
        string lname = DataGridView1.CurrentRow.Cells[0].Value.ToString();

        textBox1.Text = lname + " " + fname + " " + mname;

        panel5.Visible = false;
        DataGridView1.Visible = false;
        DataGridView1.Rows.Clear();

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string t1 = textBox2.Text;


            if (string.IsNullOrEmpty(t1) || string.IsNullOrWhiteSpace(t1))
            {
                textBox2.Text = "";
                panel6.Visible = false;
                dataGridView2.Visible = false;
                dataGridView2.Rows.Clear();
            }
            else
            {
                panel6.Visible = true;
                dataGridView2.Visible = true;
            }





            string connStr3 = "server=localhost;database=student_record;user=root;password=;";
            conn = new MySqlConnection(connStr3);
            string s3;

            MySqlDataReader dr2;

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();

            }

            try
            {
                conn.Open();
                MySqlCommand m = new MySqlCommand("SELECT t_fname,t_mname,t_lname from teacher_registration where t_lname like '" + t1 + "%'", conn);
                dr2 = m.ExecuteReader();
                dataGridView2.Rows.Clear();
                while (dr2.Read())
                {

                    if (String.IsNullOrEmpty(t1) || String.IsNullOrWhiteSpace(t1))
                    {
                        break;
                    }


                    dataGridView2.Rows.Add(dr2.GetString("t_lname"), dr2.GetString("t_fname"), dr2.GetString("t_mname"));

                }
                conn.Close();
                conn.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            conn.Close();
            conn.Dispose();

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string fname = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            string mname = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            string lname = dataGridView2.CurrentRow.Cells[0].Value.ToString();

            textBox2.Text = lname + " " + fname + " " + mname;
            panel6.Visible = false;
            dataGridView2.Visible = false;
            dataGridView2.Rows.Clear();

        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if ((String.IsNullOrEmpty(textBox2.Text) || string.IsNullOrWhiteSpace(textBox2.Text)))
            {
                textBox2.ForeColor = Color.Silver;
                textBox2.Text = "Search";
                panel6.Visible = false;
                dataGridView2.Visible = false;
            }

       //     panel6.Visible = false;
         //   dataGridView2.Visible = false;

        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Search")
            {
                textBox2.ForeColor = Color.FromArgb(45, 45, 48);
                textBox2.Text = "";
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {

            string t1 = textBox2.Text;
            


            if (t1 == "Search")
            {
                MessageBox.Show("Please choose a teacher to search!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                textBox2.Clear();

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
                    MySqlCommand m = new MySqlCommand("SELECT * from student_record.teacher_registration where CONCAT(t_lname,' ',t_fname,' ',t_mname) = '" + t1 + "'", conn);
                    dr2 = m.ExecuteReader();
                    if (dr2.Read())
                    {
              

                        Panel newviewpanel = new Panel();
                        panel1.Controls.Clear();
                        viewclient2 r = new viewclient2();
                        newviewpanel = r.panel2;
                        panel1.Controls.Add(newviewpanel);

                        r.TextBox1.Text = dr2.GetString("t_fname");
                        r.TextBox2.Text = dr2.GetString("t_mname");
                        r.TextBox3.Text = dr2.GetString("t_lname");
                        r.textBox14.Text = dr2.GetString("t_id");
                        r.DateTimePicker1.Value = dr2.GetDateTime("t_dateofbirth");
                        r.TextBox4.Text = dr2.GetString("t_placeofbirth");
                        r.TextBox5.Text = dr2.GetString("t_citizenship");
                        r.ComboBox1.Text = dr2.GetString("t_status");
                        r.TextBox13.Text = dr2.GetString("t_age");
                        r.textBox6.Text = dr2.GetString("t_contact");
                        r.textBox7.Text = dr2.GetString("t_email");
                        r.RichTextBox1.Text = dr2.GetString("t_add");
                        r.textBox12.Text = dr2.GetString("t_yearofentry");

                        if (dr2.GetString("t_sex") == "Male")
                        {
                            r.RadioButton1.Checked = true;
                            r.RadioButton2.Checked = false;
                        }
                        else
                        {
                            r.RadioButton1.Checked = false;
                            r.RadioButton2.Checked = true;
                        }

                        conn.Close();
                        conn.Dispose();
                    }

                    else
                    {
                        MessageBox.Show("Teacher not found!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
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

        private void button8_Click(object sender, EventArgs e)
        {
            lineShape1.BorderColor = Color.FromArgb(21, 161, 255);
            lineShape2.BorderColor = Color.Gray;
            lineShape3.BorderColor = Color.Gray;
            lineShape4.BorderColor = Color.Gray;
            lineShape5.BorderColor = Color.Gray;


            Panel newviewsubjectpanel = new Panel();
            panel1.Controls.Clear();
            viewsubject r = new viewsubject();


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
    
            newviewsubjectpanel = r.panel2;
            panel1.Controls.Add(newviewsubjectpanel);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            lineShape1.BorderColor = Color.Gray;
            lineShape2.BorderColor = Color.Gray;
            lineShape3.BorderColor = Color.Gray;
            lineShape4.BorderColor = Color.FromArgb(21, 161, 255);
            lineShape5.BorderColor = Color.Gray;

            Panel newviewsubjectpanel = new Panel();
            panel1.Controls.Clear();
            semviewer r = new semviewer();

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
                r.comboBox2.Items.Clear();
                while (dr2.Read())
                {
                    r.comboBox2.Items.Add(dr2.GetString("subject_code"));
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            conn.Close();
            conn.Dispose();
    

            newviewsubjectpanel = r.panel2;
            panel1.Controls.Add(newviewsubjectpanel);
        }

        private void button8_MouseHover(object sender, EventArgs e)
        {
            lineShape1.BorderColor = Color.FromArgb(21, 161, 255);
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {
            lineShape1.BorderColor = Color.DimGray;
        }

        private void button9_MouseHover(object sender, EventArgs e)
        {
            lineShape4.BorderColor = Color.FromArgb(21, 161, 255);
        }

        private void button9_MouseLeave(object sender, EventArgs e)
        {
            lineShape4.BorderColor = Color.DimGray;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkColor = Color.Gray;
            linkLabel2.LinkColor = Color.FromArgb(21, 161, 255);
            textBox2.Visible = true;
            button7.Visible = true;

            textBox1.Visible = false;
            button3.Visible = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel2.LinkColor = Color.Gray;
            linkLabel1.LinkColor = Color.FromArgb(21, 161, 255);
            textBox1.Visible = true;
            button3.Visible = true;

            textBox2.Visible = false;
            button7.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (panel9.Visible == true)
            {
                panel9.Visible = false;
            }
            else {
                panel9.Visible = true;
            }
               
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult d = new DialogResult();

            d = MessageBox.Show("Are you sure you want to Log out?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (d.ToString() == "Yes")
            {
                login l = new login();
                l.Show();
                this.Hide();
            }

            else
            {

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void clearpanel()
        {
            panel1.Controls.Clear();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            lineShape1.BorderColor = Color.Gray;
            lineShape2.BorderColor = Color.Gray;
            lineShape3.BorderColor = Color.Gray;
            lineShape4.BorderColor = Color.Gray;
            lineShape5.BorderColor = Color.FromArgb(21, 161, 255);

            Panel newmenu = new Panel();
            panel1.Controls.Clear();
            menu m = new menu();
            newmenu = m.panel1;
            panel1.Controls.Add(newmenu);
        }
        
    }
}
