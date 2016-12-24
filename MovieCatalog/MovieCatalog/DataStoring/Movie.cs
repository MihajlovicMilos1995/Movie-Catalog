using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MovieCatalog
{
    public enum MovieTypeEnum
    {
        Unknown,
        Action,
        Thriller,
        Scifi,
        Fantasy,
        Western
    }

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
