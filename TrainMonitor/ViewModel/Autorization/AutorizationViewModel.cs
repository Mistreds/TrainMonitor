using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace TrainMonitor.ViewModel.Autorization
{
   public class AutorizationViewModel:BaseViewModel
    {
        public static View.Autorization.Autorization Autorization;
        public AutorizationViewModel()
        {
            Autorization=new View.Autorization.Autorization(this);
            Autorization.Show();
            

        }
      
        public ICommand OpenRegistration => new RelayCommand(() => { 
        
            RegistrationViewModel regViewModel = new RegistrationViewModel();
           // Autorization.Close();

        });
       
        public void Auth(string login, string password)
        {
            using (var db=new Model.ConnectDB())
            {
                var emp = db.Employee.Where(p => p.Login == login && p.Password == password).Include(p=>p.EmployeePost).ThenInclude(p=>p.Post).FirstOrDefault();
                if(emp==null)
                {
                    MessageBox.Show("Введеный логин или пароль неверны","Ошибка");
                    return;
                }
                MainWindow mainWindow= new MainWindow(emp);
                mainWindow.Show();
                Autorization.Close();
            }
        }
    }
}
