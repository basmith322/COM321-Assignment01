using System;
using System.Collections.Generic;
using System.Collections;
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
using Assignment1.Models;
using Microsoft.Win32;

namespace Assignment1
{

    public partial class MainWindow : Window
    {
        private Database db;
        private Movie movie;

        #region MainWindow
        public MainWindow()
        {
            InitializeComponent();

            BrowseMode();

            db = new Database();

            movie = new Movie();
        }
        #endregion

        #region MVVM Updaters

        public void UpdateModelFromUI(Movie movie)
        {

            movie.Title = txtTitle.Text;
            movie.Year = Convert.ToInt32(txtYear.Text);
            movie.Director = txtDirector.Text;
            movie.Duration = Convert.ToInt32(txtDuration.Text);
            movie.Budget = Convert.ToInt32(txtBudget.Text);
            movie.Rating = Convert.ToInt32(RatingSelector.RatingSelected);
            movie.PosterURL = txtMoviePosterUrl.Text;
            movie.Actors.Add(txtCast.Text);
            movie.Genres = GenreSelector.GenreSelected;
            movie.Actors = AddActors();

            db.Update(movie);

        }

        public void UpdateUIFromModel(Movie movie)
        {
            if (db.Count() != 0)
            {
                txtTitle.Text = db.Get().Title;
                txtYear.Text = Convert.ToString(db.Get().Year);
                txtDirector.Text = db.Get().Director;
                txtDuration.Text = Convert.ToString(db.Get().Duration);
                txtBudget.Text = Convert.ToString(db.Get().Budget);
                RatingSelector.RatingSelected = db.Get().Rating;
                txtMoviePosterUrl.Text = db.Get().PosterURL;
                GenreSelector.GenreSelected = db.Get().Genres;
                lstCast.Items.Add(db.Get().Actors);

                var path = txtMoviePosterUrl.Text;
                try
                {
                    var uri = new Uri(path, UriKind.Absolute);
                    posterImage.Source = new BitmapImage(uri);
                }
                catch (UriFormatException e)
                {
                    posterImage.Source = null;
                }
            }
        }

        private void UpdateNavigation()
        {

        }
        #endregion

        #region FileMenuButtons
        private void FileMenuNew_Click(object sender, RoutedEventArgs e)
        {
            movie = new Movie();
            UpdateUIFromModel(db.Get());
        }

        private void FileMenuOpen_Click(object sender, RoutedEventArgs e)
        {
            var openFile = new OpenFileDialog()
            {
                Filter = "json files|*.json",
                Title = "File to open",
            };

            if (openFile.ShowDialog() == true)
            {
                var file = openFile.FileName;
                db.Load(file);
            }

            UpdateUIFromModel(db.Get());
        }

        private void FileMenuSave_Click(object sender, RoutedEventArgs e)
        {

            UpdateModelFromUI(db.Get());
            var saveFile = new SaveFileDialog()
            {
                Filter = "json files|*.json",
                Title = "...File to save",
            };
            if (saveFile.ShowDialog() == true)
            {
                var file = saveFile.FileName;
                db.Save(file);
            }
        }

        private void FileMenuExit_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(1);
        }
        #endregion

        #region EditMenuButtons
        private void EditMenuEdit_Click(object sender, RoutedEventArgs e)
        {
            EditMode();
        }

        private void EditMenuCreate_Click(object sender, RoutedEventArgs e)
        {
            CreateMode();
        }

        private void EditMenuDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        #endregion

        #region ViewMenuButtons
        private void ViewMenuTitle_Click(object sender, RoutedEventArgs e)
        {
            db.OrderByTitle();
        }

        private void ViewMenuYear_Click(object sender, RoutedEventArgs e)
        {
            db.OrderByYear();
        }

        private void ViewMenuDuration_Click(object sender, RoutedEventArgs e)
        {
            db.OrderByDuration();
        }
        #endregion

