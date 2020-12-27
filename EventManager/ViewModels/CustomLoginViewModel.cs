using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventManager.ViewModels
{
    public class CustomLoginViewModel
    {
        public string EmailAddress { get; set; }
        public long UserId { get; set; }
        public int RoleId { get; set; }
        public string Roles { get; set; }
        public string Password { get; set; }
        public string UserLastname { get; set; }
        public string UserFirstname { get; set; }
        public bool? IsActivated { get; set; }
       
    }
}