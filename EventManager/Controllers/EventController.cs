using EventManager.Models;
using EventManager.Repositories;
using EventManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EventManager.Controllers
{

    public class EventController : Controller
    {
        EventRepository eventRepository = null;
        private EventManagerDbEntities db = null;
        public EventController()
        {
            try
            {
                db = new EventManagerDbEntities();
                eventRepository = new EventRepository();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult EventList(string searchItem)
        {
            List<EventViewModel> getList = null;

            if (string.IsNullOrEmpty(searchItem))
            {
                getList = eventRepository.GetEventList();
            }
            else
            {
                getList = eventRepository.GetEventList(searchItem);
            }
            return View(getList);
        }

        
        public ActionResult EventDetails(int id)
        {
            EventViewModel getEvent = null;
            try
            {
                getEvent = eventRepository.GetEventForEdit(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(getEvent);
        }

        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> DeleteEvent(long id)
        {
            try
            {
                await eventRepository.DeleteEvent(id);
                return Json(new { s = "Event deleted successfully!" });
            }
            catch (Exception ex)
            {
                return Json(new { f = ex.Message });
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AddEvent()
        {
            LoadDropDownList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> AddEvent([Bind(Include = "EventId,EventName,EventDesc, UserAddress, EventVenueId,EventDate,EventTime,EventFee, EventType")] EventViewModel events, int EventVenueId)
        {
            var getRecord = await eventRepository.AddEvent(events, events.EventVenueId);
            if (getRecord != null)
            {
                ViewBag.DisplayMessage = "success";
                ModelState.AddModelError("", "Event created successfully!");
            }
            else
            {
                ViewBag.DisplayMessage = "Info";
                ModelState.AddModelError("", "Ooops, something went wrong, event not created! kindly check your input and try again.");
            }
            LoadDropDownList();
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult EditEvent(long? id)
        {
            EventViewModel getEvent = null;
            try
            {
                getEvent = eventRepository.GetEventForEdit(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            LoadDropDownList();
            return View(getEvent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> EditEvent([Bind(Include = "EventId,EventName,EventDesc, UserAddress, EventVenueId,EventDate,EventTime,EventFee, EventType")] int id, EventViewModel events)
        {
           
            try
            {
                var getResponse = await eventRepository.UpdateEventDetails(events,id);
                if (getResponse != null)
                {
                    ViewBag.DisplayMessage = "success";
                    ModelState.AddModelError("", "Event updated successfully!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            LoadDropDownList();
            return View();
        }

        //private void LoadDropDownList()
        //{
        //    try
        //    {
        //        ViewBag.EventType = new SelectList(db.EventTypes, "EventTypeId", "EventTypeName");
        //        //ViewBag.VenueId = new SelectList(db.EventVenues, "EventVenueId", "VenueName");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}

        private void LoadDropDownList()
        {
            try
            {

                var eventVenue = (from ctg in db.EventVenues
                                  select new
                                  {
                                      ctg.VenueId,
                                      ctg.VenueName
                                  }
                ).ToList();
                var items = eventVenue.Select(t => new SelectListItem
                {
                    Text = t.VenueName,
                    Value = t.VenueId.ToString()
                }).ToList();

                ViewBag.fkEventVenueList = items;
                ViewBag.EventType = new SelectList(db.EventTypes, "EventTypeName", "EventTypeName");
            }
            catch (Exception ex)
            {
                ViewBag.DisplayMessage = "Info";
                ModelState.AddModelError("", "Error: " + ex.Message);
            }

        }
    }
}