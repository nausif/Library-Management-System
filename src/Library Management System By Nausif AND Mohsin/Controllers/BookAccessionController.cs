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
    public class BookAccessionController : Controller
    {
        private LMSEntities db = new LMSEntities();

        // GET: /BookAccession/
        public ActionResult Index()
        {
            if (Convert.ToString(Session["Loginaccess"]) == "ok")
            {
                var book_acc_code = db.Book_Acc_Code.Include(b => b.Book_Edition);
            return View(book_acc_code.ToList());
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: /BookAccession/Details/5
        public ActionResult Details(string id)
        {
            if (Convert.ToString(Session["Loginaccess"]) == "ok")
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book_Acc_Code book_acc_code = db.Book_Acc_Code.Find(id);
            if (book_acc_code == null)
            {
                return HttpNotFound();
            }
                return View(book_acc_code);
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: /BookAccession/Create
        public ActionResult Create()
        {
            if (Convert.ToString(Session["Loginaccess"]) == "ok")
            {
                ViewBag.Book_ISBN = new SelectList(db.Book_Edition, "Book_ISBN", "Book_ISBN");
            return View();
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: /BookAccession/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Book_Acc_Code1,Book_ISBN")] Book_Acc_Code book_acc_code)
        {
            if (ModelState.IsValid)
            {
                db.Book_Acc_Code.Add(book_acc_code);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Book_ISBN = new SelectList(db.Book_Edition, "Book_ISBN", "Book_ISBN", book_acc_code.Book_ISBN);
            return View(book_acc_code);
        }

        // GET: /BookAccession/Edit/5
        public ActionResult Edit(string id)
        {
            if (Convert.ToString(Session["Loginaccess"]) == "ok")
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book_Acc_Code book_acc_code = db.Book_Acc_Code.Find(id);
            if (book_acc_code == null)
            {
                return HttpNotFound();
            }
            ViewBag.Book_ISBN = new SelectList(db.Book_Edition, "Book_ISBN", "Book_ISBN", book_acc_code.Book_ISBN);
            return View(book_acc_code);
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: /BookAccession/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Book_Acc_Code1,Book_ISBN")] Book_Acc_Code book_acc_code)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book_acc_code).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Book_ISBN = new SelectList(db.Book_Edition, "Book_ISBN", "Book_ISBN", book_acc_code.Book_ISBN);
            return View(book_acc_code);
        }

        // GET: /BookAccession/Delete/5
        public ActionResult Delete(string id)
        {
            if (Convert.ToString(Session["Loginaccess"]) == "ok")
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book_Acc_Code book_acc_code = db.Book_Acc_Code.Find(id);
            if (book_acc_code == null)
            {
                return HttpNotFound();
            }
            return View(book_acc_code);
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: /BookAccession/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Book_Acc_Code book_acc_code = db.Book_Acc_Code.Find(id);
            db.Book_Acc_Code.Remove(book_acc_code);
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
