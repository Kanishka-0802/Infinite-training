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
            int units = ebill.UnitsConsumed;
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

            ebill.BillAmount = amount;
        }

        public void AddBill(Electric_Bill ebill)
        {
            DataBaseHandler db = new DataBaseHandler();
            using (SqlConnection con = db.GetConnection())
            {
                con.Open();
                string query = @"insert into ElectricityBill
                                 (consumer_number, consumer_name, units_consumed, bill_amount)
                                 VALUES (@num, @name, @units, @amount)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@num", ebill.ConsumerNumber);
                    cmd.Parameters.AddWithValue("@name", ebill.ConsumerName);
                    cmd.Parameters.AddWithValue("@units", ebill.UnitsConsumed);
                    cmd.Parameters.AddWithValue("@amount", ebill.BillAmount);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Electric_Bill> Generate_N_BillDetails(int num)
        {
            List<Electric_Bill> bills = new List<Electric_Bill>();
            DataBaseHandler db = new DataBaseHandler();
            using (SqlConnection con = db.GetConnection())
            {
                con.Open();
                string query = $"SELECT TOP (@n) consumer_number, consumer_name, units_consumed, bill_amount " +
                               "FROM ElectricityBill ORDER BY consumer_number DESC";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@n", num);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var eb = new Electric_Bill
                            {
                                ConsumerNumber = reader["consumer_number"].ToString(),
                                ConsumerName = reader["consumer_name"].ToString(),
                                UnitsConsumed = Convert.ToInt32(reader["units_consumed"]),
                                BillAmount = Convert.ToDouble(reader["bill_amount"])
                            };
                            bills.Add(eb);
                        }
                    }
                }
            }
            return bills;
        }
    }
}
