using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LordGlobal.Rx.Models;
using LordGlobal.Rx.BC;

namespace LordGlobal.Rx.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        #region Object Initialization
        BusinessContext _objBusiness = new BusinessContext();
        #endregion

        [HttpGet]
        public ActionResult LoginPage()
        {          
            return View(new Login());
        }

        [HttpPost]
        public ActionResult LoginPage(Login loginData)
        {
            bool isLoginSuccess = false;
            DashboardModel model = new DashboardModel();
            LoginProfile profileData=null;

            //if Valid login data then proceed to check for authentication.
            if (ModelState.IsValid)
            {
                isLoginSuccess = _objBusiness.GetLoginDetails(loginData);
                //if Authentication is successful
                if (isLoginSuccess)
                {
                    // If user is Active
                    if(loginData.Status.Equals(LoginStatus.Active.ToString()))
                    {
                        model.loginProfile=_objBusiness.LoadUserProfile(loginData.UserRole, loginData.UserId);
                        TempData["DoctorData"] = model;
                        Session["userId"] = loginData.UserId;
                        if (model.loginProfile != null)
                        {
                            
                            //if user role is doctor thenshow doctor's dashboard
                            if (loginData.UserRole.Equals(UserRole.Doctor.ToString()))
                            {
                                return RedirectToAction("DoctorDashboard", "Dashboard");
                             
                            }
                            //if user role is Admin then show Admin's dashboard
                            else if (loginData.UserRole.Equals(UserRole.Admin.ToString()))
                            {

                            }
                            //if user role is receptionist then show receptionist's dashboard
                            else if (loginData.UserRole.Equals(UserRole.Receptionist.ToString()))
                            {

                            }
                        }
                            //If new user then redirect to registration page
                        else
                        {

                        }
                    }
                    
                    
                }
                // if Authentication failed
                else
                {
                    ViewBag.errMsg = "Invalid Credentials. Please try with correct credentials.";
                    return View(loginData);
                }
                return View();
            }
            //if invalid data then redirect to login page
            else
            {
                return View(loginData);
            }            
        }

    }
}
