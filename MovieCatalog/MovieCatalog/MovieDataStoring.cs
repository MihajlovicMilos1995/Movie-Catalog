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
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string ReleaseDate { get; set; }

        public static MovieDataStoring GetMovieData()
        {
            var Film = new MovieDataStoring()
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
