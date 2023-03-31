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

namespace School_10.Pages
{
    /// <summary>
    /// Логика взаимодействия для Ocenki.xaml
    /// </summary>
    public partial class Ocenki : Page
    {
        public Ocenki()
        {
            InitializeComponent();
            UpdateOcenki();
        }

        private void UpdateOcenki()
        {
            var Shkola = App.Context.Uroki_Ucheniki.ToList();
            LviewService.ItemsSource = Shkola; 
        }

        private void BntSave_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateOcenki();
        }
    }
}
