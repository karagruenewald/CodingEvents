using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEvents.Data;
using CodingEvents.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {

            ViewBag.events = EventData.GetAll();
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("/events/add")]
        public IActionResult NewEvent(Event newEvent)
        {
            EventData.Add(newEvent);
            return Redirect("/events");
        }

        public IActionResult Delete ()
        {
            ViewBag.events = EventData.GetAll();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach(int id in eventIds)
            {
                EventData.Remove(id);
            }

            return Redirect("/Events");
        }

        [Route("/Events/Edit/{eventId}")]
        public IActionResult Edit (int eventId)
        {
            //allows us to grab the values of the event we're trying to edit
            ViewBag.events = EventData.GetById(eventId);
            ViewBag.title = "Edit Event: " + ViewBag.events.Name + "(id=" + ViewBag.events.Id + ")";
            return View();
        }

        [HttpPost]
        [Route("/Events/Edit")]
        public IActionResult SubmitEditEvenForm(int eventId, string name, string description)
        {
            
            Event updated = EventData.GetById(eventId);
            updated.Name = name;
            updated.Description = description;
            //because it grabbed the specific object, it will update the object values


            return Redirect("/Events");
        }
    }
}
