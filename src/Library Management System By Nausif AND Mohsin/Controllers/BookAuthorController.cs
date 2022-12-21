using Library_Management_System_By_Nausif_AND_Mohsin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Library_Management_System_By_Nausif_AND_Mohsin.Controllers
{
    public class BookAuthorController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            if (Convert.ToString(Session["Loginaccess"]) == "ok")
            {
                Book_Author ba = new Book_Author();
            List<Book_Author> list = ba.get_all_BookAuthors();
            return View(list);
        }
			return RedirectToAction("Index", "Home");

    }

    Book_Author ba = new Book_Author();
        public ActionResult delete(string id1,int? id2,string id3,string id4,int? id5)
        {
            if (Convert.ToString(Session["Loginaccess"]) == "ok")
            {
                if (id1 == null || id2 == null || id3 == null || id4 == null || id5 == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                ba.Author_ID = Convert.ToInt32(id2);
                ba.ISBN = id1;
                ba.Book_Edition = Convert.ToInt32(id5);
                ba.Author_Name = id3;
                ba.Book_Name = id4;
                return View(ba);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id1, int id2)
        {
            ba.delete(id1, id2);
            return RedirectToAction("Index");
        }

        public ActionResult Add_Author()
        {

            if (Convert.ToString(Session["Loginaccess"]) == "ok")
            {
                DropdownforISBN gc = new DropdownforISBN();
            List<DropdownforISBN> lgc = gc.GetISBN();
            ViewBag.isbn = new SelectList(lgc, "Book_ISBN", "Book_ISBN");

            DropdownforAuthor dd = new DropdownforAuthor();
            List<DropdownforAuthor> ldd = dd.GetAuthor();
            ViewBag.author = new SelectList(ldd, "Author_ID", "Author_Name");

            return View();
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Add_Author(Book_Author ba)
        {

            ba.Add_Book_Author();

            DropdownforISBN gc = new DropdownforISBN();
            List<DropdownforISBN> lgc = gc.GetISBN();
            ViewBag.isbn = new SelectList(lgc, "Book_ISBN", "Book_ISBN");

            DropdownforAuthor dd = new DropdownforAuthor();
            List<DropdownforAuthor> ldd = dd.GetAuthor();
            ViewBag.author = new SelectList(ldd, "Author_ID", "Author_Name");

            return RedirectToAction("Index");
        }

	}
}