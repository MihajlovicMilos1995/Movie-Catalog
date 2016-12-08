using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MovieCatalog
{
    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public string add;
        public MovieDataStoring movie;
        public AddWindow()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public List<Genre> Genres
        {
            get
            {
                return Enum.GetValues(typeof(Genre)).Cast<Genre>().ToList<Genre>();
            }
        }

        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            string addName = textBox.Text;
            //int addGenre = (int)Genre.;
            string addDirector = textBox1.Text;
            movie = new MovieDataStoring();
        }
        //Na Ok treba inicijalizovati movie sa vrednostima sa forme
    }
}
