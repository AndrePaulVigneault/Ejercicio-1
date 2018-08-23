using DbContextLibrary;
using Ejercicio_1EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPersonasMascotas.Data
{
    public interface IPersona_MascotaRepository : IGenericRepository<Persona_Mascota>
    {
    }
}
