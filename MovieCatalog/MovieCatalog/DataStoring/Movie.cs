using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace MovieCatalog
{
    public enum MovieTypeEnum
    {
        Action = 1,
        Thriller = 2,
        Scifi = 3,
        Fantasy = 4,
        Western = 5
    }
    [Serializable]
    public class Movie : INotifyPropertyChanged
    {
        public Movie()
        {

        }
        public Movie(Movie newMovie)
        {
            CopyProperties(newMovie);
        }

        public void CopyProperties(Movie movie)
        {
            this.Name = movie.Name;
            this.Director = movie.Director;
            this.Genre = movie.Genre;
            this.ReleaseDate = movie.ReleaseDate;
        }
        
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                OnPropertyChanged();

            }
        }
        private MovieTypeEnum _Genre;
        public MovieTypeEnum Genre
        {
            get { return _Genre; }
            set
            {
                _Genre = value;
                OnPropertyChanged();
            }
        }
        private string _Director;
        public string Director
        {
            get { return _Director; }
            set
            {
                _Director = value;
                OnPropertyChanged();
            }
        }
        private DateTime _ReleaseDate = DateTime.Now;
        public DateTime ReleaseDate
        {
            get { return _ReleaseDate; }
            set
            {
                _ReleaseDate = value;
                OnPropertyChanged();
            }
        }

        public static ObservableCollection<Movie> getMovies()
        {
            var movie = new ObservableCollection<Movie>();
            movie.Add(new Movie() { Name = "Avatar", Genre = MovieTypeEnum.Scifi, Director = "James Cameron", ReleaseDate = new DateTime(2001, 2, 12) });
            movie.Add(new Movie() { Name = "Dark Knight", Genre = MovieTypeEnum.Fantasy, Director = "Christopher Nolan", ReleaseDate = new DateTime(2010, 3, 12) });
            movie.Add(new Movie() { Name = "Gilmors girls", Genre = MovieTypeEnum.Action, Director = "Ivan Peric", ReleaseDate = new DateTime(2006, 5, 30) });
            movie.Add(new Movie() { Name = "The Hatefull Eight", Genre = MovieTypeEnum.Western, Director = "Quentin Tarntino", ReleaseDate = new DateTime(2016, 3, 5) });
            return movie;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }

    }
}
