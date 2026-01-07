using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectricBill.Models
{
    public class Electric_Bill
    {
   
        private string consumerNumber;
        private string consumerName;
        private int unitsConsumed;
        private double billAmount;

        public string ConsumerNumber
        {
            get => consumerNumber;
            set
            {
                
                if (string.IsNullOrWhiteSpace(value) || !value.StartsWith("EB") || value.Length != 7)
                    throw new FormatException("Invalid Consumer Number");

                string digits = value.Substring(2);
                if (!int.TryParse(digits, out _))
                    throw new FormatException("Invalid Consumer Number");

                consumerNumber = value;
            }
        }

        public string ConsumerName
        {
            get => consumerName;
            set => consumerName = value;
        }

        public int UnitsConsumed
        {
            get => unitsConsumed;
            set => unitsConsumed = value;
        }

        public double BillAmount
        {
            get => billAmount;
            set => billAmount = value;
        }
    }
}
