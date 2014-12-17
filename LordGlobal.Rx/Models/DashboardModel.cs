using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LordGlobal.Rx.Models
{
    public class DashboardModel
    {
        public List<MailData> Mail { get; set; }
        public List<TaskData> Task { get; set; }
        public List<NotificationData> Notification { get; set; }
        public int? TotalPatientCountForDoctor { get; set; }
        public DateTime MemberCreationDateTime { get; set; }
        public LoginProfile loginProfile { get; set; }
        public string UserRole { get; set; }
        public int? TotalPatientCount { get; set; }
    }

    public enum notificationStatus { Unread, Read }
    public class NotificationData
    {
        public long UserId { get; set; }
        public DateTime NotificationDate { get; set; }
        public string Status { get; set; }
        public string Heading { get; set; }
        public string Description { get; set; }
    }
    public class MailData
    {
        #region MailBoxNotification
        public long From { get; set; }
        public string FromName { get; set; }
        public long To { get; set; }
        public DateTime SentDtm { get; set; }
        public string Message { get; set; }
        public string status { get; set; }
        public byte Photo { get; set; }
        #endregion
    }

    public enum taskStatus { Pending, Completed }
    public class TaskData
    {
        public long UserId { get; set; }
        public DateTime TaskDate { get; set; }
        public string Heading { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
    }

    public class LoginProfile
    {
        #region LoginData
        public long UserId { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string emailId { get; set; }
        public string RegNo { get; set; }
        public string Specialist { get; set; }
        public int Age { get; set; }
        public string ClinicAddress { get; set; }
        public string ClinicName { get; set; }
        public long PhoneNumber { get; set; }
        public long landline { get; set; }
        public string City { get; set; }
        public int Pincode { get; set; }
        public string Gender { get; set; }
        public long DoctorId { get; set; }
        public string Qualification { get; set; }
        public byte[] image { get; set; }
        #endregion
    }
}