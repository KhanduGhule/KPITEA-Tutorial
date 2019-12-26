using KPITEA.Entities.DataModel;
using KPITEA.Entities.ViewModel;
using KPITEA.Repository.Interface;
using KPITEA.Repository.ModelEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPITEA.Repository.Repository
{
    public class User : IUser
    {
        public bool Register(RegisterViewModel model)
        {

            bool QueryResult = false;
            KPITEAEntities dbcontext = new KPITEAEntities();
            tblEmployee emp = new tblEmployee();
            emp.First_name = model.FistName;
            emp.Middle_name = model.MiddleName;
            emp.Last_name = model.LastName;
            emp.Age = model.Age;
            emp.Marital_Status= model.MaritalStatus;
            emp.LastChangedAt = DateTime.Now;
            emp.Salary = model.Salary;
            emp.Location = model.Location;
            dbcontext.tblEmployees.Add(emp);
            dbcontext.SaveChanges();
            return QueryResult;
        }


        public List<Users> GetAllUsers()
        {
            List<Users> List = new List<Users>();
            KPITEAEntities dbcontext = new KPITEAEntities();
             List = dbcontext.tblEmployees.Select(f => new Users()
            {
                Emp_ID=f.Emp_ID,
                First_name = f.First_name,
                Last_name = f.Last_name,
                Middle_name = f.Middle_name,
                Marital_Status=f.Marital_Status,
                Age=f.Age,
                Salary=f.Salary,
                Location=f.Location               
                
            }).ToList();


            return List;
        }

    }
}
