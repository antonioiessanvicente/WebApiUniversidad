using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiUniversidad.Models
{
    public class Asignatura
    {
        [Key]
        public int Id_Asignatura { get; set; }
        public String Nombre { get; set; }
        public float Creditos { get; set; }
        public String Tipo { get; set; }
        public int Curso { get; set; }
        public int Cuatrimestre { get; set; }
        [ForeignKey("profesor")]
        public int? ID_Profesor { get; set; }
        [ForeignKey("grado")]
        public int ID_Grado { get; set; }

    }
}
