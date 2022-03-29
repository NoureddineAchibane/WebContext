using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebContext.Pages.Etudiant
{
    public class Etudiants
    {
        [Key]
        public int EtudiantId { get; set; }
        [Required(ErrorMessage = "Please enter a name.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a prenom.")]
        public string Prenom { get; set; }
        
    }
}
