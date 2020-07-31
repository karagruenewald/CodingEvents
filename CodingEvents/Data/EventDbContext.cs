using System;
using CodingEvents.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

//layer connecting from our application to our database - after creating DbContext need to register it with our app(Startup.cs)
namespace CodingEvents.Data
{
    public class EventDbContext: IdentityDbContext<IdentityUser>
    {
        //representation of our events table
        public DbSet<Event> Events { get; set; }
        public DbSet<EventCategory> EventCategories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<EventTag> EventTags { get; set; }
        public DbSet<Contact> Contacts { get; set; }


        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options)
        {
        }

        //this method will run when DbContext is called & this will set primarykey of Event Tag as eventid+tagid
        protected override void OnModelCreating(ModelBuilder modelBuiler)
        {
            modelBuiler.Entity<EventTag>()
                .HasKey(et => new { et.EventId, et.TagId });

            base.OnModelCreating(modelBuiler);
        }
    }
}
