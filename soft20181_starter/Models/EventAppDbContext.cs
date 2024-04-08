using Humanizer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace soft20181_starter.Models
{
	//public class EventAppDbContext : DbContext
	public class EventAppDbContext : IdentityDbContext<MyAppUser>
	{
		public EventAppDbContext(DbContextOptions<EventAppDbContext> options) : base(options)
		{

		}
		public DbSet<Contact> ContactUs { get; set; }
		public DbSet<Event> Events { get; set; }

        //To create a table for users; but you don't need to do this, if you are using "IdentityDbContext", as it is inherited from "IdentityDbContext"
        //public DbSet<MyAppUser> Users { get; set; }
    }
}
