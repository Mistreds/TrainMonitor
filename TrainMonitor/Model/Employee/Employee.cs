using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainMonitor.Model.Employee
{
    public class Employee : BaseViewModel
    {
        private int _id_employee;
        public Employee(int idEmployee, string login, string email, string password, string surname, string name, string patronymic, string passportSeries, string passportNumber, DateTime birthDate, int postId)
        {
            _id_employee = idEmployee;
            _login = login;
            _email = email;
            _password = password;
            _surname = surname;
            _name = name;
            _patronymic = patronymic;
            _passport_series = passportSeries;
            _passport_number = passportNumber;
            _birth_date = birthDate;
            _post_id = postId;
        }

        [Key]
        public int ID_Employee
        {
            get => _id_employee;
            set
            {
                _id_employee = value;
                OnPropertyChanged();
            }
        }
        private string _login;
        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged();
            }
        }
        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }
        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }
        private string _surname;
        public string Surname
        {
            get => _surname;
            set
            {
                _surname = value;
                OnPropertyChanged();
            }
        }
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        private string _patronymic;
        public string Patronymic
        {
            get => _patronymic;
            set
            {
                _patronymic = value;
                OnPropertyChanged();
            }
        }
        private string _passport_series;
        [MinLength(4),MaxLength(4)]
        public string Passport_Series
        {
            get => _passport_series;
            set
            {
                _passport_series = value;
                OnPropertyChanged();
            }

        }
            private string _passport_number;
        [MinLength(4),MaxLength(6)]
        public string Passport_Number
        {
            get => _passport_number;
            set
            {
                _passport_number = value;
                OnPropertyChanged();
            }
        }
        private DateTime _birth_date;
        public DateTime Birth_Date
        {
            get => _birth_date;
            set
            {
                _birth_date = value;
                OnPropertyChanged();
            }
        }
        private  int _post_id;

        public int PostId
        {
            get => _post_id;
            set
            {
                _post_id = value;
                OnPropertyChanged();
            }
        }

        private Post _post;

        public Post Post
        {
            get => _post;
            set
            {
                _post = value;
                OnPropertyChanged();
            }
        }
        private int _brigade_id;

      
        public int BrigadeId
        {
            get => _brigade_id;
            set
            {
                _brigade_id = value;
                OnPropertyChanged();
            }
        }

        private Brigade _brigade;

        public Brigade Brigade
        {
            get =>  _brigade;
            set
            {
                _brigade = value;
                OnPropertyChanged();
            }
        }
        public  Employee(){}

    }
    public class Department:BaseViewModel
    {
        private int _id_department;
        [Key]
        public int ID_Department
        {
            get=> _id_department;
            set
            {
                _id_department = value;
                OnPropertyChanged();
            }
        }
        private string _department_name;
        public string DepartmentName
        {
            get => _department_name;
            set
            {
                _department_name = value;
                OnPropertyChanged();
            }
        }
        public  Department(){}

        public Department(int idDepartment, string departmentName)
        {
            this.ID_Department = idDepartment;
            this.DepartmentName = departmentName;
        }
    }
    public class Post:BaseViewModel
    {
        private int _id_post;
        [Key]
        public int ID_Post
        {
            get => _id_post;
            set
            {
                _id_post = value;
                OnPropertyChanged();
                
            }
        }

        private string _post_name;

        public string PostName
        {
            get => _post_name;
            set
            {
                _post_name = value;
                OnPropertyChanged();
            }
        }
        private int _salary;

        public int Salary
        {
            get => _salary;
            set
            {
                _salary = value;
                OnPropertyChanged();
            }
        }

        private int department_id;

        public int DepartmentId
        {
            get => department_id;
            set
            {
                department_id = value;
                OnPropertyChanged();
            }
        }

        private Department _department;

        public Department Department
        {
            get => _department;
            set
            {
                _department = value;
                OnPropertyChanged();
            }
        }
        public  Post(){}

        public Post(int _id, string postName, int salary, int departmentId)
        {
            ID_Post = _id;
            PostName = postName;
            Salary = salary;
            DepartmentId = departmentId;
        }
    }
    public class Brigade:BaseViewModel
    {
        private int _id_brigade;
        [Key]
        public int Id_Brigade
        {
            get => _id_brigade;
            set
            {
                _id_brigade = value;
                OnPropertyChanged();
            }
        }
        private string _brigade_name;
        public string BrigadeName
        {
            get => _brigade_name;
            set
            {
                _brigade_name = value;
                OnPropertyChanged();
            }
        }

        public Brigade(){}

        public Brigade(int idBrigade, string brigadeName)
        {
            _id_brigade = idBrigade;
            _brigade_name = brigadeName;
        }
    }
}

