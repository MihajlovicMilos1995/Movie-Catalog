using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog
{
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
        private string _Genre;
        public string Genre
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

        public static MovieDataStoring GetMovieData()
        {
            List<string> list1 = new List<string>(new string[] { "Film1", "Film2", "Film3", "Film4" });
            {
                Name = "Avatar",
                Genre = "Action",
                Director = "James Cameron",
                ReleaseDate = "18/12/2009 12:00:00"
            };
            return Film;
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
