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
    public class ReturnBookModels
    {
        [Required(ErrorMessage = "Book Accession is Required")]
        [Display(Name = "Book Accessions")]
        public string Book_Accessions { get; set; }

        [Required(ErrorMessage = "Return Date is Required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Return Date")]
        public DateTime ReturnDate { get; set; }

        [Display(Name = "Book Fine")]
        public int? fine { get; set; }

        public void ReturnBook()
        {
            object[] arr = get_duedate();
            
            double Totaldays = (DateTime.Now - Convert.ToDateTime(arr[0])).TotalDays;
            ReturnDate = DateTime.Now;
            if(Totaldays > 0)
            {
                fine = 50 * Convert.ToInt32(Totaldays);
                if(!(arr[1] == null))
                {
                    fine -= Convert.ToInt32(arr[1]);
                    if (fine < 0)
                    {
                        fine = null;
                    }
                }
            }


            
            SqlCommand sq_com = new SqlCommand("book_return", Connections.GetConnection());
            sq_com.CommandType = CommandType.StoredProcedure;
            sq_com.Parameters.AddWithValue("@returndate",ReturnDate);
            sq_com.Parameters.AddWithValue("@bookacccode",Book_Accessions);
            sq_com.Parameters.AddWithValue("@bookfine", ((object)fine ?? DBNull.Value));
            sq_com.ExecuteNonQuery();
        }

        public int Member_Discount()
        {
            SqlCommand sc = new SqlCommand("get_mem_discount", Connections.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@memid", Book_Accessions);
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return Convert.ToInt32(dt.Rows[0][0]);
        }


        public object[] get_duedate()
        {
            SqlCommand sc = new SqlCommand("get_duedate", Connections.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@acc",Book_Accessions );
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            object[] o = new object[2];
            o[0] = dt.Rows[0][0];
            o[1] = dt.Rows[0][1];
            return o;
        }
    }
    public class BookAcc_Dropdown
    {
        public string Book_Accessions { get; set; }
        public List<BookAcc_Dropdown> BookAcc_dd(List<string> l)
        {
            List<BookAcc_Dropdown> lc = new List<BookAcc_Dropdown>();
            for (int i = 0; i < l.Count; i++)
            {
                BookAcc_Dropdown bad = new BookAcc_Dropdown();
                bad.Book_Accessions = l[i];
                lc.Add(bad);
            }
            return lc;
        }
    }
}