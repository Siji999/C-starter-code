using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using soft20181_starter.Models;

namespace soft20181_starter.Pages
{
    //[Authorize (Roles = "Admin")]
    public class ContactModel : PageModel
    {
        [BindProperty]
        public Contact ContactInfo { get; set; }


        public void OnGet()
        {

        }

        public void OnPost()
        {
            if(ModelState.IsValid)
            {
                // Save to Database
                // Show success message
                // return
            }
            


        }
    }
}
