using Microsoft.EntityFrameworkCore;

namespace WebContext.Pages.Etudiant
{
    public class EtudiantContext:DbContext
    {
        public EtudiantContext(DbContextOptions<EtudiantContext> options)
         : base(options)
         { }
        public DbSet<Etudiants> Etudiants { get; set; }
        protected override void OnModelCreating(ModelBuilder m)
        {
            m.Entity<Etudiants>().HasAlternateKey(x=> x.EtudiantId);
            m.Entity<Etudiants>().HasData(
                new Etudiants()
                {
                    EtudiantId = 1,
                    Name = "Achibane",
                    Prenom = "Noureddine"
                },
                new Etudiants()
                {
                    EtudiantId = 2,
                    Name = "Labrag",
                    Prenom = "Hassan"
                },
                new Etudiants()
                {
                    EtudiantId = 3,
                    Name = "Yeah",
                    Prenom = "Mouad"
                }
                );
        }
    }
}
