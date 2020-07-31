using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEvents.Data;
using CodingEvents.Models;
using CodingEvents.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodingEvents.Controllers
{
    [Authorize]
    public class EventsController : Controller
    {
        private EventDbContext context;

        private readonly UserManager<IdentityUser> _userManager;

        //must set this constructor to use EventsDbContext
        public EventsController(EventDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            context = dbContext;
            _userManager = userManager;
        }


        // GET: /<controller>/
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {

            var userId = _userManager.GetUserId(User);

            // lambda syntax, must grab the categories from category database, by default EF does lazy loading, only loading just the Events table
            List<Event> events = context.Events
                .Include(e => e.Category)
                .Include(e => e.Contact)
                .Where(e => e.UserId== userId)
                .ToList();
            return View(events);
        }

        [HttpGet]
        public IActionResult Add()
        {
            List<EventCategory> categories = context.EventCategories.ToList();
            List<Contact> contacts = context.Contacts.ToList();
            //becomes representation of what the user is putting into the form
            AddEventViewModel addEventView = new AddEventViewModel(categories, contacts);

            return View(addEventView);
        }

        [HttpPost]
        [Route("/events/add")]
        public IActionResult Add(AddEventViewModel addEventViewModel)
        {
            //translating from ViewModel object to business logic Event object

            if(ModelState.IsValid)
            {

                //grabbing user id
                var userId = _userManager.GetUserId(User);


                //have to grab the CategoryId to assign to Category
                EventCategory category = context.EventCategories.Find(addEventViewModel.CategoryId);
                Contact contact = context.Contacts.Find(addEventViewModel.ContactId);

                Event newEvent = new Event
                {
                    Name = addEventViewModel.Name,
                    Description = addEventViewModel.Description,
                    Location = addEventViewModel.Location,
                    NumOfAttendees = addEventViewModel.NumOfAttendees,
                    Category = category,
                    Contact = contact,
                    UserId = userId

                }; //this allows us to directly set the properties we want, still calls the default constructor of Event class

                

                context.Events.Add(newEvent);
                context.SaveChanges();


                return Redirect("/events");

            }

            return View(addEventViewModel); //this is so the form rerenders nonvalid form back to user

            
        }

        public IActionResult Delete ()
        {
            //ViewBag.events = EventData.GetAll();
            ViewBag.events = context.Events.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach(int id in eventIds)
            {
                //EventData.Remove(id);
                Event e = context.Events.Find(id);
                context.Events.Remove(e);
            }

            context.SaveChanges();

            return Redirect("/Events");
        }

        [Route("/Events/Edit/{eventId}")]
        public IActionResult Edit (int eventId)
        {

            Event evt = context.Events.Find(eventId);

            //allows us to grab the values of the event we're trying to edit
            ViewBag.events = evt;
            ViewBag.title = "Edit Event: " + ViewBag.events.Name + "(id=" + ViewBag.events.Id + ")";
            return View();
        }

        [HttpPost]
        [Route("/Events/Edit")]
        public IActionResult SubmitEditEvenForm(int eventId, string name, string description)
        {
            
            Event updated = context.Events.Find(eventId);
            updated.Name = name;
            updated.Description = description;
            
            //because it grabbed the specific object, it will update the object values

            context.SaveChanges();


            return Redirect("/Events");
        }

        public IActionResult Detail (int id)
        {
            Event theEvent = context.Events
                .Include(e => e.Category)
                .Single(e => e.Id == id);


            List<EventTag> eventTags = context.EventTags
                .Where(et => et.EventId == id)
                .Include(et => et.Tag)
                .ToList();

            EventDetailViewModel viewModel = new EventDetailViewModel(theEvent, eventTags);
            return View(viewModel);
        }
    }
}
