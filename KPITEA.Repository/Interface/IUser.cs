using KPITEA.Entities.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPITEA.Repository.Interface
{
  public  interface IUser
    {
        bool Register(RegisterViewModel model);
    }
}
