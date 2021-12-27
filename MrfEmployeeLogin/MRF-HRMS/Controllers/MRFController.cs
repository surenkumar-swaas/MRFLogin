using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MRF_HRMS.Models;

namespace MRF_HRMS.Controllers
{
    public class MRFController : Controller
    {
        
        MRFDal mrfdal = new MRFDal();
        // GET: MRF
        public ActionResult mrfmainscreen()
        {
            return View();
        }

        public JsonResult Add(MRFModel ad)
        {
            return Json(mrfdal.Add(ad), JsonRequestBehavior.AllowGet);
        }
    }
}