using System;
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
                    Console.WriteLine(RouteText);
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
}