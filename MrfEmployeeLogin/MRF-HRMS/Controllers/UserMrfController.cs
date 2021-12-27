using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MRF_HRMS.Models;

namespace MRF_HRMS.Controllers
{
    public class UserMrfController : Controller
    {
        UserMrfDAL umdal = new UserMrfDAL();
        // GET: UserMrf
        public ActionResult ViewMyMrf()
        {
            return View();
        }
        public JsonResult List()
        {
            return Json(umdal.ListAll(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListAllData()
        {
            return Json(umdal.ListAllProp(), JsonRequestBehavior.AllowGet);
        }


        public ActionResult EditUserView()
        {
            int ID = Convert.ToInt32(Request.QueryString["MrfID"]);
            var UserEdit = umdal.ListAllProp().Find(x => x.ID.Equals(ID));
            //return Json(UserEdit, JsonRequestBehavior.AllowGet);
            return View(UserEdit);
        }

        public JsonResult Update(UserEditModel bdm, int ID)
        {
            return Json(umdal.Update(bdm,ID), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int ID)
        {
            return Json(umdal.Delete(ID), JsonRequestBehavior.AllowGet);
        }


    }
}