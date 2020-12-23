using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CamDoorBellApp.Models
{
    public class UserModels
    {
        public class User
        {
            public int UserId { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string PhoneNumber { get; set; }
            public string UserRole { get; set; }
        }

        public class LoginUserModel
        {
            public int UserId { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }
        public class RegisterUserModel
        {
            public int UserId { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string PhoneNumber { get; set; }
            public string UserRole { get; set; }
        }
    }
}