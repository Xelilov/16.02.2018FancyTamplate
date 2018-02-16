using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fancy_Template.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {            
            return View();
        }
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(FormCollection frm)
        {
            Session["User_Name"] = frm["User_name"] ;
            Session["User_Password"] = frm["User_password"];
            if (Session["User_Name"].ToString() == "admin")
            {
                if (Session["User_Password"].ToString() == "admin")
                {
                    
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return RedirectToAction("Index");

            }            
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

        public ActionResult LogOut()
        {
            Session["User_Name"] = null;
            return RedirectToAction("Index");
        }

    }
}