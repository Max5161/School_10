using School_10.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace School_10.Pages
{
    /// <summary>
    /// Логика взаимодействия для VistavOcenki.xaml
    /// </summary>
    public partial class VistavOcenki : Page, INotifyPropertyChanged
    {
        public VistavOcenki()
        {
            InitializeComponent();
            DataContext = this;

            DateTime now = DateTime.Now.Date;

            DateTime begin = now;
            DateTime end = begin.AddDays(100);

            Ucheniki = App.Context.Uchenikis.ToList();
            SetRangeDates(begin, end);

        }

        private DataTable _table;
        private DateTime _begin;
        private DateTime _end;

        private List<Ucheniki> ucheniki;
        public List<Ucheniki> Ucheniki { get => ucheniki; set => Set(ref ucheniki, value); }


        public DataTable Table { get => _table; set => Set(ref _table, value); }
        public DateTime Begin { get => _begin; private set => Set(ref _begin, value); }
        public DateTime End { get => _end; private set => Set(ref _end, value); }

        private void SetRangeDates(DateTime begin, DateTime end)
        {
            begin = begin.Date;
            end = end.Date;
            if (Begin == begin && End == end)
                return;

            if (begin < end)
            {
                Begin = begin;
                End = end;
            }
            else
            {
                End = begin;
                Begin = end;
            }

            DataTable table = new DataTable();
            int length = (End - Begin).Days + 1;

            table.Columns.Add("ФИО", typeof(string));
            
            for (int i = 0; i < length; i++)
                table.Columns.Add(Begin.AddDays(i).ToString("dd.MM.yyyy"), typeof(string));

            foreach (var uch in Ucheniki)
            {
                var ocen = uch.Uroki_Ucheniki.Where(o => o.Ucheniki == uch).ToList();
                table.Rows.Add(uch.Familia);

                
                
            }
            

            Table = table;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool Set<T>(ref T field, T value, [CallerMemberName] string prop = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(prop);
            return true;
        }

    }
}
