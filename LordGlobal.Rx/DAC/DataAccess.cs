using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using LordGlobal.Rx.DAC;
using LordGlobal.Rx.DAC.Query;
using LordGlobal.Rx.Models;

namespace LordGlobal.Rx
{
    public class DataAccess
    {
        #region variables
        BaseDac baseDac = new BaseDac();
        #endregion

        #region Connections
        public MySqlConnection con = null;
        public MySqlCommand cmd = null;
        #endregion

        #region constructor
        /// <summary>
        /// DataAccess- This method is used to initialize the database connection object.
        /// </summary>
        public DataAccess()
        {
            con = baseDac.GetConnection();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// GetLoginDetails - This method is used to get the login details
        /// </summary>
        /// <param name="loginData">loginData</param>
        /// <returns>true/false</returns>
        public bool GetLoginDetails(Login loginDetails)
        {
            bool isSuccess = false;
            string query = Query.GET_LOGIN_DETAILS.ToString();

            try
            {
                con.Open();
                using (cmd = baseDac.getCommand(query, con))
                {
                    cmd.Parameters.Add("userName", MySqlDbType.String).Value = loginDetails.UserName;
                    var data = cmd.ExecuteReader();
                    if (data.Read())
                    {
                        //if user name and pasword are valid then fetch all the details from the database table
                        if (data["user_name"].ToString().ToUpper().Equals(loginDetails.UserName.ToUpper()) && data["password"].Equals(loginDetails.Password))
                        {
                            loginDetails.UserId = Convert.ToInt64(data["user_id"]);
                            loginDetails.UserRole = Convert.ToString(data["user_role"]);
                            loginDetails.LastLoginDateTime = Convert.ToDateTime(data["last_login_dt_tm"]);
                            loginDetails.MemberCreationDateTime = Convert.ToDateTime(data["member_creation_dt_tm"]);
                            loginDetails.Status = Convert.ToString(data["status"]);
                            isSuccess = true;                            
                        }
                    }
                    data.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("RX00001: Process failed while retrieving data from database.:", ex);
            }
            finally
            {
                con.Close();
            }
            return isSuccess;
        }

        public LoginProfile LoadDoctorProfile(long userId)
        {
            LoginProfile profileData=null;
            string query = Query.GET_DOCTOR_PROFILE_DETAILS.ToString();
            try
            {
                con.Open();
                using(cmd=baseDac.getCommand(query,con))
                {
                    cmd.Parameters.Add("userId", MySqlDbType.Int64).Value = userId;
                    var data=cmd.ExecuteReader();
                    if (data.Read())
                    {
                           profileData= new LoginProfile();
                           profileData.UserId = userId;
                           profileData.FullName = data["doctor_name"].ToString();
                           Common.MapFirstMiddleLastName(profileData);
                           profileData.RegNo = data["permanent_registration_number"].ToString();
                           profileData.emailId = data["email_id"].ToString();
                           profileData.Specialist = data["specialist"].ToString();
                           profileData.Qualification = data["qualification"].ToString();
                           profileData.Age = Convert.ToInt32(data["age"]);
                           profileData.ClinicAddress = data["clinic_address"].ToString();
                           profileData.ClinicName = data["clinic_name"].ToString();
                           profileData.PhoneNumber = Convert.ToInt64(data["phone_number"]);
                           profileData.landline = Convert.ToInt64(data["landline"]);
                           profileData.City = data["city"].ToString();
                           profileData.Gender = Convert.ToString(data["gender"]);
                           profileData.Pincode = Convert.ToInt32(data["pincode"]);
                           profileData.image = data["photo"] as byte[] ?? null;                       
                    }
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("RX00001: Process failed while retrieving data from database.:", ex);
            }
            finally
            {
                con.Close();
            }
            return profileData;
        }

        public List<MailData> LoadMailData(long userId)
        {
            List<MailData> mailData = new List<MailData>();
            MailData mail;
            string sqlQuery = Query.GET_MAIL_DETAILS.ToString();
            try
            {
                con.Open();
                using (cmd = baseDac.getCommand(sqlQuery,con))
                {
                    cmd.Parameters.Add("userId", MySqlDbType.Int64).Value = userId;
                    var data = cmd.ExecuteReader();
                    while (data.Read())
                    {
                        mail = new MailData();
                         mail.From = Convert.ToInt64(data["mail_from"]);
                        mail.To = userId;
                        mail.Message = data["message"].ToString();
                        mail.status = data["status"].ToString();
                        mail.FromName = data["from_name"].ToString();
                        mailData.Add(mail);                            
                    }
                    data.Close();
                }


            }
            catch (Exception exception)
            {
                throw new Exception("RX00001: Process failed while retrieving data from database.:", exception);
            }
            finally
            {
                con.Close();
            }
            return mailData;
        }


        public List<TaskData> LoadTaskData(long userId)
        {
            List<TaskData> taskData = new List<TaskData>();
            TaskData task = null;
            string sqlQuery = Query.GET_TASK_DETAILS.ToString();

            try
            {
                con.Open();
                using (cmd = baseDac.getCommand(sqlQuery, con))
                {
                    cmd.Parameters.Add("userID", MySqlDbType.UInt64).Value = userId;
                    var data = cmd.ExecuteReader();
                    while (data.Read())
                    {
                        task = new TaskData();
                        task.Description = data["description"].ToString();
                        task.Heading = data["heading"].ToString();
                        task.Status = data["status"].ToString();
                        task.TaskDate = Convert.ToDateTime(data["task_dt"]);
                        task.UserId = userId;
                        taskData.Add(task);                            
                    }
                    data.Close();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("RX00001: Process failed while retrieving data from database.:", ex);
            }
            finally
            {
                con.Close();
            }

            return taskData;
        }

        public List<NotificationData> LoadNotificationData(long userId)
        {
            
            List<NotificationData> notificationData = new List<NotificationData>();
            NotificationData notification = null;
            string sql = Query.GET_NOTIFICATION_DETAILS.ToString();
            try
            {
                con.Open();
                using (cmd = baseDac.getCommand(sql, con))
                {
                    cmd.Parameters.Add("userId", MySqlDbType.Int64).Value = userId;
                    var data = cmd.ExecuteReader();
                    while (data.Read())
                    {
                        notification = new NotificationData();


                        notification.Description = data["description"].ToString();
                        notification.Heading = data["heading"].ToString();
                        notification.Status = data["status"].ToString();
                        notification.NotificationDate = Convert.ToDateTime(data["notification_dt"]);
                        notification.UserId = userId;
                        notificationData.Add(notification);

                    }
                    data.Close();
                }
            }
            catch (System.Exception ex)
            {
                throw new Exception("RX00001: Process failed while retrieving data from database.:", ex);
            }
            finally
            {
                con.Close();
            }
            
            return notificationData;
        }


         #endregion
    }
}