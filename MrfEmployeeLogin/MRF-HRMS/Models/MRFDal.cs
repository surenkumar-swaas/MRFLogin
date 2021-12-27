using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MRF_HRMS.Models
{
    public class MRFDal
    {
        string cs = ConfigurationManager.ConnectionStrings["MrfHRMS"].ConnectionString;

        public int Add(MRFModel ad)
        {
            try
            {
                int i;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("sp_Add", con);
                    com.CommandType = CommandType.StoredProcedure;

                    com.Parameters.AddWithValue("@PositionName", ad.PositionName);
                    com.Parameters.AddWithValue("@CreatedByID", ad.CreatedByID);
                    com.Parameters.AddWithValue("@CreatedDate", ad.CreatedDate);
                    com.Parameters.AddWithValue("@FilledBefore", ad.FilledBefore);
                    com.Parameters.AddWithValue("@VacancyForID", ad.VacancyForID);
                    com.Parameters.AddWithValue("@VacancyTypeID", ad.VacancyTypeID);
                    com.Parameters.AddWithValue("@Territory", ad.Territory);
                    com.Parameters.AddWithValue("@Division", ad.Division);
                    com.Parameters.AddWithValue("@MinYear", ad.MinYear);
                    com.Parameters.AddWithValue("@MaxYear", ad.MaxYear);
                    com.Parameters.AddWithValue("@MinCTC", ad.MinCTC);
                    com.Parameters.AddWithValue("@MaxCTC", ad.MaxCTC);
                    com.Parameters.AddWithValue("@AdditionalRequirements", ad.AdditionalRequirements);

                    i = com.ExecuteNonQuery();
                    return i;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}