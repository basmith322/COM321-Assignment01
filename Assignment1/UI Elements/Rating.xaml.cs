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

namespace Assignment1
{
    /// <summary>
    /// Interaction logic for Rating.xaml
    /// </summary>
    public partial class Rating : UserControl
    {
        public Rating()
        {
            InitializeComponent();
        }

        public int RatingSelected
        {
            get
            {
                //determine which radio button is checked and return relevant value
                var RatingValue = radBtnOne.IsChecked.Value ? 1 : radBtnTwo.IsChecked.Value ? 2 : radBtnThree.IsChecked.Value ? 3 : radBtnFour.IsChecked.Value ? 4 : radBtnFive.IsChecked.Value ? 5 : 0;
                return RatingValue;

            }

            set
            {
                //set the appropriate radio button based on the value 
                if (value == 1) radBtnOne.IsChecked = true;
                else if (value == 2) radBtnTwo.IsChecked = true;
                else if (value == 3) radBtnThree.IsChecked = true;
                else if (value == 4) radBtnFour.IsChecked = true;
                else if (value == 5) radBtnFive.IsChecked = true;

            }

        }

        //clearing existing radio button selection
        public void Clear()
        {
            radBtnOne.IsChecked = false;
            radBtnTwo.IsChecked = false;
            radBtnThree.IsChecked = false;
            radBtnFour.IsChecked = false;
            radBtnFive.IsChecked = false;
        }
    }
}
