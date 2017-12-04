using System;
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
            m = new Movie()
            {
                // initialise your test movie attributes
                Title = "Movie 1",
                Year = 2017,
                Duration = 150
            };
        }

        [TestMethod]
        public void TestCreateMovie()
        {
            // verify the movie was created by checking that each attribute value was set
            // e.g.   Assert.AreEqual(m.Title, "The title of the test movie");
            Movie m = new Movie { Title = "Movie 1", Year = 2017, Duration = 150 };
            db.Add(m);
            Assert.AreEqual(m.Title, db.Get().Title);

        }

        [TestMethod]
        public void TestUpdateMovie()
        {
            // make changes to the test movie m            

            // Check if changes were accepted

        }
    }
}
