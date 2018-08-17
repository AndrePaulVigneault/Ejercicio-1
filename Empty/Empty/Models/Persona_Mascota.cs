using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ejercicio_1EntityFramework
{
    public class Persona_Mascota
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Persona Persona { get; set; }
        public Mascota Mascota { get; set; }

    }
}
