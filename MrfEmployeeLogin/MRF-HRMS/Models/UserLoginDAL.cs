using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MRF_HRMS.Models
{
    public class UserLoginDAL
    {
        string cs = ConfigurationManager.ConnectionStrings["MrfHRMS"].ConnectionString;

        public int loginvalidate(UserLoginModel idpass)
        {

            try
            {
                int k;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("sp_loginvalidate", con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@UserID", idpass.UserID);
                    com.Parameters.AddWithValue("@UserPassword", idpass.UserPassword);
                    k = (Int32)com.ExecuteScalar();
                }
                return k;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}