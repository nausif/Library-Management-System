using Library_Management_System_By_Nausif_AND_Mohsin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library_Management_System_By_Nausif_AND_Mohsin.Controllers
{
    public class UserAccountController : Controller
    {
        UserSignupModel usm = new UserSignupModel();
        [HttpGet]
        public ActionResult UserSignup()
        {
            return View(usm);
        }
        [HttpPost]
        public ActionResult UserSignup(UserSignupModel sm)
        {
            sm.registerMember();
            ModelState.Clear();
            usm = null;
            ViewBag.Message = "Registeration Done Successfully";
            return View(usm);
        }

        
        [HttpGet]
        public ActionResult UserLogin()
        {
            Session["Loginaccess"] = "no";
            return View();
        }

        [HttpPost]
        public ActionResult UserLogin(UserLoginModel ulm)
        {

            int logincheck = ulm.GetPassword();
            Session["loginname"] = ulm.name;
            Session["memberid"] = ulm.memid;
            if (logincheck == 1)
            {
                Session["Loginaccess"] = "ok";
                return RedirectToAction("DashBoard", "Home");
                
            }
            else if(logincheck == 2)
            {
                return RedirectToAction("Search", "SearchBooks");
            }
            else   
            return View();
        }
	}
}