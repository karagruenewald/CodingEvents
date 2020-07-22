using System;
namespace CodingEvents.Models
{
    public class Event
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ContactEmail { get; set; }
        public string Location { get; set; }
        public int NumOfAttendees { get; set; }

        public EventType Type { get; set; } //EventType.Conference, EventType.Meeting

        //this will be set when we create objects in the database
        public int Id { get; set; }
        

        //no arg constructor needed for model binding by the framework
        public Event()
        {  
        }


        public Event(string name, string description, string contactEmail, string location, int numOfAttendees, EventType type)
        {
            Name = name;
            Description = description;
            ContactEmail = contactEmail;
            Location = location;
            NumOfAttendees = numOfAttendees;
            Type = type;
            
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            return obj is Event @event &&
                   Id == @event.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
