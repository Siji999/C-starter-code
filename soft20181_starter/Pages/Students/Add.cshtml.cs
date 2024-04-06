using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using soft20181_starter.Models;

namespace soft20181_starter.Pages.Students
{
	//[Authorize(Roles = "Admin")]
    public class AddModel : PageModel
    {
		public StudentAppDbContext _db { get; set; }
		public AddModel(StudentAppDbContext db)
		{
			_db = db;
		}

		[BindProperty]
		public Student TheStudent { get; set; }
		public void OnGet()
        {
        }

		public IActionResult OnPost()
		{
			_db.Students.Add(TheStudent);
			_db.SaveChanges();
			return RedirectToPage("Index");
		}
	}
}
