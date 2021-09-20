using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiUniversidad.Models
{
    public class Grado
    {
        [Key]
        public int Id_Grado { get; set; }
        public String Nombre { get; set; }

    }
}
