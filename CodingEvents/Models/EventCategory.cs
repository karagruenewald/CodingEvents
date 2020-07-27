using System;
using System.Collections.Generic;

namespace CodingEvents.Models
{
    public class EventCategory
    {

        public int Id { get; set; }
        public string Name { get; set; }

        //Need a reference of the Events that are this category
        public List<Event> Events { get; set; }


        public EventCategory()
        {
        }

        public EventCategory(string name)
        {
            Name = name;
        }
    }
}
