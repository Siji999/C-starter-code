using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using soft20181_starter.Models;
using System.Data;

namespace soft20181_starter.Pages
{

    [Authorize]
    //[Authorize(Roles = "Admin")]
    public class AdminModel : PageModel
    {
        public EventAppDbContext _db { get; set; }
        public RoleManager<IdentityRole> _roleMgr { get; set; }
        public UserManager<MyAppUser> _userMgr { get; set; }
        public AdminModel(EventAppDbContext db, RoleManager<IdentityRole> roleMgr, UserManager<MyAppUser> userMgr)
        {
            _db = db;
            _roleMgr = roleMgr;
            _userMgr = userMgr;
        }

        [BindProperty]
        public string UserId { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Role { get; set; }

        public List<MyAppUser> UserList { get; set; }
        //public List<MyAppUser> UserList { get; set; } = new List<MyAppUser>();

        //public List<UserWithRoleViewModel> UsersWithRoles { get; set; }

        public List<Event> EventList { get; set; }
        public async Task OnGet()
        {
            //EventList = _db.Events.ToList();

            // Fetch all users
            //UserList = await _userMgr.Users.ToListAsync();
            UserList = await _userMgr.Users.ToListAsync();

            // Fetch all events
            EventList = await _db.Events.ToListAsync();

            // Check if the "Admin" role exists, if not, create it
            if (!await _roleMgr.RoleExistsAsync("Admin"))
            {
                await _roleMgr.CreateAsync(new IdentityRole("Admin"));
            }

            if (!await _roleMgr.RoleExistsAsync("User"))
            {
                await _roleMgr.CreateAsync(new IdentityRole("User"));
            }

            //// Assign the "Admin" role to the current user
            //var currentUser = await _userMgr.GetUserAsync(User);
            //if (currentUser != null && !await _userMgr.IsInRoleAsync(currentUser, "Admin"))
            //{
            //    await _userMgr.AddToRoleAsync(currentUser, "Admin");
            //}


            //// create roles for admin and users
            //var adminRole = new IdentityRole("Admin");
            //var userRole = new IdentityRole("User");
            //await _roleMgr.CreateAsync(adminRole);
            //await _roleMgr.CreateAsync(userRole);
            //// i'm commenting it out after running it so that it doesn't get recreated on a re-run


            //// assign the admin role to the current user
            //// find the user
            //var user = await _userMgr.FindByEmailAsync("holooluwatosin@gmail.com");

            //// add to role
            //await _userMgr.AddToRoleAsync(user, "Admin");
        }

        public async Task<IActionResult> OnPost()
        {
            // Find the user
            //var user = await _userMgr.FindByEmailAsync(Email);
            var user = await _userMgr.FindByIdAsync(UserId);

            // Check if the user exists
            if (user == null)
            {
                return NotFound();
            }

            // Assign the role to the user
            await _userMgr.AddToRoleAsync(user, Role);

            return RedirectToPage(); // Redirect back to the page after assigning the role
        }
    }
}
