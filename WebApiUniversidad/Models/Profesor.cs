using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiUniversidad.Models
{
    public class Profesor
    {
        [Key]
        [ForeignKey("persona")]
        public int Id_Profesor { get; set; }
        [ForeignKey("departamento")]
        public int Id_Departamento { get; set; }
    }
}
