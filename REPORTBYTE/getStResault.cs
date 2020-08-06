using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace REPORTBYTE
{
    class getStResault
    {
        public string getmark(int stId, int subId)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SHATTER\source\repos\REPORTBYTE\repoBite.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "SELECT Marks FROM MARKS WHERE Student_Id = " + stId + " AND Subject_Id = " + subId;
            SqlCommand cmd1 = new SqlCommand(query, con);
            con.Open();
            using (SqlDataReader reader = cmd1.ExecuteReader())
            {
                if (reader.Read())
                {
                    return Convert.ToString(reader["Marks"]);
                }
            }
            return "";
        }

        public string[] getStudentResault(int index)
        {
            string[] report = new string[17];
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SHATTER\source\repos\REPORTBYTE\repoBite.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "SELECT * FROM Students WHERE Index_No = " + index;
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    report[0] = Convert.ToString(reader["Index_No"]);
                    report[1] = Convert.ToString(reader["Name"]);
                    report[2] = Convert.ToString(reader["Total_Marks"]);
                    report[3] = Convert.ToString(reader["Average"]);
                    report[4] = Convert.ToString(reader["Position"]);
                    if(report[2]=="")
                    {
                        report[2] = "N/A";
                    }
                    if (report[3] == "")
                    {
                        report[3] = "N/A";
                    }
                    if (report[4] == "")
                    {
                        report[4] = "N/A";
                    }
                }
            }
            report[5] = getmark(index, 1);
            report[6] = getmark(index, 2);
            report[7] = getmark(index, 3);
            report[8] = getmark(index, 4);
            report[9] = getmark(index, 5);
            report[10] = getmark(index, 6);
            report[11] = getmark(index, 7);
            report[12] = getmark(index, 8);
            report[13] = getmark(index, 9);
            report[14] = getmark(index, 10);
            report[15] = getmark(index, 11);
            report[16] = getmark(index, 12);

            con.Close();
            return report;
        }

    }
}
