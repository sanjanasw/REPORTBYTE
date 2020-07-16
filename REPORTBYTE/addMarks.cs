using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace REPORTBYTE
{
    class addMarks
    {
        public String addMark(int subject_id, int student_id, int marks)
        {

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SHATTER\source\repos\REPORTBYTE\repoBite.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "Insert into Marks(Student_Id,Subject_Id,Marks) values ('" + student_id + "','" + subject_id + "','" + marks + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            string query1 = "UPDATE Students SET Sub" + subject_id + " = " + marks + " WHERE Index_No = " + student_id;
            SqlCommand cmd1 = new SqlCommand(query1, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
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
