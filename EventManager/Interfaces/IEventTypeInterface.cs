using EventManager.Models;
using EventManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManager.Interfaces
{
    public interface IEventTypeInterface
    {
        Task<bool> DeleteEventType(int id);
        Task<bool> UpdateEventTypeDetails(EventTypeViewModel eventType);
        Task<EventType> AddEventType(EventTypeViewModel eventType);
        List<EventTypeViewModel> GetEventTypeList();
        EventTypeViewModel GetEventTypeByName(string name);
        void Save();
    }
}
