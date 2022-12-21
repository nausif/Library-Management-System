//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Library_Management_System_By_Nausif_AND_Mohsin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Book_Acc_Code
    {
        public Book_Acc_Code()
        {
            this.Book_Borrow_Return = new HashSet<Book_Borrow_Return>();
        }

        [Required(ErrorMessage = "Book Accession is Required")]
        [Display(Name = "Book Accession Code")]
        public string Book_Acc_Code1 { get; set; }

        [Required(ErrorMessage = "ISBN is required")]
        [Display(Name = "Book ISBN")]
        public string Book_ISBN { get; set; }

        public virtual Book_Edition Book_Edition { get; set; }
        public virtual ICollection<Book_Borrow_Return> Book_Borrow_Return { get; set; }
    }
}