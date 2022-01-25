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
        private View.Autorization.Autorization Autorization;
        public AutorizationViewModel(View.Autorization.Autorization Autorization)
        {
            this.Autorization = Autorization;

        }
        public ICommand OpenRegistration => new RelayCommand(() => { 
        
            RegistrationViewModel regViewModel = new RegistrationViewModel();
                
        });
        public void Auth(string login, string password)
        {
            using (var db=new Model.ConnectDB())
            {
                var emp = db.Employee.Where(p => p.Login == login && p.Password == password).FirstOrDefault();
                if(emp==null)
                {
                    MessageBox.Show("Введеный логин или пароль неверны","Ошибка");
                    return;
                }
                MainWindow mainWindow= new MainWindow();
                mainWindow.Show();
                Autorization.Close();
            }
        }
    }
}
