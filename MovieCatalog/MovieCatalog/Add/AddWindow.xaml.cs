using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace MovieCatalog
{
    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public Movie AddMovie { get; set; }
        public ICommand OkCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public AddWindow()
        {
            OkCommand = new DelegateCommand(Ok);
            CancelCommand = new DelegateCommand(Cancel);

            AddMovie = new Movie();

            InitializeComponent();

        }

        //Ok funkcija
        public void Ok()
        {

            this.DialogResult = true;
            this.Close();
        }

        //Cancel funkcija
        public void Cancel()
        {
            this.Close();
        }

        public List<MovieTypeEnum> Genres
        {
            get
            {
                return Enum.GetValues(typeof(MovieTypeEnum)).Cast<MovieTypeEnum>().ToList<MovieTypeEnum>();
            }
        }
    }
}
