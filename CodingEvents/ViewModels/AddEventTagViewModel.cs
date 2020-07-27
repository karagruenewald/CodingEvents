using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CodingEvents.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CodingEvents.ViewModels
{
    public class AddEventTagViewModel
    {
        //represent the event we're trying to add a tag to
        [Required(ErrorMessage ="Event is required.")]
        public int EventId { get; set; }
        public Event Event { get; set; }


        //represents the specific tag the user is trying to select for tag
        [Required(ErrorMessage = "Event is required.")]
        public int TagId { get; set; }
        public Tag Tag { get; set; }

        //for drop down menu
        public List<SelectListItem> Tags { get; set; }


        public AddEventTagViewModel(Event theEvent, List<Tag> possibleTags)
        {
            Tags = new List<SelectListItem>();

            foreach (var tag in possibleTags)
            {
                Tags.Add(new SelectListItem
                {
                    Value = tag.Id.ToString(),
                    Text = tag.Name
                });
            }

            Event = theEvent;

        }




        public AddEventTagViewModel()
        {
        }
    }
}
