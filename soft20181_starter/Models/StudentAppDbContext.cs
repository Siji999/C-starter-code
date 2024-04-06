using Humanizer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace soft20181_starter.Models
{
	//public class StudentAppDbContext : DbContext
	public class StudentAppDbContext : IdentityDbContext<MyAppUser>
	{
		public StudentAppDbContext(DbContextOptions<StudentAppDbContext> options) : base(options)
		{

		}
		public DbSet<Student> Students { get; set; }
		//To create a table for users; this is inherited from "IdentityDbContext"
		//public DbSet<MyAppUser> Users { get; set; }
	}
}
