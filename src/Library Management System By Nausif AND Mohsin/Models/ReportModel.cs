using MVCLOGIN.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Library_Management_System_By_Nausif_AND_Mohsin;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Report1Model
    {
        public string Member_FirstName { get; set; }
        public string Member_LastName { get; set; }
        public string Member_Address { get; set; }
        public string Member_Registered_Date { get; set; }
        public string Member_Email { get; set; }
        public string Member_Gender {get;set;}
        public string Member_DOB {get;set;}


        public static List<Report1Model> get_report_data()
        {
            List<Report1Model> rm_list = new List<Report1Model>();

            SqlCommand sc = new SqlCommand("get_report_data", Connections.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;

            SqlDataReader sdr = sc.ExecuteReader();

            while (sdr.Read())
            {
                Report1Model rm = new Report1Model();
                rm.Member_FirstName = sdr["Member_FirstName"].ToString();
                rm.Member_LastName = sdr["Member_LastName"].ToString();
                rm.Member_Address = sdr["Member_Address"].ToString();
                rm.Member_Registered_Date = Convert.ToDateTime(sdr["Member_Registered_Date"]).ToShortDateString();
                rm.Member_Email = sdr["Member_Email"].ToString();
                rm.Member_Gender = sdr["Member_Gender"].ToString();
                rm.Member_DOB = Convert.ToDateTime(sdr["Member_DOB"]).ToShortDateString();
                rm_list.Add(rm);
            }

            sdr.Close();
            return (rm_list);
        }
    }


    public class Report2Model
    {
        public string Member_ID { get; set; }
        public string Book_Acc_Code { get; set; }
        public string Borrow_Date { get; set; }
        public string Due_Date { get; set; }
        public string Return_Date { get; set; }
        public string Fine_Charge { get; set; }


        public static List<Report2Model> get_report_data()
        {
            List<Report2Model> rm_list = new List<Report2Model>();

            SqlCommand sc = new SqlCommand("get_borrow_return", Connections.GetConnection());
            sc.CommandType = CommandType.StoredProcedure;

            SqlDataReader sdr = sc.ExecuteReader();

            while (sdr.Read())
            {
                Report2Model rm = new Report2Model();
                rm.Member_ID = sdr["Member_FirstName"].ToString();
                rm.Book_Acc_Code = sdr["Book_Acc_Code"].ToString();
                rm.Borrow_Date = Convert.ToDateTime(sdr["Borrow_Date"]).ToShortDateString();
                rm.Due_Date = Convert.ToDateTime(sdr["Due_Date"]).ToShortDateString();
                if (sdr["Return_Date"].ToString() == "")
                {
                    rm.Return_Date = "";
                }
                else
                rm.Return_Date = Convert.ToDateTime(sdr["Return_Date"]).ToShortDateString();
                rm.Fine_Charge = sdr["Fine_Charge"].ToString();
                rm_list.Add(rm);
            }

            sdr.Close();
            return (rm_list);
        }
    }
}