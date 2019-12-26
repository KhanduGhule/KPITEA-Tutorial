using KPITEA.Entities.DataModel;
using KPITEA.Entities.ViewModel;
using KPITEA.Repository.Interface;
using KPITEA.Repository.ModelEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
namespace KPITEA.Repository.Repository
{
    public class UserRepository : IUserRepository
    {
     private   KPITEA.Repository.ModelEntity.KPITEAEntities _dbContext;      

        public UserRepository(KPITEA.Repository.ModelEntity.KPITEAEntities dbContext)
        {
            this._dbContext = dbContext;
        }



        public bool Register(RegisterViewModel model)
        {
            bool QueryResult = false;
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {

                    tblEmployee emp = new tblEmployee();
                    emp.First_name = model.FistName;
                    emp.Middle_name = model.MiddleName;
                    emp.Last_name = model.LastName;
                    emp.Age = model.Age;
                    emp.Marital_Status = model.MaritalStatus;
                    emp.LastChangedAt = DateTime.Now;
                    emp.Salary = model.Salary;
                    emp.Location = model.Location;
                    _dbContext.tblEmployees.Add(emp);
                    int NOOfRecordsAffected = _dbContext.SaveChanges();
                    if (NOOfRecordsAffected > 0)
                    {
                        tblUserCredential Credential = new tblUserCredential();
                        Credential.EmailId = model.Email;
                        Credential.IsApproved = true;
                        Credential.EmployeeId = emp.Emp_ID;
                        Credential.Username = model.FistName + emp.Emp_ID.ToString();
                        Credential.PasswordHash = model.Password;
                        _dbContext.tblUserCredentials.Add(Credential);
                        _dbContext.SaveChanges();
                        scope.Complete();
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return QueryResult;
        }


        public IEnumerable<Users> GetAllUsers()
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
       public bool DeleteUser(decimal UserId)
        {
            bool Queryresult = false;
            using (TransactionScope scope = new TransactionScope())
            {
                var User = _dbContext.tblEmployees.Where(x => x.Emp_ID == UserId).FirstOrDefault();
                if (User != null)
                {

                    var UserCredentials = _dbContext.tblUserCredentials.Where(e => e.EmployeeId == User.Emp_ID).FirstOrDefault();
                    if (UserCredentials != null)
                    {
                        _dbContext.tblUserCredentials.Remove(UserCredentials);
                        _dbContext.tblEmployees.Remove(User);
                        int NoOfRecordsAffected = _dbContext.SaveChanges();
                        if (NoOfRecordsAffected > 0)
                        {
                            Queryresult = true;
                        }

                        scope.Complete();
                    }
                }
            }

            return Queryresult;
        }
    }
}
