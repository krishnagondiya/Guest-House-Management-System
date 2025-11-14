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
    public partial class UC_AddAdmin : UserControl
    {

        Function fn = new Function();
        String q;
        public UC_AddAdmin()
        {
            InitializeComponent();
        }

        private void UC_AddAdmin_Load(object sender, EventArgs e)
        {
            q = "select * from Login";
            DataSet ds = fn.getData(q);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void txtRoomNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAddAdmin_Click(object sender, EventArgs e)
        {
            if (txtName.Text!="" && txtMobile.Text != "" && txtAddress.Text != "" && txtUserName.Text != "" && txtPassword.Text != "")
            {
                q = "insert into Login(Name,Mobile,Address,UserName,Password) values('" + txtName.Text + "','" + txtMobile.Text + "','" + txtAddress.Text + "','" + txtUserName.Text + "','" + txtPassword.Text + "')";
                fn.setData(q,"Admin Inserted Successfuly.");
                UC_AddAdmin_Load(this,null);
                clearall();
            }
            else
            {
                MessageBox.Show("Please Fill All Data","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                clearall();
            }
        }

        public void clearall()
        {
            txtName.Clear();
            txtMobile.Clear();
            txtAddress.Clear();
            txtUserName.Clear();
            txtPassword.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtMobile.Text != "" && txtAddress.Text != "" && txtUserName.Text != "" && txtPassword.Text != "")
            {
                q = "update  Login set Name='" + txtName.Text + "',Mobile='" + txtMobile.Text + "',Address='" + txtAddress.Text + "',UserName='" + txtUserName.Text + "',Password='" + txtPassword.Text + "' where Id=" + Id + "";
                fn.setData(q, "Update Successfuly");
                UC_AddAdmin_Load(this, null);
                clearall();
            }
            else
            {
                MessageBox.Show("Please Select A Record Which You Want To Update", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearall();
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        int Id;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                if (row.Cells["Id"].Value.ToString()!="")
                {
                Id =int.Parse(row.Cells["Id"].Value.ToString());
                }
                txtName.Text = row.Cells["Name"].Value.ToString();
                txtMobile.Text = row.Cells["Mobile"].Value.ToString();
                txtAddress.Text = row.Cells["Address"].Value.ToString();
                txtUserName.Text = row.Cells["UserName"].Value.ToString();
                txtPassword.Text = row.Cells["Password"].Value.ToString();

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtMobile.Text != "" && txtAddress.Text != "" && txtUserName.Text != "" && txtPassword.Text != "")
            {
                if (MessageBox.Show("Are You Sure?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    q = "delete from Login where Id=" + Id + "";
                    fn.setData(q, "Delete Successfuly.");
                    UC_AddAdmin_Load(this, null);
                    clearall();
                }
            }
            else
            {
                MessageBox.Show("Please Select A Record Which You Want To Delete", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearall();
            }

        }
    }
}
