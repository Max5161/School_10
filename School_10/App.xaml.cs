using School_10.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace School_10
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Entities.School10Entities Context
        { get; } = new Entities.School10Entities();

        public static User CurrentUser { get; set; } = null;
    }
}
