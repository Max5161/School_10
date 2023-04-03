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
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Page
    {
        public Autorization()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            var User = App.Context.Users
                .FirstOrDefault(p => p.Login == TBoxLogin.Text && p.Password == PBoxPassword.Password);
            if (User != null)
            {
                switch (User.Role_ID)
                {
                    case 1:
                        // Teacher
                        App.CurrentUser = User;
                        NavigationService.Navigate(new SpisokUrokov(User));
                        break;
                    case 2:
                        // Uchenik
                        App.CurrentUser = User;
                        NavigationService.Navigate(new Ocenki());
                        break;
                    case 3:
                        //Admin
                        App.CurrentUser = User; 
                        NavigationService.Navigate(new SpisokUrokov(User));
                        break;
                }
            }
            else
            {
                MessageBox.Show("Пользователь с такими данными не найден.", "Ошибки",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
