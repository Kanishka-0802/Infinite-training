using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ElectricBill.Models
{
    public class ElectricBoard
    {
    
        public void CalculateBill(Electric_Bill ebill)
        {
            int units = ebill.Units_consumed;
            double amount = 0;

            if (units <= 100)
            {
                amount = 0;
            }
            else if (units <= 300)
            {
                amount = (units - 100) * 1.5;
            }
            else if (units <= 600)
            {
                amount = (200 * 1.5) + (units - 300) * 3.5;
            }
            else if (units <= 1000)
            {
                amount = (200 * 1.5) + (300 * 3.5) + (units - 600) * 5.5;
            }
            else
            {
                amount = (200 * 1.5) + (300 * 3.5) + (400 * 5.5) + (units - 1000) * 7.5;
            }

            ebill.Bill_amount = amount;
        }

        public void AddBill(Electric_Bill ebill)
        {
            DataBaseHandler db = new DataBaseHandler();
            SqlConnection con = db.GetConnection();
                con.Open();
                string query = @"insert into ElectricityBill
                                 (consumer_number, consumer_name, units_consumed, bill_amount)
                                 values (@num, @name, @units, @amount)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@num", ebill.Consumer_num);
                    cmd.Parameters.AddWithValue("@name", ebill.Consumer_name);
                    cmd.Parameters.AddWithValue("@units", ebill.Units_consumed);
                    cmd.Parameters.AddWithValue("@amount", ebill.Bill_amount);
                    cmd.ExecuteNonQuery();
               
            }
        }

        public List<Electric_Bill> Generate_N_Bill(int num)
        {
            List<Electric_Bill> bills = new List<Electric_Bill>();
            DataBaseHandler db = new DataBaseHandler();
            SqlConnection con = db.GetConnection();
               con.Open();
                string query = $"select top (@n) consumer_number, consumer_name, units_consumed, bill_amount " +
                               "from ElectricityBill order by consumer_number desc";
            SqlCommand cmd = new SqlCommand(query, con);
                
                    cmd.Parameters.AddWithValue("@n", num);
                SqlDataReader reader = cmd.ExecuteReader();
                    
                        while (reader.Read())
                        {
                            var eb = new Electric_Bill
                            {
                                Consumer_num = reader["consumer_number"].ToString(),
                                Consumer_name = reader["consumer_name"].ToString(),
                                Units_consumed = Convert.ToInt32(reader["units_consumed"]),
                                Bill_amount = Convert.ToDouble(reader["bill_amount"])
                            };
                            bills.Add(eb);
                        }
                   
            
            return bills;
        }
    }
}
