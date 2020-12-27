using EventManager.Interfaces;
using EventManager.Models;
using EventManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EventManager.Repositories
{
    public class EventTypeRepository : IEventTypeInterface, IDisposable
    {
        private EventManagerDbEntities db = null;

        public EventTypeRepository()
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

        public EventTypeRepository(EventManagerDbEntities db)
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


        public async Task<bool> DeleteEventType(int id)
        {
            bool getState = false;
            try
            {
                var remove = (from d in db.EventTypes.Where(x => x.EventTypeId == id) select d).FirstOrDefault();
                if (remove != null)
                {
                    db.EventTypes.Remove(remove);
                    await db.SaveChangesAsync();
                    getState = true;
                }
            }
            catch (Exception ex)
            {
                getState = false;
                throw ex;
            }
            return getState;
        }

        public async Task<bool> UpdateEventTypeDetails(EventTypeViewModel eventType)
        {
            bool status = false;
            var getRecord = (from r in db.EventTypes.Where(x => x.EventTypeId.Equals(eventType.EventTypeId)) select r).FirstOrDefault();
            if (getRecord != null)
            {
                try
                {
                    getRecord.EventTypeName = eventType.EventTypeName;                   
                    await db.SaveChangesAsync();
                    status = true;
                }
                catch (Exception ex)
                {
                    status = false;
                    throw ex;
                }
            }
            return status;
        }

        public async Task<EventType> AddEventType(EventTypeViewModel eventType)
        {
            EventType itemCollections = null;

            try
            {
                itemCollections = new EventType
                {
                    EventTypeName = eventType.EventTypeName,                  
                };
                db.EventTypes.Add(itemCollections);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                //log.Error(ex.Message);
                throw ex;
            }
            return itemCollections;
        }

        public List<EventTypeViewModel> GetEventTypeList()
        {
            List<EventTypeViewModel> eventTypeRecord = null;
            try
            {
                eventTypeRecord = (from eventTypeDetail in db.EventTypes
                               select new EventTypeViewModel
                               {
                                   EventTypeName = eventTypeDetail.EventTypeName
                               }).ToList();
            }
            catch (Exception ex)
            {
                //log.Error(ex.Message);
                throw ex;
            }
            return eventTypeRecord;
        }

        public EventTypeViewModel GetEventTypeByName(string name)
        {
            EventTypeViewModel eventType = null;
            try
            {
                eventType = (from n in db.EventTypes.Where(x => x.EventTypeName == name)
                        select new EventTypeViewModel
                        {
                            EventTypeName = n.EventTypeName,
                            EventTypeId = n.EventTypeId                          
                        }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return eventType;
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