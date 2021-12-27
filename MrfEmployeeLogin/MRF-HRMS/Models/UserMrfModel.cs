using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRF_HRMS.Models
{
    public class UserMrfModel
    {
        public int ID { get; set; }
        public string PositionName { get; set; }
        public string CreatedByID { get; set; }
        public string VacancyFor { get; set; }
        public string Territory { get; set; }

    }
}