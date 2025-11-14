using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuesthouseSystem.All_User_Control
{
    public partial class UC_CustomerDetails : UserControl
    {

        Function fn =new  Function();
        String q;

        public UC_CustomerDetails()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSerachBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtSerachBy.SelectedIndex==0)
            {
                q = "select Customer.Id,Customer.Cname,Customer.Mobile,Customer.Gender,Customer.Dob,Customer.Address,Customer.Checkin,Customer.Checkout,Rooms.RoomNo,Rooms.RoomType,Rooms.Bed,Rooms.Price from Customer inner join Rooms on Customer.Roomid = Rooms.Roomid";
                DataSet ds = fn.getData(q);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else if (txtSerachBy.SelectedIndex == 1)
            {
                q = "select Customer.Id,Customer.Cname,Customer.Mobile,Customer.Gender,Customer.Dob,Customer.Address,Customer.Checkin,Customer.Checkout,Rooms.RoomNo,Rooms.RoomType,Rooms.Bed,Rooms.Price from Customer inner join Rooms on Customer.Roomid = Rooms.Roomid where Checkout is null";
                DataSet ds = fn.getData(q);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else if (txtSerachBy.SelectedIndex == 2)
            {
                q = "select Customer.Id,Customer.Cname,Customer.Mobile,Customer.Gender,Customer.Dob,Customer.Address,Customer.Checkin,Customer.Checkout,Rooms.RoomNo,Rooms.RoomType,Rooms.Bed,Rooms.Price from Customer inner join Rooms on Customer.Roomid = Rooms.Roomid where Checkout is not null";
                DataSet ds = fn.getData(q);
                dataGridView1.DataSource = ds.Tables[0];
            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UC_CustomerDetails_Load(object sender, EventArgs e)
        {

        }
    }
}
