using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Product_Assignment { 
        public partial class Default : System.Web.UI.Page
        {
           
            Dictionary<string, (string ImageUrl, string Price)> products = new Dictionary<string, (string, string)>
        {
            { "Kurthas", ("https://www.bing.com/th/id/OIP.11L4WF6HyirelQGYlYPLLAHaLH?w=160&h=211&c=8&rs=1&qlt=90&o=6&dpr=1.5&pid=3.1&rm=2", "₹1200") },
            { "Jeans", ("https://www.bing.com/th/id/OIP.2oWsDw8XnT0aJ5qo_QAZ5gHaGt?w=238&h=211&c=8&rs=1&qlt=90&o=6&dpr=1.5&pid=3.1&rm=2", "₹2000") },
            { "Sarees", ("https://www.bing.com/th/id/OIP.gtn169HKXaOu9hoKB17MmQHaJ4?w=138&h=211&c=8&rs=1&qlt=90&o=6&dpr=1.5&pid=3.1&rm=2", "₹3500") },
            { "TShirts", ("https://www.bing.com/th/id/OIP.GU1ZFy7t-KIVWCWAc-NrBgHaE7?w=279&h=211&c=8&rs=1&qlt=90&o=6&dpr=1.5&pid=3.1&rm=2", "₹800") }, 
            { "Shoes", ("https://www.bing.com/th/id/OIP.HTPCXU0TOFrfyfqdBkHXsAHaFE?w=281&h=211&c=8&rs=1&qlt=90&o=6&dpr=1.5&pid=3.1&rm=2", "₹2500") }, 
            { "Watches", ("https://www.bing.com/th/id/OIP.HTPCXU0TOFrfyfqdBkHXsAHaFE?w=281&h=211&c=8&rs=1&qlt=90&o=6&dpr=1.5&pid=3.1&rm=2", "₹4000") }, 
            { "Bags", ("https://www.bing.com/th/id/OIP.HTPCXU0TOFrfyfqdBkHXsAHaFE?w=281&h=211&c=8&rs=1&qlt=90&o=6&dpr=1.5&pid=3.1&rm=2", "₹1500") }, 
            { "Jackets", ("https://www.bing.com/th/id/OIP.HTPCXU0TOFrfyfqdBkHXsAHaFE?w=281&h=211&c=8&rs=1&qlt=90&o=6&dpr=1.5&pid=3.1&rm=2", "₹3000") }
        };

            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                 
                    img_Product.ImageUrl = products["Kurthas"].ImageUrl;
                }
            }

            protected void ddl_Product_SelectedIndexChanged(object sender, EventArgs e)
            {
                string selectedProduct = ddl_Product.SelectedValue;
                img_Product.ImageUrl = products[selectedProduct].ImageUrl;
                lblPrice.Text = ""; 
            }

            protected void btnGetPrice_Click(object sender, EventArgs e)
            {
                string selectedProduct = ddl_Product.SelectedValue;
                lblPrice.Text = "Price: " + products[selectedProduct].Price;
            }
        }
   
}