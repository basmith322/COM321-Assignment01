using System;
using System.Collections.Generic;
using System.Text;


namespace Assignment1.Models
{
    public enum Genre { Comedy, Action, Horror, Romance, SciFi, Western, Family, Thriller, War }

    public class Movie
    {
        // declare the movie properties and a constructor to initialise a blank movie

        //Movie m = new Movie();
     
        public string Title { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public int Duration { get; set; }
        public double Budget { get; set; }
        public int Rating { get; set; }
        public string PosterURL { get; set; }
        public List<string> Actors { get; set; }
        public List<Genre> Genres { get; set; }


            public Movie()
                 {
                   Title = "";
                   Year = 0;
                   Director = "";
                   Duration = 0;
                   Budget = 0.00;
                   Rating = 0;
                   PosterURL = "";
                   Actors = new List<string> ();
                   Genres = new List<Genre>();
                 }
              }
            }


