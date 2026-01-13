using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Assessment_2.Models
{
    public class Movie
    {
        [Key]
        public int mid { get; set; } 
        public string movie_name { get; set; } 
        public string director_name { get; set; } 
        public DateTime dateof_Release { get; set; } 
    }
}