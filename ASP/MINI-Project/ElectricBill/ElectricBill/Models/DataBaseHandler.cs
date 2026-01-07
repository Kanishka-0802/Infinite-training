using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ElectricBill.Models
{
    public class DataBaseHandler
    {

        public SqlConnection GetConnection()
        {
            string connStr = ConfigurationManager.ConnectionStrings["ElectricityBillDB"].ConnectionString;
            return new SqlConnection(connStr);
        }
    }
}
