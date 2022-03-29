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
    public class DeleteModel : PageModel
    {
        private readonly WebContext.Pages.Etudiant.EtudiantContext _context;

        public DeleteModel(WebContext.Pages.Etudiant.EtudiantContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Etudiant = await _context.Etudiants.FindAsync(id);

            if (Etudiant != null)
            {
                _context.Etudiants.Remove(Etudiant);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
