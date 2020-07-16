using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Drawing;

namespace REPORTBYTE
{
    class addStudent
    {
        public String addSt(string name)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SHATTER\source\repos\REPORTBYTE\repoBite.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "Insert into students(Name) values ('" + name + "')";
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return "Added Succesfull......";
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                return Convert.ToString(ex);
            }
            catch (Exception ex)
            {
                return Convert.ToString(ex);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
