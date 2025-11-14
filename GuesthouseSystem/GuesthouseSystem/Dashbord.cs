using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuesthouseSystem
{
    public partial class Dashbord : Form
    {
        public Dashbord()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login L = new Login();
            L.Show();
            this.Hide();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            MovingPanel.Left = btnCustomerRegistration.Left+8;
            uC_CustomerRegistration1.Visible = true;
            uC_CustomerRegistration1.BringToFront();
            uC_AddRoom1.Visible = false;
        }

        private void btnAddRooms_Click(object sender, EventArgs e)
        {
            MovingPanel.Left = btnAddRooms.Left + 8;
            uC_AddRoom1.Visible = true;
            uC_AddRoom1.BringToFront();
            

        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            MovingPanel.Left = btnCheckOut.Left + 8;
            uC_CheckOut1.Visible = true;
            uC_CheckOut1.BringToFront();
            uC_AddRoom1.Visible = false;
            uC_CustomerRegistration1.Visible = false;

        }

        private void btnCustomerDetails_Click(object sender, EventArgs e)
        {
            MovingPanel.Left = btnCustomerDetails.Left + 8;
            uC_CustomerDetails1.Visible = true;
            uC_CustomerDetails1.BringToFront();
            uC_AddRoom1.Visible = false;
            uC_CustomerRegistration1.Visible = false;
            uC_CheckOut1.Visible = false;

        }

        private void btnAddAdmin_Click(object sender, EventArgs e)
        {
            MovingPanel.Left = btnAddAdmin.Left + 8;
            uC_AddAdmin1.Visible = true;
            uC_AddAdmin1.BringToFront();
            uC_AddRoom1.Visible = false;
            uC_CustomerRegistration1.Visible = false;
            uC_CheckOut1.Visible = false;
            uC_CustomerDetails1.Visible = false;

        }

        private void uC_CustomerRegistration1_Load(object sender, EventArgs e)
        {

        }

        private void uC_AddAdmin1_Load(object sender, EventArgs e)
        {

        }
    }
}
