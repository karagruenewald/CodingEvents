using System;
namespace CodingEvents.Models
{
    public class Event
    {
        public string Name { get; set; }
        public string Description { get; set; }
        
        public string Location { get; set; }
        public int NumOfAttendees { get; set; }


        //need this for one to many relationship with Contact
        public Contact Contact { get; set; }
        public int ContactId { get; set; }


        //need this for one to many relationship with Event Category
        public EventCategory Category { get; set; }
        public int CategoryId { get; set; }



        //this will be set when we create objects in the database
        public int Id { get; set; }
        

        //no arg constructor needed for model binding by the framework
        public Event()
        {  
        }


        public Event(string name, string description, string location, int numOfAttendees)
        {
            Name = name;
            Description = description;
            Location = location;
            NumOfAttendees = numOfAttendees;
            
            
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
