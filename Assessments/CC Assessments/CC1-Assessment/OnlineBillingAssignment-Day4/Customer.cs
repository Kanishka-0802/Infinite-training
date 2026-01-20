using System;

namespace OnlineBillingAssignment_Day4
{
    internal class Customer
    {
        public int CustomerID;
        public string CustomerName;
        public decimal units = 6.53m;

        public Customer(int customerID, string customerName)
        {
            CustomerID = customerID;
            CustomerName = customerName;
        }
        private decimal TotalUsage(params int[] readings)
        {
            int total = 0;
            foreach (int reading in readings)
            {
                total += reading;
            }
            return total;
        }
        public static int GetServiceCharge()
        {
            return 50;
        }

        public void CalculateBill(out decimal total, out decimal tax, out decimal netPayable, params int[] readings)
        {
            decimal usage = TotalUsage(readings);
            total = usage * units;
            tax = total * 0.10m;
            netPayable = total + tax + GetServiceCharge();
        }


        public void DisplayBillingDetails(decimal total, decimal tax, decimal netPayable)
        {
            Console.WriteLine("\n========== Utility Bill System ==========");
            Console.WriteLine($"Customer ID       : {CustomerID}");
            Console.WriteLine($"Customer Name     : {CustomerName}");
            Console.WriteLine($"Rate per Unit     : {units:F2}");
            Console.WriteLine($"Service Charge    : {GetServiceCharge():F2}");
            Console.WriteLine($"Total Usage Cost  : {total:F2}");
            Console.WriteLine($"Tax (10%)         : {tax:F2}");
            Console.WriteLine($"Net Payable       : {netPayable:F2}");
            Console.WriteLine("==================================");
        }
    }
}
