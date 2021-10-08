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
    public class Alumnos_se_matriculan_asignaturasController : ControllerBase
    {
        private readonly MySQLDbContext _context;

        public Alumnos_se_matriculan_asignaturasController(MySQLDbContext context)
        {
            _context = context;
        }

        // GET: api/Alumnos_se_matriculan_asignaturas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alumno_se_matricula_asignatura>>> GetAlumno_se_matricula_asignatura()
        {
            return await _context.Alumno_se_matricula_asignatura.ToListAsync();
        }

        // GET: api/Alumnos_se_matriculan_asignaturas/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Alumno_se_matricula_asignatura>> GetAlumno_se_matricula_asignatura(int id)
        //{
        //    var alumno_se_matricula_asignatura = await _context.Alumno_se_matricula_asignatura.FindAsync(id);

        //    if (alumno_se_matricula_asignatura == null)
        //    {
        //        return NotFound();
        //    }

        //    return alumno_se_matricula_asignatura;
        //}

        // Obtiene el listado de asignaturas de un alumno (todos los años)
        // GET: api/Alumnos_se_matriculan_asignaturas/alumno/5
        // [HttpGet("{id}")]
        [HttpGet("alumno/{id}")]
        public async Task<ActionResult<IEnumerable<Alumno_se_matricula_asignatura>>> GetAlumno_se_matricula_asignatura(int id)
        { 
            var alumno_se_matricula_asignatura = await _context.Alumno_se_matricula_asignatura.Where(x => x.Id_Alumno == id).ToListAsync();

            if (alumno_se_matricula_asignatura == null)
            {
                return NotFound();
            }

            return  alumno_se_matricula_asignatura;
        }

        // Obtiene el listado de alumnos de una asignatura (todos los años)
        // GET: api/Alumnos_se_matriculan_asignaturas/asignatura/1
        [HttpGet("asignatura/{asignatura}")]
        public async Task<ActionResult<IEnumerable<Alumno_se_matricula_asignatura>>> GetAlumnos_asignatura(int asignatura)
        {
            // var alumno_se_matricula_asignatura = await _context.Alumno_se_matricula_asignatura.FindAsync(id);
            var alumno_se_matricula_asignatura = await _context.Alumno_se_matricula_asignatura.Where(x => x.Id_Asignatura == asignatura).ToListAsync();

            if (alumno_se_matricula_asignatura == null)
            {
                return NotFound();
            }

            return alumno_se_matricula_asignatura;
        }

        // PUT: api/Alumnos_se_matriculan_asignaturas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        [HttpPut("{id_al:int}/{id_as:int}/{id_cu:int}")]
        public async Task<IActionResult> PutAlumno_se_matricula_asignatura([FromRoute] int id_al, int id_as, int id_cu, Alumno_se_matricula_asignatura alumnoAM)
        {
            //if (id != alumno_se_matricula_asignatura.Id_Alumno)
            //{
            //    return BadRequest();
            //}

           var alumno_se_matricula_asignatura = await _context.Alumno_se_matricula_asignatura.FindAsync(id_al, id_as, id_cu);


            /* CAMBIO Versión 1.01 */
            // No se puede modificar al formar parte de una clave primaria, por lo que hay que borrar la actual e insertar la nueva.
            // _context.Entry(alumno_se_matricula_asignatura).State = EntityState.Modified;

            _context.Alumno_se_matricula_asignatura.Remove(alumno_se_matricula_asignatura);
            await _context.SaveChangesAsync();

            // Actualizo los valores del objeto encontrado con los del body de la llamada PUT
            alumno_se_matricula_asignatura.Id_Alumno = alumnoAM.Id_Alumno;
            alumno_se_matricula_asignatura.Id_Asignatura = alumnoAM.Id_Asignatura;
            alumno_se_matricula_asignatura.Id_Curso_Escolar = alumnoAM.Id_Curso_Escolar;

            // Insertamos de nuevo el objeto con los nuevos valores
            _context.Alumno_se_matricula_asignatura.Add(alumno_se_matricula_asignatura);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Alumno_se_matricula_asignaturaExists(id_al,id_as,id_cu))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            
            /* CAMBIO Versión 1.01 */
            // Se dewvuelve el objeto creado
           // return Ok(alumno_se_matricula_asignatura);
            return CreatedAtAction("GetAlumno_se_matricula_asignatura", new { id = alumno_se_matricula_asignatura.Id_Alumno }, alumno_se_matricula_asignatura);
        }

        // POST: api/Alumnos_se_matriculan_asignaturas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Alumno_se_matricula_asignatura>> PostAlumno_se_matricula_asignatura(Alumno_se_matricula_asignatura alumno_se_matricula_asignatura)
        {
            _context.Alumno_se_matricula_asignatura.Add(alumno_se_matricula_asignatura);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Alumno_se_matricula_asignaturaExists(alumno_se_matricula_asignatura.Id_Alumno,
                                                         alumno_se_matricula_asignatura.Id_Asignatura,
                                                         alumno_se_matricula_asignatura.Id_Curso_Escolar))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAlumno_se_matricula_asignatura", new { id = alumno_se_matricula_asignatura.Id_Alumno }, alumno_se_matricula_asignatura);
        }

        // DELETE: api/Alumnos_se_matriculan_asignaturas/5/1/2
        [HttpDelete("{id_al:int}/{id_as:int}/{id_cu:int}")]
        public async Task<IActionResult> DeleteAlumno_se_matricula_asignatura([FromRoute] int id_al, int id_as,int id_cu)
        {
            var alumno_se_matricula_asignatura = await _context.Alumno_se_matricula_asignatura.FindAsync(id_al,id_as, id_cu);
            if (alumno_se_matricula_asignatura == null)
            {
                return NotFound();
            }

            _context.Alumno_se_matricula_asignatura.Remove(alumno_se_matricula_asignatura);
            await _context.SaveChangesAsync();

            return Ok(alumno_se_matricula_asignatura);
        }

        private bool Alumno_se_matricula_asignaturaExists(int id_al, int id_asig, int id_cu)
        {
            return _context.Alumno_se_matricula_asignatura.Any(e => e.Id_Alumno == id_al &&
                                                                e.Id_Asignatura == id_asig && 
                                                                e.Id_Curso_Escolar == id_cu);
        }
    }
}
