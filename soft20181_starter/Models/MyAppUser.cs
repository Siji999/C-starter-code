using Microsoft.AspNetCore.Identity;

namespace soft20181_starter.Models
{
	public class MyAppUser : IdentityUser
	{
        public string Course { get; set; }
    }
}
