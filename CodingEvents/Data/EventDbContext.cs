using System;
using CodingEvents.Models;
using Microsoft.EntityFrameworkCore;

//layer connecting from our application to our database - after creating need to register it with our app(Startup.cs)
namespace CodingEvents.Data
{
    public class EventDbContext: DbContext
    {
        //representation of our events table
        public DbSet<Event> Events { get; set; }

        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options)
        {
        }
    }
}
