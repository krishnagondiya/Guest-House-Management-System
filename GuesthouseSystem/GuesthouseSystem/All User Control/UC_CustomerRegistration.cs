using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GuesthouseSystem.All_User_Control
{
    public partial class UC_CustomerRegistration : UserControl
    {

        Function fn = new Function();
        String q;
        public UC_CustomerRegistration()
        {
            InitializeComponent();
        }

        public void setComboBox(String q,ComboBox combo)
        {
            SqlDataReader sdr = fn.getForCombo(q);
            while(sdr.Read())
            {
                for(int i=0; i<sdr.FieldCount; i++)
                {
                    combo.Items.Add(sdr.GetString(i));
                }
            }
            sdr.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRoomType.SelectedIndex = -1;
            txtRoomNo.ResetText();
            txtPrice.Clear();
        }

        private void btnAlloteRoom_Click(object sender, EventArgs e)
        {
            if (txtName.Text!="" && txtMobile.Text != "" && txtGender.Text != "" && txtDob.Text != "" && txtAddress.Text != "" && txtCheckin.Text != "")
            {
                String Name = txtName.Text;
                Int64 Mobile = Int64.Parse(txtMobile.Text);
                String Gender = txtGender.Text;
                String Dob = txtDob.Text;
                String Address = txtAddress.Text;
                String Checkin = txtCheckin.Text;

                q = "insert into Customer (Cname,Mobile,Gender,Dob,Address,Checkin,Roomid) values ('"+Name+ "'," + Mobile + ",'" + Gender + "','" + Dob + "','" + Address + "','" + Checkin + "' ,'" + Roomid + "') update Rooms set Booked='YES' where RoomNo='" + txtRoomNo.Text + "'";
                fn.setData(q, "Room No (" + txtRoomNo.Text + ") Allocation Successfully!!.");
                clearall();
            }
            else
            {
                MessageBox.Show("Please Fill All Fileds.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UC_CustomerRegistration_Load(object sender, EventArgs e)
        {

        }

        private void txtRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRoomNo.Items.Clear();
            txtPrice.Clear();
            q = "select RoomNo from Rooms where Bed='"+txtBed.Text+"' and RoomType='"+txtRoomType.Text+"' and Booked='NO'";
            setComboBox(q, txtRoomNo);
        }
        int Roomid;
        private void txtRoomNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            q = "select Price,Roomid from Rooms where RoomNo='"+txtRoomNo.Text+"'";
            DataSet ds = fn.getData(q);
            txtPrice.Text = ds.Tables[0].Rows[0][0].ToString();
            Roomid = int.Parse(ds.Tables[0].Rows[0][1].ToString());
        }

        public void clearall()
        {
            txtName.Clear();
            txtMobile.Clear();
            txtGender.SelectedIndex=-1;
            txtDob.ResetText();
            txtAddress.Clear();
            txtCheckin.ResetText();
            txtBed.SelectedIndex = -1;
            txtRoomType.SelectedIndex = -1;
            txtRoomNo.ResetText();
            txtPrice.Clear();

        }

        private void UC_CustomerRegistration_Leave(object sender, EventArgs e)
        {
            clearall();
        }
    }
}
