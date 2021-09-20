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
    public class GradosController : ControllerBase
    {
        private readonly MySQLDbContext _context;

        public GradosController(MySQLDbContext context)
        {
            _context = context;
        }

        // GET: api/Grados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Grado>>> GetGrado()
        {
            return await _context.Grado.ToListAsync();
        }

        // GET: api/Grados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Grado>> GetGrado(int id)
        {
            var grado = await _context.Grado.FindAsync(id);

            if (grado == null)
            {
                return NotFound();
            }

            return grado;
        }

        // PUT: api/Grados/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrado(int id, Grado grado)
        {
            if (id != grado.Id_Grado)
            {
                return BadRequest();
            }

            _context.Entry(grado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GradoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(grado);
        }

        // POST: api/Grados
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Grado>> PostGrado(Grado grado)
        {
            _context.Grado.Add(grado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGrado", new { id = grado.Id_Grado }, grado);
        }

        // DELETE: api/Grados/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Grado>> DeleteGrado(int id)
        {
            var grado = await _context.Grado.FindAsync(id);
            if (grado == null)
            {
                return NotFound();
            }

            _context.Grado.Remove(grado);
            await _context.SaveChangesAsync();

            return grado;
        }

        private bool GradoExists(int id)
        {
            return _context.Grado.Any(e => e.Id_Grado == id);
        }
    }
}
