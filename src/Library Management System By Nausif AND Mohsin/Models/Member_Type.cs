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

    public partial class Member_Type
    {
        public Member_Type()
        {
            this.Members = new HashSet<Member>();
        }
        [Display(Name = "Member Type ID")]
        public int Member_Type_ID { get; set; }

        [Required(ErrorMessage = "Member Type Name is required")]
        [Display(Name = "Member Type Name")]
        [StringLength(50)]
        public string Member_Type_Name { get; set; }

        [Display(Name = "Member Type Discount")]
        public Nullable<int> Member_Discount { get; set; }

        public virtual ICollection<Member> Members { get; set; }
    }
}
