using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoAssessment
{
    internal class Connections
    {
        SqlConnection con = new SqlConnection("Integrated Security = true; Database = master; Server = (localdb)\\MSSQLLocalDB");


        //Task 2.1 – Display all courses 
        //Show: CourseId, CourseName, Credits, Semester
        public void showcourses()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from courses_A", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine($"{dr["courseid"]}   {dr["coursename"]}   {dr["credits"]}   {dr["semester"]}  ");
            }
            con.Close();
        }
        //Task 2.2 – Add a new student
        //Input: 
        //• FullName 
        //• Email 
        //• Department 
        //• YearOfStudy
        //Insert via parameterized query.

        public void insertstudent()
        {
            SqlTransaction tr = null;

            try
            {
                con.Open();

                tr = con.BeginTransaction();


                Console.Write("Enter StudentName: ");
                string Name = Console.ReadLine();

                Console.Write("Enter Email: ");
                string email = Console.ReadLine();

                Console.Write("Enter Dept : ");
                string dept = Console.ReadLine();

                Console.Write("Enter YearOfStudy :");
                int yr_study = Convert.ToInt32(Console.ReadLine());

                SqlCommand cmd = new SqlCommand(
            $"insert into students_A (fullname, email, department, yearofstudy) " +
            $"values ('{Name}', '{email}', '{dept}', {yr_study})", con, tr);

                int rowaffected = cmd.ExecuteNonQuery();
                Console.WriteLine("Total Records Inserted in student_A: " + rowaffected);
                tr.Commit();
                Console.WriteLine("Transaction committed!");
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                if (tr != null)
                {
                    tr.Rollback();
                    Console.WriteLine("Transaction failed.");
                }
            }
            con.Close();
        }


        //        Task 2.3 – Search students by department
        //Input example: “Computer Science” 
        //Display matching students.


        public void searchstudent()
        {
            Console.Write("Enter Department Name: ");
            string dept = Console.ReadLine();

            con.Open();

            SqlCommand cmd = new SqlCommand(
                "select * from students_A where department = @department", con);
            cmd.Parameters.AddWithValue("@department", dept);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine($"{dr["studentid"]}   {dr["fullname"]}   {dr["email"]}   {dr["department"]}   {dr["yearofstudy"]}");
            }
            dr.Close();
            con.Close();
            }

//        Task 2.4 – Display enrolled courses for a student
//Input: StudentId
//Output example: 
//Course Name | Credits | Enroll Date | Grade
        public void displaycourses()
        {
            Console.Write("Enter Student Id: ");
            int student_Id = Convert.ToInt32(Console.ReadLine());

                con.Open();

                SqlCommand cmd = new SqlCommand(
                    "select c.coursename, c.credits, e.enrolldate, e.grade from enrollments_A e join courses_A c on e.courseid=c.courseid where  e.studentid = @studentid", con);

                cmd.Parameters.AddWithValue("studentid",student_Id);

                SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Console.WriteLine($"{dr["CourseName"]} | {dr["Credits"]} | {dr["EnrollDate"]} | {dr["Grade"]}");
                    }
                }



        //Task 2.5 – Update grade(Connected Mode)
        //Input: 
        //• EnrollmentId 
        //• Grade(A/B/C/D/F)
        //Update Enrollments table.


        public void update()
        {
            Console.Write("Enter Enrollment ID : ");
            int enroll_Id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Grade (A/B/C/D/F): ");
            string grade = Console.ReadLine();
                con.Open();

                SqlCommand cmd = new SqlCommand(
                    $"update enrollments_A  set grade = '{grade}' where enrollmentid = {enroll_Id}", con);

                int rowsAffected = cmd.ExecuteNonQuery();

                Console.WriteLine($"Enrollment rows updated: {rowsAffected}");
            con.Close();
            }
        }
}
