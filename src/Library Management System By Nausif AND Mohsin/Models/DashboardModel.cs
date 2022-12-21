using MVCLOGIN.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Library_Management_System_By_Nausif_AND_Mohsin.Models
{
    public class DashboardModel
    {
        public int total_count { get; set; }

        public int get_todayissue()
        {
            SqlCommand sq_com = new SqlCommand("get_todayissue", Connections.GetConnection());
            sq_com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(sq_com);

            DataTable dt = new DataTable();
             sda.Fill(dt);
             if (dt.Rows.Count > 0)
             {
                total_count = Convert.ToInt32(dt.Rows[0][0]);
             }
            return total_count;
        }

        public int get_todayreturn()
        {
            SqlCommand sq_com = new SqlCommand("get_todaysreturn", Connections.GetConnection());
            sq_com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(sq_com);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                total_count = Convert.ToInt32(dt.Rows[0][0]);
            }
            return total_count;
        }

        public int get_todaymember()
        {
            SqlCommand sq_com = new SqlCommand("get_todaysmember", Connections.GetConnection());
            sq_com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(sq_com);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                total_count = Convert.ToInt32(dt.Rows[0][0]);
            }
            return total_count;
        }

    }
}