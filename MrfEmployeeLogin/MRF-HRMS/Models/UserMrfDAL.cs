using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MRF_HRMS.Models
{
    public class UserMrfDAL
    {
        string cs = ConfigurationManager.ConnectionStrings["MrfHRMS"].ConnectionString;

        public List<UserMrfModel> ListAll()
        {
            List<UserMrfModel> bdl = new List<UserMrfModel>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("sp_select", con);
                com.CommandType = CommandType.StoredProcedure;
              
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    bdl.Add(new UserMrfModel
                    {
                        ID = Convert.ToInt32(rdr["ID"]),
                        CreatedByID = Convert.ToString(rdr["CreatedByName"]),
                        PositionName = Convert.ToString(rdr["PositionName"]),
                        VacancyFor = Convert.ToString(rdr["VacancyForName"]),
                        Territory = Convert.ToString(rdr["Territory"])
                    });
                }
                return bdl;
            }
        }


        public List<UserEditModel> ListAllProp()
        {
            List<UserEditModel> bdl = new List<UserEditModel>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("sp_select", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    bdl.Add(new UserEditModel
                    {
                        ID = Convert.ToInt32(rdr["ID"]),
                        CreatedByID = Convert.ToString(rdr["CreatedByID"]),                        
                        PositionName = Convert.ToString(rdr["PositionName"]),
                        VacancyFor = Convert.ToInt32(rdr["VacancyForID"]),
                        Territory = Convert.ToString(rdr["Territory"]),
                        Division = Convert.ToString(rdr["Division"]),
                        FilledBefore = Convert.ToDateTime(rdr["FilledBefore"]),
                        CreatedDate = Convert.ToDateTime(rdr["CreatedDate"]),
                        AdditionalRequirements = Convert.ToString(rdr["AdditionalRequirements"]),
                        VacancyType = Convert.ToInt32(rdr["VacancyTypeID"]),
                        MinYear = Convert.ToInt32(rdr["MinYear"]),
                        MaxYear = Convert.ToInt32(rdr["MaxYear"]),
                        MinCTC = Convert.ToInt32(rdr["MinCTC"]),
                        MaxCTC = Convert.ToInt32(rdr["MaxCTC"])
                    });
                }
                return bdl;
            }
        }


        public int Update(UserEditModel bdm, int ID)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("sp_Insert", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ID", ID);
                com.Parameters.AddWithValue("@PositionName", bdm.PositionName);
                com.Parameters.AddWithValue("@CreatedByID", bdm.CreatedByID);
                com.Parameters.AddWithValue("@CreatedDate", bdm.CreatedDate);
                com.Parameters.AddWithValue("@FilledBefore", bdm.FilledBefore);
                com.Parameters.AddWithValue("@VacancyForID", bdm.VacancyFor);
                com.Parameters.AddWithValue("@VacancyTypeID", bdm.VacancyType);
                com.Parameters.AddWithValue("@Territory", bdm.Territory);
                com.Parameters.AddWithValue("@Division", bdm.Division);
                com.Parameters.AddWithValue("@MinYear", bdm.MinYear);
                com.Parameters.AddWithValue("@MaxYear", bdm.MaxYear);
                com.Parameters.AddWithValue("@MinCTC", bdm.MinCTC);
                com.Parameters.AddWithValue("@MaxCTC", bdm.MaxCTC);
                com.Parameters.AddWithValue("@AdditionalRequirements", bdm.AdditionalRequirements);
                i = com.ExecuteNonQuery();
            }
            return i;
        }

        public int Delete(int ID)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("sp_Delete", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ID", ID);
                i = com.ExecuteNonQuery();
            }
            return i;
        }






    }
}