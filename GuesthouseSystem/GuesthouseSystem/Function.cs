using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace GuesthouseSystem
{
    class Function
    {
   
        
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\PROJECT\GuesthouseSystem\GuesthouseSystem\GuestHouse.mdf;Integrated Security=True");
             
            

        

        

        public DataSet getData(String q)
        {

              if (con.State == ConnectionState.Closed)
              {
                  con.Open();
             
              }
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = q;
            con.Close();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public void setData(String q, String message)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = q;
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("'" + message + "'", "Done.", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        public SqlDataReader getForCombo(String q)
        {
             if (con.State == ConnectionState.Closed)
             {
                 con.Open();
             
             }
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd = new SqlCommand(q, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            return sdr;

        }


    }
}
