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
        public DateTime? date;
        public string add;
        public Movie movie { get; set; }
        public AddWindow()
        {
            InitializeComponent();
           
        }
        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            // ... Get DatePicker reference.
            var picker = sender as DatePicker;

            DateTime? date = picker.SelectedDate;
            // ... Get nullable DateTime from SelectedDate.
            date = picker.SelectedDate;
            if (!date.HasValue)
            {
                // ... A null object.
                this.Title = "No date";
            }
            else
            {
                // ... No need to display the time.
                this.Title = date.Value.ToShortDateString();
            }
        }
        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public List<MovieTypeEnum> Genres
        {
            get
            {
                return Enum.GetValues(typeof(MovieTypeEnum)).Cast<MovieTypeEnum>().ToList<MovieTypeEnum>();
            }
        }

        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            movie = new Movie();

            movie.Name = nameBox.Text;
            movie.Director = directorBox.Text;
            movie.Genre = (MovieTypeEnum)comboBox.SelectedItem;        
            movie.ReleaseDate = datePicker.SelectedDate.Value;

            this.DialogResult = true;
            this.Close();
        }
        //Na Ok treba inicijalizovati movie sa vrednostima sa forme
    }
}
