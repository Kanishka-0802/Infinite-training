using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ElectricBill.Models; 

namespace ElectricBill
{
    public partial class LastBill : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (Session["Admin"] == null)
                Response.Redirect("~/Login.aspx");

            
            if (!IsPostBack && Request.QueryString["recent"] != null)
            {
                int n = int.Parse(Request.QueryString["recent"]);
                LoadBills(n);
            }
        }

        protected void btnGet_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtN.Text, out int n) || n <= 0)
            {
                lblMsg.Text = "Enter a valid positive number.";
                return;
            }
            LoadBills(n);
        }

        private void LoadBills(int n)
        {
            var board = new ElectricBoard();
            var bills = board.Generate_N_BillDetails(n);

            gv_Bills.DataSource = bills;
            gv_Bills.DataBind();

            rep_Summary.DataSource = bills;
            rep_Summary.DataBind();
        }
    }
}
