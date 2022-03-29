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
    public class IndexModel : PageModel
    {
        
        private readonly WebContext.Pages.Etudiant.EtudiantContext _context;

        public IndexModel(WebContext.Pages.Etudiant.EtudiantContext context)
        {
            _context = context;
        }

        public List<Etudiants> Etudiant { get;set; }

        public async Task OnGetAsync()
        {
            Etudiant = await _context.Etudiants.ToListAsync();
        }
    }
}
