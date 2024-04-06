using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using soft20181_starter.Models;

namespace soft20181_starter.Pages
{
    public class loginModel : PageModel
    {
        public SignInManager<MyAppUser> signInManager {  get; set; }
        public loginModel (SignInManager<MyAppUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        [BindProperty]
        public string Email { get; set; }
        public void OnGet()
        {
        }

        public async Task OnPostAsync() 
        {
            //// login the user with email
            //await signInManager.SignInAsync(new MyAppUser
            //{
            //    Email = Email,
            //});
        }
    }
}
