
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiUniversidad.Models
{
    public class Departamento
    {
        [Key]
        public int Id_Departamento { get; set; }
        public string Nombre { get; set; }
    }
}
