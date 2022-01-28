using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainMonitor.Model.Route
{
    public class RouteModel
    {
        public ObservableCollection<Station.Station> GetStations()
        {
            var db = new ConnectDB();
            return new ObservableCollection<Station.Station>(db.Station);
        }
        public ObservableCollection<Route> GetRoute()
        {
            var db = new ConnectDB();
            return new ObservableCollection<Route>(db.Route.Include(p => p.RouteStation
            ).ThenInclude(p => p.Station).Include(p => p.InitialStation).Include(p => p.TerminalStation).Include(p => p.RouteType));
        }
        public ObservableCollection<Schedule.Schedule> GetSchedule()
        {
            var db = new ConnectDB();
            return new ObservableCollection<Schedule.Schedule>(db.Schedule.Include(p => p.Train).Include(p => p.Route).ThenInclude(p => p.InitialStation).Include(p => p.Route).ThenInclude(p => p.TerminalStation));
        }
        public ObservableCollection<Ticket.Ticket> GetTicket()
        {
            var db = new ConnectDB();
            return new ObservableCollection<Ticket.Ticket>(db.Ticket.Include(p => p.Employee).Include(p => p.Schedule));
        }
        public List<RouteType> GetRouteTypes()
        {
            var db=new ConnectDB();
            return db.RouteType.ToList();
        }
        public void UpdateStation(ObservableCollection<Station.Station> stations)
        {
            var db = new ConnectDB();
            db.UpdateRange(stations);
            db.RemoveRange(db.Station.Where(p => !stations.Select(s => s.ID_Station).Contains(p.ID_Station)));
            db.SaveChanges();

        }
        public void UpdateRoute(ObservableCollection<Route> routes)
        {
            var db=new ConnectDB();
            foreach (var route in routes)
            {
                route.InitialStation = null; 
                route.TerminalStation = null;
                foreach(var st in route.RouteStation)
                {
                    st.Station= null;
                }
                route.RouteType = null;
                if (route.ID_Route == 0)
                    continue;
                db.RemoveRange(db.RouteStation.Where(p => !route.RouteStation.Select(s => s.ID_RouteStation).Contains(p.ID_RouteStation) && p.RouteId == route.ID_Route));
               
            }
            db.UpdateRange(routes);
            db.RemoveRange(db.Route.Where(p => !routes.Select(s => s.ID_Route).Contains(p.ID_Route)));
            db.SaveChanges();
        }
        public void UpdateSchedule(ObservableCollection<Schedule.Schedule> schedules)
        {
            var db=new ConnectDB();
            foreach(var sched in schedules)
            {
                sched.Train = null;
                sched.Route = null;
            }
            db.UpdateRange(schedules);
            db.RemoveRange(db.Schedule.Where(p => !schedules.Select(s => s.ID_Schedule).Contains(p.ID_Schedule)));
            db.SaveChanges();
        }
        public void UpdateTicket(ObservableCollection<Ticket.Ticket> tickets)
        {
            var db = new ConnectDB();
            foreach (var tick in tickets)
            {
                tick.Employee= null;
                tick.Schedule= null;
            }
            db.UpdateRange(tickets);
            db.RemoveRange(db.Ticket.Where(p => !tickets.Select(s => s.ID_Ticket).Contains(p.ID_Ticket)));
            db.SaveChanges();
        }
    }
}
