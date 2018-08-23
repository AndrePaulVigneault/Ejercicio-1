using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbContextLibrary;
using Ejercicio_1EntityFramework;

namespace WebPersonasMascotas.Data
{
    public class MockPersona_Mascota : IPersona_MascotaRepository
    {
        List<Persona_Mascota> Relaciones = new List<Persona_Mascota>();

        public bool Add(Persona_Mascota Relacion)
        {
            var RelacionAgregar = Relaciones.FirstOrDefault(r => r.Persona.Cedula == Relacion.Persona.Cedula && r.Mascota.Id == Relacion.Mascota.Id);
            if (RelacionAgregar == null)
            {
                var last = Relaciones.LastOrDefault();
                if (last == null)
                {
                    Relacion.Id = 1;
                }
                else
                {
                    Relacion.Id = last.Id + 1;
                }
                Relaciones.Add(Relacion);
                return true;
            }
            return false;
        }

        public bool Delete(int Id)
        {
            try
            {
                var RemoverRelacion = Relaciones.FirstOrDefault(r => r.Id == Id);
                Relaciones.Remove(RemoverRelacion);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Edit(Persona_Mascota Relacion)
        {
            var RelacionEditar = Relaciones.FirstOrDefault(r => r.Persona.Cedula == Relacion.Persona.Cedula && r.Mascota.Id == Relacion.Mascota.Id);
            if (RelacionEditar == null)
            {
                Relaciones.FirstOrDefault(r => r.Id == Relacion.Id).Persona = Relacion.Persona;
                Relaciones.FirstOrDefault(r => r.Id == Relacion.Id).Mascota = Relacion.Mascota;
                return true;
            }
            return false;
        }

        public Persona_Mascota Find(int Id)
        {
            var Relacion = Relaciones.Single(r => r.Id == Id);
            return Relacion;
        }

        public IQueryable<Persona_Mascota> GetAll() => Relaciones.AsQueryable();

        public void Save()
        {     
        }
    }
}
