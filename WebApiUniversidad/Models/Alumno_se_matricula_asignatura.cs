using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
    
namespace WebApiUniversidad.Models
{
    public class Alumno_se_matricula_asignatura
    {
        // La clave primaria se define en MySQLDbContext
        [ForeignKey("alumno")]
        public int Id_Alumno { get; set; }
        [ForeignKey("asignatura")]
        public int Id_Asignatura { get; set; }
        [ForeignKey("curso_escolar")]
        public int Id_Curso_Escolar { get; set; }
    }
}
