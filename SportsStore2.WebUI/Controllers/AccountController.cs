using SportsStore2.WebUI.Infrastructure.Abstract;
using SportsStore2.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore2.WebUI.Controllers
{
    public class AccountController : Controller
    {
        IAuthor Auth;

        public AccountController(IAuthor Auth)
        {
            this.Auth = Auth;
        }

        //
        // GET: /Account/
        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel p_LoginVM)
        {
            if(ModelState.IsValid)
            {
                if(Auth.Authenticate(p_LoginVM.UserName,p_LoginVM.Password))
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid UserName And Password!");
                    return View(p_LoginVM);
                }
            }
            else
            {
                return View(p_LoginVM);
            }
        }
	}
}