using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using soft20181_starter.Models;

namespace soft20181_starter.Pages.Events
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        //private readonly EventAppDbContext _db;
        public EventAppDbContext _db { get; set; }
        public EditModel(EventAppDbContext db)
        {
            _db = db;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public Event Events { get; set; }

        [BindProperty]
        public IFormFile ImageFile { get; set; }
        public void OnGet()
        {
            Events = _db.Events.Find(Id);
        }

        public IActionResult OnPost()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page(); // Return the page with validation errors
            //}

            if (ImageFile != null && ImageFile.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    ImageFile.CopyTo(memoryStream);
                    Events.ImageData = memoryStream.ToArray();
                }
            }

            _db.Events.Update(Events);
            _db.SaveChanges();
            return RedirectToPage("Index");
        }

        public IActionResult OnGetDelete()
        {
            Events = _db.Events.Find(Id);
            _db.Events.Remove(Events);
            _db.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
