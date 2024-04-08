using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using soft20181_starter.Models;

namespace soft20181_starter.Pages.Events
{
    [Authorize(Roles = "Admin")]
    public class AddModel : PageModel
    {
		//private readonly EventAppDbContext _db;
		public EventAppDbContext _db { get; set; }
		public AddModel(EventAppDbContext db)
		{
			_db = db;
		}

		[BindProperty]
		public Event Events { get; set; }

		[BindProperty]
		public IFormFile ImageFile { get; set; }
		public void OnGet()
		{
		}

		public IActionResult OnPost()
		{
            //_db.Events.Add(Events);
            //_db.SaveChanges();
            //return RedirectToPage("Index");

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

            _db.Events.Add(Events);
            _db.SaveChanges();
            return RedirectToPage("Index");
        }
	}
}
