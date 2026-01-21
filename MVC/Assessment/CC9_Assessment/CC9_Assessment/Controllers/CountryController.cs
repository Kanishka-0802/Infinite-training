using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Assessment_1.Models;



namespace Assessment_1.Controllers
{
    public class CountryController : ApiController
    {
        
        private static List<Country> countries = new List<Country>
        {
            new Country { ID = 101, CountryName = "India", Capital = "New Delhi" },
            new Country { ID = 102, CountryName = "Japan", Capital = "Tokyo" },
            new Country { ID = 103, CountryName = "France", Capital = "Paris" }
        };

        
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(countries);
        }

        
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null)
                return NotFound();

            return Ok(country);
        }

        
        [HttpPost]
        public IHttpActionResult Post([FromBody] Country country)
        {
            if (country == null)
                return BadRequest("Invalid data.");

            countries.Add(country);
            return Created($"api/Country/{country.ID}", country);
        }

        
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] Country update_country)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null)
                return NotFound();

            country.CountryName = update_country.CountryName;
            country.Capital = update_country.Capital;

            return Ok(country);
        }

     
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null)
                return NotFound();

            countries.Remove(country);
            return Ok();
        }
    }
}

