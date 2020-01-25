using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Web.Security;
namespace MusicStore.Controllers
{
    public class AccountController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(string uid,string pwd)
        {

            if (uid == "admin" && pwd == "admin123")
            {
                FormsAuthentication.RedirectFromLoginPage(uid, false);
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid Username or Password";
            }
            return View();
        }
    }
}
