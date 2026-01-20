using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoAssessment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //------------------Connections----------------------------

            Connections demo = new Connections();
            //demo.showcourses();
            //demo.insertstudent();
            //demo.searchstudent();
            //demo.displaycourses();
            //demo.update();


            //-----------------Disconnections-------------------------------

            Disconnection demo1 = new Disconnection();
            //demo1.loaddata();
            //demo1.modifycourse();
            //demo1.insertcourse();
            demo1.Delete();

            //------------------stored procedure-----------------
            //demo1.Courses();
            Console.ReadLine();


        }
    }
}
