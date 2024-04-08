using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using soft20181_starter.Models;

namespace soft20181_starter.Pages.Events
{
    [Authorize]
    public class DetailModel : PageModel
    {
        private readonly EventAppDbContext _db;
        private readonly UserManager<MyAppUser> _userManager;

        public DetailModel(EventAppDbContext db, UserManager<MyAppUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        //public EventAppDbContext _db { get; set; }
        //public DetailModel(EventAppDbContext db)
        //{
        //    _db = db;
        //}

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public Event EventDetail { get; set; }

        public void OnGet()
        {
            EventDetail = _db.Events.Find(Id);
        }

    }
}
