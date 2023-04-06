using School_10.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Логика взаимодействия для AddShkila.xaml
    /// </summary>
    public partial class AddShkila : Page
    {
        public AddShkila()
        {
            InitializeComponent();
            DataContext = this;
            Shkila1 = new Ucheniki();

            CboxKlass.ItemsSource = App.Context.Klassis.ToList();
        }

        private Ucheniki Shkila1;

        public Ucheniki Ucheniki { get => Shkila1; set => Set(ref Shkila1, value); }


        private void ButtonSaveUrok_Click_1(object sender, RoutedEventArgs e)

        {
            try
            {
                var newUser = new User { Login = (App.Context.Users.Count() + 1).ToString(), Password = (App.Context.Users.Count() + 1).ToString(), Role_ID = 2 };
                Ucheniki.User = newUser;

               App.Context.Uchenikis.Add(Ucheniki);
               App.Context.SaveChanges();

                 NavigationService.GoBack();
            }
          
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);    
            }
        }

        #region INPC

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private bool Set<T>(ref T field, T value, [CallerMemberName] string prop = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(prop);
            return true;
        }

        #endregion

    }
}
