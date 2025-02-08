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
    /// Логика взаимодействия для AddCars.xaml
    /// </summary>
    public partial class AddCars : Page
    {
        bool checkNew;
        cars cars;
        public AddCars(cars c)
        {
            InitializeComponent();
            if (c == null)
            {
                c = new cars();
                checkNew = true;
            }
            else
                checkNew = false;
            DataContext = cars = c;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (checkNew)
            {
                Connection.context.cars.Add(cars);
            }
            try
            {
                Connection.context.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Не удалось сохранить изменения", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Nav.Mframe.Navigate(new Cars());
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
