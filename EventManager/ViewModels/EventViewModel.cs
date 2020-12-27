using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventManager.ViewModels
{
    public class EventViewModel
    {
        public long EventId { get; set; }

        [Required(ErrorMessage = "Enter Event name!")]
        [Display(Name = "Event Name")]
        public string EventName { get; set; }

        [Required(ErrorMessage = "Enter Event Description!")]
        [Display(Name = "Event Desc.")]
        [DataType(DataType.MultilineText)]
        public string EventDesc { get; set; }

        [Required(ErrorMessage = "Enter Event Venue!")]
        [Display(Name = "Event Venue")]
        public int EventVenueId { get; set; }

        [Display(Name = "Event Venue")]
        public string EventVenue { get; set; }

        [Required(ErrorMessage = "Enter Event Type!")]
        [Display(Name = "Event Type")]
        public string EventType { get; set; }

        [Required(ErrorMessage = "Enter Event Date!")]
        [Display(Name = "Event Date")]
        [DataType(DataType.Date)]
        public DateTime? EventDate { get; set; }

        [Required(ErrorMessage = "Enter Event Time!")]
        [Display(Name = "Event Time")]
        [DataType(DataType.Time)]
        public string EventTime { get; set; }

        [Required(ErrorMessage = "Enter Event Fee!")]
        [Display(Name = "Event Fee")]
        public decimal? EventFee { get; set; }
    }
}