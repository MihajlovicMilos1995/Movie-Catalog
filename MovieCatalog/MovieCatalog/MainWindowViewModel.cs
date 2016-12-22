using Prism.Commands;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace MovieCatalog
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Movie> movies = new ObservableCollection<Movie>();
        private ObservableCollection<Movie> filteredMovies = new ObservableCollection<Movie>();
        public ICommand SearchCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        public ICommand ExportCommand { get; set; }
        public ICommand ImportCommand { get; set; }
        private Movie selectedMovie;

        private string searchValue;


        public MainWindowViewModel()
        {
            SearchCommand = new DelegateCommand(Search);
            DeleteCommand = new DelegateCommand(Delete);
            AddCommand = new DelegateCommand(Add);
            EditCommand = new DelegateCommand(Edit);
            ExitCommand = new DelegateCommand(Exit);
            ExportCommand = new DelegateCommand(Export);
            ImportCommand = new DelegateCommand(Import);
            movies = MovieCatalog.Movie.getMovies();
        }

        // Exit funkcija

        public void Exit()
        {

            var result = MessageBox.Show("Are you sure you want to exit?", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        //Import funkcija

        public void Import()
        {
            Microsoft.Win32.OpenFileDialog Import = new Microsoft.Win32.OpenFileDialog();
            Import.Filter = "XML Files (*.xml)|*.xml|JSON Files (*.json)|*.json";

            if (Import.ShowDialog() == true)
            {
                string impext = Path.GetExtension(Import.FileName);

                if (impext.Equals(".xml"))
                {
                    XmlSerializer x = new XmlSerializer(typeof(ObservableCollection<Movie>));

                    using (StreamReader reader = new StreamReader(Import.FileName))
                    {
                        Movies = (ObservableCollection<Movie>)x.Deserialize(reader);

                    }
                }
                else if (impext.Equals(".json"))
                {                   
                    string jsonimp = File.ReadAllText(Import.FileName);
                    ObservableCollection<Movie> data = JsonConvert.DeserializeObject<ObservableCollection<Movie>>(jsonimp);
                    Movies = data;
                }
            }

        }

        //Export funkcija

        public void Export()
        {

            Microsoft.Win32.SaveFileDialog SaveFile = new Microsoft.Win32.SaveFileDialog();
            SaveFile.FileName = "Movies";
            SaveFile.DefaultExt = ".xml"; // Default file extension
            SaveFile.Filter = "XML Files (.xml)|*.xml|JSON Files (*.json)|*.json"; // Filter by extension

            // Process save file dialog box results

            if (SaveFile.ShowDialog() == true)
            {
                // Save

                string filename = SaveFile.FileName;

                // izvlacenje extenzije (ubaci u if else)

                string ext = Path.GetExtension(filename);

                // Serializer
                if (ext.Equals(".xml"))
                {

                    XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Movie>));

                    using (FileStream writer = new FileStream(filename, FileMode.OpenOrCreate))
                    {
                        serializer.Serialize(writer, movies);
                    }
                }
                else if (ext == ".json")
                {
                    string json = JsonConvert.SerializeObject(movies, Formatting.Indented);

                    File.WriteAllText(filename, json);
                }
            }
        }

        // Edit funkcija

        public void Edit()
        {
            if (selectedMovie == null)
            {
                MessageBox.Show("Nothing is selected", "Error!", MessageBoxButton.OK);
            }
            else
            {
                var selectedMovie = this.selectedMovie;
                var editDialog = new Edit(selectedMovie);

                if (editDialog.ShowDialog() == true)
                {
                }
            }
        }

        // Add funkcija

        public void Add()
        {
            AddWindow addDialog = new AddWindow();

            if (addDialog.ShowDialog() == true)
            {
                movies.Add(addDialog.AddMovie);
            }
        }

        // Delete funkcija

        public void Delete()
        {
            if
          (selectedMovie == null)
            {
                MessageBox.Show("Nothing is selected", "Error", MessageBoxButton.OK);
            }
            else
            {
                var result = MessageBox.Show("Are you sure you want to proceed?", "Confirmation", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    movies.Remove((Movie)selectedMovie);
                }
            }
        }

        // Search funkcija

        public void Search()
        {
            OnPropertyChanged("Movies");
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
                        if (movie.Name.StartsWith(text) || movie.Genre.ToString().StartsWith(text))
                        {
                            filteredMovies.Add(movie);
                        }
                    }
                    return filteredMovies;

                    //dataGrid.ItemsSource = filteredMovies;
                }
            }

            set
            {
                movies = value;
                OnPropertyChanged("Movies");
            }
        }

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
