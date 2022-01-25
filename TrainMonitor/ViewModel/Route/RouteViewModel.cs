using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TrainMonitor.ViewModel.Route
{
    public class RouteViewModel:BaseViewModel
    {
        private ObservableCollection<Model.Station.Station> _stations;
        public ObservableCollection<Model.Station.Station> Stations
        {
            get => _stations;
            set
            {
                _stations= value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Model.Station.Station> _stations_combo;
        public ObservableCollection<Model.Station.Station> StationsCombo
        {
            get => _stations_combo;
            set
            {
                _stations_combo = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Model.Train.Train> _trains_combo;
        public ObservableCollection<Model.Train.Train> TrainsCombo
        {
            get => _trains_combo;
            set
            {
                _trains_combo = value;
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
        private ObservableCollection<Model.Route.Route> _route;
        public ObservableCollection<Model.Route.Route> Route
        {
            get => _route;
            set
            {
                _route = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Model.Route.Route> _route_combo;
        public ObservableCollection<Model.Route.Route> RouteCombo
        {
            get => _route_combo;
            set
            {
                _route_combo = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Model.Schedule.Schedule> _schedule;
        public ObservableCollection<Model.Schedule.Schedule> Schedules
        {
            get => _schedule;
            set
            {
                _schedule = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Model.Schedule.Schedule> _schedule_combo;
        public ObservableCollection<Model.Schedule.Schedule> SchedulesCombo
        {
            get => _schedule_combo;
            set
            {
                _schedule_combo = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Model.Ticket.Ticket> _ticket;
        public ObservableCollection<Model.Ticket.Ticket> Ticket
        {
            get => _ticket;
            set
            {
                _ticket = value;
                OnPropertyChanged();
            }
        }
        public List<Model.Route.RouteType> RouterTypes { get; private set; }
        public RouteViewModel()
        {
            RouterTypes = MainViewModel.RouteModel.GetRouteTypes();
            StationsCombo = MainViewModel.RouteModel.GetStations();
            Stations = MainViewModel.RouteModel.GetStations();
            Route = MainViewModel.RouteModel.GetRoute();
            RouteCombo = MainViewModel.RouteModel.GetRoute();
            EmployeesCombo = MainViewModel.EmployeeModel.GetEmployee();
            TrainsCombo = MainViewModel.TrainModel.GetTrain();
            SchedulesCombo = MainViewModel.RouteModel.GetSchedule();
            Schedules = MainViewModel.RouteModel.GetSchedule();
            Ticket = MainViewModel.RouteModel.GetTicket();
        }
        public ICommand UpdateStation => new RelayCommand(() => {
            MainViewModel.RouteModel.UpdateStation(Stations);
          StationsCombo = MainViewModel.RouteModel.GetStations();
            Stations = MainViewModel.RouteModel.GetStations();
        });
        public ICommand CanselStation => new RelayCommand(() => {
            StationsCombo = MainViewModel.RouteModel.GetStations();
            Stations = MainViewModel.RouteModel.GetStations();
        });
        public ICommand UpdateRoute => new RelayCommand(() => {
            MainViewModel.RouteModel.UpdateRoute(Route);
            Route = MainViewModel.RouteModel.GetRoute();
            RouteCombo = MainViewModel.RouteModel.GetRoute();
        });
        public ICommand CanselRoute => new RelayCommand(() => {
            Route = MainViewModel.RouteModel.GetRoute();
            RouteCombo = MainViewModel.RouteModel.GetRoute();
        });
        public ICommand UpdateSchedule => new RelayCommand(() => {
            MainViewModel.RouteModel.UpdateSchedule(Schedules);
            SchedulesCombo = MainViewModel.RouteModel.GetSchedule();
            Schedules = MainViewModel.RouteModel.GetSchedule();
        });
        public ICommand CanselSchedule => new RelayCommand(() => {
            SchedulesCombo = MainViewModel.RouteModel.GetSchedule();
            Schedules = MainViewModel.RouteModel.GetSchedule();
        });
        public ICommand UpdateTicket=> new RelayCommand(() => {
            MainViewModel.RouteModel.UpdateTicket(Ticket);
            Ticket = MainViewModel.RouteModel.GetTicket();
        });
        public ICommand CanselTicket => new RelayCommand(() => {
            Ticket = MainViewModel.RouteModel.GetTicket();
        });
    }
}
