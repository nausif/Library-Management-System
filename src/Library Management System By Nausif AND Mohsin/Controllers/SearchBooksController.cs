using Library_Management_System_By_Nausif_AND_Mohsin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library_Management_System_By_Nausif_AND_Mohsin.Controllers
{
    public class SearchBooksController : Controller
    {
        SearchBooks sb = new SearchBooks();
        [HttpGet] 
        public ActionResult Search()
        {
            List<SearchBooks> lsb = new List<SearchBooks>();
            return View(lsb);
        }

        [HttpPost] 
        public ActionResult Search(string bookname,string bookauthor,string category)
        {

            List<SearchBooks> lsb = sb.searchresult(bookname, bookauthor, category);
            return View(lsb);
        }
	}
}