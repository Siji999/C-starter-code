using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using soft20181_starter.Models;

namespace soft20181_starter.Pages.Events
{
    [Authorize]
    public class IndexModel : PageModel
    {
        public EventAppDbContext _db { get; set; }
        //public RoleManager<IdentityRole> _roleMgr { get; set; }
        //public UserManager<MyAppUser> _userMgr { get; set; }
        public IndexModel(EventAppDbContext db)
        //public IndexModel(StudentAppDbContext db, RoleManager<IdentityRole> roleMgr, UserManager<MyAppUser> userMgr)
        {
            _db = db;
            //_roleMgr = roleMgr;
            //_userMgr = userMgr;
        }

        // keeping the student
        public List<Event> EventList { get; set; }
        public async Task OnGet()
        {
            // fetch all students
            EventList = _db.Events.ToList();

            //// create roles for admin and users
            //var adminRole = new IdentityRole("Admin");
            //var userRole = new IdentityRole("User");
            //await _roleMgr.CreateAsync(adminRole);
            //await _roleMgr.CreateAsync(userRole);
            //// i'm commenting it out after running it so that it doesn't get recreated on a re-run
            ///

            //// assign the admin role to the current user
            //// find the user
            //var user = await _userMgr.FindByEmailAsync("holooluwatosin@gmail.com");

            //// add to role
            //await _userMgr.AddToRoleAsync(user, "Admin");
        }

    }
}
