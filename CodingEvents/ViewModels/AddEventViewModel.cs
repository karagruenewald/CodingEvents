using System;
using System.ComponentModel.DataAnnotations;

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

        public AddEventViewModel()
        {
        }
    }
}
