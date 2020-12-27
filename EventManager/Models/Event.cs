//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EventManager.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Event
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Event()
        {
            this.EventBookings = new HashSet<EventBooking>();
        }
    
        public long EventId { get; set; }
        public string EventName { get; set; }
        public string EventDesc { get; set; }
        public int EventVenueId { get; set; }
        public string EventType { get; set; }
        public Nullable<System.DateTime> EventDate { get; set; }
        public string EventTime { get; set; }
        public Nullable<decimal> EventFee { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EventBooking> EventBookings { get; set; }
        public virtual EventVenue EventVenue { get; set; }
    }
}
