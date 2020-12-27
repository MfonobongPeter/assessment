using EventManager.Models;
using EventManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManager.Interfaces
{
    public interface IEventInterface
    {
        List<EventViewModel> GetEventList();
        Task<Event> AddEvent(EventViewModel events, int eventVenueId);
        Task<Event> UpdateEventDetails(EventViewModel events, int eventId);
        Task<bool> DeleteEvent(long id);
        List<EventViewModel> GetEventList(string searchItem);
        EventViewModel GetEventForEdit(long? id);
        void Save();
    }
}
