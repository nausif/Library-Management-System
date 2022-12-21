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
    public class MemberTypeController : Controller
    {
        private LMSEntities db = new LMSEntities();
        
        // GET: /MemberType/
        public ActionResult Index()
        {
            if (Convert.ToString(Session["Loginaccess"]) == "ok")
            {
                return View(db.Member_Type.ToList());
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: /MemberType/Details/5
        public ActionResult Details(int? id)
        {
            if (Convert.ToString(Session["Loginaccess"]) == "ok")
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member_Type member_type = db.Member_Type.Find(id);
            if (member_type == null)
            {
                return HttpNotFound();
            }
            return View(member_type);
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: /MemberType/Create
        public ActionResult Create()
        {
            if (Convert.ToString(Session["Loginaccess"]) == "ok")
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: /MemberType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Member_Type_ID,Member_Type_Name,Member_Discount")] Member_Type member_type)
        {
            if (ModelState.IsValid)
            {
                db.Member_Type.Add(member_type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(member_type);
        }

        // GET: /MemberType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Convert.ToString(Session["Loginaccess"]) == "ok")
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member_Type member_type = db.Member_Type.Find(id);
            if (member_type == null)
            {
                return HttpNotFound();
            }
            return View(member_type);
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: /MemberType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Member_Type_ID,Member_Type_Name,Member_Discount")] Member_Type member_type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(member_type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(member_type);
        }

        // GET: /MemberType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Convert.ToString(Session["Loginaccess"]) == "ok")
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member_Type member_type = db.Member_Type.Find(id);
            if (member_type == null)
            {
                return HttpNotFound();
            }
            return View(member_type);
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: /MemberType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Member_Type member_type = db.Member_Type.Find(id);
            db.Member_Type.Remove(member_type);
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
