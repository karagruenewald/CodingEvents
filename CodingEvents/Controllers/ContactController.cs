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
    public class ContactController : Controller
    {
        private EventDbContext context;

        public  ContactController(EventDbContext dbContext)
        {
            context = dbContext;
        }


        // GET: /Contact/Index
        public IActionResult Index()
        {
            List<Contact> contacts = context.Contacts.ToList();
            return View(contacts);
        }


        //GET: /Contact/Add
        [HttpGet]
        public IActionResult Add()
        {
            AddContactViewModel viewModel = new AddContactViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Add(AddContactViewModel addContactViewModel)
        {

            if (ModelState.IsValid)
            {
                Contact newContact = new Contact
                {
                    Name = addContactViewModel.FirstName + " " + addContactViewModel.LastName,
                    Email = addContactViewModel.Email,
                    PhoneNumber = addContactViewModel.PhoneNumber,
                    City = addContactViewModel.City
                };

                context.Contacts.Add(newContact);
                context.SaveChanges();
                return Redirect("/Contact");
            }

            return View(addContactViewModel);

        }


        // GET: /Contact/View/{id}
        public IActionResult View (int id)
        {
            Contact theContact = context.Contacts.Find(id);

            ContactDetailViewModel viewModel = new ContactDetailViewModel(theContact);

            return View(viewModel);
        }
    }
}
