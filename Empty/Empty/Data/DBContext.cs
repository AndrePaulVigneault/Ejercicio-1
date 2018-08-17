using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio_1EntityFramework
{
    public class DBContext : DbContext
    {

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Mascota> Mascotas { get; set; }
        public DbSet<Persona_Mascota> Persona_Mascotas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = (local); Database = Ejercio1; Integrated Security = True; MultipleActiveResultSets = true;");
        }

    }
}
