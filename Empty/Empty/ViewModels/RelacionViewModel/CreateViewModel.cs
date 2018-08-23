using DbContextLibrary;
using Ejercicio_1EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebPersonasMascotas.ViewModels.RelacionViewModel
{
    public class CreateViewModel
    {
        [Display(Name = "Escoja La Persona que quiere ligar")]
        public string IdPersona;
        [Display(Name = "Escoja La Mascota que quiere ligar")]
        public string IdMascota;

        public IEnumerable<Persona> Personas { get; set; }
        public IEnumerable<Mascota> Mascotas { get; set; }

    }
}
