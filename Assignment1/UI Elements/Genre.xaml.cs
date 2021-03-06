﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assignment1
{
    /// <summary>
    /// Interaction logic for Genre.xaml
    /// </summary>
    public partial class Genre : UserControl
    {
        public Genre()
        {
            InitializeComponent();
        }

        public List<Models.Movie.Genre> GenreSelected
        {
            get
            {
                var genres = new List<Models.Movie.Genre>();
                if (chkComedy.IsChecked.Value) genres.Add(Models.Movie.Genre.Comedy);
                else if (chkRomance.IsChecked.Value) genres.Add(Models.Movie.Genre.Romance);
                else if (chkAction.IsChecked.Value) genres.Add(Models.Movie.Genre.Action);
                else if (chkThriller.IsChecked.Value) genres.Add(Models.Movie.Genre.Thriller);
                else if (chkFamily.IsChecked.Value) genres.Add(Models.Movie.Genre.Family);
                else if (chkHorror.IsChecked.Value) genres.Add(Models.Movie.Genre.Horror);
                else if (chkWestern.IsChecked.Value) genres.Add(Models.Movie.Genre.Western);
                else if (chkSciFi.IsChecked.Value) genres.Add(Models.Movie.Genre.SciFi);
                else if (chkWar.IsChecked.Value) genres.Add(Models.Movie.Genre.War);
                return genres;

            }
            set
            {
                chkComedy.IsChecked = value.Contains(Models.Movie.Genre.Comedy) ? true : false;
                chkRomance.IsChecked = value.Contains(Models.Movie.Genre.Romance) ? true : false;
                chkAction.IsChecked = value.Contains(Models.Movie.Genre.Action) ? true : false;
                chkThriller.IsChecked = value.Contains(Models.Movie.Genre.Thriller) ? true : false;
                chkFamily.IsChecked = value.Contains(Models.Movie.Genre.Family) ? true : false;
                chkHorror.IsChecked = value.Contains(Models.Movie.Genre.Horror) ? true : false;
                chkWestern.IsChecked = value.Contains(Models.Movie.Genre.Western) ? true : false;
                chkSciFi.IsChecked = value.Contains(Models.Movie.Genre.SciFi) ? true : false;
                chkWar.IsChecked = value.Contains(Models.Movie.Genre.War) ? true : false;
            }

        }
    }
}

