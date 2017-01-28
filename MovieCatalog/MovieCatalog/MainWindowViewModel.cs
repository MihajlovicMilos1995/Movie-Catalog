using Prism.Commands;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System;
using System.Linq;


namespace MovieCatalog
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        MovieContext ctx = new MovieContext();

        private ObservableCollection<Movie> movies = new ObservableCollection<Movie>();
        private ObservableCollection<Movie> filteredMovies = new ObservableCollection<Movie>();

        public ICommand SearchCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        private Movie selectedMovie;

        private string searchValue;

        public MainWindowViewModel()
        {
            SearchCommand = new DelegateCommand<string>(Search);
            DeleteCommand = new DelegateCommand(Delete);
            AddCommand = new DelegateCommand(Add);
            EditCommand = new DelegateCommand(Edit);
            ExitCommand = new DelegateCommand(Exit);
            SaveCommand = new DelegateCommand(Save);

            var filmici = ctx.Movies.ToList();
            foreach (var film in filmici)
            {
                Movies.Add(film);
            }
        }



        // Exit funkcija

        public void Exit()
        {

            var result = MessageBox.Show("Are you sure you want to exit?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        //Save to DB funkcija

        public void Save()
        {
            ctx.SaveChanges();
            MessageBox.Show("Movies are saved", "Saving", MessageBoxButton.OK);
        }

        // Edit funkcija

        public void Edit()
        {
            if (selectedMovie == null)
            {
                MessageBox.Show("Nothing is selected", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var selectedMovie = this.selectedMovie;
                var editDialog = new AddEdit(selectedMovie);

                if (editDialog.ShowDialog() == true)
                {
                }
            }
            ctx.SaveChanges();
        }

        // Add funkcija

        public void Add()
        {
            AddEdit addDialog = new AddEdit(null);

            if (addDialog.ShowDialog() == true)
            {
                movies.Add(addDialog.Movie);
                ctx.Movies.Add(addDialog.Movie);
            }
        }

        // Delete funkcija

        public void Delete()
        {
            if
          (selectedMovie == null)
            {
                MessageBox.Show("Nothing is selected", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var result = MessageBox.Show("Are you sure you want to proceed?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    ctx.Movies.Remove(selectedMovie);
                    movies.Remove(selectedMovie);
                }
            }
            ctx.SaveChanges();
        }

        // Search funkcija

        public void Search(string value)
        {
            if (value != null)
            {
                SearchValue = value;
            }
        }

        public string SearchValue
        {
            get
            {
                return searchValue;
            }
            set
            {
                searchValue = value;
                OnPropertyChanged("SearchValue");
                OnPropertyChanged("Movies");
            }
        }

        public ObservableCollection<Movie> Movies
        {
            get
            {
                if (string.IsNullOrEmpty(SearchValue))
                {
                    return movies;
                }
                else
                {
                    string text = SearchValue;
                    filteredMovies = new ObservableCollection<Movie>();
                    foreach (var movie in movies)
                    {
                        if (movie.Name.StartsWith(text, StringComparison.InvariantCultureIgnoreCase)
                            || movie.Genre.ToString().StartsWith(text, StringComparison.InvariantCultureIgnoreCase))
                        {
                            filteredMovies.Add(movie);
                        }
                    }
                    return filteredMovies;
                }
            }

            set
            {
                movies = value;
                OnPropertyChanged("Movies");
            }
        }

        // Izabrani film

        public Movie SelectedMovie
        {
            get
            {
                return selectedMovie;
            }

            set
            {
                selectedMovie = value;
                OnPropertyChanged("SelectedMovie");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
