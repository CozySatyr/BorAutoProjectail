using BorAutoProjectail.Appdata;
using BorAutoProjectail.Pages.AddPages;
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

namespace BorAutoProjectail.Pages.GridPages
{
    /// <summary>
    /// Логика взаимодействия для Clients.xaml
    /// </summary>
    public partial class Clients : Page
    {
        public Clients()
        {
            InitializeComponent();
            myDG.ItemsSource = Connection.context.clients.ToList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            myDG.ItemsSource = Connection.context.clients.ToList();
        }

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            Nav.Mframe.Navigate(new AddClients(null));
        }

        private void Btn_Ref_Click(object sender, RoutedEventArgs e)
        {
            myDG.ItemsSource = Connection.context.clients.ToList();
        }

        private void Btn_Del_Click(object sender, RoutedEventArgs e)
        {
            var delEmply = Connection.context.clients.Cast<clients>().ToList();
            if (MessageBox.Show($"Удалить {delEmply.Count} записей?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                Connection.context.clients.RemoveRange(delEmply);
            try
            {
                Connection.context.SaveChanges();
                myDG.ItemsSource = Connection.context.clients.ToList();
            }
            catch
            {
                MessageBox.Show("Не удалось сохранить изменения", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Btn_Back_Click(object sender, RoutedEventArgs e)
        {
            if (Nav.Mframe.CanGoBack)
            {
                Nav.Mframe.GoBack();
            }
        }

        private void Btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            Nav.Mframe.Navigate(new AddClients((sender as Button).DataContext as clients));
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                searchBox.Foreground = Brushes.Black;
                string searchTxt = searchBox.Text;

                if (typeOfSearch.SelectedIndex == 0)
                {
                    int searchInt;
                    if (typeOfSearch.SelectedIndex == 0)
                    {
                        if (int.TryParse(searchTxt, out searchInt))
                        {
                            myDG.ItemsSource = Connection.context.clients.Where(x => x.id.Equals(searchInt)).ToList();
                        }
                    }
                }
                else if (typeOfSearch.SelectedIndex == 1 || typeOfSearch.SelectedIndex == 2)
                {
                    if (typeOfSearch.SelectedIndex == 1)
                    {
                        myDG.ItemsSource = Connection.context.clients.Where(x => x.name.Contains(searchTxt)).ToList();
                    }
                    else if (typeOfSearch.SelectedIndex == 2)
                    {
                        myDG.ItemsSource = Connection.context.clients.Where(x => x.phone_number.Contains(searchTxt)).ToList();
                    }
                }
            }
            catch
            {
                searchBox.Foreground = Brushes.Red;
            }
        }
    }
}
