using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics.SymbolStore;

namespace REPORTBYTE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            tableHome.Visible = true;
            tableAbout.Visible = false;
            tableSettings.Visible = false;
            InsertPanel.Visible = true;
            viewPanel.Visible = false;
            printPanel.Visible = false;
            indiInsert.Visible = true;
            indiView.Visible = false;
            indiPrint.Visible = false;
            panel3.Visible = false;
            panel2.Visible = true;
            panelStudentIndi.Visible = false;
            panelTeacherIndi.Visible = false;
            panelMarksIndi.Visible = true;
            tableLayoutPanelStudent.Visible = false;
            tableLayoutPanelTeacher.Visible = false;
            tableLayoutPanelMarks.Visible = true;
            panelAllResults.Visible = true;
            panelStudentResults.Visible = false;
            label49.Visible = false;
        }

        Bitmap bmp;

        public async void timer(string error)
        {
            label49.Text = "   " + Convert.ToString(error);
            label49.Visible = true;

            await Task.Delay(5000);

            label49.Text = "";
            label49.Visible = false;
        }


        private void buttonLastest1_Click_1(object sender, EventArgs e)
        {
            InsertPanel.Visible = true;
            viewPanel.Visible = false;
            printPanel.Visible = false;
            indiInsert.Visible = true;
            indiView.Visible = false;
            indiPrint.Visible = false;
        }

        private void buttonLastest2_Click(object sender, EventArgs e)
        {
            viewPanel.Visible = true;
            InsertPanel.Visible = false;
            printPanel.Visible = false;
            indiInsert.Visible = false;
            indiView.Visible = true;
            indiPrint.Visible = false;

            updateStudent upst = new updateStudent();
            upst.getvalues();
            upst.setPosition();

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SHATTER\source\repos\REPORTBYTE\repoBite.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();

            string query = "SELECT Index_No, Name, Position, Sub1, Sub2, Sub3, Sub4, Sub5, Sub6, Sub7, Sub8, Sub9, Sub10, Sub11, Sub12, Total_Marks, Average  FROM Students";
            SqlDataAdapter adaptor = new SqlDataAdapter(query, con);
            DataSet set = new DataSet();

            adaptor.Fill(set, "Students");
            dataGridView1.DataSource = set.Tables["Students"];
            //SqlCommandBuilder builder = new SqlCommandBuilder(adaptor);
            adaptor.Update(set.Tables["Students"]);
            con.Close();



        }

        private void buttonLastest3_Click_1(object sender, EventArgs e)
        {
            printPanel.Visible = true;
            InsertPanel.Visible = false;
            viewPanel.Visible = false;
            indiInsert.Visible = false;
            indiView.Visible = false;
            indiPrint.Visible = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            tableHome.Visible = false;
            tableAbout.Visible = false;
            tableSettings.Visible = true;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            tableHome.Visible = false;
            tableAbout.Visible = true;
            tableSettings.Visible = false;
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            tableHome.Visible = true;
            tableAbout.Visible = false;
            tableSettings.Visible = false;
            timer("Settings Updated Sucessfull!!!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tableHome.Visible = true;
            tableAbout.Visible = false;
            tableSettings.Visible = false;
        }

        private void buttonLastest7_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel2.Visible = true;
            panelAllResults.Visible = true;
            panelStudentResults.Visible = false;

        }

        private void buttonLastest8_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = true;
            panelAllResults.Visible = false;
            panelStudentResults.Visible = true;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: This line of code loads data into the 'repoBiteDataSet1.Students' table. You can move, or remove it, as needed.
                this.studentsTableAdapter.Fill(this.repoBiteDataSet1.Students);
                // TODO: This line of code loads data into the 'repoBiteDataSet.Subject' table. You can move, or remove it, as needed.
                this.subjectTableAdapter.Fill(this.repoBiteDataSet.Subject);

                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SHATTER\source\repos\REPORTBYTE\repoBite.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();

                string query1 = "SELECT TOP 1 Index_No FROM Students ORDER BY Index_No DESC";
                SqlCommand cmd1 = new SqlCommand(query1, con);
                using (SqlDataReader reader = cmd1.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        label2.Text =  Convert.ToString(Convert.ToInt32(reader["Index_No"])+1);
                    }
                    else
                    {
                        label2.Text = "1";
                    }
                }
                con.Close();

            }
            catch(Exception ex)
            {
                timer(Convert.ToString(ex));
            }
            

        }
    
    private void buttonLastest4_Click(object sender, EventArgs e)
        {
            panelStudentIndi.Visible = true;
            panelTeacherIndi.Visible = false;
            panelMarksIndi.Visible = false;
            tableLayoutPanelStudent.Visible = true;
            tableLayoutPanelTeacher.Visible = false;
            tableLayoutPanelMarks.Visible = false;
        }

        private void buttonLastest5_Click(object sender, EventArgs e)
        {
            panelStudentIndi.Visible = false;
            panelTeacherIndi.Visible = true;
            panelMarksIndi.Visible = false;
            tableLayoutPanelStudent.Visible = false;
            tableLayoutPanelTeacher.Visible = true;
            tableLayoutPanelMarks.Visible = false;
        }

        private void buttonLastest6_Click(object sender, EventArgs e)
        {
            panelStudentIndi.Visible = false;
            panelTeacherIndi.Visible = false;
            panelMarksIndi.Visible = true;
            tableLayoutPanelStudent.Visible = false;
            tableLayoutPanelTeacher.Visible = false;
            tableLayoutPanelMarks.Visible = true;
        }

        private void buttonLastest9_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox1.Text;
                addStudent std = new addStudent();
                if (name == "")
                {
                    timer("Name Can't Be Nulled!!!");
                }
                else
                {
                    timer(std.addSt(name));
                }
            }            
            catch (Exception ex)
            {
                timer(Convert.ToString(ex));
            }
        }

        private void buttonLastest10_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox2.Text;
                addSubject sub = new addSubject();
                if (name == "")
                {
                    timer("Name Can't Be Nulled!!!");
                }
                else
                {
                    timer(sub.addSub(comboBox1.SelectedIndex + 1, name));
                }
            }
            catch (Exception ex)
            {
                timer(Convert.ToString(ex));
            }

        }

        private void buttonLastest11_Click(object sender, EventArgs e)
        {
            try
            {
                int marks = Convert.ToInt32(textBox3.Text);
                if (marks > 100 || marks < 0)
                {
                    timer("Please Enter Correct Mark......");
                }
                else
                {
                    try
                    {
                        addMarks mark = new addMarks();
                        timer(mark.addMark((comboBox2.SelectedIndex + 1), (comboBox3.SelectedIndex + 1), Convert.ToInt32(textBox3.Text)));
                    }
                    catch (System.FormatException)
                    {
                        timer("Please Enter Correct Input Format......");
                    }
                    catch (Exception ex)
                    {
                        timer(Convert.ToString(ex));
                    }
                }
            }
            catch (Exception)
            {
                timer("Marks Can't Be Nulled!!!");
            }

        }

        private void buttonLastest12_Click(object sender, EventArgs e)
        {
            buttonLastest1.Visible = false;
            buttonLastest2.Visible = false;
            buttonLastest3.Visible = false;
            buttonLastest7.Visible = false;
            buttonLastest17.Visible = false;

            Panel panel1 = new Panel();
            this.Controls.Add(panel1);
            
            Graphics g = panel1.CreateGraphics();
            Size formSize = this.ClientSize;
            bmp = new Bitmap(formSize.Width, formSize.Height, g);
            //bmp = new Bitmap(printPanel.Size.Width, printPanel.Size.Width, g);
            Graphics mg = Graphics.FromImage(bmp);
            mg.CopyFromScreen(panel1.Location.X, panel1.Location.Y, 0, 0, formSize);
            printPreviewDialog1.ShowDialog();

            buttonLastest1.Visible = true;
            buttonLastest2.Visible = true;
            buttonLastest3.Visible = true;
            buttonLastest7.Visible = true;
            buttonLastest17.Visible = true;

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        private void st_tech()
        {
            
        }

        private void buttonLastest17_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel2.Visible = false;
            panelAllResults.Visible = false;
            panelStudentResults.Visible = true;
        }

        private void buttonLastest16_Click(object sender, EventArgs e)
        {
            try
            {
                string[] data = new string[17];
                getStResault gst = new getStResault();
                data = gst.getStudentResault(int.Parse(textBox4.Text));

                label9.Text = "Name : " + data[1];
                label10.Text = "Index No: " + data[0];
                label47.Text = "Average : " + data[3];
                label48.Text = "Position : " + data[4];
                label13.Text = data[5];
                label16.Text = data[6];
                label19.Text = data[7];
                label22.Text = data[8];
                label25.Text = data[9];
                label28.Text = data[10];
                label31.Text = data[11];
                label34.Text = data[12];
                label37.Text = data[13];
                label40.Text = data[14];
                label43.Text = data[15];
                label46.Text = data[16];

            }
            catch(Exception ex)
            {
                timer(Convert.ToString(ex));
            }
        }

        private void buttonLastest15_Click(object sender, EventArgs e)
        {
            updateStudent upst = new updateStudent();
            upst.getvalues();
            upst.setPosition();

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SHATTER\source\repos\REPORTBYTE\repoBite.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();

            //get value from teacher name. pass value +1 to get marks
            int value = comboBox4.SelectedIndex+1;

            string query = "SELECT Index_No, Name, Sub" + value + ",Position  FROM Students";
            SqlDataAdapter adaptor = new SqlDataAdapter(query, con);
            DataSet set = new DataSet();

            try
            {
                adaptor.Fill(set, "Students");
                dataGridView2.DataSource = set.Tables["Students"];
                adaptor.Update(set.Tables["Students"]);
                con.Close();

            }catch(Exception ex)
            {
                timer(Convert.ToString(ex));
            }
        }

        private void buttonLastest13_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are You Sure To Reset All Yes/No", "Reset", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                delData del = new delData();
                del.delStudent();
            }
        }

        private void buttonLastest14_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are You Sure To Reset All Yes/No", "Reset", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                delData del = new delData();
                del.delTeacher();
            }
        }

    }
}