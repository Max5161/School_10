using School_10.Entities;
using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace School_10.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddUchniki.xaml
    /// </summary>
    public partial class AddUchniki : Page, INotifyPropertyChanged
    {
        private Entities.Uroki _currentService = null;

        private Uroki urok;

        public Uroki Urok { get => urok; set => Set(ref urok, value); }

        public AddUchniki()
        {
            InitializeComponent();
            DataContext = this;
            Urok = new Uroki();

            Cbox_FIO_Teacher.ItemsSource = App.Context.Teachers.ToList();
            CboxIDPredmeta.ItemsSource = App.Context.Predmetis.ToList();
            CboxIDKlassa.ItemsSource = App.Context.Klassis.ToList();
        }


        private void ButtonSaveUrok_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                      App.Context.Urokis.Add(Urok);
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
