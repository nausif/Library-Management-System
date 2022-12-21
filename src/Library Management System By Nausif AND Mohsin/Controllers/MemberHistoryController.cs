using Library_Management_System_By_Nausif_AND_Mohsin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library_Management_System_By_Nausif_AND_Mohsin.Controllers
{
    public class MemberHistoryController : Controller
    {
        History h = new History();
        [HttpGet]
        public ActionResult History()
        {
            List<History> lsb = h.MemberHistory(Convert.ToInt32(Session["memberid"]));
            return View(lsb);
            
        }

	}
}