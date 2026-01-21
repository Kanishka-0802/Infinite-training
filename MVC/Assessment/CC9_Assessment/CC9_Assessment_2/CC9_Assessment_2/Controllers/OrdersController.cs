using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CC9_Assessment_2.Controllers
{
    public class OrdersController : Controller
    {
        public async Task<ActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44304/");
                var response = await client.GetAsync("api/orders/by-employee/5");


                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsAsync<List<Order>>();
                    return View(data);
                }
            }
            return View(new List<Order>());
        }
    }

}