using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LordGlobal.Rx.Models;

namespace LordGlobal.Rx
{
    public enum LoginStatus { Active, Deactive };
    public enum UserRole { Admin, Doctor, Receptionist };
    public enum Mail { Pending, Delivered, Read, Delete };
    public enum Gender { Male, Female };
    public static class Common
    {
        public static void MapFirstMiddleLastName(LoginProfile loginProfile)
        {
            string[] words = loginProfile.FullName.Split(' ');
            loginProfile.FirstName = words[0];
            if (words.Length == 2)
            {
                loginProfile.LastName = words[1];
            }
            else if (words.Length == 3)
            {
                loginProfile.MiddleName = words[1];
                loginProfile.LastName = words[2];
            }
        }
    }
}