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

        public AddEventViewModel()
        {
        }
    }
}
