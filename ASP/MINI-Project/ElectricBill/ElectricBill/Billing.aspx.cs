using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ElectricBill.Models;

namespace ElectricBill
{
    public partial class Billing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (Session["Admin"] == null)
                Response.Redirect("~/Login.aspx");
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var eb = new Electric_Bill();
                eb.ConsumerNumber = txtConsumerNumber.Text.Trim();
                eb.ConsumerName = txtConsumerName.Text.Trim();

                if (!int.TryParse(txtUnits.Text, out int units))
                {
                    lblStatus.Text = "Units must be a number.";
                    return;
                }

                var validator = new BillValidator();
                string validation = validator.ValidateUnitsConsumed(units);
                if (validation != "Valid")
                {
                    lblStatus.Text = validation;
                    return;
                }

                eb.UnitsConsumed = units;

                var board = new ElectricBoard();
                board.CalculateBill(eb);
                board.AddBill(eb);

                Response.Redirect("~/LastBill.aspx?recent=1");
            }
            catch (FormatException ex)
            {
                lblStatus.Text = ex.Message; 
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error: " + ex.Message;
            }
        }
    }
}
