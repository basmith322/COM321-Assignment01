using System;
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
using Assignment1.Models;
using Microsoft.Win32;


namespace Assignment1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    //enum WindowMode { View, Create, Edit }

    public partial class MainWindow : Window
    {
        public Database db;
        private Movie mov;

        public MainWindow()
        {
            InitializeComponent();
            var path = "https://image.tmdb.org/t/p/w640/dM2w364MScsjFf8pfMbaWUcWrR.jpg";
            var uri = new Uri(path, UriKind.Absolute);

            posterImage.Source = new BitmapImage(uri);

        }

        void UpdateModelFromUI()
        {
            db.Get().Title = txtTitle.Text;
            db.Get().Year = Convert.ToInt32(txtYear.Text);
            db.Get().Director = txtDirector.Text;
            db.Get().Duration = Convert.ToInt32(txtDuration.Text);
            db.Get().Budget = Convert.ToDouble(txtDuration.Text);
            db.Get().PosterURL = txtMoviePosterUrl.Text;

            //NEEDS FIXED- NEED TO DO RATINGS GENRE AND ACTORS
            // actors
            //db.Get().Genres = Genre.GenreSelected;
            //db.Get().Rating =   Rating.MovieRating.RatingValue;
        } 
    

        void UpdateUIFromModel()
        {
            txtTitle.Text = db.Get().Title;
            txtYear.Text = db.Get().Year.ToString();
            txtDirector.Text = db.Get().Duration.ToString();
            txtBudget.Text = db.Get().Budget.ToString();

            //NEED TO DO RATING, GENRE AND ACTORS

        }

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

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            BrowseMode();
        }

        private void EditMenuEdit_Click(object sender, RoutedEventArgs e)
        {
            EditMode();
        }

        private void HelpMenuAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Movie Database System\nUI Designed by Benjamin Smith\n© 2017", "About");
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
           
        }

    private void btnLast_Click(object sender, RoutedEventArgs e)
        {
            if (db.Last()) 
            { 
                //UpdateUIFromModel(db.Get());
                UpdateModelFromUI();
            }
        }
    }
}
