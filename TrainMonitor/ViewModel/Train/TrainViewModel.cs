using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TrainMonitor.ViewModel.Train
{
   public class TrainViewModel:BaseViewModel
    {
        private ObservableCollection<Model.Employee.Brigade> _brigades_combo;
        public ObservableCollection<Model.Employee.Brigade> BrigadesCombo
        {
            get => _brigades_combo;
            set
            {
                _brigades_combo = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Model.Train.Train> _trains;
        public ObservableCollection<Model.Train.Train> Trains
        {
            get => _trains;
            set
            {
                _trains = value;
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
        private ObservableCollection<Model.Train.Train_Maintance> train_Maintances;
        public ObservableCollection<Model.Train.Train_Maintance> TrainMaintances
        {
            get => train_Maintances;
            set
            {
                train_Maintances = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Model.Train.TrainWorkType> _train_work_types;
        public  ObservableCollection<Model.Train.TrainWorkType> TrainWorkTypes
        {
            get => _train_work_types;
            set
            {
                _train_work_types = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Model.Train.TrainWorkType> _train_work_types_combo;
        public ObservableCollection<Model.Train.TrainWorkType> TrainWorkTypesCombo
        {
            get => _train_work_types_combo;
            set
            {
                _train_work_types_combo = value;
                OnPropertyChanged();
            }
        }

        public TrainViewModel()
        {
            BrigadesCombo = MainViewModel.EmployeeViewModel.BrigadesCombo;
            Trains = MainViewModel.TrainModel.GetTrain();
            TrainsCombo = MainViewModel.TrainModel.GetTrain();
            TrainWorkTypes = MainViewModel.TrainModel.GetTrainWorkType();
            TrainWorkTypesCombo = MainViewModel.TrainModel.GetTrainWorkType();
            TrainMaintances = MainViewModel.TrainModel.GetTrain_Maintance();
        }
        public ICommand UpdateTrain => new RelayCommand(() => { 
            MainViewModel.TrainModel.UpdateTrain(Trains);
            Trains = MainViewModel.TrainModel.GetTrain();
            TrainsCombo = MainViewModel.TrainModel.GetTrain();
            MainViewModel.RouteViewModel.TrainsCombo = TrainsCombo;
        });
        public ICommand CanselTrain => new RelayCommand(() => { Trains = MainViewModel.TrainModel.GetTrain();
            TrainsCombo = MainViewModel.TrainModel.GetTrain();
        });
        public ICommand UpdateWorkTypes => new RelayCommand(() => {
            MainViewModel.TrainModel.UpdateWorkType(TrainWorkTypes);
            TrainWorkTypes = MainViewModel.TrainModel.GetTrainWorkType();
            TrainWorkTypesCombo = MainViewModel.TrainModel.GetTrainWorkType();
        });
        public ICommand CanselWorkTypes => new RelayCommand(() => {
            TrainWorkTypes = MainViewModel.TrainModel.GetTrainWorkType();
            TrainWorkTypesCombo = MainViewModel.TrainModel.GetTrainWorkType();
        });
        public ICommand UpdateMaintances => new RelayCommand(() => {
            MainViewModel.TrainModel.UpdateTrain_Maintance(TrainMaintances);
            TrainMaintances = MainViewModel.TrainModel.GetTrain_Maintance();
        
        });
        public ICommand CanselMaintances => new RelayCommand(() => { TrainMaintances = MainViewModel.TrainModel.GetTrain_Maintance(); });
    }
}
