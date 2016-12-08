using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

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

    public class Movies : INotifyPropertyChanged
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
        private DateTime _ReleaseDate;
        public DateTime ReleaseDate
        {
            get { return _ReleaseDate; }
            set
            {
                _ReleaseDate = value;
                OnPropertyChanged();
            }
        }

        public static ObservableCollection <Movies> getMovies()
        {
            var movie = new ObservableCollection<Movies>();
            movie.Add(new Movies() { Name = "Avatar", Genre = MovieTypeEnum.Scifi, Director = "James Cameron", ReleaseDate = new DateTime(2001,2,12) });
            movie.Add(new Movies() { Name = "Dark Knight", Genre = MovieTypeEnum.Fantasy, Director = "Christopher Nolan" });
            movie.Add(new Movies() { Name = "Gilmors girls", Genre = MovieTypeEnum.Action, Director = "Ivan Peric" });
            movie.Add(new Movies() { Name = "The Hatefull Eight", Genre = MovieTypeEnum.Western, Director = "Quentin Tarntino" });
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
