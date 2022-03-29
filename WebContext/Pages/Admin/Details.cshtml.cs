#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebContext.Pages.Etudiant;

namespace WebContext.Pages
{
     [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly WebContext.Pages.Etudiant.EtudiantContext _context;

        public DetailsModel(WebContext.Pages.Etudiant.EtudiantContext context)
        {
            _context = context;
        }

        public Etudiants Etudiant { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Etudiant = await _context.Etudiants.FirstOrDefaultAsync(m => m.EtudiantId == id);

            if (Etudiant == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
