using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MovieCatalog
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Movies> movies = new ObservableCollection<Movies>();
        public MainWindow()
        {
            movies = Movies.getMovies();

            InitializeComponent();
            dataGrid.ItemsSource = movies;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit?", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            //Iskoristi SearchBox.Text() da bi dobio vrednost search-a. Zatim treba da prodjes kroz listu filmova (odnosno, njihovih imena ili zanra).
            //SearchBox.Text();
        }
        private void Import_Click(object sender, RoutedEventArgs e)
        {

            Microsoft.Win32.OpenFileDialog Import = new Microsoft.Win32.OpenFileDialog();

            Import.DefaultExt = ".xml";
            Import.Filter = "XML Files (*.xml)|*.xml|JSON Files (*.json)|*.json";

            Nullable<bool> result = Import.ShowDialog();
        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog SaveFile = new Microsoft.Win32.SaveFileDialog();
            SaveFile.FileName = "Movies";
            SaveFile.DefaultExt = ".xml"; // Default file extension
            SaveFile.Filter = "XML Files (.xml)|*.xml|JSON Files (*.json)|*.json"; // Filter by extension

            // Show save file dialog box
            Nullable<bool> result = SaveFile.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save
                string filename = SaveFile.FileName;
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Edit win = new Edit();
            win.Show();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to proceed?", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Close();
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addDialog = new AddWindow();

            if (addDialog.ShowDialog() == true)
            {
                movies.Add(addDialog.movie);
                dataGrid.Items.Refresh();
            }
        }
    }
}
