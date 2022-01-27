using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TrainMonitor.View.Autorization
{
    /// <summary>
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Window
    {
        private ViewModel.Autorization.AutorizationViewModel autorizationViewModel;
        public Autorization(ViewModel.Autorization.AutorizationViewModel autorizationViewModel)
        {
            InitializeComponent();
            this.autorizationViewModel = autorizationViewModel; 
            DataContext = this.autorizationViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            autorizationViewModel.Auth(Login.Text, Password.Password);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           BackPassword backPassword=new BackPassword();
            backPassword.Show();
        }
    }
}
