using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LordGlobal.Rx.Controllers
{
    public class PatientController : Controller
    {
        //
        // GET: /Patient/

        [HttpGet]
        public ActionResult PatientDetails()
        {
            return View();
        }

    }
}
