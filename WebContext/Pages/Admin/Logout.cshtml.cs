using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebContext.Pages.Admin
{
    public class LogoutModel : PageModel
    {
        public void OnGet()
        {
            _ = Logout();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToPage("Index");
        }
    }
}
