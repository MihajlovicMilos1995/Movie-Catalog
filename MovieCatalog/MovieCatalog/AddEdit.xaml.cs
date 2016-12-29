using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace MovieCatalog
{
    public partial class AddEdit : Window
    {

        private Movie _movie;
        private Movie _oldMovie;
        public Movie Movie
        {
            get
            {
                return _movie;
            }
            set
            {
                _movie = value;
                RaisePropertyChanged();
            }
        }

        public AddEdit(Movie movie)
        {
            DataContext = this;
            _oldMovie = movie;

            if (movie == null)
            {
                // Add

                this.Title = "Add movie";
                Movie = new Movie();
            }
            else
            {
                // Edit

                this.Title = "Edit movie";
                Movie = new Movie(movie);
            }
            InitializeComponent();
        }

        public List<MovieTypeEnum> Genres
        {
            get
            {
                return Enum.GetValues(typeof(MovieTypeEnum)).Cast<MovieTypeEnum>().ToList<MovieTypeEnum>();
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_oldMovie == null)
                {
                    // Add

                    this.DialogResult = true;
                }
                else
                {
                    // Edit

                    _oldMovie.CopyProperties(Movie);
                }
            }
            catch
            {
                MessageBox.Show("You must enter everything!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            this.Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(
            [CallerMemberName] string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }
    }
}
