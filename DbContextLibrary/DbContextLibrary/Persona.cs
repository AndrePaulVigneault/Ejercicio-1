using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DbContextLibrary
{
    public class Persona
    {
        [Key]
        public int Cedula { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public List<Persona_Mascota> PersonasMascotas { get; set; }
    }
}
