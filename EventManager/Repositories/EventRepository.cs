using EventManager.Interfaces;
using EventManager.Models;
using EventManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EventManager.Repositories
{
    public class EventRepository : IEventInterface, IDisposable
    {
        private EventManagerDbEntities db = null;

        public EventRepository()
        {
            try
            {
                db = new EventManagerDbEntities();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EventRepository(EventManagerDbEntities db)
        {
            try
            {
                this.db = db;
            }
            catch (Exception ex)
            {
                //log.Error(ex.Message);
                throw ex;
            }
        }

        public List<EventViewModel> GetEventList()
        {
            List<EventViewModel> eventRecord = null;
            try
            {
                eventRecord = (from eventDetail in db.Events
                              
                              join eventVenue in db.EventVenues on eventDetail.EventVenueId equals eventVenue.VenueId
                              
                              select new EventViewModel
                              {
                                  EventId = eventDetail.EventId,
                                  EventName = eventDetail.EventName,
                                  EventDesc = eventDetail.EventDesc,
                                  EventVenue = eventVenue.VenueName,
                                  EventType = eventDetail.EventType,
                                  EventDate = eventDetail.EventDate,
                                  EventTime = eventDetail.EventTime,
                                  EventFee = eventDetail.EventFee ?? 0
                              }).ToList();
            }
            catch (Exception ex)
            {
                //log.Error(ex.Message);
                throw ex;
            }
            return eventRecord;
        }

        public List<EventViewModel> GetEventList(string searchItem)
        {
            List<EventViewModel> eventRecord = null;
            try
            {
                eventRecord = (from eventDetail in db.Events

                               join eventVenue in db.EventVenues on eventDetail.EventVenueId equals eventVenue.VenueId
                               where eventDetail.EventName.ToLower().StartsWith(searchItem) || eventDetail.EventDesc.ToLower().StartsWith(searchItem)
                               select new EventViewModel
                               {
                                   EventId = eventDetail.EventId,
                                   EventName = eventDetail.EventName,
                                   EventDesc = eventDetail.EventDesc,
                                   EventVenue = eventVenue.VenueName,
                                   EventType = eventDetail.EventType,
                                   EventDate = eventDetail.EventDate,
                                   EventTime = eventDetail.EventTime,
                                   EventFee = eventDetail.EventFee ?? 0
                               }).ToList();
            }
            catch (Exception ex)
            {
                //log.Error(ex.Message);
                throw ex;
            }
            return eventRecord;
        }

        public async Task<Event> AddEvent(EventViewModel events, int eventVenueId)
        {
            Event itemCollections = null;
            
            try
            {
                itemCollections = new Event
                {
                    EventName = events.EventName,
                    EventDesc = events.EventDesc,
                    EventVenueId = eventVenueId,
                    EventType = events.EventType,
                    EventTime = events.EventTime,
                    EventFee = events.EventFee,
                    EventDate = events.EventDate,                   
                };
                db.Events.Add(itemCollections);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                //log.Error(ex.Message);
                throw ex;
            }
            return itemCollections;
        }

        public EventViewModel GetEventForEdit(long? id)
        {
            EventViewModel eventList = null;
            try
            {
                eventList =
                                (from u in db.Events
                                 where (u.EventId == id)
                                 select new EventViewModel
                                 {
                                     EventId = u.EventId,
                                     EventName = u.EventName,
                                     EventDesc = u.EventDesc,
                                     EventVenueId = u.EventVenueId,
                                     EventType = u.EventType,
                                     EventFee = u.EventFee ?? 0,
                                     EventDate = u.EventDate,
                                     EventTime = u.EventTime
                                 }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return eventList;
        }


        public async Task<Event> UpdateEventDetails(EventViewModel events, int eventId)
        {
            
            var getRecord = (from r in db.Events.Where(x => x.EventId.Equals(eventId)) select r).FirstOrDefault();
            if (getRecord != null)
            {
                try
                {
                    getRecord.EventName = events.EventName;
                    getRecord.EventDesc = events.EventDesc;
                    getRecord.EventVenueId = events.EventVenueId;
                    getRecord.EventType = events.EventType;
                    getRecord.EventDate = events.EventDate;
                    getRecord.EventTime = events.EventTime;
                    getRecord.EventFee = events.EventFee;
                    await db.SaveChangesAsync();
                    
                }
                catch (Exception ex)
                {                  
                    throw ex;
                }
            }
            return getRecord;
        }

        public async Task<bool> DeleteEvent(long id)
        {
            bool getState = false;
            try
            {
                var remove = (from d in db.Events.Where(x => x.EventId == id) select d).FirstOrDefault();
                if (remove != null)
                {
                    db.Events.Remove(remove);
                    await db.SaveChangesAsync();
                    getState = true;
                }

                //using (EventManagerDbEntities Context = new EventManagerDbEntities())
                //{
                //    Event eventDelete = new Event { EventId = id };
                //    Context.Entry(eventDelete).State = EntityState.Deleted;
                //    await Context.SaveChangesAsync();
                //}
            }
            catch (Exception ex)
            {
                getState = false;
                throw ex;
            }
            return getState;
        }

        public void Save()
        {
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                //log.Error(ex.Message);
                throw ex;
            }
        }




        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            try
            {
                if (!disposed)
                {
                    if (disposing)
                    {
                        db.Dispose();
                    }
                }
                disposed = true;
            }
            catch (Exception ex)
            {
                //log.Error(ex.Message);
                throw ex;
            }
        }

        public void Dispose()
        {
            try
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
            catch (Exception ex)
            {
                //log.Error(ex.Message);
                throw ex;
            }
        }
    }
}