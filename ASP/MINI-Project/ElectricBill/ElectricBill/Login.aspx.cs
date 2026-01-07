using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ElectricBill
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
           
            if (txtUser.Text == "admin" && txtPass.Text == "12345678")
            {
                Session["Admin"] = true;
                Response.Redirect("~/Billing.aspx"); 
            }
            else
            {
                lblMsg.Text = "Invalid username or password";
            }
        }
    }
}
