using EventManager.Models;
using EventManager.Repositories;
using EventManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventManager.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EventTypeController : Controller
    {
        GenericRepository<EventType> genericRep = null;
        EventTypeRepository eventTypeRepo = null;

        public EventTypeController()
        {
            try
            {
                genericRep = new GenericRepository<EventType>();
                eventTypeRepo = new EventTypeRepository();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult AddEventType()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEventType(EventTypeViewModel etv)
        {
            try
            {
                var getbyName = eventTypeRepo.GetEventTypeByName(etv.EventTypeName);
                if (getbyName == null)
                {
                    var saveEventType = new EventType
                    {
                        EventTypeName = etv.EventTypeName,
                    };
                    genericRep.Insert(saveEventType);
                    genericRep.Save();

                    ViewBag.DisplayMessage = "success";
                    ModelState.AddModelError("", "Event type saved successfully!");
                }
                else
                {
                    ViewBag.DisplayMessage = "Info";
                    ModelState.AddModelError("", "Event type name already exist!");
                }
            }
            catch (Exception ex)
            {
                ViewBag.DisplayMessage = "Info";
                ModelState.AddModelError("", "An error occur, event type name not added!" + ex.Message);
            }

            return View();
        }

        public ActionResult EditEventType(EventType evnTp, int id)
        {
            try
            {
                var eventTypeId = Convert.ToInt32(id);
                var saveEventType = new EventType
                {
                    EventTypeName = evnTp.EventTypeName,
                    EventTypeId = eventTypeId
                };
                genericRep.Update(saveEventType);
                genericRep.Save();
                ViewBag.DisplayMessage = "success";
                ModelState.AddModelError("", "Event type updated successfully!");

            }
            catch (Exception ex)
            {
                ViewBag.DisplayMessage = "Info";
                ModelState.AddModelError("", "An error occur, event type name not added!" + ex.Message);
            }
            return View();
        }

        public ActionResult DeleteEventType(int id)
        {
            try
            {
                genericRep.Delete(id);
                genericRep.Save();
                ViewBag.DisplayMessage = "success";
                ModelState.AddModelError("", "Event type deleted successfully!");
            }
            catch (Exception ex)
            {
                ViewBag.DisplayMessage = "Info";
                ModelState.AddModelError("", "An error occur, event type name not added!" + ex.Message);
            }
            return View();
        }

        public ActionResult EventTypeList()
        {
            var getList = genericRep.SelectAll();
            return View(getList);
        }
    }
}