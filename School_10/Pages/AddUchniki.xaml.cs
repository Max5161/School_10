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

            Cbox_FIO_Teacher.ItemsSource = App.Context.Teachers.ToList();
            CboxIDPredmeta.ItemsSource = App.Context.Predmetis.ToList();
            CboxIDKlassa.ItemsSource = App.Context.Klassis.ToList();
        }


        private void ButtonSaveUrok_Click(object sender, RoutedEventArgs e)
        {
           using (var db = new School10Entities())
            {
                db.Urokis.Add(Urok);
                db.SaveChanges();
            }
            NavigationService.GoBack();
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
