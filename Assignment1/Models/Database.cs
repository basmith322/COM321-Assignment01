using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment1.Models
{
    public class Database
    {
        private List<Movie> db; // list of movies in the database

        private int _index; // position of current movie in the database 

        // initialise the database properties
        public Database()
        {
            db = new List<Movie>();
            _index = -1;
        }

        // A property to Return number of movies in the database
        public int Count
        {
            get
            {
                return db.Count;
            }
        }

        // A property to return  current _index position which should be either
        // -1 if database is empty
        // 0 - db.Count-1 if database is not empty
        public int Index
        {
            get
            {
                return _index;
            }
        }

        // Add a movie to current position in database
        public void Add(Movie m)
        {
            db.Add(m);
            _index++;
        }

        // Return current movie or null if database empty
        public Movie Get()
        {
            if (db.Count > 0)
            {
                return db[_index];
            }

            return null;
        }

        // Delete current movie at index if there is a movie and update index 
        public void Delete()
        {
            db.RemoveAt(_index);
            _index--;
        }

        // Update the current movie at index if there is a movie and update index
        public void Update(Movie m)
        {
            //if (_index > -1)
            if (db.Count > 0)
            {
                db[_index] = m;
            }
        }

        // Delete all movies from the database and reset index
        public void clear()
        {
            db.Clear();
            _index = -1;
        }

        // Move index position to first movie (0)
        // return true if index update was possible, false otherwise
        public bool First()
        {
            if (db.Count > 0)
            {
                _index = 0;
                return true;
            }

            return false;
        }

        // Move index position to last movie
        // true if index update was possible, false otherwise</returns>
        public bool Last()
        {
            //_index = db.Count - 1;

            if (db.Count > 0)
            {
                _index = db.Count - 1;
                return true;
            }

            return false;
        }

        // Move index position to next movie
        // true if index update was possible, false otherwise<
        public bool Next()
        {
            if (_index < db.Count - 1)
            {
                _index++;
                return true;
            }

            return false;
        }

        // Move index position to previous movie
        // true if index update was possible, false otherwise
        public bool Prev()
        {
            if (_index > 0)
            {
                _index--;
                return true;
            }

            return false;
        }

        // Load movies from a json file and set index to first record
        public void Load(string file)
        {

        }

        // Save movies to a Json file
        public void Save(string file)
        {

        }

        // Following methods update the List of movies (db) to the specified order

        // order the database by year of movie
        public void OrderByYear()
        {

        }

        // order the database by title of movie (ascending)
        public void OrderByTitle()
        {

        }

        // order the database by budget of movie (ascending)
        public void OrderByBudget()
        {

        }

        public void OrderByDuration()
        {

        }
    }
}
