using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using soft20181_starter.Models;

namespace soft20181_starter.Pages.Students
{
    public class StudentsModel : PageModel
    {
        public StudentAppDbContext _db { get; set; }
        public StudentsModel(StudentAppDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Student TheStudent { get; set; }

        public List<Student> StudentList { get; set; }
        public void OnGet()
        {
            StudentList = _db.Students.ToList();
        }

        public void OnPost()
        {
            _db.Students.Add(TheStudent);
            _db.SaveChanges();
            StudentList = _db.Students.ToList();
        }
    }
}
