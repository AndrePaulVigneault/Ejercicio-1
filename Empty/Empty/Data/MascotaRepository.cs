using DbContextLibrary;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Ejercicio_1EntityFramework.Data
{
    class MascotaRepository : IMascotaRepository
    {
        internal DBContext _context;

        public MascotaRepository(DBContext context)
        {
            _context = context;
        }

        public bool Add(Mascota mascota)
        {
            if (_context.Set<Mascota>().Where(s => s.Id == mascota.Id).FirstOrDefault() == null)
            {
                _context.Set<Mascota>().Add(mascota);
                return true;
            }
            return false;
        }

        public bool Delete(int Id)
        {
            try {
                _context.Set<Mascota>().Remove(_context.Set<Mascota>().Where(s => s.Id == Id).SingleOrDefault());
                return true;
            }catch(Exception )
            {
                return false;
            }
         
        }

        public bool Edit(Mascota mascota)
        {
            if (_context.Set<Mascota>().Where(s => s.Id == mascota.Id).FirstOrDefault() != null)
            {
                _context.Entry(mascota).State = EntityState.Modified;
                return true;
            }
            return false;
            
        }

        public Mascota Find(int Id)
        {
            Mascota mascota = _context.Set<Mascota>().Where(s => s.Id == Id).FirstOrDefault();
            return mascota;
        }

        public IQueryable<Mascota> GetAll()
        {
            IQueryable<Mascota> query = _context.Set<Mascota>();
            return query;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
