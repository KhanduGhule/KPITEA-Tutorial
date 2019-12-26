using KPITEA.Entities.DataModel;
using KPITEA.Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPITEA.Repository.Interface
{
  public  interface IUserRepository
    {
        bool Register(RegisterViewModel model);
        IEnumerable<Users> GetAllUsers();
        bool DeleteUser(decimal UserId);
    }
}