        #region HelpMenuButtons
        private void HelpMenuAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Movie Database System\nUI Designed by Benjamin Smith\n© 2017", "About");
        }
        #endregion

        #region WindowModes
        //enum WindowMode { Browse, Create, Edit }
        void BrowseMode()
        {
            btnFirst.Visibility = Visibility.Visible;
            btnPrevious.Visibility = Visibility.Visible;
            btnNext.Visibility = Visibility.Visible;
            btnLast.Visibility = Visibility.Visible;
            btnCancel.Visibility = Visibility.Collapsed;
            btnSave.Visibility = Visibility.Collapsed;
            posterImage.Visibility = Visibility.Visible;
            txtTitle.IsReadOnly = true;
            txtDuration.IsReadOnly = true;
            txtYear.IsReadOnly = true;
            txtBudget.IsReadOnly = true;
            txtDirector.IsReadOnly = true;
            RatingSelector.IsEnabled = false;
            GenreSelector.IsEnabled = false;
            lblMoviePosterUrl.Visibility = Visibility.Collapsed;
            txtMoviePosterUrl.Visibility = Visibility.Collapsed;
            txtCast.Visibility = Visibility.Collapsed;
            btnAdd.Visibility = Visibility.Collapsed;
            btnDelete.Visibility = Visibility.Collapsed;
            lblPoster.Visibility = Visibility.Visible;
            posterImage.Visibility = Visibility.Visible;
            File.IsEnabled = true;
            Edit.IsEnabled = true;
            View.IsEnabled = true;
            Application.Current.MainWindow.SizeToContent = SizeToContent.WidthAndHeight;
        }

        public void EditMode()
        {
            btnFirst.Visibility = Visibility.Hidden;
            btnPrevious.Visibility = Visibility.Hidden;
            btnNext.Visibility = Visibility.Hidden;
            btnLast.Visibility = Visibility.Hidden;
            btnCancel.Visibility = Visibility.Visible;
            btnSave.Visibility = Visibility.Visible;
            posterImage.Visibility = Visibility.Hidden;
            txtTitle.IsReadOnly = false;
            txtDuration.IsReadOnly = false;
            txtYear.IsReadOnly = false;
            txtBudget.IsReadOnly = false;
            txtDirector.IsReadOnly = false;
            RatingSelector.IsEnabled = true;
            GenreSelector.IsEnabled = true;
            lblMoviePosterUrl.Visibility = Visibility.Visible;
            txtMoviePosterUrl.Visibility = Visibility.Visible;
            txtCast.Visibility = Visibility.Visible;
            btnAdd.Visibility = Visibility.Visible;
            btnDelete.Visibility = Visibility.Visible;
            lblPoster.Visibility = Visibility.Collapsed;
            posterImage.Visibility = Visibility.Collapsed;
            File.IsEnabled = false;
            Edit.IsEnabled = false;
            View.IsEnabled = false;
            Application.Current.MainWindow.SizeToContent = SizeToContent.WidthAndHeight;
        }

        public void CreateMode()
        {
            EditMode();
            txtTitle.Clear();
            txtDuration.Clear();
            txtYear.Clear();
            txtBudget.Clear();
            RatingSelector.Clear();
            txtDirector.Clear();
            ClearGenre();

        }
        #endregion

        #region NavigationButtons

        private void btnFirst_Click(object sender, RoutedEventArgs e)
        {
            db.First();
        }
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            db.Next();
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            db.Prev();
        }

        private void btnLast_Click(object sender, RoutedEventArgs e)
        {

            db.Last();
        }
        #endregion

        #region ModifierButtons
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            lstCast.Items.Add(txtCast.Text);
            txtCast.Clear();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            UpdateUIFromModel(db.Get());
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            BrowseMode();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            UpdateModelFromUI(db.Get());
            BrowseMode();
            UpdateUIFromModel(db.Get());
            
        }
        #endregion

        #region Other Functions

        public List<string> AddActors()
        {
            var actors = new List<string>();
            actors.Add(txtCast.Text);

            return actors;
        }

        public void ClearGenre()
        {
            GenreSelector.chkAction.IsChecked = false;
            GenreSelector.chkComedy.IsChecked = false;
            GenreSelector.chkFamily.IsChecked = false;
            GenreSelector.chkHorror.IsChecked = false;
            GenreSelector.chkRomance.IsChecked = false;
            GenreSelector.chkSciFi.IsChecked = false;
            GenreSelector.chkThriller.IsChecked = false;
            GenreSelector.chkWar.IsChecked = false;
            GenreSelector.chkWestern.IsChecked = false;
        }
        #endregion
    }
}
