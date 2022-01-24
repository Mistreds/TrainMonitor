using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TrainMonitor.Model;

namespace TrainMonitor
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            View.Autorization.Autorization autorization = new View.Autorization.Autorization();
            autorization.Show();
           
        }
    }
}
