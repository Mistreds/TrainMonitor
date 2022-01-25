using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainMonitor.View.Employee;

namespace TrainMonitor.Model.Train
{
    public class Train:BaseViewModel
    {
        private int _id_train;
       
        [Key]
        public int ID_Train
        {
            get=> _id_train;
            set
            {
                _id_train = value;
                OnPropertyChanged(); 
            }
        }

        private string _train_number;

        public string TrainNumber
        {
            get => _train_number;
            set
            {
                _train_number = value;
                OnPropertyChanged();
            }
        }

        private string train_type;

        public string Train_Type
        {
            get => train_type;
            set
            {
                train_type = value;
                OnPropertyChanged();
            }
        }
        private int _brigade_id;
        public int BrigadeId
        {
            get => _brigade_id;
            set
            {
                _brigade_id = value;
                OnPropertyChanged();
            }
        }

        private Employee.Brigade _brigade;

        public Employee.Brigade Brigade
        {
            get => _brigade;
            set
            {
                _brigade = value;
                OnPropertyChanged();
            }
        } 
    }

    public class Train_Maintance : BaseViewModel
    {
        private int _id_train_maintance;
      
        [Key]
        public int ID_Train_Maintance
        {
            get => _id_train_maintance;
            set
            {
                _id_train_maintance = value;
                OnPropertyChanged();
            }
        }

        private int _train_work_type_id;

        public int TrainWorkTypeId
        {
            get => _train_work_type_id;
            set
            {
                _train_work_type_id = value;
                OnPropertyChanged();
            }
        }
        private TrainWorkType _trainWorkType;

        public TrainWorkType TrainWorkType
        {
            get => _trainWorkType;
            set
            {
                _trainWorkType = value;
                OnPropertyChanged();
            }
        }
        private DateTime _date_of_the_work;

        public DateTime DateOfheWork
        {
            get => _date_of_the_work;
            set
            {
                _date_of_the_work = value;
                OnPropertyChanged();
            }
        }

        private Train _train;

        public Train Train
        {
            get => _train;
            set
            {
                _train = value;
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
    }
    public class TrainWorkType : BaseViewModel
    {
        private int _id_type;
        [Key]
        public int IdType
        {
            get => _id_type;
            set
            {
                _id_type = value;
                OnPropertyChanged();
            }
        }
        private string _work_name;
        public string WorkName
        {
            get => _work_name;
            set
            {
                _work_name = value;
                OnPropertyChanged();
            }
        }
    }
}
