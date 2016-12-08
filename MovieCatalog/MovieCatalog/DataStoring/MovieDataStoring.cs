using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace MovieCatalog
{
    public enum Genre
    {
        Action = 1,
        Thriller = 2,
        Scifi = 3,
        Fantasy = 4,
        Western = 5 
    }

    public class MovieDataStoring : INotifyPropertyChanged
    {
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
        private Genre _Genre;
        public Genre Genre
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
        private string _ReleaseDate;
        public string ReleaseDate
        {
            get { return _ReleaseDate; }
            set
            {
                _ReleaseDate = value;
                OnPropertyChanged();
            }
        }

        public static List<MovieDataStoring> getMovies()
        {
            var movie = new List<MovieDataStoring>();
            movie.Add(new MovieDataStoring() { Name = "Avatar", Genre = Genre.Action, Director = "James Cameron", ReleaseDate = ""});
            movie.Add(new MovieDataStoring() { Name = "Dark Knight", Genre = Genre.Action, Director = "Christopher Nolan" });
            movie.Add(new MovieDataStoring() { Name = "Gilmors girls", Genre = Genre.Action, Director = "Ivan Peric" });
            movie.Add(new MovieDataStoring() { Name = "The Hatefull Eight", Genre = Genre.Action, Director = "Quentin Tarntino" });
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
