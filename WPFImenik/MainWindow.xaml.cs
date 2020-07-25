using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WPFImenik
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Osoba> Imenik = new ObservableCollection<Osoba>();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new Osoba();
            BindingGroup = new BindingGroup();
            prikaz.ItemsSource = Imenik;

        }

        private void Unos(object sender, RoutedEventArgs e)
        {
            BindingGroup.CommitEdit();
             if(DataContext is Osoba o)
            {
                if(!Imenik.Contains(o))
                {
                    Imenik.Add(o);
                }
                DataContext = new Osoba();
            }

        }

        private void izmena(object sender, RoutedEventArgs e)
        {
            if (prikaz.SelectedItem != null)
            {
                DataContext = prikaz.SelectedItem;
            }

        }

        private void brisanje(object sender, RoutedEventArgs e)
        {
            Imenik.Remove(prikaz.SelectedItem as Osoba);
        }
    }
}
