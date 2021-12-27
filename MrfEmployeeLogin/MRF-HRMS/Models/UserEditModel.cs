using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRF_HRMS.Models
{
    public class UserEditModel
    {
        public int ID { get; set; }

        public string PositionName { get; set; }
        public string CreatedByID { get; set; }
        public int VacancyFor { get; set; }
        public string Territory { get; set; }
        public int VacancyType { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime FilledBefore { get; set; }
        public string Division { get; set; }
        public int MinYear { get; set; }
        public int MaxYear { get; set; }
        public int MinCTC { get; set; }
        public int MaxCTC { get; set; }
        public string AdditionalRequirements { get; set; }
       
    }
}