using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectricBill.Models
{
    public class BillValidator
    {

        public string ValidateUnitsConsumed(int units_Consumed)
        {
            if (units_Consumed < 0)
                return "Given units is invalid";
            return "Valid";
        }
    }
}
