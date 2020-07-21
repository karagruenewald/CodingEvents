using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEvents.Data;
using CodingEvents.Models;
using CodingEvents.ViewModels;
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

            List<Event> events = new List<Event>(EventData.GetAll());
            return View(events);
        }

        [HttpGet]
        public IActionResult Add()
        {
            //becomes representation of what the user is putting into the form
            AddEventViewModel addEventView = new AddEventViewModel();
            return View(addEventView);
        }

        [HttpPost]
        [Route("/events/add")]
        public IActionResult Add(AddEventViewModel addEventViewModel)
        {
            //translating from ViewModel object to business logic Event object

            if(ModelState.IsValid)
            {

                Event newEvent = new Event
                {
                    Name = addEventViewModel.Name,
                    Description = addEventViewModel.Description,
                    ContactEmail = addEventViewModel.ContactEmail,
                    Location = addEventViewModel.Location,
                    NumOfAttendees = addEventViewModel.NumOfAttendees

                }; //this allows us to directly set the properties we want, still calls the default constructor of Event class

                EventData.Add(newEvent);
                return Redirect("/events");

            }

            return View(addEventViewModel); //this is so the form rerenders nonvalid form back to user

            
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
        public IActionResult SubmitEditEvenForm(int eventId, string name, string description, string email)
        {
            
            Event updated = EventData.GetById(eventId);
            updated.Name = name;
            updated.Description = description;
            updated.ContactEmail = email;
            //because it grabbed the specific object, it will update the object values


            return Redirect("/Events");
        }
    }
}
