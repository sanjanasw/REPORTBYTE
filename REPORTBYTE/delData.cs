using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace REPORTBYTE
{
    class delData
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SHATTER\source\repos\REPORTBYTE\repoBite.mdf;Integrated Security=True;Connect Timeout=30");

        public void delStudent()
        {
            string query = "DELETE FROM Students";
            SqlCommand cmd = new SqlCommand(query, con);
            string query1 = "DELETE FROM Marks";
            SqlCommand cmd1 = new SqlCommand(query1, con);
            string query2 = "DELETE FROM Position";
            SqlCommand cmd2 = new SqlCommand(query2, con);
            cmd.ExecuteNonQuery();
            cmd1.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
        }

        public void delTeacher()
        {
            string query = "DELETE FROM subject WHERE Subject_Teacher";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
        }

        
    }
}
