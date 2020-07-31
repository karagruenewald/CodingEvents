using System;
using CodingEvents.Models;

namespace CodingEvents.ViewModels
{
    // Create a view model every time you want to create a view

    public class ContactDetailViewModel
    {
        public string Name { get; set; }

        public ContactDetailViewModel(Contact c)
        {
            Name = c.Name;
        }
    }
}
