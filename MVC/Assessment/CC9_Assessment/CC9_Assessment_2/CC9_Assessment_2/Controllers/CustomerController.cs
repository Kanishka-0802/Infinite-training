using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CC9_Assessment_2.Controllers
{ 
        public class CustomerController : ApiController
        {
            private readonly NorthwindEntities db = new NorthwindEntities();

            [HttpGet]
            [Route("api/customers/by-country/{country}")]
            public IHttpActionResult GetCustomersByCountry(string country)
            {
                var customers = db.GetCustomersByCountry(country).ToList();
                return Ok(customers);
            }
        }


    }

