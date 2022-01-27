using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TrainMonitor.Model.Employee
{
    public class Employee : BaseViewModel
    {
        private int _id_employee;
        public Employee(int idEmployee, string login, string email, string password, string surname, string name, string patronymic, string passportSeries, string passportNumber, DateTime birthDate)
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
            
        }
       
        [Key]// инициализация первичного ключа
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
                Regex regex_login = new Regex("([A-Z])|([a-z])");
               
                _login = value;
                
                _login = Regex.Replace(_login, @"[(\s!@\#\$%\^&\*\(\)_\+=\-'\\:\|/`~\.,\{}\)]+", "");
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
                _surname = Regex.Replace(_surname, @"[0-9\(\s!@\#\$%\^&\*\(\)_\+=\-'\\:\|/`~\.,\{}\)]+", "");
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
                _name = Regex.Replace(_name, @"[0-9\(\s!@\#\$%\^&\*\(\)_\+=\-'\\:\|/`~\.,\{}\)]+", "");
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
                _patronymic = Regex.Replace(_patronymic, @"[0-9\(\s!@\#\$%\^&\*\(\)_\+=\-'\\:\|/`~\.,\{}\)]+", "");
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
                if (value != null)
                {
                    if (value.Length > 4)
                        return;
                    _passport_series = Regex.Replace(value, @"[^\d]+", "");

                }
                OnPropertyChanged();
            }

        }
            private string _passport_number;
        [MinLength(6),MaxLength(6)]//длина строки в базе
        public string Passport_Number
        {
            get => _passport_number;
            set
            {
                if(value!=null)
                {
                    if (value.Length > 6)
                        return;
                    _passport_number = Regex.Replace(value, @"[^\d]+", "");

                }
                 
                
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
        private string _phone;
        public string Phone
        {
            get => _phone;
            set
            {
                _phone = value;
                Regex _Phone = new Regex(@"((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}");//регулярное выражение для телефона
                Valid_Phone=_Phone.IsMatch(value);
                if(string.IsNullOrEmpty(value))
                {
                    Valid_Phone = true;
                }
                OnPropertyChanged();
            }
        }
        
        private bool valid_phone;
        [NotMapped]//не создавать таблицу в бд
        public bool Valid_Phone
        {
            get => valid_phone;
            set
            {
                valid_phone = value;
                OnPropertyChanged();
            }
        }
        [NotMapped]
        public string DateMedical
        {
            get
            {
                var db=new Model.ConnectDB();
                //загрузить из базы дату последнего осмотра
                var med = db.MedicalExamination.Where(p => p.EmployeeId == ID_Employee).OrderByDescending(p => p.ExaminationDate).FirstOrDefault();
                if (med != null)
                    return med.ExaminationDate.ToString("dd.MM.yyyy");
                else
                    return "Осмотра небыло";
            }
        }

        private ObservableCollection<EmployeePost> _employee_post;
        public ObservableCollection<EmployeePost> EmployeePost
        {
            get => _employee_post;
            set
            {
                _employee_post = value;
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
    public class EmployeePost:BaseViewModel
    {
        private int id_employee_post;
        [Key]
        public int ID_EmployeePost
        {
            get => id_employee_post;
            set
            {
                id_employee_post = value;
                OnPropertyChanged();
            }
        }
        private int _employee_id;
        public int EmployeeId

        {
            get => _employee_id;
            set
            {
                _employee_id = value;
                OnPropertyChanged();
            }
        }
        private Employee _employee;
        public Employee Employee

        {
            get => _employee;
            set
            {
                _employee = value;
                OnPropertyChanged();
            }
        }
        private int _post_id;
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
        public EmployeePost()
        {

        }
        public EmployeePost(int id, int emp_id, int post_id)
        {
            ID_EmployeePost = id;
            EmployeeId = emp_id;
            PostId = post_id;
        }
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
        private int _role_id;
        public int RoleId
        {
            get => _role_id;
            set
            {
                _role_id= value;
                OnPropertyChanged();
            }
        }
        private Role role;
        public Role Role
        {
            get => role;
            set
            {
                role = value;
                OnPropertyChanged();
            }
        }
        public  Post(){}

        public Post(int _id, string postName, int salary, int departmentId, int RoleId)
        {
            ID_Post = _id;
            PostName = postName;
            Salary = salary;
            DepartmentId = departmentId;
            this.RoleId=RoleId;
        }
    }
    public class Brigade:BaseViewModel
    {
        private int _id_brigade;
        [Key]
        public int ID_Brigade
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
    public class MedicalExamination:BaseViewModel
    {
        private int _id_medical_examination;
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID_MedicalExamination
        {
            get => _id_medical_examination;
            set
            {
                _id_medical_examination = value;
                OnPropertyChanged();
            }
        }
        private DateTime _examination_date;
        public DateTime ExaminationDate
        {
            get => _examination_date;
            set
            {
                _examination_date= value;
                OnPropertyChanged();
            }
        }
        private string _examination_result;
        public string ExaminationResult
        {
            get => _examination_result;
            set
            {
                _examination_result = value;
                OnPropertyChanged();
            }
        }
        private int _employee_id;
        public int EmployeeId
        {
            get => _employee_id;
            set
            {
                _employee_id = value;
                OnPropertyChanged();
            }
        }
        private Employee _employee;
        public Employee Employee
        {
            get => _employee;
            set
            {
                _employee = value;
                OnPropertyChanged();
            }
        }
    }
    public class Role:BaseViewModel
    {
        [Key]
        public int ID_Role { get; set; }
        public string RoleName { get; set; }
        public Role() { }
        public Role(int id, string name)
        {
            ID_Role = id;
            RoleName = name;
        }
    }
}

