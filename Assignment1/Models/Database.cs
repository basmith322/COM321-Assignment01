using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment1.Models
{
    public class Database
    {
        #region DatabaseInitializations
        public List<Movie> db; // list of movies in the database

        private int _index; // position of current movie in the database 

        // initialise the database properties
        public Database()
        {
            db = new List<Movie>();
            _index = -1;
        }

        // A property to Return number of movies in the database
        public int Count()
        { 
                return db.Count;
        }

        // A property to return  current _index position which should be either
        // -1 if database is empty
        // 0 - db.Count-1 if database is not empty
        public int Index()
        {
                return _index;
        }
        #endregion

        #region DatabaseModifierFunctions
        // Add a movie to current position in database
        public void Add(Movie m)
        {
            _index++;
            db.Insert(_index, m);
        }

        // Return current movie or null if database empty
        public Movie Get()
        {
            if (db.Count > 0)
            {
                return db.ElementAt(_index);
            }
            else
            {
                return null;
            }
        }

        // Delete current movie at index if there is a movie and update index 
        public void Delete()
        {
            if (_index <= db.Count())
            {
                db.RemoveAt(_index);
                _index--;
            }
            
            if (_index == -1 && db.Count > 0)
            {
                _index = 0;
            }
        }

        // Update the current movie at index if there is a movie and update index
        public void Update(Movie m)
        {
            db.RemoveAt(_index);
            db.Insert(_index, m);
        }

        // Delete all movies from the database and reset index
        public void clear()
        {
            db.Clear();
            _index = 0;
        }
        #endregion

        #region NavigationButtonFunctions
        // Move index position to first movie (0)
        // return true if index update was possible, false otherwise
        public bool First()
        {
            if (_index != 0)
            {
                _index = 0;
                return true;
            }
            else
            {
                return false;
            }
        }

        // Move index position to next movie
        // true if index update was possible, false otherwise<
        public bool Next()
        {
            if (_index < db.Count() - 1)
            {
                _index++;
                return true;
            }
            else
            {
                return false;
            }
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
            else
            {
                return false;
            }
        }
        // Move index position to last movie
        // true if index update was possible, false otherwise</returns>
        public bool Last()
        {
            //_index = db.Count - 1;

            if (_index < (db.Count() - 1))
            {
                _index = db.Count - 1;
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region LoadSaveFunctions
        // Load movies from a json file and set index to first record
        public void Load(string file)
        { 
            var json = File.ReadAllText(file);
            db = JsonConvert.DeserializeObject<List<Movie>>(json);
            _index = 0;
        }

        // Save movies to a Json file
        public void Save(string file)
        {
            string json = JsonConvert.SerializeObject(db);
            File.WriteAllText(file, json);
        }
        #endregion

        #region OrderByFunctions

        // Following methods update the List of movies (db) to the specified order

        // order by year of movie
        public void OrderByYear()
        {
            db = db.OrderBy(x => x.Year).ToList();
        }

        // order by title of movie (ascending)
        public void OrderByTitle()
        {
            db = db.OrderBy(x => x.Title).ToList();
        }

        // order by budget of movie (ascending)
        public void OrderByBudget()
        {
            db = db.OrderBy(x => x.Budget).ToList();
        }

        // order by duration of movie (ascending)
        public void OrderByDuration()
        {
            db = db.OrderBy(x => x.Duration).ToList();
        }
    }
    #endregion
}
