using School_10.Commands;
using School_10.Entities;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace School_10.Pages
{
    /// <summary>
    /// Логика взаимодействия для VistavlenOcenok.xaml
    /// </summary>
    public partial class VistavlenOcenok : Page, INotifyPropertyChanged
    {

        public VistavlenOcenok(Uroki predmet)
        {
            InitializeComponent();
            DataContext = this;
            this.predmet = predmet;
        }

        private readonly Uroki predmet;

        private List<Uroki_Ucheniki> urok;
        public List<Uroki_Ucheniki> Urok { get => urok; set { Set(ref urok, value); } }

        private Uroki_Ucheniki selectedUrok;
        public Uroki_Ucheniki SelectedUrok { get => selectedUrok; set { if ( Set(ref selectedUrok, value)) UpdateUrok(); } }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Urok = App.Context.Uroki_Ucheniki.Where(p => p.Uroki.ID_Uroka == predmet.ID_Uroka).ToList();
        }


        private RelayCommand updateUrok;
        public RelayCommand UpdateUrokCmd { 
            get 
            { 
                if (updateUrok is null) 
                    updateUrok = new RelayCommand(obj => UpdateUrok());
                return updateUrok;
            }
        }

        

        private void UpdateUrok()
        {
            if (selectedUrok != null)
            {
                //App.Context.Uroki_Ucheniki.Attach(SelectedUrok);
                //App.Context.Entry(SelectedUrok).Property(x => x.Ocenka).IsModified = true;
                //App.Context.Entry(SelectedUrok).CurrentValues.SetValues(SelectedUrok);
                var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
                var context = new ValidationContext(SelectedUrok);
                if (!Validator.TryValidateObject(SelectedUrok, context, results, true))
                {
                    foreach (var error in results)
                    {
                        MessageBox.Show(error.ErrorMessage);
                    }
                }
                else
                {
                    App.Context.Entry(SelectedUrok).State = EntityState.Modified;
                    App.Context.SaveChanges();
                }
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
