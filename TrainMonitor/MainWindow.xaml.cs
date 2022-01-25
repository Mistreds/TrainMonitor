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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TrainMonitor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(Model.Employee.Employee employee )
        {
            InitializeComponent();
            DataContext = new ViewModel.MainViewModel();
            IsValid(employee);
        }
       private void IsValid(Model.Employee.Employee employee)
        {
            Cadr.Visibility = Visibility.Collapsed;
            Graph.Visibility = Visibility.Collapsed;
            Traid.Visibility = Visibility.Collapsed;
            Disp.Visibility = Visibility.Collapsed;
            MainMeh.Visibility = Visibility.Collapsed;  

            if(employee.EmployeePost.Any(p=>p.Post.RoleId==1))
            {
                Cadr.Visibility = Visibility.Visible;
                Graph.Visibility = Visibility.Visible;
                Traid.Visibility = Visibility.Visible;
                Disp.Visibility = Visibility.Visible;
                MainMeh.Visibility = Visibility.Visible;

                return;
            }
            if (employee.EmployeePost.Any(p => p.Post.RoleId == 2))
            {
                Cadr.Visibility = Visibility.Visible;
            }
            if (employee.EmployeePost.Any(p => p.Post.RoleId == 3))
            {
                Graph.Visibility = Visibility.Visible;
            }
            if (employee.EmployeePost.Any(p => p.Post.RoleId == 4))
            {
                Traid.Visibility = Visibility.Visible;
            }
            if (employee.EmployeePost.Any(p => p.Post.RoleId == 5))
            {
                Disp.Visibility = Visibility.Visible;
            }
            if (employee.EmployeePost.Any(p => p.Post.RoleId == 6))
            {
                MainMeh.Visibility = Visibility.Visible;
            }
        }

        
    }
}
