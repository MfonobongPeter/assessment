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
    public class EventBookingController : Controller
    {

        EventBookingRepository eventBookingRepo = null;        
        public EventBookingController()
        {
            try
            {             
                eventBookingRepo = new EventBookingRepository();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // GET: EventBooking
        public ActionResult Booking(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Booking([Bind(Include = "EventId,EmailAddress,PhoneNumber")] EventBookingViewModel booking, int id)
        {
            var validateBooking = eventBookingRepo.ValidateBooking(booking.EmailAddress, id);
            if (validateBooking == null)
            {
                var getRecord = await eventBookingRepo.AddEventBooking(booking, id);
                if (getRecord != null)
                {
                    ModelState.Clear();
                    ViewBag.DisplayMessage = "success";
                    ModelState.AddModelError("", "Event booked successfully!");
                }
                else
                {
                    ViewBag.DisplayMessage = "Info";
                    ModelState.AddModelError("", "Ooops, something went wrong, booking not created! kindly check your input and try again.");
                }
            }
            else
            {
                ViewBag.DisplayMessage = "Info";
                ModelState.AddModelError("", "Duplicate Booking, Event already booked for this user! ");
            }
            return View(booking);
        }
    }
}