using System;
using System.Collections.Generic;
using CodingEvents.Models;

namespace CodingEvents.ViewModels
{
    public class EventDetailViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ContactEmail { get; set; }
        public string CategoryName { get; set; }
        public int EventId { get; set; }

        //need to display all the tags associated with each event
        public string TagText { get; set; }

        public EventDetailViewModel(Event theEvent, List<EventTag> eventTags)
        {
            EventId = theEvent.Id;
            Name = theEvent.Name;
            Description = theEvent.Description;
            ContactEmail = theEvent.ContactEmail;
            CategoryName = theEvent.Category.Name;

            TagText = "";
            for (var i = 0; i < eventTags.Count; i++)
            {
                TagText += ("#" + eventTags[i].Tag.Name);
                if(i < eventTags.Count - 1)
                {
                    TagText += ", ";
                }
            }

        }
    }
}
