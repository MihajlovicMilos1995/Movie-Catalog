using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MovieCatalog
{
    public partial class MainWindow : Window
    {
        public MainWindowViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();
            viewModel = new MainWindowViewModel();
            DataContext = viewModel;
        }

        private void dataGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            (sender as DataGrid).SelectedItem = null;
        }
    }
}
