﻿using BorAutoProjectail.Appdata;
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
    /// Логика взаимодействия для AddDillers.xaml
    /// </summary>
    public partial class AddDillers : Page
    {
        bool checkNew;
        dillers dillers;
        public AddDillers(dillers c)
        {
            InitializeComponent();
            if (c == null)
            {
                c = new dillers();
                checkNew = true;
            }
            else
                checkNew = false;
            DataContext = dillers = c;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (checkNew)
            {
                Connection.context.dillers.Add(dillers);
            }
            try
            {
                Connection.context.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Не удалось сохранить изменения", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Nav.Mframe.Navigate(new Dillers());
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
