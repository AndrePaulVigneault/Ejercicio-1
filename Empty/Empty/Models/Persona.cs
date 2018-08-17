using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ejercicio_1EntityFramework
{
    public class Persona
    {
        [Key]
        public int Cedula { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public List<Persona_Mascota> Persona_Mascota { get; set; }
    }
}
