using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TrainMonitor.ViewModel.Employee
{
    public class EmployeeViewModel:BaseViewModel
    {
        private ObservableCollection<Model.Employee.Department> _departments;
        public ObservableCollection<Model.Employee.Department> Departments
        {
            get => _departments;
            set
            {
                _departments = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Model.Employee.Department> _departments_combo;
        public ObservableCollection<Model.Employee.Department> DepartmentsCombo
        {
            get => _departments_combo;
            set
            {
                _departments_combo = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Model.Employee.Post> _posts;
        public ObservableCollection<Model.Employee.Post> Posts
        {
            get=> _posts;
            set
            {
                _posts = value;
                OnPropertyChanged();
            }
        }
        public EmployeeViewModel()
        {
            Departments = MainViewModel.EmployeeModel.GetDepartments();
            DepartmentsCombo=MainViewModel.EmployeeModel.GetDepartmentsCombo();
            Posts = MainViewModel.EmployeeModel.GetDepartmentsPost();

        }
        public ICommand UpdateDepart => new RelayCommand(() => {
            Departments = MainViewModel.EmployeeModel.GetDepartments();
            DepartmentsCombo = MainViewModel.EmployeeModel.GetDepartmentsCombo();
        });
        public ICommand CanselDepart => new RelayCommand(() => {
            Departments = MainViewModel.EmployeeModel.GetDepartments();
            DepartmentsCombo = MainViewModel.EmployeeModel.GetDepartmentsCombo();
        });
        public ICommand UpdatePost => new RelayCommand(() => { Posts = MainViewModel.EmployeeModel.GetDepartmentsPost(); });
        public ICommand CanselPost => new RelayCommand(() => { Posts = MainViewModel.EmployeeModel.GetDepartmentsPost(); });
    }
}
