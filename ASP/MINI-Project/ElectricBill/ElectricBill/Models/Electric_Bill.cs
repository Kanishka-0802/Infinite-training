using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectricBill.Models
{
    public class Electric_Bill
    {
   
        private string consumer_num;
        private string consumer_name;
        private int units_consumed;
        private double bill_amount;

        public string Consumer_num
        {
            get => consumer_num;
            set
            {
                
                if (string.IsNullOrWhiteSpace(value) || !value.StartsWith("EB") || value.Length != 7)
                    throw new FormatException("Invalid Consumer Number");

                string digits = value.Substring(2);
                if (!int.TryParse(digits, out _))
                    throw new FormatException("Invalid Consumer Number");

                consumer_num = value;
            }
        }

        public string Consumer_name
        {
            get => consumer_name;
            set => consumer_name = value;
        }

        public int Units_consumed
        {
            get => units_consumed;
            set => units_consumed = value;
        }

        public double Bill_amount
        {
            get => bill_amount;
            set => bill_amount = value;
        }
    }
}
