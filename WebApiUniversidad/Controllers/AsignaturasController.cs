using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiUniversidad.Models;

namespace WebApiUniversidad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsignaturasController : ControllerBase
    {
        private readonly MySQLDbContext _context;

        public AsignaturasController(MySQLDbContext context)
        {
            _context = context;
        }

        // GET: api/Asignaturas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Asignatura>>> GetAsignatura()
        {
            return await _context.Asignatura.ToListAsync();
        }

        // GET: api/Asignaturas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Asignatura>> GetAsignatura(int id)
        {
            var asignatura = await _context.Asignatura.FindAsync(id);

            if (asignatura == null)
            {
                return NotFound();
            }

            return asignatura;
        }

        // PUT: api/Asignaturas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsignatura(int id, Asignatura asignatura)
        {
            if (id != asignatura.Id_Asignatura)
            {
                return BadRequest();
            }

            _context.Entry(asignatura).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsignaturaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

           return Ok(asignatura);
        }

        // POST: api/Asignaturas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Asignatura>> PostAsignatura(Asignatura asignatura)
        {
            _context.Asignatura.Add(asignatura);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAsignatura", new { id = asignatura.Id_Asignatura }, asignatura);
        }

        // DELETE: api/Asignaturas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Asignatura>> DeleteAsignatura(int id)
        {
            var asignatura = await _context.Asignatura.FindAsync(id);
            if (asignatura == null)
            {
                return NotFound();
            }

            _context.Asignatura.Remove(asignatura);
            await _context.SaveChangesAsync();

            return asignatura;
        }

        private bool AsignaturaExists(int id)
        {
            return _context.Asignatura.Any(e => e.Id_Asignatura == id);
        }
    }
}
