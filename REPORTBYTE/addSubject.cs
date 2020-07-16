using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace REPORTBYTE
{
    class addSubject
    {
        public String addSub(int sub , string name)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SHATTER\source\repos\REPORTBYTE\repoBite.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "UPDATE Subject SET Subject_Teacher = '" + name + "' WHERE Subject_Id =  '" + sub + "'";
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return "Added Succesfull......";
            }
            catch (SqlException ex)
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
