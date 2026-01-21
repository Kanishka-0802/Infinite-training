using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CC9_Assessment_2.Controllers
{
    public class OrderController : ApiController
    {
        private readonly NorthwindEntities db  = new NorthwindEntities();

        [HttpGet]
        [Route("api/orders/by-employee/{employeeId}")]
        public IHttpActionResult GetOrdersByEmployee(int employeeId)
        {
            var orders = db.Orders.Where(o => o.EmployeeID == employeeId).ToList();
            return Ok(orders);
        }
    }

}
