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
        //тут получение данных из базы данный посредством linq и ef core
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
            //include в ef core это получение данных при помощи вторичного ключа, например в таблице с должностью есть ключ DepartmentId, и мы в обьект Post загружаем так же "подобьект" Department, думаю понятно объяснил, в остальных моделях по аналогии
            return new ObservableCollection<Post>(db.Post.Include(p => p.Department).Include(p=>p.Role).Where(p=>p.ID_Post!=1));
        }
        public ObservableCollection<Model.Employee.Post> GetDepartmentsPostCombo()
        {
            var db = new ConnectDB();
            return new ObservableCollection<Post>(db.Post.Include(p=>p.Department).Include(p => p.Role));
        }
        public ObservableCollection<Model.Employee.Employee> GetEmployee()
        {
            var db = new ConnectDB();
            return new ObservableCollection<Employee>(db.Employee.Include(p=>p.Brigade).Include(p=>p.EmployeePost).ThenInclude(p=>p.Post));
        }
        public ObservableCollection<Model.Employee.Brigade> GetBrigades()
        {
            var db = new ConnectDB();
            return new ObservableCollection<Brigade>(db.Brigade.Where(p=>p.ID_Brigade!=1));

        }
        public List<Model.Employee.Role> GetRole()
        {
            var db = new ConnectDB();
            return db.Role.ToList();

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
        //тут обновленние данных в коллеции
        public void UpdateBrigade(ObservableCollection<Model.Employee.Brigade> brigades)//обновление бригады
        {
            var db = new ConnectDB();
            db.Brigade.UpdateRange(brigades);
            db.Brigade.RemoveRange(db.Brigade.Where(p => !brigades.Select(s => s.ID_Brigade).Contains(p.ID_Brigade) && p.ID_Brigade!=1));
            db.SaveChanges();
        }
        public void UpdateEmployee(ObservableCollection<Employee> employee)
        {
            var db=new ConnectDB();
            foreach(var emp in employee)
            {
                //employee post это список должностей пользователя
                foreach(var post in emp.EmployeePost)
                {
                    post.Post = null;//необходимо присвоить в employeepost переменной post null, потому что ef core будет пытатся добавить его в бд, и будет выскакивать исключение, что повторяющийся ключ
                }
                if (!emp.Valid_Phone)//если телефон не правильного формата то оставляет его пустым
                    emp.Phone = string.Empty;
                emp.Brigade = null; //аналогично с employee post
                if (emp.ID_Employee==1)//это чтобы не удалили случайно права администратору
                    continue;
                db.RemoveRange(db.EmployeePost.Where(p => !emp.EmployeePost.Select(s => s.ID_EmployeePost).Contains(p.ID_EmployeePost) && p.EmployeeId==emp.ID_Employee));//удаление должностей, которые мы вручную удалили из коллекции через del
                
            }
            //Обновление пользоватей
            db.Employee.UpdateRange(employee);
            //Удаление пользоватей
            db.RemoveRange(db.Employee.Where(p => !employee.Select(s => s.ID_Employee).Contains(p.ID_Employee) && p.ID_Employee!=1));
            db.SaveChanges();
        }
        public void UpdateDepartment(ObservableCollection<Department> departments)
        {
            var db = new ConnectDB();
            db.Department.UpdateRange(departments);
            db.RemoveRange(db.Department.Where(p => !departments.Select(s => s.ID_Department).Contains(p.ID_Department) && p.ID_Department!=1 ));
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
            db.RemoveRange(db.Post.Where(p => !posts.Select(s => s.ID_Post).Contains(p.ID_Post) && p.ID_Post!=1));
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
            db.RemoveRange(db.MedicalExamination.Where(p => !medicalExaminations.Select(s => s.ID_MedicalExamination).Contains(p.ID_MedicalExamination)));
            db.SaveChanges();
        }
    }
}
