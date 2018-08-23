using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DbContextLibrary
{
    public class Mascota
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Raza { get; set; }
        public bool EstadoAdopcion { get; set; }
        public List<Persona_Mascota> PersonasMascotas { get; set; }
    }
}
