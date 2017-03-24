using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MovieService
{
    public partial class MovieServiceForm : Form
    { 
        public MovieServiceForm()
        {
            InitializeComponent();
        }

        private IMovieService movieService = SimpleDI.GetService();

        private void button1_Click(object sender, EventArgs e)
        { //Movies from Category

            if (textBox1.Text == "")
            {
                listBox2.Items.Clear();
                listBox2.Items.Add("Please input a valid year or category.");
            }
            else
            {
                string b = textBox1.Text;
                listBox2.Items.Clear();

                foreach (Movie m in movieService.MoviesFromCategory(b))
                {
                    listBox2.Items.Add(m.Title);
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {   //Reset, empty all fields

            listBox1.Items.Clear();
            listBox2.Items.Clear();
            textBox1.Clear();

            foreach(Category c in movieService.AllCategories())
            {
                listBox1.Items.Add(c.Name);
            }

            foreach (Movie m in movieService.AllMovies())
            {
                listBox2.Items.Add(m.Title);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        { //Movies from year
                                 
                int aret;
                if (int.TryParse(textBox1.Text, out aret) == true)
                {
                    listBox2.Items.Clear();
                    foreach (Movie m in movieService.MoviesFromYear(aret))
                    {
                        listBox2.Items.Add(m.Title);
                    }
                }
                else
                {
                    listBox2.Items.Clear();
                    listBox2.Items.Add("Please input a valid year.");
                }
            
        }

        private void MovieServiceForm_Load(object sender, EventArgs e)
        { //When the program is first started, the categories and the movies will be displayed in their separate boxes
            foreach (Category c in movieService.AllCategories())
            {
                listBox1.Items.Add(c.Name);
            }

            foreach (Movie m in movieService.AllMovies())
            {
                listBox2.Items.Add(m.Title);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        { //MoviesAfterYear

            int aret;
            if (int.TryParse(textBox1.Text, out aret) == true)
            {
                listBox2.Items.Clear();
                foreach (Movie m in movieService.MoviesAfterYear(aret))
                {
                    listBox2.Items.Add(m.Title);
                }
            }
            else
            {
                listBox2.Items.Clear();
                listBox2.Items.Add("Please input a valid year.");
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        { //A-Z order

            listBox2.Items.Clear();
            foreach (Movie m in movieService.AlphabeticalOrder())
            {
                listBox2.Items.Add(m.Title);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        { //Average rating of all movies
            listBox2.Items.Clear();
            listBox2.Items.Add("The average rating for a movie is:");
            listBox2.Items.Add(movieService.AverageRating());
        }

        private void button7_Click(object sender, EventArgs e)
        { //Long Title: Shows movies with over 30 characters in their titles

            listBox2.Items.Clear();
            foreach (Movie m in movieService.LongTitle())
            {
                listBox2.Items.Add(m.Title);
            }

        }

    }
}
