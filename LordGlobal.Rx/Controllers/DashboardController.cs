using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LordGlobal.Rx.Models;
using LordGlobal.Rx.BC;

namespace LordGlobal.Rx.Controllers
{
    public class DashboardController : Controller
    {
        //
        // GET: /Dashboard/
        [HttpGet]
        public ActionResult DoctorDashboard()
        {
            #region Object Initialization
            BusinessContext _objBusiness = new BusinessContext();
            DashboardModel dashboard = (DashboardModel)TempData["DoctorData"];
            #endregion

            dashboard.Mail = _objBusiness.LoadMailData(dashboard.loginProfile.UserId);
            dashboard.Task = _objBusiness.LoadTaskData(dashboard.loginProfile.UserId);
            dashboard.Notification = _objBusiness.LoadNotificationData(dashboard.loginProfile.UserId);


            return View(dashboard);
        }

    }
}
