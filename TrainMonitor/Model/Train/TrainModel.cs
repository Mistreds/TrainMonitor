using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainMonitor.Model.Train
{
   public class TrainModel
    {
        public ObservableCollection<Model.Train.Train>  GetTrain()
        {
            var db=new ConnectDB();
            return new ObservableCollection<Train>(db.Train.Include(p => p.Brigade));
        }
        public ObservableCollection<Model.Train.Train_Maintance> GetTrain_Maintance()
        {
            var db = new ConnectDB();
            return new ObservableCollection<Train_Maintance>(db.TrainMaintance.Include(p => p.Train).Include(p=>p.TrainWorkType));
        }
        public ObservableCollection<Model.Train.TrainWorkType> GetTrainWorkType()
        {
            var db = new ConnectDB();
            return new ObservableCollection<TrainWorkType>(db.TrainWorkTypes);
        }
        public void UpdateTrain(ObservableCollection<Model.Train.Train> trains)
        {
            var db = new ConnectDB();
            foreach(var train in trains)
            {
                train.Brigade = null;
            }
            db.UpdateRange(trains);
            db.SaveChanges();
        }
        public void UpdateTrain_Maintance(ObservableCollection<Train_Maintance> trains)
        {
            var db = new ConnectDB();
            foreach (var train in trains)
            {
                train.TrainWorkType= null;
            }
            db.UpdateRange(trains);
            db.SaveChanges();
        }
        public void UpdateWorkType(ObservableCollection<TrainWorkType> trains)
        {
            var db = new ConnectDB();
            db.UpdateRange(trains);
            db.SaveChanges();
        }
    }
}
