using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace REPORTBYTE
{
    class updateStudent
    {
        public void getvalues()
        {
            
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SHATTER\source\repos\REPORTBYTE\repoBite.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            con.Open();
            string query = "SELECT * FROM Students";
            SqlCommand cmd = new SqlCommand(query, con);
            adapter.SelectCommand = cmd;
            adapter.Fill(ds, "Name");
            int rowCount =  ds.Tables[0].Rows.Count;
            
            for (int i=0; i<=rowCount; i++)
            {
                int tot = 0;

                for (int k = 0; k < 13; k++)
                {
                    string query2 = "SELECT Marks FROM MARKS WHERE Student_Id = " + i + " AND Subject_Id = " + k;
                    SqlCommand cmd2 = new SqlCommand(query2, con);
             
                    using (SqlDataReader reader = cmd2.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tot += Convert.ToInt32(reader["Marks"]);
                        }
                    }
                }
                double avg = Math.Round((tot / 12.0), 3);
                string query1 = "UPDATE Students SET Total_Marks = "+ tot + ", Average = " + avg + " WHERE Index_No = " + i;
                SqlCommand cmd1 = new SqlCommand(query1, con);
                    cmd1.ExecuteNonQuery();
            }

            con.Close();

        }


        

        public void setPosition()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SHATTER\source\repos\REPORTBYTE\repoBite.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            string query = "SELECT * FROM Students";
            SqlCommand cmd = new SqlCommand(query, con);
            adapter.SelectCommand = cmd;
            adapter.Fill(ds, "Name");
            int rowCount = ds.Tables[0].Rows.Count;

            Dictionary<int, double> dict = new Dictionary<int, double>();
            Dictionary<int, double> dict_Sorted = new Dictionary<int, double>();

            for (int i=0; i<=rowCount; i++)
            {
                string query1 = "SELECT Average FROM Students WHERE Index_No = " + i;
                SqlCommand cmd1 = new SqlCommand(query1, con);
                using (SqlDataReader reader = cmd1.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        dict.Add(i, Convert.ToDouble(reader["Average"]));
                    }
                }
            }

            foreach (KeyValuePair<int, double> author in dict.OrderByDescending(key => key.Value))
            {
                dict_Sorted.Add(author.Key, author.Value);
            }

            int k = 1;
            foreach (KeyValuePair<int, double> item in dict_Sorted)
            {
                string query2 = "UPDATE Position SET [Index] = " + item.Key + ", Average = " + item.Value + " WHERE Position = " +k;
                SqlCommand cmd2 = new SqlCommand(query2, con);
                cmd2.ExecuteNonQuery();
                k++;
            }

       
            for (int i = 0; i <= rowCount; i++)
            {
                int position;
                string query3 = "SELECT Position FROM Position WHERE [Index] = " + i;
                SqlCommand cmd3 = new SqlCommand(query3, con);
                using (SqlDataReader reader = cmd3.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        position = Convert.ToInt32(reader["Position"]);
                        string query4 = "UPDATE Students SET Position = " + position + " WHERE Index_No = " + i;
                        SqlCommand cmd4 = new SqlCommand(query4, con);
                        reader.Close();
                        cmd4.ExecuteNonQuery();
                    }
                }
            }

            con.Close();
        }



    }
}
