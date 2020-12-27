using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventManager.ViewModels
{
    public class EventUsersViewModel
    {
        public long UserId { get; set; }

        [Required(ErrorMessage = "Enter Firstname!")]
        [Display(Name = "Firstname")]
        public string UserFirstName { get; set; }

        [Required(ErrorMessage = "Enter Lastname!")]
        [Display(Name = "Lastname")]
        public string UserLastName { get; set; }

        [DataType(DataType.MultilineText)]
        [MaxLength(1500)]
        [Display(Name = "Address")]
        public string UserAddress { get; set; }

        [Required(ErrorMessage = "Enter Email!")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Enter password")]
        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Enter Confirm password")]
        [CompareAttribute("PasswordHash", ErrorMessage = "Passwords don't match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Role")]
        [Required(ErrorMessage = "Select Role")]
        public int RoleId { get; set; }

        public string Role { get; set; }
        public string Status { get; set; }
        public string CreatedOn { get; set; }
    }
}