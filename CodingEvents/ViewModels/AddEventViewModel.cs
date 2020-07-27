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


        [EmailAddress]
        [Display(Name="Contact's Email")]
        public string ContactEmail { get; set; }


        [Required(ErrorMessage ="Location is required")]
        [Display(Name = "Event's Location")]
        public string Location { get; set; }


        [Range(0,100000, ErrorMessage ="Number must be between 0 and 100,000.")]
        [Display(Name="Number of Attendees")]
        public int NumOfAttendees { get; set; }



        //[Display(Name="Event Type")]
        //public EventType Type { get; set; }







        //each item represents one of the enum values
        //allows View Model to help View generate drop down menu
        //public List<SelectListItem> EventTypes { get; set; } = new List<SelectListItem>
        //{
        //    //for a new Select List Item we need to pass in what we want it to say(string), and then the value of the enum(as a string)
        //    //for value of enum, we have to first cast the enum as an integer to get the number and then back to a string
        //    new SelectListItem(EventType.Conference.ToString(), ((int)EventType.Conference).ToString()),
        //    new SelectListItem(EventType.Meetup.ToString(), ((int)EventType.Meetup).ToString()),
        //    new SelectListItem(EventType.Social.ToString(), ((int)EventType.Social).ToString()),
        //    new SelectListItem(EventType.Workshop.ToString(), ((int)EventType.Workshop).ToString())

        //};

        [Required(ErrorMessage = "Category is required.")]
        public int CategoryId { get; set; }

        public List<SelectListItem> Categories { get; set; }


        //allows us to have select drop down menu in the form able to display all categories
        public AddEventViewModel(List<EventCategory> categories)
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

        }

        //needed for model binding
        public AddEventViewModel ()
        {

        }
    }
}
