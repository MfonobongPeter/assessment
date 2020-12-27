using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventManager.ViewModels
{
    public class EventTypeViewModel
    {
        public int EventTypeId { get; set; }

        [Required(ErrorMessage = "Enter Event type name!")]
        [Display(Name = "Event Type")]
        public string EventTypeName { get; set; }
    }
}