using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainMonitor.Model.Route
{
    public class Route:BaseViewModel
    {
        private int _id_route;
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID_Route
        {
            get => _id_route;
            set
            {
                _id_route = value;
                OnPropertyChanged();
            }
        }
        private int _route_type_id;

        public int RouteTypeId
        {
            get => _route_type_id;
            set
            {
                _route_type_id = value;
                OnPropertyChanged();
            }
        }
        private RouteType _routeType;

        public RouteType RouteType
        {
            get => _routeType;
            set
            {
                _routeType = value;
                OnPropertyChanged();
            }
        }
        private int _initial_station_id;

        public int InitialStationId
        {
            get => _initial_station_id;
            set
            {
                _initial_station_id = value;
                OnPropertyChanged();
            }
        }
        private string _route_text;
        [NotMapped]
       public string RouteText
        {
            get => _route_text;
            private set
            {
                _route_text = value;
                OnPropertyChanged();
            }
        }

        private Model.Station.Station _initial_station;

        public Model.Station.Station InitialStation
        {
            get => _initial_station;
            set
            {
                _initial_station = value;
                if(TerminalStation != null && InitialStation!=null)
                {
                    RouteText = $"{InitialStation.StationName}-{TerminalStation.StationName}";
                }
                OnPropertyChanged();
            }
        }
        private int _terminal_station_id;

        public int TerminalStationId
        {
            get => _terminal_station_id;
            set
            {
                _terminal_station_id = value;
               
                OnPropertyChanged();
            }
        }
        private Model.Station.Station _terminal_station;

        public Model.Station.Station TerminalStation
        {
            get => _terminal_station;
            set
            {
                _terminal_station = value;
                if (InitialStation != null && TerminalStation != null)
                {
                    RouteText = $"{InitialStation.StationName}-{TerminalStation.StationName}";
                    Console.WriteLine(RouteText);
                }
                OnPropertyChanged();
            }
        }

        private ObservableCollection<RouteStation> _routeStations;

        public ObservableCollection<RouteStation> RouteStation
        {
            get => _routeStations;
            set
            {
                _routeStations = value;
                OnPropertyChanged();
            }
        }

        public Route()
        {
            RouteStation = new ObservableCollection<RouteStation>();
        }
    }

    public class RouteType:BaseViewModel
    {
        private int _type_id;
        [Key]
        public int TypeId
        {
            get => _type_id;
            set
            {
                _type_id = value;
                OnPropertyChanged();
            }
        }
        private string _route_type_name;

        public string RouteTypeName
        {
            get => _route_type_name;
            set
            {
                _route_type_name = value;
                OnPropertyChanged();
            }
        }
        public RouteType() { }

        public RouteType(int typeId, string routeTypeName)
        {
            _type_id = typeId;
            _route_type_name = routeTypeName;
        }
    }

    public class RouteStation : BaseViewModel
    {
        private int id_route_station;
        [Key]
        public int ID_RouteStation
        {
            get => id_route_station;
            set
            {
                id_route_station = value;
                OnPropertyChanged();
            }
        }
        private int _route_id;
        public int RouteId

        {
            get => _route_id;
            set
            {
                _route_id = value;
                OnPropertyChanged();
            }
        }
        private Route _route;
        public Route Route

        {
            get => _route;
            set
            {
                _route = value;
                OnPropertyChanged();
            }
        }
        private int _station_id;
        public int StationId

        {
            get =>_station_id;
            set
            {
                _station_id = value;
                OnPropertyChanged();
            }
        }
        private Station.Station _station;
        public Station.Station Station
        {
            get => _station;
            set
            {
                _station = value;
                OnPropertyChanged();
            }
        }
        public RouteStation ()
        {

        }
    }
}