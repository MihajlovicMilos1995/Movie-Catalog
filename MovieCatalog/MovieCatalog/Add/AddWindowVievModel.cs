using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace MovieCatalog.Add
{
    class AddWindowVievModel
    {
        private ObservableCollection<Movie> movies = new ObservableCollection<Movie>();
        public Movie Movie { get; set; }
        public ICommand OkCommand { get; set; }
        public ICommand CancelCommand { get; set; }       

        private string nameValue;
        private string directorValue;
        private DateTime releaseValue;
        private MovieTypeEnum genreValue;
        private AddWindowVievModel()
        
        {
            OkCommand = new DelegateCommand(Ok);
            CancelCommand = new DelegateCommand(Cancel);
        }

        //Ok funkcija
        public void Ok()
        {
            Movie = new Movie();
            try
            {
                Movie.Name = nameValue;
                Movie.Director = directorValue;
                Movie.Genre = (MovieTypeEnum)comboBox.SelectedItem;
                Movie.ReleaseDate = datePicker.SelectedDate.Value;
                this.DialogResult = true;
                this.Close();
            }
            catch
            {
                MessageBox.Show("You must enter everything", "Error", MessageBoxButton.OK);
            }
        }

        //Cancel funkcija
        public void Cancel()
        {
            this.Close();
        }
    }
}

