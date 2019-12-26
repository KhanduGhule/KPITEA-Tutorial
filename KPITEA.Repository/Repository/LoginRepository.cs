using KPITEA.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KPITEA.Entities.ViewModel;

namespace KPITEA.Repository.Repository
{
   public class LoginRepository : ILoginRepository
    {
        KPITEA.Repository.ModelEntity.KPITEAEntities _dbContext;

        public LoginRepository(KPITEA.Repository.ModelEntity.KPITEAEntities dbContext)
        {
            this._dbContext = dbContext;
        }

        bool ILoginRepository.ValidateUserCredentials(LoginViewModel model)
        {
            bool QueryResult = false;

            var UserData = _dbContext.tblUserCredentials.Where(x => x.EmailId== model.Email).FirstOrDefault();
            if (UserData != null)
            {
                if (UserData.PasswordHash == model.Password)
                {
                     
                       QueryResult = true;
                }
            }
            return QueryResult;
        }       
    }
}
