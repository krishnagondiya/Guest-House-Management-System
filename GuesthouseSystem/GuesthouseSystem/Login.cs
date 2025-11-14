using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace GuesthouseSystem
{
    public partial class Login : Form
    {

        Function fn = new Function();

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\PROJECT\GuesthouseSystem\GuesthouseSystem\GuestHouse.mdf;Integrated Security=True");

        public Login()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Click on the link below to continue learning how to build a desktop app using WinForms!
            System.Diagnostics.Process.Start("http://aka.ms/dotnet-get-started-desktop");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thanks!");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            con.Open();
            String q = "select * from Login where UserName='" + textBox1.Text + "' and Password='" + textBox2.Text + "'";
            SqlCommand com = new SqlCommand(q, con);
            SqlDataReader dr = com.ExecuteReader();

            if (dr.HasRows)
            {
                MessageBox.Show("Login Done", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Dashbord db = new Dashbord();
                db.Show();
                this.Hide();
                clear();
            }
            else if (textBox1.Text == "" && textBox2.Text=="")
            {
                MessageBox.Show("Please Enter Username And Password","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

            else
            {
                MessageBox.Show("Incorect Username or Password","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                clear();
            }
            
            con.Close();
        }

        public void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
