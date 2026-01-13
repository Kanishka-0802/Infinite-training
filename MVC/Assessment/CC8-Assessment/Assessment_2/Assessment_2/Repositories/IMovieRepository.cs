using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assessment_2.Models;


namespace Assessment_2.Repositories
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAll();
        Movie GetById(int id);
        void Add(Movie movie);
        void Update(Movie movie);
        void Delete(int id);
        IEnumerable<Movie> GetmoviesByYear(int year);
        IEnumerable<Movie> GetmoviesByDirector(string director_Name);
    }
}

