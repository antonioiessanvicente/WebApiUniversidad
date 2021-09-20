using Microsoft.EntityFrameworkCore;
using WebApiUniversidad.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

namespace WebApiUniversidad.Models
{

    // Contexto de la Base de datos
    public class MySQLDbContext : DbContext
    {
        public MySQLDbContext(DbContextOptions<MySQLDbContext> options)
            : base(options)
        {
        }

        // El campo debe tener el mismo nombre que la tabla de la BD
        public DbSet<Asignatura> Asignatura { get; set; }
        public DbSet<Curso_Escolar> Curso_Escolar { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Grado> Grado { get; set; }
        public DbSet<Persona> Persona { get; set; }
        public DbSet<Profesor> Profesor { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Alumno_se_matricula_asignatura> Alumno_se_matricula_asignatura { get; set; }



        // Clave primaria compuesta de linped y localidad
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumno_se_matricula_asignatura>()
                .HasKey(l => new { l.Id_Alumno, l.Id_Asignatura, l.Id_Curso_Escolar });

        }

    }
}
