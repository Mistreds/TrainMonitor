using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
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
            ViewModel.Autorization.AutorizationViewModel autorizationViewModel = new ViewModel.Autorization.AutorizationViewModel(); 
        //    this.DispatcherUnhandledException += new DispatcherUnhandledExceptionEventHandler(App_DispatcherUnhandledException);
        }
        void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            // Process unhandled exception
            MessageBox.Show($"{e.Exception.Message} {e.Exception.StackTrace}", "Ошибка");
            // Prevent default unhandled exception processing
            e.Handled = true;
        }
    }
}
