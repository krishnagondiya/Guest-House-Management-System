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

    
    public partial class UC_CheckOut : UserControl
    {
        Function fn = new Function();
        String q;

        public UC_CheckOut()
        {
            InitializeComponent();
        }

        private void UC_CheckOut_Load(object sender, EventArgs e)
        {
            q = "select Customer.Id,Customer.Cname,Customer.Mobile,Customer.Gender,Customer.Dob,Customer.Address,Customer.Checkin,Rooms.RoomNo,Rooms.RoomType,Rooms.Bed,Rooms.Price from Customer inner join Rooms on Customer.Roomid = Rooms.Roomid where Chekout = 'NO'";
            DataSet ds = fn.getData(q);
            dataGridView1.DataSource = ds.Tables[0];


        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            q = "select Customer.Id,Customer.Cname,Customer.Mobile,Customer.Gender,Customer.Dob,Customer.Address,Customer.Checkin,Rooms.RoomNo,Rooms.RoomType,Rooms.Bed,Rooms.Price from Customer inner join Rooms on Customer.Roomid = Rooms.Roomid where Cname like '"+txtName.Text+"%' and Chekout='NO'";
            DataSet ds = fn.getData(q);
            dataGridView1.DataSource = ds.Tables[0];

        }
        int Id;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value!=null)
            {
                Id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtCname.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtRoomNo.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();

            }
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (txtCname.Text != "") 
            {
                if (MessageBox.Show("Are You Sure?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)==DialogResult.OK)
                {
                    String Cdate = txtCheckOut.Text;
                    q = "update Customer set Chekout='YES',Checkout='"+Cdate+"' where Id="+Id+" update Rooms set Booked='NO' where RoomNo='"+txtRoomNo.Text+"'";
                    fn.setData(q,"Check Out Successfuly.");
                    UC_CheckOut_Load(this, null);
                    clearall();

                }
            }
            else
            {
                MessageBox.Show("No Customer Selected.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void clearall()
        {
            txtName.Clear();
            txtCname.Clear();
            txtRoomNo.Clear();
            txtCheckOut.ResetText();
        }

        private void UC_CheckOut_Leave(object sender, EventArgs e)
        {
            clearall();
        }
    }
}
