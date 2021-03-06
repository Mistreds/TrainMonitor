using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace TrainMonitor.ViewModel.Employee
{
    public class EmployeeViewModel : BaseViewModel
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
            get => _posts;
            set
            {
                _posts = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Model.Employee.Post> _posts_combo;
        public ObservableCollection<Model.Employee.Post> PostsCombo
        {
            get => _posts_combo;
            set
            {
                _posts_combo = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Model.Employee.Employee> _employees;
        public ObservableCollection<Model.Employee.Employee> Employees
        {
            get => _employees;
            set
            {
                _employees = value;
                OnPropertyChanged();
            }
        }
      
        private ObservableCollection<Model.Employee.Employee> _employees_combo;
        public ObservableCollection<Model.Employee.Employee> EmployeesCombo
        {
            get => _employees_combo;
            set
            {
                _employees_combo = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Model.Employee.Brigade> _brigades;
        public ObservableCollection<Model.Employee.Brigade> Brigades
        {
            get => _brigades;
            set
            {
                _brigades = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Model.Employee.Brigade> _brigades_combo;
        public ObservableCollection<Model.Employee.Brigade> BrigadesCombo
        {
            get => _brigades_combo;
            set
            {
                _brigades_combo = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Model.Employee.MedicalExamination> _medicalExamination;
        public ObservableCollection<Model.Employee.MedicalExamination> MedicalExaminations
        {
            get => _medicalExamination;
            set
            {
                _medicalExamination = value;
                OnPropertyChanged();
            }
        }
        public bool is_read_only_emp { get; set; }
        public bool is_read_only_post { get; set; }
        public bool is_read_only_brigade { get; set; }
        public bool is_read_only_Med { get; set; }
        public bool is_read_only_Dep { get; set; }
        public List<Model.Employee.Role> Roles { get;private set; }
        public EmployeeViewModel()
        {
      
            //observablecollection это коллекция с отслеживанием изменений, идеальна для патерна mvvm
            //Тут инициализация коллеций
            //Из модель обращается к базе данных, и данный view model получает коллекцию
            //Для выпадающего меню необходимо обновить доп коллекцию
            //Отдел
            Departments = MainViewModel.EmployeeModel.GetDepartments();
            DepartmentsCombo = MainViewModel.EmployeeModel.GetDepartmentsCombo();
            //Должность
            Posts = MainViewModel.EmployeeModel.GetDepartmentsPost();
            PostsCombo = MainViewModel.EmployeeModel.GetDepartmentsPostCombo();
            //Сотрудники
            Employees = MainViewModel.EmployeeModel.GetEmployee();
            EmployeesCombo = MainViewModel.EmployeeModel.GetEmployee();
            //Бригады
            Brigades = MainViewModel.EmployeeModel.GetBrigades();
            BrigadesCombo = MainViewModel.EmployeeModel.GetBrigadesCombo();
            //мед осмотр
            MedicalExaminations = MainViewModel.EmployeeModel.GetMedicalExaminations();
            //роли
            Roles = MainViewModel.EmployeeModel.GetRole();
            //остальные модели аналогичные

        }
        public ICommand UpdateDepart => new RelayCommand(() => {
            //обновление подразделений
            MainViewModel.EmployeeModel.UpdateDepartment(Departments);
            Departments = MainViewModel.EmployeeModel.GetDepartments();
            DepartmentsCombo = MainViewModel.EmployeeModel.GetDepartmentsCombo();
        });
        public ICommand CanselDepart => new RelayCommand(() => {//отмена обновления, возврат данных из базы
            Departments = MainViewModel.EmployeeModel.GetDepartments();
            DepartmentsCombo = MainViewModel.EmployeeModel.GetDepartmentsCombo();
        });
        public ICommand UpdatePost => new RelayCommand(() => {
            //Тут и далее все по аналогии с обновлением и отменой обновления подразделений
            MainViewModel.EmployeeModel.UpdatePost(Posts);
            Posts = MainViewModel.EmployeeModel.GetDepartmentsPost();
            PostsCombo = MainViewModel.EmployeeModel.GetDepartmentsPostCombo();
        });
        public ICommand CanselPost => new RelayCommand(() => { Posts = MainViewModel.EmployeeModel.GetDepartmentsPost();
            PostsCombo = MainViewModel.EmployeeModel.GetDepartmentsPostCombo();
        });
        public ICommand UpdateEmployee => new RelayCommand(() => {
            MainViewModel.EmployeeModel.UpdateEmployee(Employees);
            Employees = MainViewModel.EmployeeModel.GetEmployee();
            EmployeesCombo = MainViewModel.EmployeeModel.GetEmployee();
            MainViewModel.RouteViewModel.EmployeesCombo= EmployeesCombo;
        });
        public ICommand CanselEmployee => new RelayCommand(() => {
            Employees = MainViewModel.EmployeeModel.GetEmployee();
            EmployeesCombo = MainViewModel.EmployeeModel.GetEmployee();
        });
        public ICommand UpdateBrigade => new RelayCommand(() => {
            MainViewModel.EmployeeModel.UpdateBrigade(Brigades);
            Brigades = MainViewModel.EmployeeModel.GetBrigades();
            BrigadesCombo = MainViewModel.EmployeeModel.GetBrigadesCombo();
            MainViewModel.TrainViewModel.BrigadesCombo=MainViewModel.EmployeeModel.GetBrigadesCombo();
        });
        public ICommand CanselBrigade => new RelayCommand(() => {
            Brigades = MainViewModel.EmployeeModel.GetBrigades();
            BrigadesCombo = MainViewModel.EmployeeModel.GetBrigadesCombo();
        });
        public ICommand UpdateMedical => new RelayCommand(() => {
            MainViewModel.EmployeeModel.UpdateMedical(MedicalExaminations);
            MedicalExaminations = MainViewModel.EmployeeModel.GetMedicalExaminations();
        });
        public ICommand CanselMedical => new RelayCommand(() => { MedicalExaminations = MainViewModel.EmployeeModel.GetMedicalExaminations(); });
        public ICommand AddEmployee => new RelayCommand(() => {

            //Тут мы открывает view model с регистрацией нового пользователя, но без подтверждения по емайлу
            var reg = new ViewModel.Autorization.RegistrationViewModel(true);
        
        });
        
    }
}
