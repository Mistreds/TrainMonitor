using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainMonitor.Model.Employee
{
    public class EmployeeModel
    {
        public ObservableCollection<Model.Employee.Department> GetDepartments()
        {
            var db = new ConnectDB();
            return  new ObservableCollection<Department>(db.Department.Where(p=>p.ID_Department!=1));
        }
        public ObservableCollection<Model.Employee.Department> GetDepartmentsCombo()
        {
            var db = new ConnectDB();
            return new ObservableCollection<Department>(db.Department);
        }
        public ObservableCollection<Model.Employee.Post> GetDepartmentsPost()
        {
            var db = new ConnectDB();
            return new ObservableCollection<Post>(db.Post.Include(p => p.Department).Where(p=>p.ID_Post!=1));
        }
        public ObservableCollection<Model.Employee.Post> GetDepartmentsPostCombo()
        {
            var db = new ConnectDB();
            return new ObservableCollection<Post>(db.Post.Include(p=>p.Department));
        }
        public ObservableCollection<Model.Employee.Employee> GetEmployee()
        {
            var db = new ConnectDB();
            return new ObservableCollection<Employee>(db.Employee.Where(p => p.ID_Employee != 1));
        }
        public void UpdateDepartment(ObservableCollection<Department> departments)
        {
            var db = new ConnectDB();
            foreach (var department in departments)
            {
                Console.WriteLine(department.ID_Department);
            }
            Console.ReadLine(); 
            db.Department.UpdateRange(departments);
            db.SaveChanges();
        }
        public void UpdatePost(ObservableCollection<Post> posts)
        {
            var db=new ConnectDB();
            foreach (var post in posts)
            {
                Console.WriteLine(post.ID_Post);
                post.Department = null;
            }
            db.Post.UpdateRange(posts);
            db.SaveChanges();
        }
       
    }
}
