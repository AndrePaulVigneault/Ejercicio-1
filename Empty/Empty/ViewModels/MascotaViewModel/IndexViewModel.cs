using DbContextLibrary;
using Ejercicio_1EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPersonasMascotas.ViewModels.MascotaViewModel
{
    public class IndexViewModel
    {
        public List<Mascota> Mascotas { get; set; }
    }
}
