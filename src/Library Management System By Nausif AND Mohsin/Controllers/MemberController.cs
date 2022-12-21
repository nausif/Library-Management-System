using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Library_Management_System_By_Nausif_AND_Mohsin.Models;

namespace Library_Management_System_By_Nausif_AND_Mohsin.Controllers
{
    public class MemberController : Controller
    {
        private LMSEntities db = new LMSEntities();

        public ActionResult Index()
        {
            if (Convert.ToString(Session["Loginaccess"]) == "ok")
            {
                var members = db.Members.Include(m => m.Member_Type);
            return View(members.ToList());
        }
			return RedirectToAction("Index", "Home");
    }

        public ActionResult Details(int? id)
        {
        if (Convert.ToString(Session["Loginaccess"]) == "ok")
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
    }
			return RedirectToAction("Index", "Home");
}

        public ActionResult Create()
        {
    if (Convert.ToString(Session["Loginaccess"]) == "ok")
    {
        ViewBag.Member_Type_ID = new SelectList(db.Member_Type, "Member_Type_ID", "Member_Type_Name");
            return View();
          }
			return RedirectToAction("Index", "Home");
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Member_ID,Member_FirstName,Member_LastName,Member_Type_ID,Member_Password,Member_Address,Member_Registered_Date,Member_Phone,Member_Email,Member_Gender,Member_DOB")] Member member)
        {
   
        if (ModelState.IsValid)
            {
                member.Member_Type_ID = 2;
                member.Member_Registered_Date = DateTime.Now;
                db.Members.Add(member);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(member);
        }

        public ActionResult Edit(int? id)
        {
    if (Convert.ToString(Session["Loginaccess"]) == "ok")
    {
        if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            ViewBag.Member_Type_ID = new SelectList(db.Member_Type, "Member_Type_ID", "Member_Type_Name", member.Member_Type_ID);
            return View(member);
}
			return RedirectToAction("Index", "Home");
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Member_ID,Member_FirstName,Member_LastName,Member_Type_ID,Member_Password,Member_Address,Member_Registered_Date,Member_Phone,Member_Email,Member_Gender,Member_DOB")] Member member)
        {

            if (ModelState.IsValid)
            {
                db.Entry(member).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Member_Type_ID = new SelectList(db.Member_Type, "Member_Type_ID", "Member_Type_Name", member.Member_Type_ID);
            return View(member);
        }

     
        public ActionResult Delete(int? id)
        {
    if (Convert.ToString(Session["Loginaccess"]) == "ok")
    {
        if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
}
			return RedirectToAction("Index", "Home");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            Member member = db.Members.Find(id);
            db.Members.Remove(member);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
