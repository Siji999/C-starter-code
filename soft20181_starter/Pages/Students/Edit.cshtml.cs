using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using soft20181_starter.Models;

namespace soft20181_starter.Pages.Students
{
    public class EditModel : PageModel
    {
		public StudentAppDbContext _db { get; set; }
		public EditModel(StudentAppDbContext db)
		{
			_db = db;
		}

		//public void OnGet(string id)
		//{
		//}

		//Another option is, option2 ;
		[BindProperty(SupportsGet = true)]
        public int Id { get; set; }

		[BindProperty]
		public Student TheStudent { get; set; }

		public void OnGet()
        {
			TheStudent = _db.Students.Find(Id);
        }
		
		public IActionResult OnGetDelete()
        {
			TheStudent = _db.Students.Find(Id);
			_db.Students.Remove(TheStudent);
			_db.SaveChanges();
			return RedirectToPage("Index");
		}

		public IActionResult OnPost() 
		{ 
			_db.Students.Update(TheStudent);
			_db.SaveChanges();
			return RedirectToPage("Index");
		}
    }
}
