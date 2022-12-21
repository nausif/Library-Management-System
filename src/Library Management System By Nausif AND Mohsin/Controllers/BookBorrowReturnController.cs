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
    public class BookBorrowReturnController : Controller
    {
        private LMSEntities db = new LMSEntities();

        // GET: /BookBorrowReturn/
        public ActionResult Index()
        {
            if (Convert.ToString(Session["Loginaccess"]) == "ok")
            {
                var book_borrow_return = db.Book_Borrow_Return.Include(b => b.Book_Acc_Code1).Include(b => b.Member);
            return View(book_borrow_return.ToList());
            }
            return RedirectToAction("Index", "Home");

        }

        //// GET: /BookBorrowReturn/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Book_Borrow_Return book_borrow_return = db.Book_Borrow_Return.Find(id);
        //    if (book_borrow_return == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    book_borrow_return.Return_Date = DateTime.Now;
        //    return View(book_borrow_return);
        //}

        //[HttpPost]
        //public ActionResult Details([Bind(Include = "Return_Date,Fine_Charge")] Book_Borrow_Return book_borrow_return)
        //{
        //        db.Entry(book_borrow_return).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //}

        // GET: /BookBorrowReturn/Create
        public ActionResult Create()
        {
            if (Convert.ToString(Session["Loginaccess"]) == "ok")
            {
                List<string> temp1 = db.Book_Acc_Code.Select(q => q.Book_Acc_Code1).ToList();
            List<string> temp2 = db.Book_Borrow_Return.Where(e => e.Return_Date.Equals(null)).Select(e => e.Book_Acc_Code).ToList();
            List<string> temp3 = temp1.Except(temp2).ToList();
            ViewBag.Book_Acc_Code = new SelectList(temp3);
            ViewBag.Member_ID = new SelectList(db.Members, "Member_ID", "Member_FirstName");
            return View();
            }
            return RedirectToAction("Index", "Home");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Book_Borrow_ID,Borrow_Date,Return_Date,Due_Date,Fine_Charge,Book_Acc_Code,Member_ID")] Book_Borrow_Return book_borrow_return)
        {
            if (ModelState.IsValid)
            {
                book_borrow_return.Borrow_Date = System.DateTime.Now;
                book_borrow_return.Due_Date = System.DateTime.Now.Add(System.TimeSpan.FromDays(7));
                db.Book_Borrow_Return.Add(book_borrow_return);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            List<string> temp1 = db.Book_Acc_Code.Select(q => q.Book_Acc_Code1).ToList();
            List<string> temp2 = db.Book_Borrow_Return.Where(e => e.Return_Date.Equals(null)).Select(e => e.Book_Acc_Code).ToList();
            List<string> temp3 = temp1.Except(temp2).ToList();
            ViewBag.Book_Acc_Code = new SelectList(temp3);
            ViewBag.Member_ID = new SelectList(db.Members, "Member_ID", "Member_FirstName", book_borrow_return.Member_ID);
            return View(book_borrow_return);
        }

        [HttpGet]
        public ActionResult Return()
        {
            if (Convert.ToString(Session["Loginaccess"]) == "ok")
            {
                
                List<string> temp2 = db.Book_Borrow_Return.Where(e => e.Return_Date.Equals(null)).Select(e => e.Book_Acc_Code).ToList();
            List<BookAcc_Dropdown> l = badd.BookAcc_dd(temp2);
            ViewBag.Book_Acc_Code = new SelectList(l, "Book_Accessions", "Book_Accessions");
            return View();
            }
            return RedirectToAction("Index", "Home");

        }

        BookAcc_Dropdown badd = new BookAcc_Dropdown();

        [HttpPost]
        public ActionResult Return(ReturnBookModels rbm)
        {
            
            rbm.ReturnBook();
            List<string> temp2 = db.Book_Borrow_Return.Where(e => e.Return_Date.Equals(null)).Select(e => e.Book_Acc_Code).ToList();
            List<BookAcc_Dropdown> l = badd.BookAcc_dd(temp2);
            ViewBag.Book_Acc_Code = new SelectList(l, "Book_Accessions", "Book_Accessions");
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (Convert.ToString(Session["Loginaccess"]) == "ok")
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book_Borrow_Return book_borrow_return = db.Book_Borrow_Return.Find(id);
            if (book_borrow_return == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.Book_Acc_Code = new SelectList(db.Book_Acc_Code, "Book_Acc_Code1", "Book_Acc_Code1", book_borrow_return.Book_Acc_Code);
            ViewBag.Member_ID = new SelectList(db.Members, "Member_ID", "Member_FirstName", book_borrow_return.Member_ID);
            return View(book_borrow_return);
            }
            return RedirectToAction("Index", "Home");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Book_Borrow_ID,Borrow_Date,Return_Date,Due_Date,Fine_Charge,Book_Acc_Code,Member_ID")] Book_Borrow_Return book_borrow_return)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book_borrow_return).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Book_Acc_Code = new SelectList(db.Book_Acc_Code, "Book_Acc_Code1", "Book_Acc_Code1", book_borrow_return.Book_Acc_Code);
            ViewBag.Member_ID = new SelectList(db.Members, "Member_ID", "Member_FirstName", book_borrow_return.Member_ID);
            return View(book_borrow_return);
        }

        //// GET: /BookBorrowReturn/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Book_Borrow_Return book_borrow_return = db.Book_Borrow_Return.Find(id);
        //    if (book_borrow_return == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(book_borrow_return);
        //}

        //// POST: /BookBorrowReturn/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Book_Borrow_Return book_borrow_return = db.Book_Borrow_Return.Find(id);
        //    db.Book_Borrow_Return.Remove(book_borrow_return);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
