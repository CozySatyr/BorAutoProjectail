using BorAutoProjectail.Appdata;
using BorAutoProjectail.Pages.GridPages;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BorAutoProjectail.Pages
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void sellsBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.Mframe.Navigate(new Sells());
        }

        private void sellsOtchBtn_Click(object sender, RoutedEventArgs e)
        {
            Reports reports = new Reports();
            reports.GenerateSells();
        }

        private void carsBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.Mframe.Navigate(new Cars());
        }

        private void carsOtchBtn_Click(object sender, RoutedEventArgs e)
        {
            Reports reports = new Reports();
            reports.GenerateCars();
        }

        private void dillersBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.Mframe.Navigate(new Dillers());
        }

        private void dillersOtchBtn_Click(object sender, RoutedEventArgs e)
        {
            Reports reports = new Reports();
            reports.GenerateDillers();
        }

        private void clientsGridBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.Mframe.Navigate(new Clients());
        }

        private void clientsGridOtchBtn_Click(object sender, RoutedEventArgs e)
        {
            Reports reports = new Reports();
            reports.GenerateClients();
        }

        private void usersGridBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.Mframe.Navigate(new Users());
        }

        private void usersGridOtchBtn_Click(object sender, RoutedEventArgs e)
        {
            Reports reports = new Reports();
            reports.GenerateUsers();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          Environment.Exit(0);
        }
    }
}
