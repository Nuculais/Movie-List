using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieService
{
    public class Movie
    {
        public string Title { get; set; }
        public int YearOfPublication { get; set; }
        public double Rating { get; set; }
        public int NumberOfUserVotes { get; set; }
        public ICollection<Category> Categories { get; set; }
        public Movie()
        {
            Categories = new List<Category>();
        }   
    }


    public class Category
    {
        public string Name { get; set; }
        public ICollection<Movie> Movies { get; set; }
        public Category() 
        {
            Movies = new List<Movie>();
        }
    }




    public class InMemoryMovieService : IMovieService
    {
        public List<Category> Green = new List<Category>();
        public List<Movie> Yellow = new List<Movie>();

        public InMemoryMovieService()
        {
            Category Drama = new Category() { Name = "Drama" };
            Category Erotica = new Category() { Name = "Erotica" };
            Category Documentary = new Category() { Name = "Documentary" };
            Category Comedy = new Category() { Name = "Comedy" };

            Green.Add(Drama);
            Green.Add(Erotica);
            Green.Add(Documentary);
            Green.Add(Comedy);


            Movie Bengt = new Movie() { Title = "Bengt-Göran på Påsklov", YearOfPublication = 1987, Rating = 2.3, NumberOfUserVotes = 5 };
            Movie Fluff = new Movie() { Title = "Hitlerjugend och de vita kaninerna", YearOfPublication = 1935, Rating = 3.5, NumberOfUserVotes = 981 };
            Movie Gaffel = new Movie() { Title = "Alla mina Gaffeltruckar", YearOfPublication = 2001, Rating = 8.7, NumberOfUserVotes = 245 };
            Movie Inte = new Movie() { Title = "Det Inte Särskilt Stora Äventyret", YearOfPublication = 2076, Rating = 10, NumberOfUserVotes = 0 };

            Yellow.Add(Bengt);
            Yellow.Add(Fluff);
            Yellow.Add(Gaffel);
            Yellow.Add(Inte);

            ConnectMovieAndCategory(Bengt, Drama);
            ConnectMovieAndCategory(Fluff, Erotica);
            ConnectMovieAndCategory(Gaffel, Documentary);
            ConnectMovieAndCategory(Inte, Comedy);

        }

        public IEnumerable<Movie> AllMovies()
        {
            return Yellow;
        }

        public IEnumerable<Category> AllCategories()
        {
            return Green;
        }

        public IEnumerable<Movie> MoviesFromCategory(string name)
        {
            var kategorier = from Category in Green
                             where Category.Name == name
                             select Category;
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
        {//Shows movies published during the chosen year
            //var filmer = Yellow.Where(movie => movie.YearOfPublication == year);
            //return filmer;        
            throw new NotImplementedException();
        }

        public void ConnectMovieAndCategory(Movie movie, Category category)
        {
            movie.Categories.Add(category);
            category.Movies.Add(movie);
        }

      public IEnumerable<Movie> MoviesAfterYear(int year)
        {//Shows movies released after or during the chosen year
            //var moviesafter = Yellow.Where(movie => movie.YearOfPublication >= year);
            //return moviesafter;
            throw new NotImplementedException();
        }
        public IEnumerable<Movie> AlphabeticalOrder()
        {//A-Z
            //var alph = Yellow.OrderBy(movie => movie.Title);
            //return alph;
            throw new NotImplementedException();
        }
        public IEnumerable<Movie> LongTitle()
        {//Shows movies with titles over 30 characters, in descending order
            //var longtitle = Yellow.Where(movie => movie.Title.Length > 30).OrderByDescending(movie => movie.Title.Length);
            //return longtitle;
            throw new NotImplementedException();
        }
       public double AverageRating()
        {
            //var avg = Yellow.Average(a => a.Rating);
            //return avg;
            throw new NotImplementedException();
        }
    }
}
