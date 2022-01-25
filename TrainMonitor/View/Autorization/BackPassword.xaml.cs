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
    /// Логика взаимодействия для BackPassword.xaml
    /// </summary>
    public partial class BackPassword : Window
    {
        private int code;
        public BackPassword()
        {
            InitializeComponent();
            Stack_code.Visibility = Visibility.Collapsed;
            Stack_pass.Visibility = Visibility.Collapsed;
        }

        private void mail_but_Click(object sender, RoutedEventArgs e)
        {
            var db = new Model.ConnectDB();
            if(!db.Employee.Any(p=>p.Email.ToLower()== Mail.Text.ToLower()))
            {
                MessageBox.Show("Такой email не зарегистрирован","Ошибка");
                return;
            }
            code = Model.Employee.EmployeeRegistrationModel.SendCode(Mail.Text);
            if(code!=0)
            {
                Mail.IsReadOnly = true;
                Stack_code.Visibility=Visibility.Visible;
            }
        }

        private void Code_but_Click(object sender, RoutedEventArgs e)
        {
            if (Code.Text == code.ToString())
            {
                Stack_pass.Visibility = Visibility.Visible;
                
            }
        }

        private void Pass_but_Click(object sender, RoutedEventArgs e)
        {
            var db = new Model.ConnectDB();
           var emp=db.Employee.Where(p=>p.Email == Mail.Text).FirstOrDefault();
            emp.Password = Pass.Password;
            db.Update(emp);
            db.SaveChanges();   

        }
    }
}
