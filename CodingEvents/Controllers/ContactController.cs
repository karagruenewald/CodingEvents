using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CodingEvents.Data;
using CodingEvents.Models;
using CodingEvents.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodingEvents.Controllers
{
    public class ContactController : Controller
    {
        private EventDbContext context;
        private readonly IWebHostEnvironment webHostEnvironment;  // allows us to store images in our wwwroot folder

        public  ContactController(EventDbContext dbContext, IWebHostEnvironment hostEnvironment)
        {
            context = dbContext;
            webHostEnvironment = hostEnvironment;
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
                string uniqueFileName = UploadedFile(addContactViewModel);

                Contact newContact = new Contact
                {
                    Name = addContactViewModel.FirstName + " " + addContactViewModel.LastName,
                    Email = addContactViewModel.Email,
                    PhoneNumber = addContactViewModel.PhoneNumber,
                    City = addContactViewModel.City,
                    ProfilePicture = uniqueFileName
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


        //helper function for photos, just used here in the controller so it's private
        private string UploadedFile(AddContactViewModel model)
        {
            string uniqueFileName = null;

            if(model.ProfileImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfileImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProfileImage.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
    }
}
