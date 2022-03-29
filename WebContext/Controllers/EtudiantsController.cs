#nullable disable
using Couchbase.Core.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebContext.Pages.Etudiant;

namespace WebContext.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EtudiantsController : ControllerBase
    {
        private readonly EtudiantContext _context;
        private readonly ILogger _logger;
        public EtudiantsController(EtudiantContext context, ILoggerFactory logger)
        {
            _context = context;
            _logger = logger.CreateLogger<EtudiantsController>();
        }

        // GET: api/Etudiants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Etudiants>>> GetEtudiants()
        {
            _logger.LogWarning("Log message in All etudiants method");

            return await _context.Etudiants.ToListAsync();
        }

        // GET: api/Etudiants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Etudiants>> GetEtudiants(int id)
        {
            var etudiants = await _context.Etudiants.FindAsync(id);
            _logger.LogInformation("Log message in the Find method");

            if (etudiants == null)
            {
                _logger.LogWarning(LoggingEvents.SearchEvent, "GetById({0}) NOT FOUND", id);
                return NotFound();
            }

            return etudiants;
        }

        // PUT: api/Etudiants/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEtudiants(int id, Etudiants etudiants)
        {
            if (id != etudiants.EtudiantId)
            {
                return BadRequest();
            }

            _context.Entry(etudiants).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EtudiantsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Etudiants
        [HttpPost]
        public async Task<ActionResult<Etudiants>> PostEtudiants(Etudiants etudiants)
        {
            _context.Etudiants.Add(etudiants);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEtudiants", new { id = etudiants.EtudiantId }, etudiants);
        }

        // DELETE: api/Etudiants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEtudiants(int id)
        {
            var etudiants = await _context.Etudiants.FindAsync(id);
            if (etudiants == null)
            {
                return NotFound();
            }

            _context.Etudiants.Remove(etudiants);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EtudiantsExists(int id)
        {
            return _context.Etudiants.Any(e => e.EtudiantId == id);
        }
    }
}
