using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fancy_Template.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            if (!Check_Login_Session())
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
        private bool Check_Login_Session()
        {
            if (Session["User_Name"] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}