using KPITEA.Entities.ViewModel;
using KPITEA.Repository.Interface;
using KPITEA.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KPITEA.Controllers
{
    [SessionTimeoutFilterAttribute]
    public class HomeController : Controller
    {
        
        private readonly KPITEA.Repository.Interface.IUserRepository  _repository;

        private readonly KPITEA.Repository.Interface.ILoginRepository _loginRepository;
        public HomeController(IUserRepository repository, KPITEA.Repository.Interface.ILoginRepository loginRepository)
        {
            this._repository = repository;
            this._loginRepository = loginRepository;

        }
        

        public ActionResult Users()
        {
            ViewBag.Message = "Users";        

           var Model= _repository.GetAllUsers();

            return View(Model);
        }
       

        public ActionResult deleteUser(Decimal UserId)
        {
            decimal QueryResultId = 0;
            if (ModelState.IsValid)
            {
                try
                {

                   bool QueryResult = _repository.DeleteUser(UserId);
                    return Json(QueryResult, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    QueryResultId = -1;
                    //var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(TaskId);
                    // EMSGlobal.log_EMS.Error(Environment.NewLine + "Exception occurred while executing AddTask(PMTasksController) : " + Environment.NewLine + " Default Data : " + jsonString + Environment.NewLine + ex.ToString());
                }

            }
            else
            {
                //var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(TaskId);
                // EMSGlobal.log_EMS.Error(Environment.NewLine + "Exception occurred while executing AddTask(PMTasksController)  " + Environment.NewLine + " in which ModelState is not found as valid : " + Environment.NewLine + " Default Data : " + jsonString.ToString());
            }
            return Json(QueryResultId, JsonRequestBehavior.AllowGet);
        }
    }
}