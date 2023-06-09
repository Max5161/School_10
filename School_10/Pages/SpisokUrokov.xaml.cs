﻿using School_10.Commands;
using School_10.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace School_10.Pages
{
    /// <summary>
    /// Логика взаимодействия для SpisokUrokov.xaml
    /// </summary>
    public partial class SpisokUrokov : Page, INotifyPropertyChanged
    {
        private readonly School10Entities db;
        private readonly User user;

        public SpisokUrokov(User user)
        {
            InitializeComponent();
            DataContext = this;
            this.user = user;
        }

        // Список Уроков
        private List<Uroki> uroki;
        public List<Uroki> Urokis { get => uroki; 
            set 
            { 
               if( Set(ref uroki, value))
                {
                    urokiViewSource = new CollectionViewSource
                    {
                        Source = value,
                        SortDescriptions = {
                        new SortDescription(nameof(Uroki.ID_Uroka), ListSortDirection.Ascending )
                    }
                    };

                    urokiViewSource.Filter += new FilterEventHandler(OnDateFilter);
                    urokiViewSource.Filter += TodayOnlyFilter;

                    urokiViewSource.View.Refresh();
                    OnPropertyChanged(nameof(UrokiView));
                } 
            } 
        }

        private void TodayOnlyFilter(object sender, FilterEventArgs e)
        {
            if (TodayOnly != true) return;
            if (e.Item is Uroki urokit == false) return;

            if (urokit.Date != DateTime.Now.Date)
                e.Accepted = false;
        }

        private string visibilityAdmin  = "Collapsed";
        public string VisibilityAdmin { get => visibilityAdmin; set { Set(ref visibilityAdmin, value); } }

        private CollectionViewSource urokiViewSource;
        public ICollectionView UrokiView => urokiViewSource?.View;

        // 
        private bool todayOnly;
        public bool TodayOnly { get => todayOnly; set { if (Set(ref todayOnly, value)) urokiViewSource?.View.Refresh(); } }


        // Выбранный урок
        private Uroki selectedUrok;
        public Uroki SelectedUrok { get => selectedUrok; set => Set(ref selectedUrok, value);  }
         
        // Дата урока
        private DateTime selectedFirstDate = Convert.ToDateTime("24.02.2020");
        private DateTime selectedSecondDate = DateTime.Now;
        public DateTime SelectedFirstDate { get => selectedFirstDate; set { if( Set(ref selectedFirstDate, value)) urokiViewSource.View.Refresh(); } }
        public DateTime SelectedSecondDate { get => selectedSecondDate; set { if (Set(ref selectedSecondDate, value)) urokiViewSource.View.Refresh(); } }



        // Комманды открытия страцы "Выставения оценок"
        private RelayCommand openUrokCmd;
        public RelayCommand OpenUrokCmd => openUrokCmd ?? (openUrokCmd = new RelayCommand(obj => OpenVistavlenieUrok()));

        private RelayCommand deleteUrokCmd;
        public RelayCommand DeleteUrokCmd => deleteUrokCmd ?? (deleteUrokCmd = new RelayCommand(obj => RemoveUrok(SelectedUrok)));
        private void RemoveUrok(Uroki urok)
        {
            if (urok is null) return;


            using (var db = new School10Entities())
            {
                // db.Urokis.Remove(urok);
                db.Urokis.Attach(urok);
                db.Entry(urok).State = EntityState.Deleted;
                db.SaveChanges();
            }
            urokiViewSource.View.Refresh();
        }


        private void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if(user.Role_ID == 3)
            {
                VisibilityAdmin = "Visible";
                using (var db = new School10Entities())
                {
                    Urokis = db.Urokis.Include("Predmeti").Include("Teacher").Include("Klassi").ToList();
                }
            }
            if (user.Role_ID == 1)
            {
                VisibilityAdmin = "Collapsed";
                using (var db = new School10Entities())
                {
                    Urokis = db.Urokis.Include("Predmeti").Include("Teacher").Include("Klassi").Where(p => p.Teacher.User_ID == user.User_ID).ToList();
                }
            }
            //Uroki = App.Context.Urokis.ToList();
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

        private void OpenVistavlenieUrok()
        {
            if (SelectedUrok is null) return;
            NavigationService.Navigate(new VistavlenOcenok(SelectedUrok));
        }

        // Фильтр по датам
        private void OnDateFilter(object sender, FilterEventArgs e)
        {
            var obj = e.Item as Uroki;
            if (obj != null)
            {
                if (obj.Date >= SelectedFirstDate && obj.Date <= SelectedSecondDate)
                    e.Accepted = true;
                else
                    e.Accepted = false;
            };
        }

        private void ButtonDabavUrok_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddUchniki());
        }

        private void ButtonDabavUchenik_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddShkila());
        }
    }
    
}
