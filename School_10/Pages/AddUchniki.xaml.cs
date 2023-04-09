using School_10.Entities;
using System;
using System.Collections.Generic;
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


                var ucheniki = App.Context.Uchenikis.Where(p => p.Klass_ID == Urok.Klass_ID).ToList();

                var urokUchenik = new List<Uroki_Ucheniki>();
                foreach (var item in ucheniki)
                {
                    urokUchenik.Add(new Uroki_Ucheniki { Uroki_ID = Urok.ID_Uroka, Uchenik_ID = item.Uchenik_ID });
                }

                App.Context.Uroki_Ucheniki.AddRange(urokUchenik);

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
