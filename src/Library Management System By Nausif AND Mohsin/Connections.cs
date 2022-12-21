using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace MVCLOGIN.Models
{
    public class Connections
    {
        public static SqlConnection My_SQL_Connection;
        public static SqlConnection GetConnection()
        {
            if(My_SQL_Connection == null)
            {
                My_SQL_Connection = new SqlConnection();
                My_SQL_Connection.ConnectionString = ConfigurationManager.ConnectionStrings["LMS"].ToString();
                My_SQL_Connection.Open();
            }
            return My_SQL_Connection;
        }
    }
}