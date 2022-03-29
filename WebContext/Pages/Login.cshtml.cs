using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace WebContext.Pages
{
    public class LoginModel : PageModel
    {
         public string message { get; set; }
        public void OnGet()
        {
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult OnPost(string Nom, string password)
        {
            try
            {
                message = "";

                if (Nom == "Admin" && password == "123")
                {
                    var claim = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name,Nom)
                        };
                    var identity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    var props = new AuthenticationProperties();
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props).Wait();

                    return RedirectToPage("/Admin/Index");
                }


                else
                {
                    message = "Try Again";
                    return Page();
                }
            }
            catch
            {
                return Page();
            }
        }
    }
}
