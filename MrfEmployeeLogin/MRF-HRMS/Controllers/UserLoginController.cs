using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MRF_HRMS.Models;

namespace MRF_HRMS.Controllers
{
    public class UserLoginController : Controller
    {

        UserLoginDAL uldal = new UserLoginDAL(); 
        // GET: UserLogin
        public ActionResult UserUILogin()
        {
            return View();
        }

        public JsonResult loginvalidate(UserLoginModel idpass)
        {
            
            Session["UserID"]= idpass.UserID;
            return Json(uldal.loginvalidate(idpass), JsonRequestBehavior.AllowGet);
        }
    }
}