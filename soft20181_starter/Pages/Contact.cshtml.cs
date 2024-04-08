using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using soft20181_starter.Models;

namespace soft20181_starter.Pages
{
    //[Authorize (Roles = "Admin")]
    [Authorize]
    public class ContactModel : PageModel
    {
        public EventAppDbContext _db { get; set; }

        public ContactModel(EventAppDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Contact ContactInfo { get; set; }


        public void OnGet()
        {
        }

        //public void OnPost()
        //{
        //    if(ModelState.IsValid)
        //    {
        //        // Save to Database
        //        // Show success message
        //        // return

        //        _db.ContactUs.Add(ContactInfo);
        //        _db.SaveChanges();
        //        RedirectToPage("Index");
        //    }
        //}

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.ContactUs.Add(ContactInfo);
                _db.SaveChanges();
                return RedirectToPage("Index");
            }

            // If ModelState is not valid, redisplay the page with validation errors
            return Page();
        }

    }
}
