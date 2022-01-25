using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TrainMonitor.View.Employee
{
    /// <summary>
    /// Логика взаимодействия для AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {
        public AddEmployee(ViewModel.Autorization.RegistrationViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
        public string GetPassword()
        {
            if (password1.Password == password2.Password)
            {
                if (password1.Password.Length < 8)
                {
                    MessageBox.Show("Длинна пароля меньше 8 символов", "Ошибка");
                    return null;
                }

                Regex regex_latin = new Regex("([A-Z])|([a-z])");

                if (regex_latin.Matches(password1.Password).Count < 5)
                {
                    MessageBox.Show("Кол-во латинский букв  в пароле меньше 5", "Ошибка");
                    return null;
                }
                Regex regex_number = new Regex("([0-9])");
                if (regex_number.Matches(password1.Password).Count < 3)
                {
                    MessageBox.Show("Кол-во цифр в пароле меньше 3", "Ошибка");
                    return null;
                }
                return password1.Password;
            }
            else
            {
                MessageBox.Show("Пароли не совпадают", "Ошибка");
                return null;
            }

        }
    }
}
