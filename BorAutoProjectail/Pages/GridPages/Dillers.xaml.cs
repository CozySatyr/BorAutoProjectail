﻿using BorAutoProjectail.Appdata;
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
    /// Логика взаимодействия для Dillers.xaml
    /// </summary>
    public partial class Dillers : Page
    {
        public Dillers()
        {
            InitializeComponent();
            myDG.ItemsSource = Connection.context.dillers.ToList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            myDG.ItemsSource = Connection.context.dillers.ToList();
        }

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            Nav.Mframe.Navigate(new AddDillers(null));
        }

        private void Btn_Ref_Click(object sender, RoutedEventArgs e)
        {
            myDG.ItemsSource = Connection.context.dillers.ToList();
        }

        private void Btn_Del_Click(object sender, RoutedEventArgs e)
        {
            var delEmply = Connection.context.dillers.Cast<dillers>().ToList();
            if (MessageBox.Show($"Удалить {delEmply.Count} записей?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                Connection.context.dillers.RemoveRange(delEmply);
            try
            {
                Connection.context.SaveChanges();
                myDG.ItemsSource = Connection.context.dillers.ToList();
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
            Nav.Mframe.Navigate(new AddDillers((sender as Button).DataContext as dillers));
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                searchBox.Foreground = Brushes.Black;
                string searchTxt = searchBox.Text;

                if (typeOfSearch.SelectedIndex == 0 || typeOfSearch.SelectedIndex == 3)
                {
                    if (typeOfSearch.SelectedIndex == 0)
                    {
                        int searchInt;
                        if (int.TryParse(searchTxt, out searchInt))
                        {
                            myDG.ItemsSource = Connection.context.dillers.Where(x => x.id.Equals(searchInt)).ToList();
                        }
                    }
                    if (typeOfSearch.SelectedIndex == 3)
                    {
                        int searchInt;
                        if (int.TryParse(searchTxt, out searchInt))
                        {
                            myDG.ItemsSource = Connection.context.dillers.Where(x => x.salary.Equals(searchTxt)).ToList();
                        }
                    }
                }
                else if (typeOfSearch.SelectedIndex == 1 || typeOfSearch.SelectedIndex == 2)
                {
                    if (typeOfSearch.SelectedIndex == 1)
                    {
                        myDG.ItemsSource = Connection.context.dillers.Where(x => x.name.Contains(searchTxt)).ToList();
                    }
                    else if (typeOfSearch.SelectedIndex == 2)
                    {
                        myDG.ItemsSource = Connection.context.dillers.Where(x => x.phone_number.Contains(searchTxt)).ToList();
                    }
                }
            }
            catch
            {
                searchBox.Foreground = Brushes.Red;
            }
        }

        private void myDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
