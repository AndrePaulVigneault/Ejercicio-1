using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DbContextLibrary
{
    public class Persona_Mascota
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Mascota Mascota { get; set; }
        public Persona Persona { get; set; }
    }
}
