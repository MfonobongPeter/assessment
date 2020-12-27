using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventManager.ViewModels
{
    public class EventBookingViewModel
    {
        public long BookingId { get; set; }
        public long? EventId { get; set; }

        [Required(ErrorMessage = "Enter Email!")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Enter Phone Number!")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }
}