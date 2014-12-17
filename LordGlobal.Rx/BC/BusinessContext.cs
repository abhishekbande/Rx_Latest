using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LordGlobal.Rx.Models;

namespace LordGlobal.Rx.BC
{
    public class BusinessContext
    {
        #region Object Initialization
        DataAccess _objDac = new DataAccess();
        #endregion


        #region GetLoginDetails
        public bool GetLoginDetails(Login loginDetails)
        {            
            return _objDac.GetLoginDetails(loginDetails);
        }
        #endregion

        public LoginProfile LoadUserProfile(string userRole,long userId)
        {
            if (userRole.Equals(UserRole.Doctor.ToString()))
            {
                return _objDac.LoadDoctorProfile(userId);
            }
            else if (userRole.Equals(UserRole.Admin.ToString()))
            {
                return null;
            }
            else if (userRole.Equals(UserRole.Receptionist.ToString()))
            {
                return null;
            }

            return null;

        }

    }
}