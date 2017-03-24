using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

namespace MovieService
{
    /// <summary>
    /// Parses movies and categories from a csv-file with a specific format.
    /// </summary>
    public class CsvParser
    {
        private List<Movie> Movies = new List<Movie>();
        private Dictionary<String, Category> Categories =
            new Dictionary<String, Category>();

        /// <summary>
        /// Get all parsed movies.
        /// Call ParseCsv before calling this method.
        /// </summary>
        /// <returns>A set of movies.</returns>
        public IEnumerable<Movie> GetMovies()
        {
            return Movies;
        }

        /// <summary>
        /// Get all parsed categories.
        /// Call ParseCsv before calling this method.
        /// </summary>
        /// <returns>A set of categories.</returns>
        public IEnumerable<Category> GetCategories()
        {
            return Categories.Values;
        }

        /// <summary>
        /// Parses a csv-file at path:"/../../Files/Movies.csv"
        /// containing movies and their categories.
        /// </summary>
        public void ParseCsv()
        {
            var path = Application.StartupPath + "/../../Files/Movies.csv";
            var lines = File.ReadAllLines(path, Encoding.GetEncoding("iso-8859-1"));

            foreach (string line in lines)
            {
                var items = line.Split(new string[] { ";" }, StringSplitOptions.None);

                int year, votes;
                int.TryParse(items[1], out year);
                int.TryParse(items[3], out votes);

                double rating;
                var style = NumberStyles.Number;
                var culture = CultureInfo.CreateSpecificCulture("en-US");
                double.TryParse(items[2], style, culture, out rating);


                Movie movie = new Movie
                {
                    Title = items[0],
                    YearOfPublication = year,
                    Rating = rating,
                    NumberOfUserVotes = votes,
                    Categories = new List<Category>()
                };

                Movies.Add(movie);

                var categories = items[4].Split(new String[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var c in categories)
                {
                    Category category;

                    if (!Categories.ContainsKey(c))
                    {
                        category = new Category
                        {
                            Movies = new List<Movie>(),
                            Name = c
                        };

                        Categories.Add(c, category);
                    }
                    else
                        category = Categories[c];

                    category.Movies.Add(movie);
                    movie.Categories.Add(category);
                }
            }
        }
    }
}
