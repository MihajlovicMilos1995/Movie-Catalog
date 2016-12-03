using System;
using System.Collections.Generic;
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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            dataGrid.ItemsSource = MovieDataStoring.getMovies();
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

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddWindow win2 = new AddWindow();
            win2.Show();           
        }

        private void Import_Click(object sender, RoutedEventArgs e)
        {

            Microsoft.Win32.OpenFileDialog ExplorerOpen = new Microsoft.Win32.OpenFileDialog();

            ExplorerOpen.DefaultExt = ".xml";
            ExplorerOpen.Filter = "XML Files (*.xml)|*.xml|JSON Files (*.json)|*.json";

            Nullable<bool> result = ExplorerOpen.ShowDialog();
        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog SaveFile = new Microsoft.Win32.SaveFileDialog();
            SaveFile.FileName = "Document"; // Default file name
            SaveFile.DefaultExt = ".xml"; // Default file extension
            SaveFile.Filter = "XML Files (.xml)|*.xml|JSON Files (*.json)|*.json"; // Filter files by extension

            // Show save file dialog box
            Nullable<bool> result = SaveFile.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                string filename = SaveFile.FileName;
            }
        }
    }
}
