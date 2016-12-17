using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace MovieCatalog
{
    /// <summary>
    /// Interaction logic for Edit.xaml
    /// </summary>
    public partial class Edit : Window
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
        public Edit(Movie movie)
        {
            DataContext = this;
            _oldMovie = movie;
            Movie = movie;
            InitializeComponent();
        }
        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            // ... Get DatePicker reference.
            var picker = sender as DatePicker;

            DateTime? date = picker.SelectedDate;
            // ... Get nullable DateTime from SelectedDate.
            date = picker.SelectedDate;
            if (!date.HasValue)
            {
                // ... A null object.
                this.Title = "No date";
            }
            else
            {
                // ... No need to display the time.
                this.Title = date.Value.ToShortDateString();
            }
        }
        public List<MovieTypeEnum> Genres
        {
            get
            {
                return Enum.GetValues(typeof(MovieTypeEnum)).Cast<MovieTypeEnum>().ToList<MovieTypeEnum>();
            }
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


        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            Movie.Genre = (MovieTypeEnum)comboBox.SelectedItem;
            _oldMovie.CopyProperties(Movie);

            this.DialogResult = true;
            this.Close();
        }
    }
}
