using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Assessment_2.Models
{
   

   
        public class MoviesDbContext : DbContext
        {
            public MoviesDbContext() : base("MoviesDB") { }

            public DbSet<Movie> Movies { get; set; }
        }
    }

