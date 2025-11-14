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
    public partial class UC_AddRoom : UserControl
    {

        Function fn = new Function();
        String q;

        public UC_AddRoom()
        {
            InitializeComponent();
        }

        private void UC_AddAdmin_Load(object sender, EventArgs e)
        {
            q = "select * from Rooms";
            DataSet ds = fn.getData(q);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtRoomNo.Text != "" && txtRoomType.Text != "" && txtBed.Text != "" && txtPrice.Text != "")
            {
                    if (Booking == "YES")
                    {
                        MessageBox.Show("You Can't Delete Alloted Room", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        //String RoomType = txtRoomType.Text;
                        //String Bed = txtBed.Text;
                        //Int64 Price = Int64.Parse(txtPrice.Text);

                        q = "delete from Rooms where Roomid="+ID+"";
                        fn.setData(q, "Room Deleted Successfully.");
                        UC_AddAdmin_Load(this, null);
                        clear();
                    }
            }
            else
            {
                MessageBox.Show("Please Select A Room Which You Want To Delete.", "Warning !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (txtRoomNo.Text != "" && txtRoomType.Text != "" && txtBed.Text != "" && txtPrice.Text != "")
            {
                String RoomNO = txtRoomNo.Text;

                q = "select count(*) from Rooms where RoomNo='" + RoomNO + "' AND Roomid != " + ID;
                DataSet ds = fn.getData(q);
                int count = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

                if (count > 0)
                {
                    MessageBox.Show("Room Number Already Exists", "Warning..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (Booking == "YES")
                    {
                        MessageBox.Show("You Can't Update Alloted Room", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        String RoomType = txtRoomType.Text;
                        String Bed = txtBed.Text;
                        Int64 Price = Int64.Parse(txtPrice.Text);

                        q = "update Rooms set RoomNo='" + RoomNO + "', RoomType='" + RoomType + "', Bed='" + Bed + "', Price=" + Price + " where Roomid=" + ID;
                        fn.setData(q, "Room Updated Successfully.");

                        UC_AddAdmin_Load(this, null);
                        clear();

                    }
                }
            }
            else
            {
                MessageBox.Show("Please Select A Room Which You Want To Update.", "Warning !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtRoomNo.Text != "" && txtRoomType.Text != "" && txtBed.Text != "" && txtPrice.Text != "")
            {
                String RoomNO = txtRoomNo.Text;
                q = "select count(*) from Rooms where RoomNo='"+RoomNO+"'";
                DataSet ds = fn.getData(q);
                int count = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

                if (count > 0)
                {
                    MessageBox.Show("Room Number Already Exists","Warning..",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                else
                {
                    String RoomType = txtRoomType.Text;
                    String Bed = txtBed.Text;
                    Int64 Price = Int64.Parse(txtPrice.Text);

                    q = "Insert into Rooms (RoomNo,RoomType,Bed,Price) values('" + RoomNO + "','" + RoomType + "','" + Bed + "'," + Price + ")";
                    fn.setData(q, "Room Added.");

                    UC_AddAdmin_Load(this, null);
                    clear();
                }
            }
            else
            {
                MessageBox.Show("Fill All Fields.", "Warning !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        public void clear()
        {
            txtRoomNo.Clear();
            txtRoomType.SelectedIndex = -1;
            txtBed.SelectedIndex = -1;
            txtPrice.Clear();
        }
        int ID;
        String Booking;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                ID = int.Parse(row.Cells["Roomid"].Value.ToString());
                txtRoomNo.Text = row.Cells["RoomNO"].Value.ToString();
                txtRoomType.Text = row.Cells["RoomType"].Value.ToString();
                txtBed.Text = row.Cells["Bed"].Value.ToString();
                txtPrice.Text = row.Cells["Price"].Value.ToString();
                Booking = row.Cells["Booked"].Value.ToString();

            }
        }
        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void UC_AddRoom_Enter(object sender, EventArgs e)
        {
            UC_AddAdmin_Load(this, null);
        }

        private void UC_AddRoom_Leave(object sender, EventArgs e)
        {
            clear();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtRoomNo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
