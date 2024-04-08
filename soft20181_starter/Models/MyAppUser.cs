using Microsoft.AspNetCore.Identity;

namespace soft20181_starter.Models
{
    public class MyAppUser : IdentityUser
    {
        public object AttendingEvents { get; internal set; }
    }
}
