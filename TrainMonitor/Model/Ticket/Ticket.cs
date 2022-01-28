using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainMonitor.Model.Ticket
{
    public class Ticket:BaseViewModel
    {
        private int _id_ticket;
        [Key]
        public int ID_Ticket
        {
            get => _id_ticket;
            set
            {
                _id_ticket = value;
                OnPropertyChanged();
            }
        }
        private DateTime _date_of_purchase;
        public DateTime DateOfPurchase
        {
            get => _date_of_purchase;
            set
            {
                _date_of_purchase = value;
                OnPropertyChanged();
            }
        }
        private DateTime _date_of_return;
        public DateTime DateOfReturn
        {
            get => _date_of_return;
            set
            {
                _date_of_return = value;
                OnPropertyChanged();
            }
        }
        private DateTime _booking_date;
        public DateTime BookingDate
        {
            get => _booking_date;
            set
            {
                _booking_date = value;
                OnPropertyChanged();
            }
        }

        private string _ticket_number;

        public string Ticket_Number
        {
            get => _ticket_number;
            set
            {
                _ticket_number = value;
                OnPropertyChanged();
            }
        }

        private int _employee_id;
        public int EmployeeId
        {
            get => _employee_id;
            set
            {
                _employee_id = value;
                OnPropertyChanged();
            }
        }
        private Employee.Employee _employee;
        public Employee.Employee Employee
        {
            get => _employee;
            set
            {
                _employee = value;
                OnPropertyChanged();
            }
        }
        private int _schedule_id;
        public int ScheduleId
        {
            get => _schedule_id;
            set
            {
                _schedule_id = value;
                OnPropertyChanged();
            }
        }
        private Schedule.Schedule _schedule;
        public Schedule.Schedule Schedule
        {
            get =>_schedule;
            set
            {
                _schedule = value;
                OnPropertyChanged();
            }
        }

    }
}