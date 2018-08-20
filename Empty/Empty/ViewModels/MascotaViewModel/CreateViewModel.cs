using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebPersonasMascotas.ViewModels
{
    public class CreateViewModel
    {

        [Required(ErrorMessage = "El Nombre de la persona es requerida")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La Raza es requerida")]
        [Display(Name = "Raza")]
        public string Raza { get; set; }
    }
}
