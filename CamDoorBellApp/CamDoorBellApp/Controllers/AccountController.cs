using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;
using static CamDoorBellApp.Models.UserModels;

namespace CamDoorBellApp.Controllers
{
    public class UserController : ApiController
    {
        private bool isAuthorize = false;
        public HttpResponseMessage Get()
        {
            if(IsAuthorized())
            {
                string query = @"
                    select UserId, Email, Password, PhoneNumber, UserRole from
                    dbo.Users
                    ";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["DoorBellAlarmSystemDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return Request.CreateResponse(HttpStatusCode.OK, table);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            
        }
        [Route("api/User/Login")]
        public string Post(LoginUserModel LoginUserModel)
        {
            try
            {
                string query = @"
                    select Email, Password, PhoneNumber, UserRole from
                    dbo.Users
                    where Email = '" + LoginUserModel.UserId + @"' and
                    Password = '" + LoginUserModel.Password + @"'
                    ";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["DoorBellAlarmSystemDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                FormsAuthentication.SetAuthCookie(LoginUserModel.Email, true);
                isAuthorize = true;
                return "Login successfully!";
            }
            catch (Exception)
            {
                return "Failed to login!";
            }
        }
        [Route("api/User/Register")]
        public string Post(RegisterUserModel RegisterModel)
        {
            try
            {
                string query = @"
                    insert into dbo.Users values
                    ('" + RegisterModel.Email + @"',
                     '" + RegisterModel.Password + @"',
                     '" + RegisterModel.PhoneNumber + @"',
                     '" + RegisterModel.UserRole + @"'
                    )";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["DoorBellAlarmSystemDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                FormsAuthentication.SetAuthCookie(RegisterModel.Email, true);
                return "Registered Successfully!";
            }
            catch (Exception)
            {
                return "Failed to Register!";
            }
        }
        [Route("api/User/ChangeData")]

        public string Put(RegisterUserModel RegisterModel)
        {
            if (IsAuthorized())
            {
                try
                {
                    string query = @"
                    update dbo.Users set 
                    Email='" + RegisterModel.Email + @"'
                    ,Password='" + RegisterModel.Password + @"'
                    ,PhoneNumber='" + RegisterModel.PhoneNumber + @"'
                    ,UserRole='" + RegisterModel.UserRole + @"'
                    where UserId=" + RegisterModel.UserId + @"
                    ";

                    DataTable table = new DataTable();
                    using (var con = new SqlConnection(ConfigurationManager.
                        ConnectionStrings["DoorBellAlarmSystemDB"].ConnectionString))
                    using (var cmd = new SqlCommand(query, con))
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.Text;
                        da.Fill(table);
                    }

                    return "User updated successfully!";
                }
                catch (Exception)
                {
                    return "Failed to update user info!";
                }
            }
            return "User is not authorized!";
        }

        public string Delete(int id)
        {
            if(IsAuthorized())
            {
                try
                {
                    string query = @"
                    delete from dbo.Users 
                    where UserId=" + id + @"
                    ";

                    DataTable table = new DataTable();
                    using (var con = new SqlConnection(ConfigurationManager.
                        ConnectionStrings["DoorBellAlarmSystemDB"].ConnectionString))
                    using (var cmd = new SqlCommand(query, con))
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.Text;
                        da.Fill(table);
                    }

                    return "Deleted Successfully!!";
                }
                catch (Exception)
                {
                    return "Failed to Delete!!";
                }
            }
            return "User is not authorized!";
        }

        public bool IsAuthorized()
        {
            return isAuthorize;
        }
    }

}
