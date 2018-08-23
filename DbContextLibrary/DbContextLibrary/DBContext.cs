using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DbContextLibrary
{
    public class DBContext : DbContext
    {
        private IConfiguration _Config;
        public DBContext(IConfiguration config )
        {
            _Config = config;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_Config.GetConnectionString("DefaultConnection"));
        }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Mascota> Mascotas { get; set; }
        public DbSet<Persona_Mascota> PersonasMascotas { get; set; }
    }
}
