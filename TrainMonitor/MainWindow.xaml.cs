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
        private ViewModel.MainViewModel mainViewModel;
        public MainWindow(Model.Employee.Employee employee )
        {
            InitializeComponent();
            mainViewModel = new ViewModel.MainViewModel(employee);
            DataContext = mainViewModel;
            IsValid(employee);
        }
       private void IsValid(Model.Employee.Employee employee)
        {
          

            if(employee.EmployeePost.Any(p=>p.Post.RoleId==1))
            {

                ViewModel.MainViewModel.EmployeeViewModel.is_read_only_brigade = true;
                ViewModel.MainViewModel.EmployeeViewModel.is_read_only_Dep=true;
                ViewModel.MainViewModel.EmployeeViewModel.is_read_only_emp=true;
                ViewModel.MainViewModel.EmployeeViewModel.is_read_only_Med = true;
                ViewModel.MainViewModel.EmployeeViewModel.is_read_only_post=true;
                ViewModel.MainViewModel.RouteViewModel.Route_read_only = true;
                ViewModel.MainViewModel.RouteViewModel.Station_read_only = true;
                ViewModel.MainViewModel.RouteViewModel.Schedules_read_only = true;
                ViewModel.MainViewModel.RouteViewModel.Ticket_read_only = true;
                ViewModel.MainViewModel.TrainViewModel.train_read_only = true;
                ViewModel.MainViewModel.TrainViewModel.train_WorkTypes_read_only = true;
                ViewModel.MainViewModel.TrainViewModel.train_TrainMaintances_read_only = true;
                return;
            }
            if (employee.EmployeePost.Any(p => p.Post.RoleId == 2))
            {
                ViewModel.MainViewModel.EmployeeViewModel.is_read_only_brigade = true;
                ViewModel.MainViewModel.EmployeeViewModel.is_read_only_Dep = true;
                ViewModel.MainViewModel.EmployeeViewModel.is_read_only_emp = true;
                ViewModel.MainViewModel.EmployeeViewModel.is_read_only_Med = true;
                ViewModel.MainViewModel.EmployeeViewModel.is_read_only_post = true;
            }
            if (employee.EmployeePost.Any(p => p.Post.RoleId == 3))
            {
                ViewModel.MainViewModel.RouteViewModel.Route_read_only = true;
                ViewModel.MainViewModel.RouteViewModel.Station_read_only=true;
                ViewModel.MainViewModel.RouteViewModel.Schedules_read_only = true;
            }
            if (employee.EmployeePost.Any(p => p.Post.RoleId == 4))
            {
                ViewModel.MainViewModel.RouteViewModel.Ticket_read_only = true;
            }
            if (employee.EmployeePost.Any(p => p.Post.RoleId == 5))
            {
                ViewModel.MainViewModel.TrainViewModel.train_read_only = true;
            }
            if (employee.EmployeePost.Any(p => p.Post.RoleId == 6))
            {
                ViewModel.MainViewModel.TrainViewModel.train_read_only = true;
                ViewModel.MainViewModel.TrainViewModel.train_WorkTypes_read_only = true;
                ViewModel.MainViewModel.TrainViewModel.train_TrainMaintances_read_only = true;
            }
        }

        
    }
}
