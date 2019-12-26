using KPITEA.Entities.DataModel;
using KPITEA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using KPITEA.Repository.Repository;
using KPITEA.Repository.Interface;

namespace KPITEA.Controllers
{
    public class LoginController : Controller
    {
        private readonly KPITEA.Repository.Interface.IUserRepository _repository;
        private readonly KPITEA.Repository.Interface.ILoginRepository _loginRepository;
        public LoginController(IUserRepository repository, KPITEA.Repository.Interface.ILoginRepository loginRepository)
        {
            this._repository = repository;
            this._loginRepository = loginRepository;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult ValidateUserCredentials(KPITEA.Entities.ViewModel.LoginViewModel model)
        {
            ViewBag.Message = "Users";

            var IsValidCredentials = _loginRepository.ValidateUserCredentials(model);
            if (!IsValidCredentials)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                Session["LoggedUserId"] = model.Email;
                return RedirectToAction("Users", "Home");
            }

            return View();
        }




        [HttpPost]
        [AllowAnonymous]      
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
          
             bool QueryResult=  _repository.Register(model);
            if (QueryResult)
            {
                return RedirectToAction("Index", "Login");
            }
             
            return View(model);
        }
    }
}