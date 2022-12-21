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
    public class CategoryController : Controller
    {
        private LMSEntities db = new LMSEntities();

        // GET: /Category/
        public ActionResult Index()
        {
            if (Convert.ToString(Session["Loginaccess"]) == "ok")
            {
                return View(db.Categories.ToList());
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: /Category/Details/5
        public ActionResult Details(int? id)
        {
            if (Convert.ToString(Session["Loginaccess"]) == "ok")
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }
			return RedirectToAction("Index", "Home");
    }

        // GET: /Category/Create
        public ActionResult Create()
        {
            if (Convert.ToString(Session["Loginaccess"]) == "ok")
            {
                return View();
        }
			return RedirectToAction("Index", "Home");
    }

        // POST: /Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Category_ID,Category_Name")] Category category)
        {
            
                if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
            }
         

        // GET: /Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Convert.ToString(Session["Loginaccess"]) == "ok")
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: /Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Category_ID,Category_Name")] Category category)
        {
            
                if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
            }
         

        // GET: /Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Convert.ToString(Session["Loginaccess"]) == "ok")
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: /Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
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
