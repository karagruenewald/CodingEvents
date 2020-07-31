using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CodingEvents.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CodingEvents.ViewModels
{
    public class AddEventViewModel
    {
        //this is the data we want the user to fill out on the form, this provides a level of validation


        [Required(ErrorMessage ="Name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage ="Name must be between 3 and 50 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Please enter a description for your event.")]
        [StringLength(500, ErrorMessage ="Description must be less than 500 characters.")]
        public string Description { get; set; }


        [Required(ErrorMessage ="Location is required")]
        [Display(Name = "Event's Location")]
        public string Location { get; set; }


        [Range(0,100000, ErrorMessage ="Number must be between 0 and 100,000.")]
        [Display(Name="Number of Attendees")]
        public int NumOfAttendees { get; set; }



      

        [Required(ErrorMessage = "Category is required.")]
        public int CategoryId { get; set; }
        public List<SelectListItem> Categories { get; set; }


        public int ContactId { get; set; }
        public List<SelectListItem> Contacts { get; set; }


        //allows us to have select drop down menu in the form able to display all categories
        public AddEventViewModel(List<EventCategory> categories, List<Contact> contacts)
        {
            Categories = new List<SelectListItem>();

            foreach (var category in categories)
            {
                Categories.Add(new SelectListItem
                {
                    //for drop down menu, goes in html input tags
                    Value = category.Id.ToString(),
                    Text = category.Name
                });
            }

            Contacts = new List<SelectListItem>();

            foreach(var contact in contacts)
            {
                Contacts.Add(new SelectListItem
                {
                    Value = contact.Id.ToString(),
                    Text = contact.Name

                });
            }

        }

        //needed for model binding
        public AddEventViewModel ()
        {

        }
    }
}
