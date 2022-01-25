using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainMonitor.Model.Schedule
{
    public class Schedule:BaseViewModel
    {

        private int _id_schedule;
        [Key]
        public int ID_Schedule
        {
            get => _id_schedule;
            set
            {
                _id_schedule = value;
                OnPropertyChanged();
            }
        }
        private DateTime _date_of_dispatch;

        public DateTime DateOfDispatch
        {
            get => _date_of_dispatch;
            set
            {
                _date_of_dispatch = value;
                OnPropertyChanged();
            }
        }

        private DateTime _stop_date;

        public DateTime StopDate
        {
            get => _stop_date;
            set
            {
                _stop_date = value;
                OnPropertyChanged();
            }
        }

        private DateTime _delay_start;

        public DateTime DelayStop
        {
            get => _delay_start;
            set
            {
                _delay_start = value;
                OnPropertyChanged();
            }
        }

        private DateTime _delay_end;

        public DateTime DelayEnd
        {
            get => _delay_end;
            set
            {
                _delay_end = value;
                OnPropertyChanged();
            }
        }

        private string _delay_reason;

        public string DelayReason
        {
            get => _delay_reason;
            set
            {
                _delay_reason = value;
                OnPropertyChanged();
            }
        }

        private double _ticket_price;

        public double Ticket_Price
        {
            get => _ticket_price;
            set
            {
                _ticket_price = value;
                OnPropertyChanged();
            }
        }

        private int _train_id;

        public int TrainId
        {
            get => _train_id;
            set
            {
                _train_id = value;
                OnPropertyChanged();
            }
        }

        private Train.Train _train;

        public Train.Train Train
        {
            get => _train;
            set
            {
                _train = value;
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

        private Route.Route _route;
        public Route.Route Route
        {
            get => _route;
            set
            {
                _route = value;
                OnPropertyChanged();
            }
        }

        
    }
}