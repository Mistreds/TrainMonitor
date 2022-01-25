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
        public static Train.TrainViewModel TrainViewModel { get; private set; }
        public static Route.RouteViewModel RouteViewModel { get; private set; }
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
        public static Model.Train.TrainModel TrainModel { get; private set; }
        public static Model.Route.RouteModel RouteModel { get; private set; }
        public MainViewModel() 
        {
            EmployeeModel=new Model.Employee.EmployeeModel();
            TrainModel=new Model.Train.TrainModel();
            RouteModel=new Model.Route.RouteModel();  
            EmployeeViewModel = new Employee.EmployeeViewModel();
            TrainViewModel=new Train.TrainViewModel();
            RouteViewModel=new Route.RouteViewModel();
            PagesControl = new Dictionary<string, Page> { { "Department", new View.Employee.Department(EmployeeViewModel) }, { "Post", new View.Employee.Post(EmployeeViewModel) }, {"Employee",  new View.Employee.Employee(EmployeeViewModel) }, {"Brigade", new View.Employee.Brigade(EmployeeViewModel) }, { "MedicalView", new View.Employee.MedicalView(EmployeeViewModel) }, {"TrainView", new View.Train.TrainView(TrainViewModel) }, { "TrainWorkType", new View.Train.TrainWorkType(TrainViewModel) },{ "TrainMaintance", new View.Train.TrainMaintance(TrainViewModel) }, {"Stations", new View.Station.Station(RouteViewModel) }, { "Route", new View.Station.Route(RouteViewModel) }, {"Schedule", new View.Station.Schedule(RouteViewModel)}, { "Ticket", new View.Station.Ticket(RouteViewModel) } };
        }
        public ICommand   OpenPageCommand => new DelegateCommand<string>(OpenPage);
        private void OpenPage(string page)
        {
            Console.WriteLine(page);
            PageControl = PagesControl[page];
        }
    }
}
