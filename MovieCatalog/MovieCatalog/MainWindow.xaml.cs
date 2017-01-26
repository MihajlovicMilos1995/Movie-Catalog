using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Data.Entity;
using System.Linq;

namespace MovieCatalog
{
    public partial class MainWindow : Window
    {
        public MainWindowViewModel viewModel;
       
        public MainWindow()
        {
            InitializeComponent();
            viewModel = new MainWindowViewModel();
            using (var ctx = new MovieContext ())
            {
                var filmici = ctx.Movies.ToList();
                foreach (var film in filmici)
                {
                    viewModel.Movies.Add(film);
                }
                
            }

            DataContext = viewModel;
        }

        private void dataGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            (sender as DataGrid).SelectedItem = null;
        }
    }
}

