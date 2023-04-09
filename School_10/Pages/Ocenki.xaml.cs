using System.Linq;
using System.Windows;
using System.Windows.Controls;

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
            var Shkola = App.Context.Uroki_Ucheniki.Where(p => p.Ucheniki.User_ID == App.CurrentUser.User_ID).ToList();

            //// Поиск по ФИО
            //Shkola = Shkola.Where(p => p.Ucheniki.Familia.ToLower().Contains(TboxSerch.Text.ToLower())
            //|| p.Ucheniki.Name.ToLower().Contains(TboxSerch.Text.ToLower())
            //|| p.Ucheniki.Otchestvo.ToLower().Contains(TboxSerch.Text.ToLower())
            //).ToList();

            DGService.ItemsSource = Shkola; 
        }



        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateOcenki();
        }

        private void TboxSerch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateOcenki();
        }
    }
}
