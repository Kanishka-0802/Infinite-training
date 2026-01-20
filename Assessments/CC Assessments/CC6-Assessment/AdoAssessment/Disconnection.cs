using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoAssessment
{
    internal class Disconnection
    {
        SqlConnection con = new SqlConnection("Integrated Security = true; Database = master; Server = (localdb)\\MSSQLLocalDB");
        SqlDataAdapter da_stud;
        SqlDataAdapter da_course;
        SqlDataAdapter da_enroll;
        DataSet ds = new DataSet();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        



        //Task 3.1 – Load Students and Courses into a DataSet
        //Show the data in tabular format.
        public void loaddata()
        {
            da_stud = new SqlDataAdapter("select * from students_A", con);
            SqlCommandBuilder sb = new SqlCommandBuilder(da_stud);
            da_stud.Fill(ds, "stud");
            dt1 = ds.Tables["stud"];
            Console.WriteLine("--------------Student_Records------------");
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                Console.WriteLine(dt1.Rows[i][0]);
                Console.WriteLine(dt1.Rows[i][1]);
                Console.WriteLine(dt1.Rows[i][2]);
                Console.WriteLine(dt1.Rows[i][3]);
                Console.WriteLine(dt1.Rows[i][4]);
                Console.WriteLine("-------------------------------------");
            }
            da_course = new SqlDataAdapter("select * from courses_A", con);
            SqlCommandBuilder cbCourses = new SqlCommandBuilder(da_course);
            da_course.Fill(ds, "course");
            dt2 = ds.Tables["course"];
            Console.WriteLine("--------------Course_Records------------");
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                Console.WriteLine(dt2.Rows[i][0]);
                Console.WriteLine(dt2.Rows[i][1]);
                Console.WriteLine(dt2.Rows[i][2]);
                Console.WriteLine(dt2.Rows[i][3]);
                Console.WriteLine("-------------------------------------");
            }

        }


        // Task 3.2 – Modify course credits(Disconnected Mode)
        //Steps: 
        //1. Load Courses into DataSet 
        //2. Ask user for CourseId 
        //3. Update Credits 
        //4. Use SqlCommandBuilder to update DB



        public void modifycourse()
        {
            da_course = new SqlDataAdapter("select * from courses_A", con);
            SqlCommandBuilder cbCourses = new SqlCommandBuilder(da_course);
            da_course.Fill(ds, "course");
            DataTable dt2 = ds.Tables["course"];
            Console.WriteLine("------------------ Courses_table ------------------");
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                Console.WriteLine(dt2.Rows[i][0]);
                Console.WriteLine(dt2.Rows[i][1]);
                Console.WriteLine(dt2.Rows[i][2]);
                Console.WriteLine(dt2.Rows[i][3]);
                Console.WriteLine("-------------------------------------");
            }

            Console.Write("Enter courseid to update: ");
            int course_Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter new credit value: ");
            int new_credit = Convert.ToInt32(Console.ReadLine());
            DataRow[] rows = dt2.Select($"courseid = {course_Id}");
            if (rows.Length > 0)
            {
                rows[0]["credits"] = new_credit;
                Console.WriteLine("credits updated");
            }
            else
            {
                Console.WriteLine("courseid not found.");

            }
            da_course.Update(ds, "course");


        }



        //Task 3.3 – Insert a new course(Disconnected Mode)
        //Add new row → Update DB.

        public void insertcourse()
        {
            da_course = new SqlDataAdapter("select * from courses_A", con);
            SqlCommandBuilder sb = new SqlCommandBuilder(da_course);
            da_course.Fill(ds, "course");
            DataTable dt = ds.Tables["course"];
            DataRow newRow = dt.NewRow();
            Console.Write("Enter coursename: ");
            string cname = Console.ReadLine();
            Console.Write("Enter credits: ");
            int credits = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Semester: ");
            string semester = Console.ReadLine();
            newRow["coursename"] = cname;
            newRow["credits"] = credits;
            newRow["semester"] = semester;

            dt.Rows.Add(newRow);

            da_course.Update(ds, "course");

            Console.WriteLine("inserted");
        }

        //        Task 3.4 – Delete a student(Disconnected Mode)
        //Delete student record inside DataTable.

        public void Delete()
        {

            da_stud = new SqlDataAdapter("select * from students_A", con);
            da_stud.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            SqlCommandBuilder sb = new SqlCommandBuilder(da_stud);
            da_stud.Fill(dt1);
            Console.WriteLine("Enter the studentid:");
            int id = int.Parse(Console.ReadLine());
            DataRow drr = dt1.Rows.Find(id);
            drr.Delete();
            int rowsaffected = da_stud.Update(dt1);
            Console.WriteLine("Total rows deleted: " + rowsaffected);
        }

    




        // Stored Procedure 
        //        Call stored procedure: 
        //usp_GetCoursesBySemester @semester

        public void Courses()
        {
            SqlCommand cmd = new SqlCommand("usp_1", con);
            cmd.CommandType = CommandType.StoredProcedure;
            Console.Write("Enter semester (semester 3) : ");
            string sem = Console.ReadLine();
            cmd.Parameters.AddWithValue("@sem", sem);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "courses_A");
            Console.WriteLine("----------- Courses ----------");
            DataTable dt2 = ds.Tables["courses_A"];
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                Console.WriteLine(dt2.Rows[i][0]);
                Console.WriteLine(dt2.Rows[i][1]);
                Console.WriteLine(dt2.Rows[i][2]);
                Console.WriteLine(dt2.Rows[i][3]);
                Console.WriteLine("-------------------------------------");
            }
        }

    }
}
