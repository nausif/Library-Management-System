using MVCLOGIN.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Library_Management_System_By_Nausif_AND_Mohsin.Models
{
    public class SearchBooks
    {
        [Display(Name="Book Name")]
        public string book_name { get; set; }
        [Display(Name = "Book ISBN")]
        public string book_ISBN { get; set; }
        [Display(Name = "Book Published Date")]
        public string book_published_date { get; set; }
        [Display(Name = "Book Price")]
        public Nullable<int> Book_Price { get; set; }
        [Display(Name = "Publisher Name")]
        public string Publisher_Name { get; set; }
        [Display(Name = "Book Edition")]
        public int Book_Edition { get; set; }


        public List<SearchBooks> searchresult(string bookname,string bookauthor,string category)
        {
            List<SearchBooks> ba_list = new List<SearchBooks>();

            SqlCommand sc = new SqlCommand("search_detailsofbooks", Connections.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@bookname",bookname);
            sc.Parameters.AddWithValue("@bookauthor", bookauthor);
            sc.Parameters.AddWithValue("@category", category);
            SqlDataAdapter sda = new SqlDataAdapter(sc);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SearchBooks sm = new SearchBooks();
                sm.book_name = dt.Rows[i][0].ToString();
                sm.book_ISBN = dt.Rows[i][1].ToString();
                sm.Book_Edition = Convert.ToInt32(dt.Rows[i][2]);
                sm.book_published_date = Convert.ToDateTime(dt.Rows[i][3]).ToShortDateString();
                sm.Book_Price = Convert.ToInt32(dt.Rows[i][4].ToString());
                sm.Publisher_Name = dt.Rows[i][5].ToString();
                ba_list.Add(sm);
            }
            return (ba_list);
        }
    }
    public class History
    {
        [Display(Name = "Book Name")]
        public string Book_Name { get; set; }

        [Display(Name = "Borrow Date")]
        public string Borrow_Date { get; set; }


        [Display(Name = "Book ISBN")]
        public string ISBN { get; set; }

        [Display(Name = "Return Date")]
        public string Return_Date { get; set; }


        [Display(Name = "Due Date")]
        public string Due_Date { get; set; }

        [Display(Name = "Fine Charge")]
        public Nullable<int> Fine_Charge { get; set; }


        [Display(Name = "Book Accession Code")]
        public string Book_Acc_Code { get; set; }



        public List<History> MemberHistory(int memid)
        {
            List<History> ba_list = new List<History>();

            SqlCommand sc = new SqlCommand("memberhistory", Connections.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@memberid", memid);
            SqlDataAdapter sda = new SqlDataAdapter(sc);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                History sm = new History();
                sm.Book_Name = dt.Rows[i][0].ToString();
                sm.ISBN = dt.Rows[i][1].ToString();
                sm.Book_Acc_Code = dt.Rows[i][2].ToString();
                sm.Borrow_Date = Convert.ToDateTime(dt.Rows[i][3]).ToShortDateString();
                if(dt.Rows[i][4].ToString() == "")
                {
                    sm.Return_Date = "";
                }
                else
                sm.Return_Date = Convert.ToDateTime(dt.Rows[i][4]).ToShortDateString();
                sm.Due_Date = Convert.ToDateTime(dt.Rows[i][5]).ToShortDateString();
                if (dt.Rows[i][6].ToString() == "")
                {
                    sm.Fine_Charge = null;
                }
                else
                sm.Fine_Charge = Convert.ToInt32(dt.Rows[i][6].ToString());
                ba_list.Add(sm);
            }
            return (ba_list);
        }
        
    }
}