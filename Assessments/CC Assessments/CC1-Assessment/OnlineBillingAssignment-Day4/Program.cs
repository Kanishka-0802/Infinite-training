using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBillingAssignment_Day4
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("=== Online Utility Billing System ===");
            Console.Write("Enter number of customers: ");
            int customerCount = Convert.ToInt32(Console.ReadLine());
            int readingCount = 3;
            for (int i = 0; i < customerCount; i++)
            {
                Console.WriteLine($"\nEnter Details for Customer {i + 1} ");

                Console.Write("Enter Customer ID: ");
                int id = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Customer Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter number of readings: ");
              
                int[] readings = new int[readingCount];
                for (int j = 0; j < readingCount; j++)
                {
                    readings[j] = Convert.ToInt32(Console.ReadLine());
                }
            
                Customer customer = new Customer(id,name);
                customer.CalculateBill(out decimal total, out decimal tax, out decimal netPayable,readings);
                customer.DisplayBillingDetails(total, tax, netPayable);
            }

            Console.WriteLine("\n=== All Customer Bills proceeded Successfully! ===");
            Console.ReadLine();
        
    }
    }
}
