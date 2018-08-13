using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ejercicio_1EntityFramework
{
    public class Mascota
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Raza { get; set; }
        public bool EstadoAdopcion { get; set; }
        public List<Persona_Mascota> Persona_Mascota { get; set; }

    }
}
