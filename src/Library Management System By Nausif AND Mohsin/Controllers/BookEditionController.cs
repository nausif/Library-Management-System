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
    public class BookEditionController : Controller
    {
        private LMSEntities db = new LMSEntities();

        // GET: /BookEdition/
        public ActionResult Index()
        {
            if (Convert.ToString(Session["Loginaccess"]) == "ok")
            {
                var book_edition = db.Book_Edition.Include(b => b.Book).Include(b => b.Publisher);
            return View(book_edition.ToList());
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: /BookEdition/Details/5
        public ActionResult Details(string id)
        {
            if (Convert.ToString(Session["Loginaccess"]) == "ok")
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book_Edition book_edition = db.Book_Edition.Find(id);
            if (book_edition == null)
            {
                return HttpNotFound();
            }
            return View(book_edition);
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: /BookEdition/Create
        public ActionResult Create()
        {
            if (Convert.ToString(Session["Loginaccess"]) == "ok")
            {
                ViewBag.Book_ID = new SelectList(db.Books, "Book_ID", "Book_Title");
            ViewBag.Publisher_ID = new SelectList(db.Publishers, "Publisher_ID", "Publisher_Name");
            return View();
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: /BookEdition/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Book_ISBN,Book_ID,Book_Published_Date,Book_Price,Publisher_ID,Book_Edition1")] Book_Edition book_edition)
        {
            if (ModelState.IsValid)
            {
                db.Book_Edition.Add(book_edition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Book_ID = new SelectList(db.Books, "Book_ID", "Book_Title", book_edition.Book_ID);
            ViewBag.Publisher_ID = new SelectList(db.Publishers, "Publisher_ID", "Publisher_Name", book_edition.Publisher_ID);
            return View(book_edition);
        }

        // GET: /BookEdition/Edit/5
        public ActionResult Edit(string id)
        {
            if (Convert.ToString(Session["Loginaccess"]) == "ok")
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book_Edition book_edition = db.Book_Edition.Find(id);
            if (book_edition == null)
            {
                return HttpNotFound();
            }
            ViewBag.Book_ID = new SelectList(db.Books, "Book_ID", "Book_Title", book_edition.Book_ID);
            ViewBag.Publisher_ID = new SelectList(db.Publishers, "Publisher_ID", "Publisher_Name", book_edition.Publisher_ID);
            return View(book_edition);
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: /BookEdition/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Book_ISBN,Book_ID,Book_Published_Date,Book_Price,Publisher_ID,Book_Edition1")] Book_Edition book_edition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book_edition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Book_ID = new SelectList(db.Books, "Book_ID", "Book_Title", book_edition.Book_ID);
            ViewBag.Publisher_ID = new SelectList(db.Publishers, "Publisher_ID", "Publisher_Name", book_edition.Publisher_ID);
            return View(book_edition);

        }

        // GET: /BookEdition/Delete/5
        public ActionResult Delete(string id)
        {
            if (Convert.ToString(Session["Loginaccess"]) == "ok")
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book_Edition book_edition = db.Book_Edition.Find(id);
            if (book_edition == null)
            {
                return HttpNotFound();
            }
            return View(book_edition);
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: /BookEdition/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Book_Edition book_edition = db.Book_Edition.Find(id);
            db.Book_Edition.Remove(book_edition);
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
