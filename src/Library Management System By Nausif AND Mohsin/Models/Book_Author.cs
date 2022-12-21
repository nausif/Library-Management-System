using MVCLOGIN.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Library_Management_System_By_Nausif_AND_Mohsin.Models
{
    public class Book_Author
    {
        [Required(ErrorMessage = "ISBN is required")]
        [Display(Name = "Book ISBN")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Author Name is required")]
        [Display(Name = "Author Name")]
        public int Author_ID { get; set; }

        [Display(Name = "Author Name")]
        public string Author_Name { get; set; }

        [Display(Name = "Book Name")]
        public string Book_Name { get; set; }

        [Display(Name = "Edition")]
        public int Book_Edition { get; set; } 

        public void Add_Book_Author()
        {
            SqlCommand sq_com = new SqlCommand("addbookauthor", Connections.GetConnection());
            sq_com.CommandType = CommandType.StoredProcedure;
            sq_com.Parameters.AddWithValue("@bookisbn", ISBN);
            sq_com.Parameters.AddWithValue("@authorid", Author_ID);
            sq_com.ExecuteNonQuery();
        }

        public List<Book_Author> get_all_BookAuthors()
        {
            List<Book_Author> ba_list = new List<Book_Author>();

            SqlCommand sc = new SqlCommand("get_all_bookauthors", Connections.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sda = new SqlDataAdapter(sc);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Book_Author sm = new Book_Author();
                sm.ISBN = dt.Rows[i][0].ToString();
                sm.Author_ID = Convert.ToInt32(dt.Rows[i][1].ToString());
                sm.Author_Name = dt.Rows[i][2].ToString();
                sm.Book_Name = dt.Rows[i][3].ToString();
                sm.Book_Edition = Convert.ToInt32(dt.Rows[i][4].ToString());
                ba_list.Add(sm);
            }
            return (ba_list);
        }

        
        public void delete(string id1,int? id2)
        {
            SqlCommand sc = new SqlCommand("delete_bookauthor", Connections.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;

            sc.Parameters.AddWithValue("@authorid", id2);
            sc.Parameters.AddWithValue("@bookisbn", id1);
            sc.ExecuteNonQuery();
        }
        
        //public void findbookauthor(string id1 ,int? id2)
        //{
        //    SqlCommand sq_com = new SqlCommand("findbookauthor", Connections.GetConnection());
        //    sq_com.CommandType = CommandType.StoredProcedure;

        //    sq_com.Parameters.AddWithValue("@isbn", ISBN);
        //    sq_com.Parameters.AddWithValue("@authorid", Author_ID);
        //    SqlDataAdapter sda = new SqlDataAdapter(sq_com);

        //    DataTable dt = new DataTable();
        //    sda.Fill(dt);

        //    if (dt.Rows.Count > 0)
        //    {
        //        std_name = dt.Rows[0][1].ToString();
        //        std_f_name = dt.Rows[0][2].ToString();
        //        gender = dt.Rows[0][3].ToString();
        //        age = dt.Rows[0][4].ToString();
        //        program_name = dt.Rows[0][5].ToString();

        //        return true;
        //    }
        //    else
        //        return false;
        //}
    }

    public class DropdownforISBN
    {

        public string Book_ISBN { get; set; }

        public List<DropdownforISBN> GetISBN()
        {
            List<DropdownforISBN> lc = new List<DropdownforISBN>();
            SqlCommand sc = new SqlCommand("get_isbn", Connections.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;

            SqlDataReader sdr = sc.ExecuteReader();

            while (sdr.Read())
            {
                DropdownforISBN gc = new DropdownforISBN();
                gc.Book_ISBN = sdr["Book_ISBN"].ToString();
                lc.Add(gc);
            }
            sdr.Close();
            return lc;
        }

    }

    public class DropdownforAuthor
    {
        public int Author_ID { get; set; }

        public string Author_Name { get; set; }

        public List<DropdownforAuthor> GetAuthor()
        {
            List<DropdownforAuthor> lc = new List<DropdownforAuthor>();
            SqlCommand sc = new SqlCommand("get_author", Connections.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;

            SqlDataReader sdr = sc.ExecuteReader();

            while (sdr.Read())
            {
                DropdownforAuthor gc = new DropdownforAuthor();
                gc.Author_ID = Convert.ToInt32(sdr["Author_ID"]);
                gc.Author_Name = sdr["Author_Name"].ToString();
                lc.Add(gc);
            }
            sdr.Close();
            return lc;
        }


    }
}