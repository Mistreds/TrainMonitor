using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainMonitor.Model.Employee;

namespace TrainMonitor.Model
{
    public class ConnectDB : DbContext
    {

        public DbSet<Employee.Employee> Employee { get; set; }
        public DbSet<Employee.Department> Department { get; set; }
        public DbSet<Employee.Post> Post { get; set; }
        public  DbSet<Employee.Brigade> Brigade { get; set; }
        public ConnectDB()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
            //Database.Migrate();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Тут необходимао прописать настройки postgres, где database желаемое название (база создается автоматически при первом запуске) и password соотвественно пароль
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=;Username=postgres;Password=");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee.Department>(b => b.ToTable("department"));
            modelBuilder.Entity<Employee.Department>().HasData(new Employee.Department[]
            {
                new Employee.Department(1,"Пусто"),new Employee.Department(2,"Администратор")
            });
            modelBuilder.Entity<Employee.Post>(b => b.ToTable("post"));
            modelBuilder.Entity<Employee.Post>().HasData(new Employee.Post[] {new Employee.Post(1, "Пусто", 0, 1), new Employee.Post(2, "Администратор", 0, 2)});
            modelBuilder.Entity<Employee.Employee>(b => b.ToTable("employee"));
            modelBuilder.Entity<Employee.Employee>().Property(p => p.BrigadeId).HasDefaultValue(1);
            modelBuilder.Entity<Employee.Employee>().HasData(new Employee.Employee(1, "Admin", "mistred24@yandex.ru", "Admin", "Admin","Admin","Admin" , "0000" , "000000", DateTime.Parse("24.04.1997"), 1));
            modelBuilder.Entity<Employee.Brigade>(b => b.ToTable("brigade"));
            modelBuilder.Entity<Employee.Brigade>().HasData(new Brigade(1, "Пусто"));
        }
    }
}
