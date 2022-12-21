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
    public class UserSignupModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(70)]
        [Display(Name = "Address")]
        public string Address { get; set; }


        [Display(Name = "Registered Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public System.DateTime Registered_Date { get; set; }

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^((\+92-?)|0)?[0-9]{10}$", ErrorMessage = "Entered phone format is not valid.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Email Address")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Email is is not valid.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Gender is Required")]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "DOB is Required")]
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public System.DateTime DOB { get; set; }

        public void registerMember()
        {
            SqlCommand sq_com = new SqlCommand("registermember", Connections.GetConnection());
            sq_com.CommandType = CommandType.StoredProcedure;
            sq_com.Parameters.AddWithValue("@firstname", FirstName);
            sq_com.Parameters.AddWithValue("@lastname", LastName);
            sq_com.Parameters.AddWithValue("@pass", Password);
            sq_com.Parameters.AddWithValue("@address", Address);
            sq_com.Parameters.AddWithValue("@email", Email);
            sq_com.Parameters.AddWithValue("@gender", Gender);
            sq_com.Parameters.AddWithValue("@dob", DOB);
            sq_com.Parameters.AddWithValue("@phoneno", ((object)Phone ?? DBNull.Value));
            sq_com.ExecuteNonQuery();
        }
    }
    public class UserLoginModel
    {
        [Display(Name = "Email Address")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Email is is not valid.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public string name { get; set; }

        public int memid { get; set; }

        public int GetPassword()
        {
            SqlCommand sq_com = new SqlCommand("loginmember", Connections.GetConnection());
            sq_com.CommandType = CommandType.StoredProcedure;

            sq_com.Parameters.AddWithValue("@email", Email);
            SqlDataAdapter sda = new SqlDataAdapter(sq_com);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
                if (dt.Rows[0][0].Equals(Password))
                {
                    name = dt.Rows[0][2].ToString();
                    memid = Convert.ToInt32(dt.Rows[0][3]);
                    if (dt.Rows[0][1].Equals(1))
                    {
                        return 1;
                    }
                    return 2;
                }
            return -1;
        }
    }
}