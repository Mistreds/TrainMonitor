using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainMonitor.Model.Station
{
    public class Station:BaseViewModel
    {
        private int _id_station;
        [Key]
        public int ID_Station
        {
            get => _id_station;
            set
            {
                _id_station = value;
                OnPropertyChanged();
            }
        }

        private string _station_name;

        public string StationName
        {
            get => _station_name;
            set
            {
                _station_name = value;
                OnPropertyChanged();
            }
        }

        private string _station_number;

        public string StationNumber
        {
            get => _station_number;
            set
            {
                _station_number = value;
                OnPropertyChanged();
            }
        }
    }
}