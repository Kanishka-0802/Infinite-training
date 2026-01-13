using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Assessment_2.Models;

namespace Assessment_2.Repositories
{
 
        public class MovieRepository : IMovieRepository
        {
            private readonly MoviesDbContext context = new MoviesDbContext();

            public IEnumerable<Movie> GetAll() => context.Movies.ToList();

            public Movie GetById(int id) => context.Movies.Find(id);

            public void Add(Movie movie)
            {
                context.Movies.Add(movie);
                context.SaveChanges();
            }

            public void Update(Movie movie)
            {
                context.Entry(movie).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }

            public void Delete(int id)
            {
                var movie = context.Movies.Find(id);
                if (movie != null)
                {
                    context.Movies.Remove(movie);
                    context.SaveChanges();
                }
            }

            public IEnumerable<Movie> GetmoviesByYear(int year) =>
                context.Movies.Where(m => m.dateof_Release.Year == year).ToList();

            public IEnumerable<Movie> GetmoviesByDirector(string directorName) =>
                context.Movies.Where(m => m.director_name == directorName).ToList();
        }
    }

