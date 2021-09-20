using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApiUniversidad.Models
{
    public class Curso_Escolar
    {
        [Key]
        public int Id_Curso_Escolar { get; set; }
        public int Anyo_Inicio { get; set; }
        public int Anyo_Fin { get; set; }
    }
}
