using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebPersonasMascotas.ViewModels.PersonaViewModel
{
    public class EditViewModel
    {
        [Required(ErrorMessage = "La cedula de la persona es requerida")]
        [Display(Name = "Cedula")]
        public int Cedula { get; set; }
        [Required(ErrorMessage = "El Nombre de la persona es requerida")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La Fecha de nacimiento de la persona es requerida")]
        [DataType(DataType.Date)]
        [Display(Name = "FechaNacimiento")]
        public DateTime FechaNacimiento { get; set; }
    }
}
