using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieService
{


   public class CsvMovieService : IMovieService
    {
       CsvParser Parsern = new CsvParser();
       List<Movie> Red = new List<Movie>();
       List<Category> Purple = new List<Category>();

       public CsvMovieService()
       {                     
           Parsern.ParseCsv();

           foreach (Movie m in Parsern.GetMovies())
           {
               Red.Add(m);
           }
           foreach (Category c in Parsern.GetCategories())
           {
               Purple.Add(c);
           }
       }


       public IEnumerable<Movie> AllMovies()
       {
          return Red;
       }

       public IEnumerable<Category> AllCategories()
       {
           return Purple;
       }

       public IEnumerable<Movie> MoviesFromCategory(string name)
       {//Shows movies of the selected category
           
           var kategorier = Purple.Where(c => c.Name == name);

           var kategori = kategorier.SingleOrDefault();

           if (kategori != null)
           {
               return kategori.Movies;
           }
           else
           {
               return new List<Movie>();
           }       
       }

       public IEnumerable<Movie> MoviesFromYear(int year)
       {//Shows movies from the selected year
         
           var filmer = Red.Where(movie => movie.YearOfPublication == year);
           return filmer;
       }

       public double AverageRating()
       { //Shows the average rating of all movies in the Csv file. 
        

           var avg = Red.Average(a => a.Rating);
             return avg;
       }


       public IEnumerable<Movie> MoviesAfterYear(int year)
       {//Shows movies released during or after the selected year

           var moviesafter = Red.Where(movie => movie.YearOfPublication >= year);
           return moviesafter;
       }

       public IEnumerable<Movie> AlphabeticalOrder()
       {//A-Z
           var alph = Red.OrderBy(movie => movie.Title);
           return alph;
       }

       public IEnumerable<Movie> LongTitle()
       {//Shows movies with titles over 20 characters, in descending order

           var longtitle = Red.Where(movie => movie.Title.Length > 30).OrderByDescending(movie => movie.Title.Length);
           return longtitle;
       }
    }
}
