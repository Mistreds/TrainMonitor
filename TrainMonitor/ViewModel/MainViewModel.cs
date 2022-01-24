using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace TrainMonitor.ViewModel
{
   public class MainViewModel:BaseViewModel
    {
        public static Employee.EmployeeViewModel EmployeeViewModel { get; private set; }
        private Page _page_control;
        public Page PageControl
        {
            get => _page_control;
            set
            {
                _page_control = value;
                OnPropertyChanged();
            }
        }
        private readonly Dictionary<string, Page> PagesControl;
        public static Model.Employee.EmployeeModel EmployeeModel { get; private set; }
        public MainViewModel()
        {
            EmployeeModel=new Model.Employee.EmployeeModel();
            EmployeeViewModel = new Employee.EmployeeViewModel();   
            PagesControl = new Dictionary<string, Page> { { "Department", new View.Employee.Department(EmployeeViewModel) }, { "Post", new View.Employee.Post(EmployeeViewModel) }, {"Employee",  new View.Employee.Employee(EmployeeViewModel) } };
        }
        public ICommand   OpenPageCommand => new DelegateCommand<string>(OpenPage);
        private void OpenPage(string page)
        {
            Console.WriteLine(page);
            PageControl = PagesControl[page];
        }
    }
}
