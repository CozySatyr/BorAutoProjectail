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

namespace BorAutoProjectail.Pages.AddPages
{
    /// <summary>
    /// Логика взаимодействия для AddClients.xaml
    /// </summary>
    public partial class AddClients : Page
    {
        bool checkNew;
        clients clients;
        public AddClients(clients c)
        {
            InitializeComponent();
            if (c == null)
            {
                c = new Appdata.clients();
                checkNew = true;
            }
            else
                checkNew = false;
            DataContext = clients = c;
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (checkNew)
            {
                Connection.context.clients.Add(clients);
            }
            try
            {
                Connection.context.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Не удалось сохранить изменения", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Nav.Mframe.Navigate(new Clients());
        }

        private void Btn_Back_Click(object sender, RoutedEventArgs e)
        {
            if (Nav.Mframe.CanGoBack)
            {
                Nav.Mframe.GoBack();
            }
        }
    }
}
