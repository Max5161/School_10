﻿using School_10.Entities;
using School_10.Pages;
using System;
using System.Collections;
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

namespace School_10
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FrameMain.Navigate(new Pages.Autorization());
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            if (FrameMain.CanGoBack)
                FrameMain.GoBack();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameMain.Navigate(new AddShkila());

            
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
