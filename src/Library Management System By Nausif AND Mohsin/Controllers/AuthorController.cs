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
    public class AuthorController : Controller
    {
        private LMSEntities db = new LMSEntities();

        // GET: /Author/
        public ActionResult Index()
        {
            if (Convert.ToString(Session["Loginaccess"]) == "ok")
            {
                return View(db.Authors.ToList());
        }
			return RedirectToAction("Index", "Home");
    }

        // GET: /Author/Details/5
        public ActionResult Details(int? id)
        {
        if (Convert.ToString(Session["Loginaccess"]) == "ok")
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
    }
			return RedirectToAction("Index", "Home");
}

        
        public ActionResult Create()
{
    if (Convert.ToString(Session["Loginaccess"]) == "ok")
    {
        return View();
}
			return RedirectToAction("Index", "Home");
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Author_ID,Author_Name,Author_Email,Author_Phone")] Author author)
        {
            if (ModelState.IsValid)
            {
                db.Authors.Add(author);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(author);
        }

        
        public ActionResult Edit(int? id)
{
    if (Convert.ToString(Session["Loginaccess"]) == "ok")
    {
        if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
}
			return RedirectToAction("Index", "Home");
        }

        // POST: /Author/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Author_ID,Author_Name,Author_Email,Author_Phone")] Author author)
        {
            if (ModelState.IsValid)
            {
                db.Entry(author).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(author);
        }

        // GET: /Author/Delete/5
        public ActionResult Delete(int? id)
        {
    if (Convert.ToString(Session["Loginaccess"]) == "ok")
    {
        if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
}
			return RedirectToAction("Index", "Home");
        }

        // POST: /Author/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
    if (Convert.ToString(Session["Loginaccess"]) == "ok")
    {
        Author author = db.Authors.Find(id);
            db.Authors.Remove(author);
            db.SaveChanges();
            return RedirectToAction("Index");
}
			return RedirectToAction("Index", "Home");
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
