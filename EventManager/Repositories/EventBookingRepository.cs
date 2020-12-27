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
    public class EventBookingRepository : IEventBookingInterface, IDisposable
    {
        private EventManagerDbEntities db = null;

        public EventBookingRepository()
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

        public EventBookingRepository(EventManagerDbEntities db)
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

        public async Task<EventBooking> AddEventBooking(EventBookingViewModel events, int eventId)
        {
            EventBooking itemCollections = null;

            try
            {
                itemCollections = new EventBooking
                {
                    EmailAddress = events.EmailAddress,
                    PhoneNumber = events.PhoneNumber,
                    EventId = eventId,
                };
                db.EventBookings.Add(itemCollections);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                //log.Error(ex.Message);
                throw ex;
            }
            return itemCollections;
        }

        public EventBooking ValidateBooking(string email, long? eventId)
        {
            EventBooking getBookingDetail = null;
            try
            {
                getBookingDetail = (from user in db.EventBookings.Where(x => x.EmailAddress.Trim() == email.Trim() && x.EventId == eventId) select user).FirstOrDefault();
            }
            catch (Exception ex)
            {
                //log.Error(ex.Message);
            }
            return getBookingDetail;
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