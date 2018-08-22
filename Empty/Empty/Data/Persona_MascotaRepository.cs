using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ejercicio_1EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace WebPersonasMascotas.Data
{
    public class Persona_MascotaRepository : IPersona_MascotaRepository
    {
        internal DBContext _context;

        public Persona_MascotaRepository(DBContext context)
        {
            _context = context;
        }

        public bool Add(Persona_Mascota Relacion)
        {
            if (_context.Set<Persona_Mascota>().Where(s => s.Id == Relacion.Id).FirstOrDefault() == null)
            {
                _context.Set<Persona_Mascota>().Add(Relacion);
                return true;
            }
            return false;
        }

        public bool Delete(int Id)
        {
            try
            {
                _context.Set<Persona_Mascota>().Remove(_context.Set<Persona_Mascota>().Where(s => s.Id == Id).SingleOrDefault());
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool Edit(Persona_Mascota Relacion)
        {
            if (_context.Set<Persona_Mascota>().Where(s => s.Id == Relacion.Id).FirstOrDefault() != null)
            {
                _context.Entry(Relacion).State = EntityState.Modified;
                return true;
            }
            return false;

        }

        public Persona_Mascota Find(int Id)
        {
            Persona_Mascota Relacion = _context.Set<Persona_Mascota>().Where(s => s.Id == Id).FirstOrDefault();
            return Relacion;
        }

        public IQueryable<Persona_Mascota> GetAll()
        {
            IQueryable<Persona_Mascota> query = _context.Set<Persona_Mascota>();
            return query;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
