﻿using Microsoft.EntityFrameworkCore;
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
            return new ObservableCollection<Employee>(db.Employee.Include(p=>p.Brigade).Include(p=>p.Post));
        }
        public ObservableCollection<Model.Employee.Brigade> GetBrigades()
        {
            var db = new ConnectDB();
            return new ObservableCollection<Brigade>(db.Brigade.Where(p=>p.ID_Brigade!=1));

        }
        public ObservableCollection<Model.Employee.Brigade> GetBrigadesCombo()
        {
            var db = new ConnectDB();
            return new ObservableCollection<Brigade>(db.Brigade);

        }
        public ObservableCollection<Model.Employee.MedicalExamination> GetMedicalExaminations()
        {
            var db=new ConnectDB();
            return new ObservableCollection<MedicalExamination>(db.MedicalExamination.Include(p => p.Employee));
        }
        public void UpdateBrigade(ObservableCollection<Model.Employee.Brigade> brigades)
        {
            var db = new ConnectDB();
            foreach (var item in brigades)
            {
                if(item.ID_Brigade<1)
                {
                    item.ID_Brigade = 0;
                }
            }
            db.Brigade.UpdateRange(brigades);
            db.SaveChanges();
        }
        public void UpdateEmployee(ObservableCollection<Employee> employee)
        {
            var db=new ConnectDB();
            foreach(var emp in employee)
            {
                emp.Post = null;
                emp.Brigade = null;
            }
            db.Employee.UpdateRange(employee);
            db.SaveChanges();
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
       public void UpdateMedical(ObservableCollection<Model.Employee.MedicalExamination> medicalExaminations)
        {
            foreach(var emp in medicalExaminations)
            {
                emp.Employee = null;
            }
            var db= new ConnectDB();
            db.MedicalExamination.UpdateRange(medicalExaminations);
            db.SaveChanges();
        }
    }
}
