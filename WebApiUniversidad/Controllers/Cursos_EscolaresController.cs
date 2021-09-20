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
    public class Cursos_EscolaresController : ControllerBase
    {
        private readonly MySQLDbContext _context;

        public Cursos_EscolaresController(MySQLDbContext context)
        {
            _context = context;
        }

        // GET: api/Cursos_Escolares
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curso_Escolar>>> GetCurso_Escolar()
        {
            return await _context.Curso_Escolar.ToListAsync();
        }

        // GET: api/Cursos_Escolares/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Curso_Escolar>> GetCurso_Escolar(int id)
        {
            var curso_Escolar = await _context.Curso_Escolar.FindAsync(id);

            if (curso_Escolar == null)
            {
                return NotFound();
            }

            return curso_Escolar;
        }

        // PUT: api/Cursos_Escolares/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurso_Escolar(int id, Curso_Escolar curso_Escolar)
        {
            if (id != curso_Escolar.Id_Curso_Escolar)
            {
                return BadRequest();
            }

            _context.Entry(curso_Escolar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Curso_EscolarExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(curso_Escolar);
        }

        // POST: api/Cursos_Escolares
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Curso_Escolar>> PostCurso_Escolar(Curso_Escolar curso_Escolar)
        {
            _context.Curso_Escolar.Add(curso_Escolar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCurso_Escolar", new { id = curso_Escolar.Id_Curso_Escolar }, curso_Escolar);
        }

        // DELETE: api/Cursos_Escolares/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Curso_Escolar>> DeleteCurso_Escolar(int id)
        {
            var curso_Escolar = await _context.Curso_Escolar.FindAsync(id);
            if (curso_Escolar == null)
            {
                return NotFound();
            }

            _context.Curso_Escolar.Remove(curso_Escolar);
            await _context.SaveChangesAsync();

            return curso_Escolar;
        }

        private bool Curso_EscolarExists(int id)
        {
            return _context.Curso_Escolar.Any(e => e.Id_Curso_Escolar == id);
        }
    }
}
