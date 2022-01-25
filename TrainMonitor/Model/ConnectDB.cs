using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainMonitor.Model.Employee;
using TrainMonitor.Model.Train;

namespace TrainMonitor.Model
{
    public class ConnectDB : DbContext
    {

        //Тут идет обьявление обьект базы данных, чтобы можно было сделать из них выборку
        public DbSet<Employee.Employee> Employee { get; set; }
        public DbSet<Employee.Department> Department { get; set; }
        public DbSet<Employee.Post> Post { get; set; }
        public  DbSet<Employee.Brigade> Brigade { get; set; }
        public DbSet<Employee.MedicalExamination> MedicalExamination { get; set; }
        public DbSet<Employee.Role> Role { get; set; }
        public DbSet<Employee.EmployeePost> EmployeePost { get; set; }
        public  DbSet<Train.Train> Train { get; set; }
        public DbSet<Train.Train_Maintance> TrainMaintance { get; set; }
        public DbSet<TrainWorkType> TrainWorkTypes { get; set; }
        public DbSet<Station.Station> Station { get; set; }
        public DbSet<Route.RouteType> RouteType { get; set; }
        public DbSet<Route.Route> Route { get; set; }
        public DbSet<Schedule.Schedule> Schedule { get; set; }
        public DbSet<Ticket.Ticket> Ticket { get; set; }

        public ConnectDB()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
            //Database.Migrate();

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Про Entity Framework Core лучше всего почитать вот тут https://metanit.com/sharp/efcore/1.1.php
            //Тут необходимао прописать настройки postgres, где database желаемое название (база создается автоматически при первом запуске) и password соотвественно пароль
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=train_monitor;Username=postgres;Password=");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.UseSerialColumns();//Возможность использование автоинкремента в базе
            #region  Employee
            #region Department
            modelBuilder.Entity<Employee.Department>(b => b.ToTable("department"));//инициализация объекта Department в базе с названием таблицы
            modelBuilder.Entity<Employee.Department>().Property(f => f.ID_Department).UseIdentityAlwaysColumn();//использование автонкремента на соотвествующем столбе
            modelBuilder.Entity<Employee.Department>().HasData(new Employee.Department[] //инициализация первичных данных, срабатывает один раз при создании БД
            {
                new Employee.Department(1,"Администратор")
            });

            modelBuilder.Entity<Employee.Department>().Property(f => f.ID_Department).HasIdentityOptions(startValue: 2);//начинать автоинкремент с идентификатора 2, если его не будет, то при первом добавлении данных в таблицу будет выскакивать исключение, что такой id в базе уже есть есть
            #endregion
            //Дальше все идет абсолютно одинаково, где первичных данных нет, HasIdentityOptions(startValue: 2); не нуден
            modelBuilder.Entity<Employee.Role>(b => b.ToTable("role"));
            modelBuilder.Entity<Employee.Role>().HasData(new Role[] { new Role(1, "Администратор"), new Role(2, "Глава отдела кадров"), new Role(3, "Графист"), new Role(4, "Продавец"), new Role(5, "Диспетчер поезда"), new Role(6, "Главный механик") });
            #region Post
            modelBuilder.Entity<Employee.Post>(b => b.ToTable("post"));
            modelBuilder.Entity<Employee.Post>().Property(f => f.ID_Post).UseIdentityAlwaysColumn();
            modelBuilder.Entity<Employee.Post>().HasData(new Employee.Post[] { new Employee.Post(1, "Администратор", 0, 1, 1) });
            modelBuilder.Entity<Employee.Post>().Property(f => f.ID_Post).HasIdentityOptions(startValue: 2);
            #endregion
            #region Brigade
            modelBuilder.Entity<Employee.Brigade>(b => b.ToTable("brigade"));
            modelBuilder.Entity<Employee.Brigade>().Property(f => f.ID_Brigade).UseIdentityAlwaysColumn();
            modelBuilder.Entity<Employee.Brigade>().HasData(new Brigade(1, "Пусто"));
            modelBuilder.Entity<Employee.Brigade>().Property(f => f.ID_Brigade).HasIdentityOptions(startValue: 2);
            #endregion
            modelBuilder.Entity<Employee.Employee>(b => b.ToTable("employee"));
            modelBuilder.Entity<Employee.Employee>().Property(p => p.BrigadeId).HasDefaultValue(1);
            #region Employee
            modelBuilder.Entity<Employee.Employee>().Property(f => f.ID_Employee).UseIdentityAlwaysColumn();
            modelBuilder.Entity<Employee.Employee>().Property(f => f.ID_Employee).HasIdentityOptions(startValue: 2);
            //Где почта лучше замнить на любую свою почту
            modelBuilder.Entity<Employee.Employee>().HasData(new Employee.Employee(1, "Admin", "Почта", "Admin", "Admin", "Admin", "Admin", "0000", "000000", DateTime.Parse("24.04.1997")));
            #endregion
            #region EmployeePost
            modelBuilder.Entity<EmployeePost>(b => b.ToTable("empoyee_post"));
            modelBuilder.Entity<EmployeePost>().HasData(new EmployeePost[] { new EmployeePost(1,1,1) });
            modelBuilder.Entity<EmployeePost>().Property(f => f.ID_EmployeePost).UseIdentityAlwaysColumn();
            modelBuilder.Entity<EmployeePost>().Property(f => f.ID_EmployeePost).HasIdentityOptions(startValue: 2);
            #endregion
            modelBuilder.Entity<MedicalExamination>(b => b.ToTable("medical_examination"));
            #endregion
            #region Train
            modelBuilder.Entity<Train.Train>(b => b.ToTable("train"));
            modelBuilder.Entity<Train.Train>().Property(f => f.ID_Train).UseIdentityAlwaysColumn();
            modelBuilder.Entity<Train_Maintance>(b => b.ToTable("train_maintance"));
            modelBuilder.Entity<Train_Maintance>().Property(f => f.ID_Train_Maintance).UseIdentityAlwaysColumn();
            modelBuilder.Entity<TrainWorkType>(b => b.ToTable("train_work_type"));
            modelBuilder.Entity<TrainWorkType>().Property(f => f.IdType).UseIdentityAlwaysColumn();
            #endregion
            #region Station
            modelBuilder.Entity<Station.Station>(b => b.ToTable("station"));
            modelBuilder.Entity<Station.Station>().Property(f => f.ID_Station).UseIdentityAlwaysColumn();
            #endregion
            #region Route
            modelBuilder.Entity<Route.Route>(b => b.ToTable("route"));
            modelBuilder.Entity<Route.Route>().Property(f => f.ID_Route).UseIdentityAlwaysColumn();
            modelBuilder.Entity<Route.RouteType>(b => b.ToTable("route_type"));
            modelBuilder.Entity<Route.RouteType>().HasData(new Route.RouteType[] { new Route.RouteType(1, "Внутренний"), new Route.RouteType(2, "Международный"), new Route.RouteType(3, "Туристический"), new Route.RouteType(4, "Специальный маршрут") });
            #endregion
            #region Schedule
            modelBuilder.Entity<Schedule.Schedule>(b => b.ToTable("schedule"));
            modelBuilder.Entity<Schedule.Schedule>().Property(f=>f.ID_Schedule).UseIdentityAlwaysColumn();
            #endregion
            #region Ticket
            modelBuilder.Entity<Ticket.Ticket>(b => b.ToTable("ticket"));
            modelBuilder.Entity<Ticket.Ticket>().Property(f => f.ID_Ticket).UseIdentityAlwaysColumn();
            #endregion
        }
    }
}
