using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieService
{
   public interface IMovieService
    {

       IEnumerable<Movie> AllMovies();
       IEnumerable<Category> AllCategories();
       IEnumerable<Movie> MoviesFromCategory(string name);
       IEnumerable<Movie> MoviesFromYear(int year);
       IEnumerable<Movie> MoviesAfterYear(int year);
       IEnumerable<Movie> AlphabeticalOrder();
       IEnumerable<Movie> LongTitle();
       double AverageRating();
    }
}
