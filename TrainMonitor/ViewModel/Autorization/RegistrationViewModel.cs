using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace TrainMonitor.ViewModel.Autorization
{
    public class RegistrationViewModel:BaseViewModel
    {
        private Model.Employee.Employee _add_employee;
        public Model.Employee.Employee AddEmployee
        {
            get => _add_employee;
            set
            {
                _add_employee = value;
                OnPropertyChanged();
            }
        }
        private int _code;
        public int Code
        {
            get => _code;
            set
            {
                _code = value;
                OnPropertyChanged();
            }
        }
        private int received_code;
        private bool _is_send_code;
        public bool IsSendCode
        {
            get => _is_send_code;
            set
            {
                _is_send_code = value;
                if (!value)
                    Registration = new RelayCommand(SendCode);
                else
                    Registration = new RelayCommand(EmployeeRegistrate);
                OnPropertyChanged();
            }
        }

        private View.Autorization.Registration registration;
        public RegistrationViewModel()
        {
            IsSendCode= false;  
            AddEmployee = new Model.Employee.Employee();
            AddEmployee.Birth_Date= DateTime.Now;
            registration = new View.Autorization.Registration(this);
            registration.Show();
        }
        private ICommand _registration;
        public ICommand Registration
        {
            get => _registration;
            set
            {
                _registration=value;
                OnPropertyChanged();
            }
        }
        private void SendCode()
        {
              received_code=Model.Employee.EmployeeRegistrationModel.SendCode(AddEmployee.Email);
         
            if (received_code!=0)
            {
                IsSendCode = true;
            }
        }

        private void EmployeeRegistrate()
        {
            if(received_code!=Code)
            {
                MessageBox.Show("Введенный код неверен","Ошибка");
            }
            var pass = registration.GetPassword();
            try
            {
                if (pass == null)
                    return;

                AddEmployee.Password = pass;
              
                AddEmployee.ID_Employee = 0;
                using (var db = new Model.ConnectDB())
                {
                    if(db.Employee.Any(p=>p.Email==AddEmployee.Email || p.Login==AddEmployee.Login))
                    {
                        MessageBox.Show("Пользователь с таким Email или логином уже зарегистрирован", "Успех");
                        return;
                    }
                    db.Employee.Add(AddEmployee);
                    db.SaveChanges();

                }
                MessageBox.Show("Пользователь успешно добавлен","Успех");
                registration.Close();
            }
           catch (Exception ex)
            {
                MessageBox.Show(ex.Message +" " + ex.StackTrace);
            }


        }
    }
}
