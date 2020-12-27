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
    public class HomeController : Controller
    {
        EventRepository eventRepository = null;
        public HomeController()
        {
            try
            {
                eventRepository = new EventRepository();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
        public ActionResult Index(string searchItem)
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

        [HttpPost]
        public ActionResult Index(string searchItem, int? id)
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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}