using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiUniversidad.Models
{
    public class Persona
    {
        [Key]
        public int Id_Persona { get; set; }
        public String Nif { get; set; }
        public String Nombre { get; set; }
        public String Apellido1 { get; set; }
        public String Apellido2 { get; set; }
        public String Ciudad { get; set; }
        public String Direccion  { get; set; }
        public String Telefono { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public char Sexo { get; set; }
        public String Tipo { get; set; }
        public String Ruta_Foto { get; set; }



    }
}
