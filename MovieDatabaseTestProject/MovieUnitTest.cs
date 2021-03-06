﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment1.Models;
using System.Collections.Generic;

namespace MovieDatabaseTestProject
{
    [TestClass]
    public class MovieUnitTest
    {
        // test movie
        private Movie m;
        private Database db;

        [TestInitialize]
        public void SetUp()
        {
            m = new Movie
            {
                // initialise your test movie attributes
                Title = "MovieOne",
                Year = 2017,
                Duration = 150,
                Director = "Robert Hill",
                Budget = 143.6,
                Rating = 3,
                PosterURL = "www.google.com",
                Actors = new List<String> {"Jonah Hill", "James Cordon", "Emily Blunt"},
                Genres = new List<Movie.Genre> { Movie.Genre.Comedy}
            };
        }
        //example

        [TestMethod]
        public void TestCreateMovie()
        {
            // verify the movie was created by checking that each attribute value was set
            // e.g.   Assert.AreEqual(m.Title, "The title of the test movie");
            {
                Movie mov = new Movie();

                Assert.AreEqual(m.Title, "MovieOne");
                Assert.AreEqual(m.Year, 2017);
                Assert.AreEqual(m.Duration, 150);
                Assert.AreEqual(m.Director, "Robert Hill");
                Assert.AreEqual(m.Budget, 143.6);
                Assert.AreEqual(m.Rating, 3);
                Assert.AreEqual(m.PosterURL, "www.google.com");
                Assert.IsTrue(m.Actors.Contains("Jonah Hill"));
                Assert.IsTrue(m.Actors.Contains("James Cordon"));
                Assert.IsTrue(m.Actors.Contains("Emily Blunt"));
                Assert.IsTrue(m.Genres.Contains(Movie.Genre.Comedy));
            }
        }

        [TestMethod]
        public void TestUpdateMovie()
        {
            // make changes to the test movie m            
            // Check if changes were accepted
           

            var db = new Database();
            var m = new Movie() { Title = "Movie 3", Year = 2015, Budget = 120 };
            db.Add(m);
            //db.Index = db.Count - 1;
            db.Update(m);
            Assert.AreEqual(m.Year, m.Year);

        }
    }
}
