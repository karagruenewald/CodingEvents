using System;
using System.Collections.Generic;

namespace CodingEvents.Models
{
    public class Contact
    {

        public int  Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }

        public List<Event> Events { get; set; }


        public Contact()
        {
        }

        public Contact(string name, string email, string phoneNumber, string city)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            City = city;
        }
    }
}
