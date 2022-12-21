using Library_Management_System_By_Nausif_AND_Mohsin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library_Management_System_By_Nausif_AND_Mohsin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        LMSEntities db = new LMSEntities();
        public ActionResult Dashboard()
        {
            if (Convert.ToString(Session["Loginaccess"]) == "ok")
            {
                DashboardModel dbm = new DashboardModel();
                ViewBag.TotalMem = db.Members.Count();
                ViewBag.TotalIssued = db.Book_Borrow_Return.Count();
                ViewBag.TotalBooks = db.Books.Count();
                ViewBag.TodayIssued = dbm.get_todayissue();
                ViewBag.TodayReturn = dbm.get_todayreturn();
                ViewBag.TodayMember = dbm.get_todaymember();
                return View();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}