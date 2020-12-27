using EventManager.Models;
using EventManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManager.Interfaces
{
    public interface IEventBookingInterface
    {
        Task<EventBooking> AddEventBooking(EventBookingViewModel events, int eventId);
        EventBooking ValidateBooking(string email, long? eventId);
    }
}
