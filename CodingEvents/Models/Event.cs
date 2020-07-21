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

        public int Id { get; }
        private static int nextId = 1;

        //no arg constructor needed for model binding by the framework
        public Event()
        {
            Id = nextId;
            nextId++;
        }


        public Event(string name, string description, string contactEmail, string location, int numOfAttendees, EventType type): this()
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
