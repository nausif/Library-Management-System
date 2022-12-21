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
    public class BookController : Controller
    {
        private LMSEntities db = new LMSEntities();

        // GET: /Book/
        public ActionResult Index()
        {
            if (Convert.ToString(Session["Loginaccess"]) == "ok")
            {
                var books = db.Books.Include(b => b.Category);
            return View(books.ToList());
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: /Book/Details/5
        public ActionResult Details(int? id)
        {
            if (Convert.ToString(Session["Loginaccess"]) == "ok")
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: /Book/Create
        public ActionResult Create()
        {
            if (Convert.ToString(Session["Loginaccess"]) == "ok")
            {
                ViewBag.Category_ID = new SelectList(db.Categories, "Category_ID", "Category_Name");
            return View();
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: /Book/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Book_ID,Book_Title,Category_ID")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Category_ID = new SelectList(db.Categories, "Category_ID", "Category_Name", book.Category_ID);
            return View(book);
        }

        // GET: /Book/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Convert.ToString(Session["Loginaccess"]) == "ok")
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.Category_ID = new SelectList(db.Categories, "Category_ID", "Category_Name", book.Category_ID);
            return View(book);
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: /Book/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Book_ID,Book_Title,Category_ID")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Category_ID = new SelectList(db.Categories, "Category_ID", "Category_Name", book.Category_ID);
            return View(book);
        }

        // GET: /Book/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Convert.ToString(Session["Loginaccess"]) == "ok")
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: /Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
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
